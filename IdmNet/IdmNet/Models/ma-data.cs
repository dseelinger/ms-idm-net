using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
// ReSharper disable InconsistentNaming

namespace IdmNet.Models
{
    /// <summary>
    /// ma-data - 
    /// </summary>
    public class ma_data : IdmResource
    {
        /// <summary>
        /// Parameterless CTOR
        /// </summary>
        public ma_data()
        {
            ObjectType = ForcedObjType = "ma-data";
        }

        /// <summary>
        /// Build a ma_data object from a IdmResource object
        /// </summary>
        /// <param name="resource">base class</param>
        public ma_data(IdmResource resource)
        {
            ObjectType = ForcedObjType = "ma-data";
            Attributes = resource.Attributes;
            if (resource.Creator == null)
                return;
            Creator = resource.Creator;
        }

        readonly string ForcedObjType;

        /// <summary>
        /// Object Type (can only be ma-data)
        /// </summary>
        [Required]
        public override sealed string ObjectType
        {
            get { return GetAttrValue("ObjectType"); }
            set
            {
                if (value != ForcedObjType)
                    throw new InvalidOperationException("Object Type of ma_data can only be 'ma-data'");
                SetAttrValue("ObjectType", value);
            }
        }

        /// <summary>
        /// SyncConfig-attribute-inclusion - Sync Configuration resource attribute
        /// </summary>
        public string SyncConfig_attribute_inclusion
        {
            get { return GetAttrValue("SyncConfig-attribute-inclusion"); }
            set {
                SetAttrValue("SyncConfig-attribute-inclusion", value); 
            }
        }


        /// <summary>
        /// SyncConfig-capabilities-mask - Sync Configuration resource attribute
        /// </summary>
        public int? SyncConfig_capabilities_mask
        {
            get { return AttrToInteger("SyncConfig-capabilities-mask"); }
            set { 
                SetAttrValue("SyncConfig-capabilities-mask", value.ToString());
            }
        }


        /// <summary>
        /// SyncConfig-category - Sync Configuration resource attribute
        /// </summary>
        public string SyncConfig_category
        {
            get { return GetAttrValue("SyncConfig-category"); }
            set {
                SetAttrValue("SyncConfig-category", value); 
            }
        }


        /// <summary>
        /// SyncConfig-component_mappings - Sync Configuration resource attribute
        /// </summary>
        public string SyncConfig_component_mappings
        {
            get { return GetAttrValue("SyncConfig-component_mappings"); }
            set {
                SetAttrValue("SyncConfig-component_mappings", value); 
            }
        }


        /// <summary>
        /// SyncConfig-controller-configuration - Sync Configuration resource attribute
        /// </summary>
        public string SyncConfig_controller_configuration
        {
            get { return GetAttrValue("SyncConfig-controller-configuration"); }
            set {
                SetAttrValue("SyncConfig-controller-configuration", value); 
            }
        }


        /// <summary>
        /// SyncConfig-creation-time - Sync Configuration resource attribute
        /// </summary>
        public string SyncConfig_creation_time
        {
            get { return GetAttrValue("SyncConfig-creation-time"); }
            set {
                SetAttrValue("SyncConfig-creation-time", value); 
            }
        }


        /// <summary>
        /// SyncConfig-dn-construction - Sync Configuration resource attribute
        /// </summary>
        public string SyncConfig_dn_construction
        {
            get { return GetAttrValue("SyncConfig-dn-construction"); }
            set {
                SetAttrValue("SyncConfig-dn-construction", value); 
            }
        }


        /// <summary>
        /// SyncConfig-encrypted-attributes - Sync Configuration resource attribute
        /// </summary>
        public string SyncConfig_encrypted_attributes
        {
            get { return GetAttrValue("SyncConfig-encrypted-attributes"); }
            set {
                SetAttrValue("SyncConfig-encrypted-attributes", value); 
            }
        }


        /// <summary>
        /// SyncConfig-export-attribute-flow - Sync Configuration resource attribute
        /// </summary>
        public string SyncConfig_export_attribute_flow
        {
            get { return GetAttrValue("SyncConfig-export-attribute-flow"); }
            set {
                SetAttrValue("SyncConfig-export-attribute-flow", value); 
            }
        }


        /// <summary>
        /// SyncConfig-export-type - Sync Configuration resource attribute
        /// </summary>
        public int? SyncConfig_export_type
        {
            get { return AttrToInteger("SyncConfig-export-type"); }
            set { 
                SetAttrValue("SyncConfig-export-type", value.ToString());
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
            get { return AttrToInteger("SyncConfig-format-version"); }
            set { 
                SetAttrValue("SyncConfig-format-version", value.ToString());
            }
        }


        /// <summary>
        /// SyncConfig-id - Sync Configuration resource attribute
        /// </summary>
        [Required]
        public string SyncConfig_id
        {
            get { return GetAttrValue("SyncConfig-id"); }
            set {
                SetAttrValue("SyncConfig-id", value); 
            }
        }


        /// <summary>
        /// SyncConfig-internal-version - Sync Configuration resource attribute
        /// </summary>
        public int? SyncConfig_internal_version
        {
            get { return AttrToInteger("SyncConfig-internal-version"); }
            set { 
                SetAttrValue("SyncConfig-internal-version", value.ToString());
            }
        }


        /// <summary>
        /// SyncConfig-join - Sync Configuration resource attribute
        /// </summary>
        public string SyncConfig_join
        {
            get { return GetAttrValue("SyncConfig-join"); }
            set {
                SetAttrValue("SyncConfig-join", value); 
            }
        }


        /// <summary>
        /// SyncConfig-last-modification-time - Sync Configuration resource attribute
        /// </summary>
        public string SyncConfig_last_modification_time
        {
            get { return GetAttrValue("SyncConfig-last-modification-time"); }
            set {
                SetAttrValue("SyncConfig-last-modification-time", value); 
            }
        }


        /// <summary>
        /// SyncConfig-ma-companyname - Sync Configuration resource attribute
        /// </summary>
        public string SyncConfig_ma_companyname
        {
            get { return GetAttrValue("SyncConfig-ma-companyname"); }
            set {
                SetAttrValue("SyncConfig-ma-companyname", value); 
            }
        }


        /// <summary>
        /// SyncConfig-ma-listname - Sync Configuration resource attribute
        /// </summary>
        public string SyncConfig_ma_listname
        {
            get { return GetAttrValue("SyncConfig-ma-listname"); }
            set {
                SetAttrValue("SyncConfig-ma-listname", value); 
            }
        }


        /// <summary>
        /// SyncConfig-ma-partition-data - Sync Configuration resource attribute
        /// </summary>
        public List<string> SyncConfig_ma_partition_data
        {
            get { return GetAttrValues("SyncConfig-ma-partition-data"); }
            set {
                SetAttrValues("SyncConfig-ma-partition-data", value); 
            }
        }


        /// <summary>
        /// SyncConfig-ma-run-data - Sync Configuration resource attribute
        /// </summary>
        public List<string> SyncConfig_ma_run_data
        {
            get { return GetAttrValues("SyncConfig-ma-run-data"); }
            set {
                SetAttrValues("SyncConfig-ma-run-data", value); 
            }
        }


        /// <summary>
        /// SyncConfig-ma-ui-settings - Sync Configuration resource attribute
        /// </summary>
        public string SyncConfig_ma_ui_settings
        {
            get { return GetAttrValue("SyncConfig-ma-ui-settings"); }
            set {
                SetAttrValue("SyncConfig-ma-ui-settings", value); 
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
        /// SyncConfig-password-sync-allowed - Sync Configuration resource attribute
        /// </summary>
        public int? SyncConfig_password_sync_allowed
        {
            get { return AttrToInteger("SyncConfig-password-sync-allowed"); }
            set { 
                SetAttrValue("SyncConfig-password-sync-allowed", value.ToString());
            }
        }


        /// <summary>
        /// SyncConfig-private-configuration - Sync Configuration resource attribute
        /// </summary>
        public string SyncConfig_private_configuration
        {
            get { return GetAttrValue("SyncConfig-private-configuration"); }
            set {
                SetAttrValue("SyncConfig-private-configuration", value); 
            }
        }


        /// <summary>
        /// SyncConfig-projection - Sync Configuration resource attribute
        /// </summary>
        public string SyncConfig_projection
        {
            get { return GetAttrValue("SyncConfig-projection"); }
            set {
                SetAttrValue("SyncConfig-projection", value); 
            }
        }


        /// <summary>
        /// SyncConfig-provisioning-cleanup - Sync Configuration resource attribute
        /// </summary>
        public string SyncConfig_provisioning_cleanup
        {
            get { return GetAttrValue("SyncConfig-provisioning-cleanup"); }
            set {
                SetAttrValue("SyncConfig-provisioning-cleanup", value); 
            }
        }


        /// <summary>
        /// SyncConfig-provisioning-cleanup-type - Sync Configuration resource attribute
        /// </summary>
        public string SyncConfig_provisioning_cleanup_type
        {
            get { return GetAttrValue("SyncConfig-provisioning-cleanup-type"); }
            set {
                SetAttrValue("SyncConfig-provisioning-cleanup-type", value); 
            }
        }


        /// <summary>
        /// SyncConfig-refresh-schema - Refresh Schema
        /// </summary>
        public int? SyncConfig_refresh_schema
        {
            get { return AttrToInteger("SyncConfig-refresh-schema"); }
            set { 
                SetAttrValue("SyncConfig-refresh-schema", value.ToString());
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
        /// SyncConfig-stay-disconnector - Sync Configuration resource attribute
        /// </summary>
        public string SyncConfig_stay_disconnector
        {
            get { return GetAttrValue("SyncConfig-stay-disconnector"); }
            set {
                SetAttrValue("SyncConfig-stay-disconnector", value); 
            }
        }


        /// <summary>
        /// SyncConfig-sub-type - Sync Configuration resource attribute
        /// </summary>
        public string SyncConfig_sub_type
        {
            get { return GetAttrValue("SyncConfig-sub-type"); }
            set {
                SetAttrValue("SyncConfig-sub-type", value); 
            }
        }


        /// <summary>
        /// SyncConfig-version - Sync Configuration resource attribute
        /// </summary>
        public int? SyncConfig_version
        {
            get { return AttrToInteger("SyncConfig-version"); }
            set { 
                SetAttrValue("SyncConfig-version", value.ToString());
            }
        }


    }
}
