# IdmNetClient.DeleteAsync Method 
 

Delete an object in the Identity Manager service (async await)

**Namespace:**&nbsp;<a href="N_IdmNet">IdmNet</a><br />**Assembly:**&nbsp;IdmNet (in IdmNet.dll) Version: 1.0.0.0 (1.0.0)

## Syntax

**C#**<br />
``` C#
public Task<Message> DeleteAsync(
	string objectID
)
```

**VB**<br />
``` VB
Public Function DeleteAsync ( 
	objectID As String
) As Task(Of Message)
```

**C++**<br />
``` C++
public:
Task<Message^>^ DeleteAsync(
	String^ objectID
)
```

**F#**<br />
``` F#
member DeleteAsync : 
        objectID : string -> Task<Message> 

```


#### Parameters
&nbsp;<dl><dt>objectID</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />Resource ID for the object to be deleted</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/dd321424" target="_blank">Task</a>(<a href="http://msdn2.microsoft.com/en-us/library/ms405907" target="_blank">Message</a>)<br />\[Missing <returns> documentation for "M:IdmNet.IdmNetClient.DeleteAsync(System.String)"\]

## See Also


#### Reference
<a href="T_IdmNet_IdmNetClient">IdmNetClient Class</a><br /><a href="N_IdmNet">IdmNet Namespace</a><br />