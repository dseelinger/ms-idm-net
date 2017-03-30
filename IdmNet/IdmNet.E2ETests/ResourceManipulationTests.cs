﻿using IdmNet.Models;
using IdmNet.SoapModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.ServiceModel.Channels;
using System.Threading.Tasks;
using System.Xml;
using Xunit;

namespace IdmNet.E2ETests
{
    public class ResourceManipulationTests
    {
        [Fact]
        public async Task T008_It_can_create_objects_in_Identity_Manager()
        {
            // Arrange
            var it = IdmNetClientFactory.BuildClient();
            var newUser = new IdmResource { ObjectType = "Person", DisplayName = "Test User" };

            // Act
            Message createResult = await it.CreateAsync(newUser);

            // assert
            string objectId = it.GetNewObjectId(createResult);
            var result = await it.GetAsync(objectId, new List<string> { "DisplayName" });
            Assert.Equal(newUser.DisplayName, result.DisplayName);

            // afterwards
            await it.DeleteAsync(objectId);
        }

        [Fact]
        public async Task T009_It_can_delete_objects_from_Identity_Manager()
        {
            // Arrange
            var it = IdmNetClientFactory.BuildClient();
            Message toDelete =
                await it.CreateAsync(new IdmResource { ObjectType = "Person", DisplayName = "Test User" });
            var objectId = it.GetNewObjectId(toDelete);

            // Act
            Message result = await it.DeleteAsync(objectId);


            // Assert
            Assert.False(result.IsFault);
            try
            {
                await it.GetAsync(objectId, new List<string> { "DisplayName" });
                Assert.True(false, "Should not make it here");
            }
            catch (KeyNotFoundException)
            {
                // OK
            }
        }

        [Fact]
        public async Task
            T010_It_can_do_a_search_and_return_the_first_page_of_results_and_info_on_retrieving_subsequent_pages_if_any()
        {
            // Arrange
            var it = IdmNetClientFactory.BuildClient();
            var criteria = new SearchCriteria("/ObjectTypeDescription");
            criteria.Selection.Add("DisplayName");

            // Act
            PagedSearchResults result = await it.GetPagedResultsAsync(criteria, 5);

            // Assert
            Assert.Equal("/ObjectTypeDescription", result.PagingContext.Filter);
            Assert.Equal(5, result.PagingContext.CurrentIndex);
            Assert.Equal("Forwards", result.PagingContext.EnumerationDirection);
            Assert.Equal("9999-12-31T23:59:59.9999999", result.PagingContext.Expires);
            Assert.Equal("ObjectID", result.PagingContext.Selection[0]);
            Assert.Equal("ObjectType", result.PagingContext.Selection[1]);
            Assert.Equal("DisplayName", result.PagingContext.Selection[2]);
            Assert.Equal("DisplayName", result.PagingContext.Sorting.SortingAttributes[0].AttributeName);
            Assert.Equal(true, result.PagingContext.Sorting.SortingAttributes[0].Ascending);

            Assert.Equal("ObjectTypeDescription", result.Results[0].ObjectType);
        }

        [Fact]
        public async Task T011_It_can_get_resources_back_from_a_search_a_page_at_a_time()
        {
            // Arrange
            var it = IdmNetClientFactory.BuildClient();
            var criteria = new SearchCriteria("/ObjectTypeDescription");
            criteria.Selection.Add("DisplayName");
            PagedSearchResults pagedSearchResults = await it.GetPagedResultsAsync(criteria, 5);
            PagingContext pagingContext = pagedSearchResults.PagingContext;

            // Act
            var pagedResults = await it.GetPagedResultsAsync(5, pagingContext);

            // Assert
            Assert.Equal(5, pagedResults.Results.Count);
            Assert.True(pagedResults.Results[0].DisplayName.Length > 0);
            Assert.Equal("/ObjectTypeDescription", pagedResults.PagingContext.Filter);
            Assert.Equal(10, pagedResults.PagingContext.CurrentIndex);
            Assert.Equal("Forwards", pagedResults.PagingContext.EnumerationDirection);
            Assert.Equal("9999-12-31T23:59:59.9999999", pagedResults.PagingContext.Expires);
            Assert.Equal("ObjectID", pagedResults.PagingContext.Selection[0]);
            Assert.Equal("ObjectType", pagedResults.PagingContext.Selection[1]);
            Assert.Equal("DisplayName", pagedResults.PagingContext.Selection[2]);
            Assert.Equal("DisplayName", pagedResults.PagingContext.Sorting.SortingAttributes[0].AttributeName);
            Assert.Equal(true, pagedResults.PagingContext.Sorting.SortingAttributes[0].Ascending);

            Assert.Equal(null, pagedResults.EndOfSequence);
            Assert.Equal(true, pagedResults.Items is XmlNode[]);
            Assert.Equal(5, ((XmlNode[])(pagedResults.Items)).Length);
        }

        // Note that the next two tests are currently commented out because I'm not running from a machine that has MIM installed locally.
        // ...Yes, I know - shame on me.
        //[Fact]
        //public async Task T012_It_can_approve_requests()
        //{
        //    // Note: for this test to pass you have to enable the MPRs for Distribution Group Management, and run from a machine with MIM on it.
        //    // Arrange
        //    TestUserInfo ownerUser = null;
        //    TestUserInfo joiningUser = null;
        //    string groupId = "";
        //    try
        //    {
        //        ownerUser = await CreateTestUser("Owner01");
        //        joiningUser = await CreateTestUser("Joiner01");

        //        try
        //        {
        //            groupId = await CreateGroup(ownerUser, "02");

        //            var approvals = await GenerateApproval(joiningUser, groupId);
        //            string fqdn = IdmNetClientFactory.GetEnvironmentSetting("MIM_fqdn");
        //            var ownerClient =
        //                IdmNetClientFactory.BuildClient();


        //            // Act
        //            var result = await ownerClient.ApproveAsync(approvals[0]);

        //            // Assert
        //            // TODO?
        //            //AssertUserIsInGroupNow();
        //        }
        //        finally
        //        {
        //            await DeleteGroup(groupId);
        //        }
        //    }
        //    finally
        //    {
        //        // Afterwards
        //        await DeleteUser(joiningUser);
        //        await DeleteUser(ownerUser);
        //    }
        //}

        //[Fact]
        //public async Task T013_It_can_return_the_approval_objects_associated_with_a_particular_request()
        //{
        //    // Note: for this test to pass you have to enable the MPRs for Distribution Group Management, and run from a machine with MIM on it.
        //    // Arrange
        //    TestUserInfo ownerUser = null;
        //    TestUserInfo joiningUser = null;
        //    string groupId = "";
        //    try
        //    {
        //        ownerUser = await CreateTestUser("Owner01");
        //        joiningUser = await CreateTestUser("Joiner01");

        //        try
        //        {
        //            groupId = await CreateGroup(ownerUser, "02");

        //            // Act
        //            var approvals = await GenerateApproval(joiningUser, groupId);

        //            // Assert
        //            Assert.NotNull(approvals);
        //            Assert.Equal(1, approvals.Count);
        //            Assert.NotNull(approvals[0].EndpointAddress);
        //            Assert.NotNull(approvals[0].WorkflowInstance);

        //        }
        //        finally
        //        {
        //            await DeleteGroup(groupId);
        //        }
        //    }
        //    finally
        //    {
        //        // Afterwards
        //        await DeleteUser(joiningUser);
        //        await DeleteUser(ownerUser);
        //    }
        //}

        [Fact]
        public async Task It_throws_when_ApproveOrReject_is_called_with_a_null_approval()
        {
            // Arrange
            var it = IdmNetClientFactory.BuildClient();

            // Act
            try
            {
                await it.ApproveOrRejectAsync(null, "because I said so", true);
                Assert.True(false, "Should not reach here");
            }
            catch (ArgumentNullException)
            {
                // OK
            }
            // Assert
        }

        [Fact]
        public async Task It_can_return_the_entire_schema_for_a_particular_object_type()
        {
            // Arrange
            var personOid = "6cb7e506-b4b3-4901-8b8c-ff044f14e743";
            var it = IdmNetClientFactory.BuildClient();

            // Act
            Schema result = await it.GetSchemaAsync("Person");

            // Assert
            Assert.Equal("User", result.DisplayName);
            Assert.True(result.CreatedTime >= new DateTime(2010, 1, 1));
            Assert.Equal(null, result.Creator);
            Assert.Equal("This resource defines applicable policies to manage incoming requests. ",
                result.Description);
            Assert.Equal("Person", result.Name);
            Assert.Equal(personOid, result.ObjectID);
            Assert.Equal("ObjectTypeDescription", result.ObjectType);
            Assert.Equal(null, result.ResourceTime);
            Assert.Equal("Microsoft.ResouceManagement.PortalClient", result.UsageKeyword[0]);

            var expectedBindingCount = 59;
            Assert.True(result.BindingDescriptions.Count >= expectedBindingCount);
            for (int i = 0; i < expectedBindingCount; i++)
            {
                Assert.Equal(personOid, result.BindingDescriptions[i].BoundObjectType.ObjectID);
            }
            Assert.Equal("3e04bbbf-014f-413c-8d07-6276cd383be8",
                result.BindingDescriptions[0].BoundAttributeType.ObjectID);
            Assert.Equal(false, result.BindingDescriptions[0].Required);

            Assert.Equal("String", result.BindingDescriptions[0].BoundAttributeType.DataType);
            Assert.Equal(false, result.BindingDescriptions[0].BoundAttributeType.Multivalued);
            Assert.Equal("Account Name", result.BindingDescriptions[0].BoundAttributeType.DisplayName);
            Assert.Equal("User's log on name", result.BindingDescriptions[0].BoundAttributeType.Description);
            Assert.Equal(null, result.BindingDescriptions[0].BoundAttributeType.IntegerMaximum);
            Assert.Equal(null, result.BindingDescriptions[0].BoundAttributeType.IntegerMinimum);
            Assert.Equal("AccountName", result.BindingDescriptions[0].BoundAttributeType.Name);
            Assert.Equal(null, result.BindingDescriptions[0].BoundAttributeType.StringRegex);
            Assert.Equal("Microsoft.ResourceManagement.WebServices",
                result.BindingDescriptions[0].BoundAttributeType.UsageKeyword[0]);
        }

        [Fact]
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
            var pagedResults = await it.GetPagedResultsAsync(5, pagingContext);

            // Assert
            Assert.Equal(5, pagedResults.Results.Count);
            Assert.True(pagedResults.Results[0].DisplayName.Length > 0);

            Assert.Equal(null, pagedResults.EndOfSequence);
            Assert.Equal(true, pagedResults.Items is XmlNode[]);
            Assert.Equal(5, ((XmlNode[])(pagedResults.Items)).Length);
        }

        [Fact]
        public async Task It_throws_an_exception_when_it_encounters_bad_xpath()
        {
            // Arrange
            var it = IdmNetClientFactory.BuildClient();
            var criteria = new SearchCriteria("<3#");

            // Act & Assert
            await Assert.ThrowsAsync<SoapFaultException>(() => it.SearchAsync(criteria));
        }

        [Fact]
        public async Task It_throws_an_exception_when_valid_yet_unknown_xpath_is_searched_for()
        {
            // Arrange
            var it = IdmNetClientFactory.BuildClient();
            var criteria = new SearchCriteria("/foo");

            // Act
            await Assert.ThrowsAsync<SoapFaultException>(() => it.SearchAsync(criteria));
        }

        [Fact]
        public async Task It_throws_when_passing_a_null_resource_to_create()
        {
            // Arrange
            var it = IdmNetClientFactory.BuildClient();

            // Act
            await Assert.ThrowsAsync<ArgumentNullException>(() => it.CreateAsync(null));
        }

        [Fact]
        public async Task It_throws_an_exception_when_trying_to_create_an_invalid_resource()
        {
            // Arrange
            var it = IdmNetClientFactory.BuildClient();

            // Act
            var newUser = new IdmResource();
            await Assert.ThrowsAsync<SoapFaultException>(() => it.CreateAsync(newUser));
        }

        [Fact]
        public async Task It_throws_when_attempting_to_delete_a_null_ObjectID()
        {
            // Arrange
            var it = IdmNetClientFactory.BuildClient();

            // Act
            await Assert.ThrowsAsync<ArgumentNullException>(() => it.DeleteAsync(null));
        }

        [Fact]
        public async Task It_throws_an_exception_when_attempting_to_delete_an_object_that_does_not_exist()
        {
            // Arrange
            var it = IdmNetClientFactory.BuildClient();

            // Act
            await Assert.ThrowsAsync<SoapFaultException>(() => it.DeleteAsync("bad object id"));
        }

        [Fact]
        public async Task It_throws_an_exception_when_you_treat_a_single_valued_attribute_as_if_it_is_multi_valued()
        {
            // Arrange
            const string attrName = "FirstName";
            const string attrValue = "Testing";
            var it = IdmNetClientFactory.BuildClient();
            Message testResource = await CreateTestPerson(it);
            var objectId = it.GetNewObjectId(testResource);

            // Act
            try
            {
                await Assert.ThrowsAsync<SoapFaultException>(() => it.AddValueAsync(objectId, attrName, attrValue));
            }
            finally
            {
                // Afterwards
                await it.DeleteAsync(objectId);
            }

        }

        [Fact]
        public async Task It_can_add_a_value_to_a_multi_valued_attribute_that_already_has_one_or_more_values
            ()
        {
            // Arrange
            const string attrName = "SearchScopeContext";
            const string attrValue = "FirstName";
            var it = IdmNetClientFactory.BuildClient();
            Message testResource = await CreateTestSearchScope(it);
            var objectId = it.GetNewObjectId(testResource);

            // Act
            try
            {
                await it.AddValueAsync(objectId, attrName, attrValue);

                // Assert
                var searchResult =
                    await
                        it.SearchAsync(new SearchCriteria
                        {
                            Filter =
                                new Filter
                                {
                                    Query = "/SearchScopeConfiguration[ObjectID='" + objectId + "']"
                                },
                            Selection = new List<string> { "SearchScopeContext" }
                        });
                Assert.True(searchResult.First().GetAttrValues(attrName).Contains(attrValue));
            }
            finally
            {
                // Afterwards
                await it.DeleteAsync(objectId);
            }
        }

        [Fact]
        public async Task It_can_add_a_value_to_an_empty_multi_valued_attribute()
        {
            // Arrange
            const string attrName = "ProxyAddressCollection";
            const string attrValue = "joecool@nowhere.net";
            var it = IdmNetClientFactory.BuildClient();
            Message testResource = await CreateTestPerson(it);
            var objectId = it.GetNewObjectId(testResource);

            // Act
            try
            {
                await it.AddValueAsync(objectId, attrName, attrValue);

                // Assert
                var searchResult =
                    await
                        it.SearchAsync(new SearchCriteria
                        {
                            Filter =
                                new Filter
                                {
                                    Query = "/Person[ObjectID='" + objectId + "']"
                                },
                            Selection = new List<string> { "ProxyAddressCollection" }
                        });

                Assert.True(searchResult.First().GetAttrValues(attrName).Contains(attrValue));
            }
            finally
            {
                // Afterwards
                await it.DeleteAsync(objectId);
            }
        }

        [Fact]
        public async Task It_can_delete_a_value_from_a_multi_valued_attribute()
        {
            // Arrange
            const string attrName = "ProxyAddressCollection";
            const string attrValue1 = "joecool@nowhere.net";
            const string attrValue2 = "joecool@nowhere.lab";
            var it = IdmNetClientFactory.BuildClient();
            Message testResource = await CreateTestPerson(it);
            var objectId = it.GetNewObjectId(testResource);

            try
            {
                await it.AddValueAsync(objectId, attrName, attrValue1);
                await it.AddValueAsync(objectId, attrName, attrValue2);

                // Act
                Message result = await it.RemoveValueAsync(objectId, attrName, attrValue2);

                // Assert
                Assert.False(result.IsFault);
                var searchResult =
                    await
                        it.SearchAsync(new SearchCriteria
                        {
                            Filter =
                                new Filter
                                {
                                    Query = "/Person[ObjectID='" + objectId + "']"
                                },
                            Selection = new List<string> { "ProxyAddressCollection" }
                        });

                Assert.False(searchResult.First().GetAttrValues(attrName).Contains(attrValue2));
            }
            finally
            {
                // Afterwards
                await it.DeleteAsync(objectId);
            }
        }

        [Fact]
        public async Task It_can_modify_single_valued_attribute_that_was_previously_null()
        {
            // Arrange
            const string attrName = "FirstName";
            const string attrValue = "TestFirstName";
            var it = IdmNetClientFactory.BuildClient();
            Message testResource = await CreateTestPerson(it);
            var objectId = it.GetNewObjectId(testResource);

            try
            {
                // Act
                Message result = await it.ReplaceValueAsync(objectId, attrName, attrValue);

                // Assert
                Assert.False(result.IsFault);
                var searchResult =
                    await
                        it.SearchAsync(new SearchCriteria
                        {
                            Filter =
                                new Filter
                                {
                                    Query = "/Person[ObjectID='" + objectId + "']"
                                },
                            Selection = new List<string> { attrName }
                        });

                Assert.Equal(attrValue, searchResult.First().GetAttrValue(attrName));
            }
            finally
            {
                // Afterwards
                await it.DeleteAsync(objectId);
            }
        }

        [Fact]
        public async Task It_can_modify_a_value_of_a_single_valued_attribute_even_if_it_already_had_a_value()
        {
            await AssertReplaceOk("FirstName", "TestFirstName1", "TestFirstName2");
        }

        [Fact]
        public async Task It_can_remove_a_single_valued_attribute_by_setting_its_value_to_null()
        {
            await AssertReplaceOk("FirstName", "TestFirstName1", null);
        }

        [Fact]
        public async Task It_can_make_a_bunch_of_changes_at_the_same_time_for_a_single_resource()
        {
            // Arrange
            var it = IdmNetClientFactory.BuildClient();
            Message testResource = await CreateTestPerson(it);
            var objectId = it.GetNewObjectId(testResource);
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
                Message result = await it.ChangeMultipleAttrbutes(objectId, changes1);

                // Assert
                Assert.False(result.IsFault);
                var searchResult =
                    await
                        it.SearchAsync(new SearchCriteria
                        {
                            Filter =
                                new Filter
                                {
                                    Query = "/Person[ObjectID='" + objectId + "']"
                                },
                            Selection = new List<string> { "FirstName", "LastName", "ProxyAddressCollection" }
                        });

                var modifiedResource1 = searchResult.First();
                Assert.Equal("FirstNameTest", modifiedResource1.GetAttrValue("FirstName"));
                Assert.Equal("LastNameTest", modifiedResource1.GetAttrValue("LastName"));
                Assert.True(modifiedResource1.GetAttrValues("ProxyAddressCollection").Contains("joe@lab1.lab"));
                Assert.True(modifiedResource1.GetAttrValues("ProxyAddressCollection").Contains("joe@lab2.lab"));
            }
            finally
            {
                // Afterwards
                await it.DeleteAsync(objectId);
            }
        }

        [Fact]
        public async Task It_returns_the_same_number_for_both_GetCount_and_Search()
        {
            // Arrange
            var it = IdmNetClientFactory.BuildClient();
            int count = await it.GetCountAsync("/ConstantSpecifier");

            var searchResults = await it.SearchAsync(new SearchCriteria("/ConstantSpecifier"), 25);

            Assert.Equal(count, searchResults.Count());
        }

        [Fact]
        public async Task It_doesnt_add_superflous_attributes_on_create()
        {
            // Arrange
            var it = IdmNetClientFactory.BuildClient();
            string newObjectId = null;

            try
            {
                var newUser = new IdmResource
                {
                    Attributes = new List<IdmAttribute>
                    {
                        new IdmAttribute {Name = "ObjectType", Values = new List<string> {"Person"}},
                        new IdmAttribute {Name = "ObjectID", Values = new List<string>()},
                        new IdmAttribute {Name = "DisplayName", Values = new List<string> {"_Test User"}},
                    }
                };
                var createResult = await it.CreateAsync(newUser);

                // assert
                newObjectId = it.GetNewObjectId(createResult);
                var result = await it.GetAsync(newObjectId, new List<string> { "DisplayName" });
                Assert.Equal(newUser.DisplayName, result.DisplayName);
            }
            finally
            {
                // afterwards
                await it.DeleteAsync(newObjectId);
            }
            // Act
        }

        [Fact]
        public async Task It_returns_0_records_when_no_records_match_search()
        {
            // Arrange
            var it = IdmNetClientFactory.BuildClient();

            var searchResults = await it.SearchAsync(new SearchCriteria("/Configuration"), 25);

            Assert.Equal(0, searchResults.Count());
        }

        [Fact]
        public async Task It_returns_0_records_when_no_records_match_SELECT_STAR_search()
        {
            // Arrange
            var it = IdmNetClientFactory.BuildClient();

            var searchResults =
                await it.SearchAsync(new SearchCriteria("/Configuration") { Selection = new List<string> { "*" } }, 25);

            Assert.Equal(0, searchResults.Count());
        }

        [Fact]
        public async Task It_throws_an_exception_when_GetAsync_is_called_but_no_match_for_the_object_ID()
        {
            // Arrange
            var it = IdmNetClientFactory.BuildClient();

            // Act
            try
            {
                IdmResource result = await it.GetAsync("c51c9ef3-f00d-4d4e-b30b-c1a18e79c56e", null);
                Assert.True(false, "Should have encountered a KeyNotFoundException");
            }
            catch (KeyNotFoundException)
            {
                // Expected Exception
            }
        }

        [Fact]
        public async Task It_throws_an_exception_when_GetAsync_is_called_but_no_match_for_the_object_ID_and_SELECT_STAR()
        {
            // Arrange
            var it = IdmNetClientFactory.BuildClient();

            // Act
            try
            {
                IdmResource result = await it.GetAsync("c51c9ef3-f00d-4d4e-b30b-c1a18e79c56e", new List<string> { "*" });
                Assert.True(false, "Should have encountered a KeyNotFoundException");
            }
            catch (KeyNotFoundException)
            {
                // Expected Exception
            }
        }

        [Fact]
        public void It_can_return_a_ReferenceResourceProperty_if_one_is_present_in_a_SOAP_Message_string()
        {
            var expectedString = "f7453c35-fda7-4e78-bd9d-b3ae77eaa26c";
            var it = IdmNetClientFactory.BuildClient();

            string result = it.GetResourceReferenceProperty(SoapMessageWithResourceReferenceProperty);

            Assert.Equal(expectedString, result);

        }


        string SoapMessageWithResourceReferenceProperty = @"<s:Envelope xmlns:s=""http://www.w3.org/2003/05/soap-envelope"" xmlns:a=""http://www.w3.org/2005/08/addressing"" xmlns:u=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd"">
  <s:Header>
    <a:Action s:mustUnderstand=""1"" u:Id=""_4"">http://schemas.microsoft.com/2006/11/ResourceManagement/fault</a:Action>
    <a:RelatesTo u:Id=""_5"">urn:uuid:f9fe7758-14c1-43ad-874d-1a18f6e8d017</a:RelatesTo>
    <Context u:Id=""_6"" xmlns=""http://schemas.microsoft.com/ws/2006/05/context"">
      <Property name=""instanceId"">87d409b2-078f-4829-86e8-027f6da74014</Property>
    </Context>
    <o:Security s:mustUnderstand=""1"" xmlns:o=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd"">
      <u:Timestamp u:Id=""uuid-a31177d2-c2f5-40dc-a8de-01891afb2868-15061"">
        <u:Created>2015-09-08T18:32:47.670Z</u:Created>
        <u:Expires>2015-09-08T18:37:47.670Z</u:Expires>
      </u:Timestamp>
      <c:DerivedKeyToken u:Id=""_0"" xmlns:c=""http://schemas.xmlsoap.org/ws/2005/02/sc"">
        <o:SecurityTokenReference>
          <o:Reference URI=""urn:uuid:3b166c57-0a88-4710-bfb7-72a964499994"" ValueType=""http://schemas.xmlsoap.org/ws/2005/02/sc/sct"" />
        </o:SecurityTokenReference>
        <c:Offset>0</c:Offset>
        <c:Length>24</c:Length>
        <c:Nonce>rysUPAQ9dRSHvSmhZA8KiQ==</c:Nonce>
      </c:DerivedKeyToken>
      <c:DerivedKeyToken u:Id=""_1"" xmlns:c=""http://schemas.xmlsoap.org/ws/2005/02/sc"">
        <o:SecurityTokenReference>
          <o:Reference URI=""urn:uuid:3b166c57-0a88-4710-bfb7-72a964499994"" ValueType=""http://schemas.xmlsoap.org/ws/2005/02/sc/sct"" />
        </o:SecurityTokenReference>
        <c:Nonce>eOMgp7/FtvHCOncT4Bt7GQ==</c:Nonce>
      </c:DerivedKeyToken>
      <e:ReferenceList xmlns:e=""http://www.w3.org/2001/04/xmlenc#"">
        <e:DataReference URI=""#_3"" />
        <e:DataReference URI=""#_7"" />
      </e:ReferenceList>
      <e:EncryptedData Id=""_7"" Type=""http://www.w3.org/2001/04/xmlenc#Element"" xmlns:e=""http://www.w3.org/2001/04/xmlenc#"">
        <e:EncryptionMethod Algorithm=""http://www.w3.org/2001/04/xmlenc#aes256-cbc"" />
        <KeyInfo xmlns=""http://www.w3.org/2000/09/xmldsig#"">
          <o:SecurityTokenReference>
            <o:Reference URI=""#_1"" />
          </o:SecurityTokenReference>
        </KeyInfo>
        <e:CipherData>
          <e:CipherValue>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</e:CipherValue>
        </e:CipherData>
      </e:EncryptedData>
    </o:Security>
  </s:Header>
  <s:Body u:Id=""_2"">
    <Fault xmlns=""http://www.w3.org/2003/05/soap-envelope"">
      <Code>
        <Value>Receiver</Value>
        <Subcode>
          <Value xmlns:a=""http://schemas.microsoft.com/2006/11/ResourceManagement"">a:AuthorizationRequiredFault</Value>
        </Subcode>
      </Code>
      <Reason>
        <Text xml:lang=""en-US"">Permission is required</Text>
      </Reason>
      <Detail>
        <AuthorizationRequiredFault xmlns=""http://schemas.microsoft.com/2006/11/ResourceManagement"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
          <EndpointReference xmlns=""http://schemas.xmlsoap.org/ws/2004/08/addressing"">
            <Address>http://fimallinone:5725/ResourceManagementService/Resource</Address>
            <ReferenceProperties>
              <ResourceReferenceProperty xmlns=""http://schemas.microsoft.com/2006/11/ResourceManagement"">urn:uuid:f7453c35-fda7-4e78-bd9d-b3ae77eaa26c</ResourceReferenceProperty>
            </ReferenceProperties>
          </EndpointReference>
        </AuthorizationRequiredFault>
      </Detail>
    </Fault>
  </s:Body>
</s:Envelope>";

        private static async Task<Message> CreateTestPerson(IdmNetClient it)
        {
            return await it.CreateAsync(new IdmResource { ObjectType = "Person", DisplayName = "Test User" });
        }

        private static async Task<Message> CreateTestSearchScope(IdmNetClient it)
        {
            return await it.CreateAsync(new IdmResource
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
            Message testResource = await CreateTestPerson(it);
            var objectId = it.GetNewObjectId(testResource);

            try
            {
                // Act
                await it.ReplaceValueAsync(objectId, attrName, attrValue1);
                await it.ReplaceValueAsync(objectId, attrName, attrValue2);

                // Assert
                var searchResult =
                    await it.SearchAsync(new SearchCriteria
                    {
                        Filter =
                            new Filter
                            {
                                Query = "/Person[ObjectID='" + objectId + "']"
                            },
                        Selection = new List<string> { attrName }
                    });

                Assert.Equal(attrValue2, searchResult.First().GetAttrValue(attrName));
            }
            finally
            {
                // Afterwards
                await it.DeleteAsync(objectId);
            }
        }

        private async Task<Message> AddExplicitMember(TestUserInfo testUser, string groupId)
        {
            string fqdn = IdmNetClientFactory.GetEnvironmentSetting("MIM_fqdn");
            var client =
                IdmNetClientFactory.BuildClient(new IdmConnectionInfo
                {
                    Domain = testUser.Domain,
                    Server = fqdn,
                    Username = testUser.AccountName,
                    Password = testUser.Password
                });

            var testUserObj = await client.GetAsync(testUser.ObjectId, new List<string> { "DisplayName" });


            var msg = await client.AddValueAsync(groupId, "ExplicitMember", testUserObj.ObjectID);
            return msg;
        }

        private async Task<List<Approval>> GenerateApproval(TestUserInfo joiningUser, string groupId)
        {
            var soapMessage = await AddExplicitMember(joiningUser, groupId);
            var it = IdmNetClientFactory.BuildClient();
            var requestId = it.GetResourceReferenceProperty(soapMessage.ToString());
            List<Approval> approvals = await it.GetApprovalsForRequest(requestId);
            return approvals;
        }

        protected async Task<TestUserInfo> CreateTestUser(string disambiguator)
        {
            // Create the user in AD
            var shortDomain = ConfigurationManager.AppSettings["short_domain"];
            var fullDomain = ConfigurationManager.AppSettings["full_domain"];
            var fullDomainLdap = ConfigurationManager.AppSettings["full_domain_ldap"];

            var ouContex = new PrincipalContext(ContextType.Domain, fullDomain, fullDomainLdap);
            string accountName = $"_TU_{disambiguator}";
            var up = new UserPrincipal(ouContex) { SamAccountName = accountName, Enabled = true, DisplayName = accountName };
            up.SetPassword("Password1");
            up.Save(ouContex);

            var user = UserPrincipal.FindByIdentity(ouContex, accountName);
            var sidBytes = new byte[28];
            user?.Sid.GetBinaryForm(sidBytes, 0);

            // Create the user in identity manager
            IdmNetClient idmClient = IdmNetClientFactory.BuildClient();

            var person = new Person
            {
                DisplayName = $"Approval Test User {disambiguator}",
                AccountName = accountName,
                Domain = shortDomain,
                ObjectSID = sidBytes
            };

            var result = await idmClient.CreateAsync(person);
            var objectId = idmClient.GetNewObjectId(result);

            return new TestUserInfo
            {
                AdUser = up,
                DisplayName = person.DisplayName,
                AccountName = person.AccountName,
                Domain = shortDomain,
                Password = "Password1",
                ObjectId = objectId
            };
        }

        protected async Task DeleteUser(TestUserInfo testUser)
        {
            try
            {
                // Delete the user from Identity Manager
                IdmNetClient idmClient = IdmNetClientFactory.BuildClient();
                await idmClient.DeleteAsync(testUser.ObjectId);
            }
            finally
            {
                // Delete the user from AD
                testUser.AdUser.Delete();
            }
        }

        protected async Task<string> CreateGroup(TestUserInfo ownerUser, string disambiguator)
        {
            // Troubleshooting
            ownerUser = new TestUserInfo
            {
                Domain = "FIMDOM",
                ObjectId = "7fb2b853-24f0-4498-9534-4e10589723c4",
                Password = ".....1dM.....",
                DisplayName = "doug",
                AccountName = "doug"
            };

            // Create the user in identity manager
            var shortDomain = ConfigurationManager.AppSettings["short_domain"];
            string fqdn = IdmNetClientFactory.GetEnvironmentSetting("MIM_fqdn");
            var adminClient = IdmNetClientFactory.BuildClient();
            var ownerClient =
                IdmNetClientFactory.BuildClient(new IdmConnectionInfo
                {
                    Domain = ownerUser.Domain,
                    Server = fqdn,
                    Username = ownerUser.AccountName,
                    Password = ownerUser.Password
                });

            // Look up the items needed to construct the group...
            // ...Owner
            var ownerObj =
                await ownerClient.GetAsync(ownerUser.ObjectId, new List<string> { "DisplayName" });
            var owner = new Person(ownerObj);

            // ...Domain Config
            var domainConfigSearch =
                await
                    adminClient.SearchAsync(new SearchCriteria("/DomainConfiguration[DisplayName='" + shortDomain + "']"));
            var domainConfig = new DomainConfiguration(domainConfigSearch.First());

            var fimObj = new Group
            {
                DisplayName = $"Approval Test Group {disambiguator}",
                DisplayedOwner = owner,
                Domain = shortDomain,
                DomainConfiguration = domainConfig,
                MailNickname = "ApprovalTestGroup{disambiguator}",
                ExplicitMember = new List<IdmResource> { owner },
                MembershipAddWorkflow = "Owner Approval",
                MembershipLocked = false,
                Owner = new List<Person> { owner },
                Scope = "Universal",
                Type = "Distribution"
            };

            var result = await ownerClient.CreateAsync(fimObj);
            var objectId = ownerClient.GetNewObjectId(result);
            return objectId;
        }

        protected async Task DeleteGroup(string objectId)
        {
            // Delete the user from Identity Manager
            IdmNetClient idmClient = IdmNetClientFactory.BuildClient();
            await idmClient.DeleteAsync(objectId);
        }
    }
}
