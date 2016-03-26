# IdmAttribute.ToBinary Method 
 

Convert the Value (string) of an attribute to a binary value (byte[]), if the attribute is defined as binary in Identity Manager

**Namespace:**&nbsp;<a href="N_IdmNet_Models">IdmNet.Models</a><br />**Assembly:**&nbsp;IdmNet (in IdmNet.dll) Version: 1.0.0.0 (1.0.0)

## Syntax

**C#**<br />
``` C#
public byte[] ToBinary()
```

**VB**<br />
``` VB
Public Function ToBinary As Byte()
```

**C++**<br />
``` C++
public:
array<unsigned char>^ ToBinary()
```

**F#**<br />
``` F#
member ToBinary : unit -> byte[] 

```


#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/yyb1w04y" target="_blank">Byte</a>[]<br />Single (or first) binary value of the attribute or null if the attribute is "not present" in the Identity Manager resource

## See Also


#### Reference
<a href="T_IdmNet_Models_IdmAttribute">IdmAttribute Class</a><br /><a href="N_IdmNet_Models">IdmNet.Models Namespace</a><br />