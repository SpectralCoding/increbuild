﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.0
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IncreBuild.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class ExplainStrings {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ExplainStrings() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("IncreBuild.Resources.ExplainStrings", typeof(ExplainStrings).Assembly);
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
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to - IncreBuild Says: This is the attribute which is displayed in the Windows Explorer property page, and translates to the &quot;File version&quot; box
        ///   in the &quot;Assemply Information&quot; window in the Project Properties &quot;Application&quot; tab. Most of the time this is the best attribute to reflect
        ///   a unique version that changes every time the binary is rebuilt. Suggest automatic updating every build.
        ///
        ///Typically you’ll manually set the Major and Minor AssemblyFileVersion to reflect the version of the assembly, then incre [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string AssemblyFileVersionExplainBody {
            get {
                return ResourceManager.GetString("AssemblyFileVersionExplainBody", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to - IncreBuild Says: This should be representative of an entire product release and would match marketing materials, applications
        ///   updates, etc. To effectively use this attribute (which is __NOT__ required) you would create specific Build Configs for building a
        ///   release version of the product. These Build configs would have Major/Minor set to Manual and Build/Revision set to taste.
        ///
        ///The AssemblyInformationalVersion is intended to allow coherent versioning of the entire product, which may consist of ma [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string AssemblyInformationalVersionExplainBody {
            get {
                return ResourceManager.GetString("AssemblyInformationalVersionExplainBody", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to - IncreBuild Says: If you&apos;re working alone on a project, it won&apos;t matter if this is attribute is changed. If you work on a team or send
        ///   code to other developers then read below carefully to determine when you want to break compatibility. Suggest set to Manual.
        ///
        ///The AssemblyVersion is used by the CLR to bind to strongly named assemblies. It is stored in the AssemblyDef manifest metadata
        ///table of the built assembly, and in the AssemblyRef table of any assembly that references it.
        ///
        ///This is very import [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string AssemblyVersionExplainBody {
            get {
                return ResourceManager.GetString("AssemblyVersionExplainBody", resourceCulture);
            }
        }
    }
}
