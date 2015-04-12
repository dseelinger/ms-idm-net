using System.Xml.Serialization;

namespace IdmNet.SoapModels
{
    [XmlRoot(Namespace = SoapConstants.DirectoryAccess, IsNullable = false)]
    [XmlType(AnonymousType = true)]
    public class ModifyRequest
    {
        [XmlElement]
        public Change[] Change { get; set; }

        [XmlAttribute(AttributeName = "Dialect", DataType = "anyURI")]
        public string Dialect { get; set; }

        public ModifyRequest()
        {
            Dialect = SoapConstants.IdentityAttributeTypeDialect;
        }
    }

    [XmlRoot(Namespace = SoapConstants.DirectoryAccess)]
    public class Change : AttributeTypeAndValue
    {
        [XmlAttribute(AttributeName = "Operation")]
        public ModeType Operation { get; set; }

        public Change()
        {
        }

        public Change(ModeType operation, string attributeType, string attributeValue)
            : base(attributeType, attributeValue)
        {
            Operation = operation;
        }
    }

    [XmlType(TypeName = "ModeType", Namespace = SoapConstants.DirectoryAccess)]
    public enum ModeType
    {
        [XmlEnum(Name = "Replace")] Replace,
        [XmlEnum(Name = "Add")] Add,
        [XmlEnum(Name = "Delete")] Delete
    }
}
