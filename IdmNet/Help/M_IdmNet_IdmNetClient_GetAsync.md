# IdmNetClient.GetAsync Method 
 

Get an object by its ID from Identity Manager (async await)

**Namespace:**&nbsp;<a href="N_IdmNet">IdmNet</a><br />**Assembly:**&nbsp;IdmNet (in IdmNet.dll) Version: 1.0.0.0 (1.0.0)

## Syntax

**C#**<br />
``` C#
public Task<IdmResource> GetAsync(
	string objectID,
	List<string> selection
)
```

**VB**<br />
``` VB
Public Function GetAsync ( 
	objectID As String,
	selection As List(Of String)
) As Task(Of IdmResource)
```

**C++**<br />
``` C++
public:
Task<IdmResource^>^ GetAsync(
	String^ objectID, 
	List<String^>^ selection
)
```

**F#**<br />
``` F#
member GetAsync : 
        objectID : string * 
        selection : List<string> -> Task<IdmResource> 

```


#### Parameters
&nbsp;<dl><dt>objectID</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />Resource ID for the object to retrieve</dd><dt>selection</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/6sh2ey19" target="_blank">System.Collections.Generic.List</a>(<a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">String</a>)<br />\[Missing <param name="selection"/> documentation for "M:IdmNet.IdmNetClient.GetAsync(System.String,System.Collections.Generic.List{System.String})"\]</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/dd321424" target="_blank">Task</a>(<a href="T_IdmNet_Models_IdmResource">IdmResource</a>)<br />Resource matching ObjectID

## See Also


#### Reference
<a href="T_IdmNet_IdmNetClient">IdmNetClient Class</a><br /><a href="N_IdmNet">IdmNet Namespace</a><br />