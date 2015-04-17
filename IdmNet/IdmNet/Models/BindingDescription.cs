namespace IdmNet.Models
{
    public class BindingDescription : AttributeInfoResource
    {
        private AttributeTypeDescription _boundAttributeType;
        private ObjectTypeDescription _boundObjectType;

        public BindingDescription()
        {
        }

        public BindingDescription(IdmResource idmResource) : base(idmResource)
        {
        }

        /// <summary>
        /// A true indicates this attribute can be localized.  Only allowed for String DataTypes
        /// </summary>
        public bool? Required
        {
            get { return AttrToBool("Required"); }
            set { SetAttrValue("Required", value.ToString()); }
        }

        /// <summary>
        /// Attribute Type - The binding's attribute type
        /// </summary>
        public AttributeTypeDescription BoundAttributeType
        {
            get { return GetAttr("BoundAttributeType", _boundAttributeType); }
            set
            {
                _boundAttributeType = value;
                SetAttrValue("BoundAttributeType", value.ObjectID);
            }
        }

        /// <summary>
        /// Attribute Type - The binding's attribute type
        /// </summary>
        public ObjectTypeDescription BoundObjectType
        {
            get { return GetAttr("BoundObjectType", _boundObjectType); }
            set
            {
                _boundObjectType = value;
                SetAttrValue("BoundObjectType", value.ObjectID);
            }
        }


    }
}
