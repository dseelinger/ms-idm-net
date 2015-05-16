using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
// ReSharper disable InconsistentNaming

namespace IdmNet.Models
{
    /// <summary>
    /// msidmCompositeType - 
    /// </summary>
    public class msidmCompositeType : IdmResource
    {
        /// <summary>
        /// Parameterless CTOR
        /// </summary>
        public msidmCompositeType()
        {
            ObjectType = ForcedObjType = "msidmCompositeType";
        }

        /// <summary>
        /// Build a msidmCompositeType object from a IdmResource object
        /// </summary>
        /// <param name="resource">base class</param>
        public msidmCompositeType(IdmResource resource)
        {
            Attributes = resource.Attributes;
            ObjectType = ForcedObjType = "msidmCompositeType";
            if (resource.Creator == null)
                return;
            Creator = resource.Creator;
        }

        readonly string ForcedObjType;

        /// <summary>
        /// Object Type (can only be msidmCompositeType)
        /// </summary>
        [Required]
        public override sealed string ObjectType
        {
            get { return GetAttrValue("ObjectType"); }
            set
            {
                if (value != ForcedObjType)
                    throw new InvalidOperationException("Object Type of msidmCompositeType can only be 'msidmCompositeType'");
                SetAttrValue("ObjectType", value);
            }
        }

        /// <summary>
        /// Element - 
        /// </summary>
        public List<IdmResource> msidmElement
        {
            get { return GetMultiValuedAttr("msidmElement", _themsidmElement); }
            set { SetMultiValuedAttr("msidmElement", out _themsidmElement, value); }
        }
        private List<IdmResource> _themsidmElement;


    }
}
