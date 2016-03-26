# IdmNetClient.GetPagedResultsAsync Method (Int32, PagingContext)
 

Pull resources from Identity Manager

**Namespace:**&nbsp;<a href="N_IdmNet">IdmNet</a><br />**Assembly:**&nbsp;IdmNet (in IdmNet.dll) Version: 1.0.0.0 (1.0.0)

## Syntax

**C#**<br />
``` C#
public Task<PagedSearchResults> GetPagedResultsAsync(
	int pageSize,
	PagingContext pagingContext
)
```

**VB**<br />
``` VB
Public Function GetPagedResultsAsync ( 
	pageSize As Integer,
	pagingContext As PagingContext
) As Task(Of PagedSearchResults)
```

**C++**<br />
``` C++
public:
Task<PagedSearchResults^>^ GetPagedResultsAsync(
	int pageSize, 
	PagingContext^ pagingContext
)
```

**F#**<br />
``` F#
member GetPagedResultsAsync : 
        pageSize : int * 
        pagingContext : PagingContext -> Task<PagedSearchResults> 

```


#### Parameters
&nbsp;<dl><dt>pageSize</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/td2s409d" target="_blank">System.Int32</a><br />Maximum number of records to return</dd><dt>pagingContext</dt><dd>Type: <a href="T_IdmNet_SoapModels_PagingContext">IdmNet.SoapModels.PagingContext</a><br />Information regarding which records to pull</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/dd321424" target="_blank">Task</a>(<a href="T_IdmNet_SoapModels_PagedSearchResults">PagedSearchResults</a>)<br />Paged search results

## Exceptions
&nbsp;<table><tr><th>Exception</th><th>Condition</th></tr><tr><td><a href="T_IdmNet_SoapFaultException">SoapFaultException</a></td><td /></tr></table>

## See Also


#### Reference
<a href="T_IdmNet_IdmNetClient">IdmNetClient Class</a><br /><a href="Overload_IdmNet_IdmNetClient_GetPagedResultsAsync">GetPagedResultsAsync Overload</a><br /><a href="N_IdmNet">IdmNet Namespace</a><br />