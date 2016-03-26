# IdmResource.GetAttr(*T*) Method (String, *T*)
 

Get the complex object that is backing a single-valued reference attribute in IdmNet.

**Namespace:**&nbsp;<a href="N_IdmNet_Models">IdmNet.Models</a><br />**Assembly:**&nbsp;IdmNet (in IdmNet.dll) Version: 1.0.0.0 (1.0.0)

## Syntax

**C#**<br />
``` C#
public T GetAttr<T>(
	string attrName,
	T backingField
)
where T : new(), IdmResource

```

**VB**<br />
``` VB
Public Function GetAttr(Of T As {New, IdmResource}) ( 
	attrName As String,
	backingField As T
) As T
```

**C++**<br />
``` C++
public:
generic<typename T>
where T : gcnew(), IdmResource
T GetAttr(
	String^ attrName, 
	T backingField
)
```

**F#**<br />
``` F#
member GetAttr : 
        attrName : string * 
        backingField : 'T -> 'T  when 'T : new() and IdmResource

```


#### Parameters
&nbsp;<dl><dt>attrName</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />Name of the single-valued attribute to retrieve</dd><dt>backingField</dt><dd>Type: *T*<br />Object that contains the representation for the reference type</dd></dl>

#### Type Parameters
&nbsp;<dl><dt>T</dt><dd>Complex Object's type, such as "Person" for Creator</dd></dl>

#### Return Value
Type: *T*<br />Strongly-typed single value for the Attribute

## See Also


#### Reference
<a href="T_IdmNet_Models_IdmResource">IdmResource Class</a><br /><a href="Overload_IdmNet_Models_IdmResource_GetAttr">GetAttr Overload</a><br /><a href="N_IdmNet_Models">IdmNet.Models Namespace</a><br />