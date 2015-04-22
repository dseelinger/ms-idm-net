using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Threading.Tasks;
using System.Xml;
using IdmNet.Models;
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
            var it = IdmNetClientFactory.BuildClient();
            var criteria = new SearchCriteria("/ObjectTypeDescription");
            criteria.Selection.Add("DisplayName");

            // Act
            IEnumerable<IdmResource> result = await it.SearchAsync(criteria);

            // Assert
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
            var it = IdmNetClientFactory.BuildClient();
            var criteria = new SearchCriteria("/BindingDescription");
            criteria.Selection.Add("UsageKeyword");

            // Act
            IEnumerable<IdmResource> result = await it.SearchAsync(criteria);

            // Assert
            var resultsAry = result.ToArray();
            Assert.IsTrue(resultsAry.Length > 42);
            Assert.IsTrue(resultsAry[0].GetAttrValues("UsageKeyword").Count >= 1);
        }

        [TestMethod]
        [TestCategory("Integration")]
        public async Task It_can_perform_multiple_searches()
        {
            // Arrange 1
            var it = IdmNetClientFactory.BuildClient();
            var criteria = new SearchCriteria("/BindingDescription");
            criteria.Selection.Add("UsageKeyword");

            // Act 1
            IEnumerable<IdmResource> result = await it.SearchAsync(criteria);

            // Assert 1
            var resultsAry = result.ToArray();
            Assert.IsTrue(resultsAry.Length > 42);
            Assert.IsTrue(resultsAry[0].GetAttrValues("UsageKeyword").Count >= 1);




            // Arrange 2
            var criteria2 = new SearchCriteria("/ObjectTypeDescription");
            criteria2.Selection.Add("DisplayName");

            // Act 2
            IEnumerable<IdmResource> result2 = await it.SearchAsync(criteria2);

            // Assert 2
            var resultsAry2 = result2.ToArray();
            Assert.IsTrue(resultsAry2.Length >= 42);
            Assert.IsTrue(resultsAry2[0].GetAttrValues("DisplayName").Count == 1);
            Assert.AreEqual("Activity Information Configuration", resultsAry2[0].DisplayName);
            Assert.AreEqual("Workflow Instance", resultsAry2[resultsAry2.Length - 1].DisplayName);
        }


        [TestMethod]
        [TestCategory("Integration")]
        [ExpectedException(typeof (SoapFaultException))]
        public async Task It_throws_for_get_when_bad_xpath_given()
        {
            // Arrange
            var it = IdmNetClientFactory.BuildClient();
            var criteria = new SearchCriteria("<3#");

            // Act
            await it.SearchAsync(criteria);
        }

        [TestMethod]
        [TestCategory("Integration")]
        [ExpectedException(typeof (SoapFaultException))]
        public async Task It_throws_when_unknown_xpath_given()
        {
            // Arrange
            var it = IdmNetClientFactory.BuildClient();
            var criteria = new SearchCriteria("/foo");

            // Act
            await it.SearchAsync(criteria);
        }


        [TestMethod]
        [TestCategory("Integration")]
        public async Task It_can_sort_search_results()
        {
            // Arrange
            var it = IdmNetClientFactory.BuildClient();

            // Act
            var criteria = new SearchCriteria
            {
                Filter = new Filter {Query = "/ObjectTypeDescription"},
                Selection = new List<string> {"DisplayName"},
                Sorting =
                    new Sorting
                    {
                        SortingAttributes =
                            new[] {new SortingAttribute {Ascending = false, AttributeName = "DisplayName"}}
                    }
            };

            IEnumerable<IdmResource> result = await it.SearchAsync(criteria);


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
            var it = IdmNetClientFactory.BuildClient();

            // Act
            var newUser = new IdmResource {ObjectType = "Person", DisplayName = "Test User"};
            IdmResource createResult = await it.PostAsync(newUser);
            Assert.AreEqual(newUser.DisplayName, createResult.DisplayName);

            // assert
            //IEnumerable<IdmResource> searchResult =
            //    await it.SearchAsync(new SearchCriteria { XPath = "/Person[ObjectID='" + createResult.ObjectID + "']" });
            var result = await it.GetAsync(createResult.ObjectID, new[] {"DisplayName"});
            Assert.AreEqual(newUser.DisplayName, result.DisplayName);

            // afterwards
            await it.DeleteAsync(createResult.ObjectID);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException))]
        public async Task It_throws_when_passing_a_null_resource_to_create()
        {
            // Arrange
            var it = IdmNetClientFactory.BuildClient();

            // Act
            await it.PostAsync(null);
        }

        [TestMethod]
        [TestCategory("Integration")]
        [ExpectedException(typeof (SoapFaultException))]
        public async Task It_throws_when_an_invalid_resource_is_passed_to_create()
        {
            // Arrange
            var it = IdmNetClientFactory.BuildClient();

            // Act
            var newUser = new IdmResource();
            await it.PostAsync(newUser);
        }



        [TestMethod]
        [TestCategory("Integration")]
        public async Task It_can_delete_an_IdmResource()
        {
            // Arrange
            var it = IdmNetClientFactory.BuildClient();
            IdmResource toDelete =
                await it.PostAsync(new IdmResource {ObjectType = "Person", DisplayName = "Test User"});

            // Act
            Message result = await it.DeleteAsync(toDelete.ObjectID);


            // Assert
            Assert.IsFalse(result.IsFault);
            try
            {
                await it.GetAsync(toDelete.ObjectID, new[] {"DisplayName"});
                Assert.Fail("Should not make it here");
            }
            catch (SoapFaultException)
            {
                // OK
            }

        }


        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException))]
        public async Task It_throws_when_attempting_to_delete_a_null_ObjectID()
        {
            // Arrange
            var it = IdmNetClientFactory.BuildClient();

            // Act
            await it.DeleteAsync(null);
        }

        [TestMethod]
        [TestCategory("Integration")]
        [ExpectedException(typeof (SoapFaultException))]
        public async Task It_throws_when_attempting_to_delete_a_bad_object_ID()
        {
            // Arrange
            var it = IdmNetClientFactory.BuildClient();

            // Act
            await it.DeleteAsync("bad object id");
        }


        [TestMethod]
        [TestCategory("Integration")]
        [ExpectedException(typeof (SoapFaultException))]
        public async Task It_throws_when_Posting_a_value_to_a_single_valued_attribute()
        {
            // Arrange
            const string attrName = "FirstName";
            const string attrValue = "Testing";
            var it = IdmNetClientFactory.BuildClient();
            IdmResource testResource = await CreateTestPerson(it);

            // Act
            try
            {
                Message result = await it.AddValueAsync(testResource.ObjectID, attrName, attrValue);

                Assert.IsFalse(result.IsFault);
            }
            finally
            {
                // Afterwards
                it.DeleteAsync(testResource.ObjectID);
            }

        }


        [TestMethod]
        [TestCategory("Integration")]
        public async Task It_can_PostAttributeValueAsync_to_a_multi_valued_attribute_that_already_has_one_or_more_values
            ()
        {
            // Arrange
            const string attrName = "SearchScopeContext";
            const string attrValue = "FirstName";
            var it = IdmNetClientFactory.BuildClient();
            IdmResource testResource = await CreateTestSearchScope(it);

            // Act
            try
            {
                await it.AddValueAsync(testResource.ObjectID, attrName, attrValue);

                // Assert
                var searchResult =
                    await
                        it.SearchAsync(new SearchCriteria
                        {
                            Filter =
                                new Filter
                                {
                                    Query = "/SearchScopeConfiguration[ObjectID='" + testResource.ObjectID + "']"
                                },
                            Selection = new List<string> {"SearchScopeContext"}
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
            var it = IdmNetClientFactory.BuildClient();
            IdmResource testResource = await CreateTestPerson(it);

            // Act
            try
            {
                await it.AddValueAsync(testResource.ObjectID, attrName, attrValue);

                // Assert
                var searchResult =
                    await
                        it.SearchAsync(new SearchCriteria
                        {
                            Filter =
                                new Filter
                                {
                                    Query = "/Person[ObjectID='" + testResource.ObjectID + "']"
                                },
                            Selection = new List<string> {"ProxyAddressCollection"}
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
            var it = IdmNetClientFactory.BuildClient();
            IdmResource testResource = await CreateTestPerson(it);

            try
            {
                await it.AddValueAsync(testResource.ObjectID, attrName, attrValue1);
                await it.AddValueAsync(testResource.ObjectID, attrName, attrValue2);

                // Act
                Message result = await it.RemoveValueAsync(testResource.ObjectID, attrName, attrValue2);

                // Assert
                Assert.IsFalse(result.IsFault);
                var searchResult =
                    await
                        it.SearchAsync(new SearchCriteria
                        {
                            Filter =
                                new Filter
                                {
                                    Query = "/Person[ObjectID='" + testResource.ObjectID + "']"
                                },
                            Selection = new List<string> {"ProxyAddressCollection"}
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
            const string attrValue = "TestFirstName";
            var it = IdmNetClientFactory.BuildClient();
            IdmResource testResource = await CreateTestPerson(it);

            try
            {
                // Act
                Message result = await it.ReplaceValueAsync(testResource.ObjectID, attrName, attrValue);

                // Assert
                Assert.IsFalse(result.IsFault);
                var searchResult =
                    await
                        it.SearchAsync(new SearchCriteria
                        {
                            Filter =
                                new Filter
                                {
                                    Query = "/Person[ObjectID='" + testResource.ObjectID + "']"
                                },
                            Selection = new List<string> {attrName}
                        });

                Assert.AreEqual(attrValue, searchResult.First().GetAttrValue(attrName));
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
            await AssertReplaceOk("FirstName", "TestFirstName1", "TestFirstName2");
        }

        [TestMethod]
        [TestCategory("Integration")]
        public async Task It_can_PutAttributeValueAsync_with_a_null_value_to_a_present_single_valued_attribute()
        {
            await AssertReplaceOk("FirstName", "TestFirstName1", null);
        }

        [TestMethod]
        [TestCategory("Integration")]
        public async Task It_can_PutAsync_to_batch_a_bunch_of_changes_together_for_a_single_object()
        {
            // Arrange
            var it = IdmNetClientFactory.BuildClient();
            IdmResource testResource = await CreateTestPerson(it);
            var changes1 = new[]
            {
                new Change(ModeType.Replace, "FirstName", "FirstNameTest"),
                new Change(ModeType.Replace, "LastName", "LastNameTest"),
                new Change(ModeType.Add, "ProxyAddressCollection", "joe@lab1.lab"),
                new Change(ModeType.Add, "ProxyAddressCollection", "joe@lab2.lab"),
            };

            try
            {
                // Act
                Message result = await it.ChangeMultipleAttrbutes(testResource.ObjectID, changes1);

                // Assert
                Assert.IsFalse(result.IsFault);
                var searchResult =
                    await
                        it.SearchAsync(new SearchCriteria
                        {
                            Filter =
                                new Filter
                                {
                                    Query = "/Person[ObjectID='" + testResource.ObjectID + "']"
                                },
                            Selection = new List<string> {"FirstName", "LastName", "ProxyAddressCollection"}
                        });

                var modifiedResource1 = searchResult.First();
                Assert.AreEqual("FirstNameTest", modifiedResource1.GetAttrValue("FirstName"));
                Assert.AreEqual("LastNameTest", modifiedResource1.GetAttrValue("LastName"));
                Assert.IsTrue(modifiedResource1.GetAttrValues("ProxyAddressCollection").Contains("joe@lab1.lab"));
                Assert.IsTrue(modifiedResource1.GetAttrValues("ProxyAddressCollection").Contains("joe@lab2.lab"));
            }
            finally
            {
                // Afterwards
                it.DeleteAsync(testResource.ObjectID);
            }
        }

        [TestMethod]
        [TestCategory("Integration")]
        public async Task It_can_GetAsync_by_ID()
        {
            // Arrange
            var it = IdmNetClientFactory.BuildClient();
            var newUser = new IdmResource {ObjectType = "Person", DisplayName = "Test User"};
            IdmResource createResult = await it.PostAsync(newUser);
            var attributes = new[] {"DisplayName", "ObjectID"};

            // Act
            IdmResource result = await it.GetAsync(createResult.ObjectID, attributes);

            // assert
            Assert.AreEqual(createResult.ObjectID, result.ObjectID);
            Assert.AreEqual("Person", result.ObjectType);
            Assert.AreEqual("Test User", result.DisplayName);

            // afterwards
            await it.DeleteAsync(createResult.ObjectID);
        }


        [TestMethod]
        [TestCategory("Integration")]
        public async Task It_can_get_a_count_on_a_Search()
        {
            // Arrange
            var it = IdmNetClientFactory.BuildClient();

            // Act
            int result = await it.GetCountAsync("/ConstantSpecifier");


            Assert.AreEqual(97, result);
        }

        [TestMethod]
        [TestCategory("Integration")]
        public async Task It_can_get_all_ObjectTypeDescription_in_reverse_order()
        {
            // Arrange
            var it = IdmNetClientFactory.BuildClient();

            // Act
            var criteria = new SearchCriteria
            {
                Selection = new List<string> {"DisplayName"},
                Filter = new Filter {Query = "/ObjectTypeDescription"},
                Sorting =
                    new Sorting
                    {
                        SortingAttributes =
                            new[] {new SortingAttribute {Ascending = false, AttributeName = "DisplayName"}}
                    }
            };

            IEnumerable<IdmResource> result = await it.SearchAsync(criteria);


            var resultsAry = result.ToArray();
            Assert.IsTrue(resultsAry.Length >= 42);
            Assert.IsTrue(resultsAry[0].GetAttrValues("DisplayName").Count == 1);
            Assert.AreEqual("Activity Information Configuration", resultsAry[resultsAry.Length - 1].DisplayName);
            Assert.AreEqual("Workflow Instance", resultsAry[0].DisplayName);
        }



        [TestMethod]
        [TestCategory("Integration")]
        public async Task It_can_PreparePagedSearchAsync()
        {
            // Arrange
            var it = IdmNetClientFactory.BuildClient();
            var criteria = new SearchCriteria("/ObjectTypeDescription");
            criteria.Selection.Add("DisplayName");

            // Act
            var result = await it.PreparePagedSearchAsync(criteria, 5);

            // Assert
            Assert.AreEqual("/ObjectTypeDescription", result.PagingContext.Filter);
            Assert.AreEqual(0, result.PagingContext.CurrentIndex);
            Assert.AreEqual("Forwards", result.PagingContext.EnumerationDirection);
            Assert.AreEqual("9999-12-31T23:59:59.9999999", result.PagingContext.Expires);
            Assert.AreEqual("ObjectID", result.PagingContext.Selection[0]);
            Assert.AreEqual("ObjectType", result.PagingContext.Selection[1]);
            Assert.AreEqual("DisplayName", result.PagingContext.Selection[2]);
            Assert.AreEqual("DisplayName", result.PagingContext.Sorting.SortingAttributes[0].AttributeName);
            Assert.AreEqual(true, result.PagingContext.Sorting.SortingAttributes[0].Ascending);
        }

        [TestMethod]
        [TestCategory("Integration")]
        public async Task It_can_PullAsync()
        {
            // Arrange
            var it = IdmNetClientFactory.BuildClient();
            var criteria = new SearchCriteria("/ObjectTypeDescription");
            criteria.Selection.Add("DisplayName");
            PullInfo pullInfo = await it.PreparePagedSearchAsync(criteria, 5);
            PagingContext pagingContext = pullInfo.PagingContext;

            // Act
            var pagedResults = await it.PullAsync(5, pagingContext);

            // Assert
            Assert.AreEqual(5, pagedResults.Results.Count);
            Assert.AreEqual("Activity Information Configuration", pagedResults.Results[0].DisplayName);
            Assert.AreEqual("Binding Description", pagedResults.Results[4].DisplayName);
            Assert.AreEqual("/ObjectTypeDescription", pagedResults.PagingContext.Filter);
            Assert.AreEqual(5, pagedResults.PagingContext.CurrentIndex);
            Assert.AreEqual("Forwards", pagedResults.PagingContext.EnumerationDirection);
            Assert.AreEqual("9999-12-31T23:59:59.9999999", pagedResults.PagingContext.Expires);
            Assert.AreEqual("ObjectID", pagedResults.PagingContext.Selection[0]);
            Assert.AreEqual("ObjectType", pagedResults.PagingContext.Selection[1]);
            Assert.AreEqual("DisplayName", pagedResults.PagingContext.Selection[2]);
            Assert.AreEqual("DisplayName", pagedResults.PagingContext.Sorting.SortingAttributes[0].AttributeName);
            Assert.AreEqual(true, pagedResults.PagingContext.Sorting.SortingAttributes[0].Ascending);

            Assert.AreEqual(null, pagedResults.EndOfSequence);
            Assert.AreEqual(true, pagedResults.Items is XmlNode[]);
            Assert.AreEqual(5, ((XmlNode[])(pagedResults.Items)).Length);
        }

        [TestMethod]
        [TestCategory("Integration")]
        public async Task It_can_PullAsync_even_wothout_getting_PullInfo_first_if_you_know_what_you_are_doing()
        {
            // Arrange
            var it = IdmNetClientFactory.BuildClient();
            PagingContext pagingContext = new PagingContext
            {
                CurrentIndex = 0,
                Filter = "/ObjectTypeDescription",
                Selection = new[] {"ObjectID", "ObjectType", "DisplayName"},
                Sorting = new Sorting(),
                EnumerationDirection = "Forwards",
                Expires = "9999-12-31T23:59:59.9999999"
            };

            // Act
            var pagedResults = await it.PullAsync(5, pagingContext);

            // Assert
            Assert.AreEqual(5, pagedResults.Results.Count);
            Assert.AreEqual("Activity Information Configuration", pagedResults.Results[0].DisplayName);
            Assert.AreEqual("Binding Description", pagedResults.Results[4].DisplayName);

            Assert.AreEqual(null, pagedResults.EndOfSequence);
            Assert.AreEqual(true, pagedResults.Items is XmlNode[]);
            Assert.AreEqual(5, ((XmlNode[])(pagedResults.Items)).Length);
        }

        // TODO 003: Implement GetSchema(string objectTypeName)
        // TODO 002: Implement Select *
        // TODO 001: Implement Approvals
        // TODO -999: Implement the STS endpoint





        private static async Task<IdmResource> CreateTestPerson(IdmNetClient it)
        {
            return await it.PostAsync(new IdmResource {ObjectType = "Person", DisplayName = "Test User"});
        }

        private static async Task<IdmResource> CreateTestSearchScope(IdmNetClient it)
        {
            return await it.PostAsync(new IdmResource
            {
                Attributes = new List<IdmAttribute>
                {
                    new IdmAttribute {Name = "ObjectType", Value = "SearchScopeConfiguration"},
                    new IdmAttribute {Name = "DisplayName", Value = "_TestSearchScope"},
                    new IdmAttribute {Name = "SearchScopeContext", Value = "DisplayName"},
                    new IdmAttribute {Name = "IsConfigurationType", Value = "true"},
                    new IdmAttribute {Name = "Order", Value = "1"},
                    new IdmAttribute {Name = "SearchScope", Value = "/Person"},
                    new IdmAttribute {Name = "UsageKeyword", Value = "foo"},
                }
            });
        }

        private static async Task AssertReplaceOk(string attrName, string attrValue1, string attrValue2)
        {
            var it = IdmNetClientFactory.BuildClient();
            IdmResource testResource = await CreateTestPerson(it);

            try
            {
                // Act
                await it.ReplaceValueAsync(testResource.ObjectID, attrName, attrValue1);
                await it.ReplaceValueAsync(testResource.ObjectID, attrName, attrValue2);

                // Assert
                var searchResult =
                    await it.SearchAsync(new SearchCriteria
                    {
                        Filter =
                            new Filter
                            {
                                Query = "/Person[ObjectID='" + testResource.ObjectID + "']"
                            },
                        Selection = new List<string> {attrName}
                    });

                Assert.AreEqual(attrValue2, searchResult.First().GetAttrValue(attrName));
            }
            finally
            {
                // Afterwards
                it.DeleteAsync(testResource.ObjectID);
            }
        }
    }
}
