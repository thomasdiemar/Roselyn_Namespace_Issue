using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.CodeAnalysis.MSBuild;
using Microsoft.CodeAnalysis;
using System.Threading.Tasks;
using System.Linq;
using Core;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Reflection;
using System.Text;
using FluentAssertions;

namespace Roselyn_Namespace_Issue
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestMainProjectClassReferencesInSolution()
        {
            var expectation = new List<string>
            {
                "ReferencedProject.ReferencedClass",
                "MainProject.MainHelperClass",
                "ReferencedProject.ReferenceHelperClass",
            };

            var actual = FindTypes();

            actual["MainProject.MainClass"].Should().BeEquivalentTo(expectation);
        }

        Dictionary<string, List<string>> FindTypes()
        {
            var dir = new DirectoryInfo(System.Environment.CurrentDirectory).Parent.Parent.Parent;
            var solutionpath = dir.FullName + "\\Roselyn_Namespace_Issue.sln";
            var task = FindTypes(solutionpath);
            task.Wait();
            return task.Result;
        }

        async Task<Dictionary<string, List<string>>> FindTypes(string solutionpath)
        {
            MSBuildWorkspace workspace;
            try
            {
                workspace = MSBuildWorkspace
                    .Create(new Dictionary<string, string> {
                    { "CheckForSystemRuntimeDependency", "true" },
                });
            }
            catch (ReflectionTypeLoadException e)
            {
                var builder = new StringBuilder();
                foreach (var loaderException in e.LoaderExceptions)
                {
                    builder.AppendLine(loaderException.Message);
                }
                System.Diagnostics.Debug.WriteLine(builder.ToString());
                throw;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                throw;
            }
            workspace.LoadMetadataForReferencedProjects = true;

            var solution = await workspace.OpenSolutionAsync(solutionpath);

            return FindTypes(solution);
        }

        Dictionary<string, List<string>> FindTypes(Solution solution)
        {
            //All of the sudden you have to keep track yourself of sourcefiles and other stuff in the projects
            var projects = solution.Projects
               .Select(project => project.Resolve(solution).WithAllSourceFiles())
               .ToList();

            var result = new Dictionary<string, List<string>>();
            projects.ToList().ForEach(x => FindTypes(x, result));
            return result;
        }

        async void FindTypes(Microsoft.CodeAnalysis.Project project, Dictionary<string, List<string>> Types)
        { 
            var compilation = await project.GetCompilationAsync();


            foreach (var syntaxTree in compilation.SyntaxTrees)
            {
                var types = new Dictionary<string, BaseTypeDeclarationSyntax>();
                var visitor = new TypeRegistorVisitor() { Types = types };
                visitor.Visit(syntaxTree.GetRoot());

                var semantic = compilation.GetSemanticModel(syntaxTree);

                foreach (var kv in types)
                {
                    //No problem with namespace here
                    var type = semantic.GetDeclaredSymbol(kv.Value);

                    List<string> typesForCurrentClass = null;

                    //many issues with namespace here
                    typesForCurrentClass = kv.Value
                        .DescendantNodes()
                        .Select(n => semantic.GetTypeInfo(n).Type)
                        .Where(n => n != null)
                        .Select(t => t.ContainingNamespace + "." + t.Name)
                        .Distinct()
                        .ToList();

                    Types.Add(kv.Key, typesForCurrentClass);
                }
            }
        }
    }
}
