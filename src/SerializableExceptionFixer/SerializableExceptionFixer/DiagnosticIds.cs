namespace SerializableExceptionFixer
{
    public static class DiagnosticIds
    {
        public const string SerializableExceptionAttributeMissing = "SE1010";
        public const string ConstructorThatAcceptsSerializationInfoAndStreamingContextMissing = "SE1020";

        public const string ParameterlessConstructorMissing = "SE2010";
        public const string ConstructorThatAcceptsStringMissing = "SE2020";
        public const string ConstructorThatAcceptsStringAndExceptionMissing = "SE2030";
        
        public const string ExceptionsShouldEndWithExceptions = "SE3010";
    }
}