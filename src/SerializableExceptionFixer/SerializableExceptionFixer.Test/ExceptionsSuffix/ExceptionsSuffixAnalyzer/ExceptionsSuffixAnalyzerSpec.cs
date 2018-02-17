using FluentAssertions;
using Microsoft.CodeAnalysis;
using NUnit.Framework;

namespace SerializableExceptionFixer.Test.ExceptionsSuffix.ExceptionsSuffixAnalyzer
{
    [TestFixture]
    internal abstract class ExceptionsSuffixAnalyzerSpec : Spec
    {
        protected readonly SerializableExceptionFixer.ExceptionsSuffix.ExceptionsSuffixAnalyzer Sut;

        protected ExceptionsSuffixAnalyzerSpec()
        {
            Sut = new SerializableExceptionFixer.ExceptionsSuffix.ExceptionsSuffixAnalyzer();
        }
    }

    [TestFixture]
    internal class If_Analyzer_runs_on_exception_without_suffix_exception : ExceptionsSuffixAnalyzerSpec
    {
        private Diagnostic[] _diagnostics;
        private const string Code = @"
using System;
using System.Runtime.Serialization;

namespace SomeNamespace
{
    [Serializable]
    public class MyClass : Exception
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
        public void Should_missing_exeption_suffix_be_notified()
        {
            _diagnostics[0].Id.Should().Be(DiagnosticIds.ExceptionsShouldEndWithExceptions);
        }
    }

    [TestFixture]
    internal class If_Analyzer_runs_on_exception_with_suffix_exception : ExceptionsSuffixAnalyzerSpec
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
    internal class If_Analyzer_runs_on_class_that_is_no_exception : ExceptionsSuffixAnalyzerSpec
    {
        private Diagnostic[] _diagnostics;
        private const string Code = @"
namespace SomeNamespace
{
    public class NoneException
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