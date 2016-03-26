# ApprovalResponseSoapModel Constructor (String, String, String)
 

Primary CTOR

**Namespace:**&nbsp;<a href="N_IdmNet_SoapModels">IdmNet.SoapModels</a><br />**Assembly:**&nbsp;IdmNet (in IdmNet.dll) Version: 1.0.0.0 (1.0.0)

## Syntax

**C#**<br />
``` C#
public ApprovalResponseSoapModel(
	string approvalObjectId,
	string decision,
	string reason
)
```

**VB**<br />
``` VB
Public Sub New ( 
	approvalObjectId As String,
	decision As String,
	reason As String
)
```

**C++**<br />
``` C++
public:
ApprovalResponseSoapModel(
	String^ approvalObjectId, 
	String^ decision, 
	String^ reason
)
```

**F#**<br />
``` F#
new : 
        approvalObjectId : string * 
        decision : string * 
        reason : string -> ApprovalResponseSoapModel
```


#### Parameters
&nbsp;<dl><dt>approvalObjectId</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />Approval ObjectID (without the "urn:uuid:")</dd><dt>decision</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />Can only be "Approved" or "Rejected"</dd><dt>reason</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />Optional reason for approval or rejection</dd></dl>

## See Also


#### Reference
<a href="T_IdmNet_SoapModels_ApprovalResponseSoapModel">ApprovalResponseSoapModel Class</a><br /><a href="Overload_IdmNet_SoapModels_ApprovalResponseSoapModel__ctor">ApprovalResponseSoapModel Overload</a><br /><a href="N_IdmNet_SoapModels">IdmNet.SoapModels Namespace</a><br />