using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using IdmNet.SoapModels;
using System.Linq;
using System.Collections.Generic;
using IdmNet.Models;

namespace IdmNet.E2ETests
{
    public class SearchTests
    {
        [Fact]
        public async Task It_can_search_for_resources_without_specifying_a_select_or_sort()
        {
            // Arrange
            IdmNetClient it = IdmNetClientFactory.BuildClient();

            // TODO 001: Test Search Criteria
            // Act
            var results = (await it.SearchAsync(new SearchCriteria("/ObjectTypeDescription"))).ToArray();

            // Assert
            results.Length.Should().BeGreaterOrEqualTo(40);
            Assert.Equal(2, results[0].Attributes.Count);
            Assert.Equal("ObjectTypeDescription", results[0].ObjectType);
            Assert.Equal("ObjectTypeDescription", results[results.Length - 1].ObjectType);
            Assert.Equal("e1a42ced-6968-457c-b5c8-3f9a573295a6".Length, results[0].ObjectID.Length);
            Assert.Equal("e1a42ced-6968-457c-b5c8-3f9a573295a6".Length, results[1].ObjectID.Length);
        }

        [Fact]
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
            Assert.True(results.Length >= 40);
            Assert.Equal(4, results[0].Attributes.Count);
            Assert.True(results[0].DisplayName.Length > 0);
            Assert.True(results[results.Length - 1].DisplayName.Length > 0);
            Assert.Equal("ActivityInformationConfiguration", results[0].GetAttrValue("Name"));
            Assert.True(results[1].GetAttrValue("Name").Length > 0);
        }

        [Fact]
        public async Task T003_It_can_search_for_resources_and_return_all_attributes_with_Select_STAR()
        {
            // Arrange
            var it = IdmNetClientFactory.BuildClient();

            // Act
            var results =
                (await
                    it.SearchAsync(new SearchCriteria("/BindingDescription")
                    {
                        Selection = new List<string> { "*" },
                    })).ToArray();

            // Assert
            Assert.True(results.Length >= 40);
            Assert.Equal(10, results[0].Attributes.Count);
            Assert.Equal("Account Name", results[0].DisplayName);
            Assert.Equal("XOML", results[results.Length - 1].DisplayName);
        }

        [Fact]
        public async Task
            T004_It_can_Search_for_resources_and_Sort_the_results_by_multiple_attributes_in_Ascending_or_Descending_order
            ()
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
            Assert.Equal("e1a42ced-6968-457c-b5c8-3f9a573295a6", bindings[0].BoundObjectType.ObjectID);
            Assert.Equal("e1a42ced-6968-457c-b5c8-3f9a573295a6", bindings[1].BoundObjectType.ObjectID);
            Assert.Equal("e1a42ced-6968-457c-b5c8-3f9a573295a6", bindings[18].BoundObjectType.ObjectID);
            Assert.Equal("e1a42ced-6968-457c-b5c8-3f9a573295a6", bindings[19].BoundObjectType.ObjectID);

            Assert.Equal("c51c9ef3-2de0-4d4e-b30b-c1a18e79c56e", bindings[20].BoundObjectType.ObjectID);

            var attributes = new List<string> { "DisplayName" };
            var objType1 = await it.GetAsync(bindings[0].BoundObjectType.ObjectID, attributes);
            Assert.Equal("Activity Information Configuration", objType1.DisplayName);

            var objType2 = await it.GetAsync(bindings[20].BoundObjectType.ObjectID, attributes);
            Assert.Equal("Approval", objType2.DisplayName);


            // Sub-sort is by attribute type - descending (note that ObjectID appears "before" ActivityName"
            var attributes2 = new List<string> { "Name" };
            var objType3 = await it.GetAsync(bindings[0].BoundAttributeType.ObjectID, attributes2);
            Assert.Equal("TypeName", objType3.GetAttrValue("Name"));

            var objType4 = await it.GetAsync(bindings[1].BoundAttributeType.ObjectID, attributes2);
            Assert.Equal("ResourceTime", objType4.GetAttrValue("Name"));

            var objType6 = await it.GetAsync(bindings[18].BoundAttributeType.ObjectID, attributes2);
            Assert.Equal("ActivityName", objType6.GetAttrValue("Name"));

            var objType5 = await it.GetAsync(bindings[19].BoundAttributeType.ObjectID, attributes2);
            Assert.Equal("ObjectID", objType5.GetAttrValue("Name"));
        }

        [Fact]
        public async Task T005_It_can_get_a_resource_by_its_ObjectID()
        {
            // Arrange
            var it = IdmNetClientFactory.BuildClient();

            // Act
            IdmResource result = await it.GetAsync("c51c9ef3-2de0-4d4e-b30b-c1a18e79c56e", null);

            // Assert
            Assert.Equal("c51c9ef3-2de0-4d4e-b30b-c1a18e79c56e", result.ObjectID);
            Assert.Equal("ObjectTypeDescription", result.ObjectType);
        }

        [Fact]
        public async Task T006_It_can_get_any_or_all_attributes_for_a_resource_by_its_ObjectID()
        {
            // Arrange
            var it = IdmNetClientFactory.BuildClient();

            // Act
            IdmResource result = await it.GetAsync("c51c9ef3-2de0-4d4e-b30b-c1a18e79c56e", new List<string> { "*" });

            // Assert
            Assert.Equal(6, result.Attributes.Count);
            Assert.Equal("c51c9ef3-2de0-4d4e-b30b-c1a18e79c56e", result.ObjectID);
            Assert.Equal("ObjectTypeDescription", result.ObjectType);
            Assert.Equal("Approval", result.DisplayName);
        }

        [Fact]
        public async Task T007_It_can_return_the_number_of_matching_records_for_a_given_search()
        {
            // Arrange
            var it = IdmNetClientFactory.BuildClient();

            // Act
            int result = await it.GetCountAsync("/ConstantSpecifier");

            // Assert
            Assert.Equal(97, result);
        }

    }
}
