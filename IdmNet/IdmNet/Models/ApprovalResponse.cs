using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
// ReSharper disable InconsistentNaming

namespace IdmNet.Models
{
    /// <summary>
    /// ApprovalResponse - This is the response to an approval.
    /// </summary>
    public class ApprovalResponse : IdmResource
    {
        /// <summary>
        /// Parameterless CTOR
        /// </summary>
        public ApprovalResponse()
        {
            ObjectType = ForcedObjType = "ApprovalResponse";
        }

        /// <summary>
        /// Build a ApprovalResponse object from a IdmResource object
        /// </summary>
        /// <param name="resource">base class</param>
        public ApprovalResponse(IdmResource resource)
        {
            Attributes = resource.Attributes;
            ObjectType = ForcedObjType = "ApprovalResponse";
            if (resource.Creator == null)
                return;
            Creator = resource.Creator;
        }

        readonly string ForcedObjType;

        /// <summary>
        /// Object Type (can only be ApprovalResponse)
        /// </summary>
        [Required]
        public override sealed string ObjectType
        {
            get { return GetAttrValue("ObjectType"); }
            set
            {
                if (value != ForcedObjType)
                    throw new InvalidOperationException("Object Type of ApprovalResponse can only be 'ApprovalResponse'");
                SetAttrValue("ObjectType", value);
            }
        }

        /// <summary>
        /// Approval - 
        /// </summary>
        public Approval Approval
        {
            get { return GetAttr("Approval", _theApproval); }
            set 
            { 
                _theApproval = value;
                SetAttrValue("Approval", ObjectIdOrNull(value)); 
            }
        }
        private Approval _theApproval;


        /// <summary>
        /// Computed Actor - This attribute is intended to be used to setup rights as appropriate.
        /// </summary>
        public List<IdmResource> ComputedActor
        {
            get { return GetMultiValuedAttr("ComputedActor", _theComputedActor); }
            set { SetMultiValuedAttr("ComputedActor", out _theComputedActor, value); }
        }
        private List<IdmResource> _theComputedActor;


        /// <summary>
        /// Decision - 
        /// </summary>
        [Required]
        public string Decision
        {
            get { return GetAttrValue("Decision"); }
            set {
                SetAttrValue("Decision", value); 
            }
        }


        /// <summary>
        /// Reason - 
        /// </summary>
        public string Reason
        {
            get { return GetAttrValue("Reason"); }
            set {
                SetAttrValue("Reason", value); 
            }
        }


        /// <summary>
        /// Requestor - This attribute is intended to be used to setup rights as appropriate.
        /// </summary>
        public IdmResource Requestor
        {
            get { return GetAttr("Requestor", _theRequestor); }
            set 
            { 
                _theRequestor = value;
                SetAttrValue("Requestor", ObjectIdOrNull(value)); 
            }
        }
        private IdmResource _theRequestor;


    }
}
