using System;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace IdmNet
{
    public class SoapXmlSerializer : XmlObjectSerializer
    {
        private readonly XmlSerializer _serializer;

        public SoapXmlSerializer(Type type)
        {
            _serializer = new XmlSerializer(type);
        }


        public override bool IsStartObject(XmlDictionaryReader reader)
        {
            return _serializer.CanDeserialize(reader);
        }

        public override object ReadObject(XmlDictionaryReader reader, bool verifyObjectName)
        {
            return (!verifyObjectName || IsStartObject(reader)) ? _serializer.Deserialize(reader) : null;
        }

        public override void WriteEndObject(XmlDictionaryWriter writer)
        {
        }

        public override void WriteObjectContent(XmlDictionaryWriter writer, object graph)
        {
            _serializer.Serialize(writer, graph);
        }

        public override void WriteStartObject(XmlDictionaryWriter writer, object graph)
        {
        }
    }
}
