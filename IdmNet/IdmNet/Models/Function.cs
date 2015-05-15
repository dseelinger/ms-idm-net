using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
// ReSharper disable InconsistentNaming

namespace IdmNet.Models
{
    /// <summary>
    /// Function - This is a descriptor of a function used during transformations.
    /// </summary>
    public class Function : IdmResource
    {
        /// <summary>
        /// Parameterless CTOR
        /// </summary>
        public Function()
        {
            ObjectType = ForcedObjType = "Function";
        }

        /// <summary>
        /// Build a Function object from a IdmResource object
        /// </summary>
        /// <param name="resource">base class</param>
        public Function(IdmResource resource)
        {
            ObjectType = ForcedObjType = "Function";
            Attributes = resource.Attributes;
            if (resource.Creator == null)
                return;
            Creator = resource.Creator;
        }

        readonly string ForcedObjType;

        /// <summary>
        /// Object Type (can only be Function)
        /// </summary>
        [Required]
        public override sealed string ObjectType
        {
            get { return GetAttrValue("ObjectType"); }
            set
            {
                if (value != ForcedObjType)
                    throw new InvalidOperationException("Object Type of Function can only be 'Function'");
                SetAttrValue("ObjectType", value);
            }
        }

        /// <summary>
        /// Assembly - The library in which to find functions.
        /// </summary>
        [Required]
        public string Assembly
        {
            get { return GetAttrValue("Assembly"); }
            set {
                SetAttrValue("Assembly", value); 
            }
        }


        /// <summary>
        /// Function Name - The name of the function.
        /// </summary>
        [Required]
        public string FunctionName
        {
            get { return GetAttrValue("FunctionName"); }
            set {
                SetAttrValue("FunctionName", value); 
            }
        }


        /// <summary>
        /// Namespace - The namespace where the function resides.
        /// </summary>
        [Required]
        public string Namespace
        {
            get { return GetAttrValue("Namespace"); }
            set {
                SetAttrValue("Namespace", value); 
            }
        }


        /// <summary>
        /// Parameters List - Contains the list of parameters a function takes as input.
        /// </summary>
        [Required]
        public string FunctionParameters
        {
            get { return GetAttrValue("FunctionParameters"); }
            set {
                SetAttrValue("FunctionParameters", value); 
            }
        }


        /// <summary>
        /// Return Type - The type of the value returned by a function.
        /// </summary>
        [Required]
        public string ReturnType
        {
            get { return GetAttrValue("ReturnType"); }
            set {
                SetAttrValue("ReturnType", value); 
            }
        }


    }
}
