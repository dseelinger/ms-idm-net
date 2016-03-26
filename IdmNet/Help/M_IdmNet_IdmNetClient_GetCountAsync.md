# IdmNetClient.GetCountAsync Method 
 

Get the number of Identity Manager resources that match the given XPath Filter.

**Namespace:**&nbsp;<a href="N_IdmNet">IdmNet</a><br />**Assembly:**&nbsp;IdmNet (in IdmNet.dll) Version: 1.0.0.0 (1.0.0)

## Syntax

**C#**<br />
``` C#
public Task<int> GetCountAsync(
	string filter
)
```

**VB**<br />
``` VB
Public Function GetCountAsync ( 
	filter As String
) As Task(Of Integer)
```

**C++**<br />
``` C++
public:
Task<int>^ GetCountAsync(
	String^ filter
)
```

**F#**<br />
``` F#
member GetCountAsync : 
        filter : string -> Task<int> 

```


#### Parameters
&nbsp;<dl><dt>filter</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />Search filter</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/dd321424" target="_blank">Task</a>(<a href="http://msdn2.microsoft.com/en-us/library/td2s409d" target="_blank">Int32</a>)<br />Number of matching resources

## See Also


#### Reference
<a href="T_IdmNet_IdmNetClient">IdmNetClient Class</a><br /><a href="N_IdmNet">IdmNet Namespace</a><br />