namespace SerializableExceptionFixer
{
    public static class DiagnosticIds
    {
        public const string SerializableExceptionAttributeMissing = "SE1010";
        public const string ParameterlessConstructorMissing = "SE1020";
        public const string ConstructorThatAcceptsStringMissing = "SE1030";
        public const string ConstructorThatAcceptsStringAndExceptionMissing = "SE1040";
        public const string ConstructorThatAcceptsSerializationInfoAndStreamingContextMissing = "SE1050";
        public const string ExceptionsShouldEndWithExceptions = "SE2050";
    }
}