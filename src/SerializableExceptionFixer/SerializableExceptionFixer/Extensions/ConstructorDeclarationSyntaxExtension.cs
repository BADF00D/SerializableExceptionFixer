using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Linq;

namespace SerializableExceptionFixer.Extensions
{
    internal static class ConstructorDeclarationSyntaxExtension
    {
        public static bool IsParameterlessConstructor(this ConstructorDeclarationSyntax constructor)
        {
            return constructor.ParameterList.Parameters.Count == 0;
        }
    }
}
