using System;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

// Note: all these "models" are simply required for the SOAP calls to work.  They can't really be refactored in a nice way. 
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
        private string _attrName;

        /// <summary>
        /// Don't set this directly - only use the constructor
        /// </summary>
        [XmlElement(ElementName = "AttributeType")]
        public string AttributeName { get { return _attrName; }
            set
            {
                if (String.IsNullOrWhiteSpace(value) || value.Any(Char.IsWhiteSpace) || !(Char.IsLetter(value[0])))
                    throw new ArgumentException("Cannot be Null, Empty, or Whitespace", "value");

                _attrName = value;
            }
        }

        /// <summary>
        /// Don't set this directly - only use the constructor
        /// </summary>
        [XmlAnyElement(Name = "AttributeValue")]
        public XmlElement AttributeValue { get; set; }


        /// <summary>
        /// Parameterless Constructor
        /// </summary>
        public AttributeTypeAndValue()
        {
        }

        /// <summary>
        /// Create new AttributeTypeAndValue with an attribute name and value
        /// </summary>
        /// <param name="attributeName"></param>
        /// <param name="attributeValue"></param>
        public AttributeTypeAndValue(string attributeName, string attributeValue)
        {
            AttributeName = attributeName;


            SetAttributeValue(attributeName, attributeValue);
        }

        private void SetAttributeValue(string attributeName, string attributeValue)
        {
            // Null attribute value = Remove attribute value from Identity Manager = ""
            if (attributeValue == null)
                attributeValue = "";

            var xmlDoc = new XmlDocument();

            AttributeValue = xmlDoc.CreateElement("AttributeValue", SoapConstants.DirectoryAccess);
            xmlDoc.AppendChild(AttributeValue);

            var elementAttributeData = xmlDoc.CreateElement("rm", attributeName, SoapConstants.RmNamespace);
            elementAttributeData.InnerText = attributeValue;
            AttributeValue.AppendChild(elementAttributeData);
        }
    }

    [XmlRoot(Namespace = SoapConstants.Transfer)]
    public class ResourceCreated
    {
        [XmlElement(Namespace = SoapConstants.Addressing)]
        public EndpointReference EndpointReference { get; set; }
    }

    [XmlRoot(Namespace = SoapConstants.Addressing)]
    public class EndpointReference
    {
        [XmlElement(Namespace = SoapConstants.Addressing)]
        public string Address { get; set; }

        public ReferenceProperties ReferenceProperties { get; set; }
    }

    public class ReferenceProperties
    {
        [XmlElement(Namespace = SoapConstants.RmNamespace)]
        public ResourceReferenceProperty ResourceReferenceProperty { get; set; }
    }

    public class ResourceReferenceProperty
    {
        [XmlText(Type = typeof (string))]
        public string Value { get; set; }
    }
}
