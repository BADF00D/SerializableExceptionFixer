using Microsoft.CodeAnalysis;
using System;
using System.Linq;

namespace SerializableExceptionFixer.Extensions
{
    internal static class MethodSymbolExtension
    {
        private static readonly string SystemString = typeof(String).FullName;

        public static bool IsConstructorThatAcceptsString(this IMethodSymbol method)
        {
            if (method.MethodKind != MethodKind.Constructor) return false;
            if (method.Parameters.Count() != 1) return false;

            return method.Parameters.First().Type.GetFullNameWithNameSpace() == SystemString;
        }
    }
}
