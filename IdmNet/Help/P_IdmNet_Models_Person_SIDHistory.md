# Person.SIDHistory Property 
 

SID History - Contains previous SIDs used for the resource if the resource was moved from another domain.

**Namespace:**&nbsp;<a href="N_IdmNet_Models">IdmNet.Models</a><br />**Assembly:**&nbsp;IdmNet (in IdmNet.dll) Version: 1.0.0.0 (1.0.0)

## Syntax

**C#**<br />
``` C#
public List<byte[]> SIDHistory { get; set; }
```

**VB**<br />
``` VB
Public Property SIDHistory As List(Of Byte())
	Get
	Set
```

**C++**<br />
``` C++
public:
property List<array<unsigned char>^>^ SIDHistory {
	List<array<unsigned char>^>^ get ();
	void set (List<array<unsigned char>^>^ value);
}
```

**F#**<br />
``` F#
member SIDHistory : List<byte[]> with get, set

```


#### Property Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/6sh2ey19" target="_blank">List</a>(<a href="http://msdn2.microsoft.com/en-us/library/yyb1w04y" target="_blank">Byte</a>[])

## See Also


#### Reference
<a href="T_IdmNet_Models_Person">Person Class</a><br /><a href="N_IdmNet_Models">IdmNet.Models Namespace</a><br />