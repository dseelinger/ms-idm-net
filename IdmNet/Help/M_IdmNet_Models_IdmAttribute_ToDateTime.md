# IdmAttribute.ToDateTime Method 
 

Convert the Value (string) of an attribute to DateTime, if the attribute is defined as a DateTime object in Identity Manager

**Namespace:**&nbsp;<a href="N_IdmNet_Models">IdmNet.Models</a><br />**Assembly:**&nbsp;IdmNet (in IdmNet.dll) Version: 1.0.0.0 (1.0.0)

## Syntax

**C#**<br />
``` C#
public Nullable<DateTime> ToDateTime()
```

**VB**<br />
``` VB
Public Function ToDateTime As Nullable(Of DateTime)
```

**C++**<br />
``` C++
public:
Nullable<DateTime> ToDateTime()
```

**F#**<br />
``` F#
member ToDateTime : unit -> Nullable<DateTime> 

```


#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/b3h38hb0" target="_blank">Nullable</a>(<a href="http://msdn2.microsoft.com/en-us/library/03ybds8y" target="_blank">DateTime</a>)<br />Single (or first) DateTime value of the attribute or null if the attribute is "not present" in the Identity Manager resource

## See Also


#### Reference
<a href="T_IdmNet_Models_IdmAttribute">IdmAttribute Class</a><br /><a href="N_IdmNet_Models">IdmNet.Models Namespace</a><br />