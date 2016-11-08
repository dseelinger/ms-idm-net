using System;
using System.Collections.Generic;
using IdmNet.Models;
using Xunit;
using FluentAssertions;
// ReSharper disable ObjectCreationAsStatement
// ReSharper disable UseObjectOrCollectionInitializer

namespace IdmNet.Models.Tests
{
    public class SynchronizationFilterTests
    {
        private SynchronizationFilter _it;

        public SynchronizationFilterTests()
        {
            _it = new SynchronizationFilter();
        }

        [Fact]
        public void It_has_a_paremeterless_constructor()
        {
            _it.ObjectType.Should().Be("SynchronizationFilter");
        }

        [Fact]
        public void It_has_a_constructor_that_takes_an_IdmResource()
        {
            var resource = new IdmResource
            {
                DisplayName = "My Display Name",
                Creator = new Person { DisplayName = "Creator Display Name", ObjectID = "Creator ObjectID"},
            };
            var it = new SynchronizationFilter(resource);

            it.ObjectType.Should().Be("SynchronizationFilter");
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
            var it = new SynchronizationFilter(resource);

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
        public void It_has_SynchronizeObjectType_which_is_an_empty_collection_by_default()
        {
            // Assert
            _it.SynchronizeObjectType.Should().BeEmpty();
        }

        [Fact]
        public void It_has_SynchronizeObjectType_which_as_a_collection_cannot_be_set_to_null()
        {
            // Assert
            Action action = () => _it.SynchronizeObjectType = null;
            action.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void It_can_get_and_set_SynchronizeObjectType()
        {
            // Arrange
            var list = new List<ObjectTypeDescription>
            {
                new ObjectTypeDescription { DisplayName = "Test ObjectTypeDescription1", ObjectID = "guid1" },
                new ObjectTypeDescription { DisplayName = "Test ObjectTypeDescription2", ObjectID = "guid2" }
            };

            // Act
            _it.SynchronizeObjectType = list;

            // Assert
            _it.SynchronizeObjectType[0].DisplayName.Should().Be(list[0].DisplayName);
            _it.SynchronizeObjectType[1].DisplayName.Should().Be(list[1].DisplayName);
        }

    }
}
