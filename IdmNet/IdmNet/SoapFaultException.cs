using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace IdmNet
{
    /// <summary>
    /// Exception thrown when a SOAP Fault is detected/returned from SOAP web service calls.
    /// </summary>
    [Serializable]
    public class SoapFaultException : Exception
    {
        /// <summary>
        /// Parameterless CTOR
        /// </summary>
        public SoapFaultException()
        {
        }

        /// <summary>
        /// Create a new Soap Fault with a particular message
        /// </summary>
        /// <param name="message">Message to return to catching methods</param>
        public SoapFaultException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Create a new Soap Fault with a particular message and inner exception
        /// </summary>
        /// <param name="message">Message to return to catching methods</param>
        /// <param name="inner">Not normally used - just included for completeness</param>
        public SoapFaultException(string message, Exception inner)
            : base(message, inner)
        {
        }

        /// <summary>
        /// For serializing
        /// </summary>
        /// <param name="info">For serializing</param>
        /// <param name="context">For serializing</param>
        protected SoapFaultException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        /// For serializing
        /// </summary>
        /// <param name="info">For serializing</param>
        /// <param name="context">For serializing</param>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException("info");
            base.GetObjectData(info, context);
        }
    }
}
