using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
// ReSharper disable InconsistentNaming

namespace IdmNet.Models
{
    /// <summary>
    /// ManagementPolicyRule - 
    /// </summary>
    public class ManagementPolicyRule : IdmResource
    {
        /// <summary>
        /// Parameterless CTOR
        /// </summary>
        public ManagementPolicyRule()
        {
            ObjectType = ForcedObjType = "ManagementPolicyRule";
        }

        /// <summary>
        /// Build a ManagementPolicyRule object from a IdmResource object
        /// </summary>
        /// <param name="resource">base class</param>
        public ManagementPolicyRule(IdmResource resource)
        {
            Attributes = resource.Attributes;
            ObjectType = ForcedObjType = "ManagementPolicyRule";
            if (resource.Creator == null)
                return;
            Creator = resource.Creator;
        }

        readonly string ForcedObjType;

        /// <summary>
        /// Object Type (can only be ManagementPolicyRule)
        /// </summary>
        [Required]
        public override sealed string ObjectType
        {
            get { return GetAttrValue("ObjectType"); }
            set
            {
                if (value != ForcedObjType)
                    throw new InvalidOperationException("Object Type of ManagementPolicyRule can only be 'ManagementPolicyRule'");
                SetAttrValue("ObjectType", value);
            }
        }

        /// <summary>
        /// Action Parameter - The attribute names the policy works for (used for READ/UPDATE action)
        /// </summary>
        public List<string> ActionParameter
        {
            get { return GetAttrValues("ActionParameter"); }
            set {
                SetAttrValues("ActionParameter", value); 
            }
        }


        /// <summary>
        /// Action Type - String representing the action associated with the management policy rule (Create, Delete, Read, Add, Remove, Modify, Transition In, Transition Out)
        /// </summary>
        [Required]
        public List<string> ActionType
        {
            get { return GetAttrValues("ActionType"); }
            set {
                SetAttrValues("ActionType", value); 
            }
        }


        /// <summary>
        /// Action Workflows - These workflows are applied as part of the policy. Read operations do not trigger workflows.
        /// </summary>
        public List<WorkflowInstance> ActionWorkflowDefinition
        {
            get { return GetMultiValuedAttr("ActionWorkflowDefinition", _theActionWorkflowDefinition); }
            set { SetMultiValuedAttr("ActionWorkflowDefinition", out _theActionWorkflowDefinition, value); }
        }
        private List<WorkflowInstance> _theActionWorkflowDefinition;


        /// <summary>
        /// Authentication Workflows - These workflows will not be applied to Requests created by the Built-in Synchronization Account or Forefront Identity Manager Workflow Activities. Read operations do not trigger workflows.
        /// </summary>
        public List<WorkflowDefinition> AuthenticationWorkflowDefinition
        {
            get { return GetMultiValuedAttr("AuthenticationWorkflowDefinition", _theAuthenticationWorkflowDefinition); }
            set { SetMultiValuedAttr("AuthenticationWorkflowDefinition", out _theAuthenticationWorkflowDefinition, value); }
        }
        private List<WorkflowDefinition> _theAuthenticationWorkflowDefinition;


        /// <summary>
        /// Authorization Workflows - These workflows will not be applied to Requests created by the Built-in Synchronization Account or Forefront Identity Manager Workflow Activities. Read operations do not trigger workflows.
        /// </summary>
        public List<WorkflowDefinition> AuthorizationWorkflowDefinition
        {
            get { return GetMultiValuedAttr("AuthorizationWorkflowDefinition", _theAuthorizationWorkflowDefinition); }
            set { SetMultiValuedAttr("AuthorizationWorkflowDefinition", out _theAuthorizationWorkflowDefinition, value); }
        }
        private List<WorkflowDefinition> _theAuthorizationWorkflowDefinition;


        /// <summary>
        /// Disabled - Determines if resource is disabled or enabled
        /// </summary>
        [Required]
        public bool Disabled
        {
            get { return AttrToBool("Disabled"); }
            set { 
                SetAttrValue("Disabled", value.ToString());
            }
        }


        /// <summary>
        /// Grant Right - 
        /// </summary>
        [Required]
        public bool GrantRight
        {
            get { return AttrToBool("GrantRight"); }
            set { 
                SetAttrValue("GrantRight", value.ToString());
            }
        }


        /// <summary>
        /// Management Policy Rule Type - Indicates the type of this policy rule.
        /// </summary>
        [Required]
        public string ManagementPolicyRuleType
        {
            get { return GetAttrValue("ManagementPolicyRuleType"); }
            set {
                SetAttrValue("ManagementPolicyRuleType", value); 
            }
        }


        /// <summary>
        /// Principal Set - Reference to the set the principal resource should belongs to.
        /// </summary>
        public Set PrincipalSet
        {
            get { return GetAttr("PrincipalSet", _thePrincipalSet); }
            set 
            { 
                _thePrincipalSet = value;
                SetAttrValue("PrincipalSet", ObjectIdOrNull(value)); 
            }
        }
        private Set _thePrincipalSet;


        /// <summary>
        /// Principal Set Relative To Resource - 
        /// </summary>
        public string PrincipalRelativeToResource
        {
            get { return GetAttrValue("PrincipalRelativeToResource"); }
            set {
                SetAttrValue("PrincipalRelativeToResource", value); 
            }
        }


        /// <summary>
        /// Resource Current Set - 
        /// </summary>
        public Set ResourceCurrentSet
        {
            get { return GetAttr("ResourceCurrentSet", _theResourceCurrentSet); }
            set 
            { 
                _theResourceCurrentSet = value;
                SetAttrValue("ResourceCurrentSet", ObjectIdOrNull(value)); 
            }
        }
        private Set _theResourceCurrentSet;


        /// <summary>
        /// Resource Final Set - 
        /// </summary>
        public Set ResourceFinalSet
        {
            get { return GetAttr("ResourceFinalSet", _theResourceFinalSet); }
            set 
            { 
                _theResourceFinalSet = value;
                SetAttrValue("ResourceFinalSet", ObjectIdOrNull(value)); 
            }
        }
        private Set _theResourceFinalSet;


    }
}
