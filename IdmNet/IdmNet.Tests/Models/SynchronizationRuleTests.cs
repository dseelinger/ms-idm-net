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
        public void It_can_get_and_set_msidmOutboundScopingFilters()
        {
            // Act
            _it.msidmOutboundScopingFilters = "A string";

            // Assert
            Assert.AreEqual("A string", _it.msidmOutboundScopingFilters);
        }


        [TestMethod]
        public void It_can_get_and_set_RelationshipCriteria()
        {
            // Act
            _it.RelationshipCriteria = "A string";

            // Assert
            Assert.AreEqual("A string", _it.RelationshipCriteria);
        }


    }
}
