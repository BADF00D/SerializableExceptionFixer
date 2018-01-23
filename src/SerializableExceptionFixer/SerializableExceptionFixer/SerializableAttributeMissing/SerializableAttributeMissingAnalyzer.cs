using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using System;
using System.Collections.Immutable;

namespace SerializableExceptionFixer.Analyzers
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class SerializableAttributeMissingAnalyzer : DiagnosticAnalyzer
    {
        private static readonly LocalizableString SerializableAttributeMissingTitle =
            new LocalizableResourceString(nameof(Resources.SerializableAttributeMissingTitle), Resources.ResourceManager,
                typeof(Resources));

        private static readonly LocalizableString SerializableAttributeMissingMessageFormat =
            new LocalizableResourceString(nameof(Resources.SerializableAttributeMissingMessageFormat), Resources.ResourceManager,
                typeof(Resources));

        private static readonly LocalizableString SerializableAttributeMissingDescription =
            new LocalizableResourceString(nameof(Resources.SerializableAttributeMissingDescription), Resources.ResourceManager,
                typeof(Resources));

        private static readonly DiagnosticDescriptor SerializableAttributeMissingRule = new DiagnosticDescriptor(
            DiagnosticIds.SerializableExceptionAttributeMissing,
            SerializableAttributeMissingTitle,
            SerializableAttributeMissingMessageFormat,
            Constants.Category,
            DiagnosticSeverity.Error,
            true,
            SerializableAttributeMissingDescription);

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics =>
            ImmutableArray.Create(SerializableAttributeMissingRule);

        public override void Initialize(AnalysisContext context)
        {
            throw new NotImplementedException();
        }
    }
}
