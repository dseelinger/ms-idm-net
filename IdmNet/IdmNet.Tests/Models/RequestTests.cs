using System;
using System.Collections.Generic;
using IdmNet.Models;
using Xunit;
using FluentAssertions;
// ReSharper disable ObjectCreationAsStatement
// ReSharper disable UseObjectOrCollectionInitializer

namespace IdmNet.Models.Tests
{
    public class RequestTests
    {
        private Request _it;

        public RequestTests()
        {
            _it = new Request();
        }

        [Fact]
        public void It_has_a_paremeterless_constructor()
        {
            _it.ObjectType.Should().Be("Request");
        }

        [Fact]
        public void It_has_a_constructor_that_takes_an_IdmResource()
        {
            var resource = new IdmResource
            {
                DisplayName = "My Display Name",
                Creator = new Person { DisplayName = "Creator Display Name", ObjectID = "Creator ObjectID"},
            };
            var it = new Request(resource);

            it.ObjectType.Should().Be("Request");
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
            var it = new Request(resource);

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
        public void It_has_ActionWorkflowInstance_which_is_an_empty_collection_by_default()
        {
            // Assert
            _it.ActionWorkflowInstance.Should().BeEmpty();
        }

        [Fact]
        public void It_has_ActionWorkflowInstance_which_as_a_collection_cannot_be_set_to_null()
        {
            // Assert
            Action action = () => _it.ActionWorkflowInstance = null;
            action.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void It_can_get_and_set_ActionWorkflowInstance()
        {
            // Arrange
            var list = new List<WorkflowInstance>
            {
                new WorkflowInstance { DisplayName = "Test WorkflowInstance1", ObjectID = "guid1" },
                new WorkflowInstance { DisplayName = "Test WorkflowInstance2", ObjectID = "guid2" }
            };

            // Act
            _it.ActionWorkflowInstance = list;

            // Assert
            _it.ActionWorkflowInstance[0].DisplayName.Should().Be(list[0].DisplayName);
            _it.ActionWorkflowInstance[1].DisplayName.Should().Be(list[1].DisplayName);
        }

        [Fact]
        public void It_has_AuthenticationWorkflowInstance_which_is_an_empty_collection_by_default()
        {
            // Assert
            _it.AuthenticationWorkflowInstance.Should().BeEmpty();
        }

        [Fact]
        public void It_has_AuthenticationWorkflowInstance_which_as_a_collection_cannot_be_set_to_null()
        {
            // Assert
            Action action = () => _it.AuthenticationWorkflowInstance = null;
            action.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void It_can_get_and_set_AuthenticationWorkflowInstance()
        {
            // Arrange
            var list = new List<WorkflowInstance>
            {
                new WorkflowInstance { DisplayName = "Test WorkflowInstance1", ObjectID = "guid1" },
                new WorkflowInstance { DisplayName = "Test WorkflowInstance2", ObjectID = "guid2" }
            };

            // Act
            _it.AuthenticationWorkflowInstance = list;

            // Assert
            _it.AuthenticationWorkflowInstance[0].DisplayName.Should().Be(list[0].DisplayName);
            _it.AuthenticationWorkflowInstance[1].DisplayName.Should().Be(list[1].DisplayName);
        }

        [Fact]
        public void It_has_AuthorizationWorkflowInstance_which_is_an_empty_collection_by_default()
        {
            // Assert
            _it.AuthorizationWorkflowInstance.Should().BeEmpty();
        }

        [Fact]
        public void It_has_AuthorizationWorkflowInstance_which_as_a_collection_cannot_be_set_to_null()
        {
            // Assert
            Action action = () => _it.AuthorizationWorkflowInstance = null;
            action.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void It_can_get_and_set_AuthorizationWorkflowInstance()
        {
            // Arrange
            var list = new List<WorkflowInstance>
            {
                new WorkflowInstance { DisplayName = "Test WorkflowInstance1", ObjectID = "guid1" },
                new WorkflowInstance { DisplayName = "Test WorkflowInstance2", ObjectID = "guid2" }
            };

            // Act
            _it.AuthorizationWorkflowInstance = list;

            // Assert
            _it.AuthorizationWorkflowInstance[0].DisplayName.Should().Be(list[0].DisplayName);
            _it.AuthorizationWorkflowInstance[1].DisplayName.Should().Be(list[1].DisplayName);
        }

        [Fact]
        public void It_has_CommittedTime_which_is_null_by_default()
        {
            // Assert
            _it.CommittedTime.Should().Be(null);
        }

        [Fact]
        public void It_has_CommittedTime_which_can_be_set_back_to_null()
        {
            // Arrange
            var now = DateTime.Now;
            var testTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);
            _it.CommittedTime = testTime;

            // Act
            _it.CommittedTime = null;

            // Assert
            _it.CommittedTime.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_CommittedTime()
        {
            // Act
            var now = DateTime.Now;
            var testTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);
            _it.CommittedTime = testTime;

            // Assert
            _it.CommittedTime.Should().Be(testTime);
        }


        [Fact]
        public void It_has_msidmCompletedTime_which_is_null_by_default()
        {
            // Assert
            _it.msidmCompletedTime.Should().Be(null);
        }

        [Fact]
        public void It_has_msidmCompletedTime_which_can_be_set_back_to_null()
        {
            // Arrange
            var now = DateTime.Now;
            var testTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);
            _it.msidmCompletedTime = testTime;

            // Act
            _it.msidmCompletedTime = null;

            // Assert
            _it.msidmCompletedTime.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_msidmCompletedTime()
        {
            // Act
            var now = DateTime.Now;
            var testTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);
            _it.msidmCompletedTime = testTime;

            // Assert
            _it.msidmCompletedTime.Should().Be(testTime);
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
        public void It_has_HasCollateralRequest_which_is_null_by_default()
        {
            // Assert
            _it.HasCollateralRequest.Should().Be(null);
        }

        [Fact]
        public void It_has_HasCollateralRequest_which_can_be_set_back_to_null()
        {
            // Arrange
            _it.HasCollateralRequest = true;

            // Act
            _it.HasCollateralRequest = null;

            // Assert
            _it.HasCollateralRequest.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_HasCollateralRequest()
        {
            // Act
            _it.HasCollateralRequest = true;

            // Assert
            _it.HasCollateralRequest.Should().Be(true);
        }


        [Fact]
        public void It_has_ManagementPolicy_which_is_an_empty_collection_by_default()
        {
            // Assert
            _it.ManagementPolicy.Should().BeEmpty();
        }

        [Fact]
        public void It_has_ManagementPolicy_which_as_a_collection_cannot_be_set_to_null()
        {
            // Assert
            Action action = () => _it.ManagementPolicy = null;
            action.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void It_can_get_and_set_ManagementPolicy()
        {
            // Arrange
            var list = new List<ManagementPolicyRule>
            {
                new ManagementPolicyRule { DisplayName = "Test ManagementPolicyRule1", ObjectID = "guid1" },
                new ManagementPolicyRule { DisplayName = "Test ManagementPolicyRule2", ObjectID = "guid2" }
            };

            // Act
            _it.ManagementPolicy = list;

            // Assert
            _it.ManagementPolicy[0].DisplayName.Should().Be(list[0].DisplayName);
            _it.ManagementPolicy[1].DisplayName.Should().Be(list[1].DisplayName);
        }

        [Fact]
        public void It_can_get_and_set_Operation()
        {
            // Act
            _it.Operation = "A string";

            // Assert
            _it.Operation.Should().Be("A string");
        }


        [Fact]
        public void It_has_ParentRequest_which_is_null_by_default()
        {
            // Assert
            _it.ParentRequest.Should().Be(null);
        }

        [Fact]
        public void It_has_ParentRequest_which_can_be_set_back_to_null()
        {
            // Arrange
            var testRequest = new Request { DisplayName = "Test Request" };			
            _it.ParentRequest = testRequest; 

            // Act
            _it.ParentRequest = null;

            // Assert
            _it.ParentRequest.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_ParentRequest()
        {
            // Act
			var testRequest = new Request { DisplayName = "Test Request" };			
            _it.ParentRequest = testRequest; 

            // Assert
            _it.ParentRequest.DisplayName.Should().Be(testRequest.DisplayName);
        }


        [Fact]
        public void It_has_msidmRequestContext_which_is_null_by_default()
        {
            // Assert
            _it.msidmRequestContext.Should().Be(null);
        }

        [Fact]
        public void It_has_msidmRequestContext_which_can_be_set_back_to_null()
        {
            // Arrange
            var testmsidmRequestContext = new msidmRequestContext { DisplayName = "Test msidmRequestContext" };			
            _it.msidmRequestContext = testmsidmRequestContext; 

            // Act
            _it.msidmRequestContext = null;

            // Assert
            _it.msidmRequestContext.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_msidmRequestContext()
        {
            // Act
			var testmsidmRequestContext = new msidmRequestContext { DisplayName = "Test msidmRequestContext" };			
            _it.msidmRequestContext = testmsidmRequestContext; 

            // Assert
            _it.msidmRequestContext.DisplayName.Should().Be(testmsidmRequestContext.DisplayName);
        }


        [Fact]
        public void It_can_get_and_set_RequestControl()
        {
            // Act
            _it.RequestControl = "A string";

            // Assert
            _it.RequestControl.Should().Be("A string");
        }


        [Fact]
        public void It_has_RequestParameter_which_is_an_empty_collection_by_default()
        {
            // Assert
            _it.RequestParameter.Should().BeEmpty();
        }

        [Fact]
        public void It_has_RequestParameter_which_as_a_collection_cannot_be_set_to_null()
        {
            // Assert
            Action action = () => _it.RequestParameter = null;
            action.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void It_can_get_and_set_RequestParameter()
        {
            var subObject1 = "foo1";
            var subObject2 = "foo2";
            var list = new List<string> { subObject1, subObject2 };

            // Act
            _it.RequestParameter = list; 

            // Assert
            _it.RequestParameter[0].Should().Be("foo1");
            _it.RequestParameter[1].Should().Be("foo2");
        }


        [Fact]
        public void It_can_get_and_set_RequestStatus()
        {
            // Act
            _it.RequestStatus = "A string";

            // Assert
            _it.RequestStatus.Should().Be("A string");
        }


        [Fact]
        public void It_has_RequestStatusDetail_which_is_an_empty_collection_by_default()
        {
            // Assert
            _it.RequestStatusDetail.Should().BeEmpty();
        }

        [Fact]
        public void It_has_RequestStatusDetail_which_as_a_collection_cannot_be_set_to_null()
        {
            // Assert
            Action action = () => _it.RequestStatusDetail = null;
            action.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void It_can_get_and_set_RequestStatusDetail()
        {
            var subObject1 = "foo1";
            var subObject2 = "foo2";
            var list = new List<string> { subObject1, subObject2 };

            // Act
            _it.RequestStatusDetail = list; 

            // Assert
            _it.RequestStatusDetail[0].Should().Be("foo1");
            _it.RequestStatusDetail[1].Should().Be("foo2");
        }


        [Fact]
        public void It_can_get_and_set_ServicePartitionName()
        {
            // Act
            _it.ServicePartitionName = "A string";

            // Assert
            _it.ServicePartitionName.Should().Be("A string");
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
        public void It_can_get_and_set_TargetObjectType()
        {
            // Act
            _it.TargetObjectType = "A string";

            // Assert
            _it.TargetObjectType.Should().Be("A string");
        }


    }
}
