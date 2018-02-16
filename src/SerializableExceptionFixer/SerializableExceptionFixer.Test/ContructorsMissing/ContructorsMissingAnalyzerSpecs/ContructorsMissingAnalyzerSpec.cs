using FluentAssertions;
using Microsoft.CodeAnalysis;
using NUnit.Framework;
using SerializableExceptionFixer.ParameterlessContructorMissing;

namespace SerializableExceptionFixer.Test.ContructorsMissing.ContructorsMissingAnalyzerSpecs
{
    [TestFixture]
    internal abstract class ContructorsMissingAnalyzerSpec : Spec
    {
        protected readonly ContructorsMissingAnalyzer Sut;

        protected ContructorsMissingAnalyzerSpec()
        {
            Sut = new ContructorsMissingAnalyzer();
        }
    }

    [TestFixture]
    internal class If_Analyzer_runs_on_custom_exception_without_parameterless_constructor : ContructorsMissingAnalyzerSpec
    {
        private Diagnostic[] _diagnostics;
        private const string Code = @"
using System;
using System.Runtime.Serialization;

namespace SomeNamespace
{
    [Serializable]
    public class MyException : Exception
    {
        public MyException(string message) : base(message)
        {
        }

        public MyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}";

        protected override void BecauseOf()
        {
            _diagnostics = MyHelper.RunAnalyser(Code, Sut);
        }

        [Test]
        public void There_should_be_one_diagnostic()
        {
            _diagnostics.Length.Should().Be(1);
        }

        [Test]
        public void Should_missing_SerializableAttribute_be_labeled()
        {
            _diagnostics[0].Id.Should().Be(DiagnosticIds.ParameterlessConstructorMissing);
        }
    }

}