namespace IdmNet.Models
{
    public class AttributeTypeDescription : AttributeInfoResource
    {
        public AttributeTypeDescription()
        {
        }

        public AttributeTypeDescription(IdmResource idmResource) : base(idmResource)
        {
        }

        /// <summary>
        /// (Binary|Boolean|DateTime|Integer|Reference|String|Text)
        /// </summary>
        public string DataType 
        {
            get { return GetAttrValue("DataType"); }
            set { SetAttrValue("DataType", value); }
        }

        /// <summary>
        /// (required) A true indicates this attribute can be localized.  Only allowed for String DataTypes
        /// </summary>
        public bool MultiValued 
        {
            get { return AttrToBool("MultiValued") == true; }
            set { SetAttrValue("MultiValued", value.ToString()); }
        }


    }
}
