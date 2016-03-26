# IdmAttribute Class
 

Represents an individual Identity Manager resource's attribute and value


## Inheritance Hierarchy
<a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">System.Object</a><br />&nbsp;&nbsp;IdmNet.Models.IdmAttribute<br />
**Namespace:**&nbsp;<a href="N_IdmNet_Models">IdmNet.Models</a><br />**Assembly:**&nbsp;IdmNet (in IdmNet.dll) Version: 1.0.0.0 (1.0.0)

## Syntax

**C#**<br />
``` C#
public class IdmAttribute
```

**VB**<br />
``` VB
Public Class IdmAttribute
```

**C++**<br />
``` C++
public ref class IdmAttribute
```

**F#**<br />
``` F#
type IdmAttribute =  class end
```

The IdmAttribute type exposes the following members.


## Constructors
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_IdmNet_Models_IdmAttribute__ctor">IdmAttribute</a></td><td>
Parameterless Constructor</td></tr></table>&nbsp;
<a href="#idmattribute-class">Back to Top</a>

## Properties
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_IdmAttribute_Name">Name</a></td><td>
Attribute name</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_IdmAttribute_Value">Value</a></td><td>
Makes the native multi-valued nature of the Attribute look like a single-valued attribute</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_Models_IdmAttribute_Values">Values</a></td><td>
List of values for this attribute</td></tr></table>&nbsp;
<a href="#idmattribute-class">Back to Top</a>

## Methods
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/bsc2ak47" target="_blank">Equals</a></td><td>
Determines whether the specified object is equal to the current object.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/4k87zsw7" target="_blank">Finalize</a></td><td>
Allows an object to try to free resources and perform other cleanup operations before it is reclaimed by garbage collection.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/zdee4b3y" target="_blank">GetHashCode</a></td><td>
Serves as the default hash function.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/dfwy45w9" target="_blank">GetType</a></td><td>
Gets the <a href="http://msdn2.microsoft.com/en-us/library/42892f65" target="_blank">Type</a> of the current instance.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/57ctke0a" target="_blank">MemberwiseClone</a></td><td>
Creates a shallow copy of the current <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_IdmNet_Models_IdmAttribute_ToBinaries">ToBinaries</a></td><td>
Convert the Values (strings) of an multi-valued attribute to binary, if the attribute is defined as Binary in Identity Manager</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_IdmNet_Models_IdmAttribute_ToBinary">ToBinary</a></td><td>
Convert the Value (string) of an attribute to a binary value (byte[]), if the attribute is defined as binary in Identity Manager</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_IdmNet_Models_IdmAttribute_ToBool">ToBool</a></td><td>
Convert the Value (string) of an attribute to boolean, if the attribute is defined as a boolean in Identity Manager</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_IdmNet_Models_IdmAttribute_ToDateTime">ToDateTime</a></td><td>
Convert the Value (string) of an attribute to DateTime, if the attribute is defined as a DateTime object in Identity Manager</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_IdmNet_Models_IdmAttribute_ToDateTimes">ToDateTimes</a></td><td>
Convert the Values (strings) of an multi-valued attribute to DateTime, if the attribute is defined as a DateTime in Identity Manager</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_IdmNet_Models_IdmAttribute_ToInteger">ToInteger</a></td><td>
Convert the Value (string) of an attribute to a integer value if the attribute is defined as such in Identity Manager</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_IdmNet_Models_IdmAttribute_ToIntegers">ToIntegers</a></td><td>
Convert the Values (strings) of an multi-valued attribute to integers, if the attribute is defined as integer in Identity Manager</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/7bxwbwt2" target="_blank">ToString</a></td><td>
Returns a string that represents the current object.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr></table>&nbsp;
<a href="#idmattribute-class">Back to Top</a>

## See Also


#### Reference
<a href="N_IdmNet_Models">IdmNet.Models Namespace</a><br />