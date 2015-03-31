using System;
using System.Collections.Generic;
using System.Net;
using System.ServiceModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IdmNet.Tests
{
    [TestClass]
    public class IdmNetTests
    {
        // TODO 001: Make this work
        [TestMethod]
        [TestCategory("Integration")]
        public void It_can_get_all_ObjectTypeDescription()
        {
            // Arrange
            var criteria = new SearchCriteria { Attributes = new[] { "Name" }, XPath = "/ObjectTypeDescription" };
            var soapBinding = new IdmSoapBinding();
            var endpointAddress = new EndpointAddress(GetEnv("MIM_Enumeration_endpoint"));
            var credential = new NetworkCredential(
                GetEnv("MIM_username"),
                GetEnv("MIM_pwd"),
                GetEnv("MIM_domain"));
            var searchClient = new SearchClient(soapBinding, endpointAddress);
            if (searchClient.ClientCredentials != null)
                searchClient.ClientCredentials.Windows.ClientCredential = credential;
            else
                Assert.Fail("Could not construct Idm Search Client");
            var it = new IdmNet(searchClient);

            // Act
            //// TODO 002: Create IdmResource object
            //// TODO 001: Create SearchAsync method
            //IEnumerable<IdmResource> result = await it.SearchAsync(criteria);



        }

        private static string GetEnv(string environmentVariableName)
        {
            var environmentVariable = Environment.GetEnvironmentVariable(environmentVariableName);
            if (environmentVariable == null)
            {
                throw new ApplicationException("Missing Environment Variable: " + environmentVariableName);
            }
            return environmentVariable;
        }

    }
}
