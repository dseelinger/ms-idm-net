namespace IdmNet
{
    /// <summary>
    /// Constants used for serializing SOAP objects
    /// </summary>
    public static class SoapConstants
    {
        /// <summary>
        /// Constant for serializing Identity Manager objects - not for normal use.
        /// </summary>
        public const string EnumeratePortAndPath = ":5725/ResourceManagementService/Enumeration";

        /// <summary>
        /// Constant for serializing Identity Manager objects - not for normal use.
        /// </summary>
        public const string FactoryPortAndPath = ":5725/ResourceManagementService/ResourceFactory";

        /// <summary>
        /// Constant for serializing Identity Manager objects - not for normal use.
        /// </summary>
        public const string ResourcePortAndPath = ":5725/ResourceManagementService/Resource";

        /// <summary>
        /// Constant for serializing Identity Manager objects - not for normal use.
        /// </summary>
        public const string EnumerateAction = "http://schemas.xmlsoap.org/ws/2004/09/enumeration/Enumerate";

        /// <summary>
        /// Constant for serializing Identity Manager objects - not for normal use.
        /// </summary>
        public const string CreateAction = "http://schemas.xmlsoap.org/ws/2004/09/transfer/Create";

        /// <summary>
        /// Constant for serializing Identity Manager objects - not for normal use.
        /// </summary>
        public const string DeleteAction = "http://schemas.xmlsoap.org/ws/2004/09/transfer/Delete";

        /// <summary>
        /// Constant for serializing Identity Manager objects - not for normal use.
        /// </summary>
        public const string PutAction = "http://schemas.xmlsoap.org/ws/2004/09/transfer/Put";


        /// <summary>
        /// Constant for serializing Identity Manager objects - not for normal use.
        /// </summary>
        public const string RmNamespace = "http://schemas.microsoft.com/2006/11/ResourceManagement";

        /// <summary>
        /// Constant for serializing Identity Manager objects - not for normal use.
        /// </summary>
        public const string EnumerationNamespace = "http://schemas.xmlsoap.org/ws/2004/09/enumeration";

        /// <summary>
        /// Constant for serializing Identity Manager objects - not for normal use.
        /// </summary>
        public const string IdentityAttributeTypeDialect =
            "http://schemas.microsoft.com/2006/11/ResourceManagement/Dialect/IdentityAttributeType-20080602";

        /// <summary>
        /// Constant for serializing Identity Manager objects - not for normal use.
        /// </summary>
        public const string DirectoryAccess = "http://schemas.microsoft.com/2006/11/IdentityManagement/DirectoryAccess";

        /// <summary>
        /// Constant for serializing Identity Manager objects - not for normal use.
        /// </summary>
        public const string Transfer = "http://schemas.xmlsoap.org/ws/2004/09/transfer";

        /// <summary>
        /// Constant for serializing Identity Manager objects - not for normal use.
        /// </summary>
        public const string Addressing = "http://schemas.xmlsoap.org/ws/2004/08/addressing";
    }
}