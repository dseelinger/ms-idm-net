using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace IdmNet
{
    [Serializable]
    public class SoapFaultException : Exception
    {
        public SoapFaultException()
        {
        }

        public SoapFaultException(string message)
            : base(message)
        {
        }

        public SoapFaultException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected SoapFaultException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException("info");
            base.GetObjectData(info, context);
        }
    }
}
