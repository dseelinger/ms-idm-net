# IdmResource Class
 

Model to represents a basic resource in the Identity Manager Resource


## Inheritance Hierarchy
<a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">System.Object</a><br />&nbsp;&nbsp;IdmNet.Models.IdmResource<br />&nbsp;&nbsp;&nbsp;&nbsp;<a href="#inheritance-hierarchy" />
**Namespace:**&nbsp;<a href="N_IdmNet_Models">IdmNet.Models</a><br />**Assembly:**&nbsp;IdmNet (in IdmNet.dll) Version: 1.0.0.0 (1.0.0)

## Syntax

**C#**<br />
``` C#
public class IdmResource
```

**VB**<br />
``` VB
Public Class IdmResource
```

**C++**<br />
``` C++
public ref class IdmResource
```

**F#**<br />
``` F#
type IdmResource =  class end
```

The IdmResource type exposes the following members.


## Constructors
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_IdmNet_Models_IdmResource__ctor">IdmResource</a></td><td>
Parameterless constructor</td></tr></table>&nbsp;
<a href="#idmresource-class">Back to Top</a>

## Properties
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_IdmResource_Attributes">Attributes</a></td><td>
List of attributes for which we have data for this particular object. Note that due to performance reasons, there may be other attributes and values in the identity manager service, but they may not have been retrieved yet.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_IdmResource_CreatedTime">CreatedTime</a></td><td>
(aka Created Time) The time when the resource is created in the FIM service database. This attribute is assigned its value by the FIM service. It cannot be modified by any user.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_IdmResource_Creator">Creator</a></td><td>
This is a reference attribute that refers to the resource that directly created the resource in the FIM service database. This attribute is assigned its value by the FIM service. It cannot be modified by any user.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_IdmResource_DeletedTime">DeletedTime</a></td><td>
(aka Deleted Time) The time when the current resource is deleted from the FIM service database. This attribute is assigned its value by the FIM service. It cannot be modified by any user.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_IdmResource_Description">Description</a></td><td>
Resource Description</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_IdmResource_DetectedRulesList">DetectedRulesList</a></td><td>
(aka Detected Rules List) The synchronization rules detected for resources in external systems.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_IdmResource_DisplayName">DisplayName</a></td><td>
(aka Display Name) Display name for the resource.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_IdmResource_ExpectedRulesList">ExpectedRulesList</a></td><td>
(aka Expected Rules List) This resource has been added to these Synchronization Rules and will be manifested in external systems according to the Synchronization Rule definitions.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_IdmResource_ExpirationTime">ExpirationTime</a></td><td>
(aka Expiration Time) The date and time when the resource expires. The appropriate Management Policy Rule will delete the resource when the current date and time is later than the date and time specified in this attribute.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_IdmResource_Item">Item</a></td><td>
Resource Indexer - get's the attribute of the resource object as indexed by name.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_IdmResource_Locale">Locale</a></td><td>
The region and language for which the representation of a resource has been adapted.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_IdmResource_MVObjectID">MVObjectID</a></td><td>
(aka MV Resource ID) The GUID of an entry in the FIM metaverse corresponding to this resource.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_IdmResource_ObjectID">ObjectID</a></td><td>
(aka Resource ID) The value of the attribute is a globally unique identifier (GUID) assigned by FIM to each resource when it is created. Note that it is not required here since this class also represents resources that may not have been created as well as existing resources.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_IdmResource_ObjectType">ObjectType</a></td><td>
(aka Resource Type) The resource type of a resource. This attribute is assigned its value when the resource is created in the FIM service database by the FIM service. It cannot be modified by any user.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_IdmResource_ResourceTime">ResourceTime</a></td><td>
(aka Resource Time) The date and time of a representation of a resource. This attribute is updated by the FIM service. This attribute can be used to define time triggered Management Policy Rules.</td></tr></table>&nbsp;
<a href="#idmresource-class">Back to Top</a>

## Methods
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="M_IdmNet_Models_IdmResource_AttrToBool">AttrToBool</a></td><td>
Convert the named attribute to a Boolean value</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="M_IdmNet_Models_IdmResource_AttrToDateTime">AttrToDateTime</a></td><td>
Convert the named attribute to a DateTime value</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="M_IdmNet_Models_IdmResource_AttrToInteger">AttrToInteger</a></td><td>
Convert the named attribute to an Integer value</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="M_IdmNet_Models_IdmResource_AttrToNullableBool">AttrToNullableBool</a></td><td>
Convert the named attribute to a Boolean value</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="M_IdmNet_Models_IdmResource_AttrToNullableDateTime">AttrToNullableDateTime</a></td><td>
Convert the named attribute to a DateTime value</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="M_IdmNet_Models_IdmResource_AttrToNullableInteger">AttrToNullableInteger</a></td><td>
Convert the named attribute to an Integer value</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/bsc2ak47" target="_blank">Equals</a></td><td>
Determines whether the specified object is equal to the current object.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/4k87zsw7" target="_blank">Finalize</a></td><td>
Allows an object to try to free resources and perform other cleanup operations before it is reclaimed by garbage collection.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_IdmNet_Models_IdmResource_GetAttr">GetAttr(String)</a></td><td>
Get a particular attribute and its values by name</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_IdmNet_Models_IdmResource_GetAttr__1">GetAttr(T)(String, T)</a></td><td>
Get the complex object that is backing a single-valued reference attribute in IdmNet.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_IdmNet_Models_IdmResource_GetAttrValue">GetAttrValue</a></td><td>
Get just a single value from an attribute object by name</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_IdmNet_Models_IdmResource_GetAttrValues">GetAttrValues</a></td><td>
Get all attribute values from an attribute object by name</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/zdee4b3y" target="_blank">GetHashCode</a></td><td>
Serves as the default hash function.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_IdmNet_Models_IdmResource_GetMultiValuedAttr__1">GetMultiValuedAttr(T)</a></td><td>
Get the list of complex objects that is backing a multi-valued reference attribute in IdmNet.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/dfwy45w9" target="_blank">GetType</a></td><td>
Gets the <a href="http://msdn2.microsoft.com/en-us/library/42892f65" target="_blank">Type</a> of the current instance.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/57ctke0a" target="_blank">MemberwiseClone</a></td><td>
Creates a shallow copy of the current <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")![Static member](media/static.gif "Static member")</td><td><a href="M_IdmNet_Models_IdmResource_ObjectIdOrNull">ObjectIdOrNull</a></td><td>
Returns the ObjectID of the resource or NULL if the resource value is null</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_IdmNet_Models_IdmResource_SetAttrValue">SetAttrValue</a></td><td>
Set just a single value on a named attribute object</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_IdmNet_Models_IdmResource_SetAttrValues">SetAttrValues</a></td><td>
Set all attribute values on an named attribute object</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_IdmNet_Models_IdmResource_SetMultiValuedAttr__1">SetMultiValuedAttr(T)</a></td><td>
Set the list of complex objects that is backing a multi-valued reference attribute in IdmNet.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/7bxwbwt2" target="_blank">ToString</a></td><td>
Returns a string that represents the current object.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr></table>&nbsp;
<a href="#idmresource-class">Back to Top</a>

## See Also


#### Reference
<a href="N_IdmNet_Models">IdmNet.Models Namespace</a><br />

## Inheritance Hierarchy<a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">System.Object</a><br />&nbsp;&nbsp;IdmNet.Models.IdmResource<br />&nbsp;&nbsp;&nbsp;&nbsp;<a href="T_IdmNet_Models_ActivityInformationConfiguration">IdmNet.Models.ActivityInformationConfiguration</a><br />&nbsp;&nbsp;&nbsp;&nbsp;<a href="T_IdmNet_Models_Approval">IdmNet.Models.Approval</a><br />&nbsp;&nbsp;&nbsp;&nbsp;<a href="T_IdmNet_Models_ApprovalResponse">IdmNet.Models.ApprovalResponse</a><br />&nbsp;&nbsp;&nbsp;&nbsp;<a href="T_IdmNet_Models_AttributeTypeDescription">IdmNet.Models.AttributeTypeDescription</a><br />&nbsp;&nbsp;&nbsp;&nbsp;<a href="T_IdmNet_Models_BindingDescription">IdmNet.Models.BindingDescription</a><br />&nbsp;&nbsp;&nbsp;&nbsp;<a href="T_IdmNet_Models_Configuration">IdmNet.Models.Configuration</a><br />&nbsp;&nbsp;&nbsp;&nbsp;<a href="T_IdmNet_Models_ConstantSpecifier">IdmNet.Models.ConstantSpecifier</a><br />&nbsp;&nbsp;&nbsp;&nbsp;<a href="T_IdmNet_Models_DetectedRuleEntry">IdmNet.Models.DetectedRuleEntry</a><br />&nbsp;&nbsp;&nbsp;&nbsp;<a href="T_IdmNet_Models_DomainConfiguration">IdmNet.Models.DomainConfiguration</a><br />&nbsp;&nbsp;&nbsp;&nbsp;<a href="T_IdmNet_Models_EmailTemplate">IdmNet.Models.EmailTemplate</a><br />&nbsp;&nbsp;&nbsp;&nbsp;<a href="T_IdmNet_Models_ExpectedRuleEntry">IdmNet.Models.ExpectedRuleEntry</a><br />&nbsp;&nbsp;&nbsp;&nbsp;<a href="T_IdmNet_Models_FilterScope">IdmNet.Models.FilterScope</a><br />&nbsp;&nbsp;&nbsp;&nbsp;<a href="T_IdmNet_Models_ForestConfiguration">IdmNet.Models.ForestConfiguration</a><br />&nbsp;&nbsp;&nbsp;&nbsp;<a href="T_IdmNet_Models_Function">IdmNet.Models.Function</a><br />&nbsp;&nbsp;&nbsp;&nbsp;<a href="T_IdmNet_Models_GateRegistration">IdmNet.Models.GateRegistration</a><br />&nbsp;&nbsp;&nbsp;&nbsp;<a href="T_IdmNet_Models_Group">IdmNet.Models.Group</a><br />&nbsp;&nbsp;&nbsp;&nbsp;<a href="T_IdmNet_Models_HomepageConfiguration">IdmNet.Models.HomepageConfiguration</a><br />&nbsp;&nbsp;&nbsp;&nbsp;<a href="T_IdmNet_Models_ma_data">IdmNet.Models.ma_data</a><br />&nbsp;&nbsp;&nbsp;&nbsp;<a href="T_IdmNet_Models_ManagementPolicyRule">IdmNet.Models.ManagementPolicyRule</a><br />&nbsp;&nbsp;&nbsp;&nbsp;<a href="T_IdmNet_Models_msidmCompositeType">IdmNet.Models.msidmCompositeType</a><br />&nbsp;&nbsp;&nbsp;&nbsp;<a href="T_IdmNet_Models_msidmDataWarehouseBinding">IdmNet.Models.msidmDataWarehouseBinding</a><br />&nbsp;&nbsp;&nbsp;&nbsp;<a href="T_IdmNet_Models_msidmReportingJob">IdmNet.Models.msidmReportingJob</a><br />&nbsp;&nbsp;&nbsp;&nbsp;<a href="T_IdmNet_Models_msidmRequestContext">IdmNet.Models.msidmRequestContext</a><br />&nbsp;&nbsp;&nbsp;&nbsp;<a href="T_IdmNet_Models_msidmRequestTargetDetail">IdmNet.Models.msidmRequestTargetDetail</a><br />&nbsp;&nbsp;&nbsp;&nbsp;<a href="T_IdmNet_Models_msidmSystemConfiguration">IdmNet.Models.msidmSystemConfiguration</a><br />&nbsp;&nbsp;&nbsp;&nbsp;<a href="T_IdmNet_Models_mv_data">IdmNet.Models.mv_data</a><br />&nbsp;&nbsp;&nbsp;&nbsp;<a href="T_IdmNet_Models_NavigationBarConfiguration">IdmNet.Models.NavigationBarConfiguration</a><br />&nbsp;&nbsp;&nbsp;&nbsp;<a href="T_IdmNet_Models_ObjectTypeDescription">IdmNet.Models.ObjectTypeDescription</a><br />&nbsp;&nbsp;&nbsp;&nbsp;<a href="T_IdmNet_Models_ObjectVisualizationConfiguration">IdmNet.Models.ObjectVisualizationConfiguration</a><br />&nbsp;&nbsp;&nbsp;&nbsp;<a href="T_IdmNet_Models_Person">IdmNet.Models.Person</a><br />&nbsp;&nbsp;&nbsp;&nbsp;<a href="T_IdmNet_Models_PortalUIConfiguration">IdmNet.Models.PortalUIConfiguration</a><br />&nbsp;&nbsp;&nbsp;&nbsp;<a href="T_IdmNet_Models_Request">IdmNet.Models.Request</a><br />&nbsp;&nbsp;&nbsp;&nbsp;<a href="T_IdmNet_Models_Resource">IdmNet.Models.Resource</a><br />&nbsp;&nbsp;&nbsp;&nbsp;<a href="T_IdmNet_Models_SearchScopeConfiguration">IdmNet.Models.SearchScopeConfiguration</a><br />&nbsp;&nbsp;&nbsp;&nbsp;<a href="T_IdmNet_Models_Set">IdmNet.Models.Set</a><br />&nbsp;&nbsp;&nbsp;&nbsp;<a href="T_IdmNet_Models_SupportedLocaleConfiguration">IdmNet.Models.SupportedLocaleConfiguration</a><br />&nbsp;&nbsp;&nbsp;&nbsp;<a href="T_IdmNet_Models_SynchronizationFilter">IdmNet.Models.SynchronizationFilter</a><br />&nbsp;&nbsp;&nbsp;&nbsp;<a href="T_IdmNet_Models_SynchronizationRule">IdmNet.Models.SynchronizationRule</a><br />&nbsp;&nbsp;&nbsp;&nbsp;<a href="T_IdmNet_Models_SystemResourceRetentionConfiguration">IdmNet.Models.SystemResourceRetentionConfiguration</a><br />&nbsp;&nbsp;&nbsp;&nbsp;<a href="T_IdmNet_Models_TimeZoneConfiguration">IdmNet.Models.TimeZoneConfiguration</a><br />&nbsp;&nbsp;&nbsp;&nbsp;<a href="T_IdmNet_Models_WorkflowDefinition">IdmNet.Models.WorkflowDefinition</a><br />&nbsp;&nbsp;&nbsp;&nbsp;<a href="T_IdmNet_Models_WorkflowInstance">IdmNet.Models.WorkflowInstance</a><br />