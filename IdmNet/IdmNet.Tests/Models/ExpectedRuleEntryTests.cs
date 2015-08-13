using System;
using System.Collections.Generic;
using IdmNet.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable ObjectCreationAsStatement
// ReSharper disable UseObjectOrCollectionInitializer

namespace IdmNet.Models.Tests
{
    [TestClass]
    public class ExpectedRuleEntryTests
    {
        private ExpectedRuleEntry _it;

        public ExpectedRuleEntryTests()
        {
            _it = new ExpectedRuleEntry();
        }

        [TestMethod]
        public void It_has_a_paremeterless_constructor()
        {
            Assert.AreEqual("ExpectedRuleEntry", _it.ObjectType);
        }

        [TestMethod]
        public void It_has_a_constructor_that_takes_an_IdmResource()
        {
            var resource = new IdmResource
            {
                DisplayName = "My Display Name",
                Creator = new Person { DisplayName = "Creator Display Name", ObjectID = "Creator ObjectID"},
            };
            var it = new ExpectedRuleEntry(resource);

            Assert.AreEqual("ExpectedRuleEntry", it.ObjectType);
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
            var it = new ExpectedRuleEntry(resource);

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
        public void It_can_get_and_set_ExpectedRuleEntryAction()
        {
            // Act
            _it.ExpectedRuleEntryAction = "A string";

            // Assert
            Assert.AreEqual("A string", _it.ExpectedRuleEntryAction);
        }


        [TestMethod]
        public void It_has_ResourceParent_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.ResourceParent);
        }

        [TestMethod]
        public void It_has_ResourceParent_which_can_be_set_back_to_null()
        {
            // Arrange
            var testIdmResource = new IdmResource { DisplayName = "Test IdmResource" };			
            _it.ResourceParent = testIdmResource; 

            // Act
            _it.ResourceParent = null;

            // Assert
            Assert.IsNull(_it.ResourceParent);
        }

        [TestMethod]
        public void It_can_get_and_set_ResourceParent()
        {
            // Act
			var testIdmResource = new IdmResource { DisplayName = "Test IdmResource" };			
            _it.ResourceParent = testIdmResource; 

            // Assert
            Assert.AreEqual(testIdmResource.DisplayName, _it.ResourceParent.DisplayName);
        }


        [TestMethod]
        public void It_can_get_and_set_StatusError()
        {
            // Act
            _it.StatusError = "A string";

            // Assert
            Assert.AreEqual("A string", _it.StatusError);
        }


        [TestMethod]
        public void It_has_SynchronizationRuleData_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.SynchronizationRuleData);
        }

        [TestMethod]
        public void It_has_SynchronizationRuleData_which_can_be_set_back_to_null()
        {
            // Arrange
            var subObject1 = "foo1";
            var subObject2 = "foo2";
            var list = new List<string> { subObject1, subObject2 };
            _it.SynchronizationRuleData = list; 

            // Act
            _it.SynchronizationRuleData = null;

            // Assert
            Assert.IsNull(_it.SynchronizationRuleData);
        }

        [TestMethod]
        public void It_can_get_and_set_SynchronizationRuleData()
        {
            var subObject1 = "foo1";
            var subObject2 = "foo2";
            var list = new List<string> { subObject1, subObject2 };

            // Act
            _it.SynchronizationRuleData = list; 

            // Assert
            Assert.AreEqual("foo1", _it.SynchronizationRuleData[0]);
            Assert.AreEqual("foo2", _it.SynchronizationRuleData[1]);
        }


        [TestMethod]
        public void It_has_SynchronizationRuleID_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.SynchronizationRuleID);
        }

        [TestMethod]
        public void It_has_SynchronizationRuleID_which_can_be_set_back_to_null()
        {
            // Arrange
            var testSynchronizationRule = new SynchronizationRule { DisplayName = "Test SynchronizationRule" };			
            _it.SynchronizationRuleID = testSynchronizationRule; 

            // Act
            _it.SynchronizationRuleID = null;

            // Assert
            Assert.IsNull(_it.SynchronizationRuleID);
        }

        [TestMethod]
        public void It_can_get_and_set_SynchronizationRuleID()
        {
            // Act
			var testSynchronizationRule = new SynchronizationRule { DisplayName = "Test SynchronizationRule" };			
            _it.SynchronizationRuleID = testSynchronizationRule; 

            // Assert
            Assert.AreEqual(testSynchronizationRule.DisplayName, _it.SynchronizationRuleID.DisplayName);
        }


        [TestMethod]
        public void It_can_get_and_set_SynchronizationRuleName()
        {
            // Act
            _it.SynchronizationRuleName = "A string";

            // Assert
            Assert.AreEqual("A string", _it.SynchronizationRuleName);
        }


        [TestMethod]
        public void It_can_get_and_set_SynchronizationRuleStatus()
        {
            // Act
            _it.SynchronizationRuleStatus = "A string";

            // Assert
            Assert.AreEqual("A string", _it.SynchronizationRuleStatus);
        }


    }
}
