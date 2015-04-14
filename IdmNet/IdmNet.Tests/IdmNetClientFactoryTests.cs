using System;
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

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void It_throws_when_an_environment_variable_is_missing()
        {
            IdmNetClientFactory.GetEnv("foo");
        }


    }
}
