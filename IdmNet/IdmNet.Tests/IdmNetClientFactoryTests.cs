using System;
using System.Threading.Tasks;
using IdmNet.Tests.TestModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using Assert = Xunit.Assert;

namespace IdmNet.Tests
{
    [TestClass]
    public class IdmNetClientFactoryTests : PortalTestBase
    {
        [Fact]
        public void It_can_build_and_initialize_an_IdmNetClient_instance()
        {
            var client = IdmNetClientFactory.BuildClient();

            Assert.NotNull(client);
        }

        [Fact]
        public void It_throws_when_an_environment_setting_cannot_be_found()
        {

            Assert.Throws<ApplicationException>(() => { IdmNetClientFactory.GetEnvironmentSetting("foo"); });
        }

        [Fact]
        public void It_does_not_throw_when_an_environment_variable_is_not_present_but_an_app_doc_config_setting_is_present()
        {

            var result = IdmNetClientFactory.GetEnvironmentSetting("bar");

            Assert.Equal("value", result);
        }

        [TestMethod]
        [TestCategory("Integration")]
        public async Task It_can_take_connection_information_in_the_ctor()
        {
            // Arrange
            TestUserInfo testUser = null;
            try
            {
                testUser = await CreateTestUser("con03");
                string fqdn = IdmNetClientFactory.GetEnvironmentSetting("MIM_fqdn");
                string username = IdmNetClientFactory.GetEnvironmentSetting("MIM_username");
                string password = IdmNetClientFactory.GetEnvironmentSetting("MIM_pwd");
                string domain = IdmNetClientFactory.GetEnvironmentSetting("MIM_domain");
                IdmConnectionInfo connectionInfo = new IdmConnectionInfo
                {
                    Server = fqdn,
                    Username = username,
                    Password = password,
                    Domain = domain
                };

                var it = IdmNetClientFactory.BuildClient(connectionInfo);

            }
            finally
            {
                // Afterwards
                await DeleteUser(testUser);
            }
        }

    }
}
