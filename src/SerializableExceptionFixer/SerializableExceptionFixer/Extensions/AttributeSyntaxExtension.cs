using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace SerializableExceptionFixer.Extensions
{
    public static class AttributeSyntaxExtension
    {
        private static readonly string SystemSerializableAttribute = typeof(System.SerializableAttribute).FullName;

        public static bool IsSerializableAttribute(this AttributeSyntax attributeSyntax, SemanticModel model)
        {
            var ctorInfo = model.GetSymbolInfo(attributeSyntax);
            var attributeType = (ctorInfo.Symbol as IMethodSymbol)?.ContainingType;

            return attributeType.GetFullNameWithNameSpace() == SystemSerializableAttribute;
        }
    }
}
