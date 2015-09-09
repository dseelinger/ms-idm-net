namespace IdmNet.Tests
{
    public static class TestConstants
    {
        public static string SoapMessageWithResourceReferenceProperty = @"<s:Envelope xmlns:s=""http://www.w3.org/2003/05/soap-envelope"" xmlns:a=""http://www.w3.org/2005/08/addressing"" xmlns:u=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd"">
  <s:Header>
    <a:Action s:mustUnderstand=""1"" u:Id=""_4"">http://schemas.microsoft.com/2006/11/ResourceManagement/fault</a:Action>
    <a:RelatesTo u:Id=""_5"">urn:uuid:f9fe7758-14c1-43ad-874d-1a18f6e8d017</a:RelatesTo>
    <Context u:Id=""_6"" xmlns=""http://schemas.microsoft.com/ws/2006/05/context"">
      <Property name=""instanceId"">87d409b2-078f-4829-86e8-027f6da74014</Property>
    </Context>
    <o:Security s:mustUnderstand=""1"" xmlns:o=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd"">
      <u:Timestamp u:Id=""uuid-a31177d2-c2f5-40dc-a8de-01891afb2868-15061"">
        <u:Created>2015-09-08T18:32:47.670Z</u:Created>
        <u:Expires>2015-09-08T18:37:47.670Z</u:Expires>
      </u:Timestamp>
      <c:DerivedKeyToken u:Id=""_0"" xmlns:c=""http://schemas.xmlsoap.org/ws/2005/02/sc"">
        <o:SecurityTokenReference>
          <o:Reference URI=""urn:uuid:3b166c57-0a88-4710-bfb7-72a964499994"" ValueType=""http://schemas.xmlsoap.org/ws/2005/02/sc/sct"" />
        </o:SecurityTokenReference>
        <c:Offset>0</c:Offset>
        <c:Length>24</c:Length>
        <c:Nonce>rysUPAQ9dRSHvSmhZA8KiQ==</c:Nonce>
      </c:DerivedKeyToken>
      <c:DerivedKeyToken u:Id=""_1"" xmlns:c=""http://schemas.xmlsoap.org/ws/2005/02/sc"">
        <o:SecurityTokenReference>
          <o:Reference URI=""urn:uuid:3b166c57-0a88-4710-bfb7-72a964499994"" ValueType=""http://schemas.xmlsoap.org/ws/2005/02/sc/sct"" />
        </o:SecurityTokenReference>
        <c:Nonce>eOMgp7/FtvHCOncT4Bt7GQ==</c:Nonce>
      </c:DerivedKeyToken>
      <e:ReferenceList xmlns:e=""http://www.w3.org/2001/04/xmlenc#"">
        <e:DataReference URI=""#_3"" />
        <e:DataReference URI=""#_7"" />
      </e:ReferenceList>
      <e:EncryptedData Id=""_7"" Type=""http://www.w3.org/2001/04/xmlenc#Element"" xmlns:e=""http://www.w3.org/2001/04/xmlenc#"">
        <e:EncryptionMethod Algorithm=""http://www.w3.org/2001/04/xmlenc#aes256-cbc"" />
        <KeyInfo xmlns=""http://www.w3.org/2000/09/xmldsig#"">
          <o:SecurityTokenReference>
            <o:Reference URI=""#_1"" />
          </o:SecurityTokenReference>
        </KeyInfo>
        <e:CipherData>
          <e:CipherValue>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</e:CipherValue>
        </e:CipherData>
      </e:EncryptedData>
    </o:Security>
  </s:Header>
  <s:Body u:Id=""_2"">
    <Fault xmlns=""http://www.w3.org/2003/05/soap-envelope"">
      <Code>
        <Value>Receiver</Value>
        <Subcode>
          <Value xmlns:a=""http://schemas.microsoft.com/2006/11/ResourceManagement"">a:AuthorizationRequiredFault</Value>
        </Subcode>
      </Code>
      <Reason>
        <Text xml:lang=""en-US"">Permission is required</Text>
      </Reason>
      <Detail>
        <AuthorizationRequiredFault xmlns=""http://schemas.microsoft.com/2006/11/ResourceManagement"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
          <EndpointReference xmlns=""http://schemas.xmlsoap.org/ws/2004/08/addressing"">
            <Address>http://fimallinone:5725/ResourceManagementService/Resource</Address>
            <ReferenceProperties>
              <ResourceReferenceProperty xmlns=""http://schemas.microsoft.com/2006/11/ResourceManagement"">urn:uuid:f7453c35-fda7-4e78-bd9d-b3ae77eaa26c</ResourceReferenceProperty>
            </ReferenceProperties>
          </EndpointReference>
        </AuthorizationRequiredFault>
      </Detail>
    </Fault>
  </s:Body>
</s:Envelope>";
    }
}
