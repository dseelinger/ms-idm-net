using System;
using System.Collections.Generic;
using IdmNet.Models;
using Xunit;
using FluentAssertions;
// ReSharper disable ObjectCreationAsStatement
// ReSharper disable UseObjectOrCollectionInitializer

namespace IdmNet.Models.Tests
{
    public class msidmPamConfigurationTests
    {
        private msidmPamConfiguration _it;

        public msidmPamConfigurationTests()
        {
            _it = new msidmPamConfiguration();
        }

        [Fact]
        public void It_has_a_paremeterless_constructor()
        {
            _it.ObjectType.Should().Be("msidmPamConfiguration");
        }

        [Fact]
        public void It_has_a_constructor_that_takes_an_IdmResource()
        {
            var resource = new IdmResource
            {
                DisplayName = "My Display Name",
                Creator = new Person { DisplayName = "Creator Display Name", ObjectID = "Creator ObjectID"},
            };
            var it = new msidmPamConfiguration(resource);

            it.ObjectType.Should().Be("msidmPamConfiguration");
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
            var it = new msidmPamConfiguration(resource);

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
        public void It_can_get_and_set_msidmDefaultADContainer()
        {
            // Act
            _it.msidmDefaultADContainer = "A string";

            // Assert
            _it.msidmDefaultADContainer.Should().Be("A string");
        }


        [Fact]
        public void It_can_get_and_set_msidmPamForestFunctionality()
        {
            // Act
            _it.msidmPamForestFunctionality = "A string";

            // Assert
            _it.msidmPamForestFunctionality.Should().Be("A string");
        }


        [Fact]
        public void It_can_get_and_set_msidmPamPrivUserPrefix()
        {
            // Act
            _it.msidmPamPrivUserPrefix = "A string";

            // Assert
            _it.msidmPamPrivUserPrefix.Should().Be("A string");
        }


        [Fact]
        public void It_can_get_and_set_msidmPamRequestExpirationInDays()
        {
            // Act
            _it.msidmPamRequestExpirationInDays = 123;

            // Assert
            _it.msidmPamRequestExpirationInDays.Should().Be(123);
        }


        [Fact]
        public void It_can_get_and_set_msidmPamRoleDefaultDurationInSeconds()
        {
            // Act
            _it.msidmPamRoleDefaultDurationInSeconds = 123;

            // Assert
            _it.msidmPamRoleDefaultDurationInSeconds.Should().Be(123);
        }


        [Fact]
        public void It_can_get_and_set_msidmPamRoleMaximalDurationInSeconds()
        {
            // Act
            _it.msidmPamRoleMaximalDurationInSeconds = 123;

            // Assert
            _it.msidmPamRoleMaximalDurationInSeconds.Should().Be(123);
        }


        [Fact]
        public void It_can_get_and_set_msidmPamRoleMinimalDurationInSeconds()
        {
            // Act
            _it.msidmPamRoleMinimalDurationInSeconds = 123;

            // Assert
            _it.msidmPamRoleMinimalDurationInSeconds.Should().Be(123);
        }


        [Fact]
        public void It_can_get_and_set_msidmPamUserAdminPasswordLength()
        {
            // Act
            _it.msidmPamUserAdminPasswordLength = 123;

            // Assert
            _it.msidmPamUserAdminPasswordLength.Should().Be(123);
        }


    }
}
