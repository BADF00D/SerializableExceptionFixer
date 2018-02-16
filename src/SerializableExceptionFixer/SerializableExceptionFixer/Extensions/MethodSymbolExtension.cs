using System;
using System.Linq;
using System.Runtime.Serialization;
using Microsoft.CodeAnalysis;

namespace SerializableExceptionFixer.Extensions
{
    internal static class MethodSymbolExtension
    {
        private static readonly string SystemString = typeof(string).FullName;
        private static readonly string SystemException = typeof(Exception).FullName;
        private static readonly string SystemRuntimeSerializationException = typeof(SerializationInfo).FullName;
        private static readonly string SystemRuntimeSerializationStreamingContext = typeof(StreamingContext).FullName;

        public static bool IsConstructorThatAcceptsString(this IMethodSymbol method)
        {
            if (method.MethodKind != MethodKind.Constructor) return false;
            if (method.Parameters.Count() != 1) return false;

            return method.Parameters[0].Type.GetFullNameWithNameSpace() == SystemString;
        }

        public static bool IsConstructorThatAcceptsStringAndException(this IMethodSymbol method)
        {
            if (method.MethodKind != MethodKind.Constructor) return false;
            if (method.Parameters.Count() != 2) return false;

            return method.Parameters[0].Type.GetFullNameWithNameSpace() == SystemString
                   && method.Parameters[1].Type.GetFullNameWithNameSpace() == SystemException;
        }

        public static bool IsConstructorThatAcceptsSerializationInfoAndStreamingContext(this IMethodSymbol method)
        {
            if (method.MethodKind != MethodKind.Constructor) return false;
            if (method.Parameters.Count() != 2) return false;

            return method.Parameters[0].Type.GetFullNameWithNameSpace() == SystemRuntimeSerializationException
                   && method.Parameters[1].Type.GetFullNameWithNameSpace() ==
                   SystemRuntimeSerializationStreamingContext;
        }
    }
}