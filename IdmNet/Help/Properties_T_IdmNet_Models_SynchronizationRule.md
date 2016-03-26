# SynchronizationRule Properties
 

The <a href="T_IdmNet_Models_SynchronizationRule">SynchronizationRule</a> type exposes the following members.


## Properties
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_IdmResource_Attributes">Attributes</a></td><td>
List of attributes for which we have data for this particular object. Note that due to performance reasons, there may be other attributes and values in the identity manager service, but they may not have been retrieved yet.
 (Inherited from <a href="T_IdmNet_Models_IdmResource">IdmResource</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_SynchronizationRule_ConnectedObjectType">ConnectedObjectType</a></td><td>
External System Resource Type - The resource type in the external system that this Synchronization Rule applies to.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_SynchronizationRule_ConnectedSystem">ConnectedSystem</a></td><td>
External System - The Management Agent identifying the external system this Synchronization Rule will operate on.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_SynchronizationRule_ConnectedSystemScope">ConnectedSystemScope</a></td><td>
External System Scoping Filter - A filter representing the resources on the external system that the rule applies to.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_SynchronizationRule_CreateConnectedSystemObject">CreateConnectedSystemObject</a></td><td>
Create External System Resource - Indicates if an external system resource is created if the relationship criteria is not met.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_IdmResource_CreatedTime">CreatedTime</a></td><td>
(aka Created Time) The time when the resource is created in the FIM service database. This attribute is assigned its value by the FIM service. It cannot be modified by any user.
 (Inherited from <a href="T_IdmNet_Models_IdmResource">IdmResource</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_SynchronizationRule_CreateILMObject">CreateILMObject</a></td><td>
Create FIM Resource - Indicates if a resource should be created in FIM if the relationship criteria is not met.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_IdmResource_Creator">Creator</a></td><td>
This is a reference attribute that refers to the resource that directly created the resource in the FIM service database. This attribute is assigned its value by the FIM service. It cannot be modified by any user.
 (Inherited from <a href="T_IdmNet_Models_IdmResource">IdmResource</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_IdmResource_DeletedTime">DeletedTime</a></td><td>
(aka Deleted Time) The time when the current resource is deleted from the FIM service database. This attribute is assigned its value by the FIM service. It cannot be modified by any user.
 (Inherited from <a href="T_IdmNet_Models_IdmResource">IdmResource</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_SynchronizationRule_Dependency">Dependency</a></td><td>
Dependency - A Synchronization Rule that must be applied to a resource before this Synchronization Rule can be applied.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_IdmResource_Description">Description</a></td><td>
Resource Description
 (Inherited from <a href="T_IdmNet_Models_IdmResource">IdmResource</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_IdmResource_DetectedRulesList">DetectedRulesList</a></td><td>
(aka Detected Rules List) The synchronization rules detected for resources in external systems.
 (Inherited from <a href="T_IdmNet_Models_IdmResource">IdmResource</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_SynchronizationRule_DisconnectConnectedSystemObject">DisconnectConnectedSystemObject</a></td><td>
Disconnect External System Resource - This option applies when this Synchronization Rule is removed from a resource in FIM.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_IdmResource_DisplayName">DisplayName</a></td><td>
(aka Display Name) Display name for the resource.
 (Inherited from <a href="T_IdmNet_Models_IdmResource">IdmResource</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_SynchronizationRule_ExistenceTest">ExistenceTest</a></td><td>
Existence Test - Outbound attribute flows within a transformation marked as an existence tests for the Synchronization Rule.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_IdmResource_ExpectedRulesList">ExpectedRulesList</a></td><td>
(aka Expected Rules List) This resource has been added to these Synchronization Rules and will be manifested in external systems according to the Synchronization Rule definitions.
 (Inherited from <a href="T_IdmNet_Models_IdmResource">IdmResource</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_IdmResource_ExpirationTime">ExpirationTime</a></td><td>
(aka Expiration Time) The date and time when the resource expires. The appropriate Management Policy Rule will delete the resource when the current date and time is later than the date and time specified in this attribute.
 (Inherited from <a href="T_IdmNet_Models_IdmResource">IdmResource</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_SynchronizationRule_FlowType">FlowType</a></td><td>
Data Flow Direction - A Synchronization Rule can be defined as inbound (0), outbound (1) or bi-directional (2).</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_SynchronizationRule_ILMObjectType">ILMObjectType</a></td><td>
FIM Resource Type - The resource type in the FIM Metaverse that this Synchronization Rule applies to.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_SynchronizationRule_InitialFlow">InitialFlow</a></td><td>
Initial Flow - A series of outbound flows between FIM and external systems. These flows are only executed upon creation of a new resource.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_IdmResource_Item">Item</a></td><td>
Resource Indexer - get's the attribute of the resource object as indexed by name.
 (Inherited from <a href="T_IdmNet_Models_IdmResource">IdmResource</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_IdmResource_Locale">Locale</a></td><td>
The region and language for which the representation of a resource has been adapted.
 (Inherited from <a href="T_IdmNet_Models_IdmResource">IdmResource</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_SynchronizationRule_ManagementAgentID">ManagementAgentID</a></td><td>
Management Agent ID - Description: The Management Agent identifying the external system this Synchronization Rule will operate on.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_SynchronizationRule_msidmOutboundIsFilterBased">msidmOutboundIsFilterBased</a></td><td>
Outbound Scope Filter Based - Determines how the synchronization rule is applied to existing resources.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_SynchronizationRule_msidmOutboundScopingFilters">msidmOutboundScopingFilters</a></td><td>
Outbound Scoping Filters - A filter representing the resources on the FIM metaverse that the rule applies to.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_IdmResource_MVObjectID">MVObjectID</a></td><td>
(aka MV Resource ID) The GUID of an entry in the FIM metaverse corresponding to this resource.
 (Inherited from <a href="T_IdmNet_Models_IdmResource">IdmResource</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_IdmResource_ObjectID">ObjectID</a></td><td>
(aka Resource ID) The value of the attribute is a globally unique identifier (GUID) assigned by FIM to each resource when it is created. Note that it is not required here since this class also represents resources that may not have been created as well as existing resources.
 (Inherited from <a href="T_IdmNet_Models_IdmResource">IdmResource</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_SynchronizationRule_ObjectType">ObjectType</a></td><td>
Object Type (can only be SynchronizationRule)
 (Overrides <a href="P_IdmNet_Models_IdmResource_ObjectType">IdmResource.ObjectType</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_SynchronizationRule_PersistentFlow">PersistentFlow</a></td><td>
Persistent Flow - A series of attribute flow definitions.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_SynchronizationRule_Precedence">Precedence</a></td><td>
Precedence - A number indicating the Synchronization Rule's precedence relative to all other Synchronization Rules that apply to the same external system. A smaller number represents a higher precedence.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_SynchronizationRule_RelationshipCriteria">RelationshipCriteria</a></td><td>
Relationship Criteria - Defines how a relationship between a resource in FIM and a resource in an external system is detected.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_IdmResource_ResourceTime">ResourceTime</a></td><td>
(aka Resource Time) The date and time of a representation of a resource. This attribute is updated by the FIM service. This attribute can be used to define time triggered Management Policy Rules.
 (Inherited from <a href="T_IdmNet_Models_IdmResource">IdmResource</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_SynchronizationRule_SynchronizationRuleParameters">SynchronizationRuleParameters</a></td><td>
Synchronization Rule Parameters - These are parameters which require values to be provided from the workflow that adds the Synchronization Rule to a resource.</td></tr></table>&nbsp;
<a href="#synchronizationrule-properties">Back to Top</a>

## See Also


#### Reference
<a href="T_IdmNet_Models_SynchronizationRule">SynchronizationRule Class</a><br /><a href="N_IdmNet_Models">IdmNet.Models Namespace</a><br />