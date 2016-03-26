# ma_data Properties
 

The <a href="T_IdmNet_Models_ma_data">ma_data</a> type exposes the following members.


## Properties
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_IdmResource_Attributes">Attributes</a></td><td>
List of attributes for which we have data for this particular object. Note that due to performance reasons, there may be other attributes and values in the identity manager service, but they may not have been retrieved yet.
 (Inherited from <a href="T_IdmNet_Models_IdmResource">IdmResource</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_IdmResource_CreatedTime">CreatedTime</a></td><td>
(aka Created Time) The time when the resource is created in the FIM service database. This attribute is assigned its value by the FIM service. It cannot be modified by any user.
 (Inherited from <a href="T_IdmNet_Models_IdmResource">IdmResource</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_IdmResource_Creator">Creator</a></td><td>
This is a reference attribute that refers to the resource that directly created the resource in the FIM service database. This attribute is assigned its value by the FIM service. It cannot be modified by any user.
 (Inherited from <a href="T_IdmNet_Models_IdmResource">IdmResource</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_IdmResource_DeletedTime">DeletedTime</a></td><td>
(aka Deleted Time) The time when the current resource is deleted from the FIM service database. This attribute is assigned its value by the FIM service. It cannot be modified by any user.
 (Inherited from <a href="T_IdmNet_Models_IdmResource">IdmResource</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_IdmResource_Description">Description</a></td><td>
Resource Description
 (Inherited from <a href="T_IdmNet_Models_IdmResource">IdmResource</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_IdmResource_DetectedRulesList">DetectedRulesList</a></td><td>
(aka Detected Rules List) The synchronization rules detected for resources in external systems.
 (Inherited from <a href="T_IdmNet_Models_IdmResource">IdmResource</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_IdmResource_DisplayName">DisplayName</a></td><td>
(aka Display Name) Display name for the resource.
 (Inherited from <a href="T_IdmNet_Models_IdmResource">IdmResource</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_IdmResource_ExpectedRulesList">ExpectedRulesList</a></td><td>
(aka Expected Rules List) This resource has been added to these Synchronization Rules and will be manifested in external systems according to the Synchronization Rule definitions.
 (Inherited from <a href="T_IdmNet_Models_IdmResource">IdmResource</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_IdmResource_ExpirationTime">ExpirationTime</a></td><td>
(aka Expiration Time) The date and time when the resource expires. The appropriate Management Policy Rule will delete the resource when the current date and time is later than the date and time specified in this attribute.
 (Inherited from <a href="T_IdmNet_Models_IdmResource">IdmResource</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_IdmResource_Item">Item</a></td><td>
Resource Indexer - get's the attribute of the resource object as indexed by name.
 (Inherited from <a href="T_IdmNet_Models_IdmResource">IdmResource</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_IdmResource_Locale">Locale</a></td><td>
The region and language for which the representation of a resource has been adapted.
 (Inherited from <a href="T_IdmNet_Models_IdmResource">IdmResource</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_IdmResource_MVObjectID">MVObjectID</a></td><td>
(aka MV Resource ID) The GUID of an entry in the FIM metaverse corresponding to this resource.
 (Inherited from <a href="T_IdmNet_Models_IdmResource">IdmResource</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_IdmResource_ObjectID">ObjectID</a></td><td>
(aka Resource ID) The value of the attribute is a globally unique identifier (GUID) assigned by FIM to each resource when it is created. Note that it is not required here since this class also represents resources that may not have been created as well as existing resources.
 (Inherited from <a href="T_IdmNet_Models_IdmResource">IdmResource</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_ma_data_ObjectType">ObjectType</a></td><td>
Object Type (can only be ma-data)
 (Overrides <a href="P_IdmNet_Models_IdmResource_ObjectType">IdmResource.ObjectType</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_IdmResource_ResourceTime">ResourceTime</a></td><td>
(aka Resource Time) The date and time of a representation of a resource. This attribute is updated by the FIM service. This attribute can be used to define time triggered Management Policy Rules.
 (Inherited from <a href="T_IdmNet_Models_IdmResource">IdmResource</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_ma_data_SyncConfig_attribute_inclusion">SyncConfig_attribute_inclusion</a></td><td>
SyncConfig-attribute-inclusion - Sync Configuration resource attribute</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_ma_data_SyncConfig_capabilities_mask">SyncConfig_capabilities_mask</a></td><td>
SyncConfig-capabilities-mask - Sync Configuration resource attribute</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_ma_data_SyncConfig_category">SyncConfig_category</a></td><td>
SyncConfig-category - Sync Configuration resource attribute</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_ma_data_SyncConfig_component_mappings">SyncConfig_component_mappings</a></td><td>
SyncConfig-component_mappings - Sync Configuration resource attribute</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_ma_data_SyncConfig_controller_configuration">SyncConfig_controller_configuration</a></td><td>
SyncConfig-controller-configuration - Sync Configuration resource attribute</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_ma_data_SyncConfig_creation_time">SyncConfig_creation_time</a></td><td>
SyncConfig-creation-time - Sync Configuration resource attribute</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_ma_data_SyncConfig_dn_construction">SyncConfig_dn_construction</a></td><td>
SyncConfig-dn-construction - Sync Configuration resource attribute</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_ma_data_SyncConfig_encrypted_attributes">SyncConfig_encrypted_attributes</a></td><td>
SyncConfig-encrypted-attributes - Sync Configuration resource attribute</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_ma_data_SyncConfig_export_attribute_flow">SyncConfig_export_attribute_flow</a></td><td>
SyncConfig-export-attribute-flow - Sync Configuration resource attribute</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_ma_data_SyncConfig_export_type">SyncConfig_export_type</a></td><td>
SyncConfig-export-type - Sync Configuration resource attribute</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_ma_data_SyncConfig_extension">SyncConfig_extension</a></td><td>
SyncConfig-extension - Sync Configuration resource attribute</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_ma_data_SyncConfig_format_version">SyncConfig_format_version</a></td><td>
SyncConfig-format-version - Sync Configuration resource attribute</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_ma_data_SyncConfig_id">SyncConfig_id</a></td><td>
SyncConfig-id - Sync Configuration resource attribute</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_ma_data_SyncConfig_internal_version">SyncConfig_internal_version</a></td><td>
SyncConfig-internal-version - Sync Configuration resource attribute</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_ma_data_SyncConfig_join">SyncConfig_join</a></td><td>
SyncConfig-join - Sync Configuration resource attribute</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_ma_data_SyncConfig_last_modification_time">SyncConfig_last_modification_time</a></td><td>
SyncConfig-last-modification-time - Sync Configuration resource attribute</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_ma_data_SyncConfig_ma_companyname">SyncConfig_ma_companyname</a></td><td>
SyncConfig-ma-companyname - Sync Configuration resource attribute</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_ma_data_SyncConfig_ma_listname">SyncConfig_ma_listname</a></td><td>
SyncConfig-ma-listname - Sync Configuration resource attribute</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_ma_data_SyncConfig_ma_partition_data">SyncConfig_ma_partition_data</a></td><td>
SyncConfig-ma-partition-data - Sync Configuration resource attribute</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_ma_data_SyncConfig_ma_run_data">SyncConfig_ma_run_data</a></td><td>
SyncConfig-ma-run-data - Sync Configuration resource attribute</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_ma_data_SyncConfig_ma_ui_settings">SyncConfig_ma_ui_settings</a></td><td>
SyncConfig-ma-ui-settings - Sync Configuration resource attribute</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_ma_data_SyncConfig_password_sync">SyncConfig_password_sync</a></td><td>
SyncConfig-password-sync - Sync Configuration resource attribute</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_ma_data_SyncConfig_password_sync_allowed">SyncConfig_password_sync_allowed</a></td><td>
SyncConfig-password-sync-allowed - Sync Configuration resource attribute</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_ma_data_SyncConfig_private_configuration">SyncConfig_private_configuration</a></td><td>
SyncConfig-private-configuration - Sync Configuration resource attribute</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_ma_data_SyncConfig_projection">SyncConfig_projection</a></td><td>
SyncConfig-projection - Sync Configuration resource attribute</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_ma_data_SyncConfig_provisioning_cleanup">SyncConfig_provisioning_cleanup</a></td><td>
SyncConfig-provisioning-cleanup - Sync Configuration resource attribute</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_ma_data_SyncConfig_provisioning_cleanup_type">SyncConfig_provisioning_cleanup_type</a></td><td>
SyncConfig-provisioning-cleanup-type - Sync Configuration resource attribute</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_ma_data_SyncConfig_refresh_schema">SyncConfig_refresh_schema</a></td><td>
SyncConfig-refresh-schema - Refresh Schema</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_ma_data_SyncConfig_schema">SyncConfig_schema</a></td><td>
SyncConfig-schema - Sync Configuration resource attribute</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_ma_data_SyncConfig_stay_disconnector">SyncConfig_stay_disconnector</a></td><td>
SyncConfig-stay-disconnector - Sync Configuration resource attribute</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_ma_data_SyncConfig_sub_type">SyncConfig_sub_type</a></td><td>
SyncConfig-sub-type - Sync Configuration resource attribute</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_ma_data_SyncConfig_version">SyncConfig_version</a></td><td>
SyncConfig-version - Sync Configuration resource attribute</td></tr></table>&nbsp;
<a href="#ma_data-properties">Back to Top</a>

## See Also


#### Reference
<a href="T_IdmNet_Models_ma_data">ma_data Class</a><br /><a href="N_IdmNet_Models">IdmNet.Models Namespace</a><br />