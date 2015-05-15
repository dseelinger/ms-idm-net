using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
// ReSharper disable InconsistentNaming

namespace IdmNet.Models
{
    /// <summary>
    /// mv-data - 
    /// </summary>
    public class mv_data : IdmResource
    {
        /// <summary>
        /// Parameterless CTOR
        /// </summary>
        public mv_data()
        {
            ObjectType = ForcedObjType = "mv-data";
        }

        /// <summary>
        /// Build a mv_data object from a IdmResource object
        /// </summary>
        /// <param name="resource">base class</param>
        public mv_data(IdmResource resource)
        {
            ObjectType = ForcedObjType = "mv-data";
            Attributes = resource.Attributes;
            if (resource.Creator == null)
                return;
            Creator = resource.Creator;
        }

        readonly string ForcedObjType;

        /// <summary>
        /// Object Type (can only be mv-data)
        /// </summary>
        [Required]
        public override sealed string ObjectType
        {
            get { return GetAttrValue("ObjectType"); }
            set
            {
                if (value != ForcedObjType)
                    throw new InvalidOperationException("Object Type of mv_data can only be 'mv-data'");
                SetAttrValue("ObjectType", value);
            }
        }

        /// <summary>
        /// SyncConfig-extension - Sync Configuration resource attribute
        /// </summary>
        public string SyncConfig_extension
        {
            get { return GetAttrValue("SyncConfig-extension"); }
            set {
                SetAttrValue("SyncConfig-extension", value); 
            }
        }


        /// <summary>
        /// SyncConfig-format-version - Sync Configuration resource attribute
        /// </summary>
        public int? SyncConfig_format_version
        {
            get { return AttrToNullableInteger("SyncConfig-format-version"); }
            set { 
                SetAttrValue("SyncConfig-format-version", value.ToString());
            }
        }


        /// <summary>
        /// SyncConfig-import-attribute-flow - Sync Configuration resource attribute
        /// </summary>
        public string SyncConfig_import_attribute_flow
        {
            get { return GetAttrValue("SyncConfig-import-attribute-flow"); }
            set {
                SetAttrValue("SyncConfig-import-attribute-flow", value); 
            }
        }


        /// <summary>
        /// SyncConfig-mv-deletion - Sync Configuration resource attribute
        /// </summary>
        public string SyncConfig_mv_deletion
        {
            get { return GetAttrValue("SyncConfig-mv-deletion"); }
            set {
                SetAttrValue("SyncConfig-mv-deletion", value); 
            }
        }


        /// <summary>
        /// SyncConfig-password-change-history-size - ObjectTypes that are synced
        /// </summary>
        public int? SyncConfig_password_change_history_size
        {
            get { return AttrToNullableInteger("SyncConfig-password-change-history-size"); }
            set { 
                SetAttrValue("SyncConfig-password-change-history-size", value.ToString());
            }
        }


        /// <summary>
        /// SyncConfig-password-sync - Sync Configuration resource attribute
        /// </summary>
        public string SyncConfig_password_sync
        {
            get { return GetAttrValue("SyncConfig-password-sync"); }
            set {
                SetAttrValue("SyncConfig-password-sync", value); 
            }
        }


        /// <summary>
        /// SyncConfig-provisioning - Sync Configuration resource attribute
        /// </summary>
        public string SyncConfig_provisioning
        {
            get { return GetAttrValue("SyncConfig-provisioning"); }
            set {
                SetAttrValue("SyncConfig-provisioning", value); 
            }
        }


        /// <summary>
        /// SyncConfig-provisioning-type - Sync Configuration resource attribute
        /// </summary>
        public string SyncConfig_provisioning_type
        {
            get { return GetAttrValue("SyncConfig-provisioning-type"); }
            set {
                SetAttrValue("SyncConfig-provisioning-type", value); 
            }
        }


        /// <summary>
        /// SyncConfig-schema - Sync Configuration resource attribute
        /// </summary>
        public string SyncConfig_schema
        {
            get { return GetAttrValue("SyncConfig-schema"); }
            set {
                SetAttrValue("SyncConfig-schema", value); 
            }
        }


        /// <summary>
        /// SyncConfig-version - Sync Configuration resource attribute
        /// </summary>
        public int? SyncConfig_version
        {
            get { return AttrToNullableInteger("SyncConfig-version"); }
            set { 
                SetAttrValue("SyncConfig-version", value.ToString());
            }
        }


    }
}
