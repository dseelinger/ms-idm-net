using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IdmNet.Tests
{
    [TestClass]
    public class SoapFaultExceptionTests
    {
        [TestMethod]
        public void It_has_a_default_ctor()
        {
            // Arrange
            const string expectedMessage = "Exception of type 'IdmNet.SoapFaultException' was thrown.";

            // Act
            var sut = new SoapFaultException();

            // Assert
            Assert.IsNull(sut.InnerException);
            Assert.AreEqual(expectedMessage, sut.Message);
        }

        [TestMethod]
        public void It_has_a_ctor_string()
        {
            // Arrange
            const string expectedMessage = "message";

            // Act
            var sut = new SoapFaultException(expectedMessage);

            // Assert
            Assert.IsNull(sut.InnerException);
            Assert.AreEqual(expectedMessage, sut.Message);
        }

        [TestMethod]
        public void It_has_a_ctor_string_ex()
        {
            // Arrange
            const string expectedMessage = "message";
            var innerEx = new Exception("foo");

            // Act
            var sut = new SoapFaultException(expectedMessage, innerEx);

            // Assert
            Assert.AreEqual(innerEx, sut.InnerException);
            Assert.AreEqual(expectedMessage, sut.Message);
        }

        [TestMethod]
        public void It_can_be_serialized_and_deserialized()
        {
            // Arrange
            var innerEx = new Exception("foo");
            var originalException = new SoapFaultException("message", innerEx);
            var buffer = new byte[4096];
            var ms = new MemoryStream(buffer);
            var ms2 = new MemoryStream(buffer);
            var formatter = new BinaryFormatter();

            // Act
            formatter.Serialize(ms, originalException);
            var deserializedException = (SoapFaultException)formatter.Deserialize(ms2);

            // Assert
            Assert.AreEqual(originalException.InnerException.Message, deserializedException.InnerException.Message);
            Assert.AreEqual(originalException.Message, deserializedException.Message);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void It_throws_when_GetObjectData_called_with_null_info()
        {
            // Arrange
            var sut = new SoapFaultException("message");

            // Act
            // ReSharper disable once AssignNullToNotNullAttribute
            sut.GetObjectData(null, new StreamingContext());
        }
    }
}
