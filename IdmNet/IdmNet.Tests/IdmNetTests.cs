using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IdmNet.Tests
{
    [TestClass]
    public class IdmNetTests
    {
        [TestMethod]
        [TestCategory("Integration")]
        public async Task It_can_get_all_ObjectTypeDescription()
        {
            // Arrange
            var it = BuildClient(); 

            // Act
            var criteria = new SearchCriteria { Attributes = new[] { "DisplayName" }, XPath = "/ObjectTypeDescription" };
            IEnumerable<IdmResource> result = await it.SearchAsync(criteria);


            var resultsAry = result.ToArray();
            Assert.IsTrue(resultsAry.Length >= 42);
            Assert.IsTrue(resultsAry[0].GetAttrValues("DisplayName").Count == 1);
            Assert.AreEqual("Activity Information Configuration", resultsAry[0].DisplayName);
            Assert.AreEqual("Workflow Instance", resultsAry[resultsAry.Length - 1].DisplayName);
        }

        [TestMethod]
        [TestCategory("Integration")]
        public async Task It_can_get_objects_with_multi_valued_attributes()
        {
            // Arrange
            var it = BuildClient();

            // Act
            var criteria = new SearchCriteria { Attributes = new[] { "UsageKeyword" }, XPath = "/BindingDescription" };
            IEnumerable<IdmResource> result = await it.SearchAsync(criteria);


            var resultsAry = result.ToArray();
            Assert.IsTrue(resultsAry.Length > 42);
            Assert.IsTrue(resultsAry[0].GetAttrValues("UsageKeyword").Count >= 1);
        }

        [TestMethod]
        [TestCategory("Integration")]
        public async Task It_can_perform_multiple_searches()
        {
            // Arrange
            var it = BuildClient();

            // Act 1
            var criteria = new SearchCriteria { Attributes = new[] { "UsageKeyword" }, XPath = "/BindingDescription" };
            IEnumerable<IdmResource> result = await it.SearchAsync(criteria);


            var resultsAry = result.ToArray();
            Assert.IsTrue(resultsAry.Length > 42);
            Assert.IsTrue(resultsAry[0].GetAttrValues("UsageKeyword").Count >= 1);

            // Act 2
            var criteria2 = new SearchCriteria { Attributes = new[] { "DisplayName" }, XPath = "/ObjectTypeDescription" };
            IEnumerable<IdmResource> result2 = await it.SearchAsync(criteria2);


            var resultsAry2 = result2.ToArray();
            Assert.IsTrue(resultsAry2.Length >= 42);
            Assert.IsTrue(resultsAry2[0].GetAttrValues("DisplayName").Count == 1);
            Assert.AreEqual("Activity Information Configuration", resultsAry2[0].DisplayName);
            Assert.AreEqual("Workflow Instance", resultsAry2[resultsAry2.Length - 1].DisplayName);
        }


        [TestMethod]
        [TestCategory("Integration")]
        [ExpectedException(typeof(Exception))]
        public async Task It_throws_for_get_when_bad_xpath_given()
        {
            // Arrange
            var it = BuildClient();

            // Act
            var criteria = new SearchCriteria { XPath = "<3#" };
            await it.SearchAsync(criteria);
        }

        [TestMethod]
        [TestCategory("Integration")]
        [ExpectedException(typeof(Exception))]
        public async Task It_throws_when_unknown_xpath_given()
        {
            // Arrange
            var it = BuildClient();

            // Act
            var criteria = new SearchCriteria { XPath = "/foo" };
            await it.SearchAsync(criteria);
        }


        [TestMethod]
        [TestCategory("Integration")]
        public async Task It_can_sort_search_results()
        {
            // Arrange
            var it = BuildClient();

            // Act
            var criteria = new SearchCriteria { Attributes = new[] { "DisplayName" }, XPath = "/ObjectTypeDescription", SortAttribute =  "DisplayName", SortDecending = true};
            IEnumerable<IdmResource> result = await it.SearchAsync(criteria);


            var resultsAry = result.ToArray();
            Assert.IsTrue(resultsAry.Length >= 42);
            Assert.IsTrue(resultsAry[0].GetAttrValues("DisplayName").Count == 1);
            Assert.AreEqual("Workflow Instance", resultsAry[0].DisplayName);
            Assert.AreEqual("Activity Information Configuration", resultsAry[resultsAry.Length - 1].DisplayName);
        }



        //[TestMethod]
        //[TestCategory("Integration")]
        //public async Task It_can_create_objects_in_Identity_Manager()
        //{
        //    // Arrange
        //    var it = BuildClient();

        //    // Act
        //    var newUser = new IdmResource{ObjectType = "Person", DisplayName = "Test User"};
        //    IdmResource createResult = await it.CreateAsync(newUser);

        //    // assert
        //    IEnumerable<IdmResource> searchResult =
        //        await it.SearchAsync(new SearchCriteria {XPath = "/Person[ObjectId='" + createResult.ObjectID + "']"});
        //    var searchArray = searchResult.ToArray();
        //    Assert.AreEqual(newUser.DisplayName, createResult.DisplayName);
        //    Assert.AreEqual(newUser.DisplayName, searchArray[0].DisplayName);
        //}

        private static IdmNetClient BuildClient()
        {
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

            //// TODO: Inject this, don't construct it here
            //var factory = new ResourceFactoryClient("ServiceMultipleTokenBinding_ResourceFactory",
            //    new EndpointAddress(new Uri(this.base_address + service_url),
            //        EndpointIdentity.CreateSpnIdentity("FIMService/" + addressFQDN))); 






            var it = new IdmNetClient(searchClient);
            return it;
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
