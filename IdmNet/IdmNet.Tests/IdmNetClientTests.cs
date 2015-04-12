using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.Threading.Tasks;
using IdmNet.SoapModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
#pragma warning disable 4014

// ReSharper disable PossibleNullReferenceException

namespace IdmNet.Tests
{
    [TestClass]
    public class IdmNetClientTests
    {
        [TestMethod]
        [TestCategory("Integration")]
        public async Task It_can_get_all_ObjectTypeDescription()
        {
            // Arrange
            var it = BuildClient(); 

            // Act
            var criteria = new SearchCriteria { Attributes = new[] { "DisplayName" }, XPath = "/ObjectTypeDescription" };
            IEnumerable<IdmResource> result = await it.GetAsync(criteria);


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
            IEnumerable<IdmResource> result = await it.GetAsync(criteria);


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
            IEnumerable<IdmResource> result = await it.GetAsync(criteria);


            var resultsAry = result.ToArray();
            Assert.IsTrue(resultsAry.Length > 42);
            Assert.IsTrue(resultsAry[0].GetAttrValues("UsageKeyword").Count >= 1);

            // Act 2
            var criteria2 = new SearchCriteria { Attributes = new[] { "DisplayName" }, XPath = "/ObjectTypeDescription" };
            IEnumerable<IdmResource> result2 = await it.GetAsync(criteria2);


            var resultsAry2 = result2.ToArray();
            Assert.IsTrue(resultsAry2.Length >= 42);
            Assert.IsTrue(resultsAry2[0].GetAttrValues("DisplayName").Count == 1);
            Assert.AreEqual("Activity Information Configuration", resultsAry2[0].DisplayName);
            Assert.AreEqual("Workflow Instance", resultsAry2[resultsAry2.Length - 1].DisplayName);
        }


        [TestMethod]
        [TestCategory("Integration")]
        [ExpectedException(typeof(SoapFaultException))]
        public async Task It_throws_for_get_when_bad_xpath_given()
        {
            // Arrange
            var it = BuildClient();

            // Act
            var criteria = new SearchCriteria { XPath = "<3#" };
            await it.GetAsync(criteria);
        }

        [TestMethod]
        [TestCategory("Integration")]
        [ExpectedException(typeof(SoapFaultException))]
        public async Task It_throws_when_unknown_xpath_given()
        {
            // Arrange
            var it = BuildClient();

            // Act
            var criteria = new SearchCriteria { XPath = "/foo" };
            await it.GetAsync(criteria);
        }


        [TestMethod]
        [TestCategory("Integration")]
        public async Task It_can_sort_search_results()
        {
            // Arrange
            var it = BuildClient();

            // Act
            var criteria = new SearchCriteria { Attributes = new[] { "DisplayName" }, XPath = "/ObjectTypeDescription", SortAttribute =  "DisplayName", SortDecending = true};
            IEnumerable<IdmResource> result = await it.GetAsync(criteria);


            var resultsAry = result.ToArray();
            Assert.IsTrue(resultsAry.Length >= 42);
            Assert.IsTrue(resultsAry[0].GetAttrValues("DisplayName").Count == 1);
            Assert.AreEqual("Workflow Instance", resultsAry[0].DisplayName);
            Assert.AreEqual("Activity Information Configuration", resultsAry[resultsAry.Length - 1].DisplayName);
        }



        [TestMethod]
        [TestCategory("Integration")]
        public async Task It_can_create_objects_in_Identity_Manager()
        {
            // Arrange
            var it = BuildClient();

            // Act
            var newUser = new IdmResource { ObjectType = "Person", DisplayName = "Test User" };
            IdmResource createResult = await it.PostAsync(newUser);

            // assert
            IEnumerable<IdmResource> searchResult =
                await it.GetAsync(new SearchCriteria { XPath = "/Person[ObjectID='" + createResult.ObjectID + "']" });
            var searchArray = searchResult.ToArray();
            Assert.AreEqual(newUser.DisplayName, createResult.DisplayName);
            Assert.AreEqual(newUser.DisplayName, searchArray[0].DisplayName);

            // afterwards
            await it.DeleteAsync(createResult.ObjectID);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task It_throws_when_passing_a_null_resource_to_create()
        {
            // Arrange
            var it = BuildClient();

            // Act
            await it.PostAsync(null);
        }

        [TestMethod]
        [TestCategory("Integration")]
        [ExpectedException(typeof(SoapFaultException))]
        public async Task It_throws_when_an_invalid_resource_is_passed_to_create()
        {
            // Arrange
            var it = BuildClient();

            // Act
            var newUser = new IdmResource();
            await it.PostAsync(newUser);
        }



        [TestMethod]
        [TestCategory("Integration")]
        public async Task It_can_delete_an_IdmResource()
        {
            // Arrange
            var it = BuildClient();
            IdmResource toDelete =
                await it.PostAsync(new IdmResource {ObjectType = "Person", DisplayName = "Test User"});

            // Act
            await it.DeleteAsync(toDelete.ObjectID);


            // Assert
            IEnumerable<IdmResource> searchResult =
                await it.GetAsync(new SearchCriteria { XPath = "/Person[ObjectID='" + toDelete.ObjectID + "']" });
            Assert.AreEqual(0, searchResult.Count());
        }


        [TestMethod]
        [TestCategory("Integration")]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task It_throws_when_attempting_to_delete_a_null_ObjectID()
        {
            // Arrange
            var it = BuildClient();

            // Act
            await it.DeleteAsync(null);
        }

        [TestMethod]
        [TestCategory("Integration")]
        [ExpectedException(typeof(SoapFaultException))]
        public async Task It_throws_when_attempting_to_delete_a_bad_object_ID()
        {
            // Arrange
            var it = BuildClient();

            // Act
            await it.DeleteAsync("bad object id");
        }


        [TestMethod]
        [TestCategory("Integration")]
        [ExpectedException(typeof(SoapFaultException))]
        public async Task It_throws_when_Posting_a_value_to_a_single_valued_attribute()
        {
            // Arrange
            const string attrName = "FirstName";
            const string attrValue = "Testing";
            var it = BuildClient();
            IdmResource testResource = await CreateTestPerson(it);

            // Act
            try
            {
                await it.AddValueAsync(testResource.ObjectID, attrName, attrValue);
            }
            finally
            {
                // Afterwards
                it.DeleteAsync(testResource.ObjectID);
            }

        }


        [TestMethod]
        [TestCategory("Integration")]
        public async Task It_can_PostAttributeValueAsync_to_a_multi_valued_attribute_that_already_has_one_or_more_values()
        {
            // Arrange
            const string attrName = "SearchScopeContext";
            const string attrValue = "FirstName";
            var it = BuildClient();
            IdmResource testResource = await CreateTestSearchScope(it);

            // Act
            try
            {
                await it.AddValueAsync(testResource.ObjectID, attrName, attrValue);

                // Assert
                var searchResult =
                    await
                        it.GetAsync(new SearchCriteria
                        {
                            XPath = "/SearchScopeConfiguration[ObjectID='" + testResource.ObjectID + "']",
                            Attributes = new[] { "SearchScopeContext" }
                        });
                Assert.IsTrue(searchResult.First().GetAttrValues(attrName).Contains(attrValue));
            }
            finally 
            {
                // Afterwards
                it.DeleteAsync(testResource.ObjectID);
            }


        }

        [TestMethod]
        [TestCategory("Integration")]
        public async Task It_can_PostAttributeValueAsync_to_a_not_present_multi_valued_attribute()
        {
            // Arrange
            const string attrName = "ProxyAddressCollection";
            const string attrValue = "joecool@nowhere.net";
            var it = BuildClient();
            IdmResource testResource = await CreateTestPerson(it);

            // Act
            try
            {
                await it.AddValueAsync(testResource.ObjectID, attrName, attrValue);

                // Assert
                var searchResult =
                    await
                        it.GetAsync(new SearchCriteria
                        {
                            XPath = "/Person[ObjectID='" + testResource.ObjectID + "']",
                            Attributes = new[] { "ProxyAddressCollection" }
                        });
                Assert.IsTrue(searchResult.First().GetAttrValues(attrName).Contains(attrValue));
            }
            finally
            {
                // Afterwards
                it.DeleteAsync(testResource.ObjectID);
            }
        }

        [TestMethod]
        [TestCategory("Integration")]
        public async Task It_can_DeleteAttributeValueAsync_to_a_not_present_multi_valued_attribute()
        {
            // Arrange
            const string attrName = "ProxyAddressCollection";
            const string attrValue1 = "joecool@nowhere.net";
            const string attrValue2 = "joecool@nowhere.lab";
            var it = BuildClient();
            IdmResource testResource = await CreateTestPerson(it);

            try
            {
                await it.AddValueAsync(testResource.ObjectID, attrName, attrValue1);
                await it.AddValueAsync(testResource.ObjectID, attrName, attrValue2);

                // Act
                await it.RemoveValueAsync(testResource.ObjectID, attrName, attrValue2);

                // Assert
                var searchResult =
                    await
                        it.GetAsync(new SearchCriteria
                        {
                            XPath = "/Person[ObjectID='" + testResource.ObjectID + "']",
                            Attributes = new[] { "ProxyAddressCollection" }
                        });
                Assert.IsFalse(searchResult.First().GetAttrValues(attrName).Contains(attrValue2));
            }
            finally
            {
                // Afterwards
                it.DeleteAsync(testResource.ObjectID);
            }
        }

        [TestMethod]
        [TestCategory("Integration")]
        public async Task It_can_PutAttributeValueAsync_to_a_not_present_single_valued_attribute()
        {
            // Arrange
            const string attrName = "FirstName";
            const string attrValue1 = "TestFirstName";
            var it = BuildClient();
            IdmResource testResource = await CreateTestPerson(it);

            try
            {
                // Act
                await it.ReplaceValueAsync(testResource.ObjectID, attrName, attrValue1);


                // Assert
                var searchResult =
                    await
                        it.GetAsync(new SearchCriteria
                        {
                            XPath = "/Person[ObjectID='" + testResource.ObjectID + "']",
                            Attributes = new[] { attrName }
                        });
                Assert.AreEqual(attrValue1, searchResult.First().GetAttrValue(attrName));
            }
            finally
            {
                // Afterwards
                it.DeleteAsync(testResource.ObjectID);
            }
        }

        [TestMethod]
        [TestCategory("Integration")]
        public async Task It_can_PutAttributeValueAsync_to_a_present_single_valued_attribute()
        {
            // Arrange
            const string attrName = "FirstName";
            const string attrValue1 = "TestFirstName1";
            const string attrValue2 = "TestFirstName2";
            var it = BuildClient();
            IdmResource testResource = await CreateTestPerson(it);

            try
            {
                // Act
                await it.ReplaceValueAsync(testResource.ObjectID, attrName, attrValue1);
                await it.ReplaceValueAsync(testResource.ObjectID, attrName, attrValue2);


                // Assert
                var searchResult =
                    await
                        it.GetAsync(new SearchCriteria
                        {
                            XPath = "/Person[ObjectID='" + testResource.ObjectID + "']",
                            Attributes = new[] { attrName }
                        });
                Assert.AreEqual(attrValue2, searchResult.First().GetAttrValue(attrName));
            }
            finally
            {
                // Afterwards
                it.DeleteAsync(testResource.ObjectID);
            }
        }

        [TestMethod]
        [TestCategory("Integration")]
        public async Task It_can_PutAttributeValueAsync_with_a_null_value_to_a_present_single_valued_attribute()
        {
            // Arrange
            const string attrName = "FirstName";
            const string attrValue1 = "TestFirstName1";
            const string attrValue2 = null;
            var it = BuildClient();
            IdmResource testResource = await CreateTestPerson(it);

            try
            {
                // Act
                await it.ReplaceValueAsync(testResource.ObjectID, attrName, attrValue1);
                await it.ReplaceValueAsync(testResource.ObjectID, attrName, attrValue2);

                // Assert
                var searchResult =
                    await
                        it.GetAsync(new SearchCriteria
                        {
                            XPath = "/Person[ObjectID='" + testResource.ObjectID + "']",
                            Attributes = new[] { attrName }
                        });
                Assert.IsNull(searchResult.First().GetAttrValue(attrName));
            }
            finally
            {
                // Afterwards
                it.DeleteAsync(testResource.ObjectID);
            }
        }

        
        // TODO 005: Implement Update Whole Object

        // TODO 004: Implement User and Group
        // TODO 003: Implement ObjectTypeDescription, AttributeTypeDescription, and Binding
        // TODO 001: Implement Creation of Approvals
        // TODO 000: Implement Attribute Endpoints on resources



        private static IdmNetClient BuildClient()
        {
            var soapBinding = new IdmSoapBinding();
            string fqdn = IdmUtils.GetEnv("MIM_fqdn");
            var endpointIdentity = EndpointIdentity.CreateSpnIdentity("FIMSERVICE/" + fqdn);


            var enumerationPath = "http://" + fqdn + SoapConstants.EnumeratePortAndPath;
            var factoryPath = "http://" + fqdn + SoapConstants.FactoryPortAndPath;
            var resourcePath = "http://" + fqdn + SoapConstants.ResourcePortAndPath;
            

            var enumerationEndpoint = new EndpointAddress(new Uri(enumerationPath), endpointIdentity);
            var factoryEndpoint = new EndpointAddress(new Uri(factoryPath), endpointIdentity);
            var resourceEndpoint = new EndpointAddress(new Uri(resourcePath), endpointIdentity);
            

            var searchClient = new SearchClient(soapBinding, enumerationEndpoint);
            var factoryClient = new ResourceFactoryClient(soapBinding, factoryEndpoint);
            var resourceClient = new ResourceClient(soapBinding, resourceEndpoint);



            var credentials = new NetworkCredential(
                GetEnv("MIM_username"),
                GetEnv("MIM_pwd"),
                GetEnv("MIM_domain"));

            searchClient.ClientCredentials.Windows.ClientCredential = credentials;
            factoryClient.ClientCredentials.Windows.ClientCredential = credentials;
            resourceClient.ClientCredentials.Windows.ClientCredential = credentials;


            var it = new IdmNetClient(searchClient, factoryClient, resourceClient);
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

        private static async Task<IdmResource> CreateTestPerson(IdmNetClient it)
        {
            return await it.PostAsync(new IdmResource { ObjectType = "Person", DisplayName = "Test User" });
        }
        private static async Task<IdmResource> CreateTestSearchScope(IdmNetClient it)
        {
            return await it.PostAsync(new IdmResource { Attributes = new List<IdmAttribute>
            {
                new IdmAttribute{Name = "ObjectType", Value = "SearchScopeConfiguration"},
                new IdmAttribute{Name = "DisplayName", Value = "_TestSearchScope"},
                new IdmAttribute{Name = "SearchScopeContext", Value = "DisplayName"},
                new IdmAttribute{Name = "IsConfigurationType", Value = "true"},
                new IdmAttribute{Name = "Order", Value = "1"},
                new IdmAttribute{Name = "SearchScope", Value = "/Person"},
                new IdmAttribute{Name = "UsageKeyword", Value = "foo"},
            }});
        }
    }
}
