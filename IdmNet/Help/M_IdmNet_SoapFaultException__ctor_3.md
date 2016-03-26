# SoapFaultException Constructor (String, Exception)
 

Create a new Soap Fault with a particular message and inner exception

**Namespace:**&nbsp;<a href="N_IdmNet">IdmNet</a><br />**Assembly:**&nbsp;IdmNet (in IdmNet.dll) Version: 1.0.0.0 (1.0.0)

## Syntax

**C#**<br />
``` C#
public SoapFaultException(
	string message,
	Exception inner
)
```

**VB**<br />
``` VB
Public Sub New ( 
	message As String,
	inner As Exception
)
```

**C++**<br />
``` C++
public:
SoapFaultException(
	String^ message, 
	Exception^ inner
)
```

**F#**<br />
``` F#
new : 
        message : string * 
        inner : Exception -> SoapFaultException
```


#### Parameters
&nbsp;<dl><dt>message</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />Message to return to catching methods</dd><dt>inner</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/c18k6c59" target="_blank">System.Exception</a><br />Not normally used - just included for completeness</dd></dl>

## See Also


#### Reference
<a href="T_IdmNet_SoapFaultException">SoapFaultException Class</a><br /><a href="Overload_IdmNet_SoapFaultException__ctor">SoapFaultException Overload</a><br /><a href="N_IdmNet">IdmNet Namespace</a><br />