# IdmAttribute.ToInteger Method 
 

Convert the Value (string) of an attribute to a integer value if the attribute is defined as such in Identity Manager

**Namespace:**&nbsp;<a href="N_IdmNet_Models">IdmNet.Models</a><br />**Assembly:**&nbsp;IdmNet (in IdmNet.dll) Version: 1.0.0.0 (1.0.0)

## Syntax

**C#**<br />
``` C#
public Nullable<int> ToInteger()
```

**VB**<br />
``` VB
Public Function ToInteger As Nullable(Of Integer)
```

**C++**<br />
``` C++
public:
Nullable<int> ToInteger()
```

**F#**<br />
``` F#
member ToInteger : unit -> Nullable<int> 

```


#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/b3h38hb0" target="_blank">Nullable</a>(<a href="http://msdn2.microsoft.com/en-us/library/td2s409d" target="_blank">Int32</a>)<br />Single (or first) integer value of the attribute or null if there are no values for the attribute

## See Also


#### Reference
<a href="T_IdmNet_Models_IdmAttribute">IdmAttribute Class</a><br /><a href="N_IdmNet_Models">IdmNet.Models Namespace</a><br />