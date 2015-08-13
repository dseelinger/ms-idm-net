using System;
using System.Collections.Generic;
using IdmNet.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable ObjectCreationAsStatement
// ReSharper disable UseObjectOrCollectionInitializer

namespace IdmNet.Models.Tests
{
    [TestClass]
    public class RequestTests
    {
        private Request _it;

        public RequestTests()
        {
            _it = new Request();
        }

        [TestMethod]
        public void It_has_a_paremeterless_constructor()
        {
            Assert.AreEqual("Request", _it.ObjectType);
        }

        [TestMethod]
        public void It_has_a_constructor_that_takes_an_IdmResource()
        {
            var resource = new IdmResource
            {
                DisplayName = "My Display Name",
                Creator = new Person { DisplayName = "Creator Display Name", ObjectID = "Creator ObjectID"},
            };
            var it = new Request(resource);

            Assert.AreEqual("Request", it.ObjectType);
            Assert.AreEqual("My Display Name", it.DisplayName);
            Assert.AreEqual("Creator Display Name", it.Creator.DisplayName);
        }

        [TestMethod]
        public void It_has_a_constructor_that_takes_an_IdmResource_without_Creator()
        {
            var resource = new IdmResource
            {
                DisplayName = "My Display Name",
            };
            var it = new Request(resource);

            Assert.AreEqual("My Display Name", it.DisplayName);
            Assert.IsNull(it.Creator);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void It_throws_when_you_try_to_set_ObjectType_to_anything_other_than_its_primary_ObjectType()
        {
            _it.ObjectType = "Invalid Object Type";
        }

        [TestMethod]
        public void It_has_ActionWorkflowInstance_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.ActionWorkflowInstance);
        }

        [TestMethod]
        public void It_has_ActionWorkflowInstance_which_can_be_set_back_to_null()
        {
            // Arrange
            var list = new List<WorkflowInstance>
            {
                new WorkflowInstance { DisplayName = "Test WorkflowInstance1", ObjectID = "guid1" },
                new WorkflowInstance { DisplayName = "Test WorkflowInstance2", ObjectID = "guid2" }
            };
            _it.ActionWorkflowInstance = list;

            // Act
            _it.ActionWorkflowInstance = null;

            // Assert
            Assert.IsNull(_it.ActionWorkflowInstance);
        }

        [TestMethod]
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
            Assert.AreEqual(list[0].DisplayName, _it.ActionWorkflowInstance[0].DisplayName);
            Assert.AreEqual(list[1].DisplayName, _it.ActionWorkflowInstance[1].DisplayName);
        }


        [TestMethod]
        public void It_has_AuthenticationWorkflowInstance_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.AuthenticationWorkflowInstance);
        }

        [TestMethod]
        public void It_has_AuthenticationWorkflowInstance_which_can_be_set_back_to_null()
        {
            // Arrange
            var list = new List<WorkflowInstance>
            {
                new WorkflowInstance { DisplayName = "Test WorkflowInstance1", ObjectID = "guid1" },
                new WorkflowInstance { DisplayName = "Test WorkflowInstance2", ObjectID = "guid2" }
            };
            _it.AuthenticationWorkflowInstance = list;

            // Act
            _it.AuthenticationWorkflowInstance = null;

            // Assert
            Assert.IsNull(_it.AuthenticationWorkflowInstance);
        }

        [TestMethod]
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
            Assert.AreEqual(list[0].DisplayName, _it.AuthenticationWorkflowInstance[0].DisplayName);
            Assert.AreEqual(list[1].DisplayName, _it.AuthenticationWorkflowInstance[1].DisplayName);
        }


        [TestMethod]
        public void It_has_AuthorizationWorkflowInstance_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.AuthorizationWorkflowInstance);
        }

        [TestMethod]
        public void It_has_AuthorizationWorkflowInstance_which_can_be_set_back_to_null()
        {
            // Arrange
            var list = new List<WorkflowInstance>
            {
                new WorkflowInstance { DisplayName = "Test WorkflowInstance1", ObjectID = "guid1" },
                new WorkflowInstance { DisplayName = "Test WorkflowInstance2", ObjectID = "guid2" }
            };
            _it.AuthorizationWorkflowInstance = list;

            // Act
            _it.AuthorizationWorkflowInstance = null;

            // Assert
            Assert.IsNull(_it.AuthorizationWorkflowInstance);
        }

        [TestMethod]
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
            Assert.AreEqual(list[0].DisplayName, _it.AuthorizationWorkflowInstance[0].DisplayName);
            Assert.AreEqual(list[1].DisplayName, _it.AuthorizationWorkflowInstance[1].DisplayName);
        }


        [TestMethod]
        public void It_has_CommittedTime_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.CommittedTime);
        }

        [TestMethod]
        public void It_has_CommittedTime_which_can_be_set_back_to_null()
        {
            // Arrange
            var now = DateTime.Now;
            var testTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);
            _it.CommittedTime = testTime;

            // Act
            _it.CommittedTime = null;

            // Assert
            Assert.IsNull(_it.CommittedTime);
        }

        [TestMethod]
        public void It_can_get_and_set_CommittedTime()
        {
            // Act
            var now = DateTime.Now;
            var testTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);
            _it.CommittedTime = testTime;

            // Assert
            Assert.AreEqual(testTime, _it.CommittedTime);
        }


        [TestMethod]
        public void It_has_msidmCompletedTime_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.msidmCompletedTime);
        }

        [TestMethod]
        public void It_has_msidmCompletedTime_which_can_be_set_back_to_null()
        {
            // Arrange
            var now = DateTime.Now;
            var testTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);
            _it.msidmCompletedTime = testTime;

            // Act
            _it.msidmCompletedTime = null;

            // Assert
            Assert.IsNull(_it.msidmCompletedTime);
        }

        [TestMethod]
        public void It_can_get_and_set_msidmCompletedTime()
        {
            // Act
            var now = DateTime.Now;
            var testTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);
            _it.msidmCompletedTime = testTime;

            // Assert
            Assert.AreEqual(testTime, _it.msidmCompletedTime);
        }


        [TestMethod]
        public void It_has_ComputedActor_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.ComputedActor);
        }

        [TestMethod]
        public void It_has_ComputedActor_which_can_be_set_back_to_null()
        {
            // Arrange
            var list = new List<IdmResource>
            {
                new IdmResource { DisplayName = "Test IdmResource1", ObjectID = "guid1" },
                new IdmResource { DisplayName = "Test IdmResource2", ObjectID = "guid2" }
            };
            _it.ComputedActor = list;

            // Act
            _it.ComputedActor = null;

            // Assert
            Assert.IsNull(_it.ComputedActor);
        }

        [TestMethod]
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
            Assert.AreEqual(list[0].DisplayName, _it.ComputedActor[0].DisplayName);
            Assert.AreEqual(list[1].DisplayName, _it.ComputedActor[1].DisplayName);
        }


        [TestMethod]
        public void It_has_HasCollateralRequest_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.HasCollateralRequest);
        }

        [TestMethod]
        public void It_has_HasCollateralRequest_which_can_be_set_back_to_null()
        {
            // Arrange
            _it.HasCollateralRequest = true;

            // Act
            _it.HasCollateralRequest = null;

            // Assert
            Assert.IsNull(_it.HasCollateralRequest);
        }

        [TestMethod]
        public void It_can_get_and_set_HasCollateralRequest()
        {
            // Act
            _it.HasCollateralRequest = true;

            // Assert
            Assert.AreEqual(true, _it.HasCollateralRequest);
        }


        [TestMethod]
        public void It_has_ManagementPolicy_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.ManagementPolicy);
        }

        [TestMethod]
        public void It_has_ManagementPolicy_which_can_be_set_back_to_null()
        {
            // Arrange
            var list = new List<ManagementPolicyRule>
            {
                new ManagementPolicyRule { DisplayName = "Test ManagementPolicyRule1", ObjectID = "guid1" },
                new ManagementPolicyRule { DisplayName = "Test ManagementPolicyRule2", ObjectID = "guid2" }
            };
            _it.ManagementPolicy = list;

            // Act
            _it.ManagementPolicy = null;

            // Assert
            Assert.IsNull(_it.ManagementPolicy);
        }

        [TestMethod]
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
            Assert.AreEqual(list[0].DisplayName, _it.ManagementPolicy[0].DisplayName);
            Assert.AreEqual(list[1].DisplayName, _it.ManagementPolicy[1].DisplayName);
        }


        [TestMethod]
        public void It_can_get_and_set_Operation()
        {
            // Act
            _it.Operation = "A string";

            // Assert
            Assert.AreEqual("A string", _it.Operation);
        }


        [TestMethod]
        public void It_has_ParentRequest_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.ParentRequest);
        }

        [TestMethod]
        public void It_has_ParentRequest_which_can_be_set_back_to_null()
        {
            // Arrange
            var testRequest = new Request { DisplayName = "Test Request" };			
            _it.ParentRequest = testRequest; 

            // Act
            _it.ParentRequest = null;

            // Assert
            Assert.IsNull(_it.ParentRequest);
        }

        [TestMethod]
        public void It_can_get_and_set_ParentRequest()
        {
            // Act
			var testRequest = new Request { DisplayName = "Test Request" };			
            _it.ParentRequest = testRequest; 

            // Assert
            Assert.AreEqual(testRequest.DisplayName, _it.ParentRequest.DisplayName);
        }


        [TestMethod]
        public void It_has_msidmRequestContext_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.msidmRequestContext);
        }

        [TestMethod]
        public void It_has_msidmRequestContext_which_can_be_set_back_to_null()
        {
            // Arrange
            var testmsidmRequestContext = new msidmRequestContext { DisplayName = "Test msidmRequestContext" };			
            _it.msidmRequestContext = testmsidmRequestContext; 

            // Act
            _it.msidmRequestContext = null;

            // Assert
            Assert.IsNull(_it.msidmRequestContext);
        }

        [TestMethod]
        public void It_can_get_and_set_msidmRequestContext()
        {
            // Act
			var testmsidmRequestContext = new msidmRequestContext { DisplayName = "Test msidmRequestContext" };			
            _it.msidmRequestContext = testmsidmRequestContext; 

            // Assert
            Assert.AreEqual(testmsidmRequestContext.DisplayName, _it.msidmRequestContext.DisplayName);
        }


        [TestMethod]
        public void It_can_get_and_set_RequestControl()
        {
            // Act
            _it.RequestControl = "A string";

            // Assert
            Assert.AreEqual("A string", _it.RequestControl);
        }


        [TestMethod]
        public void It_has_RequestParameter_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.RequestParameter);
        }

        [TestMethod]
        public void It_has_RequestParameter_which_can_be_set_back_to_null()
        {
            // Arrange
            var subObject1 = "foo1";
            var subObject2 = "foo2";
            var list = new List<string> { subObject1, subObject2 };
            _it.RequestParameter = list; 

            // Act
            _it.RequestParameter = null;

            // Assert
            Assert.IsNull(_it.RequestParameter);
        }

        [TestMethod]
        public void It_can_get_and_set_RequestParameter()
        {
            var subObject1 = "foo1";
            var subObject2 = "foo2";
            var list = new List<string> { subObject1, subObject2 };

            // Act
            _it.RequestParameter = list; 

            // Assert
            Assert.AreEqual("foo1", _it.RequestParameter[0]);
            Assert.AreEqual("foo2", _it.RequestParameter[1]);
        }


        [TestMethod]
        public void It_can_get_and_set_RequestStatus()
        {
            // Act
            _it.RequestStatus = "A string";

            // Assert
            Assert.AreEqual("A string", _it.RequestStatus);
        }


        [TestMethod]
        public void It_has_RequestStatusDetail_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.RequestStatusDetail);
        }

        [TestMethod]
        public void It_has_RequestStatusDetail_which_can_be_set_back_to_null()
        {
            // Arrange
            var subObject1 = "foo1";
            var subObject2 = "foo2";
            var list = new List<string> { subObject1, subObject2 };
            _it.RequestStatusDetail = list; 

            // Act
            _it.RequestStatusDetail = null;

            // Assert
            Assert.IsNull(_it.RequestStatusDetail);
        }

        [TestMethod]
        public void It_can_get_and_set_RequestStatusDetail()
        {
            var subObject1 = "foo1";
            var subObject2 = "foo2";
            var list = new List<string> { subObject1, subObject2 };

            // Act
            _it.RequestStatusDetail = list; 

            // Assert
            Assert.AreEqual("foo1", _it.RequestStatusDetail[0]);
            Assert.AreEqual("foo2", _it.RequestStatusDetail[1]);
        }


        [TestMethod]
        public void It_can_get_and_set_ServicePartitionName()
        {
            // Act
            _it.ServicePartitionName = "A string";

            // Assert
            Assert.AreEqual("A string", _it.ServicePartitionName);
        }


        [TestMethod]
        public void It_has_Target_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.Target);
        }

        [TestMethod]
        public void It_has_Target_which_can_be_set_back_to_null()
        {
            // Arrange
            var testIdmResource = new IdmResource { DisplayName = "Test IdmResource" };			
            _it.Target = testIdmResource; 

            // Act
            _it.Target = null;

            // Assert
            Assert.IsNull(_it.Target);
        }

        [TestMethod]
        public void It_can_get_and_set_Target()
        {
            // Act
			var testIdmResource = new IdmResource { DisplayName = "Test IdmResource" };			
            _it.Target = testIdmResource; 

            // Assert
            Assert.AreEqual(testIdmResource.DisplayName, _it.Target.DisplayName);
        }


        [TestMethod]
        public void It_can_get_and_set_TargetObjectType()
        {
            // Act
            _it.TargetObjectType = "A string";

            // Assert
            Assert.AreEqual("A string", _it.TargetObjectType);
        }


    }
}
