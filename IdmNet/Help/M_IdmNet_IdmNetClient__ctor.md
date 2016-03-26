# IdmNetClient Constructor 
 

Primary constructor for the IdmNetClient. Though this is public and can be called, the normal thing to do is to use IdmNetClientFactory.BuildClient(). This is available in case you want to build the client based on different assumptions made by the factory builder. For example, if you wanted to use a different client credentials mechanism, WCF binding, or endpoints

**Namespace:**&nbsp;<a href="N_IdmNet">IdmNet</a><br />**Assembly:**&nbsp;IdmNet (in IdmNet.dll) Version: 1.0.0.0 (1.0.0)

## Syntax

**C#**<br />
``` C#
public IdmNetClient(
	SearchClient searchClient,
	ResourceFactoryClient factoryClient,
	ResourceClient resourceClient
)
```

**VB**<br />
``` VB
Public Sub New ( 
	searchClient As SearchClient,
	factoryClient As ResourceFactoryClient,
	resourceClient As ResourceClient
)
```

**C++**<br />
``` C++
public:
IdmNetClient(
	SearchClient^ searchClient, 
	ResourceFactoryClient^ factoryClient, 
	ResourceClient^ resourceClient
)
```

**F#**<br />
``` F#
new : 
        searchClient : SearchClient * 
        factoryClient : ResourceFactoryClient * 
        resourceClient : ResourceClient -> IdmNetClient
```


#### Parameters
&nbsp;<dl><dt>searchClient</dt><dd>Type: SearchClient<br />This is the SOAP client used to connect to Identity Manager for search functionality (WS-Enumeration - Enumerate and Pull operations)</dd><dt>factoryClient</dt><dd>Type: ResourceFactoryClient<br />This is the SOAP client used to create new objects/resources in Identity Manager (WS-Transfer - Create operation)</dd><dt>resourceClient</dt><dd>Type: ResourceClient<br />This is the SOAP client used to modify existing objects/resources in Identity Manager</dd></dl>

## See Also


#### Reference
<a href="T_IdmNet_IdmNetClient">IdmNetClient Class</a><br /><a href="N_IdmNet">IdmNet Namespace</a><br />