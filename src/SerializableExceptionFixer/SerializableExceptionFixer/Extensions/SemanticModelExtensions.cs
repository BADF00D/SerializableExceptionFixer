using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace SerializableExceptionFixer.Extensions
{
    internal static class SemanticModelExtensions
    {
        public static bool IsException(this SemanticModel model, ClassDeclarationSyntax @class)
        {
            if (!@class.BaseList.Types.Any()) return false;


            if (model.GetDeclaredSymbol(@class) is INamedTypeSymbol nts) return nts.IsOfType("System.Exception");
            return false;
        }
    }
}