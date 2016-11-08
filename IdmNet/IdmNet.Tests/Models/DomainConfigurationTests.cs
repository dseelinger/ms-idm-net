using System;
using System.Collections.Generic;
using IdmNet.Models;
using Xunit;
using FluentAssertions;
// ReSharper disable ObjectCreationAsStatement
// ReSharper disable UseObjectOrCollectionInitializer

namespace IdmNet.Models.Tests
{
    public class DomainConfigurationTests
    {
        private DomainConfiguration _it;

        public DomainConfigurationTests()
        {
            _it = new DomainConfiguration();
        }

        [Fact]
        public void It_has_a_paremeterless_constructor()
        {
            _it.ObjectType.Should().Be("DomainConfiguration");
        }

        [Fact]
        public void It_has_a_constructor_that_takes_an_IdmResource()
        {
            var resource = new IdmResource
            {
                DisplayName = "My Display Name",
                Creator = new Person { DisplayName = "Creator Display Name", ObjectID = "Creator ObjectID"},
            };
            var it = new DomainConfiguration(resource);

            it.ObjectType.Should().Be("DomainConfiguration");
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
            var it = new DomainConfiguration(resource);

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
        public void It_can_get_and_set_Domain()
        {
            // Act
            _it.Domain = "A string";

            // Assert
            _it.Domain.Should().Be("A string");
        }


        [Fact]
        public void It_has_ForeignSecurityPrincipalSet_which_is_null_by_default()
        {
            // Assert
            _it.ForeignSecurityPrincipalSet.Should().Be(null);
        }

        [Fact]
        public void It_has_ForeignSecurityPrincipalSet_which_can_be_set_back_to_null()
        {
            // Arrange
            var testSet = new Set { DisplayName = "Test Set" };			
            _it.ForeignSecurityPrincipalSet = testSet; 

            // Act
            _it.ForeignSecurityPrincipalSet = null;

            // Assert
            _it.ForeignSecurityPrincipalSet.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_ForeignSecurityPrincipalSet()
        {
            // Act
			var testSet = new Set { DisplayName = "Test Set" };			
            _it.ForeignSecurityPrincipalSet = testSet; 

            // Assert
            _it.ForeignSecurityPrincipalSet.DisplayName.Should().Be(testSet.DisplayName);
        }


        [Fact]
        public void It_has_ForestConfiguration_which_is_null_by_default()
        {
            // Assert
            _it.ForestConfiguration.Should().Be(null);
        }

        [Fact]
        public void It_has_ForestConfiguration_which_can_be_set_back_to_null()
        {
            // Arrange
            var testForestConfiguration = new ForestConfiguration { DisplayName = "Test ForestConfiguration" };			
            _it.ForestConfiguration = testForestConfiguration; 

            // Act
            _it.ForestConfiguration = null;

            // Assert
            _it.ForestConfiguration.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_ForestConfiguration()
        {
            // Act
			var testForestConfiguration = new ForestConfiguration { DisplayName = "Test ForestConfiguration" };			
            _it.ForestConfiguration = testForestConfiguration; 

            // Assert
            _it.ForestConfiguration.DisplayName.Should().Be(testForestConfiguration.DisplayName);
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


    }
}
