using System;
using Xunit;

namespace IdmNet.Tests
{
    public class IdmNetClientFactoryTests
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
    }
}
