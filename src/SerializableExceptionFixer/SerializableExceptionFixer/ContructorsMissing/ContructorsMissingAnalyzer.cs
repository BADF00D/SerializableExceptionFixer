using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using SerializableExceptionFixer.Extensions;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;

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
            DiagnosticIds.ParameterlessConstructorMissing,
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

        private static readonly LocalizableString StringAndExceptionConstructorMissingTitle =
            new LocalizableResourceString(nameof(Resources.StringAndExceptionConstructorMissingTitle), Resources.ResourceManager,
                typeof(Resources));

        private static readonly LocalizableString StringAndExceptionConstructorMissingMessageFormat =
            new LocalizableResourceString(nameof(Resources.StringAndExceptionConstructorMissingMessageFormat), Resources.ResourceManager,
                typeof(Resources));

        private static readonly LocalizableString StringAndExceptionConstructorMissingDescription =
            new LocalizableResourceString(nameof(Resources.StringAndExceptionConstructorMissingDescription), Resources.ResourceManager,
                typeof(Resources));

        private static readonly DiagnosticDescriptor StringAndExceptionConstructorMissingRule = new DiagnosticDescriptor(
            DiagnosticIds.ConstructorThatAcceptsStringAndExceptionMissing,
            StringAndExceptionConstructorMissingTitle,
            StringAndExceptionConstructorMissingMessageFormat,
            Constants.Category,
            DiagnosticSeverity.Error,
            true,
            StringAndExceptionConstructorMissingDescription);

        private static readonly LocalizableString SerializationInfoAndStreamingContextConstructorMissingTitle =
            new LocalizableResourceString(nameof(Resources.SerializationInfoAndStreamingContextConstructorMissingTitle), Resources.ResourceManager,
                typeof(Resources));

        private static readonly LocalizableString SerializationInfoAndStreamingContextConstructorMissingMessageFormat =
            new LocalizableResourceString(nameof(Resources.SerializationInfoAndStreamingContextConstructorMissingMessageFormat), Resources.ResourceManager,
                typeof(Resources));

        private static readonly LocalizableString SerializationInfoAndStreamingContextConstructorMissingDescription =
            new LocalizableResourceString(nameof(Resources.SerializationInfoAndStreamingContextConstructorMissingDescription), Resources.ResourceManager,
                typeof(Resources));

        private static readonly DiagnosticDescriptor SerializationInfoAndStreamingContextConstructorMissingRule = new DiagnosticDescriptor(
            DiagnosticIds.ConstructorThatAcceptsSerializationInfoAndStreamingContextMissing,
            SerializationInfoAndStreamingContextConstructorMissingTitle,
            SerializationInfoAndStreamingContextConstructorMissingMessageFormat,
            Constants.Category,
            DiagnosticSeverity.Error,
            true,
            SerializationInfoAndStreamingContextConstructorMissingDescription);
        #endregion Localization

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create(
            ParameterlessConstructorMissingRule, 
            StringConstructorMissingRule,
            StringAndExceptionConstructorMissingRule,
            SerializationInfoAndStreamingContextConstructorMissingRule);

        public override void Initialize(AnalysisContext context)
        {
            context.RegisterSyntaxNodeAction(AnalyseClassDeclaration, SyntaxKind.ClassDeclaration);
        }

        private void AnalyseClassDeclaration(SyntaxNodeAnalysisContext context)
        {
            if (!(context.Node is ClassDeclarationSyntax @class)) return;

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

            if (!classType.Constructors.Any(ctor => ctor.IsConstructorThatAcceptsStringAndException()))
            {
                context.ReportDiagnostic(Diagnostic.Create(StringAndExceptionConstructorMissingRule, @class.GetLocation()));
            }

            if (!classType.Constructors.Any(ctor => ctor.IsConstructorThatAcceptsSerializationInfoAndStreamingContext()))
            {
                context.ReportDiagnostic(Diagnostic.Create(SerializationInfoAndStreamingContextConstructorMissingRule, @class.GetLocation()));
            }
        }
    }
}
