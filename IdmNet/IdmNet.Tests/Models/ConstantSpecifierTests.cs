using System;
using System.Collections.Generic;
using IdmNet.Models;
using Xunit;
using FluentAssertions;
// ReSharper disable ObjectCreationAsStatement
// ReSharper disable UseObjectOrCollectionInitializer

namespace IdmNet.Models.Tests
{
    public class ConstantSpecifierTests
    {
        private ConstantSpecifier _it;

        public ConstantSpecifierTests()
        {
            _it = new ConstantSpecifier();
        }

        [Fact]
        public void It_has_a_paremeterless_constructor()
        {
            _it.ObjectType.Should().Be("ConstantSpecifier");
        }

        [Fact]
        public void It_has_a_constructor_that_takes_an_IdmResource()
        {
            var resource = new IdmResource
            {
                DisplayName = "My Display Name",
                Creator = new Person { DisplayName = "Creator Display Name", ObjectID = "Creator ObjectID"},
            };
            var it = new ConstantSpecifier(resource);

            it.ObjectType.Should().Be("ConstantSpecifier");
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
            var it = new ConstantSpecifier(resource);

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
        public void It_has_BoundAttributeType_which_is_null_by_default()
        {
            // Assert
            _it.BoundAttributeType.Should().Be(null);
        }

        [Fact]
        public void It_has_BoundAttributeType_which_can_be_set_back_to_null()
        {
            // Arrange
            var testAttributeTypeDescription = new AttributeTypeDescription { DisplayName = "Test AttributeTypeDescription" };			
            _it.BoundAttributeType = testAttributeTypeDescription; 

            // Act
            _it.BoundAttributeType = null;

            // Assert
            _it.BoundAttributeType.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_BoundAttributeType()
        {
            // Act
			var testAttributeTypeDescription = new AttributeTypeDescription { DisplayName = "Test AttributeTypeDescription" };			
            _it.BoundAttributeType = testAttributeTypeDescription; 

            // Assert
            _it.BoundAttributeType.DisplayName.Should().Be(testAttributeTypeDescription.DisplayName);
        }


        [Fact]
        public void It_can_get_and_set_ConstantValueKey()
        {
            // Act
            _it.ConstantValueKey = "A string";

            // Assert
            _it.ConstantValueKey.Should().Be("A string");
        }


        [Fact]
        public void It_has_BoundObjectType_which_is_null_by_default()
        {
            // Assert
            _it.BoundObjectType.Should().Be(null);
        }

        [Fact]
        public void It_has_BoundObjectType_which_can_be_set_back_to_null()
        {
            // Arrange
            var testObjectTypeDescription = new ObjectTypeDescription { DisplayName = "Test ObjectTypeDescription" };			
            _it.BoundObjectType = testObjectTypeDescription; 

            // Act
            _it.BoundObjectType = null;

            // Assert
            _it.BoundObjectType.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_BoundObjectType()
        {
            // Act
			var testObjectTypeDescription = new ObjectTypeDescription { DisplayName = "Test ObjectTypeDescription" };			
            _it.BoundObjectType = testObjectTypeDescription; 

            // Assert
            _it.BoundObjectType.DisplayName.Should().Be(testObjectTypeDescription.DisplayName);
        }


    }
}
