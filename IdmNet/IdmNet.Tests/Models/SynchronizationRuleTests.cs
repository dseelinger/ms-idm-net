using System;
using System.Collections.Generic;
using IdmNet.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable ObjectCreationAsStatement
// ReSharper disable UseObjectOrCollectionInitializer

namespace IdmNet.Models.Tests
{
    [TestClass]
    public class SynchronizationRuleTests
    {
        private SynchronizationRule _it;

        public SynchronizationRuleTests()
        {
            _it = new SynchronizationRule();
        }

        [TestMethod]
        public void It_has_a_paremeterless_constructor()
        {
            Assert.AreEqual("SynchronizationRule", _it.ObjectType);
        }

        [TestMethod]
        public void It_has_a_constructor_that_takes_an_IdmResource()
        {
            var resource = new IdmResource
            {
                DisplayName = "My Display Name",
                Creator = new Person { DisplayName = "Creator Display Name", ObjectID = "Creator ObjectID"},
            };
            var it = new SynchronizationRule(resource);

            Assert.AreEqual("SynchronizationRule", it.ObjectType);
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
            var it = new SynchronizationRule(resource);

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
        public void It_can_get_and_set_CreateConnectedSystemObject()
        {
            // Act
            _it.CreateConnectedSystemObject = true;

            // Assert
            Assert.AreEqual(true, _it.CreateConnectedSystemObject);
        }


        [TestMethod]
        public void It_can_get_and_set_CreateILMObject()
        {
            // Act
            _it.CreateILMObject = true;

            // Assert
            Assert.AreEqual(true, _it.CreateILMObject);
        }


        [TestMethod]
        public void It_can_get_and_set_FlowType()
        {
            // Act
            _it.FlowType = 123;

            // Assert
            Assert.AreEqual(123, _it.FlowType);
        }


        [TestMethod]
        public void It_has_Dependency_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.Dependency);
        }

        [TestMethod]
        public void It_has_Dependency_which_can_be_set_back_to_null()
        {
            // Arrange
            var testSynchronizationRule = new SynchronizationRule { DisplayName = "Test SynchronizationRule" };			
            _it.Dependency = testSynchronizationRule; 

            // Act
            _it.Dependency = null;

            // Assert
            Assert.IsNull(_it.Dependency);
        }

        [TestMethod]
        public void It_can_get_and_set_Dependency()
        {
            // Act
			var testSynchronizationRule = new SynchronizationRule { DisplayName = "Test SynchronizationRule" };			
            _it.Dependency = testSynchronizationRule; 

            // Assert
            Assert.AreEqual(testSynchronizationRule.DisplayName, _it.Dependency.DisplayName);
        }


        [TestMethod]
        public void It_can_get_and_set_DisconnectConnectedSystemObject()
        {
            // Act
            _it.DisconnectConnectedSystemObject = true;

            // Assert
            Assert.AreEqual(true, _it.DisconnectConnectedSystemObject);
        }


        [TestMethod]
        public void It_has_ExistenceTest_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.ExistenceTest);
        }

        [TestMethod]
        public void It_has_ExistenceTest_which_can_be_set_back_to_null()
        {
            // Arrange
            var subObject1 = "foo1";
            var subObject2 = "foo2";
            var list = new List<string> { subObject1, subObject2 };
            _it.ExistenceTest = list; 

            // Act
            _it.ExistenceTest = null;

            // Assert
            Assert.IsNull(_it.ExistenceTest);
        }

        [TestMethod]
        public void It_can_get_and_set_ExistenceTest()
        {
            var subObject1 = "foo1";
            var subObject2 = "foo2";
            var list = new List<string> { subObject1, subObject2 };

            // Act
            _it.ExistenceTest = list; 

            // Assert
            Assert.AreEqual("foo1", _it.ExistenceTest[0]);
            Assert.AreEqual("foo2", _it.ExistenceTest[1]);
        }


        [TestMethod]
        public void It_can_get_and_set_ConnectedSystem()
        {
            // Act
            _it.ConnectedSystem = "A string";

            // Assert
            Assert.AreEqual("A string", _it.ConnectedSystem);
        }


        [TestMethod]
        public void It_can_get_and_set_ConnectedObjectType()
        {
            // Act
            _it.ConnectedObjectType = "A string";

            // Assert
            Assert.AreEqual("A string", _it.ConnectedObjectType);
        }


        [TestMethod]
        public void It_can_get_and_set_ConnectedSystemScope()
        {
            // Act
            _it.ConnectedSystemScope = "A string";

            // Assert
            Assert.AreEqual("A string", _it.ConnectedSystemScope);
        }


        [TestMethod]
        public void It_can_get_and_set_ILMObjectType()
        {
            // Act
            _it.ILMObjectType = "A string";

            // Assert
            Assert.AreEqual("A string", _it.ILMObjectType);
        }


        [TestMethod]
        public void It_has_InitialFlow_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.InitialFlow);
        }

        [TestMethod]
        public void It_has_InitialFlow_which_can_be_set_back_to_null()
        {
            // Arrange
            var subObject1 = "foo1";
            var subObject2 = "foo2";
            var list = new List<string> { subObject1, subObject2 };
            _it.InitialFlow = list; 

            // Act
            _it.InitialFlow = null;

            // Assert
            Assert.IsNull(_it.InitialFlow);
        }

        [TestMethod]
        public void It_can_get_and_set_InitialFlow()
        {
            var subObject1 = "foo1";
            var subObject2 = "foo2";
            var list = new List<string> { subObject1, subObject2 };

            // Act
            _it.InitialFlow = list; 

            // Assert
            Assert.AreEqual("foo1", _it.InitialFlow[0]);
            Assert.AreEqual("foo2", _it.InitialFlow[1]);
        }


        [TestMethod]
        public void It_has_ManagementAgentID_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.ManagementAgentID);
        }

        [TestMethod]
        public void It_has_ManagementAgentID_which_can_be_set_back_to_null()
        {
            // Arrange
            var testma_data = new ma_data { DisplayName = "Test ma_data" };			
            _it.ManagementAgentID = testma_data; 

            // Act
            _it.ManagementAgentID = null;

            // Assert
            Assert.IsNull(_it.ManagementAgentID);
        }

        [TestMethod]
        public void It_can_get_and_set_ManagementAgentID()
        {
            // Act
			var testma_data = new ma_data { DisplayName = "Test ma_data" };			
            _it.ManagementAgentID = testma_data; 

            // Assert
            Assert.AreEqual(testma_data.DisplayName, _it.ManagementAgentID.DisplayName);
        }


        [TestMethod]
        public void It_has_msidmOutboundIsFilterBased_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.msidmOutboundIsFilterBased);
        }

        [TestMethod]
        public void It_has_msidmOutboundIsFilterBased_which_can_be_set_back_to_null()
        {
            // Arrange
            _it.msidmOutboundIsFilterBased = true;

            // Act
            _it.msidmOutboundIsFilterBased = null;

            // Assert
            Assert.IsNull(_it.msidmOutboundIsFilterBased);
        }

        [TestMethod]
        public void It_can_get_and_set_msidmOutboundIsFilterBased()
        {
            // Act
            _it.msidmOutboundIsFilterBased = true;

            // Assert
            Assert.AreEqual(true, _it.msidmOutboundIsFilterBased);
        }


        [TestMethod]
        public void It_can_get_and_set_msidmOutboundScopingFilters()
        {
            // Act
            _it.msidmOutboundScopingFilters = "A string";

            // Assert
            Assert.AreEqual("A string", _it.msidmOutboundScopingFilters);
        }


        [TestMethod]
        public void It_has_PersistentFlow_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.PersistentFlow);
        }

        [TestMethod]
        public void It_has_PersistentFlow_which_can_be_set_back_to_null()
        {
            // Arrange
            var subObject1 = "foo1";
            var subObject2 = "foo2";
            var list = new List<string> { subObject1, subObject2 };
            _it.PersistentFlow = list; 

            // Act
            _it.PersistentFlow = null;

            // Assert
            Assert.IsNull(_it.PersistentFlow);
        }

        [TestMethod]
        public void It_can_get_and_set_PersistentFlow()
        {
            var subObject1 = "foo1";
            var subObject2 = "foo2";
            var list = new List<string> { subObject1, subObject2 };

            // Act
            _it.PersistentFlow = list; 

            // Assert
            Assert.AreEqual("foo1", _it.PersistentFlow[0]);
            Assert.AreEqual("foo2", _it.PersistentFlow[1]);
        }


        [TestMethod]
        public void It_has_Precedence_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.Precedence);
        }

        [TestMethod]
        public void It_has_Precedence_which_can_be_set_back_to_null()
        {
            // Arrange
            _it.Precedence = 123;

            // Act
            _it.Precedence = null;

            // Assert
            Assert.IsNull(_it.Precedence);
        }

        [TestMethod]
        public void It_can_get_and_set_Precedence()
        {
            // Act
            _it.Precedence = 123;

            // Assert
            Assert.AreEqual(123, _it.Precedence);
        }


        [TestMethod]
        public void It_can_get_and_set_RelationshipCriteria()
        {
            // Act
            _it.RelationshipCriteria = "A string";

            // Assert
            Assert.AreEqual("A string", _it.RelationshipCriteria);
        }


        [TestMethod]
        public void It_has_SynchronizationRuleParameters_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.SynchronizationRuleParameters);
        }

        [TestMethod]
        public void It_has_SynchronizationRuleParameters_which_can_be_set_back_to_null()
        {
            // Arrange
            var subObject1 = "foo1";
            var subObject2 = "foo2";
            var list = new List<string> { subObject1, subObject2 };
            _it.SynchronizationRuleParameters = list; 

            // Act
            _it.SynchronizationRuleParameters = null;

            // Assert
            Assert.IsNull(_it.SynchronizationRuleParameters);
        }

        [TestMethod]
        public void It_can_get_and_set_SynchronizationRuleParameters()
        {
            var subObject1 = "foo1";
            var subObject2 = "foo2";
            var list = new List<string> { subObject1, subObject2 };

            // Act
            _it.SynchronizationRuleParameters = list; 

            // Assert
            Assert.AreEqual("foo1", _it.SynchronizationRuleParameters[0]);
            Assert.AreEqual("foo2", _it.SynchronizationRuleParameters[1]);
        }


    }
}
