# IdmResource.Attributes Property 
 

List of attributes for which we have data for this particular object. Note that due to performance reasons, there may be other attributes and values in the identity manager service, but they may not have been retrieved yet.

**Namespace:**&nbsp;<a href="N_IdmNet_Models">IdmNet.Models</a><br />**Assembly:**&nbsp;IdmNet (in IdmNet.dll) Version: 1.0.0.0 (1.0.0)

## Syntax

**C#**<br />
``` C#
public List<IdmAttribute> Attributes { get; set; }
```

**VB**<br />
``` VB
Public Property Attributes As List(Of IdmAttribute)
	Get
	Set
```

**C++**<br />
``` C++
public:
property List<IdmAttribute^>^ Attributes {
	List<IdmAttribute^>^ get ();
	void set (List<IdmAttribute^>^ value);
}
```

**F#**<br />
``` F#
member Attributes : List<IdmAttribute> with get, set

```


#### Property Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/6sh2ey19" target="_blank">List</a>(<a href="T_IdmNet_Models_IdmAttribute">IdmAttribute</a>)

## See Also


#### Reference
<a href="T_IdmNet_Models_IdmResource">IdmResource Class</a><br /><a href="N_IdmNet_Models">IdmNet.Models Namespace</a><br />