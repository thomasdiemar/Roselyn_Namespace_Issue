using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class TypeRegistorVisitor : CSharpSyntaxRewriter
    {
        public Dictionary<String, BaseTypeDeclarationSyntax> Types { get; set; }

        protected void Register(BaseTypeDeclarationSyntax node)
        {
            NamespaceDeclarationSyntax namespaceDeclarationSyntax = null;
            if (!SyntaxNodeHelper.TryGetEnclosingSyntax(node, out namespaceDeclarationSyntax))
            {
                throw new Exception("No namespace?!");
            }

            var namespaceName = namespaceDeclarationSyntax.Name.ToString();
            var fullClassName = namespaceName + "." + node.Identifier.ValueText.ToString();

            if (!Types.ContainsKey(fullClassName))
            {
                Types.Add(fullClassName, node);
            }
        }

        public override SyntaxNode VisitInterfaceDeclaration(InterfaceDeclarationSyntax node)
        {
            node = (InterfaceDeclarationSyntax)base.VisitInterfaceDeclaration(node);
            Register(node);
            return node;
        }

        public override SyntaxNode VisitStructDeclaration(StructDeclarationSyntax node)
        {
            node = (StructDeclarationSyntax)base.VisitStructDeclaration(node);
            Register(node);
            return node;
        }

        public override SyntaxNode VisitClassDeclaration(ClassDeclarationSyntax node)
        {
            node = (ClassDeclarationSyntax)base.VisitClassDeclaration(node);
            Register(node);
            return node;
        }

        public override SyntaxNode VisitEnumDeclaration(EnumDeclarationSyntax node)
        {
            node = (EnumDeclarationSyntax)base.VisitEnumDeclaration(node);
            Register(node);
            return node;
        }

    }
}
