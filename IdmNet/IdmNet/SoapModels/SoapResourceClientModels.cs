using System.Xml.Serialization;

namespace IdmNet.SoapModels
{
    /// <summary>
    /// Yet another SOAP Model
    /// </summary>
    [XmlRoot(Namespace = SoapConstants.DirectoryAccess, IsNullable = false)]
    [XmlType(AnonymousType = true)]
    public class ModifyRequest
    {
        /// <summary>
        /// Part of a SOAP model
        /// </summary>
        [XmlElement]
        public Change[] Change { get; set; }

        /// <summary>
        /// Part of a SOAP model
        /// </summary>
        [XmlAttribute(AttributeName = "Dialect", DataType = "anyURI")]
        public string Dialect { get; set; }

        /// <summary>
        /// Part of a SOAP model
        /// </summary>
        public ModifyRequest()
        {
            Dialect = SoapConstants.IdentityAttributeTypeDialect;
        }
    }

    /// <summary>
    /// Yet another SOAP Model
    /// </summary>
    [XmlRoot(Namespace = SoapConstants.DirectoryAccess)]
    public class Change : AttributeTypeAndValue
    {
        /// <summary>
        /// Part of a SOAP model
        /// </summary>
        [XmlAttribute(AttributeName = "Operation")]
        public ModeType Operation { get; set; }

        /// <summary>
        /// Part of a SOAP model
        /// </summary>
        public Change()
        {
        }

        /// <summary>
        /// Part of a SOAP model
        /// </summary>
        public Change(ModeType operation, string attrName, string attrValue)
            : base(attrName, attrValue)
        {
            Operation = operation;
        }
    }

    /// <summary>
    /// Yet another SOAP Model
    /// </summary>
    [XmlType(TypeName = "ModeType", Namespace = SoapConstants.DirectoryAccess)]
    public enum ModeType
    {
        /// <summary>
        /// Part of a SOAP model
        /// </summary>
        [XmlEnum(Name = "Replace")] Replace,

        /// <summary>
        /// Part of a SOAP model
        /// </summary>
        [XmlEnum(Name = "Add")] Add,

        /// <summary>
        /// Part of a SOAP model
        /// </summary>
        [XmlEnum(Name = "Delete")] Delete
    }

    /// <summary>
    /// Soap model
    /// </summary>
    [XmlRoot(Namespace = SoapConstants.DirectoryAccess)]
    public class BaseObjectSearchRequest
    {
        /// <summary>
        /// Part of a soap model
        /// </summary>
        [XmlAttribute] public string Dialect = SoapConstants.IdentityAttributeTypeDialect;

        /// <summary>
        /// Part of a soap model
        /// </summary>
        [XmlElement(ElementName = "AttributeType")]
        public string[] AttributeType { get; set; }
    }

    /// <summary>
    /// Soap model
    /// </summary>
    [XmlRoot(Namespace = SoapConstants.DirectoryAccess, IsNullable = false)]
    public class BaseObjectSearchResponse
    {
        /// <summary>
        /// Part of a soap model
        /// </summary>
        [XmlAnyElement(Name = "PartialAttribute")]
        public object[] PartialAttribute { get; set; }
    }

}