using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using IdmNet.SoapModels;
using System.Linq;

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
    }
}
