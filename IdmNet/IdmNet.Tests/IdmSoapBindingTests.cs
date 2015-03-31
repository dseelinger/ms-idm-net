using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IdmNet.Tests
{
    [TestClass]
    public class IdmSoapBindingTests
    {
        [TestMethod]
        public void It_has_a_parameterless_constructor()
        {
            var it = new IdmSoapBinding();

            Assert.IsFalse(it.Security.Message.EstablishSecurityContext);
            Assert.IsTrue(it.AllowCookies);
            Assert.AreEqual(20000000, it.MaxReceivedMessageSize);
            Assert.AreEqual(20000000, it.MaxBufferPoolSize);
            Assert.AreEqual(32, it.ReaderQuotas.MaxDepth);
            Assert.AreEqual(20000000, it.ReaderQuotas.MaxArrayLength);
            Assert.AreEqual(20000000, it.ReaderQuotas.MaxStringContentLength);
        }

        [TestMethod]
        public void It_has_a_parameterized_constructor()
        {
            var it = new IdmSoapBinding(500);

            Assert.IsFalse(it.Security.Message.EstablishSecurityContext);
            Assert.IsTrue(it.AllowCookies);
            Assert.AreEqual(500, it.MaxReceivedMessageSize);
            Assert.AreEqual(500, it.MaxBufferPoolSize);
            Assert.AreEqual(32, it.ReaderQuotas.MaxDepth);
            Assert.AreEqual(500, it.ReaderQuotas.MaxArrayLength);
            Assert.AreEqual(500, it.ReaderQuotas.MaxStringContentLength);
        }
    }
}
