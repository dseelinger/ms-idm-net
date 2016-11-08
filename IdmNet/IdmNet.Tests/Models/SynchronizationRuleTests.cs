using System;
using System.Collections.Generic;
using IdmNet.Models;
using Xunit;
using FluentAssertions;
// ReSharper disable ObjectCreationAsStatement
// ReSharper disable UseObjectOrCollectionInitializer

namespace IdmNet.Models.Tests
{
    public class SynchronizationRuleTests
    {
        private SynchronizationRule _it;

        public SynchronizationRuleTests()
        {
            _it = new SynchronizationRule();
        }

        [Fact]
        public void It_has_a_paremeterless_constructor()
        {
            _it.ObjectType.Should().Be("SynchronizationRule");
        }

        [Fact]
        public void It_has_a_constructor_that_takes_an_IdmResource()
        {
            var resource = new IdmResource
            {
                DisplayName = "My Display Name",
                Creator = new Person { DisplayName = "Creator Display Name", ObjectID = "Creator ObjectID"},
            };
            var it = new SynchronizationRule(resource);

            it.ObjectType.Should().Be("SynchronizationRule");
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
            var it = new SynchronizationRule(resource);

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
        public void It_can_get_and_set_CreateConnectedSystemObject()
        {
            // Act
            _it.CreateConnectedSystemObject = true;

            // Assert
            _it.CreateConnectedSystemObject.Should().Be(true);
        }


        [Fact]
        public void It_can_get_and_set_CreateILMObject()
        {
            // Act
            _it.CreateILMObject = true;

            // Assert
            _it.CreateILMObject.Should().Be(true);
        }


        [Fact]
        public void It_can_get_and_set_FlowType()
        {
            // Act
            _it.FlowType = 123;

            // Assert
            _it.FlowType.Should().Be(123);
        }


        [Fact]
        public void It_has_Dependency_which_is_null_by_default()
        {
            // Assert
            _it.Dependency.Should().Be(null);
        }

        [Fact]
        public void It_has_Dependency_which_can_be_set_back_to_null()
        {
            // Arrange
            var testSynchronizationRule = new SynchronizationRule { DisplayName = "Test SynchronizationRule" };			
            _it.Dependency = testSynchronizationRule; 

            // Act
            _it.Dependency = null;

            // Assert
            _it.Dependency.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_Dependency()
        {
            // Act
			var testSynchronizationRule = new SynchronizationRule { DisplayName = "Test SynchronizationRule" };			
            _it.Dependency = testSynchronizationRule; 

            // Assert
            _it.Dependency.DisplayName.Should().Be(testSynchronizationRule.DisplayName);
        }


        [Fact]
        public void It_can_get_and_set_DisconnectConnectedSystemObject()
        {
            // Act
            _it.DisconnectConnectedSystemObject = true;

            // Assert
            _it.DisconnectConnectedSystemObject.Should().Be(true);
        }


        [Fact]
        public void It_has_ExistenceTest_which_is_an_empty_collection_by_default()
        {
            // Assert
            _it.ExistenceTest.Should().BeEmpty();
        }

        [Fact]
        public void It_has_ExistenceTest_which_as_a_collection_cannot_be_set_to_null()
        {
            // Assert
            Action action = () => _it.ExistenceTest = null;
            action.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void It_can_get_and_set_ExistenceTest()
        {
            var subObject1 = "foo1";
            var subObject2 = "foo2";
            var list = new List<string> { subObject1, subObject2 };

            // Act
            _it.ExistenceTest = list; 

            // Assert
            _it.ExistenceTest[0].Should().Be("foo1");
            _it.ExistenceTest[1].Should().Be("foo2");
        }


        [Fact]
        public void It_can_get_and_set_ConnectedSystem()
        {
            // Act
            _it.ConnectedSystem = "A string";

            // Assert
            _it.ConnectedSystem.Should().Be("A string");
        }


        [Fact]
        public void It_can_get_and_set_ConnectedObjectType()
        {
            // Act
            _it.ConnectedObjectType = "A string";

            // Assert
            _it.ConnectedObjectType.Should().Be("A string");
        }


        [Fact]
        public void It_can_get_and_set_ConnectedSystemScope()
        {
            // Act
            _it.ConnectedSystemScope = "A string";

            // Assert
            _it.ConnectedSystemScope.Should().Be("A string");
        }


        [Fact]
        public void It_can_get_and_set_ILMObjectType()
        {
            // Act
            _it.ILMObjectType = "A string";

            // Assert
            _it.ILMObjectType.Should().Be("A string");
        }


        [Fact]
        public void It_has_InitialFlow_which_is_an_empty_collection_by_default()
        {
            // Assert
            _it.InitialFlow.Should().BeEmpty();
        }

        [Fact]
        public void It_has_InitialFlow_which_as_a_collection_cannot_be_set_to_null()
        {
            // Assert
            Action action = () => _it.InitialFlow = null;
            action.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void It_can_get_and_set_InitialFlow()
        {
            var subObject1 = "foo1";
            var subObject2 = "foo2";
            var list = new List<string> { subObject1, subObject2 };

            // Act
            _it.InitialFlow = list; 

            // Assert
            _it.InitialFlow[0].Should().Be("foo1");
            _it.InitialFlow[1].Should().Be("foo2");
        }


        [Fact]
        public void It_has_ManagementAgentID_which_is_null_by_default()
        {
            // Assert
            _it.ManagementAgentID.Should().Be(null);
        }

        [Fact]
        public void It_has_ManagementAgentID_which_can_be_set_back_to_null()
        {
            // Arrange
            var testma_data = new ma_data { DisplayName = "Test ma_data" };			
            _it.ManagementAgentID = testma_data; 

            // Act
            _it.ManagementAgentID = null;

            // Assert
            _it.ManagementAgentID.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_ManagementAgentID()
        {
            // Act
			var testma_data = new ma_data { DisplayName = "Test ma_data" };			
            _it.ManagementAgentID = testma_data; 

            // Assert
            _it.ManagementAgentID.DisplayName.Should().Be(testma_data.DisplayName);
        }


        [Fact]
        public void It_has_msidmOutboundIsFilterBased_which_is_null_by_default()
        {
            // Assert
            _it.msidmOutboundIsFilterBased.Should().Be(null);
        }

        [Fact]
        public void It_has_msidmOutboundIsFilterBased_which_can_be_set_back_to_null()
        {
            // Arrange
            _it.msidmOutboundIsFilterBased = true;

            // Act
            _it.msidmOutboundIsFilterBased = null;

            // Assert
            _it.msidmOutboundIsFilterBased.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_msidmOutboundIsFilterBased()
        {
            // Act
            _it.msidmOutboundIsFilterBased = true;

            // Assert
            _it.msidmOutboundIsFilterBased.Should().Be(true);
        }


        [Fact]
        public void It_can_get_and_set_msidmOutboundScopingFilters()
        {
            // Act
            _it.msidmOutboundScopingFilters = "A string";

            // Assert
            _it.msidmOutboundScopingFilters.Should().Be("A string");
        }


        [Fact]
        public void It_has_PersistentFlow_which_is_an_empty_collection_by_default()
        {
            // Assert
            _it.PersistentFlow.Should().BeEmpty();
        }

        [Fact]
        public void It_has_PersistentFlow_which_as_a_collection_cannot_be_set_to_null()
        {
            // Assert
            Action action = () => _it.PersistentFlow = null;
            action.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void It_can_get_and_set_PersistentFlow()
        {
            var subObject1 = "foo1";
            var subObject2 = "foo2";
            var list = new List<string> { subObject1, subObject2 };

            // Act
            _it.PersistentFlow = list; 

            // Assert
            _it.PersistentFlow[0].Should().Be("foo1");
            _it.PersistentFlow[1].Should().Be("foo2");
        }


        [Fact]
        public void It_has_Precedence_which_is_null_by_default()
        {
            // Assert
            _it.Precedence.Should().Be(null);
        }

        [Fact]
        public void It_has_Precedence_which_can_be_set_back_to_null()
        {
            // Arrange
            _it.Precedence = 123;

            // Act
            _it.Precedence = null;

            // Assert
            _it.Precedence.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_Precedence()
        {
            // Act
            _it.Precedence = 123;

            // Assert
            _it.Precedence.Should().Be(123);
        }


        [Fact]
        public void It_can_get_and_set_RelationshipCriteria()
        {
            // Act
            _it.RelationshipCriteria = "A string";

            // Assert
            _it.RelationshipCriteria.Should().Be("A string");
        }


        [Fact]
        public void It_has_SynchronizationRuleParameters_which_is_an_empty_collection_by_default()
        {
            // Assert
            _it.SynchronizationRuleParameters.Should().BeEmpty();
        }

        [Fact]
        public void It_has_SynchronizationRuleParameters_which_as_a_collection_cannot_be_set_to_null()
        {
            // Assert
            Action action = () => _it.SynchronizationRuleParameters = null;
            action.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void It_can_get_and_set_SynchronizationRuleParameters()
        {
            var subObject1 = "foo1";
            var subObject2 = "foo2";
            var list = new List<string> { subObject1, subObject2 };

            // Act
            _it.SynchronizationRuleParameters = list; 

            // Assert
            _it.SynchronizationRuleParameters[0].Should().Be("foo1");
            _it.SynchronizationRuleParameters[1].Should().Be("foo2");
        }


    }
}
