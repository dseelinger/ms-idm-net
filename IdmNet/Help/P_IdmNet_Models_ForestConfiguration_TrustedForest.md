# ForestConfiguration.TrustedForest Property 
 

Trusted Forest - The list of Forest resources which are trusted by this Forest and for which an Incoming Trust for this Forest has been configured in Active Directory.

**Namespace:**&nbsp;<a href="N_IdmNet_Models">IdmNet.Models</a><br />**Assembly:**&nbsp;IdmNet (in IdmNet.dll) Version: 1.0.0.0 (1.0.0)

## Syntax

**C#**<br />
``` C#
public List<ForestConfiguration> TrustedForest { get; set; }
```

**VB**<br />
``` VB
Public Property TrustedForest As List(Of ForestConfiguration)
	Get
	Set
```

**C++**<br />
``` C++
public:
property List<ForestConfiguration^>^ TrustedForest {
	List<ForestConfiguration^>^ get ();
	void set (List<ForestConfiguration^>^ value);
}
```

**F#**<br />
``` F#
member TrustedForest : List<ForestConfiguration> with get, set

```


#### Property Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/6sh2ey19" target="_blank">List</a>(<a href="T_IdmNet_Models_ForestConfiguration">ForestConfiguration</a>)

## See Also


#### Reference
<a href="T_IdmNet_Models_ForestConfiguration">ForestConfiguration Class</a><br /><a href="N_IdmNet_Models">IdmNet.Models Namespace</a><br />