using FluentAssertions;
using Microsoft.CodeAnalysis;
using NUnit.Framework;
using SerializableExceptionFixer.SerializableAttributeMissing;

namespace SerializableExceptionFixer.Test.SerializableAttributeMissing.SerializableAttributeMissingAnalyzerSpecs
{

    internal abstract class SerializableAttributeMissingAnalyzerSpec : Spec
    {
        protected readonly SerializableAttributeMissingAnalyzer Sut;
        public SerializableAttributeMissingAnalyzerSpec()
        {
            Sut = new SerializableAttributeMissingAnalyzer();
        }
    }

    [TestFixture]
    internal class If_Analyzer_runs_on_custom_exception_without_serialable_attribute : SerializableAttributeMissingAnalyzerSpec
    {
        private Diagnostic[] _diagnostics;
        private const string Code = @"
namespace SomeNamespace
{
    public class MyException : System.Exception
    {
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
            _diagnostics[0].Id.Should().Be(DiagnosticIds.SerializableExceptionAttributeMissing);
        }
    }

    [TestFixture]
    internal class If_Analyzer_runs_on_none_exception : SerializableAttributeMissingAnalyzerSpec
    {
        private Diagnostic[] _diagnostics;
        private const string Code = @"
namespace SomeNamespace
{
    public class MyException : System.IO.MemoryStream
    {
    }
}";

        protected override void BecauseOf()
        {
            _diagnostics = MyHelper.RunAnalyser(Code, Sut);
        }

        [Test]
        public void There_should_be_no_diagnostic()
        {
            _diagnostics.Length.Should().Be(0);
        }
    }

    [TestFixture]
    internal class If_Analyzer_runs_on_custom_exception_with_serializable_attribute : SerializableAttributeMissingAnalyzerSpec
    {
        private Diagnostic[] _diagnostics;
        private const string Code = @"
namespace SomeNamespace
{
    [System.Serializable]
    public class MyException : System.Exception
    {
    }
}";

        protected override void BecauseOf()
        {
            _diagnostics = MyHelper.RunAnalyser(Code, Sut);
        }

        [Test]
        public void There_should_be_no_diagnostic()
        {
            _diagnostics.Length.Should().Be(0);
        }
    }
}
