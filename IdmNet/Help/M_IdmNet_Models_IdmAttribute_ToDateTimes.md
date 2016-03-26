# IdmAttribute.ToDateTimes Method 
 

Convert the Values (strings) of an multi-valued attribute to DateTime, if the attribute is defined as a DateTime in Identity Manager

**Namespace:**&nbsp;<a href="N_IdmNet_Models">IdmNet.Models</a><br />**Assembly:**&nbsp;IdmNet (in IdmNet.dll) Version: 1.0.0.0 (1.0.0)

## Syntax

**C#**<br />
``` C#
public List<DateTime> ToDateTimes()
```

**VB**<br />
``` VB
Public Function ToDateTimes As List(Of DateTime)
```

**C++**<br />
``` C++
public:
List<DateTime>^ ToDateTimes()
```

**F#**<br />
``` F#
member ToDateTimes : unit -> List<DateTime> 

```


#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/6sh2ey19" target="_blank">List</a>(<a href="http://msdn2.microsoft.com/en-us/library/03ybds8y" target="_blank">DateTime</a>)<br />List of DateTime values of the attribute or null if the attribute is "not present" in the Identity Manager resource

## See Also


#### Reference
<a href="T_IdmNet_Models_IdmAttribute">IdmAttribute Class</a><br /><a href="N_IdmNet_Models">IdmNet.Models Namespace</a><br />