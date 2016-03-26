# IdmNetClient.GetNewObjectId Method 
 

Get the ObjectID for a newly created resource from the response message

**Namespace:**&nbsp;<a href="N_IdmNet">IdmNet</a><br />**Assembly:**&nbsp;IdmNet (in IdmNet.dll) Version: 1.0.0.0 (1.0.0)

## Syntax

**C#**<br />
``` C#
public string GetNewObjectId(
	Message resourceCreationResponseMessage
)
```

**VB**<br />
``` VB
Public Function GetNewObjectId ( 
	resourceCreationResponseMessage As Message
) As String
```

**C++**<br />
``` C++
public:
String^ GetNewObjectId(
	Message^ resourceCreationResponseMessage
)
```

**F#**<br />
``` F#
member GetNewObjectId : 
        resourceCreationResponseMessage : Message -> string 

```


#### Parameters
&nbsp;<dl><dt>resourceCreationResponseMessage</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/ms405907" target="_blank">System.ServiceModel.Channels.Message</a><br />Response message from the CreateAsync method</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">String</a><br />New object id

## See Also


#### Reference
<a href="T_IdmNet_IdmNetClient">IdmNetClient Class</a><br /><a href="N_IdmNet">IdmNet Namespace</a><br />