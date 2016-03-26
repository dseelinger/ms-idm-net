# AttributeTypeDescription Properties
 

The <a href="T_IdmNet_Models_AttributeTypeDescription">AttributeTypeDescription</a> type exposes the following members.


## Properties
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_IdmResource_Attributes">Attributes</a></td><td>
List of attributes for which we have data for this particular object. Note that due to performance reasons, there may be other attributes and values in the identity manager service, but they may not have been retrieved yet.
 (Inherited from <a href="T_IdmNet_Models_IdmResource">IdmResource</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_IdmResource_CreatedTime">CreatedTime</a></td><td>
(aka Created Time) The time when the resource is created in the FIM service database. This attribute is assigned its value by the FIM service. It cannot be modified by any user.
 (Inherited from <a href="T_IdmNet_Models_IdmResource">IdmResource</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_IdmResource_Creator">Creator</a></td><td>
This is a reference attribute that refers to the resource that directly created the resource in the FIM service database. This attribute is assigned its value by the FIM service. It cannot be modified by any user.
 (Inherited from <a href="T_IdmNet_Models_IdmResource">IdmResource</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_AttributeTypeDescription_DataType">DataType</a></td><td>
Data Type -</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_IdmResource_DeletedTime">DeletedTime</a></td><td>
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
 (Inherited from <a href="T_IdmNet_Models_IdmResource">IdmResource</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_AttributeTypeDescription_IntegerMaximum">IntegerMaximum</a></td><td>
Integer Maximum - For an Integer attribute, this is the maximum value, inclusive.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_AttributeTypeDescription_IntegerMinimum">IntegerMinimum</a></td><td>
Integer Minimum - For an Integer attribute, this is the minimum value, inclusive.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_IdmResource_Item">Item</a></td><td>
Resource Indexer - get's the attribute of the resource object as indexed by name.
 (Inherited from <a href="T_IdmNet_Models_IdmResource">IdmResource</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_IdmResource_Locale">Locale</a></td><td>
The region and language for which the representation of a resource has been adapted.
 (Inherited from <a href="T_IdmNet_Models_IdmResource">IdmResource</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_AttributeTypeDescription_Localizable">Localizable</a></td><td>
Localizable - A true indicates this attribute can be localized. Only allowed for String DataTypes.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_AttributeTypeDescription_Multivalued">Multivalued</a></td><td>
Multivalued -</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_IdmResource_MVObjectID">MVObjectID</a></td><td>
(aka MV Resource ID) The GUID of an entry in the FIM metaverse corresponding to this resource.
 (Inherited from <a href="T_IdmNet_Models_IdmResource">IdmResource</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_AttributeTypeDescription_Name">Name</a></td><td>
Name -</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_IdmResource_ObjectID">ObjectID</a></td><td>
(aka Resource ID) The value of the attribute is a globally unique identifier (GUID) assigned by FIM to each resource when it is created. Note that it is not required here since this class also represents resources that may not have been created as well as existing resources.
 (Inherited from <a href="T_IdmNet_Models_IdmResource">IdmResource</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_AttributeTypeDescription_ObjectType">ObjectType</a></td><td>
Object Type (can only be AttributeTypeDescription)
 (Overrides <a href="P_IdmNet_Models_IdmResource_ObjectType">IdmResource.ObjectType</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_IdmResource_ResourceTime">ResourceTime</a></td><td>
(aka Resource Time) The date and time of a representation of a resource. This attribute is updated by the FIM service. This attribute can be used to define time triggered Management Policy Rules.
 (Inherited from <a href="T_IdmNet_Models_IdmResource">IdmResource</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_AttributeTypeDescription_StringRegex">StringRegex</a></td><td>
String Regular Expression - This is a .Net Regex pattern that defines what string values are allowed.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_AttributeTypeDescription_UsageKeyword">UsageKeyword</a></td><td>
Usage Keyword -</td></tr></table>&nbsp;
<a href="#attributetypedescription-properties">Back to Top</a>

## See Also


#### Reference
<a href="T_IdmNet_Models_AttributeTypeDescription">AttributeTypeDescription Class</a><br /><a href="N_IdmNet_Models">IdmNet.Models Namespace</a><br />