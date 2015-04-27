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
        public async Task T001_It_can_search_for_resources_without_specifying_a_select_or_sort()
        {
            // Arrange
            var it = IdmNetClientFactory.BuildClient();

            // Act
            var results = (await it.SearchAsync(new SearchCriteria("/ObjectTypeDescription"))).ToArray();

            // Assert
            Assert.IsTrue(results.Length >= 40);
            Assert.AreEqual(2, results[0].Attributes.Count);
            Assert.AreEqual("ObjectTypeDescription", results[0].ObjectType);
            Assert.AreEqual("ObjectTypeDescription", results[results.Length - 1].ObjectType);
            Assert.AreEqual("e1a42ced-6968-457c-b5c8-3f9a573295a6".Length, results[0].ObjectID.Length);
            Assert.AreEqual("e1a42ced-6968-457c-b5c8-3f9a573295a6".Length, results[1].ObjectID.Length);
        }

        [TestMethod]
        [TestCategory("Integration")]
        public async Task T002_It_can_search_for_resources_and_return_specific_attributes()
        {
            // Arrange
            var it = IdmNetClientFactory.BuildClient();

            // Act
            var results =
                (await
                    it.SearchAsync(new SearchCriteria("/ObjectTypeDescription")
                    {
                        Selection = new List<string> { "DisplayName", "Name" }
                    })).ToArray();

            // Assert
            Assert.IsTrue(results.Length >= 40);
            Assert.AreEqual(4, results[0].Attributes.Count);
            Assert.AreEqual("Activity Information Configuration", results[0].DisplayName);
            Assert.AreEqual("Workflow Instance", results[results.Length - 1].DisplayName);
            Assert.AreEqual("ActivityInformationConfiguration", results[0].GetAttrValue("Name"));
            Assert.AreEqual("Approval", results[1].GetAttrValue("Name"));
        }

        [TestMethod]
        [TestCategory("Integration")]
        public async Task T003_It_can_search_for_resources_and_return_all_attributes_with_Select_STAR()
        {
            // Arrange
            var it = IdmNetClientFactory.BuildClient();

            // Act
            var results =
                (await
                    it.SearchAsync(new SearchCriteria("/BindingDescription")
                    {
                        Selection = new List<string> {"*"},
                    })).ToArray();

            // Assert
            Assert.IsTrue(results.Length >= 40);
            Assert.AreEqual(10, results[0].Attributes.Count);
            Assert.AreEqual("Account Name", results[0].DisplayName);
            Assert.AreEqual("XOML", results[results.Length - 1].DisplayName);
        }

        [TestMethod]
        [TestCategory("Integration")]
        public async Task T004_It_can_Search_for_resources_and_Sort_the_results_by_multiple_attributes_in_Ascending_or_Descending_order()
        {
            // Arrange
            var it = IdmNetClientFactory.BuildClient();

            // Act
            var results =
                (await
                    it.SearchAsync(new SearchCriteria("/BindingDescription")
                    {
                        Selection = new List<string> { "*" },
                        Sorting = new Sorting
                        {
                            SortingAttributes = new[]
                            {
                                new SortingAttribute {Ascending = true, AttributeName = "BoundObjectType"},
                                new SortingAttribute {Ascending = false, AttributeName = "BoundAttributeType"}
                            }
                        }
                    })).ToArray();

            // Assert
            var bindings = results.Select(idmResource => new BindingDescription(idmResource)).ToList();

            // Grouped/sorted by object type, ascending (incidentally it sorts reference attributes by their 
            // associated DisplayName, except for attribute name, which appears to put ObjectID as the first attribute)
            Assert.AreEqual("e1a42ced-6968-457c-b5c8-3f9a573295a6", bindings[0].BoundObjectType.ObjectID);
            Assert.AreEqual("e1a42ced-6968-457c-b5c8-3f9a573295a6", bindings[1].BoundObjectType.ObjectID);
            // ...
            Assert.AreEqual("e1a42ced-6968-457c-b5c8-3f9a573295a6", bindings[18].BoundObjectType.ObjectID);
            Assert.AreEqual("e1a42ced-6968-457c-b5c8-3f9a573295a6", bindings[19].BoundObjectType.ObjectID);

            Assert.AreEqual("c51c9ef3-2de0-4d4e-b30b-c1a18e79c56e", bindings[20].BoundObjectType.ObjectID);

            var attributes = new List<string> { "DisplayName" };
            var objType1 = await it.GetAsync(bindings[0].BoundObjectType.ObjectID, attributes);
            Assert.AreEqual("Activity Information Configuration", objType1.DisplayName);

            var objType2 = await it.GetAsync(bindings[20].BoundObjectType.ObjectID, attributes);
            Assert.AreEqual("Approval", objType2.DisplayName);


            // Sub-sort is by attribute type - descending (note that ObjectID appears "before" ActivityName"
            var attributes2 = new List<string> { "Name" };
            var objType3 = await it.GetAsync(bindings[0].BoundAttributeType.ObjectID, attributes2);
            Assert.AreEqual("TypeName", objType3.GetAttrValue("Name"));

            var objType4 = await it.GetAsync(bindings[1].BoundAttributeType.ObjectID, attributes2);
            Assert.AreEqual("ResourceTime", objType4.GetAttrValue("Name"));

            var objType6 = await it.GetAsync(bindings[18].BoundAttributeType.ObjectID, attributes2);
            Assert.AreEqual("ActivityName", objType6.GetAttrValue("Name"));

            var objType5 = await it.GetAsync(bindings[19].BoundAttributeType.ObjectID, attributes2);
            Assert.AreEqual("ObjectID", objType5.GetAttrValue("Name"));
        }

        [TestMethod]
        [TestCategory("Integration")]
        public async Task T005_It_can_get_a_resource_by_its_ObjectID()
        {
            // Arrange
            var it = IdmNetClientFactory.BuildClient();

            // Act
            IdmResource result = await it.GetAsync("c51c9ef3-2de0-4d4e-b30b-c1a18e79c56e", null);

            // Assert
            Assert.AreEqual("c51c9ef3-2de0-4d4e-b30b-c1a18e79c56e", result.ObjectID);
            Assert.AreEqual("ObjectTypeDescription", result.ObjectType);
        }

        [TestMethod]
        [TestCategory("Integration")]
        public async Task T006_It_can_get_any_or_all_attributes_for_a_resource_by_its_ObjectID()
        {
            // Arrange
            var it = IdmNetClientFactory.BuildClient();

            // Act
            IdmResource result = await it.GetAsync("c51c9ef3-2de0-4d4e-b30b-c1a18e79c56e", new List<string> { "*" });

            // Assert
            Assert.AreEqual(6, result.Attributes.Count);
            Assert.AreEqual("c51c9ef3-2de0-4d4e-b30b-c1a18e79c56e", result.ObjectID);
            Assert.AreEqual("ObjectTypeDescription", result.ObjectType);
            Assert.AreEqual("Approval", result.DisplayName);
        }


        [TestMethod]
        [TestCategory("Integration")]
        public async Task T007_It_can_return_the_number_of_matching_records_for_a_given_search()
        {
            // Arrange
            var it = IdmNetClientFactory.BuildClient();

            // Act
            int result = await it.GetCountAsync("/ConstantSpecifier");

            // Assert
            Assert.AreEqual(97, result);
        }












        [TestMethod]
        [TestCategory("Integration")]
        [ExpectedException(typeof (SoapFaultException))]
        public async Task It_throws_an_exception_get_when_it_encounters_bad_xpath()
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
        public async Task It_throws_an_exception_when_valid_yet_unknown_xpath_is_searched_for()
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
            var result = await it.GetAsync(createResult.ObjectID, new List<string> { "DisplayName" });
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
        public async Task It_throws_an_exception_when_trying_to_create_an_invalid_resource()
        {
            // Arrange
            var it = IdmNetClientFactory.BuildClient();

            // Act
            var newUser = new IdmResource();
            await it.PostAsync(newUser);
        }



        [TestMethod]
        [TestCategory("Integration")]
        public async Task It_can_delete_objects_from_Identity_Manager()
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
                await it.GetAsync(toDelete.ObjectID, new List<string> { "DisplayName" });
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
        public async Task It_throws_an_exception_when_attempting_to_delete_an_object_that_does_not_exist()
        {
            // Arrange
            var it = IdmNetClientFactory.BuildClient();

            // Act
            await it.DeleteAsync("bad object id");
        }


        [TestMethod]
        [TestCategory("Integration")]
        [ExpectedException(typeof (SoapFaultException))]
        public async Task It_throws_an_exception_when_you_treat_a_single_valued_attribute_as_if_it_is_multi_valued()
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
        public async Task It_can_add_a_value_to_a_multi_valued_attribute_that_already_has_one_or_more_values
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
        public async Task It_can_add_a_value_to_an_empty_multi_valued_attribute()
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
        public async Task It_can_delete_a_value_from_a_multi_valued_attribute()
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
        public async Task It_can_modify_single_valued_attribute_that_was_previously_null()
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
        public async Task It_can_modify_a_value_of_a_single_valued_attribute_even_if_it_already_had_a_value()
        {
            await AssertReplaceOk("FirstName", "TestFirstName1", "TestFirstName2");
        }

        [TestMethod]
        [TestCategory("Integration")]
        public async Task It_can_remove_a_single_valued_attribute_by_setting_its_value_to_null()
        {
            await AssertReplaceOk("FirstName", "TestFirstName1", null);
        }

        [TestMethod]
        [TestCategory("Integration")]
        public async Task It_can_make_a_bunch_of_changes_at_the_same_time_for_a_single_resource()
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
        public async Task It_can_get_all_ObjectTypeDescription_objects_in_reverse_order()
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
        public async Task It_can_do_a_search_and_return_the_results_at_a_later_time()
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
        public async Task It_can_get_resources_back_from_a_search_a_page_at_a_time()
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
        public async Task It_can_get_resources_even_without_an_initial_search_call_if_you_know_what_you_are_doing()
        {
            // Arrange
            var it = IdmNetClientFactory.BuildClient();
            PagingContext pagingContext = new PagingContext
            {
                CurrentIndex = 0,
                Filter = "/ObjectTypeDescription",
                Selection = new[] { "ObjectID", "ObjectType", "DisplayName" },
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

        [TestMethod]
        [TestCategory("Integration")]
        public async Task It_can_return_the_entire_schema_for_a_particular_object_type()
        {
            // Arrange
            var personOid = "6cb7e506-b4b3-4901-8b8c-ff044f14e743";
            var it = IdmNetClientFactory.BuildClient();

            // Act
            ObjectTypeDescription result = await it.GetSchemaAsync("Person");

            // Assert
            Assert.AreEqual("User", result.DisplayName);
            Assert.IsTrue(result.CreatedTime >= new DateTime(2010, 1, 1));
            Assert.AreEqual(null, result.Creator);
            Assert.AreEqual("This resource defines applicable policies to manage incoming requests. ", result.Description);
            Assert.AreEqual("Person", result.Name);
            Assert.AreEqual(personOid, result.ObjectID);
            Assert.AreEqual("ObjectTypeDescription", result.ObjectType);
            Assert.AreEqual(null, result.ResourceTime);
            Assert.AreEqual("Microsoft.ResouceManagement.PortalClient", result.UsageKeyword[0]);

            var expectedBindingCount = 59;
            Assert.AreEqual(expectedBindingCount, result.BindingDescriptions.Count);
            for (int i = 0; i < expectedBindingCount; i++)
            {
                Assert.AreEqual(personOid, result.BindingDescriptions[i].BoundObjectType.ObjectID);
            }
            Assert.AreEqual("3e04bbbf-014f-413c-8d07-6276cd383be8", result.BindingDescriptions[0].BoundAttributeType.ObjectID);
            Assert.AreEqual(false, result.BindingDescriptions[0].Required);

            Assert.AreEqual("String", result.BindingDescriptions[0].BoundAttributeType.DataType);
            Assert.AreEqual(false, result.BindingDescriptions[0].BoundAttributeType.Multivalued);
            Assert.AreEqual("Account Name", result.BindingDescriptions[0].BoundAttributeType.DisplayName);
            Assert.AreEqual("User's log on name", result.BindingDescriptions[0].BoundAttributeType.Description);
            Assert.AreEqual(null, result.BindingDescriptions[0].BoundAttributeType.IntegerMaximum);
            Assert.AreEqual(null, result.BindingDescriptions[0].BoundAttributeType.IntegerMinimum);
            Assert.AreEqual("AccountName", result.BindingDescriptions[0].BoundAttributeType.Name);
            Assert.AreEqual(null, result.BindingDescriptions[0].BoundAttributeType.StringRegex);
            Assert.AreEqual("Microsoft.ResourceManagement.WebServices", result.BindingDescriptions[0].BoundAttributeType.UsageKeyword[0]);

            Assert.AreEqual("Reference", result.BindingDescriptions[expectedBindingCount -1].BoundAttributeType.DataType);
            Assert.AreEqual(false, result.BindingDescriptions[expectedBindingCount -1].BoundAttributeType.Multivalued);
            Assert.AreEqual("Time Zone", result.BindingDescriptions[expectedBindingCount -1].BoundAttributeType.DisplayName);
            Assert.AreEqual("Reference to timezone configuration", result.BindingDescriptions[expectedBindingCount -1].BoundAttributeType.Description);
            Assert.AreEqual(null, result.BindingDescriptions[expectedBindingCount -1].BoundAttributeType.IntegerMaximum);
            Assert.AreEqual(null, result.BindingDescriptions[expectedBindingCount -1].BoundAttributeType.IntegerMinimum);
            Assert.AreEqual("TimeZone", result.BindingDescriptions[expectedBindingCount -1].BoundAttributeType.Name);
            Assert.AreEqual(null, result.BindingDescriptions[expectedBindingCount -1].BoundAttributeType.StringRegex);
            Assert.AreEqual("Microsoft.ResourceManagement.WebServices", result.BindingDescriptions[expectedBindingCount -1].BoundAttributeType.UsageKeyword[0]);
        
        }


        [TestMethod]
        [TestCategory("Integration")]
        public async Task It_can_do_SELECT_STAR_FROM_blah_like_in_SQL()
        {
            // Arrange
            var it = IdmNetClientFactory.BuildClient();

            // Act
            var result =
                await
                    it.SearchAsync(new SearchCriteria
                    {
                        Filter = new Filter("/ObjectTypeDescription"),
                        Selection = new List<string> {"*"}
                    });

            // Assert
            var actual = result.ToArray();
            Assert.IsTrue(actual.Length >= 40);
            Assert.AreEqual("Activity Information Configuration", actual[0].DisplayName);
            Assert.AreEqual("ObjectTypeDescription", actual[0].ObjectType);
            Assert.AreEqual("11/5/2014 9:19:55 AM", actual[0].CreatedTime.ToString());
            Assert.AreEqual(null, actual[0].Creator);
            Assert.AreEqual("This resource drives the appearance of an activity in FIM Portal.", actual[0].Description);
            Assert.AreEqual("ActivityInformationConfiguration", actual[0].GetAttrValue("Name"));
            Assert.AreEqual("Microsoft.ResourceManagement.WebServices", actual[0].GetAttrValue("UsageKeyword"));
        }


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
