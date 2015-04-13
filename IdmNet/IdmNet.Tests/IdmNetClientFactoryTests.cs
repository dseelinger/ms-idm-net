using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IdmNet.Tests
{
    [TestClass]
    public class IdmNetClientFactoryTests
    {
        [TestMethod]
        public void It_can_build_and_initialize_an_IdmNetClient_instance()
        {
            var client = IdmNetClientFactory.BuildClient();

            Assert.IsNotNull(client);
        }
    }
}
