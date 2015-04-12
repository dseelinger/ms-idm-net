using System.ServiceModel;
using System.Xml;

namespace IdmNet.SoapModels
{
    public class IdmSoapBinding : WSHttpContextBinding
    {
        public const int DefaultMaxDataSize = 20000000;

        public IdmSoapBinding()
            : this(DefaultMaxDataSize)
        {
        }

        public IdmSoapBinding(int maxDataSize)
        {
            Security.Message.EstablishSecurityContext = false;
            AllowCookies = true;
            MaxReceivedMessageSize = maxDataSize;
            MaxBufferPoolSize = maxDataSize;
            ReaderQuotas = new XmlDictionaryReaderQuotas()
            {
                MaxDepth = 32,
                MaxArrayLength = maxDataSize,
                MaxStringContentLength = maxDataSize
            };
        }
    }
}
