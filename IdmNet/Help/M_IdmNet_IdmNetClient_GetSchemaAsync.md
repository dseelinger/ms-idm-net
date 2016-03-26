# IdmNetClient.GetSchemaAsync Method 
 

Get the Schema associated with a particular object type

**Namespace:**&nbsp;<a href="N_IdmNet">IdmNet</a><br />**Assembly:**&nbsp;IdmNet (in IdmNet.dll) Version: 1.0.0.0 (1.0.0)

## Syntax

**C#**<br />
``` C#
public Task<Schema> GetSchemaAsync(
	string objectType
)
```

**VB**<br />
``` VB
Public Function GetSchemaAsync ( 
	objectType As String
) As Task(Of Schema)
```

**C++**<br />
``` C++
public:
Task<Schema^>^ GetSchemaAsync(
	String^ objectType
)
```

**F#**<br />
``` F#
member GetSchemaAsync : 
        objectType : string -> Task<Schema> 

```


#### Parameters
&nbsp;<dl><dt>objectType</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />Name of the object for which the schema should be retrieved</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/dd321424" target="_blank">Task</a>(<a href="T_IdmNet_Models_Schema">Schema</a>)<br />A fully populated ObjectTypeDescription object, including bindings for attributes

## See Also


#### Reference
<a href="T_IdmNet_IdmNetClient">IdmNetClient Class</a><br /><a href="N_IdmNet">IdmNet Namespace</a><br />