# IdmAttribute.ToBool Method 
 

Convert the Value (string) of an attribute to boolean, if the attribute is defined as a boolean in Identity Manager

**Namespace:**&nbsp;<a href="N_IdmNet_Models">IdmNet.Models</a><br />**Assembly:**&nbsp;IdmNet (in IdmNet.dll) Version: 1.0.0.0 (1.0.0)

## Syntax

**C#**<br />
``` C#
public Nullable<bool> ToBool()
```

**VB**<br />
``` VB
Public Function ToBool As Nullable(Of Boolean)
```

**C++**<br />
``` C++
public:
Nullable<bool> ToBool()
```

**F#**<br />
``` F#
member ToBool : unit -> Nullable<bool> 

```


#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/b3h38hb0" target="_blank">Nullable</a>(<a href="http://msdn2.microsoft.com/en-us/library/a28wyd50" target="_blank">Boolean</a>)<br />Boolean value of the attribute or null if the attribute is "not present" in the Identity Manager resource (and booleans may not be multi-valued attributes in Identity Manager)

## See Also


#### Reference
<a href="T_IdmNet_Models_IdmAttribute">IdmAttribute Class</a><br /><a href="N_IdmNet_Models">IdmNet.Models Namespace</a><br />