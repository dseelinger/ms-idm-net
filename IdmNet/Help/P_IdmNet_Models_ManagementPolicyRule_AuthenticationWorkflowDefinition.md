# ManagementPolicyRule.AuthenticationWorkflowDefinition Property 
 

Authentication Workflows - These workflows will not be applied to Requests created by the Built-in Synchronization Account or Forefront Identity Manager Workflow Activities. Read operations do not trigger workflows.

**Namespace:**&nbsp;<a href="N_IdmNet_Models">IdmNet.Models</a><br />**Assembly:**&nbsp;IdmNet (in IdmNet.dll) Version: 1.0.0.0 (1.0.0)

## Syntax

**C#**<br />
``` C#
public List<WorkflowDefinition> AuthenticationWorkflowDefinition { get; set; }
```

**VB**<br />
``` VB
Public Property AuthenticationWorkflowDefinition As List(Of WorkflowDefinition)
	Get
	Set
```

**C++**<br />
``` C++
public:
property List<WorkflowDefinition^>^ AuthenticationWorkflowDefinition {
	List<WorkflowDefinition^>^ get ();
	void set (List<WorkflowDefinition^>^ value);
}
```

**F#**<br />
``` F#
member AuthenticationWorkflowDefinition : List<WorkflowDefinition> with get, set

```


#### Property Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/6sh2ey19" target="_blank">List</a>(<a href="T_IdmNet_Models_WorkflowDefinition">WorkflowDefinition</a>)

## See Also


#### Reference
<a href="T_IdmNet_Models_ManagementPolicyRule">ManagementPolicyRule Class</a><br /><a href="N_IdmNet_Models">IdmNet.Models Namespace</a><br />