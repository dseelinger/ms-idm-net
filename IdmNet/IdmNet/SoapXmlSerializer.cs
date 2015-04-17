using System;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace IdmNet
{
    /// <summary>
    /// Class for serializing our SOAP messages for Identity Manager to consume
    /// </summary>
    public class SoapXmlSerializer : XmlObjectSerializer
    {
        private readonly XmlSerializer _serializer;

        /// <summary>
        /// Build serilizer for specific type
        /// </summary>
        /// <param name="type">Type to serialize</param>
        public SoapXmlSerializer(Type type)
        {
            _serializer = new XmlSerializer(type);
        }

        /// <summary>
        /// Required for SOAP serialization
        /// </summary>
        /// <param name="reader">SOAP stuff</param>
        /// <returns>SOAP stuff</returns>
        public override bool IsStartObject(XmlDictionaryReader reader)
        {
            return _serializer.CanDeserialize(reader);
        }

        /// <summary>
        /// SOAP stuff
        /// </summary>
        /// <param name="reader">SOAP stuff</param>
        /// <param name="verifyObjectName">SOAP stuff</param>
        /// <returns>SOAP stuff</returns>
        public override object ReadObject(XmlDictionaryReader reader, bool verifyObjectName)
        {
            return (!verifyObjectName || IsStartObject(reader)) ? _serializer.Deserialize(reader) : null;
        }

        /// <summary>
        /// SOAP stuff
        /// </summary>
        /// <param name="writer">SOAP stuff</param>
        public override void WriteEndObject(XmlDictionaryWriter writer)
        {
        }

        /// <summary>
        /// SOAP stuff
        /// </summary>
        /// <param name="writer">SOAP stuff</param>
        /// <param name="graph">SOAP stuff</param>
        public override void WriteObjectContent(XmlDictionaryWriter writer, object graph)
        {
            _serializer.Serialize(writer, graph);
        }

        /// <summary>
        /// SOAP stuff
        /// </summary>
        /// <param name="writer">SOAP stuff</param>
        /// <param name="graph">SOAP stuff</param>
        public override void WriteStartObject(XmlDictionaryWriter writer, object graph)
        {
        }
    }
}
