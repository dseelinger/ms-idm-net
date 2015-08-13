using System;
using System.Collections.Generic;
using IdmNet.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable ObjectCreationAsStatement
// ReSharper disable UseObjectOrCollectionInitializer

namespace IdmNet.Models.Tests
{
    [TestClass]
    public class WorkflowDefinitionTests
    {
        private WorkflowDefinition _it;

        public WorkflowDefinitionTests()
        {
            _it = new WorkflowDefinition();
        }

        [TestMethod]
        public void It_has_a_paremeterless_constructor()
        {
            Assert.AreEqual("WorkflowDefinition", _it.ObjectType);
        }

        [TestMethod]
        public void It_has_a_constructor_that_takes_an_IdmResource()
        {
            var resource = new IdmResource
            {
                DisplayName = "My Display Name",
                Creator = new Person { DisplayName = "Creator Display Name", ObjectID = "Creator ObjectID"},
            };
            var it = new WorkflowDefinition(resource);

            Assert.AreEqual("WorkflowDefinition", it.ObjectType);
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
            var it = new WorkflowDefinition(resource);

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
        public void It_has_ClearRegistration_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.ClearRegistration);
        }

        [TestMethod]
        public void It_has_ClearRegistration_which_can_be_set_back_to_null()
        {
            // Arrange
            _it.ClearRegistration = true;

            // Act
            _it.ClearRegistration = null;

            // Assert
            Assert.IsNull(_it.ClearRegistration);
        }

        [TestMethod]
        public void It_can_get_and_set_ClearRegistration()
        {
            // Act
            _it.ClearRegistration = true;

            // Assert
            Assert.AreEqual(true, _it.ClearRegistration);
        }


        [TestMethod]
        public void It_can_get_and_set_RequestPhase()
        {
            // Act
            _it.RequestPhase = "A string";

            // Assert
            Assert.AreEqual("A string", _it.RequestPhase);
        }


        [TestMethod]
        public void It_can_get_and_set_Rules()
        {
            // Act
            _it.Rules = "A string";

            // Assert
            Assert.AreEqual("A string", _it.Rules);
        }


        [TestMethod]
        public void It_has_RunOnPolicyUpdate_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.RunOnPolicyUpdate);
        }

        [TestMethod]
        public void It_has_RunOnPolicyUpdate_which_can_be_set_back_to_null()
        {
            // Arrange
            _it.RunOnPolicyUpdate = true;

            // Act
            _it.RunOnPolicyUpdate = null;

            // Assert
            Assert.IsNull(_it.RunOnPolicyUpdate);
        }

        [TestMethod]
        public void It_can_get_and_set_RunOnPolicyUpdate()
        {
            // Act
            _it.RunOnPolicyUpdate = true;

            // Assert
            Assert.AreEqual(true, _it.RunOnPolicyUpdate);
        }


        [TestMethod]
        public void It_can_get_and_set_XOML()
        {
            // Act
            _it.XOML = "A string";

            // Assert
            Assert.AreEqual("A string", _it.XOML);
        }


    }
}
