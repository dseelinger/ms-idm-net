# IdmNetClient.GetResourceReferenceProperty Method 
 

Returns the ResourceReferenceProperty (eg. Approval ObjectID) associated with a particular message returned from an create/update-type operation

**Namespace:**&nbsp;<a href="N_IdmNet">IdmNet</a><br />**Assembly:**&nbsp;IdmNet (in IdmNet.dll) Version: 1.0.0.0 (1.0.0)

## Syntax

**C#**<br />
``` C#
public string GetResourceReferenceProperty(
	string soapMessageString
)
```

**VB**<br />
``` VB
Public Function GetResourceReferenceProperty ( 
	soapMessageString As String
) As String
```

**C++**<br />
``` C++
public:
String^ GetResourceReferenceProperty(
	String^ soapMessageString
)
```

**F#**<br />
``` F#
member GetResourceReferenceProperty : 
        soapMessageString : string -> string 

```


#### Parameters
&nbsp;<dl><dt>soapMessageString</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />The SOAP message in a string format (msg.ToString())</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">String</a><br />The ObjectID of the associated resource/Approval, otherwise NULL

## Exceptions
&nbsp;<table><tr><th>Exception</th><th>Condition</th></tr><tr><td><a href="http://msdn2.microsoft.com/en-us/library/6byb74h9" target="_blank">NotImplementedException</a></td><td /></tr></table>

## See Also


#### Reference
<a href="T_IdmNet_IdmNetClient">IdmNetClient Class</a><br /><a href="N_IdmNet">IdmNet Namespace</a><br />