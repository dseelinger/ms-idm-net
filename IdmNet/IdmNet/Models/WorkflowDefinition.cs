using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
// ReSharper disable InconsistentNaming

namespace IdmNet.Models
{
    /// <summary>
    /// WorkflowDefinition - The declaritive definition of a workflow available for execution during request processing.
    /// </summary>
    public class WorkflowDefinition : IdmResource
    {
        /// <summary>
        /// Parameterless CTOR
        /// </summary>
        public WorkflowDefinition()
        {
            ObjectType = ForcedObjType = "WorkflowDefinition";
        }

        /// <summary>
        /// Build a WorkflowDefinition object from a IdmResource object
        /// </summary>
        /// <param name="resource">base class</param>
        public WorkflowDefinition(IdmResource resource)
        {
            ObjectType = ForcedObjType = "WorkflowDefinition";
            Attributes = resource.Attributes;
            if (resource.Creator == null)
                return;
            Creator = resource.Creator;
        }

        readonly string ForcedObjType;

        /// <summary>
        /// Object Type (can only be WorkflowDefinition)
        /// </summary>
        [Required]
        public override sealed string ObjectType
        {
            get { return GetAttrValue("ObjectType"); }
            set
            {
                if (value != ForcedObjType)
                    throw new InvalidOperationException("Object Type of WorkflowDefinition can only be 'WorkflowDefinition'");
                SetAttrValue("ObjectType", value);
            }
        }

        /// <summary>
        /// Clear Registration - Modifying this attribute will clear the associated user registration data of this workflow
        /// </summary>
        public bool? ClearRegistration
        {
            get { return AttrToBool("ClearRegistration"); }
            set { 
                SetAttrValue("ClearRegistration", value.ToString());
            }
        }


        /// <summary>
        /// Request Phase - 
        /// </summary>
        [Required]
        public string RequestPhase
        {
            get { return GetAttrValue("RequestPhase"); }
            set {
                SetAttrValue("RequestPhase", value); 
            }
        }


        /// <summary>
        /// Rules - Rules file for the workflow.
        /// </summary>
        public string Rules
        {
            get { return GetAttrValue("Rules"); }
            set {
                SetAttrValue("Rules", value); 
            }
        }


        /// <summary>
        /// Run On Policy Update - Specifies if the workflow should be applied to existing members of a Transition Set in the Set Transition Policy referencing this workflow when the policy is created, enabled or when selected changes are made to the policy.
        /// </summary>
        public bool? RunOnPolicyUpdate
        {
            get { return AttrToBool("RunOnPolicyUpdate"); }
            set { 
                SetAttrValue("RunOnPolicyUpdate", value.ToString());
            }
        }


        /// <summary>
        /// XOML - 
        /// </summary>
        [Required]
        public string XOML
        {
            get { return GetAttrValue("XOML"); }
            set {
                SetAttrValue("XOML", value); 
            }
        }


    }
}
