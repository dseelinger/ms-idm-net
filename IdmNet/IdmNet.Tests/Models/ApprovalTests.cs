using System;
using System.Collections.Generic;
using IdmNet.Models;
using Xunit;
using FluentAssertions;
// ReSharper disable ObjectCreationAsStatement
// ReSharper disable UseObjectOrCollectionInitializer

namespace IdmNet.Models.Tests
{
    public class ApprovalTests
    {
        private Approval _it;

        public ApprovalTests()
        {
            _it = new Approval();
        }

        [Fact]
        public void It_has_a_paremeterless_constructor()
        {
            _it.ObjectType.Should().Be("Approval");
        }

        [Fact]
        public void It_has_a_constructor_that_takes_an_IdmResource()
        {
            var resource = new IdmResource
            {
                DisplayName = "My Display Name",
                Creator = new Person { DisplayName = "Creator Display Name", ObjectID = "Creator ObjectID"},
            };
            var it = new Approval(resource);

            it.ObjectType.Should().Be("Approval");
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
            var it = new Approval(resource);

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
        public void It_can_get_and_set_ApprovalDuration()
        {
            // Act
            var now = DateTime.Now;
            var testTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);
            _it.ApprovalDuration = testTime;

            // Assert
            _it.ApprovalDuration.Should().Be(testTime);
        }


        [Fact]
        public void It_has_ApprovalResponse_which_is_an_empty_collection_by_default()
        {
            // Assert
            _it.ApprovalResponse.Should().BeEmpty();
        }

        [Fact]
        public void It_has_ApprovalResponse_which_as_a_collection_cannot_be_set_to_null()
        {
            // Assert
            Action action = () => _it.ApprovalResponse = null;
            action.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void It_can_get_and_set_ApprovalResponse()
        {
            // Arrange
            var list = new List<ApprovalResponse>
            {
                new ApprovalResponse { DisplayName = "Test ApprovalResponse1", ObjectID = "guid1" },
                new ApprovalResponse { DisplayName = "Test ApprovalResponse2", ObjectID = "guid2" }
            };

            // Act
            _it.ApprovalResponse = list;

            // Assert
            _it.ApprovalResponse[0].DisplayName.Should().Be(list[0].DisplayName);
            _it.ApprovalResponse[1].DisplayName.Should().Be(list[1].DisplayName);
        }

        [Fact]
        public void It_can_get_and_set_ApprovalStatus()
        {
            // Act
            _it.ApprovalStatus = "A string";

            // Assert
            _it.ApprovalStatus.Should().Be("A string");
        }


        [Fact]
        public void It_can_get_and_set_ApprovalThreshold()
        {
            // Act
            _it.ApprovalThreshold = 123;

            // Assert
            _it.ApprovalThreshold.Should().Be(123);
        }


        [Fact]
        public void It_has_Approver_which_is_an_empty_collection_by_default()
        {
            // Assert
            _it.Approver.Should().BeEmpty();
        }

        [Fact]
        public void It_has_Approver_which_as_a_collection_cannot_be_set_to_null()
        {
            // Assert
            Action action = () => _it.Approver = null;
            action.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void It_can_get_and_set_Approver()
        {
            // Arrange
            var list = new List<Person>
            {
                new Person { DisplayName = "Test Person1", ObjectID = "guid1" },
                new Person { DisplayName = "Test Person2", ObjectID = "guid2" }
            };

            // Act
            _it.Approver = list;

            // Assert
            _it.Approver[0].DisplayName.Should().Be(list[0].DisplayName);
            _it.Approver[1].DisplayName.Should().Be(list[1].DisplayName);
        }

        [Fact]
        public void It_has_ComputedActor_which_is_an_empty_collection_by_default()
        {
            // Assert
            _it.ComputedActor.Should().BeEmpty();
        }

        [Fact]
        public void It_has_ComputedActor_which_as_a_collection_cannot_be_set_to_null()
        {
            // Assert
            Action action = () => _it.ComputedActor = null;
            action.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void It_can_get_and_set_ComputedActor()
        {
            // Arrange
            var list = new List<IdmResource>
            {
                new IdmResource { DisplayName = "Test IdmResource1", ObjectID = "guid1" },
                new IdmResource { DisplayName = "Test IdmResource2", ObjectID = "guid2" }
            };

            // Act
            _it.ComputedActor = list;

            // Assert
            _it.ComputedActor[0].DisplayName.Should().Be(list[0].DisplayName);
            _it.ComputedActor[1].DisplayName.Should().Be(list[1].DisplayName);
        }

        [Fact]
        public void It_has_EndpointAddress_which_is_an_empty_collection_by_default()
        {
            // Assert
            _it.EndpointAddress.Should().BeEmpty();
        }

        [Fact]
        public void It_has_EndpointAddress_which_as_a_collection_cannot_be_set_to_null()
        {
            // Assert
            Action action = () => _it.EndpointAddress = null;
            action.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void It_can_get_and_set_EndpointAddress()
        {
            var subObject1 = "foo1";
            var subObject2 = "foo2";
            var list = new List<string> { subObject1, subObject2 };

            // Act
            _it.EndpointAddress = list; 

            // Assert
            _it.EndpointAddress[0].Should().Be("foo1");
            _it.EndpointAddress[1].Should().Be("foo2");
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
        public void It_has_WorkflowInstance_which_is_null_by_default()
        {
            // Assert
            _it.WorkflowInstance.Should().Be(null);
        }

        [Fact]
        public void It_has_WorkflowInstance_which_can_be_set_back_to_null()
        {
            // Arrange
            var testWorkflowInstance = new WorkflowInstance { DisplayName = "Test WorkflowInstance" };			
            _it.WorkflowInstance = testWorkflowInstance; 

            // Act
            _it.WorkflowInstance = null;

            // Assert
            _it.WorkflowInstance.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_WorkflowInstance()
        {
            // Act
			var testWorkflowInstance = new WorkflowInstance { DisplayName = "Test WorkflowInstance" };			
            _it.WorkflowInstance = testWorkflowInstance; 

            // Assert
            _it.WorkflowInstance.DisplayName.Should().Be(testWorkflowInstance.DisplayName);
        }


    }
}
