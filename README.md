# SerializableExceptionFixer

Checks if class is an Exception and if it is serializable. Any error is reported.

In order to be serializable, an exception implementation has to satisfy different conditions mentioned in [this blog](https://blogs.msdn.microsoft.com/agileer/2013/05/17/the-correct-way-to-code-a-custom-exception-class/) and [this stackoverflow answer](https://stackoverflow.com/a/100369):

- It has to be decorated with Serializable-Attribute
- There has to be a serialization constructor

Furthermore there are some recommendations for exceptions:

- Exceptions should have the Suffix Exception
- There should be a default constructor
- There should be a constructor that accepts a string
- There should be a constructor that accpets a string and an Exception
- There should be a serialization constructor

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

## Usage

The analyzer can be user in two ways:

- via Visual Studio Extension
- via NuGet

### Visual Studio Extension

You can download the extension from Visual Studio Gallery.

**Advantages**

1. Analyzers and CodeFixes are availbale in all your projects you open.

**Disadvantages**

1. Only open files get analyzed
2. It only works on each machine, where this extension is installed. If your collegue makes misstakes while implementing an exception, this extension won't help until you open the class.
3. The analyzers mark all results as errors, ut Visual Studio don't treat them as compile time errors.

### NuGet

**Advantages**

1. Analzers are part of the project and therefore each develloper has to follow the proposed rules.
2. All files get analyzers during build of the projects.
3. Errors are compile time errors.

**Disadvantages**

1. Analyzers are only available in projects, that references them.
2. Each project has to reference this NuGet-package on its own.

## Available Diagnostics

| Id     | Category      | Short Description                                        | Codefix availbale |
| ------ | ------------- | -------------------------------------------------------- | ----------------- |
| SE1010 | Serialization | [Serilizable] Attribute is missing                       | in future         |
| SE1020 | Serialization | Serialization constructor is missing                     | in future         |
| SE2010 | Convenience   | Parameterless constructor is missing                     | in future         |
| SE2020 | Convenience   | Constructor that accepts string is missing               | in future         |
| SE2030 | Convenience   | Constructor that accepts string and Exception is missing | in future         | Serialization |
| SE3010 | Naming        | Exceptions should have suffix Exception                  | in future         |

If you are interessted in the diagnostics currently availbale, see [Diagnostics](Diagnostics.md).

## TODO

- add description and examples for exception with custom properties.
- add some analyzers

  - analyze that properties and/or fields are used in constructor
  - analyze that GetObjectData() is overwritten when using fields and/or properties
  - analyze that fields and/or properties get serialized in GetObjectData() method.

- write CodeFix that makes an exception serializable
  - add [Serializable] Attribute
  - implement constructors and assign properties and fields
  - overwrite GetObjectData() and serialize properties and fields

References:

- [Choosing the Right Type of Exception to Throw](https://blogs.msdn.microsoft.com/kcwalina/2006/07/05/choosing-the-right-type-of-exception-to-throw/) by Krzysztof Cwalina
- [The CORRECT Way to Code a Custom Exception Class](https://blogs.msdn.microsoft.com/agileer/2013/05/17/the-correct-way-to-code-a-custom-exception-class/) by Doug Seelinger
- [What is the correct way to make a custom .NET Exception serializable?
  ](https://stackoverflow.com/a/100369) by Daniel Fortunov and Duncan Jones
- [Serialization (C# )](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/serialization/)
- [Object Serialization in the .NET Framework](https://msdn.microsoft.com/en-us/library/ms973893.aspx) by Piet Obermeyer and Jonathan Hawkins

CA Diagnostics:

- [CA1032: Implement standard exception constructors](https://docs.microsoft.com/it-it/visualstudio/code-quality/ca1032-implement-standard-exception-constructors?view=vs-2015)
- [CA1064: Exceptions should be public](https://docs.microsoft.com/it-it/visualstudio/code-quality/ca1064-exceptions-should-be-public?view=vs-2015)
- [CA2237: Mark ISerializable types with SerializableAttribute](https://docs.microsoft.com/de-DE/visualstudio/code-quality/ca2237-mark-iserializable-types-with-serializableattribute?view=vs-2015)
- [CA1065: Do not raise exceptions in unexpected locations](https://docs.microsoft.com/de-DE/visualstudio/code-quality/ca1065-do-not-raise-exceptions-in-unexpected-locations?view=vs-2015)
- [CA2229: Implement serialization constructors](https://docs.microsoft.com/de-DE/visualstudio/code-quality/ca2229-implement-serialization-constructors?view=vs-2015)
