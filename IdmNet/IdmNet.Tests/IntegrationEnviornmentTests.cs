using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IdmNet.Tests
{
    [TestClass]
    public class IntegrationEnviornmentTests
    {
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void It_throws_when_an_environment_variable_doesnt_exist()
        {
            IdmUtils.GetEnv("foo");
        }

        [TestMethod]
        public void RequiredEnvironmentVariablesExist()
        {
            string user = IdmUtils.GetEnv("MIM_username");
            string pwd = IdmUtils.GetEnv("MIM_pwd");
            string domain = IdmUtils.GetEnv("MIM_domain");
            string fqdn = IdmUtils.GetEnv("MIM_fqdn");

            Assert.IsFalse(string.IsNullOrWhiteSpace(user));
            Assert.IsFalse(string.IsNullOrWhiteSpace(pwd));
            Assert.IsFalse(string.IsNullOrWhiteSpace(domain));
            Assert.IsFalse(string.IsNullOrWhiteSpace(fqdn));
            Assert.IsFalse(fqdn.ToLower().StartsWith("http"));
        }
    }
}
