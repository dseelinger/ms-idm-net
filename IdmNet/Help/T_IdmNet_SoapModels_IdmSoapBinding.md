# IdmSoapBinding Class
 

This is the default WCF binding for IdMNet


## Inheritance Hierarchy
<a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">System.Object</a><br />&nbsp;&nbsp;<a href="http://msdn2.microsoft.com/en-us/library/ms405791" target="_blank">System.ServiceModel.Channels.Binding</a><br />&nbsp;&nbsp;&nbsp;&nbsp;<a href="http://msdn2.microsoft.com/en-us/library/ms586936" target="_blank">System.ServiceModel.WSHttpBindingBase</a><br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="http://msdn2.microsoft.com/en-us/library/ms586935" target="_blank">System.ServiceModel.WSHttpBinding</a><br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="http://msdn2.microsoft.com/en-us/library/bb347282" target="_blank">System.ServiceModel.WSHttpContextBinding</a><br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IdmNet.SoapModels.IdmSoapBinding<br />
**Namespace:**&nbsp;<a href="N_IdmNet_SoapModels">IdmNet.SoapModels</a><br />**Assembly:**&nbsp;IdmNet (in IdmNet.dll) Version: 1.0.0.0 (1.0.0)

## Syntax

**C#**<br />
``` C#
public class IdmSoapBinding : WSHttpContextBinding
```

**VB**<br />
``` VB
Public Class IdmSoapBinding
	Inherits WSHttpContextBinding
```

**C++**<br />
``` C++
public ref class IdmSoapBinding : public WSHttpContextBinding
```

**F#**<br />
``` F#
type IdmSoapBinding =  
    class
        inherit WSHttpContextBinding
    end
```

The IdmSoapBinding type exposes the following members.


## Constructors
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_IdmNet_SoapModels_IdmSoapBinding__ctor">IdmSoapBinding()</a></td><td>
Parameterless CTOR</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_IdmNet_SoapModels_IdmSoapBinding__ctor_1">IdmSoapBinding(Int32)</a></td><td>
CTOR with a specific data size (don't think it's actually used currently, but could be useful in a debuggin scenario</td></tr></table>&nbsp;
<a href="#idmsoapbinding-class">Back to Top</a>

## Properties
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="http://msdn2.microsoft.com/en-us/library/aa344817" target="_blank">AllowCookies</a></td><td>
Gets or sets a value that indicates whether the WCF client will automatically store and resend any cookies sent by a single web service.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/ms586935" target="_blank">WSHttpBinding</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="http://msdn2.microsoft.com/en-us/library/ms554554" target="_blank">BypassProxyOnLocal</a></td><td>
Gets or sets a value that indicates whether to bypass the proxy server for local addresses.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/ms586936" target="_blank">WSHttpBindingBase</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="http://msdn2.microsoft.com/en-us/library/dd575315" target="_blank">ClientCallbackAddress</a></td><td>
Gets or sets the client callback address.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/bb347282" target="_blank">WSHttpContextBinding</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="http://msdn2.microsoft.com/en-us/library/ms405601" target="_blank">CloseTimeout</a></td><td>
Gets or sets the interval of time provided for a connection to close before the transport raises an exception.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/ms405791" target="_blank">Binding</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="http://msdn2.microsoft.com/en-us/library/dd642280" target="_blank">ContextManagementEnabled</a></td><td>
Gets a value that specifies whether context management is enabled.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/bb347282" target="_blank">WSHttpContextBinding</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="http://msdn2.microsoft.com/en-us/library/bb301454" target="_blank">ContextProtectionLevel</a></td><td>
Gets or sets the context protection level for this binding.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/bb347282" target="_blank">WSHttpContextBinding</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="http://msdn2.microsoft.com/en-us/library/ms554556" target="_blank">EnvelopeVersion</a></td><td>
Gets the version of SOAP that is used for messages that are processed by this binding.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/ms586936" target="_blank">WSHttpBindingBase</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="http://msdn2.microsoft.com/en-us/library/ms586286" target="_blank">HostNameComparisonMode</a></td><td>
Gets or sets a value that indicates whether the hostname is used to reach the service when matching the URI.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/ms586936" target="_blank">WSHttpBindingBase</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="http://msdn2.microsoft.com/en-us/library/ms586287" target="_blank">MaxBufferPoolSize</a></td><td>
Gets or sets the maximum amount of memory allocated, in bytes, for the buffer manager that manages the buffers required by endpoints using this binding.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/ms586936" target="_blank">WSHttpBindingBase</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="http://msdn2.microsoft.com/en-us/library/ms586288" target="_blank">MaxReceivedMessageSize</a></td><td>
Gets or sets the maximum size, in bytes, for a message that can be processed by the binding.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/ms586936" target="_blank">WSHttpBindingBase</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="http://msdn2.microsoft.com/en-us/library/ms586289" target="_blank">MessageEncoding</a></td><td>
Gets or sets whether MTOM or Text/XML is used to encode SOAP messages.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/ms586936" target="_blank">WSHttpBindingBase</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="http://msdn2.microsoft.com/en-us/library/aa345270" target="_blank">MessageVersion</a></td><td>
Gets the message version used by clients and services configured with the binding.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/ms405791" target="_blank">Binding</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="http://msdn2.microsoft.com/en-us/library/ms405602" target="_blank">Name</a></td><td>
Gets or sets the name of the binding.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/ms405791" target="_blank">Binding</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="http://msdn2.microsoft.com/en-us/library/ms405603" target="_blank">Namespace</a></td><td>
Gets or sets the XML namespace of the binding.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/ms405791" target="_blank">Binding</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="http://msdn2.microsoft.com/en-us/library/ms405604" target="_blank">OpenTimeout</a></td><td>
Gets or sets the interval of time provided for a connection to open before the transport raises an exception.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/ms405791" target="_blank">Binding</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="http://msdn2.microsoft.com/en-us/library/ms586290" target="_blank">ProxyAddress</a></td><td>
Gets or sets the URI address of the HTTP proxy.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/ms586936" target="_blank">WSHttpBindingBase</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="http://msdn2.microsoft.com/en-us/library/ms586291" target="_blank">ReaderQuotas</a></td><td>
Gets or sets constraints on the complexity of SOAP messages that can be processed by endpoints configured with this binding.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/ms586936" target="_blank">WSHttpBindingBase</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="http://msdn2.microsoft.com/en-us/library/ms405605" target="_blank">ReceiveTimeout</a></td><td>
Gets or sets the interval of time that a connection can remain inactive, during which no application messages are received, before it is dropped.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/ms405791" target="_blank">Binding</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="http://msdn2.microsoft.com/en-us/library/ms586292" target="_blank">ReliableSession</a></td><td>
Gets an object that provides convenient access to the properties of a reliable session binding element that are available when using one of the system-provided bindings.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/ms586936" target="_blank">WSHttpBindingBase</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="http://msdn2.microsoft.com/en-us/library/ms586293" target="_blank">Scheme</a></td><td>
Gets the URI transport scheme for the channels and listeners that are configured with this binding.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/ms586936" target="_blank">WSHttpBindingBase</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="http://msdn2.microsoft.com/en-us/library/ms586301" target="_blank">Security</a></td><td>
Gets the security settings used with this binding.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/ms586935" target="_blank">WSHttpBinding</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="http://msdn2.microsoft.com/en-us/library/ms405607" target="_blank">SendTimeout</a></td><td>
Gets or sets the interval of time provided for a write operation to complete before the transport raises an exception.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/ms405791" target="_blank">Binding</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="http://msdn2.microsoft.com/en-us/library/ms586298" target="_blank">TextEncoding</a></td><td>
Gets or sets the character encoding that is used for the message text.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/ms586936" target="_blank">WSHttpBindingBase</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="http://msdn2.microsoft.com/en-us/library/ms586299" target="_blank">TransactionFlow</a></td><td>
Gets or sets a value that indicates whether this binding should support flowing WS-Transactions.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/ms586936" target="_blank">WSHttpBindingBase</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="http://msdn2.microsoft.com/en-us/library/ms586300" target="_blank">UseDefaultWebProxy</a></td><td>
Gets or sets a value that indicates whether the auto-configured HTTP proxy of the system should be used, if available.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/ms586936" target="_blank">WSHttpBindingBase</a>.)</td></tr></table>&nbsp;
<a href="#idmsoapbinding-class">Back to Top</a>

## Methods
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/hh160405" target="_blank">BuildChannelFactory(TChannel)(BindingParameterCollection)</a></td><td>
Builds the channel factory stack on the client that creates a specified type of channel and that satisfies the features specified by a collection of binding parameters.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/ms586935" target="_blank">WSHttpBinding</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/ms405440" target="_blank">BuildChannelFactory(TChannel)(Object[])</a></td><td>
Builds the channel factory stack on the client that creates a specified type of channel and that satisfies the features specified by an object array.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/ms405791" target="_blank">Binding</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/ms405448" target="_blank">BuildChannelListener(TChannel)(Object[])</a></td><td>
Builds the channel listener on the service that accepts a specified type of channel and that satisfies the features specified.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/ms405791" target="_blank">Binding</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/ms554361" target="_blank">BuildChannelListener(TChannel)(BindingParameterCollection)</a></td><td>
Builds the channel listener on the service that accepts a specified type of channel and that satisfies the features specified by a collection of binding parameters.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/ms405791" target="_blank">Binding</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/ms405443" target="_blank">BuildChannelListener(TChannel)(Uri, Object[])</a></td><td>
Builds the channel listener on the service that accepts a specified type of channel and that satisfies the features specified.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/ms405791" target="_blank">Binding</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/ms405447" target="_blank">BuildChannelListener(TChannel)(Uri, BindingParameterCollection)</a></td><td>
Builds the channel listener on the service that accepts a specified type of channel and that satisfies the features specified.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/ms405791" target="_blank">Binding</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/ms405441" target="_blank">BuildChannelListener(TChannel)(Uri, String, Object[])</a></td><td>
Builds the channel listener on the service that accepts a specified type of channel and that satisfies the features specified.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/ms405791" target="_blank">Binding</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/ms405446" target="_blank">BuildChannelListener(TChannel)(Uri, String, BindingParameterCollection)</a></td><td>
Builds the channel listener on the service that accepts a specified type of channel and that satisfies the features specified.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/ms405791" target="_blank">Binding</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/ms405445" target="_blank">BuildChannelListener(TChannel)(Uri, String, ListenUriMode, Object[])</a></td><td>
Builds the channel listener on the service that accepts a specified type of channel and that satisfies the features specified.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/ms405791" target="_blank">Binding</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/ms405442" target="_blank">BuildChannelListener(TChannel)(Uri, String, ListenUriMode, BindingParameterCollection)</a></td><td>
Builds the channel listener on the service that accepts a specified type of channel and that satisfies the features specified.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/ms405791" target="_blank">Binding</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/ms405450" target="_blank">CanBuildChannelFactory(TChannel)(Object[])</a></td><td>
Returns a value that indicates whether the current binding can build a channel factory stack on the client that satisfies the requirements specified by an object array.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/ms405791" target="_blank">Binding</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/ms405449" target="_blank">CanBuildChannelFactory(TChannel)(BindingParameterCollection)</a></td><td>
Returns a value that indicates whether the current binding can build a channel factory stack on the client that satisfies the collection of binding parameters specified.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/ms405791" target="_blank">Binding</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/ms405452" target="_blank">CanBuildChannelListener(TChannel)(Object[])</a></td><td>
Returns a value that indicates whether the current binding can build a channel listener stack on the service that satisfies the criteria specified in an array of objects.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/ms405791" target="_blank">Binding</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/ms405451" target="_blank">CanBuildChannelListener(TChannel)(BindingParameterCollection)</a></td><td>
Returns a value that indicates whether the current binding can build a channel listener stack on the service that satisfies the collection of binding parameters specified.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/ms405791" target="_blank">Binding</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/bb335476" target="_blank">CreateBindingElements</a></td><td>
Creates an ordered collection of binding elements that are contained in the current binding.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/bb347282" target="_blank">WSHttpContextBinding</a>.)</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/ms585859" target="_blank">CreateMessageSecurity</a></td><td>
Returns the security binding element from the current binding.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/ms586935" target="_blank">WSHttpBinding</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/bsc2ak47" target="_blank">Equals</a></td><td>
Determines whether the specified object is equal to the current object.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/4k87zsw7" target="_blank">Finalize</a></td><td>
Allows an object to try to free resources and perform other cleanup operations before it is reclaimed by garbage collection.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/zdee4b3y" target="_blank">GetHashCode</a></td><td>
Serves as the default hash function.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/ms554364" target="_blank">GetProperty(T)</a></td><td>
Returns a typed object requested, if present, from the appropriate layer in the binding stack.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/ms405791" target="_blank">Binding</a>.)</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/ms585860" target="_blank">GetTransport</a></td><td>
Returns the transport binding element from the current binding.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/ms586935" target="_blank">WSHttpBinding</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/dfwy45w9" target="_blank">GetType</a></td><td>
Gets the <a href="http://msdn2.microsoft.com/en-us/library/42892f65" target="_blank">Type</a> of the current instance.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/57ctke0a" target="_blank">MemberwiseClone</a></td><td>
Creates a shallow copy of the current <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/dd289450" target="_blank">ShouldSerializeName</a></td><td>
Returns whether the name of the binding should be serialized.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/ms405791" target="_blank">Binding</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/dd235358" target="_blank">ShouldSerializeNamespace</a></td><td>
Returns whether the namespace of the binding should be serialized.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/ms405791" target="_blank">Binding</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/dd782864" target="_blank">ShouldSerializeReaderQuotas</a></td><td>
Returns a value that indicates whether the <a href="http://msdn2.microsoft.com/en-us/library/ms586291" target="_blank">ReaderQuotas</a> property has changed from its default value and should be serialized.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/ms586936" target="_blank">WSHttpBindingBase</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/dd992722" target="_blank">ShouldSerializeReliableSession</a></td><td>
Returns a value that indicates whether the <a href="http://msdn2.microsoft.com/en-us/library/ms586292" target="_blank">ReliableSession</a> property has changed from its default value and should be serialized.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/ms586936" target="_blank">WSHttpBindingBase</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/dd990310" target="_blank">ShouldSerializeSecurity</a></td><td>
Returns a value that indicates whether the <a href="http://msdn2.microsoft.com/en-us/library/ms586301" target="_blank">Security</a> property has changed from its default value and should be serialized.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/ms586935" target="_blank">WSHttpBinding</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/dd991138" target="_blank">ShouldSerializeTextEncoding</a></td><td>
Returns a value that indicates whether the <a href="http://msdn2.microsoft.com/en-us/library/ms586298" target="_blank">TextEncoding</a> property has changed from its default value and should be serialized.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/ms586936" target="_blank">WSHttpBindingBase</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/7bxwbwt2" target="_blank">ToString</a></td><td>
Returns a string that represents the current object.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr></table>&nbsp;
<a href="#idmsoapbinding-class">Back to Top</a>

## Fields
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public field](media/pubfield.gif "Public field")![Static member](media/static.gif "Static member")</td><td><a href="F_IdmNet_SoapModels_IdmSoapBinding_DefaultMaxDataSize">DefaultMaxDataSize</a></td><td>
Settled on this size after some initial real-world testing</td></tr></table>&nbsp;
<a href="#idmsoapbinding-class">Back to Top</a>

## See Also


#### Reference
<a href="N_IdmNet_SoapModels">IdmNet.SoapModels Namespace</a><br />