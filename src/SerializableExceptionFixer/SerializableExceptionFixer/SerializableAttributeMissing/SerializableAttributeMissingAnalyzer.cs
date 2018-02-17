using System.Collections.Immutable;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using SerializableExceptionFixer.Extensions;

namespace SerializableExceptionFixer.SerializableAttributeMissing
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class SerializableAttributeMissingAnalyzer : DiagnosticAnalyzer
    {
        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics =>
            ImmutableArray.Create(SerializableAttributeMissingRule);

        public override void Initialize(AnalysisContext context)
        {
            context.RegisterSyntaxNodeAction(AnalyseClassDeclaration, SyntaxKind.ClassDeclaration);
        }

        private void AnalyseClassDeclaration(SyntaxNodeAnalysisContext context)
        {
            var @class = context.Node as ClassDeclarationSyntax;
            if (@class == null) return;

            var semnaticModel = context.SemanticModel;
            if (!semnaticModel.IsException(@class)) return;

            var serializationAttributes = @class.AttributeLists
                .SelectMany(als => als.Attributes)
                .Where(a => a.IsSerializableAttribute(context.SemanticModel))
                .ToArray();

            if (serializationAttributes.Any()) return;

            context.ReportDiagnostic(Diagnostic.Create(SerializableAttributeMissingRule, @class.GetLocation()));
        }

        #region Localization

        private static readonly LocalizableString SerializableAttributeMissingTitle =
            new LocalizableResourceString(nameof(Resources.SerializableAttributeMissingTitle),
                Resources.ResourceManager,
                typeof(Resources));

        private static readonly LocalizableString SerializableAttributeMissingMessageFormat =
            new LocalizableResourceString(nameof(Resources.SerializableAttributeMissingMessageFormat),
                Resources.ResourceManager,
                typeof(Resources));

        private static readonly LocalizableString SerializableAttributeMissingDescription =
            new LocalizableResourceString(nameof(Resources.SerializableAttributeMissingDescription),
                Resources.ResourceManager,
                typeof(Resources));

        private static readonly DiagnosticDescriptor SerializableAttributeMissingRule = new DiagnosticDescriptor(
            DiagnosticIds.SerializableExceptionAttributeMissing,
            SerializableAttributeMissingTitle,
            SerializableAttributeMissingMessageFormat,
            Constants.CategorySerialization,
            DiagnosticSeverity.Error,
            true,
            SerializableAttributeMissingDescription);

        #endregion Localization
    }
}