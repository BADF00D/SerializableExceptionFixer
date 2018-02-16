using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializableExceptionFixer.ParameterlessContructorMissing
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class ParameterlessConstructorMissingAnalyzer : DiagnosticAnalyzer
    {
        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => throw new NotImplementedException();

        public override void Initialize(AnalysisContext context)
        {
            throw new NotImplementedException();
        }
    }
}
