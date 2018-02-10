using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializableExceptionFixer.Extensions
{
    internal static class SemanticModelExtensions
    {
        public static bool IsException(this SemanticModel model, ClassDeclarationSyntax @class)
        {
            if (!@class.BaseList.Types.Any()) return false;

            var type = model.GetTypeInfo(@class);

            return false;
        }
    }
}
