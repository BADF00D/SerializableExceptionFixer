using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;

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