# IdmNetUtils.EnsureDefaultSelectionPresent Method 
 

Ensures that a list of selected attributes always contains the detault attributes of ObjectID and ObjectType

**Namespace:**&nbsp;<a href="N_IdmNet">IdmNet</a><br />**Assembly:**&nbsp;IdmNet (in IdmNet.dll) Version: 1.0.0.0 (1.0.0)

## Syntax

**C#**<br />
``` C#
public static List<string> EnsureDefaultSelectionPresent(
	List<string> attributeList
)
```

**VB**<br />
``` VB
Public Shared Function EnsureDefaultSelectionPresent ( 
	attributeList As List(Of String)
) As List(Of String)
```

**C++**<br />
``` C++
public:
static List<String^>^ EnsureDefaultSelectionPresent(
	List<String^>^ attributeList
)
```

**F#**<br />
``` F#
static member EnsureDefaultSelectionPresent : 
        attributeList : List<string> -> List<string> 

```


#### Parameters
&nbsp;<dl><dt>attributeList</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/6sh2ey19" target="_blank">System.Collections.Generic.List</a>(<a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">String</a>)<br />List of additional attributes (if any) to add</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/6sh2ey19" target="_blank">List</a>(<a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">String</a>)<br />A list that contains both the default and additional attributes

## See Also


#### Reference
<a href="T_IdmNet_IdmNetUtils">IdmNetUtils Class</a><br /><a href="N_IdmNet">IdmNet Namespace</a><br />