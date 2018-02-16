using Microsoft.CodeAnalysis;
using System.Collections.Generic;
using System.Linq;

namespace SerializableExceptionFixer.Extensions
{
    internal static class SyntaxNodeExtension
    {
        public static IEnumerable<T> DescendantNodes<T>(this SyntaxNode node) where T : SyntaxNode
        {
            return node.DescendantNodes().OfType<T>();
        }
    }
}
