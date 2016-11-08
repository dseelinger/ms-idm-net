using System;
using System.Linq;
using System.ServiceModel.Channels;
using System.Xml;
using System.Xml.Serialization;
// ReSharper disable InconsistentNaming


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
    /// SOAP Model
    /// </summary>
    public sealed class ContextHeader : MessageHeader
    {
        /// <summary>
        /// Par of a SOAP Model
        /// </summary>
        public string WorkflowInstanceID { get; set; }

        /// <summary>
        /// Par of a SOAP Model
        /// </summary>
        public override string Name => "Context";

        /// <summary>
        /// Par of a SOAP Model
        /// </summary>
        public override string Namespace => "http://schemas.microsoft.com/ws/2006/05/context";


        /// <summary>
        /// SOAP Model Ctor
        /// </summary>
        public ContextHeader(string WorkflowInstanceID)
        {
            this.WorkflowInstanceID = WorkflowInstanceID;
        }

        /// <summary>
        /// SOAP Model Serialization helper
        /// </summary>
        protected override void OnWriteHeaderContents(XmlDictionaryWriter writer, MessageVersion messageVersion)
        {
            writer.WriteStartElement("Property", Namespace);
            // ReSharper disable once AssignNullToNotNullAttribute
            writer.WriteAttributeString("name", null, "instanceId");
            writer.WriteValue(WorkflowInstanceID);
            writer.WriteEndElement();
        }
    }

    /// <summary>
    /// Approval Response SOAP Model
    /// <remarks>
    /// Don't assume that this can be replaced by simply creating an ApprovalResposne FIM Object. It can't.
    /// </remarks>
    /// </summary>
    [XmlRoot(ElementName = "ApprovalResponse", Namespace = SoapConstants.RmNamespace)]
    public class ApprovalResponseSoapModel
    {
        /// <summary>
        /// Approval ID (with the "urn:uuid") to be approved
        /// </summary>
        [XmlElement(ElementName = "Approval", Namespace = SoapConstants.RmNamespace)]
        public string Approval { get; set; }

        /// <summary>
        /// "Approved" or "Rejected"
        /// </summary>
        [XmlElement(ElementName = "Decision", Namespace = SoapConstants.RmNamespace)]
        public string Decision { get; set; }

        /// <summary>
        /// Can only be "ApprovalResponse"
        /// </summary>
        [XmlElement(ElementName = "ObjectType", Namespace = SoapConstants.RmNamespace)]
        public string ObjectType { get; set; }

        /// <summary>
        /// Reason for the Rejection (or approval, I suppose)
        /// </summary>
        [XmlElement(ElementName = "Reason", Namespace = SoapConstants.RmNamespace)]
        public string Reason { get; set; }

        /// <summary>
        /// Default CTOR
        /// </summary>
        public ApprovalResponseSoapModel()
        {

        }

        /// <summary>
        /// Primary CTOR
        /// </summary>
        /// <param name="approvalObjectId">Approval ObjectID (without the "urn:uuid:")</param>
        /// <param name="decision">Can only be "Approved" or "Rejected"</param>
        /// <param name="reason">Optional reason for approval or rejection</param>
        public ApprovalResponseSoapModel(string approvalObjectId, string decision, string reason)
        {
            Approval = "urn:uuid:" + approvalObjectId;
            Decision = decision;
            Reason = reason;
            ObjectType = "ApprovalResponse";
        }
    }

}

