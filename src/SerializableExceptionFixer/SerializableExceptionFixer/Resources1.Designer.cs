﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SerializableExceptionFixer {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("SerializableExceptionFixer.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Deprecated.
        /// </summary>
        public static string AnalyzerTitle {
            get {
                return ResourceManager.GetString("AnalyzerTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to NUnit3 does not allow async void test methods, use async Task instead. .
        /// </summary>
        public static string AsyncVoidIsDeprectedDescription {
            get {
                return ResourceManager.GetString("AsyncVoidIsDeprectedDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Async void is not allowed. use async Task instead..
        /// </summary>
        public static string AsyncVoidIsDeprectedMessageFormat {
            get {
                return ResourceManager.GetString("AsyncVoidIsDeprectedMessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ExpectedExceptionAttribute is deprecated and will be removed in NUnit3. User Asser.ShouldThrow&lt;Exception&gt; instead..
        /// </summary>
        public static string ExpectedExceptionDeprecatedDescription {
            get {
                return ResourceManager.GetString("ExpectedExceptionDeprecatedDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ExpectedExceptionAttribute is deprecated.
        /// </summary>
        public static string ExpectedExceptionDeprecatedMessageFormat {
            get {
                return ResourceManager.GetString("ExpectedExceptionDeprecatedMessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to NUnit3 does not support TestCaseSource that are instance members..
        /// </summary>
        public static string ReferencedFieldInTestCasesSourceIsNotStaticDescription {
            get {
                return ResourceManager.GetString("ReferencedFieldInTestCasesSourceIsNotStaticDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Referenced TestCaseSource has to be static.
        /// </summary>
        public static string ReferencedFieldInTestCasesSourceIsNotStaticMessageFormat {
            get {
                return ResourceManager.GetString("ReferencedFieldInTestCasesSourceIsNotStaticMessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to TestCaseSource references a memeber that does not exists.
        /// </summary>
        public static string ReferencedMemberDoesNotExistsDescription {
            get {
                return ResourceManager.GetString("ReferencedMemberDoesNotExistsDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Missing member {0}.
        /// </summary>
        public static string ReferencedMemberDoesNotExistsXMessageFormat {
            get {
                return ResourceManager.GetString("ReferencedMemberDoesNotExistsXMessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to NUnit3 does not support TestCaseSource that are instance members..
        /// </summary>
        public static string ReferencedMethodInTestCasesSourceIsNotStaticDescription {
            get {
                return ResourceManager.GetString("ReferencedMethodInTestCasesSourceIsNotStaticDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Referenced TestCaseSource has to be static.
        /// </summary>
        public static string ReferencedMethodInTestCasesSourceIsNotStaticMessageFormat {
            get {
                return ResourceManager.GetString("ReferencedMethodInTestCasesSourceIsNotStaticMessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to NUnit3 does not support TestCaseSource that are instance members..
        /// </summary>
        public static string ReferencedPropertyInTestCasesSourceIsNotStaticDescription {
            get {
                return ResourceManager.GetString("ReferencedPropertyInTestCasesSourceIsNotStaticDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Referenced TestCaseSource has to be static.
        /// </summary>
        public static string ReferencedPropertyInTestCasesSourceIsNotStaticMessageFormat {
            get {
                return ResourceManager.GetString("ReferencedPropertyInTestCasesSourceIsNotStaticMessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Desc -  Attribute missing.
        /// </summary>
        public static string SerializableAttributeMissingDescription {
            get {
                return ResourceManager.GetString("SerializableAttributeMissingDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to MEssageFormat -  Attribute missing.
        /// </summary>
        public static string SerializableAttributeMissingMessageFormat {
            get {
                return ResourceManager.GetString("SerializableAttributeMissingMessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Title -  Attribute missing.
        /// </summary>
        public static string SerializableAttributeMissingTitle {
            get {
                return ResourceManager.GetString("SerializableAttributeMissingTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ThrowsDeprecatedDescription.
        /// </summary>
        public static string String {
            get {
                return ResourceManager.GetString("String", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Abstract classes will not be run by NUnit, so this attribute can be removed.
        /// </summary>
        public static string TestFixtureOnAbstractClassIsUselessDescription {
            get {
                return ResourceManager.GetString("TestFixtureOnAbstractClassIsUselessDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to TestFixture on abstract class is useless..
        /// </summary>
        public static string TestFixtureOnAbstractClassIsUselessMessageFormat {
            get {
                return ResourceManager.GetString("TestFixtureOnAbstractClassIsUselessMessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Throws is deprecated, catch Exception yourself is recommended..
        /// </summary>
        public static string ThrowsDeprecatedDescription {
            get {
                return ResourceManager.GetString("ThrowsDeprecatedDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Throws is deprecated.
        /// </summary>
        public static string ThrowsDeprecatedMessageFormat {
            get {
                return ResourceManager.GetString("ThrowsDeprecatedMessageFormat", resourceCulture);
            }
        }
    }
}