using System;
using System.Collections.Generic;
using IdmNet.Models;
using Xunit;
using FluentAssertions;
// ReSharper disable ObjectCreationAsStatement
// ReSharper disable UseObjectOrCollectionInitializer

namespace IdmNet.Models.Tests
{
    public class ActivityInformationConfigurationTests
    {
        private ActivityInformationConfiguration _it;

        public ActivityInformationConfigurationTests()
        {
            _it = new ActivityInformationConfiguration();
        }

        [Fact]
        public void It_has_a_paremeterless_constructor()
        {
            _it.ObjectType.Should().Be("ActivityInformationConfiguration");
        }

        [Fact]
        public void It_has_a_constructor_that_takes_an_IdmResource()
        {
            var resource = new IdmResource
            {
                DisplayName = "My Display Name",
                Creator = new Person { DisplayName = "Creator Display Name", ObjectID = "Creator ObjectID"},
            };
            var it = new ActivityInformationConfiguration(resource);

            it.ObjectType.Should().Be("ActivityInformationConfiguration");
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
            var it = new ActivityInformationConfiguration(resource);

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
        public void It_can_get_and_set_ActivityName()
        {
            // Act
            _it.ActivityName = "A string";

            // Assert
            _it.ActivityName.Should().Be("A string");
        }


        [Fact]
        public void It_can_get_and_set_AssemblyName()
        {
            // Act
            _it.AssemblyName = "A string";

            // Assert
            _it.AssemblyName.Should().Be("A string");
        }


        [Fact]
        public void It_can_get_and_set_IsActionActivity()
        {
            // Act
            _it.IsActionActivity = true;

            // Assert
            _it.IsActionActivity.Should().Be(true);
        }


        [Fact]
        public void It_can_get_and_set_IsAuthenticationActivity()
        {
            // Act
            _it.IsAuthenticationActivity = true;

            // Assert
            _it.IsAuthenticationActivity.Should().Be(true);
        }


        [Fact]
        public void It_can_get_and_set_IsAuthorizationActivity()
        {
            // Act
            _it.IsAuthorizationActivity = true;

            // Assert
            _it.IsAuthorizationActivity.Should().Be(true);
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
        public void It_can_get_and_set_TypeName()
        {
            // Act
            _it.TypeName = "A string";

            // Assert
            _it.TypeName.Should().Be("A string");
        }


    }
}
