# IdmResource.ExpirationTime Property 
 

(aka Expiration Time) The date and time when the resource expires. The appropriate Management Policy Rule will delete the resource when the current date and time is later than the date and time specified in this attribute.

**Namespace:**&nbsp;<a href="N_IdmNet_Models">IdmNet.Models</a><br />**Assembly:**&nbsp;IdmNet (in IdmNet.dll) Version: 1.0.0.0 (1.0.0)

## Syntax

**C#**<br />
``` C#
public Nullable<DateTime> ExpirationTime { get; set; }
```

**VB**<br />
``` VB
Public Property ExpirationTime As Nullable(Of DateTime)
	Get
	Set
```

**C++**<br />
``` C++
public:
property Nullable<DateTime> ExpirationTime {
	Nullable<DateTime> get ();
	void set (Nullable<DateTime> value);
}
```

**F#**<br />
``` F#
member ExpirationTime : Nullable<DateTime> with get, set

```


#### Property Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/b3h38hb0" target="_blank">Nullable</a>(<a href="http://msdn2.microsoft.com/en-us/library/03ybds8y" target="_blank">DateTime</a>)

## See Also


#### Reference
<a href="T_IdmNet_Models_IdmResource">IdmResource Class</a><br /><a href="N_IdmNet_Models">IdmNet.Models Namespace</a><br />