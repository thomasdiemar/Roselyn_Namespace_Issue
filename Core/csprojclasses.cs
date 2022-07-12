using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/developer/msbuild/2003")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://schemas.microsoft.com/developer/msbuild/2003", IsNullable = false)]
    public partial class Project
    {

        private object[] itemsField;

        private decimal toolsVersionField;

        private string defaultTargetsField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Import", typeof(ProjectImport))]
        [System.Xml.Serialization.XmlElementAttribute("ItemGroup", typeof(ProjectItemGroup))]
        [System.Xml.Serialization.XmlElementAttribute("PropertyGroup", typeof(ProjectPropertyGroup))]
        [System.Xml.Serialization.XmlElementAttribute("Target", typeof(ProjectTarget))]
        public object[] Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal ToolsVersion
        {
            get
            {
                return this.toolsVersionField;
            }
            set
            {
                this.toolsVersionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string DefaultTargets
        {
            get
            {
                return this.defaultTargetsField;
            }
            set
            {
                this.defaultTargetsField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/developer/msbuild/2003")]
    public partial class ProjectImport
    {

        private string projectField;

        private string conditionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Project
        {
            get
            {
                return this.projectField;
            }
            set
            {
                this.projectField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Condition
        {
            get
            {
                return this.conditionField;
            }
            set
            {
                this.conditionField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/developer/msbuild/2003")]
    public partial class ProjectItemGroup
    {

        private ProjectItemGroupProjectReference[] projectReferenceField;

        private ProjectItemGroupNone[] noneField;

        private ProjectItemGroupCompile[] compileField;

        private ProjectItemGroupReference[] referenceField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ProjectReference")]
        public ProjectItemGroupProjectReference[] ProjectReference
        {
            get
            {
                return this.projectReferenceField;
            }
            set
            {
                this.projectReferenceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("None")]
        public ProjectItemGroupNone[] None
        {
            get
            {
                return this.noneField;
            }
            set
            {
                this.noneField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Compile")]
        public ProjectItemGroupCompile[] Compile
        {
            get
            {
                return this.compileField;
            }
            set
            {
                this.compileField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Reference")]
        public ProjectItemGroupReference[] Reference
        {
            get
            {
                return this.referenceField;
            }
            set
            {
                this.referenceField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/developer/msbuild/2003")]
    public partial class ProjectItemGroupProjectReference
    {

        private string projectField;

        private string nameField;

        private string includeField;

        /// <remarks/>
        public string Project
        {
            get
            {
                return this.projectField;
            }
            set
            {
                this.projectField = value;
            }
        }

        /// <remarks/>
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Include
        {
            get
            {
                return this.includeField;
            }
            set
            {
                this.includeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/developer/msbuild/2003")]
    public partial class ProjectItemGroupNone
    {

        private string includeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Include
        {
            get
            {
                return this.includeField;
            }
            set
            {
                this.includeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/developer/msbuild/2003")]
    public partial class ProjectItemGroupCompile
    {

        private string includeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Include
        {
            get
            {
                return this.includeField;
            }
            set
            {
                this.includeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/developer/msbuild/2003")]
    public partial class ProjectItemGroupReference
    {

        private string hintPathField;

        private string[] privateField;

        private string embedInteropTypesField;

        private string includeField;

        /// <remarks/>
        public string HintPath
        {
            get
            {
                return this.hintPathField;
            }
            set
            {
                this.hintPathField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Private")]
        public string[] Private
        {
            get
            {
                return this.privateField;
            }
            set
            {
                this.privateField = value;
            }
        }

        /// <remarks/>
        public string EmbedInteropTypes
        {
            get
            {
                return this.embedInteropTypesField;
            }
            set
            {
                this.embedInteropTypesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Include
        {
            get
            {
                return this.includeField;
            }
            set
            {
                this.includeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/developer/msbuild/2003")]
    public partial class ProjectPropertyGroup
    {

        private object[] itemsField;

        private ItemsChoiceType[] itemsElementNameField;

        private string conditionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AppDesignerFolder", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("AssemblyName", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("AssemblyOriginatorKeyFile", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("CodeAnalysisRuleSet", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("Configuration", typeof(ProjectPropertyGroupConfiguration))]
        [System.Xml.Serialization.XmlElementAttribute("DebugSymbols", typeof(bool))]
        [System.Xml.Serialization.XmlElementAttribute("DebugType", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("DefineConstants", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("ErrorReport", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("FileAlignment", typeof(ushort))]
        [System.Xml.Serialization.XmlElementAttribute("LangVersion", typeof(decimal))]
        [System.Xml.Serialization.XmlElementAttribute("NuGetPackageImportStamp", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("Optimize", typeof(bool))]
        [System.Xml.Serialization.XmlElementAttribute("OutputPath", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("OutputType", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("Platform", typeof(ProjectPropertyGroupPlatform))]
        [System.Xml.Serialization.XmlElementAttribute("PlatformTarget", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("ProjectGuid", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("RootNamespace", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("SccAuxPath", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("SccLocalPath", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("SccProjectName", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("SccProvider", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("SignAssembly", typeof(bool))]
        [System.Xml.Serialization.XmlElementAttribute("TargetFrameworkProfile", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("TargetFrameworkVersion", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("WarningLevel", typeof(byte))]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
        public object[] Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemsChoiceType[] ItemsElementName
        {
            get
            {
                return this.itemsElementNameField;
            }
            set
            {
                this.itemsElementNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Condition
        {
            get
            {
                return this.conditionField;
            }
            set
            {
                this.conditionField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/developer/msbuild/2003")]
    public partial class ProjectPropertyGroupConfiguration
    {

        private string conditionField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Condition
        {
            get
            {
                return this.conditionField;
            }
            set
            {
                this.conditionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/developer/msbuild/2003")]
    public partial class ProjectPropertyGroupPlatform
    {

        private string conditionField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Condition
        {
            get
            {
                return this.conditionField;
            }
            set
            {
                this.conditionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/developer/msbuild/2003", IncludeInSchema = false)]
    public enum ItemsChoiceType
    {

        /// <remarks/>
        AppDesignerFolder,

        /// <remarks/>
        AssemblyName,

        /// <remarks/>
        AssemblyOriginatorKeyFile,

        /// <remarks/>
        CodeAnalysisRuleSet,

        /// <remarks/>
        Configuration,

        /// <remarks/>
        DebugSymbols,

        /// <remarks/>
        DebugType,

        /// <remarks/>
        DefineConstants,

        /// <remarks/>
        ErrorReport,

        /// <remarks/>
        FileAlignment,

        /// <remarks/>
        LangVersion,

        /// <remarks/>
        NuGetPackageImportStamp,

        /// <remarks/>
        Optimize,

        /// <remarks/>
        OutputPath,

        /// <remarks/>
        OutputType,

        /// <remarks/>
        Platform,

        /// <remarks/>
        PlatformTarget,

        /// <remarks/>
        ProjectGuid,

        /// <remarks/>
        RootNamespace,

        /// <remarks/>
        SccAuxPath,

        /// <remarks/>
        SccLocalPath,

        /// <remarks/>
        SccProjectName,

        /// <remarks/>
        SccProvider,

        /// <remarks/>
        SignAssembly,

        /// <remarks/>
        TargetFrameworkProfile,

        /// <remarks/>
        TargetFrameworkVersion,

        /// <remarks/>
        WarningLevel,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/developer/msbuild/2003")]
    public partial class ProjectTarget
    {

        private ProjectTargetPropertyGroup propertyGroupField;

        private ProjectTargetError[] errorField;

        private string nameField;

        private string beforeTargetsField;

        /// <remarks/>
        public ProjectTargetPropertyGroup PropertyGroup
        {
            get
            {
                return this.propertyGroupField;
            }
            set
            {
                this.propertyGroupField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Error")]
        public ProjectTargetError[] Error
        {
            get
            {
                return this.errorField;
            }
            set
            {
                this.errorField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string BeforeTargets
        {
            get
            {
                return this.beforeTargetsField;
            }
            set
            {
                this.beforeTargetsField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/developer/msbuild/2003")]
    public partial class ProjectTargetPropertyGroup
    {

        private string errorTextField;

        /// <remarks/>
        public string ErrorText
        {
            get
            {
                return this.errorTextField;
            }
            set
            {
                this.errorTextField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/developer/msbuild/2003")]
    public partial class ProjectTargetError
    {

        private string conditionField;

        private string textField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Condition
        {
            get
            {
                return this.conditionField;
            }
            set
            {
                this.conditionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }
    }

}
