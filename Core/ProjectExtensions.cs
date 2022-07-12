using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Core
{
    public static class ProjectExtensions
    {
        public static Microsoft.CodeAnalysis.Project AddDocuments(this Microsoft.CodeAnalysis.Project project, IEnumerable<string> files)
        {
            foreach (string file in files)
            {
                project = project.AddDocument(file, File.ReadAllText(file)).Project;
            }
            return project;
        }

        private static IEnumerable<string> GetAllSourceFiles(string directoryPath)
        {
            var res = Directory.GetFiles(directoryPath, "*.cs", SearchOption.AllDirectories);

            return res;
        }


        public static Microsoft.CodeAnalysis.Project WithAllSourceFiles(this Microsoft.CodeAnalysis.Project project)
        {
            string projectDirectory = Directory.GetParent(project.FilePath).FullName;
            var files = GetAllSourceFiles(projectDirectory);
            var newProject = project.AddDocuments(files);
            return newProject;
        }

        public static Microsoft.CodeAnalysis.Project Resolve(this Microsoft.CodeAnalysis.Project project, Microsoft.CodeAnalysis.Solution solution)
        {
            var csproject = ReadProjectFile(project.FilePath);
            project = ResolveProjectReferences(project, solution, csproject);
            project = ResolveReferences(project, solution, csproject);
            project = ResolveDefaultNameSpace(project, solution, csproject);
            return project;
        }

        private static Microsoft.CodeAnalysis.Project ResolveProjectReferences(Microsoft.CodeAnalysis.Project project, Solution solution, Project csproject)
        {
            var projectReferences = csproject.Items
                .OfType<ProjectItemGroup>()
                .Where(x => x.ProjectReference != null)
                .SelectMany(x => x.ProjectReference?
                    .Join(solution.Projects, y => y.Name, z => z.Name, (y, z) => new ProjectReference(z.Id)))
                            ;
            project = project.AddProjectReferences(projectReferences);
            return project;
        }

        private static Microsoft.CodeAnalysis.Project ResolveReferences(Microsoft.CodeAnalysis.Project project, Solution solution, Project csproject)
        {
            var path = new FileInfo(project.FilePath).Directory.Parent.FullName;

            var metaDataReferences =
                csproject.Items
                .OfType<ProjectItemGroup>()
                .Where(x => x.Reference != null)
                .SelectMany(x => x.Reference)
                .Where(x => x.HintPath != null)
                .Select(x => ResolvePath(path, x.HintPath))
                .Select(x => ResolveReferenceMetadata(x))
                .Where(x => x != null);

            project = project.AddMetadataReferences(metaDataReferences);

            return project;
        }

        private static MetadataReference ResolveReferenceMetadata(string fullname)
        {
            MetadataReference result = null;
            if (File.Exists(fullname)) result = MetadataReference.CreateFromFile(fullname);
            return result;
        }
        private static Microsoft.CodeAnalysis.Project ResolveSystemReferences(Microsoft.CodeAnalysis.Project project, Solution solution, Project csproject)
        {
            var path = new FileInfo(project.FilePath).Directory.Parent.FullName;

            var metaDataReferences =
                csproject.Items
                .OfType<ProjectItemGroup>()
                .Where(x => x.Reference != null)
                .SelectMany(x => x.Reference)
                .Where(x => x.HintPath == null && x.Include != null)
                .Select(x => ResolveInclude(x.Include));

            project = project.AddMetadataReferences(metaDataReferences);

            return project;
        }

        private static MetadataReference ResolveInclude(string include)
        {
            var type = Type.GetType(include);
            var ass = type.Assembly;
            var location = ass.Location;
            return MetadataReference.CreateFromFile(location);
        }

        private static string ResolvePath(string parent, string filepath)
        {
            var result = filepath;
            if (filepath.StartsWith(".."))
            {
                result = parent + "\\" + filepath.Substring(filepath.IndexOf("\\"));
            }
            return result;
        }

        private static Microsoft.CodeAnalysis.Project ResolveDefaultNameSpace(Microsoft.CodeAnalysis.Project project, Solution solution, Project csproject)
        {
            var defaultnamespace = csproject.Items
                .OfType<ProjectPropertyGroup>()
                .Select(x => {
                    var index = x.ItemsElementName.ToList().IndexOf(ItemsChoiceType.RootNamespace);
                    return index > -1 ? x.Items[index].ToString() : null;
                })
                .FirstOrDefault();

            if (defaultnamespace != null)
                project = project.WithDefaultNamespace(defaultnamespace);

            return project;
        }


        static Project ReadProjectFile(string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Project));
            Project i;

            using (Stream reader = new FileStream(filename, FileMode.Open))
            {
                i = (Project)serializer.Deserialize(reader);
            }
            return i;
        }
    }
}

//RootNamespace
