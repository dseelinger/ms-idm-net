# IdmResource.Creator Property 
 

This is a reference attribute that refers to the resource that directly created the resource in the FIM service database. This attribute is assigned its value by the FIM service. It cannot be modified by any user.

**Namespace:**&nbsp;<a href="N_IdmNet_Models">IdmNet.Models</a><br />**Assembly:**&nbsp;IdmNet (in IdmNet.dll) Version: 1.0.0.0 (1.0.0)

## Syntax

**C#**<br />
``` C#
public Person Creator { get; set; }
```

**VB**<br />
``` VB
Public Property Creator As Person
	Get
	Set
```

**C++**<br />
``` C++
public:
property Person^ Creator {
	Person^ get ();
	void set (Person^ value);
}
```

**F#**<br />
``` F#
member Creator : Person with get, set

```


#### Property Value
Type: <a href="T_IdmNet_Models_Person">Person</a>

## See Also


#### Reference
<a href="T_IdmNet_Models_IdmResource">IdmResource Class</a><br /><a href="N_IdmNet_Models">IdmNet.Models Namespace</a><br />