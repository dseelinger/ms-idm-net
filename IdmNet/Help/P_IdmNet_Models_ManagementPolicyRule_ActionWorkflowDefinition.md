# ManagementPolicyRule.ActionWorkflowDefinition Property 
 

Action Workflows - These workflows are applied as part of the policy. Read operations do not trigger workflows.

**Namespace:**&nbsp;<a href="N_IdmNet_Models">IdmNet.Models</a><br />**Assembly:**&nbsp;IdmNet (in IdmNet.dll) Version: 1.0.0.0 (1.0.0)

## Syntax

**C#**<br />
``` C#
public List<WorkflowInstance> ActionWorkflowDefinition { get; set; }
```

**VB**<br />
``` VB
Public Property ActionWorkflowDefinition As List(Of WorkflowInstance)
	Get
	Set
```

**C++**<br />
``` C++
public:
property List<WorkflowInstance^>^ ActionWorkflowDefinition {
	List<WorkflowInstance^>^ get ();
	void set (List<WorkflowInstance^>^ value);
}
```

**F#**<br />
``` F#
member ActionWorkflowDefinition : List<WorkflowInstance> with get, set

```


#### Property Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/6sh2ey19" target="_blank">List</a>(<a href="T_IdmNet_Models_WorkflowInstance">WorkflowInstance</a>)

## See Also


#### Reference
<a href="T_IdmNet_Models_ManagementPolicyRule">ManagementPolicyRule Class</a><br /><a href="N_IdmNet_Models">IdmNet.Models Namespace</a><br />