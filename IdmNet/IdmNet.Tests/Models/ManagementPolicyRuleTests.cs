using System;
using System.Collections.Generic;
using IdmNet.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable ObjectCreationAsStatement
// ReSharper disable UseObjectOrCollectionInitializer

namespace IdmNet.Models.Tests
{
    [TestClass]
    public class ManagementPolicyRuleTests
    {
        private ManagementPolicyRule _it;

        public ManagementPolicyRuleTests()
        {
            _it = new ManagementPolicyRule();
        }

        [TestMethod]
        public void It_has_a_paremeterless_constructor()
        {
            Assert.AreEqual("ManagementPolicyRule", _it.ObjectType);
        }

        [TestMethod]
        public void It_has_a_constructor_that_takes_an_IdmResource()
        {
            var resource = new IdmResource
            {
                DisplayName = "My Display Name",
                Creator = new Person { DisplayName = "Creator Display Name", ObjectID = "Creator ObjectID"},
            };
            var it = new ManagementPolicyRule(resource);

            Assert.AreEqual("ManagementPolicyRule", it.ObjectType);
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
            var it = new ManagementPolicyRule(resource);

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
        public void It_has_ActionParameter_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.ActionParameter);
        }

        [TestMethod]
        public void It_has_ActionParameter_which_can_be_set_back_to_null()
        {
            // Arrange
            var subObject1 = "foo1";
            var subObject2 = "foo2";
            var list = new List<string> { subObject1, subObject2 };
            _it.ActionParameter = list; 

            // Act
            _it.ActionParameter = null;

            // Assert
            Assert.IsNull(_it.ActionParameter);
        }

        [TestMethod]
        public void It_can_get_and_set_ActionParameter()
        {
            var subObject1 = "foo1";
            var subObject2 = "foo2";
            var list = new List<string> { subObject1, subObject2 };

            // Act
            _it.ActionParameter = list; 

            // Assert
            Assert.AreEqual("foo1", _it.ActionParameter[0]);
            Assert.AreEqual("foo2", _it.ActionParameter[1]);
        }


        [TestMethod]
        public void It_can_get_and_set_ActionType()
        {
            var subObject1 = "foo1";
            var subObject2 = "foo2";
            var list = new List<string> { subObject1, subObject2 };

            // Act
            _it.ActionType = list; 

            // Assert
            Assert.AreEqual("foo1", _it.ActionType[0]);
            Assert.AreEqual("foo2", _it.ActionType[1]);
        }


        [TestMethod]
        public void It_has_ActionWorkflowDefinition_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.ActionWorkflowDefinition);
        }

        [TestMethod]
        public void It_has_ActionWorkflowDefinition_which_can_be_set_back_to_null()
        {
            // Arrange
            var list = new List<WorkflowInstance>
            {
                new WorkflowInstance { DisplayName = "Test WorkflowInstance1", ObjectID = "guid1" },
                new WorkflowInstance { DisplayName = "Test WorkflowInstance2", ObjectID = "guid2" }
            };
            _it.ActionWorkflowDefinition = list;

            // Act
            _it.ActionWorkflowDefinition = null;

            // Assert
            Assert.IsNull(_it.ActionWorkflowDefinition);
        }

        [TestMethod]
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
            Assert.AreEqual(list[0].DisplayName, _it.ActionWorkflowDefinition[0].DisplayName);
            Assert.AreEqual(list[1].DisplayName, _it.ActionWorkflowDefinition[1].DisplayName);
        }


        [TestMethod]
        public void It_has_AuthenticationWorkflowDefinition_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.AuthenticationWorkflowDefinition);
        }

        [TestMethod]
        public void It_has_AuthenticationWorkflowDefinition_which_can_be_set_back_to_null()
        {
            // Arrange
            var list = new List<WorkflowDefinition>
            {
                new WorkflowDefinition { DisplayName = "Test WorkflowDefinition1", ObjectID = "guid1" },
                new WorkflowDefinition { DisplayName = "Test WorkflowDefinition2", ObjectID = "guid2" }
            };
            _it.AuthenticationWorkflowDefinition = list;

            // Act
            _it.AuthenticationWorkflowDefinition = null;

            // Assert
            Assert.IsNull(_it.AuthenticationWorkflowDefinition);
        }

        [TestMethod]
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
            Assert.AreEqual(list[0].DisplayName, _it.AuthenticationWorkflowDefinition[0].DisplayName);
            Assert.AreEqual(list[1].DisplayName, _it.AuthenticationWorkflowDefinition[1].DisplayName);
        }


        [TestMethod]
        public void It_has_AuthorizationWorkflowDefinition_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.AuthorizationWorkflowDefinition);
        }

        [TestMethod]
        public void It_has_AuthorizationWorkflowDefinition_which_can_be_set_back_to_null()
        {
            // Arrange
            var list = new List<WorkflowDefinition>
            {
                new WorkflowDefinition { DisplayName = "Test WorkflowDefinition1", ObjectID = "guid1" },
                new WorkflowDefinition { DisplayName = "Test WorkflowDefinition2", ObjectID = "guid2" }
            };
            _it.AuthorizationWorkflowDefinition = list;

            // Act
            _it.AuthorizationWorkflowDefinition = null;

            // Assert
            Assert.IsNull(_it.AuthorizationWorkflowDefinition);
        }

        [TestMethod]
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
            Assert.AreEqual(list[0].DisplayName, _it.AuthorizationWorkflowDefinition[0].DisplayName);
            Assert.AreEqual(list[1].DisplayName, _it.AuthorizationWorkflowDefinition[1].DisplayName);
        }


        [TestMethod]
        public void It_can_get_and_set_Disabled()
        {
            // Act
            _it.Disabled = true;

            // Assert
            Assert.AreEqual(true, _it.Disabled);
        }


        [TestMethod]
        public void It_can_get_and_set_GrantRight()
        {
            // Act
            _it.GrantRight = true;

            // Assert
            Assert.AreEqual(true, _it.GrantRight);
        }


        [TestMethod]
        public void It_can_get_and_set_ManagementPolicyRuleType()
        {
            // Act
            _it.ManagementPolicyRuleType = "A string";

            // Assert
            Assert.AreEqual("A string", _it.ManagementPolicyRuleType);
        }


        [TestMethod]
        public void It_has_PrincipalSet_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.PrincipalSet);
        }

        [TestMethod]
        public void It_has_PrincipalSet_which_can_be_set_back_to_null()
        {
            // Arrange
            var testSet = new Set { DisplayName = "Test Set" };			
            _it.PrincipalSet = testSet; 

            // Act
            _it.PrincipalSet = null;

            // Assert
            Assert.IsNull(_it.PrincipalSet);
        }

        [TestMethod]
        public void It_can_get_and_set_PrincipalSet()
        {
            // Act
			var testSet = new Set { DisplayName = "Test Set" };			
            _it.PrincipalSet = testSet; 

            // Assert
            Assert.AreEqual(testSet.DisplayName, _it.PrincipalSet.DisplayName);
        }


        [TestMethod]
        public void It_can_get_and_set_PrincipalRelativeToResource()
        {
            // Act
            _it.PrincipalRelativeToResource = "A string";

            // Assert
            Assert.AreEqual("A string", _it.PrincipalRelativeToResource);
        }


        [TestMethod]
        public void It_has_ResourceCurrentSet_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.ResourceCurrentSet);
        }

        [TestMethod]
        public void It_has_ResourceCurrentSet_which_can_be_set_back_to_null()
        {
            // Arrange
            var testSet = new Set { DisplayName = "Test Set" };			
            _it.ResourceCurrentSet = testSet; 

            // Act
            _it.ResourceCurrentSet = null;

            // Assert
            Assert.IsNull(_it.ResourceCurrentSet);
        }

        [TestMethod]
        public void It_can_get_and_set_ResourceCurrentSet()
        {
            // Act
			var testSet = new Set { DisplayName = "Test Set" };			
            _it.ResourceCurrentSet = testSet; 

            // Assert
            Assert.AreEqual(testSet.DisplayName, _it.ResourceCurrentSet.DisplayName);
        }


        [TestMethod]
        public void It_has_ResourceFinalSet_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.ResourceFinalSet);
        }

        [TestMethod]
        public void It_has_ResourceFinalSet_which_can_be_set_back_to_null()
        {
            // Arrange
            var testSet = new Set { DisplayName = "Test Set" };			
            _it.ResourceFinalSet = testSet; 

            // Act
            _it.ResourceFinalSet = null;

            // Assert
            Assert.IsNull(_it.ResourceFinalSet);
        }

        [TestMethod]
        public void It_can_get_and_set_ResourceFinalSet()
        {
            // Act
			var testSet = new Set { DisplayName = "Test Set" };			
            _it.ResourceFinalSet = testSet; 

            // Assert
            Assert.AreEqual(testSet.DisplayName, _it.ResourceFinalSet.DisplayName);
        }


    }
}
