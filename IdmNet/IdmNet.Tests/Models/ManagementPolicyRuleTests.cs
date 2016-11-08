using System;
using System.Collections.Generic;
using IdmNet.Models;
using Xunit;
using FluentAssertions;
// ReSharper disable ObjectCreationAsStatement
// ReSharper disable UseObjectOrCollectionInitializer

namespace IdmNet.Models.Tests
{
    public class ManagementPolicyRuleTests
    {
        private ManagementPolicyRule _it;

        public ManagementPolicyRuleTests()
        {
            _it = new ManagementPolicyRule();
        }

        [Fact]
        public void It_has_a_paremeterless_constructor()
        {
            _it.ObjectType.Should().Be("ManagementPolicyRule");
        }

        [Fact]
        public void It_has_a_constructor_that_takes_an_IdmResource()
        {
            var resource = new IdmResource
            {
                DisplayName = "My Display Name",
                Creator = new Person { DisplayName = "Creator Display Name", ObjectID = "Creator ObjectID"},
            };
            var it = new ManagementPolicyRule(resource);

            it.ObjectType.Should().Be("ManagementPolicyRule");
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
            var it = new ManagementPolicyRule(resource);

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
        public void It_has_ActionParameter_which_is_an_empty_collection_by_default()
        {
            // Assert
            _it.ActionParameter.Should().BeEmpty();
        }

        [Fact]
        public void It_has_ActionParameter_which_as_a_collection_cannot_be_set_to_null()
        {
            // Assert
            Action action = () => _it.ActionParameter = null;
            action.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void It_can_get_and_set_ActionParameter()
        {
            var subObject1 = "foo1";
            var subObject2 = "foo2";
            var list = new List<string> { subObject1, subObject2 };

            // Act
            _it.ActionParameter = list; 

            // Assert
            _it.ActionParameter[0].Should().Be("foo1");
            _it.ActionParameter[1].Should().Be("foo2");
        }


        [Fact]
        public void It_can_get_and_set_ActionType()
        {
            var subObject1 = "foo1";
            var subObject2 = "foo2";
            var list = new List<string> { subObject1, subObject2 };

            // Act
            _it.ActionType = list; 

            // Assert
            _it.ActionType[0].Should().Be("foo1");
            _it.ActionType[1].Should().Be("foo2");
        }


        [Fact]
        public void It_has_ActionWorkflowDefinition_which_is_an_empty_collection_by_default()
        {
            // Assert
            _it.ActionWorkflowDefinition.Should().BeEmpty();
        }

        [Fact]
        public void It_has_ActionWorkflowDefinition_which_as_a_collection_cannot_be_set_to_null()
        {
            // Assert
            Action action = () => _it.ActionWorkflowDefinition = null;
            action.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void It_can_get_and_set_ActionWorkflowDefinition()
        {
            // Arrange
            var list = new List<WorkflowInstance>
            {
                new WorkflowInstance { DisplayName = "Test WorkflowInstance1", ObjectID = "guid1" },
                new WorkflowInstance { DisplayName = "Test WorkflowInstance2", ObjectID = "guid2" }
            };

            // Act
            _it.ActionWorkflowDefinition = list;

            // Assert
            _it.ActionWorkflowDefinition[0].DisplayName.Should().Be(list[0].DisplayName);
            _it.ActionWorkflowDefinition[1].DisplayName.Should().Be(list[1].DisplayName);
        }

        [Fact]
        public void It_has_AuthenticationWorkflowDefinition_which_is_an_empty_collection_by_default()
        {
            // Assert
            _it.AuthenticationWorkflowDefinition.Should().BeEmpty();
        }

        [Fact]
        public void It_has_AuthenticationWorkflowDefinition_which_as_a_collection_cannot_be_set_to_null()
        {
            // Assert
            Action action = () => _it.AuthenticationWorkflowDefinition = null;
            action.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void It_can_get_and_set_AuthenticationWorkflowDefinition()
        {
            // Arrange
            var list = new List<WorkflowDefinition>
            {
                new WorkflowDefinition { DisplayName = "Test WorkflowDefinition1", ObjectID = "guid1" },
                new WorkflowDefinition { DisplayName = "Test WorkflowDefinition2", ObjectID = "guid2" }
            };

            // Act
            _it.AuthenticationWorkflowDefinition = list;

            // Assert
            _it.AuthenticationWorkflowDefinition[0].DisplayName.Should().Be(list[0].DisplayName);
            _it.AuthenticationWorkflowDefinition[1].DisplayName.Should().Be(list[1].DisplayName);
        }

        [Fact]
        public void It_has_AuthorizationWorkflowDefinition_which_is_an_empty_collection_by_default()
        {
            // Assert
            _it.AuthorizationWorkflowDefinition.Should().BeEmpty();
        }

        [Fact]
        public void It_has_AuthorizationWorkflowDefinition_which_as_a_collection_cannot_be_set_to_null()
        {
            // Assert
            Action action = () => _it.AuthorizationWorkflowDefinition = null;
            action.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void It_can_get_and_set_AuthorizationWorkflowDefinition()
        {
            // Arrange
            var list = new List<WorkflowDefinition>
            {
                new WorkflowDefinition { DisplayName = "Test WorkflowDefinition1", ObjectID = "guid1" },
                new WorkflowDefinition { DisplayName = "Test WorkflowDefinition2", ObjectID = "guid2" }
            };

            // Act
            _it.AuthorizationWorkflowDefinition = list;

            // Assert
            _it.AuthorizationWorkflowDefinition[0].DisplayName.Should().Be(list[0].DisplayName);
            _it.AuthorizationWorkflowDefinition[1].DisplayName.Should().Be(list[1].DisplayName);
        }

        [Fact]
        public void It_can_get_and_set_Disabled()
        {
            // Act
            _it.Disabled = true;

            // Assert
            _it.Disabled.Should().Be(true);
        }


        [Fact]
        public void It_can_get_and_set_GrantRight()
        {
            // Act
            _it.GrantRight = true;

            // Assert
            _it.GrantRight.Should().Be(true);
        }


        [Fact]
        public void It_can_get_and_set_ManagementPolicyRuleType()
        {
            // Act
            _it.ManagementPolicyRuleType = "A string";

            // Assert
            _it.ManagementPolicyRuleType.Should().Be("A string");
        }


        [Fact]
        public void It_has_PrincipalSet_which_is_null_by_default()
        {
            // Assert
            _it.PrincipalSet.Should().Be(null);
        }

        [Fact]
        public void It_has_PrincipalSet_which_can_be_set_back_to_null()
        {
            // Arrange
            var testSet = new Set { DisplayName = "Test Set" };			
            _it.PrincipalSet = testSet; 

            // Act
            _it.PrincipalSet = null;

            // Assert
            _it.PrincipalSet.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_PrincipalSet()
        {
            // Act
			var testSet = new Set { DisplayName = "Test Set" };			
            _it.PrincipalSet = testSet; 

            // Assert
            _it.PrincipalSet.DisplayName.Should().Be(testSet.DisplayName);
        }


        [Fact]
        public void It_can_get_and_set_PrincipalRelativeToResource()
        {
            // Act
            _it.PrincipalRelativeToResource = "A string";

            // Assert
            _it.PrincipalRelativeToResource.Should().Be("A string");
        }


        [Fact]
        public void It_has_ResourceCurrentSet_which_is_null_by_default()
        {
            // Assert
            _it.ResourceCurrentSet.Should().Be(null);
        }

        [Fact]
        public void It_has_ResourceCurrentSet_which_can_be_set_back_to_null()
        {
            // Arrange
            var testSet = new Set { DisplayName = "Test Set" };			
            _it.ResourceCurrentSet = testSet; 

            // Act
            _it.ResourceCurrentSet = null;

            // Assert
            _it.ResourceCurrentSet.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_ResourceCurrentSet()
        {
            // Act
			var testSet = new Set { DisplayName = "Test Set" };			
            _it.ResourceCurrentSet = testSet; 

            // Assert
            _it.ResourceCurrentSet.DisplayName.Should().Be(testSet.DisplayName);
        }


        [Fact]
        public void It_has_ResourceFinalSet_which_is_null_by_default()
        {
            // Assert
            _it.ResourceFinalSet.Should().Be(null);
        }

        [Fact]
        public void It_has_ResourceFinalSet_which_can_be_set_back_to_null()
        {
            // Arrange
            var testSet = new Set { DisplayName = "Test Set" };			
            _it.ResourceFinalSet = testSet; 

            // Act
            _it.ResourceFinalSet = null;

            // Assert
            _it.ResourceFinalSet.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_ResourceFinalSet()
        {
            // Act
			var testSet = new Set { DisplayName = "Test Set" };			
            _it.ResourceFinalSet = testSet; 

            // Assert
            _it.ResourceFinalSet.DisplayName.Should().Be(testSet.DisplayName);
        }


    }
}
