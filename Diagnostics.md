# Obligatory rules for exceptions that should be serializable
The following rules are oblige, if you write exceptions that are used in an environment that uses serialization.


## SE1010 - Missing Serializable Attribute
An exception that should be serializable, have to be marked with the Serializable-Attribute.

**Yields an SerializationException during serialization**

```csharp
namespace SomeNamespace {
    public sealed class CustomError : Exception{
        public CustomError(){}
        public CustomError(string message):base(message){}
        public CustomError(string message, Exception inner):base(message,inner){}
        private CustomError(SerializationInfo info, StreamingContext context) : base(info,context){}
    }
}
``` 

**Fixes the problem**
```csharp
namespace SomeNamespace {
    [Serializable]
    public sealed class CustomErrorException : Exception{
        public CustomErrorException(){}
        public CustomErrorException(string message):base(message){}
        public CustomErrorException(string message, Exception inner):base(message,inner){}
        private CustomErrorException(SerializationInfo info, StreamingContext context) : base(info,context){}
    }
}
``` 

## SE1050 - Missing serialization constructor
A serializable exception should have a serialization constructor. That's a constructor 
that:
* accepts a ``SerializationInfo`` object as first parameter
* accepts a ``StreamingContext`` object as seconds parameter
* is private if exception is sealed
* is protected if exception is not sealed

The constructor can also be public, but it is recommended to make it proteced or private.

**Yields an SerializationException during deserialization**

```csharp
namespace SomeNamespace {
    [Serializable]
    public sealed class CustomError : Exception{
        public CustomError(){}
        public CustomError(string message):base(message){}
        public CustomError(string message, Exception inner):base(message,inner){}
    }
}
``` 

**Fixes the problem**
```csharp
namespace SomeNamespace {
    [Serializable]
    public sealed class CustomErrorException : Exception{
        public CustomErrorException(){}
        public CustomErrorException(string message):base(message){}
        public CustomErrorException(string message, Exception inner):base(message,inner){}
        private CustomErrorException(SerializationInfo info, StreamingContext context) : base(info,context){}
    }
}
``` 

# Recommended rules for serializable exceptions
Its recommended to obay the following rules, but they are not oblige. Most devellopers expect the rules 
to be followed, because:
* Principle of Least surprise - each Exceptions offers the same interface and looks the same way.
* Its easier to use them in mocks an fakes (did you ever try to user SQLExceptions in your code? Have fun!). 


## SE2010 - Missing parameterless constructor
Per convention, each Exception should have a parameterless constructor.

**Not recommended**
```csharp
namespace SomeNamespace {
    [Serializable]
    public sealed class CustomErrorException : Exception{
        public CustomErrorException(string message):base(message){}
        public CustomErrorException(string message, Exception inner):base(message,inner){}
        private CustomErrorException(SerializationInfo info, StreamingContext context) : base(info,context){}
    }
}
``` 
**Recommended**
```csharp
namespace SomeNamespace {
    [Serializable]
    public sealed class CustomErrorException : Exception{
        public CustomErrorException(){}
        public CustomErrorException(string message):base(message){}
        public CustomErrorException(string message, Exception inner):base(message,inner){}
        private CustomErrorException(SerializationInfo info, StreamingContext context) : base(info,context){}
    }
}
``` 
## SE2020 - Missing constructor with single parameter of type String
Per convention, each Exception should have a constructor that accepts a message.

**Not recommended**
```csharp
namespace SomeNamespace {
    [Serializable]
    public sealed class CustomErrorException : Exception{
        public CustomErrorException(){}
        public CustomErrorException(string message, Exception inner):base(message,inner){}
        private CustomErrorException(SerializationInfo info, StreamingContext context) : base(info,context){}
    }
}
``` 
**Recommended**
```csharp
namespace SomeNamespace {
    [Serializable]
    public sealed class CustomErrorException : Exception{
        public CustomErrorException(){}
        public CustomErrorException(string message):base(message){}
        public CustomErrorException(string message, Exception inner):base(message,inner){}
        private CustomErrorException(SerializationInfo info, StreamingContext context) : base(info,context){}
    }
}
``` 

## SE2030 - Missing constructor that accepts String and Exception parameter
Per convention, each Exception should have a constructor that accepts a message and an inner exception.

**Not recommended**
```csharp
namespace SomeNamespace {
    [Serializable]
    public sealed class CustomErrorException : Exception{
        public CustomErrorException(){}
        public CustomErrorException(string message):base(message){}
        private CustomErrorException(SerializationInfo info, StreamingContext context) : base(info,context){}
    }
}
``` 
**Recommended**
```csharp
namespace SomeNamespace {
    [Serializable]
    public sealed class CustomErrorException : Exception{
        public CustomErrorException(){}
        public CustomErrorException(string message):base(message){}
        public CustomErrorException(string message, Exception inner):base(message,inner){}
        private CustomErrorException(SerializationInfo info, StreamingContext context) : base(info,context){}
    }
}
``` 

## SE3010 - Exception classes should end with Exception

Per convention, each Exception should end with Exception.

**Not Recommended**

```csharp
namespace SomeNamespace {
    [Serializable]
    public sealed class CustomError : Exception{
        public CustomError(){}
        public CustomError(string message):base(message){}
        public CustomError(string message, Exception inner):base(message,inner){}
        private CustomError(SerializationInfo info, StreamingContext context) : base(info,context){}
    }
}
``` 

**Recommended**
```csharp
namespace SomeNamespace {
    [Serializable]
    public sealed class CustomErrorException : Exception{
        public CustomErrorException(){}
        public CustomErrorException(string message):base(message){}
        public CustomErrorException(string message, Exception inner):base(message,inner){}
        private CustomErrorException(SerializationInfo info, StreamingContext context) : base(info,context){}
    }
}
``` 