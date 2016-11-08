using System;
using System.Collections.Generic;
using IdmNet.Models;
using Xunit;
using FluentAssertions;
// ReSharper disable ObjectCreationAsStatement
// ReSharper disable UseObjectOrCollectionInitializer

namespace IdmNet.Models.Tests
{
    public class AttributeTypeDescriptionTests
    {
        private AttributeTypeDescription _it;

        public AttributeTypeDescriptionTests()
        {
            _it = new AttributeTypeDescription();
        }

        [Fact]
        public void It_has_a_paremeterless_constructor()
        {
            _it.ObjectType.Should().Be("AttributeTypeDescription");
        }

        [Fact]
        public void It_has_a_constructor_that_takes_an_IdmResource()
        {
            var resource = new IdmResource
            {
                DisplayName = "My Display Name",
                Creator = new Person { DisplayName = "Creator Display Name", ObjectID = "Creator ObjectID"},
            };
            var it = new AttributeTypeDescription(resource);

            it.ObjectType.Should().Be("AttributeTypeDescription");
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
            var it = new AttributeTypeDescription(resource);

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
        public void It_can_get_and_set_DataType()
        {
            // Act
            _it.DataType = "A string";

            // Assert
            _it.DataType.Should().Be("A string");
        }


        [Fact]
        public void It_has_IntegerMaximum_which_is_null_by_default()
        {
            // Assert
            _it.IntegerMaximum.Should().Be(null);
        }

        [Fact]
        public void It_has_IntegerMaximum_which_can_be_set_back_to_null()
        {
            // Arrange
            _it.IntegerMaximum = 123;

            // Act
            _it.IntegerMaximum = null;

            // Assert
            _it.IntegerMaximum.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_IntegerMaximum()
        {
            // Act
            _it.IntegerMaximum = 123;

            // Assert
            _it.IntegerMaximum.Should().Be(123);
        }


        [Fact]
        public void It_has_IntegerMinimum_which_is_null_by_default()
        {
            // Assert
            _it.IntegerMinimum.Should().Be(null);
        }

        [Fact]
        public void It_has_IntegerMinimum_which_can_be_set_back_to_null()
        {
            // Arrange
            _it.IntegerMinimum = 123;

            // Act
            _it.IntegerMinimum = null;

            // Assert
            _it.IntegerMinimum.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_IntegerMinimum()
        {
            // Act
            _it.IntegerMinimum = 123;

            // Assert
            _it.IntegerMinimum.Should().Be(123);
        }


        [Fact]
        public void It_has_Localizable_which_is_null_by_default()
        {
            // Assert
            _it.Localizable.Should().Be(null);
        }

        [Fact]
        public void It_has_Localizable_which_can_be_set_back_to_null()
        {
            // Arrange
            _it.Localizable = true;

            // Act
            _it.Localizable = null;

            // Assert
            _it.Localizable.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_Localizable()
        {
            // Act
            _it.Localizable = true;

            // Assert
            _it.Localizable.Should().Be(true);
        }


        [Fact]
        public void It_can_get_and_set_Multivalued()
        {
            // Act
            _it.Multivalued = true;

            // Assert
            _it.Multivalued.Should().Be(true);
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
        public void It_can_get_and_set_StringRegex()
        {
            // Act
            _it.StringRegex = "A string";

            // Assert
            _it.StringRegex.Should().Be("A string");
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
