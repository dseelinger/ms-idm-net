using System;
using System.Collections.Generic;
using IdmNet.Models;
using Xunit;
using FluentAssertions;
// ReSharper disable ObjectCreationAsStatement
// ReSharper disable UseObjectOrCollectionInitializer

namespace IdmNet.Models.Tests
{
    public class DetectedRuleEntryTests
    {
        private DetectedRuleEntry _it;

        public DetectedRuleEntryTests()
        {
            _it = new DetectedRuleEntry();
        }

        [Fact]
        public void It_has_a_paremeterless_constructor()
        {
            _it.ObjectType.Should().Be("DetectedRuleEntry");
        }

        [Fact]
        public void It_has_a_constructor_that_takes_an_IdmResource()
        {
            var resource = new IdmResource
            {
                DisplayName = "My Display Name",
                Creator = new Person { DisplayName = "Creator Display Name", ObjectID = "Creator ObjectID"},
            };
            var it = new DetectedRuleEntry(resource);

            it.ObjectType.Should().Be("DetectedRuleEntry");
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
            var it = new DetectedRuleEntry(resource);

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
        public void It_can_get_and_set_Connector()
        {
            // Act
            _it.Connector = "A string";

            // Assert
            _it.Connector.Should().Be("A string");
        }


        [Fact]
        public void It_has_ResourceParent_which_is_null_by_default()
        {
            // Assert
            _it.ResourceParent.Should().Be(null);
        }

        [Fact]
        public void It_has_ResourceParent_which_can_be_set_back_to_null()
        {
            // Arrange
            var testIdmResource = new IdmResource { DisplayName = "Test IdmResource" };			
            _it.ResourceParent = testIdmResource; 

            // Act
            _it.ResourceParent = null;

            // Assert
            _it.ResourceParent.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_ResourceParent()
        {
            // Act
			var testIdmResource = new IdmResource { DisplayName = "Test IdmResource" };			
            _it.ResourceParent = testIdmResource; 

            // Assert
            _it.ResourceParent.DisplayName.Should().Be(testIdmResource.DisplayName);
        }


        [Fact]
        public void It_has_SynchronizationRuleID_which_is_null_by_default()
        {
            // Assert
            _it.SynchronizationRuleID.Should().Be(null);
        }

        [Fact]
        public void It_has_SynchronizationRuleID_which_can_be_set_back_to_null()
        {
            // Arrange
            var testSynchronizationRule = new SynchronizationRule { DisplayName = "Test SynchronizationRule" };			
            _it.SynchronizationRuleID = testSynchronizationRule; 

            // Act
            _it.SynchronizationRuleID = null;

            // Assert
            _it.SynchronizationRuleID.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_SynchronizationRuleID()
        {
            // Act
			var testSynchronizationRule = new SynchronizationRule { DisplayName = "Test SynchronizationRule" };			
            _it.SynchronizationRuleID = testSynchronizationRule; 

            // Assert
            _it.SynchronizationRuleID.DisplayName.Should().Be(testSynchronizationRule.DisplayName);
        }


    }
}
