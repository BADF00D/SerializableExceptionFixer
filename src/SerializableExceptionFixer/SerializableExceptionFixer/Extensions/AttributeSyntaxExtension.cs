using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace SerializableExceptionFixer.Extensions
{
    public static class AttributeSyntaxExtension
    {
        public static bool IsSerializableAttribute(this AttributeSyntax attributeSyntax, SemanticModel model)
        {
            var ctorInfo = model.GetSymbolInfo(attributeSyntax);
            var attributeType = (ctorInfo.Symbol as IMethodSymbol)?.ContainingType;

            if(attributeType.GetFullNameWithNameSpace() == "System.SerializableAttribute")
            {
                return true;
            }
            return false;
        }
    }
}
