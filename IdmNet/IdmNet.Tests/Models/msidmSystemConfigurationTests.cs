using System;
using System.Collections.Generic;
using IdmNet.Models;
using Xunit;
using FluentAssertions;
// ReSharper disable ObjectCreationAsStatement
// ReSharper disable UseObjectOrCollectionInitializer

namespace IdmNet.Models.Tests
{
    public class msidmSystemConfigurationTests
    {
        private msidmSystemConfiguration _it;

        public msidmSystemConfigurationTests()
        {
            _it = new msidmSystemConfiguration();
        }

        [Fact]
        public void It_has_a_paremeterless_constructor()
        {
            _it.ObjectType.Should().Be("msidmSystemConfiguration");
        }

        [Fact]
        public void It_has_a_constructor_that_takes_an_IdmResource()
        {
            var resource = new IdmResource
            {
                DisplayName = "My Display Name",
                Creator = new Person { DisplayName = "Creator Display Name", ObjectID = "Creator ObjectID"},
            };
            var it = new msidmSystemConfiguration(resource);

            it.ObjectType.Should().Be("msidmSystemConfiguration");
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
            var it = new msidmSystemConfiguration(resource);

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
        public void It_has_msidmCreateCriteriaBasedGroupsAsDeferredByDefault_which_is_null_by_default()
        {
            // Assert
            _it.msidmCreateCriteriaBasedGroupsAsDeferredByDefault.Should().Be(null);
        }

        [Fact]
        public void It_has_msidmCreateCriteriaBasedGroupsAsDeferredByDefault_which_can_be_set_back_to_null()
        {
            // Arrange
            _it.msidmCreateCriteriaBasedGroupsAsDeferredByDefault = true;

            // Act
            _it.msidmCreateCriteriaBasedGroupsAsDeferredByDefault = null;

            // Assert
            _it.msidmCreateCriteriaBasedGroupsAsDeferredByDefault.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_msidmCreateCriteriaBasedGroupsAsDeferredByDefault()
        {
            // Act
            _it.msidmCreateCriteriaBasedGroupsAsDeferredByDefault = true;

            // Assert
            _it.msidmCreateCriteriaBasedGroupsAsDeferredByDefault.Should().Be(true);
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
        public void It_can_get_and_set_msidmReportingLoggingEnabled()
        {
            // Act
            _it.msidmReportingLoggingEnabled = true;

            // Assert
            _it.msidmReportingLoggingEnabled.Should().Be(true);
        }


        [Fact]
        public void It_can_get_and_set_msidmRequestMaximumActiveDuration()
        {
            // Act
            _it.msidmRequestMaximumActiveDuration = 123;

            // Assert
            _it.msidmRequestMaximumActiveDuration.Should().Be(123);
        }


        [Fact]
        public void It_can_get_and_set_msidmRequestMaximumCancelingDuration()
        {
            // Act
            _it.msidmRequestMaximumCancelingDuration = 123;

            // Assert
            _it.msidmRequestMaximumCancelingDuration.Should().Be(123);
        }


        [Fact]
        public void It_can_get_and_set_msidmSystemThrottleLevel()
        {
            // Act
            _it.msidmSystemThrottleLevel = 123;

            // Assert
            _it.msidmSystemThrottleLevel.Should().Be(123);
        }


    }
}
