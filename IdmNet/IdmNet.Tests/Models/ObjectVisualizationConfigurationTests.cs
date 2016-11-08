using System;
using System.Collections.Generic;
using IdmNet.Models;
using Xunit;
using FluentAssertions;
// ReSharper disable ObjectCreationAsStatement
// ReSharper disable UseObjectOrCollectionInitializer

namespace IdmNet.Models.Tests
{
    public class ObjectVisualizationConfigurationTests
    {
        private ObjectVisualizationConfiguration _it;

        public ObjectVisualizationConfigurationTests()
        {
            _it = new ObjectVisualizationConfiguration();
        }

        [Fact]
        public void It_has_a_paremeterless_constructor()
        {
            _it.ObjectType.Should().Be("ObjectVisualizationConfiguration");
        }

        [Fact]
        public void It_has_a_constructor_that_takes_an_IdmResource()
        {
            var resource = new IdmResource
            {
                DisplayName = "My Display Name",
                Creator = new Person { DisplayName = "Creator Display Name", ObjectID = "Creator ObjectID"},
            };
            var it = new ObjectVisualizationConfiguration(resource);

            it.ObjectType.Should().Be("ObjectVisualizationConfiguration");
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
            var it = new ObjectVisualizationConfiguration(resource);

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
        public void It_can_get_and_set_AppliesToCreate()
        {
            // Act
            _it.AppliesToCreate = true;

            // Assert
            _it.AppliesToCreate.Should().Be(true);
        }


        [Fact]
        public void It_can_get_and_set_AppliesToEdit()
        {
            // Act
            _it.AppliesToEdit = true;

            // Assert
            _it.AppliesToEdit.Should().Be(true);
        }


        [Fact]
        public void It_can_get_and_set_AppliesToView()
        {
            // Act
            _it.AppliesToView = true;

            // Assert
            _it.AppliesToView.Should().Be(true);
        }


        [Fact]
        public void It_can_get_and_set_ConfigurationData()
        {
            // Act
            _it.ConfigurationData = "A string";

            // Assert
            _it.ConfigurationData.Should().Be("A string");
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
        public void It_can_get_and_set_StringResources()
        {
            // Act
            _it.StringResources = "A string";

            // Assert
            _it.StringResources.Should().Be("A string");
        }


        [Fact]
        public void It_can_get_and_set_TargetObjectType()
        {
            // Act
            _it.TargetObjectType = "A string";

            // Assert
            _it.TargetObjectType.Should().Be("A string");
        }


    }
}
