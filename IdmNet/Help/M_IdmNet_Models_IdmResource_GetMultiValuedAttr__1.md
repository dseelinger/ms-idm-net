# IdmResource.GetMultiValuedAttr(*T*) Method 
 

Get the list of complex objects that is backing a multi-valued reference attribute in IdmNet.

**Namespace:**&nbsp;<a href="N_IdmNet_Models">IdmNet.Models</a><br />**Assembly:**&nbsp;IdmNet (in IdmNet.dll) Version: 1.0.0.0 (1.0.0)

## Syntax

**C#**<br />
``` C#
public List<T> GetMultiValuedAttr<T>(
	string attrName,
	List<T> backingField
)
where T : new(), IdmResource

```

**VB**<br />
``` VB
Public Function GetMultiValuedAttr(Of T As {New, IdmResource}) ( 
	attrName As String,
	backingField As List(Of T)
) As List(Of T)
```

**C++**<br />
``` C++
public:
generic<typename T>
where T : gcnew(), IdmResourceList<T>^ GetMultiValuedAttr(
	String^ attrName, 
	List<T>^ backingField
)
```

**F#**<br />
``` F#
member GetMultiValuedAttr : 
        attrName : string * 
        backingField : List<'T> -> List<'T>  when 'T : new() and IdmResource

```


#### Parameters
&nbsp;<dl><dt>attrName</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />Name of the multi-valued attribute to retrieve</dd><dt>backingField</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/6sh2ey19" target="_blank">System.Collections.Generic.List</a>(*T*)<br />List of objects that contains the available representations for the references</dd></dl>

#### Type Parameters
&nbsp;<dl><dt>T</dt><dd>Complex Object's type, such as "Person" for a Group object's Owners</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/6sh2ey19" target="_blank">List</a>(*T*)<br />Strongly-typed list of values for the Attribute

## See Also


#### Reference
<a href="T_IdmNet_Models_IdmResource">IdmResource Class</a><br /><a href="N_IdmNet_Models">IdmNet.Models Namespace</a><br />