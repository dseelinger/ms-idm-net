using System;
using System.Collections.Generic;
using IdmNet.Models;
using Xunit;
using FluentAssertions;
// ReSharper disable ObjectCreationAsStatement
// ReSharper disable UseObjectOrCollectionInitializer

namespace IdmNet.Models.Tests
{
    public class WorkflowDefinitionTests
    {
        private WorkflowDefinition _it;

        public WorkflowDefinitionTests()
        {
            _it = new WorkflowDefinition();
        }

        [Fact]
        public void It_has_a_paremeterless_constructor()
        {
            _it.ObjectType.Should().Be("WorkflowDefinition");
        }

        [Fact]
        public void It_has_a_constructor_that_takes_an_IdmResource()
        {
            var resource = new IdmResource
            {
                DisplayName = "My Display Name",
                Creator = new Person { DisplayName = "Creator Display Name", ObjectID = "Creator ObjectID"},
            };
            var it = new WorkflowDefinition(resource);

            it.ObjectType.Should().Be("WorkflowDefinition");
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
            var it = new WorkflowDefinition(resource);

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
        public void It_has_ClearRegistration_which_is_null_by_default()
        {
            // Assert
            _it.ClearRegistration.Should().Be(null);
        }

        [Fact]
        public void It_has_ClearRegistration_which_can_be_set_back_to_null()
        {
            // Arrange
            _it.ClearRegistration = true;

            // Act
            _it.ClearRegistration = null;

            // Assert
            _it.ClearRegistration.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_ClearRegistration()
        {
            // Act
            _it.ClearRegistration = true;

            // Assert
            _it.ClearRegistration.Should().Be(true);
        }


        [Fact]
        public void It_can_get_and_set_RequestPhase()
        {
            // Act
            _it.RequestPhase = "A string";

            // Assert
            _it.RequestPhase.Should().Be("A string");
        }


        [Fact]
        public void It_can_get_and_set_Rules()
        {
            // Act
            _it.Rules = "A string";

            // Assert
            _it.Rules.Should().Be("A string");
        }


        [Fact]
        public void It_has_RunOnPolicyUpdate_which_is_null_by_default()
        {
            // Assert
            _it.RunOnPolicyUpdate.Should().Be(null);
        }

        [Fact]
        public void It_has_RunOnPolicyUpdate_which_can_be_set_back_to_null()
        {
            // Arrange
            _it.RunOnPolicyUpdate = true;

            // Act
            _it.RunOnPolicyUpdate = null;

            // Assert
            _it.RunOnPolicyUpdate.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_RunOnPolicyUpdate()
        {
            // Act
            _it.RunOnPolicyUpdate = true;

            // Assert
            _it.RunOnPolicyUpdate.Should().Be(true);
        }


        [Fact]
        public void It_can_get_and_set_XOML()
        {
            // Act
            _it.XOML = "A string";

            // Assert
            _it.XOML.Should().Be("A string");
        }


    }
}
