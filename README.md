# SerializableExceptionFixer
Checks if class is an Exception and if it is serializable. Any error is reported.

In order to be serializable, an exception implementation has to satisfy different conditions mentioned in [this blog](https://blogs.msdn.microsoft.com/agileer/2013/05/17/the-correct-way-to-code-a-custom-exception-class/) and [this stackoverflow answer](https://stackoverflow.com/a/100369):

* It has to be decorated with Serializable-Attribute
* There has to be a serialization constructor

Furthermore there are some recommendations for exceptions:

* Exceptions should have the Suffix Exception
* There should be a default constructor
* There should be a constructor that accepts a string
* There should be a constructor that accpets a string and an Exception                                                  

```csharp
[Serializable]
public class MyException : Exception
{
    public MyException()
    {
    }

    public MyException(string message)
        : base(message)
    {
    }

    public MyException(string message, Exception inner)
        : base(message, inner)
    {
    }

    protected MyException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
```

If thy custom exception has additional properties, these have to be public with getter and setter. Furthermore they have to be serialized by hand, implementing the ISerializable interface.

TODO add description and excample for exception with custom properties.


References:
* [Choosing the Right Type of Exception to Throw](https://blogs.msdn.microsoft.com/kcwalina/2006/07/05/choosing-the-right-type-of-exception-to-throw/) by Krzysztof Cwalina
* [The CORRECT Way to Code a Custom Exception Class](https://blogs.msdn.microsoft.com/agileer/2013/05/17/the-correct-way-to-code-a-custom-exception-class/) by Doug Seelinger
* [What is the correct way to make a custom .NET Exception serializable?
](https://stackoverflow.com/a/100369) by Daniel Fortunov and Duncan Jones
* [Serialization (C# )](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/serialization/)
* [Object Serialization in the .NET Framework](https://msdn.microsoft.com/en-us/library/ms973893.aspx) by Piet Obermeyer and Jonathan Hawkins