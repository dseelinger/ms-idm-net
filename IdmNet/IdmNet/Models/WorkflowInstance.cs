using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
// ReSharper disable InconsistentNaming

namespace IdmNet.Models
{
    /// <summary>
    /// WorkflowInstance - A specific instance of a workflow definition that is, or has been, executed.
    /// </summary>
    public class WorkflowInstance : IdmResource
    {
        /// <summary>
        /// Parameterless CTOR
        /// </summary>
        public WorkflowInstance()
        {
            ObjectType = ForcedObjType = "WorkflowInstance";
        }

        /// <summary>
        /// Build a WorkflowInstance object from a IdmResource object
        /// </summary>
        /// <param name="resource">base class</param>
        public WorkflowInstance(IdmResource resource)
        {
            ObjectType = ForcedObjType = "WorkflowInstance";
            Attributes = resource.Attributes;
            if (resource.Creator == null)
                return;
            Creator = resource.Creator;
        }

        readonly string ForcedObjType;

        /// <summary>
        /// Object Type (can only be WorkflowInstance)
        /// </summary>
        [Required]
        public override sealed string ObjectType
        {
            get { return GetAttrValue("ObjectType"); }
            set
            {
                if (value != ForcedObjType)
                    throw new InvalidOperationException("Object Type of WorkflowInstance can only be 'WorkflowInstance'");
                SetAttrValue("ObjectType", value);
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
        /// Workflow Definition - 
        /// </summary>
        public WorkflowDefinition WorkflowDefinition
        {
            get { return GetAttr("WorkflowDefinition", _theWorkflowDefinition); }
            set 
            { 
                _theWorkflowDefinition = value;
                SetAttrValue("WorkflowDefinition", ObjectIdOrNull(value)); 
            }
        }
        private WorkflowDefinition _theWorkflowDefinition;


        /// <summary>
        /// Workflow Status - Enumeration representing the current status of a workflow instance.
        /// </summary>
        [Required]
        public string WorkflowStatus
        {
            get { return GetAttrValue("WorkflowStatus"); }
            set {
                SetAttrValue("WorkflowStatus", value); 
            }
        }


        /// <summary>
        /// Workflow Status Detail - This attribute is used to track workflow instance exceptions to assist with troubleshooting and auditing workflow execution.
        /// </summary>
        public List<string> WorkflowStatusDetail
        {
            get { return GetAttrValues("WorkflowStatusDetail"); }
            set {
                SetAttrValues("WorkflowStatusDetail", value); 
            }
        }


    }
}
