using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
// ReSharper disable InconsistentNaming

namespace IdmNet.Models
{
    /// <summary>
    /// GateRegistration - This is a private resource type to keep track of password gate registration information.
    /// </summary>
    public class GateRegistration : IdmResource
    {
        /// <summary>
        /// Parameterless CTOR
        /// </summary>
        public GateRegistration()
        {
            ObjectType = ForcedObjType = "GateRegistration";
        }

        /// <summary>
        /// Build a GateRegistration object from a IdmResource object
        /// </summary>
        /// <param name="resource">base class</param>
        public GateRegistration(IdmResource resource)
        {
            ObjectType = ForcedObjType = "GateRegistration";
            Attributes = resource.Attributes;
            if (resource.Creator == null)
                return;
            Creator = resource.Creator;
        }

        readonly string ForcedObjType;

        /// <summary>
        /// Object Type (can only be GateRegistration)
        /// </summary>
        [Required]
        public override sealed string ObjectType
        {
            get { return GetAttrValue("ObjectType"); }
            set
            {
                if (value != ForcedObjType)
                    throw new InvalidOperationException("Object Type of GateRegistration can only be 'GateRegistration'");
                SetAttrValue("ObjectType", value);
            }
        }

        /// <summary>
        /// Gate Data - 
        /// </summary>
        [Required]
        public byte[] GateData
        {
            get { return GetAttr("GateData") == null ? null : GetAttr("GateData").ToBinary(); }
            set { SetAttrValue("GateData", Convert.ToBase64String(value)); }
        }


        /// <summary>
        /// Gate ID - 
        /// </summary>
        [Required]
        public string GateID
        {
            get { return GetAttrValue("GateID"); }
            set {
                SetAttrValue("GateID", value); 
            }
        }


        /// <summary>
        /// Gate Type - 
        /// </summary>
        public string GateTypeId
        {
            get { return GetAttrValue("GateTypeId"); }
            set {
                SetAttrValue("GateTypeId", value); 
            }
        }


        /// <summary>
        /// User ID - 
        /// </summary>
        public Person UserID
        {
            get { return GetAttr("UserID", _theUserID); }
            set 
            { 
                _theUserID = value;
                SetAttrValue("UserID", ObjectIdOrNull(value)); 
            }
        }
        private Person _theUserID;


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


    }
}
