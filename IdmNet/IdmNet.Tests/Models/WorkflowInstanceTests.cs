using System;
using System.Collections.Generic;
using IdmNet.Models;
using Xunit;
using FluentAssertions;
// ReSharper disable ObjectCreationAsStatement
// ReSharper disable UseObjectOrCollectionInitializer

namespace IdmNet.Models.Tests
{
    public class WorkflowInstanceTests
    {
        private WorkflowInstance _it;

        public WorkflowInstanceTests()
        {
            _it = new WorkflowInstance();
        }

        [Fact]
        public void It_has_a_paremeterless_constructor()
        {
            _it.ObjectType.Should().Be("WorkflowInstance");
        }

        [Fact]
        public void It_has_a_constructor_that_takes_an_IdmResource()
        {
            var resource = new IdmResource
            {
                DisplayName = "My Display Name",
                Creator = new Person { DisplayName = "Creator Display Name", ObjectID = "Creator ObjectID"},
            };
            var it = new WorkflowInstance(resource);

            it.ObjectType.Should().Be("WorkflowInstance");
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
            var it = new WorkflowInstance(resource);

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
        public void It_has_Request_which_is_null_by_default()
        {
            // Assert
            _it.Request.Should().Be(null);
        }

        [Fact]
        public void It_has_Request_which_can_be_set_back_to_null()
        {
            // Arrange
            var testRequest = new Request { DisplayName = "Test Request" };			
            _it.Request = testRequest; 

            // Act
            _it.Request = null;

            // Assert
            _it.Request.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_Request()
        {
            // Act
			var testRequest = new Request { DisplayName = "Test Request" };			
            _it.Request = testRequest; 

            // Assert
            _it.Request.DisplayName.Should().Be(testRequest.DisplayName);
        }


        [Fact]
        public void It_has_Requestor_which_is_null_by_default()
        {
            // Assert
            _it.Requestor.Should().Be(null);
        }

        [Fact]
        public void It_has_Requestor_which_can_be_set_back_to_null()
        {
            // Arrange
            var testIdmResource = new IdmResource { DisplayName = "Test IdmResource" };			
            _it.Requestor = testIdmResource; 

            // Act
            _it.Requestor = null;

            // Assert
            _it.Requestor.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_Requestor()
        {
            // Act
			var testIdmResource = new IdmResource { DisplayName = "Test IdmResource" };			
            _it.Requestor = testIdmResource; 

            // Assert
            _it.Requestor.DisplayName.Should().Be(testIdmResource.DisplayName);
        }


        [Fact]
        public void It_has_Target_which_is_null_by_default()
        {
            // Assert
            _it.Target.Should().Be(null);
        }

        [Fact]
        public void It_has_Target_which_can_be_set_back_to_null()
        {
            // Arrange
            var testIdmResource = new IdmResource { DisplayName = "Test IdmResource" };			
            _it.Target = testIdmResource; 

            // Act
            _it.Target = null;

            // Assert
            _it.Target.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_Target()
        {
            // Act
			var testIdmResource = new IdmResource { DisplayName = "Test IdmResource" };			
            _it.Target = testIdmResource; 

            // Assert
            _it.Target.DisplayName.Should().Be(testIdmResource.DisplayName);
        }


        [Fact]
        public void It_has_WorkflowDefinition_which_is_null_by_default()
        {
            // Assert
            _it.WorkflowDefinition.Should().Be(null);
        }

        [Fact]
        public void It_has_WorkflowDefinition_which_can_be_set_back_to_null()
        {
            // Arrange
            var testWorkflowDefinition = new WorkflowDefinition { DisplayName = "Test WorkflowDefinition" };			
            _it.WorkflowDefinition = testWorkflowDefinition; 

            // Act
            _it.WorkflowDefinition = null;

            // Assert
            _it.WorkflowDefinition.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_WorkflowDefinition()
        {
            // Act
			var testWorkflowDefinition = new WorkflowDefinition { DisplayName = "Test WorkflowDefinition" };			
            _it.WorkflowDefinition = testWorkflowDefinition; 

            // Assert
            _it.WorkflowDefinition.DisplayName.Should().Be(testWorkflowDefinition.DisplayName);
        }


        [Fact]
        public void It_can_get_and_set_WorkflowStatus()
        {
            // Act
            _it.WorkflowStatus = "A string";

            // Assert
            _it.WorkflowStatus.Should().Be("A string");
        }


        [Fact]
        public void It_has_WorkflowStatusDetail_which_is_an_empty_collection_by_default()
        {
            // Assert
            _it.WorkflowStatusDetail.Should().BeEmpty();
        }

        [Fact]
        public void It_has_WorkflowStatusDetail_which_as_a_collection_cannot_be_set_to_null()
        {
            // Assert
            Action action = () => _it.WorkflowStatusDetail = null;
            action.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void It_can_get_and_set_WorkflowStatusDetail()
        {
            var subObject1 = "foo1";
            var subObject2 = "foo2";
            var list = new List<string> { subObject1, subObject2 };

            // Act
            _it.WorkflowStatusDetail = list; 

            // Assert
            _it.WorkflowStatusDetail[0].Should().Be("foo1");
            _it.WorkflowStatusDetail[1].Should().Be("foo2");
        }


    }
}
