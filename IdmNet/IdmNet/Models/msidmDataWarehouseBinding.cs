using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
// ReSharper disable InconsistentNaming

namespace IdmNet.Models
{
    /// <summary>
    /// msidmDataWarehouseBinding - This resource describes a reporting binding object type.  These objects are used to specify a mapping between FIM objects and attributes and their related classes and properties in the FIM reporting database.
    /// </summary>
    public class msidmDataWarehouseBinding : IdmResource
    {
        /// <summary>
        /// Parameterless CTOR
        /// </summary>
        public msidmDataWarehouseBinding()
        {
            ObjectType = ForcedObjType = "msidmDataWarehouseBinding";
        }

        /// <summary>
        /// Build a msidmDataWarehouseBinding object from a IdmResource object
        /// </summary>
        /// <param name="resource">base class</param>
        public msidmDataWarehouseBinding(IdmResource resource)
        {
            ObjectType = ForcedObjType = "msidmDataWarehouseBinding";
            Attributes = resource.Attributes;
            if (resource.Creator == null)
                return;
            Creator = resource.Creator;
        }

        readonly string ForcedObjType;

        /// <summary>
        /// Object Type (can only be msidmDataWarehouseBinding)
        /// </summary>
        [Required]
        public override sealed string ObjectType
        {
            get { return GetAttrValue("ObjectType"); }
            set
            {
                if (value != ForcedObjType)
                    throw new InvalidOperationException("Object Type of msidmDataWarehouseBinding can only be 'msidmDataWarehouseBinding'");
                SetAttrValue("ObjectType", value);
            }
        }

        /// <summary>
        /// Data Warehouse Binding Identity - This attribute defines the name of a reporting binding object.
        /// </summary>
        [Required]
        public string msidmDataWarehouseBindingIdentity
        {
            get { return GetAttrValue("msidmDataWarehouseBindingIdentity"); }
            set {
                SetAttrValue("msidmDataWarehouseBindingIdentity", value); 
            }
        }


        /// <summary>
        /// Data Warehouse Mapping - This attribute defines a mapping between FIM objects and attributes and their related classes and properties in the FIM reporting database.
        /// </summary>
        [Required]
        public string msidmDataWarehouseMapping
        {
            get { return GetAttrValue("msidmDataWarehouseMapping"); }
            set {
                SetAttrValue("msidmDataWarehouseMapping", value); 
            }
        }


    }
}
