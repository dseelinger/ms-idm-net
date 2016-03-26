# IdmNetClient.ApproveOrRejectAsync Method 
 

Approve or reject a particular request

**Namespace:**&nbsp;<a href="N_IdmNet">IdmNet</a><br />**Assembly:**&nbsp;IdmNet (in IdmNet.dll) Version: 1.0.0.0 (1.0.0)

## Syntax

**C#**<br />
``` C#
public Task<Message> ApproveOrRejectAsync(
	Approval pendingApproval,
	string reason,
	bool approve
)
```

**VB**<br />
``` VB
Public Function ApproveOrRejectAsync ( 
	pendingApproval As Approval,
	reason As String,
	approve As Boolean
) As Task(Of Message)
```

**C++**<br />
``` C++
public:
Task<Message^>^ ApproveOrRejectAsync(
	Approval^ pendingApproval, 
	String^ reason, 
	bool approve
)
```

**F#**<br />
``` F#
member ApproveOrRejectAsync : 
        pendingApproval : Approval * 
        reason : string * 
        approve : bool -> Task<Message> 

```


#### Parameters
&nbsp;<dl><dt>pendingApproval</dt><dd>Type: <a href="T_IdmNet_Models_Approval">IdmNet.Models.Approval</a><br />A pending approval object - EndpointAddress and WorkflowInstance must be populated.</dd><dt>reason</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />\[Missing <param name="reason"/> documentation for "M:IdmNet.IdmNetClient.ApproveOrRejectAsync(IdmNet.Models.Approval,System.String,System.Boolean)"\]</dd><dt>approve</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/a28wyd50" target="_blank">System.Boolean</a><br />If true, approve the request, otherwise reject</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/dd321424" target="_blank">Task</a>(<a href="http://msdn2.microsoft.com/en-us/library/ms405907" target="_blank">Message</a>)<br />SOAP Message from the resulting Approval Response created.

## See Also


#### Reference
<a href="T_IdmNet_IdmNetClient">IdmNetClient Class</a><br /><a href="N_IdmNet">IdmNet Namespace</a><br />