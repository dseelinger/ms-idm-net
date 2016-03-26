# SoapFaultException.GetObjectData Method 
 

For serializing

**Namespace:**&nbsp;<a href="N_IdmNet">IdmNet</a><br />**Assembly:**&nbsp;IdmNet (in IdmNet.dll) Version: 1.0.0.0 (1.0.0)

## Syntax

**C#**<br />
``` C#
public override void GetObjectData(
	SerializationInfo info,
	StreamingContext context
)
```

**VB**<br />
``` VB
Public Overrides Sub GetObjectData ( 
	info As SerializationInfo,
	context As StreamingContext
)
```

**C++**<br />
``` C++
public:
virtual void GetObjectData(
	SerializationInfo^ info, 
	StreamingContext context
) override
```

**F#**<br />
``` F#
abstract GetObjectData : 
        info : SerializationInfo * 
        context : StreamingContext -> unit 
override GetObjectData : 
        info : SerializationInfo * 
        context : StreamingContext -> unit 
```


#### Parameters
&nbsp;<dl><dt>info</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/a9b6042e" target="_blank">System.Runtime.Serialization.SerializationInfo</a><br />For serializing</dd><dt>context</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/t16abws5" target="_blank">System.Runtime.Serialization.StreamingContext</a><br />For serializing</dd></dl>

#### Implements
<a href="http://msdn2.microsoft.com/en-us/library/27cxsdk6" target="_blank">ISerializable.GetObjectData(SerializationInfo, StreamingContext)</a><br /><a href="http://msdn2.microsoft.com/en-us/library/854b9522" target="_blank">_Exception.GetObjectData(SerializationInfo, StreamingContext)</a><br />

## See Also


#### Reference
<a href="T_IdmNet_SoapFaultException">SoapFaultException Class</a><br /><a href="N_IdmNet">IdmNet Namespace</a><br />