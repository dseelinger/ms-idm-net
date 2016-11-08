using System;
using System.Collections.Generic;
using IdmNet.Models;
using Xunit;
using FluentAssertions;
// ReSharper disable ObjectCreationAsStatement
// ReSharper disable UseObjectOrCollectionInitializer

namespace IdmNet.Models.Tests
{
    public class SetTests
    {
        private Set _it;

        public SetTests()
        {
            _it = new Set();
        }

        [Fact]
        public void It_has_a_paremeterless_constructor()
        {
            _it.ObjectType.Should().Be("Set");
        }

        [Fact]
        public void It_has_a_constructor_that_takes_an_IdmResource()
        {
            var resource = new IdmResource
            {
                DisplayName = "My Display Name",
                Creator = new Person { DisplayName = "Creator Display Name", ObjectID = "Creator ObjectID"},
            };
            var it = new Set(resource);

            it.ObjectType.Should().Be("Set");
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
            var it = new Set(resource);

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
        public void It_has_ComputedMember_which_is_an_empty_collection_by_default()
        {
            // Assert
            _it.ComputedMember.Should().BeEmpty();
        }

        [Fact]
        public void It_has_ComputedMember_which_as_a_collection_cannot_be_set_to_null()
        {
            // Assert
            Action action = () => _it.ComputedMember = null;
            action.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void It_can_get_and_set_ComputedMember()
        {
            // Arrange
            var list = new List<IdmResource>
            {
                new IdmResource { DisplayName = "Test IdmResource1", ObjectID = "guid1" },
                new IdmResource { DisplayName = "Test IdmResource2", ObjectID = "guid2" }
            };

            // Act
            _it.ComputedMember = list;

            // Assert
            _it.ComputedMember[0].DisplayName.Should().Be(list[0].DisplayName);
            _it.ComputedMember[1].DisplayName.Should().Be(list[1].DisplayName);
        }

        [Fact]
        public void It_can_get_and_set_Filter()
        {
            // Act
            _it.Filter = "A string";

            // Assert
            _it.Filter.Should().Be("A string");
        }


        [Fact]
        public void It_has_ExplicitMember_which_is_an_empty_collection_by_default()
        {
            // Assert
            _it.ExplicitMember.Should().BeEmpty();
        }

        [Fact]
        public void It_has_ExplicitMember_which_as_a_collection_cannot_be_set_to_null()
        {
            // Assert
            Action action = () => _it.ExplicitMember = null;
            action.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void It_can_get_and_set_ExplicitMember()
        {
            // Arrange
            var list = new List<IdmResource>
            {
                new IdmResource { DisplayName = "Test IdmResource1", ObjectID = "guid1" },
                new IdmResource { DisplayName = "Test IdmResource2", ObjectID = "guid2" }
            };

            // Act
            _it.ExplicitMember = list;

            // Assert
            _it.ExplicitMember[0].DisplayName.Should().Be(list[0].DisplayName);
            _it.ExplicitMember[1].DisplayName.Should().Be(list[1].DisplayName);
        }

        [Fact]
        public void It_has_Temporal_which_is_null_by_default()
        {
            // Assert
            _it.Temporal.Should().Be(null);
        }

        [Fact]
        public void It_has_Temporal_which_can_be_set_back_to_null()
        {
            // Arrange
            _it.Temporal = true;

            // Act
            _it.Temporal = null;

            // Assert
            _it.Temporal.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_Temporal()
        {
            // Act
            _it.Temporal = true;

            // Assert
            _it.Temporal.Should().Be(true);
        }


    }
}
