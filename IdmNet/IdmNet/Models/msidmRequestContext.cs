using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
// ReSharper disable InconsistentNaming

namespace IdmNet.Models
{
    /// <summary>
    /// msidmRequestContext - This includes additional request context.
    /// </summary>
    public class msidmRequestContext : IdmResource
    {
        /// <summary>
        /// Parameterless CTOR
        /// </summary>
        public msidmRequestContext()
        {
            ObjectType = ForcedObjType = "msidmRequestContext";
        }

        /// <summary>
        /// Build a msidmRequestContext object from a IdmResource object
        /// </summary>
        /// <param name="resource">base class</param>
        public msidmRequestContext(IdmResource resource)
        {
            Attributes = resource.Attributes;
            ObjectType = ForcedObjType = "msidmRequestContext";
            if (resource.Creator == null)
                return;
            Creator = resource.Creator;
        }

        readonly string ForcedObjType;

        /// <summary>
        /// Object Type (can only be msidmRequestContext)
        /// </summary>
        [Required]
        public override sealed string ObjectType
        {
            get { return GetAttrValue("ObjectType"); }
            set
            {
                if (value != ForcedObjType)
                    throw new InvalidOperationException("Object Type of msidmRequestContext can only be 'msidmRequestContext'");
                SetAttrValue("ObjectType", value);
            }
        }

        /// <summary>
        /// Security Context - This is the security context for the request.
        /// </summary>
        [Required]
        public string msidmSecurityContext
        {
            get { return GetAttrValue("msidmSecurityContext"); }
            set {
                SetAttrValue("msidmSecurityContext", value); 
            }
        }


    }
}
