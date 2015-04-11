using System;
using System.Xml;
using System.Xml.Serialization;

namespace IdmNet
{
    [XmlRoot(ElementName = "AddRequest", Namespace = SoapConstants.DirectoryAccess, IsNullable = false)]
    public class AddRequest
    {
        [XmlAttribute(AttributeName = "Dialect", DataType = "anyURI")]
        public string Dialect { get; set; }

        [XmlElement(ElementName = "AttributeTypeAndValue", IsNullable = true)]
        public AttributeTypeAndValue[] AttributeTypeAndValue { get; set; }

        public AddRequest()
        {
            Dialect = SoapConstants.IdentityAttributeTypeDialect;
        }
    }

    [XmlInclude(typeof(AttributeTypeAndValue))]
    [XmlRoot(ElementName = "AttributeTypeAndValue", Namespace = SoapConstants.DirectoryAccess, IsNullable = false)]
    public class AttributeTypeAndValue
    {
        /// <summary>
        /// Don't set this directly - only use the constructor
        /// </summary>
        [XmlElement(ElementName = "AttributeType")]
        public string AttributeName { get; set; }

        /// <summary>
        /// Don't set this directly - only use the constructor
        /// </summary>
        [XmlAnyElement(Name = "AttributeValue")]
        public object AttributeValue { get; set; }

        public AttributeTypeAndValue()
        {
        }

        public AttributeTypeAndValue(string attributeName, string attributeValue)
        {
            if (String.IsNullOrWhiteSpace(attributeName))
                throw new ArgumentException("Cannot be Null, Empty, or Whitespace", "attributeName");
            AttributeName = attributeName;

            // Null attribute value = Remove attribute value from Identity Manager = ""
            if (attributeValue == null)
                attributeValue = "";


            var xmlDoc = new XmlDocument();

            var elementAttributeValue = xmlDoc.CreateElement("AttributeValue", SoapConstants.DirectoryAccess);
            xmlDoc.AppendChild(elementAttributeValue);

            var elementAttributeData = xmlDoc.CreateElement("rm", attributeName, SoapConstants.RmNamespace);
            elementAttributeData.InnerText = attributeValue;
            elementAttributeValue.AppendChild(elementAttributeData);

            // TODO 004: try this without cloning the node once it's working
            AttributeValue = elementAttributeValue.CloneNode(true);
        }
    }

    [XmlRoot(Namespace = SoapConstants.Transfer)]
    public class ResourceCreated
    {
        [XmlElement(Namespace = SoapConstants.Addressing)]
        public EndpointReference EndpointReference { get; set; }

        // TODO 005: see if this is really needed once it's working
        public ResourceCreated() { }
    }

    [XmlRoot(Namespace = SoapConstants.Addressing)]
    public class EndpointReference
    {
        [XmlElement(Namespace = SoapConstants.Addressing)]
        public string Address { get; set; }

        public ReferenceProperties ReferenceProperties { get; set; }

        // TODO 006: see if this is really needed once it's working
        public EndpointReference() { }
    }

    public class ReferenceProperties
    {
        [XmlElement(Namespace = SoapConstants.RmNamespace)]
        public ResourceReferenceProperty ResourceReferenceProperty { get; set; }

        public ReferenceProperties()
        {
        }
    }

    public class ResourceReferenceProperty
    {
        [XmlText(Type = typeof (string))]
        public string Value { get; set; }

        public ResourceReferenceProperty()
            : this(null)
        {
        }

        public ResourceReferenceProperty(string value)
        {
            Value = value;
        }
    }
}
