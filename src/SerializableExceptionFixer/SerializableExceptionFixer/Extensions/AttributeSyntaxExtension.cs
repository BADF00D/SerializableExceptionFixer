using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace SerializableExceptionFixer.Extensions
{
    public static class AttributeSyntaxExtension
    {
        public static bool IsSerializableAttribute(this AttributeSyntax attributeSyntax, SemanticModel model)
        {
            var type = model.GetSymbolInfo(attributeSyntax);

            return false;
        }
    }
}
