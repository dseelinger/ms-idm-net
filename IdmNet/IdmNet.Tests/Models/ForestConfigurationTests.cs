using System;
using System.Collections.Generic;
using IdmNet.Models;
using Xunit;
using FluentAssertions;
// ReSharper disable ObjectCreationAsStatement
// ReSharper disable UseObjectOrCollectionInitializer

namespace IdmNet.Models.Tests
{
    public class ForestConfigurationTests
    {
        private ForestConfiguration _it;

        public ForestConfigurationTests()
        {
            _it = new ForestConfiguration();
        }

        [Fact]
        public void It_has_a_paremeterless_constructor()
        {
            _it.ObjectType.Should().Be("ForestConfiguration");
        }

        [Fact]
        public void It_has_a_constructor_that_takes_an_IdmResource()
        {
            var resource = new IdmResource
            {
                DisplayName = "My Display Name",
                Creator = new Person { DisplayName = "Creator Display Name", ObjectID = "Creator ObjectID"},
            };
            var it = new ForestConfiguration(resource);

            it.ObjectType.Should().Be("ForestConfiguration");
            it.DisplayName.Should().Be("My Display Name");
            it.Creator.DisplayName.Should().Be("Creator Display Name");
        }

        [Fact]
        public void It_has_a_constructor_that_takes_an_IdmResource_without_Creator()
        {
            var resource = new IdmResource
            {
                DisplayName = "My Display Name",
            };
            var it = new ForestConfiguration(resource);

            it.DisplayName.Should().Be("My Display Name");
            it.Creator.Should().Be(null);
        }

        [Fact]
        public void It_throws_when_you_try_to_set_ObjectType_to_anything_other_than_its_primary_ObjectType()
        {
            Action action = () => _it.ObjectType = "Invalid Object Type";
            action.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void It_has_ContactSet_which_is_null_by_default()
        {
            // Assert
            _it.ContactSet.Should().Be(null);
        }

        [Fact]
        public void It_has_ContactSet_which_can_be_set_back_to_null()
        {
            // Arrange
            var testSet = new Set { DisplayName = "Test Set" };			
            _it.ContactSet = testSet; 

            // Act
            _it.ContactSet = null;

            // Assert
            _it.ContactSet.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_ContactSet()
        {
            // Act
			var testSet = new Set { DisplayName = "Test Set" };			
            _it.ContactSet = testSet; 

            // Assert
            _it.ContactSet.DisplayName.Should().Be(testSet.DisplayName);
        }


        [Fact]
        public void It_has_DistributionListDomain_which_is_null_by_default()
        {
            // Assert
            _it.DistributionListDomain.Should().Be(null);
        }

        [Fact]
        public void It_has_DistributionListDomain_which_can_be_set_back_to_null()
        {
            // Arrange
            var testDomainConfiguration = new DomainConfiguration { DisplayName = "Test DomainConfiguration" };			
            _it.DistributionListDomain = testDomainConfiguration; 

            // Act
            _it.DistributionListDomain = null;

            // Assert
            _it.DistributionListDomain.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_DistributionListDomain()
        {
            // Act
			var testDomainConfiguration = new DomainConfiguration { DisplayName = "Test DomainConfiguration" };			
            _it.DistributionListDomain = testDomainConfiguration; 

            // Assert
            _it.DistributionListDomain.DisplayName.Should().Be(testDomainConfiguration.DisplayName);
        }


        [Fact]
        public void It_has_IsConfigurationType_which_is_null_by_default()
        {
            // Assert
            _it.IsConfigurationType.Should().Be(null);
        }

        [Fact]
        public void It_has_IsConfigurationType_which_can_be_set_back_to_null()
        {
            // Arrange
            _it.IsConfigurationType = true;

            // Act
            _it.IsConfigurationType = null;

            // Assert
            _it.IsConfigurationType.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_IsConfigurationType()
        {
            // Act
            _it.IsConfigurationType = true;

            // Assert
            _it.IsConfigurationType.Should().Be(true);
        }


        [Fact]
        public void It_has_TrustedForest_which_is_an_empty_collection_by_default()
        {
            // Assert
            _it.TrustedForest.Should().BeEmpty();
        }

        [Fact]
        public void It_has_TrustedForest_which_as_a_collection_cannot_be_set_to_null()
        {
            // Assert
            Action action = () => _it.TrustedForest = null;
            action.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void It_can_get_and_set_TrustedForest()
        {
            // Arrange
            var list = new List<ForestConfiguration>
            {
                new ForestConfiguration { DisplayName = "Test ForestConfiguration1", ObjectID = "guid1" },
                new ForestConfiguration { DisplayName = "Test ForestConfiguration2", ObjectID = "guid2" }
            };

            // Act
            _it.TrustedForest = list;

            // Assert
            _it.TrustedForest[0].DisplayName.Should().Be(list[0].DisplayName);
            _it.TrustedForest[1].DisplayName.Should().Be(list[1].DisplayName);
        }

    }
}
