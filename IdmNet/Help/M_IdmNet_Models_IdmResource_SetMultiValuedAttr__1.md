# IdmResource.SetMultiValuedAttr(*T*) Method 
 

Set the list of complex objects that is backing a multi-valued reference attribute in IdmNet.

**Namespace:**&nbsp;<a href="N_IdmNet_Models">IdmNet.Models</a><br />**Assembly:**&nbsp;IdmNet (in IdmNet.dll) Version: 1.0.0.0 (1.0.0)

## Syntax

**C#**<br />
``` C#
public void SetMultiValuedAttr<T>(
	string attrName,
	out List<T> backingField,
	List<T> values
)
where T : new(), IdmResource

```

**VB**<br />
``` VB
Public Sub SetMultiValuedAttr(Of T As {New, IdmResource}) ( 
	attrName As String,
	<OutAttribute> ByRef backingField As List(Of T),
	values As List(Of T)
)
```

**C++**<br />
``` C++
public:
generic<typename T>
where T : gcnew(), IdmResource
void SetMultiValuedAttr(
	String^ attrName, 
	[OutAttribute] List<T>^% backingField, 
	List<T>^ values
)
```

**F#**<br />
``` F#
member SetMultiValuedAttr : 
        attrName : string * 
        backingField : List<'T> byref * 
        values : List<'T> -> unit  when 'T : new() and IdmResource

```


#### Parameters
&nbsp;<dl><dt>attrName</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />Name of the multi-valued attribute to set</dd><dt>backingField</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/6sh2ey19" target="_blank">System.Collections.Generic.List</a>(*T*)<br />List of objects that will contain the representations for the references</dd><dt>values</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/6sh2ey19" target="_blank">System.Collections.Generic.List</a>(*T*)<br />List of objects that contains the representations for the references</dd></dl>

#### Type Parameters
&nbsp;<dl><dt>T</dt><dd>Complex Object's type, such as "Person" for a Group object's Owners</dd></dl>

## See Also


#### Reference
<a href="T_IdmNet_Models_IdmResource">IdmResource Class</a><br /><a href="N_IdmNet_Models">IdmNet.Models Namespace</a><br />