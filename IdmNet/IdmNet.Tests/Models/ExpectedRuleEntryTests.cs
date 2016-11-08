using System;
using System.Collections.Generic;
using IdmNet.Models;
using Xunit;
using FluentAssertions;
// ReSharper disable ObjectCreationAsStatement
// ReSharper disable UseObjectOrCollectionInitializer

namespace IdmNet.Models.Tests
{
    public class ExpectedRuleEntryTests
    {
        private ExpectedRuleEntry _it;

        public ExpectedRuleEntryTests()
        {
            _it = new ExpectedRuleEntry();
        }

        [Fact]
        public void It_has_a_paremeterless_constructor()
        {
            _it.ObjectType.Should().Be("ExpectedRuleEntry");
        }

        [Fact]
        public void It_has_a_constructor_that_takes_an_IdmResource()
        {
            var resource = new IdmResource
            {
                DisplayName = "My Display Name",
                Creator = new Person { DisplayName = "Creator Display Name", ObjectID = "Creator ObjectID"},
            };
            var it = new ExpectedRuleEntry(resource);

            it.ObjectType.Should().Be("ExpectedRuleEntry");
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
            var it = new ExpectedRuleEntry(resource);

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
        public void It_can_get_and_set_ExpectedRuleEntryAction()
        {
            // Act
            _it.ExpectedRuleEntryAction = "A string";

            // Assert
            _it.ExpectedRuleEntryAction.Should().Be("A string");
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
        public void It_can_get_and_set_StatusError()
        {
            // Act
            _it.StatusError = "A string";

            // Assert
            _it.StatusError.Should().Be("A string");
        }


        [Fact]
        public void It_has_SynchronizationRuleData_which_is_an_empty_collection_by_default()
        {
            // Assert
            _it.SynchronizationRuleData.Should().BeEmpty();
        }

        [Fact]
        public void It_has_SynchronizationRuleData_which_as_a_collection_cannot_be_set_to_null()
        {
            // Assert
            Action action = () => _it.SynchronizationRuleData = null;
            action.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void It_can_get_and_set_SynchronizationRuleData()
        {
            var subObject1 = "foo1";
            var subObject2 = "foo2";
            var list = new List<string> { subObject1, subObject2 };

            // Act
            _it.SynchronizationRuleData = list; 

            // Assert
            _it.SynchronizationRuleData[0].Should().Be("foo1");
            _it.SynchronizationRuleData[1].Should().Be("foo2");
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


        [Fact]
        public void It_can_get_and_set_SynchronizationRuleName()
        {
            // Act
            _it.SynchronizationRuleName = "A string";

            // Assert
            _it.SynchronizationRuleName.Should().Be("A string");
        }


        [Fact]
        public void It_can_get_and_set_SynchronizationRuleStatus()
        {
            // Act
            _it.SynchronizationRuleStatus = "A string";

            // Assert
            _it.SynchronizationRuleStatus.Should().Be("A string");
        }


    }
}
