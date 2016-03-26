# IdmNetClient.ChangeMultipleAttrbutes Method 
 

Make multiple changes to a particular Identity Manager service object/resource (async await)

**Namespace:**&nbsp;<a href="N_IdmNet">IdmNet</a><br />**Assembly:**&nbsp;IdmNet (in IdmNet.dll) Version: 1.0.0.0 (1.0.0)

## Syntax

**C#**<br />
``` C#
public Task<Message> ChangeMultipleAttrbutes(
	string objectID,
	Change[] changes
)
```

**VB**<br />
``` VB
Public Function ChangeMultipleAttrbutes ( 
	objectID As String,
	changes As Change()
) As Task(Of Message)
```

**C++**<br />
``` C++
public:
Task<Message^>^ ChangeMultipleAttrbutes(
	String^ objectID, 
	array<Change^>^ changes
)
```

**F#**<br />
``` F#
member ChangeMultipleAttrbutes : 
        objectID : string * 
        changes : Change[] -> Task<Message> 

```


#### Parameters
&nbsp;<dl><dt>objectID</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />Resource ID for the object containing the attributes to be modified</dd><dt>changes</dt><dd>Type: <a href="T_IdmNet_SoapModels_Change">IdmNet.SoapModels.Change</a>[]<br />Set of changes (Multi-valued "Adds/Removes and Single-valued "Replaces" to be made for the single object</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/dd321424" target="_blank">Task</a>(<a href="http://msdn2.microsoft.com/en-us/library/ms405907" target="_blank">Message</a>)<br />Task (async/await) of the asynchronous operation

## See Also


#### Reference
<a href="T_IdmNet_IdmNetClient">IdmNetClient Class</a><br /><a href="N_IdmNet">IdmNet Namespace</a><br />