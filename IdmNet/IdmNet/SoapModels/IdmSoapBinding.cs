using System.ServiceModel;
using System.Xml;

namespace IdmNet.SoapModels
{
    /// <summary>
    /// This is the default WCF binding for IdMNet
    /// </summary>
    public class IdmSoapBinding : WSHttpContextBinding
    {
        /// <summary>
        /// Settled on this size after some initial real-world testing
        /// </summary>
        public const int DefaultMaxDataSize = 20000000;

        /// <summary>
        /// Parameterless CTOR
        /// </summary>
        public IdmSoapBinding()
            : this(DefaultMaxDataSize)
        {
        }

        /// <summary>
        /// CTOR with a specific data size (don't think it's actually used currently, but could be useful in a 
        /// debuggin scenario
        /// </summary>
        /// <param name="maxDataSize"></param>
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