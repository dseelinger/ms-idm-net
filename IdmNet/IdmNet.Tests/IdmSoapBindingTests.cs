using IdmNet.SoapModels;
using Xunit;

namespace IdmNet.Tests
{
    public class IdmSoapBindingTests
    {
        [Fact]
        public void It_has_a_parameterless_constructor()
        {
            var it = new IdmSoapBinding();

            Assert.False(it.Security.Message.EstablishSecurityContext);
            Assert.True(it.AllowCookies);
            Assert.Equal(20000000, it.MaxReceivedMessageSize);
            Assert.Equal(20000000, it.MaxBufferPoolSize);
            Assert.Equal(32, it.ReaderQuotas.MaxDepth);
            Assert.Equal(20000000, it.ReaderQuotas.MaxArrayLength);
            Assert.Equal(20000000, it.ReaderQuotas.MaxStringContentLength);
        }

        [Fact]
        public void It_has_a_parameterized_constructor()
        {
            var it = new IdmSoapBinding(500);

            Assert.False(it.Security.Message.EstablishSecurityContext);
            Assert.True(it.AllowCookies);
            Assert.Equal(500, it.MaxReceivedMessageSize);
            Assert.Equal(500, it.MaxBufferPoolSize);
            Assert.Equal(32, it.ReaderQuotas.MaxDepth);
            Assert.Equal(500, it.ReaderQuotas.MaxArrayLength);
            Assert.Equal(500, it.ReaderQuotas.MaxStringContentLength);
        }
    }
}
