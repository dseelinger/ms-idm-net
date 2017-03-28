﻿using System;
using Xunit;

namespace IdmNet.Tests
{
    public class IdmNetClientFactoryTests //: PortalTestBase
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
        public void It_can_take_connection_information_in_the_ctor()
        {
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
    }
}
