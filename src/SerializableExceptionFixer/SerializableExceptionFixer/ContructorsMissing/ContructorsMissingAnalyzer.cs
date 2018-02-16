using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using SerializableExceptionFixer.Extensions;
using System.Collections.Immutable;
using System.Linq;

namespace SerializableExceptionFixer.ParameterlessContructorMissing
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class ContructorsMissingAnalyzer : DiagnosticAnalyzer
    {
        #region Localization
        private static readonly LocalizableString ParameterlessConstructorMissingTitle =
            new LocalizableResourceString(nameof(Resources.ParameterlessConstructorMissingTitle), Resources.ResourceManager,
                typeof(Resources));

        private static readonly LocalizableString ParameterlessConstructorMissingMessageFormat =
            new LocalizableResourceString(nameof(Resources.ParameterlessConstructorMissingMessageFormat), Resources.ResourceManager,
                typeof(Resources));

        private static readonly LocalizableString ParameterlessConstructorMissingDescription =
            new LocalizableResourceString(nameof(Resources.ParameterlessConstructorMissingDescription), Resources.ResourceManager,
                typeof(Resources));

        private static readonly DiagnosticDescriptor ParameterlessConstructorMissingRule = new DiagnosticDescriptor(
            DiagnosticIds.SerializableExceptionAttributeMissing,
            ParameterlessConstructorMissingTitle,
            ParameterlessConstructorMissingMessageFormat,
            Constants.Category,
            DiagnosticSeverity.Error,
            true,
            ParameterlessConstructorMissingDescription);

        private static readonly LocalizableString StringConstructorMissingTitle =
            new LocalizableResourceString(nameof(Resources.StringConstructorMissingTitle), Resources.ResourceManager,
                typeof(Resources));

        private static readonly LocalizableString StringConstructorMissingMessageFormat =
            new LocalizableResourceString(nameof(Resources.StringConstructorMissingMessageFormat), Resources.ResourceManager,
                typeof(Resources));

        private static readonly LocalizableString StringConstructorMissingDescription =
            new LocalizableResourceString(nameof(Resources.StringConstructorMissingDescription), Resources.ResourceManager,
                typeof(Resources));

        private static readonly DiagnosticDescriptor StringConstructorMissingRule = new DiagnosticDescriptor(
            DiagnosticIds.ConstructorThatAcceptsStringMissing,
            StringConstructorMissingTitle,
            StringConstructorMissingMessageFormat,
            Constants.Category,
            DiagnosticSeverity.Error,
            true,
            StringConstructorMissingDescription);
        #endregion Localization

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create(ParameterlessConstructorMissingRule, StringConstructorMissingRule);

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

            var constructors = @class
                .DescendantNodes<ConstructorDeclarationSyntax>();

            if(!constructors.Any(cds => cds.IsParameterlessConstructor()))
            {
                context.ReportDiagnostic(Diagnostic.Create(ParameterlessConstructorMissingRule, @class.GetLocation()));
            }
            var classType = context.SemanticModel.GetDeclaredSymbol(@class);

            if(!classType.Constructors.Any(ctor => ctor.IsConstructorThatAcceptsString()))
            {
                context.ReportDiagnostic(Diagnostic.Create(StringConstructorMissingRule, @class.GetLocation()));
            }
        }
    }
}
