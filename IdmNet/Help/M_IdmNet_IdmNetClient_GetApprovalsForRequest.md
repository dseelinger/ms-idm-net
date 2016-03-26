# IdmNetClient.GetApprovalsForRequest Method 
 

Returns the Approval object for a given request

**Namespace:**&nbsp;<a href="N_IdmNet">IdmNet</a><br />**Assembly:**&nbsp;IdmNet (in IdmNet.dll) Version: 1.0.0.0 (1.0.0)

## Syntax

**C#**<br />
``` C#
public Task<List<Approval>> GetApprovalsForRequest(
	string requestObjectId
)
```

**VB**<br />
``` VB
Public Function GetApprovalsForRequest ( 
	requestObjectId As String
) As Task(Of List(Of Approval))
```

**C++**<br />
``` C++
public:
Task<List<Approval^>^>^ GetApprovalsForRequest(
	String^ requestObjectId
)
```

**F#**<br />
``` F#
member GetApprovalsForRequest : 
        requestObjectId : string -> Task<List<Approval>> 

```


#### Parameters
&nbsp;<dl><dt>requestObjectId</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />ObjectID for a given request that should have an approval associated with it.</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/dd321424" target="_blank">Task</a>(<a href="http://msdn2.microsoft.com/en-us/library/6sh2ey19" target="_blank">List</a>(<a href="T_IdmNet_Models_Approval">Approval</a>))<br />An Approval object with both "EndpointAddress" and "WorkflowInstance" populated, or NULL if no Approvals exist for a given request

## See Also


#### Reference
<a href="T_IdmNet_IdmNetClient">IdmNetClient Class</a><br /><a href="N_IdmNet">IdmNet Namespace</a><br />