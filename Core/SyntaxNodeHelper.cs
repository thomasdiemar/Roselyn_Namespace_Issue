using Microsoft.CodeAnalysis;

namespace Core
{
    static class SyntaxNodeHelper
    {
        public static bool TryGetEnclosingSyntax<T>(SyntaxNode syntaxNode, out T result)
            where T : SyntaxNode
        {
            // set defaults
            result = null;

            if (syntaxNode == null)
            {
                return false;
            }

            try
            {
                syntaxNode = syntaxNode.Parent;

                if (syntaxNode == null)
                {
                    return false;
                }

                if (syntaxNode.GetType() == typeof(T))
                {
                    result = syntaxNode as T;
                    return true;
                }

                return TryGetEnclosingSyntax<T>(syntaxNode, out result);
            }
            catch
            {
                return false;
            }
        }
    }
}
