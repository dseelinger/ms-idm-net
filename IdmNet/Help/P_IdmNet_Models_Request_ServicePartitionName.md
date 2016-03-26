# Request.ServicePartitionName Property 
 

Service Partition Name - This attribute identifies the ServicePartitionName assigned to this Request. The Request and its Workflow Instances can only be processed by FIM Service instances that have this ServicePartitionName.

**Namespace:**&nbsp;<a href="N_IdmNet_Models">IdmNet.Models</a><br />**Assembly:**&nbsp;IdmNet (in IdmNet.dll) Version: 1.0.0.0 (1.0.0)

## Syntax

**C#**<br />
``` C#
public string ServicePartitionName { get; set; }
```

**VB**<br />
``` VB
Public Property ServicePartitionName As String
	Get
	Set
```

**C++**<br />
``` C++
public:
property String^ ServicePartitionName {
	String^ get ();
	void set (String^ value);
}
```

**F#**<br />
``` F#
member ServicePartitionName : string with get, set

```


#### Property Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">String</a>

## See Also


#### Reference
<a href="T_IdmNet_Models_Request">Request Class</a><br /><a href="N_IdmNet_Models">IdmNet.Models Namespace</a><br />