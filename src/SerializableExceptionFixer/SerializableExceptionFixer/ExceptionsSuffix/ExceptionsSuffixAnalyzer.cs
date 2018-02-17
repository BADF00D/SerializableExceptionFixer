using System;
using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using SerializableExceptionFixer.Extensions;

namespace SerializableExceptionFixer.ExceptionsSuffix
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class ExceptionsSuffixAnalyzer : DiagnosticAnalyzer
    {
        private static readonly string Exception = typeof(Exception).Name;

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics =>
            ImmutableArray.Create(ExceptionsSuffixRule);

        public override void Initialize(AnalysisContext context)
        {
            context.RegisterSyntaxNodeAction(AnalyseClassDeclaration, SyntaxKind.ClassDeclaration);
        }

        private static void AnalyseClassDeclaration(SyntaxNodeAnalysisContext context)
        {
            if (!(context.Node is ClassDeclarationSyntax @class)) return;

            var semnaticModel = context.SemanticModel;
            if (!semnaticModel.IsException(@class)) return;

            if (@class.Identifier.Text.EndsWith(Exception)) return;

            context.ReportDiagnostic(Diagnostic.Create(ExceptionsSuffixRule, @class.GetLocation()));
        }

        #region Localization

        private static readonly LocalizableString ExceptionsSuffixTitle =
            new LocalizableResourceString(nameof(Resources.ExceptionsSuffixMissingTitle),
                Resources.ResourceManager,
                typeof(Resources));

        private static readonly LocalizableString ExceptionsSuffixMessageFormat =
            new LocalizableResourceString(nameof(Resources.ExceptionsSuffixMessageFormat),
                Resources.ResourceManager,
                typeof(Resources));

        private static readonly LocalizableString ExceptionsSuffixDescription =
            new LocalizableResourceString(nameof(Resources.ExceptionsSuffixDescription),
                Resources.ResourceManager,
                typeof(Resources));

        private static readonly DiagnosticDescriptor ExceptionsSuffixRule = new DiagnosticDescriptor(
            DiagnosticIds.ExceptionsShouldEndWithExceptions,
            ExceptionsSuffixTitle,
            ExceptionsSuffixMessageFormat,
            Constants.CategoryNaming,
            DiagnosticSeverity.Error,
            true,
            ExceptionsSuffixDescription);

        #endregion Localization
    }
}