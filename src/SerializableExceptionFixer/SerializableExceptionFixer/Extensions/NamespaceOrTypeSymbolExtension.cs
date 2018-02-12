using System.Collections.Generic;
using Microsoft.CodeAnalysis;

namespace SerializableExceptionFixer.Extensions
{
    public static class NamespaceOrTypeSymbolExtension
    {
        public static string GetFullNameWithNameSpace(this INamespaceOrTypeSymbol @namespace) {
            var stack = new Stack<string>();
            while (@namespace.ContainingNamespace != null) {
                stack.Push(@namespace.Name);
                @namespace = @namespace.ContainingNamespace;
            }
            return string.Join(".", stack);
        }

        public static bool IsOfType(this INamedTypeSymbol type, string fullQualifiedName)
        {
            if(type.GetFullNameWithNameSpace() == fullQualifiedName)
            {
                return true;
            }
            if (type.BaseType == null) return false;

            return IsOfType(type.BaseType, fullQualifiedName);
        }
    }
}