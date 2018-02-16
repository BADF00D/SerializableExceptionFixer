using Microsoft.CodeAnalysis.CSharp.Syntax;

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