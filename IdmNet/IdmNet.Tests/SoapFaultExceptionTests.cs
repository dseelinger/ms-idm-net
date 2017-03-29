using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Xunit;

namespace IdmNet.Tests
{
    public class SoapFaultExceptionTests
    {
        [Fact]
        public void It_has_a_default_ctor()
        {
            // Arrange
            const string expectedMessage = "Exception of type 'IdmNet.SoapFaultException' was thrown.";

            // Act
            var sut = new SoapFaultException();

            // Assert
            Assert.Null(sut.InnerException);
            Assert.Equal(expectedMessage, sut.Message);
        }

        [Fact]
        public void It_has_a_ctor_string()
        {
            // Arrange
            const string expectedMessage = "message";

            // Act
            var sut = new SoapFaultException(expectedMessage);

            // Assert
            Assert.Null(sut.InnerException);
            Assert.Equal(expectedMessage, sut.Message);
        }

        [Fact]
        public void It_has_a_ctor_string_ex()
        {
            // Arrange
            const string expectedMessage = "message";
            var innerEx = new Exception("foo");

            // Act
            var sut = new SoapFaultException(expectedMessage, innerEx);

            // Assert
            Assert.Equal(innerEx, sut.InnerException);
            Assert.Equal(expectedMessage, sut.Message);
        }

        [Fact]
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
            Assert.Equal(originalException.InnerException.Message, deserializedException.InnerException.Message);
            Assert.Equal(originalException.Message, deserializedException.Message);
        }

        [Fact]
        public void It_throws_when_GetObjectData_called_with_null_info()
        {
            // Arrange
            var sut = new SoapFaultException("message");

            // Act
            Assert.Throws<ArgumentNullException>(() => sut.GetObjectData(null, new StreamingContext()));
        }
    }
}
