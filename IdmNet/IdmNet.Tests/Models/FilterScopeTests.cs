using System;
using System.Collections.Generic;
using IdmNet.Models;
using Xunit;
using FluentAssertions;
// ReSharper disable ObjectCreationAsStatement
// ReSharper disable UseObjectOrCollectionInitializer

namespace IdmNet.Models.Tests
{
    public class FilterScopeTests
    {
        private FilterScope _it;

        public FilterScopeTests()
        {
            _it = new FilterScope();
        }

        [Fact]
        public void It_has_a_paremeterless_constructor()
        {
            _it.ObjectType.Should().Be("FilterScope");
        }

        [Fact]
        public void It_has_a_constructor_that_takes_an_IdmResource()
        {
            var resource = new IdmResource
            {
                DisplayName = "My Display Name",
                Creator = new Person { DisplayName = "Creator Display Name", ObjectID = "Creator ObjectID"},
            };
            var it = new FilterScope(resource);

            it.ObjectType.Should().Be("FilterScope");
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
            var it = new FilterScope(resource);

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
        public void It_has_AllowedAttributes_which_is_an_empty_collection_by_default()
        {
            // Assert
            _it.AllowedAttributes.Should().BeEmpty();
        }

        [Fact]
        public void It_has_AllowedAttributes_which_as_a_collection_cannot_be_set_to_null()
        {
            // Assert
            Action action = () => _it.AllowedAttributes = null;
            action.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void It_can_get_and_set_AllowedAttributes()
        {
            // Arrange
            var list = new List<AttributeTypeDescription>
            {
                new AttributeTypeDescription { DisplayName = "Test AttributeTypeDescription1", ObjectID = "guid1" },
                new AttributeTypeDescription { DisplayName = "Test AttributeTypeDescription2", ObjectID = "guid2" }
            };

            // Act
            _it.AllowedAttributes = list;

            // Assert
            _it.AllowedAttributes[0].DisplayName.Should().Be(list[0].DisplayName);
            _it.AllowedAttributes[1].DisplayName.Should().Be(list[1].DisplayName);
        }

        [Fact]
        public void It_has_AllowedMembershipReferences_which_is_an_empty_collection_by_default()
        {
            // Assert
            _it.AllowedMembershipReferences.Should().BeEmpty();
        }

        [Fact]
        public void It_has_AllowedMembershipReferences_which_as_a_collection_cannot_be_set_to_null()
        {
            // Assert
            Action action = () => _it.AllowedMembershipReferences = null;
            action.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void It_can_get_and_set_AllowedMembershipReferences()
        {
            // Arrange
            var list = new List<Set>
            {
                new Set { DisplayName = "Test Set1", ObjectID = "guid1" },
                new Set { DisplayName = "Test Set2", ObjectID = "guid2" }
            };

            // Act
            _it.AllowedMembershipReferences = list;

            // Assert
            _it.AllowedMembershipReferences[0].DisplayName.Should().Be(list[0].DisplayName);
            _it.AllowedMembershipReferences[1].DisplayName.Should().Be(list[1].DisplayName);
        }

    }
}
