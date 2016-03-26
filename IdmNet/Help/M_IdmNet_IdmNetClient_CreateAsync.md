# IdmNetClient.CreateAsync Method 
 

Create Object/Resource in Identity Manager Service (async await)

**Namespace:**&nbsp;<a href="N_IdmNet">IdmNet</a><br />**Assembly:**&nbsp;IdmNet (in IdmNet.dll) Version: 1.0.0.0 (1.0.0)

## Syntax

**C#**<br />
``` C#
public Task<Message> CreateAsync(
	IdmResource resource
)
```

**VB**<br />
``` VB
Public Function CreateAsync ( 
	resource As IdmResource
) As Task(Of Message)
```

**C++**<br />
``` C++
public:
Task<Message^>^ CreateAsync(
	IdmResource^ resource
)
```

**F#**<br />
``` F#
member CreateAsync : 
        resource : IdmResource -> Task<Message> 

```


#### Parameters
&nbsp;<dl><dt>resource</dt><dd>Type: <a href="T_IdmNet_Models_IdmResource">IdmNet.Models.IdmResource</a><br />Resource to be created</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/dd321424" target="_blank">Task</a>(<a href="http://msdn2.microsoft.com/en-us/library/ms405907" target="_blank">Message</a>)<br />Resource with its newly assigned ObjectID

## See Also


#### Reference
<a href="T_IdmNet_IdmNetClient">IdmNetClient Class</a><br /><a href="N_IdmNet">IdmNet Namespace</a><br />