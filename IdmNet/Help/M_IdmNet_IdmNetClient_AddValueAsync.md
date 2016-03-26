# IdmNetClient.AddValueAsync Method 
 

Add a value to a multi-valued attribute in the Identity Manager service (async await)

**Namespace:**&nbsp;<a href="N_IdmNet">IdmNet</a><br />**Assembly:**&nbsp;IdmNet (in IdmNet.dll) Version: 1.0.0.0 (1.0.0)

## Syntax

**C#**<br />
``` C#
public Task<Message> AddValueAsync(
	string objectID,
	string attrName,
	string attrValue
)
```

**VB**<br />
``` VB
Public Function AddValueAsync ( 
	objectID As String,
	attrName As String,
	attrValue As String
) As Task(Of Message)
```

**C++**<br />
``` C++
public:
Task<Message^>^ AddValueAsync(
	String^ objectID, 
	String^ attrName, 
	String^ attrValue
)
```

**F#**<br />
``` F#
member AddValueAsync : 
        objectID : string * 
        attrName : string * 
        attrValue : string -> Task<Message> 

```


#### Parameters
&nbsp;<dl><dt>objectID</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />Resource ID for the object containing the multi-valued attribute</dd><dt>attrName</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />Name of the Multi-Valued attribute to which a value will be added</dd><dt>attrValue</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />Value to be added to the Multi-Valued attribute</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/dd321424" target="_blank">Task</a>(<a href="http://msdn2.microsoft.com/en-us/library/ms405907" target="_blank">Message</a>)<br />Task (async/await) of the asynchronous operation

## Remarks
While all attributes in an IdmResource are technically multi-valued, this method only works on attributes that are marked as multi-valued in the Identity Manager service.

## See Also


#### Reference
<a href="T_IdmNet_IdmNetClient">IdmNetClient Class</a><br /><a href="N_IdmNet">IdmNet Namespace</a><br />