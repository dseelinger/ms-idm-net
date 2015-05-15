using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
// ReSharper disable InconsistentNaming

namespace IdmNet.Models
{
    /// <summary>
    /// Request - 
    /// </summary>
    public class Request : IdmResource
    {
        /// <summary>
        /// Parameterless CTOR
        /// </summary>
        public Request()
        {
            ObjectType = ForcedObjType = "Request";
        }

        /// <summary>
        /// Build a Request object from a IdmResource object
        /// </summary>
        /// <param name="resource">base class</param>
        public Request(IdmResource resource)
        {
            ObjectType = ForcedObjType = "Request";
            Attributes = resource.Attributes;
            if (resource.Creator == null)
                return;
            Creator = resource.Creator;
        }

        readonly string ForcedObjType;

        /// <summary>
        /// Object Type (can only be Request)
        /// </summary>
        [Required]
        public override sealed string ObjectType
        {
            get { return GetAttrValue("ObjectType"); }
            set
            {
                if (value != ForcedObjType)
                    throw new InvalidOperationException("Object Type of Request can only be 'Request'");
                SetAttrValue("ObjectType", value);
            }
        }

        /// <summary>
        /// Action Workflow Instance - A reference to a workflow instance executed during the action phase of request processing.
        /// </summary>
        public List<WorkflowInstance> ActionWorkflowInstance
        {
            get { return GetMultiValuedAttr("ActionWorkflowInstance", _theActionWorkflowInstance); }
            set { SetMultiValuedAttr("ActionWorkflowInstance", out _theActionWorkflowInstance, value); }
        }
        private List<WorkflowInstance> _theActionWorkflowInstance;


        /// <summary>
        /// Authentication Workflow Instance - A reference to a workflow instance executed during the authentication phase of request processing.
        /// </summary>
        public List<WorkflowInstance> AuthenticationWorkflowInstance
        {
            get { return GetMultiValuedAttr("AuthenticationWorkflowInstance", _theAuthenticationWorkflowInstance); }
            set { SetMultiValuedAttr("AuthenticationWorkflowInstance", out _theAuthenticationWorkflowInstance, value); }
        }
        private List<WorkflowInstance> _theAuthenticationWorkflowInstance;


        /// <summary>
        /// Authorization Workflow Instance - A reference to a workflow instance executed during the authorization phase of request processing.
        /// </summary>
        public List<WorkflowInstance> AuthorizationWorkflowInstance
        {
            get { return GetMultiValuedAttr("AuthorizationWorkflowInstance", _theAuthorizationWorkflowInstance); }
            set { SetMultiValuedAttr("AuthorizationWorkflowInstance", out _theAuthorizationWorkflowInstance, value); }
        }
        private List<WorkflowInstance> _theAuthorizationWorkflowInstance;


        /// <summary>
        /// Committed Time - The time when the data operation of a request was committed to the system.
        /// </summary>
        public DateTime? CommittedTime
        {
            get { return AttrToNullableDateTime("CommittedTime"); }
            set { SetAttrValue("CommittedTime", value.ToString()); }
        }


        /// <summary>
        /// Completed Time - The time at which a request is no longer processing workflows and has reached its final status.
        /// </summary>
        public DateTime? msidmCompletedTime
        {
            get { return AttrToNullableDateTime("msidmCompletedTime"); }
            set { SetAttrValue("msidmCompletedTime", value.ToString()); }
        }


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
        /// Has Collateral Request - This request requires action workflows to be run on alternate targets and must wait for these collateral requests to finish before it can be completed.
        /// </summary>
        public bool? HasCollateralRequest
        {
            get { return AttrToNullableBool("HasCollateralRequest"); }
            set { 
                SetAttrValue("HasCollateralRequest", value.ToString());
            }
        }


        /// <summary>
        /// Management Policy Rule - A reference to a management policy resource triggered by a request.
        /// </summary>
        public List<ManagementPolicyRule> ManagementPolicy
        {
            get { return GetMultiValuedAttr("ManagementPolicy", _theManagementPolicy); }
            set { SetMultiValuedAttr("ManagementPolicy", out _theManagementPolicy, value); }
        }
        private List<ManagementPolicyRule> _theManagementPolicy;


        /// <summary>
        /// Operation - 
        /// </summary>
        [Required]
        public string Operation
        {
            get { return GetAttrValue("Operation"); }
            set {
                SetAttrValue("Operation", value); 
            }
        }


        /// <summary>
        /// Parent Request - The Request that created this Request.  If this Request was not created by a workflow, this attribute will not have a value.
        /// </summary>
        public Request ParentRequest
        {
            get { return GetAttr("ParentRequest", _theParentRequest); }
            set 
            { 
                _theParentRequest = value;
                SetAttrValue("ParentRequest", ObjectIdOrNull(value)); 
            }
        }
        private Request _theParentRequest;


        /// <summary>
        /// Request Context - This includes additional request context.
        /// </summary>
        public msidmRequestContext msidmRequestContext
        {
            get { return GetAttr("msidmRequestContext", _themsidmRequestContext); }
            set 
            { 
                _themsidmRequestContext = value;
                SetAttrValue("msidmRequestContext", ObjectIdOrNull(value)); 
            }
        }
        private msidmRequestContext _themsidmRequestContext;


        /// <summary>
        /// Request Control - Used to alter normal processing of a Request.
        /// </summary>
        public string RequestControl
        {
            get { return GetAttrValue("RequestControl"); }
            set {
                SetAttrValue("RequestControl", value); 
            }
        }


        /// <summary>
        /// Request Parameters - Serialized strongly typed request parameter that describes the details of an operation associated with a request.
        /// </summary>
        public List<string> RequestParameter
        {
            get { return GetAttrValues("RequestParameter"); }
            set {
                SetAttrValues("RequestParameter", value); 
            }
        }


        /// <summary>
        /// Request Status - This is a request status type Enum
        /// </summary>
        [Required]
        public string RequestStatus
        {
            get { return GetAttrValue("RequestStatus"); }
            set {
                SetAttrValue("RequestStatus", value); 
            }
        }


        /// <summary>
        /// Request Status Detail - Additional request information generated during the processing of this request. This may contain information messages or details of errors.
        /// </summary>
        public List<string> RequestStatusDetail
        {
            get { return GetAttrValues("RequestStatusDetail"); }
            set {
                SetAttrValues("RequestStatusDetail", value); 
            }
        }


        /// <summary>
        /// Service Partition Name - This attribute identifies the ServicePartitionName assigned to this Request. The Request and its Workflow Instances can only be processed by FIM Service instances that have this ServicePartitionName.
        /// </summary>
        public string ServicePartitionName
        {
            get { return GetAttrValue("ServicePartitionName"); }
            set {
                SetAttrValue("ServicePartitionName", value); 
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
        /// Target Resource Type - Which resource type this configuration applies to
        /// </summary>
        public string TargetObjectType
        {
            get { return GetAttrValue("TargetObjectType"); }
            set {
                SetAttrValue("TargetObjectType", value); 
            }
        }


    }
}
