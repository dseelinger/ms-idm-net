using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
// ReSharper disable InconsistentNaming

namespace IdmNet.Models
{
    /// <summary>
    /// msidmRequestTargetDetail - This resource represents the target of a specific request.  These objects are used by the Reporting ETL process to model requests in the Data Warehouse.
    /// </summary>
    public class msidmRequestTargetDetail : IdmResource
    {
        /// <summary>
        /// Parameterless CTOR
        /// </summary>
        public msidmRequestTargetDetail()
        {
            ObjectType = ForcedObjType = "msidmRequestTargetDetail";
        }

        /// <summary>
        /// Build a msidmRequestTargetDetail object from a IdmResource object
        /// </summary>
        /// <param name="resource">base class</param>
        public msidmRequestTargetDetail(IdmResource resource)
        {
            Attributes = resource.Attributes;
            ObjectType = ForcedObjType = "msidmRequestTargetDetail";
            if (resource.Creator == null)
                return;
            Creator = resource.Creator;
        }

        readonly string ForcedObjType;

        /// <summary>
        /// Object Type (can only be msidmRequestTargetDetail)
        /// </summary>
        [Required]
        public override sealed string ObjectType
        {
            get { return GetAttrValue("ObjectType"); }
            set
            {
                if (value != ForcedObjType)
                    throw new InvalidOperationException("Object Type of msidmRequestTargetDetail can only be 'msidmRequestTargetDetail'");
                SetAttrValue("ObjectType", value);
            }
        }

        /// <summary>
        /// Attribute Name - This attribute defines the name of the attribute being modified on the specified target object.  This attribute comes from the request parameters of the parent request.
        /// </summary>
        public string msidmAttributeName
        {
            get { return GetAttrValue("msidmAttributeName"); }
            set {
                SetAttrValue("msidmAttributeName", value); 
            }
        }


        /// <summary>
        /// Attribute Type ID - This attribute defines the ID used to differentiate attribute types in the Data Warehouse for use in searching and filtering.
        /// </summary>
        public IdmResource msidmAttributeTypeID
        {
            get { return GetAttr("msidmAttributeTypeID", _themsidmAttributeTypeID); }
            set 
            { 
                _themsidmAttributeTypeID = value;
                SetAttrValue("msidmAttributeTypeID", ObjectIdOrNull(value)); 
            }
        }
        private IdmResource _themsidmAttributeTypeID;


        /// <summary>
        /// Attribute Type Key - This attribute defines the key used to differentiate attribute type in the Data Warehouse for use in searching and filtering.
        /// </summary>
        public int? msidmAttributeTypeKey
        {
            get { return AttrToNullableInteger("msidmAttributeTypeKey"); }
            set { 
                SetAttrValue("msidmAttributeTypeKey", value.ToString());
            }
        }


        /// <summary>
        /// Attribute Value - This attribute defines the value of the attribute being modified on the specified target object.  This attribute comes from the request parameters of the parent request.
        /// </summary>
        public string msidmAttributeValue
        {
            get { return GetAttrValue("msidmAttributeValue"); }
            set {
                SetAttrValue("msidmAttributeValue", value); 
            }
        }


        /// <summary>
        /// Is Reference - Describes whether the underlying attribute value in a request target detail object is a reference or not.
        /// </summary>
        public int? msidmIsReference
        {
            get { return AttrToNullableInteger("msidmIsReference"); }
            set { 
                SetAttrValue("msidmIsReference", value.ToString());
            }
        }


        /// <summary>
        /// Mode - This attribute defines the mode of the update occurring on the specified target object.  This attribute comes from the request parameters of the parent request.
        /// </summary>
        public string msidmMode
        {
            get { return GetAttrValue("msidmMode"); }
            set {
                SetAttrValue("msidmMode", value); 
            }
        }


        /// <summary>
        /// Request - The Request associated with the given Approval.
        /// </summary>
        public Request Request
        {
            get { return GetAttr("Request", _theRequest); }
            set 
            { 
                _theRequest = value;
                SetAttrValue("Request", ObjectIdOrNull(value)); 
            }
        }
        private Request _theRequest;


        /// <summary>
        /// Sequence ID - This attribute defines an ID which is unique for all request target detail objects associated with a single request.
        /// </summary>
        public int? msidmSequenceID
        {
            get { return AttrToNullableInteger("msidmSequenceID"); }
            set { 
                SetAttrValue("msidmSequenceID", value.ToString());
            }
        }


        /// <summary>
        /// Target - Reference to the target of a request.
        /// </summary>
        public IdmResource Target
        {
            get { return GetAttr("Target", _theTarget); }
            set 
            { 
                _theTarget = value;
                SetAttrValue("Target", ObjectIdOrNull(value)); 
            }
        }
        private IdmResource _theTarget;


        /// <summary>
        /// Target Resource Type Identifier - An identifier of the target resource type for a request.
        /// </summary>
        public ObjectTypeDescription msidmTargetObjectTypeIdentifier
        {
            get { return GetAttr("msidmTargetObjectTypeIdentifier", _themsidmTargetObjectTypeIdentifier); }
            set 
            { 
                _themsidmTargetObjectTypeIdentifier = value;
                SetAttrValue("msidmTargetObjectTypeIdentifier", ObjectIdOrNull(value)); 
            }
        }
        private ObjectTypeDescription _themsidmTargetObjectTypeIdentifier;


    }
}
