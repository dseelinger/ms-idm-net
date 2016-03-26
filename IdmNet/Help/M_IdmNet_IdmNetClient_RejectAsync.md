# IdmNetClient.RejectAsync Method 
 

Reject a particular request

**Namespace:**&nbsp;<a href="N_IdmNet">IdmNet</a><br />**Assembly:**&nbsp;IdmNet (in IdmNet.dll) Version: 1.0.0.0 (1.0.0)

## Syntax

**C#**<br />
``` C#
public Task<Message> RejectAsync(
	Approval pendingApproval
)
```

**VB**<br />
``` VB
Public Function RejectAsync ( 
	pendingApproval As Approval
) As Task(Of Message)
```

**C++**<br />
``` C++
public:
Task<Message^>^ RejectAsync(
	Approval^ pendingApproval
)
```

**F#**<br />
``` F#
member RejectAsync : 
        pendingApproval : Approval -> Task<Message> 

```


#### Parameters
&nbsp;<dl><dt>pendingApproval</dt><dd>Type: <a href="T_IdmNet_Models_Approval">IdmNet.Models.Approval</a><br />A pending approval object - EndpointAddress and WorkflowInstance must be populated.</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/dd321424" target="_blank">Task</a>(<a href="http://msdn2.microsoft.com/en-us/library/ms405907" target="_blank">Message</a>)<br />SOAP Message from the resulting Approval Response created.

## See Also


#### Reference
<a href="T_IdmNet_IdmNetClient">IdmNetClient Class</a><br /><a href="N_IdmNet">IdmNet Namespace</a><br />