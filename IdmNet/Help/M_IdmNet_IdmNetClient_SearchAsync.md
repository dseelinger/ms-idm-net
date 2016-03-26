# IdmNetClient.SearchAsync Method 
 

Search the Identity Manager (async await)

**Namespace:**&nbsp;<a href="N_IdmNet">IdmNet</a><br />**Assembly:**&nbsp;IdmNet (in IdmNet.dll) Version: 1.0.0.0 (1.0.0)

## Syntax

**C#**<br />
``` C#
public Task<IEnumerable<IdmResource>> SearchAsync(
	SearchCriteria criteria,
	int pageSize = 50
)
```

**VB**<br />
``` VB
Public Function SearchAsync ( 
	criteria As SearchCriteria,
	Optional pageSize As Integer = 50
) As Task(Of IEnumerable(Of IdmResource))
```

**C++**<br />
``` C++
public:
Task<IEnumerable<IdmResource^>^>^ SearchAsync(
	SearchCriteria^ criteria, 
	int pageSize = 50
)
```

**F#**<br />
``` F#
member SearchAsync : 
        criteria : SearchCriteria * 
        ?pageSize : int 
(* Defaults:
        let _pageSize = defaultArg pageSize 50
*)
-> Task<IEnumerable<IdmResource>> 

```


#### Parameters
&nbsp;<dl><dt>criteria</dt><dd>Type: <a href="T_IdmNet_SoapModels_SearchCriteria">IdmNet.SoapModels.SearchCriteria</a><br />\[Missing <param name="criteria"/> documentation for "M:IdmNet.IdmNetClient.SearchAsync(IdmNet.SoapModels.SearchCriteria,System.Int32)"\]</dd><dt>pageSize (Optional)</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/td2s409d" target="_blank">System.Int32</a><br />\[Missing <param name="pageSize"/> documentation for "M:IdmNet.IdmNetClient.SearchAsync(IdmNet.SoapModels.SearchCriteria,System.Int32)"\]</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/dd321424" target="_blank">Task</a>(<a href="http://msdn2.microsoft.com/en-us/library/9eekhta0" target="_blank">IEnumerable</a>(<a href="T_IdmNet_Models_IdmResource">IdmResource</a>))<br />\[Missing <returns> documentation for "M:IdmNet.IdmNetClient.SearchAsync(IdmNet.SoapModels.SearchCriteria,System.Int32)"\]

## See Also


#### Reference
<a href="T_IdmNet_IdmNetClient">IdmNetClient Class</a><br /><a href="N_IdmNet">IdmNet Namespace</a><br />