using System;
using System.Collections.Generic;
using IdmNet.Models;
using Xunit;
using FluentAssertions;
// ReSharper disable ObjectCreationAsStatement
// ReSharper disable UseObjectOrCollectionInitializer

namespace IdmNet.Models.Tests
{
    public class ObjectTypeDescriptionTests
    {
        private ObjectTypeDescription _it;

        public ObjectTypeDescriptionTests()
        {
            _it = new ObjectTypeDescription();
        }

        [Fact]
        public void It_has_a_paremeterless_constructor()
        {
            _it.ObjectType.Should().Be("ObjectTypeDescription");
        }

        [Fact]
        public void It_has_a_constructor_that_takes_an_IdmResource()
        {
            var resource = new IdmResource
            {
                DisplayName = "My Display Name",
                Creator = new Person { DisplayName = "Creator Display Name", ObjectID = "Creator ObjectID"},
            };
            var it = new ObjectTypeDescription(resource);

            it.ObjectType.Should().Be("ObjectTypeDescription");
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
            var it = new ObjectTypeDescription(resource);

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
        public void It_can_get_and_set_Name()
        {
            // Act
            _it.Name = "A string";

            // Assert
            _it.Name.Should().Be("A string");
        }


        [Fact]
        public void It_has_UsageKeyword_which_is_an_empty_collection_by_default()
        {
            // Assert
            _it.UsageKeyword.Should().BeEmpty();
        }

        [Fact]
        public void It_has_UsageKeyword_which_as_a_collection_cannot_be_set_to_null()
        {
            // Assert
            Action action = () => _it.UsageKeyword = null;
            action.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void It_can_get_and_set_UsageKeyword()
        {
            var subObject1 = "foo1";
            var subObject2 = "foo2";
            var list = new List<string> { subObject1, subObject2 };

            // Act
            _it.UsageKeyword = list; 

            // Assert
            _it.UsageKeyword[0].Should().Be("foo1");
            _it.UsageKeyword[1].Should().Be("foo2");
        }


    }
}
