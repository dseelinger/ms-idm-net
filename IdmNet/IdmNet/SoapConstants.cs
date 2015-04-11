namespace IdmNet
{
    public static class SoapConstants
    {
        public const string EnumeratePortAndPath = ":5725/ResourceManagementService/Enumeration";
        public const string FactoryPortAndPath = ":5725/ResourceManagementService/ResourceFactory";
        public const string ResourcePortAndPath = ":5725/ResourceManagementService/Resource";

        public const string EnumerateAction = "http://schemas.xmlsoap.org/ws/2004/09/enumeration/Enumerate";
        public const string CreateAction = "http://schemas.xmlsoap.org/ws/2004/09/transfer/Create";
        public const string DeleteAction = "http://schemas.xmlsoap.org/ws/2004/09/transfer/Delete";

        public const string RmNamespace = "http://schemas.microsoft.com/2006/11/ResourceManagement";
        public const string EnumerationNamespace = "http://schemas.xmlsoap.org/ws/2004/09/enumeration";
        public const string IdentityAttributeTypeDialect = "http://schemas.microsoft.com/2006/11/ResourceManagement/Dialect/IdentityAttributeType-20080602";
        public const string DirectoryAccess = "http://schemas.microsoft.com/2006/11/IdentityManagement/DirectoryAccess";
        public const string Transfer = "http://schemas.xmlsoap.org/ws/2004/09/transfer";
        public const string Addressing = "http://schemas.xmlsoap.org/ws/2004/08/addressing";
    }
}
