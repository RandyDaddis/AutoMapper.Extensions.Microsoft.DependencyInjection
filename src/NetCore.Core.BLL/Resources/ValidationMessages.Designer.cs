﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NetCore.Core.BLL.Resources {
    using System;
    using System.Reflection;
    
    
    /// <summary>
    ///    A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class ValidationMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        internal ValidationMessages() {
        }
        
        /// <summary>
        ///    Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("NetCore.Core.BLL.Resources.ValidationMessages", typeof(ValidationMessages).GetTypeInfo().Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///    Overrides the current thread's CurrentUICulture property for all
        ///    resource lookups using this strongly typed resource class.
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
        ///    Looks up a localized string similar to Added By Is Required.
        /// </summary>
        public static string AddedByIsRequired {
            get {
                return ResourceManager.GetString("AddedByIsRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to Added Date Is Required.
        /// </summary>
        public static string AddedDateIsRequired {
            get {
                return ResourceManager.GetString("AddedDateIsRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to Changed By Is Required.
        /// </summary>
        public static string ChangedByIsRequired {
            get {
                return ResourceManager.GetString("ChangedByIsRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to Changed Date Is Required.
        /// </summary>
        public static string ChangedDateIsRequired {
            get {
                return ResourceManager.GetString("ChangedDateIsRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to Display NameI s Required.
        /// </summary>
        public static string DisplayNameIsRequired {
            get {
                return ResourceManager.GetString("DisplayNameIsRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to Duplicate Display Name Found.
        /// </summary>
        public static string DuplicateDisplayNameFound {
            get {
                return ResourceManager.GetString("DuplicateDisplayNameFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to Duplicate System Name Found.
        /// </summary>
        public static string DuplicateSystemNameFound {
            get {
                return ResourceManager.GetString("DuplicateSystemNameFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to Record Not Found.
        /// </summary>
        public static string RecordNotFound {
            get {
                return ResourceManager.GetString("RecordNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to Must be less than {1} characters.
        /// </summary>
        public static string StringLengthAttribute_InvalidMax {
            get {
                return ResourceManager.GetString("StringLengthAttribute_InvalidMax", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to {0} must be between &apos;{2}&apos; and &apos;{1}&apos; characters.
        /// </summary>
        public static string StringLengthAttribute_InvalidMaxMin {
            get {
                return ResourceManager.GetString("StringLengthAttribute_InvalidMaxMin", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to System Name Is Required.
        /// </summary>
        public static string SystemNameIsRequired {
            get {
                return ResourceManager.GetString("SystemNameIsRequired", resourceCulture);
            }
        }
    }
}
