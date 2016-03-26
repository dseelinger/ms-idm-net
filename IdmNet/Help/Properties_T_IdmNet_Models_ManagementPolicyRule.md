# ManagementPolicyRule Properties
 

The <a href="T_IdmNet_Models_ManagementPolicyRule">ManagementPolicyRule</a> type exposes the following members.


## Properties
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_ManagementPolicyRule_ActionParameter">ActionParameter</a></td><td>
Action Parameter - The attribute names the policy works for (used for READ/UPDATE action)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_ManagementPolicyRule_ActionType">ActionType</a></td><td>
Action Type - String representing the action associated with the management policy rule (Create, Delete, Read, Add, Remove, Modify, Transition In, Transition Out)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_ManagementPolicyRule_ActionWorkflowDefinition">ActionWorkflowDefinition</a></td><td>
Action Workflows - These workflows are applied as part of the policy. Read operations do not trigger workflows.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_IdmResource_Attributes">Attributes</a></td><td>
List of attributes for which we have data for this particular object. Note that due to performance reasons, there may be other attributes and values in the identity manager service, but they may not have been retrieved yet.
 (Inherited from <a href="T_IdmNet_Models_IdmResource">IdmResource</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_ManagementPolicyRule_AuthenticationWorkflowDefinition">AuthenticationWorkflowDefinition</a></td><td>
Authentication Workflows - These workflows will not be applied to Requests created by the Built-in Synchronization Account or Forefront Identity Manager Workflow Activities. Read operations do not trigger workflows.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_ManagementPolicyRule_AuthorizationWorkflowDefinition">AuthorizationWorkflowDefinition</a></td><td>
Authorization Workflows - These workflows will not be applied to Requests created by the Built-in Synchronization Account or Forefront Identity Manager Workflow Activities. Read operations do not trigger workflows.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_IdmResource_CreatedTime">CreatedTime</a></td><td>
(aka Created Time) The time when the resource is created in the FIM service database. This attribute is assigned its value by the FIM service. It cannot be modified by any user.
 (Inherited from <a href="T_IdmNet_Models_IdmResource">IdmResource</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_IdmResource_Creator">Creator</a></td><td>
This is a reference attribute that refers to the resource that directly created the resource in the FIM service database. This attribute is assigned its value by the FIM service. It cannot be modified by any user.
 (Inherited from <a href="T_IdmNet_Models_IdmResource">IdmResource</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_IdmResource_DeletedTime">DeletedTime</a></td><td>
(aka Deleted Time) The time when the current resource is deleted from the FIM service database. This attribute is assigned its value by the FIM service. It cannot be modified by any user.
 (Inherited from <a href="T_IdmNet_Models_IdmResource">IdmResource</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_IdmResource_Description">Description</a></td><td>
Resource Description
 (Inherited from <a href="T_IdmNet_Models_IdmResource">IdmResource</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_IdmResource_DetectedRulesList">DetectedRulesList</a></td><td>
(aka Detected Rules List) The synchronization rules detected for resources in external systems.
 (Inherited from <a href="T_IdmNet_Models_IdmResource">IdmResource</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_ManagementPolicyRule_Disabled">Disabled</a></td><td>
Disabled - Determines if resource is disabled or enabled</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_IdmResource_DisplayName">DisplayName</a></td><td>
(aka Display Name) Display name for the resource.
 (Inherited from <a href="T_IdmNet_Models_IdmResource">IdmResource</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_IdmResource_ExpectedRulesList">ExpectedRulesList</a></td><td>
(aka Expected Rules List) This resource has been added to these Synchronization Rules and will be manifested in external systems according to the Synchronization Rule definitions.
 (Inherited from <a href="T_IdmNet_Models_IdmResource">IdmResource</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_IdmResource_ExpirationTime">ExpirationTime</a></td><td>
(aka Expiration Time) The date and time when the resource expires. The appropriate Management Policy Rule will delete the resource when the current date and time is later than the date and time specified in this attribute.
 (Inherited from <a href="T_IdmNet_Models_IdmResource">IdmResource</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_ManagementPolicyRule_GrantRight">GrantRight</a></td><td>
Grant Right -</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_IdmResource_Item">Item</a></td><td>
Resource Indexer - get's the attribute of the resource object as indexed by name.
 (Inherited from <a href="T_IdmNet_Models_IdmResource">IdmResource</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_IdmResource_Locale">Locale</a></td><td>
The region and language for which the representation of a resource has been adapted.
 (Inherited from <a href="T_IdmNet_Models_IdmResource">IdmResource</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_ManagementPolicyRule_ManagementPolicyRuleType">ManagementPolicyRuleType</a></td><td>
Management Policy Rule Type - Indicates the type of this policy rule.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_IdmResource_MVObjectID">MVObjectID</a></td><td>
(aka MV Resource ID) The GUID of an entry in the FIM metaverse corresponding to this resource.
 (Inherited from <a href="T_IdmNet_Models_IdmResource">IdmResource</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_IdmResource_ObjectID">ObjectID</a></td><td>
(aka Resource ID) The value of the attribute is a globally unique identifier (GUID) assigned by FIM to each resource when it is created. Note that it is not required here since this class also represents resources that may not have been created as well as existing resources.
 (Inherited from <a href="T_IdmNet_Models_IdmResource">IdmResource</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_ManagementPolicyRule_ObjectType">ObjectType</a></td><td>
Object Type (can only be ManagementPolicyRule)
 (Overrides <a href="P_IdmNet_Models_IdmResource_ObjectType">IdmResource.ObjectType</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_ManagementPolicyRule_PrincipalRelativeToResource">PrincipalRelativeToResource</a></td><td>
Principal Set Relative To Resource -</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_ManagementPolicyRule_PrincipalSet">PrincipalSet</a></td><td>
Principal Set - Reference to the set the principal resource should belongs to.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_ManagementPolicyRule_ResourceCurrentSet">ResourceCurrentSet</a></td><td>
Resource Current Set -</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_ManagementPolicyRule_ResourceFinalSet">ResourceFinalSet</a></td><td>
Resource Final Set -</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_IdmResource_ResourceTime">ResourceTime</a></td><td>
(aka Resource Time) The date and time of a representation of a resource. This attribute is updated by the FIM service. This attribute can be used to define time triggered Management Policy Rules.
 (Inherited from <a href="T_IdmNet_Models_IdmResource">IdmResource</a>.)</td></tr></table>&nbsp;
<a href="#managementpolicyrule-properties">Back to Top</a>

## See Also


#### Reference
<a href="T_IdmNet_Models_ManagementPolicyRule">ManagementPolicyRule Class</a><br /><a href="N_IdmNet_Models">IdmNet.Models Namespace</a><br />