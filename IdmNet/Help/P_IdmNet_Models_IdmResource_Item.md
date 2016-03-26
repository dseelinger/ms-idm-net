# IdmResource.Item Property 
 

Resource Indexer - get's the attribute of the resource object as indexed by name.

**Namespace:**&nbsp;<a href="N_IdmNet_Models">IdmNet.Models</a><br />**Assembly:**&nbsp;IdmNet (in IdmNet.dll) Version: 1.0.0.0 (1.0.0)

## Syntax

**C#**<br />
``` C#
public IdmAttribute this[
	string attributeName
] { get; }
```

**VB**<br />
``` VB
Public ReadOnly Default Property Item ( 
	attributeName As String
) As IdmAttribute
	Get
```

**C++**<br />
``` C++
public:
property IdmAttribute^ default[String^ attributeName] {
	IdmAttribute^ get (String^ attributeName);
}
```

**F#**<br />
``` F#
member Item : IdmAttribute with get

```


#### Parameters
&nbsp;<dl><dt>attributeName</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />Index by attribute name</dd></dl>

#### Property Value
Type: <a href="T_IdmNet_Models_IdmAttribute">IdmAttribute</a>

## See Also


#### Reference
<a href="T_IdmNet_Models_IdmResource">IdmResource Class</a><br /><a href="N_IdmNet_Models">IdmNet.Models Namespace</a><br />