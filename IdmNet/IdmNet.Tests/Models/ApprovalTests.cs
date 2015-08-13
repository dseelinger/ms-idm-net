using System;
using System.Collections.Generic;
using IdmNet.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable ObjectCreationAsStatement
// ReSharper disable UseObjectOrCollectionInitializer

namespace IdmNet.Models.Tests
{
    [TestClass]
    public class ApprovalTests
    {
        private Approval _it;

        public ApprovalTests()
        {
            _it = new Approval();
        }

        [TestMethod]
        public void It_has_a_paremeterless_constructor()
        {
            Assert.AreEqual("Approval", _it.ObjectType);
        }

        [TestMethod]
        public void It_has_a_constructor_that_takes_an_IdmResource()
        {
            var resource = new IdmResource
            {
                DisplayName = "My Display Name",
                Creator = new Person { DisplayName = "Creator Display Name", ObjectID = "Creator ObjectID"},
            };
            var it = new Approval(resource);

            Assert.AreEqual("Approval", it.ObjectType);
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
            var it = new Approval(resource);

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
        public void It_can_get_and_set_ApprovalDuration()
        {
            // Act
            var now = DateTime.Now;
            var testTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);
            _it.ApprovalDuration = testTime;

            // Assert
            Assert.AreEqual(testTime, _it.ApprovalDuration);
        }


        [TestMethod]
        public void It_has_ApprovalResponse_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.ApprovalResponse);
        }

        [TestMethod]
        public void It_has_ApprovalResponse_which_can_be_set_back_to_null()
        {
            // Arrange
            var list = new List<ApprovalResponse>
            {
                new ApprovalResponse { DisplayName = "Test ApprovalResponse1", ObjectID = "guid1" },
                new ApprovalResponse { DisplayName = "Test ApprovalResponse2", ObjectID = "guid2" }
            };
            _it.ApprovalResponse = list;

            // Act
            _it.ApprovalResponse = null;

            // Assert
            Assert.IsNull(_it.ApprovalResponse);
        }

        [TestMethod]
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
            Assert.AreEqual(list[0].DisplayName, _it.ApprovalResponse[0].DisplayName);
            Assert.AreEqual(list[1].DisplayName, _it.ApprovalResponse[1].DisplayName);
        }


        [TestMethod]
        public void It_can_get_and_set_ApprovalStatus()
        {
            // Act
            _it.ApprovalStatus = "A string";

            // Assert
            Assert.AreEqual("A string", _it.ApprovalStatus);
        }


        [TestMethod]
        public void It_can_get_and_set_ApprovalThreshold()
        {
            // Act
            _it.ApprovalThreshold = 123;

            // Assert
            Assert.AreEqual(123, _it.ApprovalThreshold);
        }


        [TestMethod]
        public void It_has_Approver_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.Approver);
        }

        [TestMethod]
        public void It_has_Approver_which_can_be_set_back_to_null()
        {
            // Arrange
            var list = new List<Person>
            {
                new Person { DisplayName = "Test Person1", ObjectID = "guid1" },
                new Person { DisplayName = "Test Person2", ObjectID = "guid2" }
            };
            _it.Approver = list;

            // Act
            _it.Approver = null;

            // Assert
            Assert.IsNull(_it.Approver);
        }

        [TestMethod]
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
            Assert.AreEqual(list[0].DisplayName, _it.Approver[0].DisplayName);
            Assert.AreEqual(list[1].DisplayName, _it.Approver[1].DisplayName);
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
        public void It_has_EndpointAddress_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.EndpointAddress);
        }

        [TestMethod]
        public void It_has_EndpointAddress_which_can_be_set_back_to_null()
        {
            // Arrange
            var subObject1 = "foo1";
            var subObject2 = "foo2";
            var list = new List<string> { subObject1, subObject2 };
            _it.EndpointAddress = list; 

            // Act
            _it.EndpointAddress = null;

            // Assert
            Assert.IsNull(_it.EndpointAddress);
        }

        [TestMethod]
        public void It_can_get_and_set_EndpointAddress()
        {
            var subObject1 = "foo1";
            var subObject2 = "foo2";
            var list = new List<string> { subObject1, subObject2 };

            // Act
            _it.EndpointAddress = list; 

            // Assert
            Assert.AreEqual("foo1", _it.EndpointAddress[0]);
            Assert.AreEqual("foo2", _it.EndpointAddress[1]);
        }


        [TestMethod]
        public void It_has_Request_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.Request);
        }

        [TestMethod]
        public void It_has_Request_which_can_be_set_back_to_null()
        {
            // Arrange
            var testRequest = new Request { DisplayName = "Test Request" };			
            _it.Request = testRequest; 

            // Act
            _it.Request = null;

            // Assert
            Assert.IsNull(_it.Request);
        }

        [TestMethod]
        public void It_can_get_and_set_Request()
        {
            // Act
			var testRequest = new Request { DisplayName = "Test Request" };			
            _it.Request = testRequest; 

            // Assert
            Assert.AreEqual(testRequest.DisplayName, _it.Request.DisplayName);
        }


        [TestMethod]
        public void It_has_Requestor_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.Requestor);
        }

        [TestMethod]
        public void It_has_Requestor_which_can_be_set_back_to_null()
        {
            // Arrange
            var testIdmResource = new IdmResource { DisplayName = "Test IdmResource" };			
            _it.Requestor = testIdmResource; 

            // Act
            _it.Requestor = null;

            // Assert
            Assert.IsNull(_it.Requestor);
        }

        [TestMethod]
        public void It_can_get_and_set_Requestor()
        {
            // Act
			var testIdmResource = new IdmResource { DisplayName = "Test IdmResource" };			
            _it.Requestor = testIdmResource; 

            // Assert
            Assert.AreEqual(testIdmResource.DisplayName, _it.Requestor.DisplayName);
        }


        [TestMethod]
        public void It_has_WorkflowInstance_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.WorkflowInstance);
        }

        [TestMethod]
        public void It_has_WorkflowInstance_which_can_be_set_back_to_null()
        {
            // Arrange
            var testWorkflowInstance = new WorkflowInstance { DisplayName = "Test WorkflowInstance" };			
            _it.WorkflowInstance = testWorkflowInstance; 

            // Act
            _it.WorkflowInstance = null;

            // Assert
            Assert.IsNull(_it.WorkflowInstance);
        }

        [TestMethod]
        public void It_can_get_and_set_WorkflowInstance()
        {
            // Act
			var testWorkflowInstance = new WorkflowInstance { DisplayName = "Test WorkflowInstance" };			
            _it.WorkflowInstance = testWorkflowInstance; 

            // Assert
            Assert.AreEqual(testWorkflowInstance.DisplayName, _it.WorkflowInstance.DisplayName);
        }


    }
}
