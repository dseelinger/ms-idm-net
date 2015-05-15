using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
// ReSharper disable InconsistentNaming

namespace IdmNet.Models
{
    /// <summary>
    /// Approval - 
    /// </summary>
    public class Approval : IdmResource
    {
        /// <summary>
        /// Parameterless CTOR
        /// </summary>
        public Approval()
        {
            ObjectType = ForcedObjType = "Approval";
        }

        /// <summary>
        /// Build a Approval object from a IdmResource object
        /// </summary>
        /// <param name="resource">base class</param>
        public Approval(IdmResource resource)
        {
            ObjectType = ForcedObjType = "Approval";
            Attributes = resource.Attributes;
            if (resource.Creator == null)
                return;
            Creator = resource.Creator;
        }

        readonly string ForcedObjType;

        /// <summary>
        /// Object Type (can only be Approval)
        /// </summary>
        [Required]
        public override sealed string ObjectType
        {
            get { return GetAttrValue("ObjectType"); }
            set
            {
                if (value != ForcedObjType)
                    throw new InvalidOperationException("Object Type of Approval can only be 'Approval'");
                SetAttrValue("ObjectType", value);
            }
        }

        /// <summary>
        /// Approval Duration - 
        /// </summary>
        [Required]
        public DateTime ApprovalDuration
        {
            get { return AttrToDateTime("ApprovalDuration"); }
            set { SetAttrValue("ApprovalDuration", value.ToString()); }
        }


        /// <summary>
        /// Approval Response - This is a reference type to ApprovalResponse resource
        /// </summary>
        public List<ApprovalResponse> ApprovalResponse
        {
            get { return GetMultiValuedAttr("ApprovalResponse", _theApprovalResponse); }
            set { SetMultiValuedAttr("ApprovalResponse", out _theApprovalResponse, value); }
        }
        private List<ApprovalResponse> _theApprovalResponse;


        /// <summary>
        /// Approval Status - 
        /// </summary>
        [Required]
        public string ApprovalStatus
        {
            get { return GetAttrValue("ApprovalStatus"); }
            set {
                SetAttrValue("ApprovalStatus", value); 
            }
        }


        /// <summary>
        /// Approval Threshold - 
        /// </summary>
        [Required]
        public int ApprovalThreshold
        {
            get { return AttrToInteger("ApprovalThreshold"); }
            set { 
                SetAttrValue("ApprovalThreshold", value.ToString());
            }
        }


        /// <summary>
        /// Approver - The set of approvers.
        /// </summary>
        public List<Person> Approver
        {
            get { return GetMultiValuedAttr("Approver", _theApprover); }
            set { SetMultiValuedAttr("Approver", out _theApprover, value); }
        }
        private List<Person> _theApprover;


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
        /// Endpoint Address - The endpoint address on which a workflow instance is listening.
        /// </summary>
        public List<string> EndpointAddress
        {
            get { return GetAttrValues("EndpointAddress"); }
            set {
                SetAttrValues("EndpointAddress", value); 
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


        /// <summary>
        /// Workflow Instance - 
        /// </summary>
        public WorkflowInstance WorkflowInstance
        {
            get { return GetAttr("WorkflowInstance", _theWorkflowInstance); }
            set 
            { 
                _theWorkflowInstance = value;
                SetAttrValue("WorkflowInstance", ObjectIdOrNull(value)); 
            }
        }
        private WorkflowInstance _theWorkflowInstance;


    }
}
