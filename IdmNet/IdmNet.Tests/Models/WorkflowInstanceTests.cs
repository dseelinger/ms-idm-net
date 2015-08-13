using System;
using System.Collections.Generic;
using IdmNet.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable ObjectCreationAsStatement
// ReSharper disable UseObjectOrCollectionInitializer

namespace IdmNet.Models.Tests
{
    [TestClass]
    public class WorkflowInstanceTests
    {
        private WorkflowInstance _it;

        public WorkflowInstanceTests()
        {
            _it = new WorkflowInstance();
        }

        [TestMethod]
        public void It_has_a_paremeterless_constructor()
        {
            Assert.AreEqual("WorkflowInstance", _it.ObjectType);
        }

        [TestMethod]
        public void It_has_a_constructor_that_takes_an_IdmResource()
        {
            var resource = new IdmResource
            {
                DisplayName = "My Display Name",
                Creator = new Person { DisplayName = "Creator Display Name", ObjectID = "Creator ObjectID"},
            };
            var it = new WorkflowInstance(resource);

            Assert.AreEqual("WorkflowInstance", it.ObjectType);
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
            var it = new WorkflowInstance(resource);

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
        public void It_has_WorkflowDefinition_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.WorkflowDefinition);
        }

        [TestMethod]
        public void It_has_WorkflowDefinition_which_can_be_set_back_to_null()
        {
            // Arrange
            var testWorkflowDefinition = new WorkflowDefinition { DisplayName = "Test WorkflowDefinition" };			
            _it.WorkflowDefinition = testWorkflowDefinition; 

            // Act
            _it.WorkflowDefinition = null;

            // Assert
            Assert.IsNull(_it.WorkflowDefinition);
        }

        [TestMethod]
        public void It_can_get_and_set_WorkflowDefinition()
        {
            // Act
			var testWorkflowDefinition = new WorkflowDefinition { DisplayName = "Test WorkflowDefinition" };			
            _it.WorkflowDefinition = testWorkflowDefinition; 

            // Assert
            Assert.AreEqual(testWorkflowDefinition.DisplayName, _it.WorkflowDefinition.DisplayName);
        }


        [TestMethod]
        public void It_can_get_and_set_WorkflowStatus()
        {
            // Act
            _it.WorkflowStatus = "A string";

            // Assert
            Assert.AreEqual("A string", _it.WorkflowStatus);
        }


        [TestMethod]
        public void It_has_WorkflowStatusDetail_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.WorkflowStatusDetail);
        }

        [TestMethod]
        public void It_has_WorkflowStatusDetail_which_can_be_set_back_to_null()
        {
            // Arrange
            var subObject1 = "foo1";
            var subObject2 = "foo2";
            var list = new List<string> { subObject1, subObject2 };
            _it.WorkflowStatusDetail = list; 

            // Act
            _it.WorkflowStatusDetail = null;

            // Assert
            Assert.IsNull(_it.WorkflowStatusDetail);
        }

        [TestMethod]
        public void It_can_get_and_set_WorkflowStatusDetail()
        {
            var subObject1 = "foo1";
            var subObject2 = "foo2";
            var list = new List<string> { subObject1, subObject2 };

            // Act
            _it.WorkflowStatusDetail = list; 

            // Assert
            Assert.AreEqual("foo1", _it.WorkflowStatusDetail[0]);
            Assert.AreEqual("foo2", _it.WorkflowStatusDetail[1]);
        }


    }
}
