using System;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;


namespace IdmNet.SoapModels
{
    /// <summary>
    /// Yet another SOAP Model
    /// Note: all these "models" are simply required for the SOAP calls to work.  They can't really be refactored in a nice way. 
    /// </summary>
    [XmlRoot(ElementName = "AddRequest", Namespace = SoapConstants.DirectoryAccess, IsNullable = false)]
    public class AddRequest
    {
        /// <summary>
        /// Part of a SOAP model
        /// </summary>
        [XmlAttribute(AttributeName = "Dialect", DataType = "anyURI")]
        public string Dialect { get; set; }

        /// <summary>
        /// Part of a SOAP model
        /// </summary>
        [XmlElement(ElementName = "AttributeTypeAndValue", IsNullable = true)]
        public AttributeTypeAndValue[] AttributeTypeAndValue { get; set; }

        /// <summary>
        /// Part of a SOAP model
        /// </summary>
        public AddRequest()
        {
            Dialect = SoapConstants.IdentityAttributeTypeDialect;
        }
    }

    /// <summary>
    /// Yet another SOAP Model
    /// </summary>
    [XmlInclude(typeof (AttributeTypeAndValue))]
    [XmlRoot(ElementName = "AttributeTypeAndValue", Namespace = SoapConstants.DirectoryAccess, IsNullable = false)]
    public class AttributeTypeAndValue
    {
        private string _attrName;

        /// <summary>
        /// Don't set this directly - only use the constructor
        /// </summary>
        [XmlElement(ElementName = "AttributeType")]
        public string AttributeName
        {
            get { return _attrName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Any(char.IsWhiteSpace) || !(char.IsLetter(value[0])))
                    throw new ArgumentException("Cannot be Null, Empty, or Whitespace", nameof(value));

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
        /// <param name="attrValue"></param>
        public AttributeTypeAndValue(string attributeName, string attrValue)
        {
            AttributeName = attributeName;


            SetAttributeValue(attributeName, attrValue);
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

    /// <summary>
    /// Yet another SOAP Model
    /// </summary>
    [XmlRoot(Namespace = SoapConstants.Transfer)]
    public class ResourceCreated
    {
        /// <summary>
        /// Part of a SOAP model
        /// </summary>
        [XmlElement(Namespace = SoapConstants.Addressing)]
        public EndpointReference EndpointReference { get; set; }
    }

    /// <summary>
    /// Yet another SOAP Model
    /// </summary>
    [XmlRoot(Namespace = SoapConstants.Addressing)]
    public class EndpointReference
    {
        /// <summary>
        /// Part of a SOAP model
        /// </summary>
        [XmlElement(Namespace = SoapConstants.Addressing)]
        public string Address { get; set; }

        /// <summary>
        /// Part of a SOAP model
        /// </summary>
        public ReferenceProperties ReferenceProperties { get; set; }
    }

    /// <summary>
    /// Yet another SOAP Model
    /// </summary>
    public class ReferenceProperties
    {
        /// <summary>
        /// Part of a SOAP model
        /// </summary>
        [XmlElement(Namespace = SoapConstants.RmNamespace)]
        public ResourceReferenceProperty ResourceReferenceProperty { get; set; }
    }

    /// <summary>
    /// Yet another SOAP Model
    /// </summary>
    public class ResourceReferenceProperty
    {
        /// <summary>
        /// Part of a SOAP model
        /// </summary>
        [XmlText(Type = typeof (string))]
        public string Value { get; set; }
    }

    /// <summary>
    /// Yet another SOAP Model (for approving requests)
    /// </summary>
    [XmlRoot(ElementName = "ApprovalResponse", Namespace = SoapConstants.RmNamespace)]
    public class ApprovalResponse
    {
        /// <summary>
        /// Part of a SOAP model
        /// </summary>
        [XmlElement(ElementName = "Approval", Namespace = SoapConstants.RmNamespace)]
        public string Approval { get; set; }

        /// <summary>
        /// Part of a SOAP model
        /// </summary>
        [XmlElement(ElementName = "Decision", Namespace = SoapConstants.RmNamespace)]
        public string Decision { get; set; }

        /// <summary>
        /// Part of a SOAP model
        /// </summary>
        [XmlElement(ElementName = "ObjectType", Namespace = SoapConstants.RmNamespace)]
        public string ObjectType { get; set; }

        /// <summary>
        /// Part of a SOAP model
        /// </summary>
        [XmlElement(ElementName = "Reason", Namespace = SoapConstants.RmNamespace)]
        public string Reason { get; set; }

        /// <summary>
        /// Part of a SOAP model
        /// </summary>
        [XmlIgnore]
        public string WorkflowInstanceID { get; set; }

        /// <summary>
        /// SOAP Model constructor
        /// </summary>
        public ApprovalResponse()
        {
            ObjectType = "ApprovalResponse";
        }

    }
}

