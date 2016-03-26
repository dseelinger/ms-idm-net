# IdmAttribute.ToIntegers Method 
 

Convert the Values (strings) of an multi-valued attribute to integers, if the attribute is defined as integer in Identity Manager

**Namespace:**&nbsp;<a href="N_IdmNet_Models">IdmNet.Models</a><br />**Assembly:**&nbsp;IdmNet (in IdmNet.dll) Version: 1.0.0.0 (1.0.0)

## Syntax

**C#**<br />
``` C#
public List<int> ToIntegers()
```

**VB**<br />
``` VB
Public Function ToIntegers As List(Of Integer)
```

**C++**<br />
``` C++
public:
List<int>^ ToIntegers()
```

**F#**<br />
``` F#
member ToIntegers : unit -> List<int> 

```


#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/6sh2ey19" target="_blank">List</a>(<a href="http://msdn2.microsoft.com/en-us/library/td2s409d" target="_blank">Int32</a>)<br />List of integer values of the attribute or null if the attribute is "not present" in the Identity Manager resource

## See Also


#### Reference
<a href="T_IdmNet_Models_IdmAttribute">IdmAttribute Class</a><br /><a href="N_IdmNet_Models">IdmNet.Models Namespace</a><br />