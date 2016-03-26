# ContextHeader Class
 

SOAP Model


## Inheritance Hierarchy
<a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">System.Object</a><br />&nbsp;&nbsp;<a href="http://msdn2.microsoft.com/en-us/library/ms405929" target="_blank">System.ServiceModel.Channels.MessageHeaderInfo</a><br />&nbsp;&nbsp;&nbsp;&nbsp;<a href="http://msdn2.microsoft.com/en-us/library/ms405928" target="_blank">System.ServiceModel.Channels.MessageHeader</a><br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IdmNet.SoapModels.ContextHeader<br />
**Namespace:**&nbsp;<a href="N_IdmNet_SoapModels">IdmNet.SoapModels</a><br />**Assembly:**&nbsp;IdmNet (in IdmNet.dll) Version: 1.0.0.0 (1.0.0)

## Syntax

**C#**<br />
``` C#
public sealed class ContextHeader : MessageHeader
```

**VB**<br />
``` VB
Public NotInheritable Class ContextHeader
	Inherits MessageHeader
```

**C++**<br />
``` C++
public ref class ContextHeader sealed : public MessageHeader
```

**F#**<br />
``` F#
[<SealedAttribute>]
type ContextHeader =  
    class
        inherit MessageHeader
    end
```

The ContextHeader type exposes the following members.


## Constructors
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_IdmNet_SoapModels_ContextHeader__ctor">ContextHeader</a></td><td>
SOAP Model Ctor</td></tr></table>&nbsp;
<a href="#contextheader-class">Back to Top</a>

## Properties
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="http://msdn2.microsoft.com/en-us/library/ms405709" target="_blank">Actor</a></td><td>
Gets or sets the targeted recipient of the message header.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/ms405928" target="_blank">MessageHeader</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="http://msdn2.microsoft.com/en-us/library/ms405710" target="_blank">IsReferenceParameter</a></td><td>
Gets a value that specifies whether this message header contains reference parameters of an endpoint reference.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/ms405928" target="_blank">MessageHeader</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="http://msdn2.microsoft.com/en-us/library/ms405711" target="_blank">MustUnderstand</a></td><td>
Gets or sets a value that indicates whether the header must be understood, according to SOAP 1.1/1.2 specification.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/ms405928" target="_blank">MessageHeader</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_SoapModels_ContextHeader_Name">Name</a></td><td>
Par of a SOAP Model
 (Overrides <a href="http://msdn2.microsoft.com/en-us/library/ms405695" target="_blank">MessageHeaderInfo.Name</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_SoapModels_ContextHeader_Namespace">Namespace</a></td><td>
Par of a SOAP Model
 (Overrides <a href="http://msdn2.microsoft.com/en-us/library/ms405696" target="_blank">MessageHeaderInfo.Namespace</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="http://msdn2.microsoft.com/en-us/library/ms405712" target="_blank">Relay</a></td><td>
Gets a value that indicates whether the header should be relayed.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/ms405928" target="_blank">MessageHeader</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_IdmNet_SoapModels_ContextHeader_WorkflowInstanceID">WorkflowInstanceID</a></td><td>
Par of a SOAP Model</td></tr></table>&nbsp;
<a href="#contextheader-class">Back to Top</a>

## Methods
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/bsc2ak47" target="_blank">Equals</a></td><td>
Determines whether the specified object is equal to the current object.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/zdee4b3y" target="_blank">GetHashCode</a></td><td>
Serves as the default hash function.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/dfwy45w9" target="_blank">GetType</a></td><td>
Gets the <a href="http://msdn2.microsoft.com/en-us/library/42892f65" target="_blank">Type</a> of the current instance.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/ms195416" target="_blank">IsMessageVersionSupported</a></td><td>
Verifies whether the specified message version is supported.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/ms405928" target="_blank">MessageHeader</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/ms195419" target="_blank">ToString</a></td><td>
Returns the string representation of this message header.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/ms405928" target="_blank">MessageHeader</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/ms195422" target="_blank">WriteHeader(XmlWriter, MessageVersion)</a></td><td>
Serializes the header using the specified XML writer.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/ms405928" target="_blank">MessageHeader</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/ms195423" target="_blank">WriteHeader(XmlDictionaryWriter, MessageVersion)</a></td><td>
Serializes the header using the specified XML writer.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/ms405928" target="_blank">MessageHeader</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/ms195421" target="_blank">WriteHeaderContents</a></td><td>
Serializes the header contents using the specified XML writer.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/ms405928" target="_blank">MessageHeader</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/ms195424" target="_blank">WriteStartHeader</a></td><td>
Serializes the start header using the specified XML writer.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/ms405928" target="_blank">MessageHeader</a>.)</td></tr></table>&nbsp;
<a href="#contextheader-class">Back to Top</a>

## See Also


#### Reference
<a href="N_IdmNet_SoapModels">IdmNet.SoapModels Namespace</a><br />