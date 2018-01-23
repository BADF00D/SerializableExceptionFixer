using System.Linq;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace SerializableExceptionFixer.Extensions
{
    public static class QualifiedNameSyntaxExtensions
    {
        public static bool Is(this QualifiedNameSyntax qns, params string[] namespaces)
        {
            if (namespaces.Length == 2)
            {
                return (qns.Left as IdentifierNameSyntax)?.Identifier.Text == namespaces[0]
                       && (qns.Right as IdentifierNameSyntax)?.Identifier.Text == namespaces[1];
            }
            return (qns.Right as IdentifierNameSyntax)?.Identifier.Text == namespaces.Last()
                   && Is(qns, namespaces.Take(namespaces.Length - 1).ToArray());
        }
    }
}