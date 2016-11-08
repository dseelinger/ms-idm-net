using System;
using System.Collections.Generic;
using IdmNet.Models;
using Xunit;
using FluentAssertions;
// ReSharper disable ObjectCreationAsStatement
// ReSharper disable UseObjectOrCollectionInitializer

namespace IdmNet.Models.Tests
{
    public class NavigationBarConfigurationTests
    {
        private NavigationBarConfiguration _it;

        public NavigationBarConfigurationTests()
        {
            _it = new NavigationBarConfiguration();
        }

        [Fact]
        public void It_has_a_paremeterless_constructor()
        {
            _it.ObjectType.Should().Be("NavigationBarConfiguration");
        }

        [Fact]
        public void It_has_a_constructor_that_takes_an_IdmResource()
        {
            var resource = new IdmResource
            {
                DisplayName = "My Display Name",
                Creator = new Person { DisplayName = "Creator Display Name", ObjectID = "Creator ObjectID"},
            };
            var it = new NavigationBarConfiguration(resource);

            it.ObjectType.Should().Be("NavigationBarConfiguration");
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
            var it = new NavigationBarConfiguration(resource);

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
        public void It_can_get_and_set_NavigationUrl()
        {
            // Act
            _it.NavigationUrl = "A string";

            // Assert
            _it.NavigationUrl.Should().Be("A string");
        }


        [Fact]
        public void It_can_get_and_set_Order()
        {
            // Act
            _it.Order = 123;

            // Assert
            _it.Order.Should().Be(123);
        }


        [Fact]
        public void It_can_get_and_set_ParentOrder()
        {
            // Act
            _it.ParentOrder = 123;

            // Assert
            _it.ParentOrder.Should().Be(123);
        }


        [Fact]
        public void It_can_get_and_set_CountXPath()
        {
            // Act
            _it.CountXPath = "A string";

            // Assert
            _it.CountXPath.Should().Be("A string");
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
