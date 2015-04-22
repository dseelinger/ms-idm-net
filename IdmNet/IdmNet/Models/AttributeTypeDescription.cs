namespace IdmNet.Models
{
    /// <summary>
    /// Attribute Type Description - This describes an attribute type
    /// </summary>
    public class AttributeTypeDescription : AttributeInfoResource
    {
        /// <summary>
        /// Parameterless CTOR
        /// </summary>
        public AttributeTypeDescription()
        {
        }

        /// <summary>
        /// Base CTOR
        /// </summary>
        /// <param name="idmResource">base class</param>
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
        public bool Multivalued 
        {
            get { return AttrToBool("Multivalued") == true; }
            set { SetAttrValue("Multivalued", value.ToString()); }
        }


    }
}
