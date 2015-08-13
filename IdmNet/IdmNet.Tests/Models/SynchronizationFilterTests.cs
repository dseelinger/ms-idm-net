using System;
using System.Collections.Generic;
using IdmNet.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable ObjectCreationAsStatement
// ReSharper disable UseObjectOrCollectionInitializer

namespace IdmNet.Models.Tests
{
    [TestClass]
    public class SynchronizationFilterTests
    {
        private SynchronizationFilter _it;

        public SynchronizationFilterTests()
        {
            _it = new SynchronizationFilter();
        }

        [TestMethod]
        public void It_has_a_paremeterless_constructor()
        {
            Assert.AreEqual("SynchronizationFilter", _it.ObjectType);
        }

        [TestMethod]
        public void It_has_a_constructor_that_takes_an_IdmResource()
        {
            var resource = new IdmResource
            {
                DisplayName = "My Display Name",
                Creator = new Person { DisplayName = "Creator Display Name", ObjectID = "Creator ObjectID"},
            };
            var it = new SynchronizationFilter(resource);

            Assert.AreEqual("SynchronizationFilter", it.ObjectType);
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
            var it = new SynchronizationFilter(resource);

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
        public void It_has_SynchronizeObjectType_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.SynchronizeObjectType);
        }

        [TestMethod]
        public void It_has_SynchronizeObjectType_which_can_be_set_back_to_null()
        {
            // Arrange
            var list = new List<ObjectTypeDescription>
            {
                new ObjectTypeDescription { DisplayName = "Test ObjectTypeDescription1", ObjectID = "guid1" },
                new ObjectTypeDescription { DisplayName = "Test ObjectTypeDescription2", ObjectID = "guid2" }
            };
            _it.SynchronizeObjectType = list;

            // Act
            _it.SynchronizeObjectType = null;

            // Assert
            Assert.IsNull(_it.SynchronizeObjectType);
        }

        [TestMethod]
        public void It_can_get_and_set_SynchronizeObjectType()
        {
            // Arrange
            var list = new List<ObjectTypeDescription>
            {
                new ObjectTypeDescription { DisplayName = "Test ObjectTypeDescription1", ObjectID = "guid1" },
                new ObjectTypeDescription { DisplayName = "Test ObjectTypeDescription2", ObjectID = "guid2" }
            };

            // Act
            _it.SynchronizeObjectType = list;

            // Assert
            Assert.AreEqual(list[0].DisplayName, _it.SynchronizeObjectType[0].DisplayName);
            Assert.AreEqual(list[1].DisplayName, _it.SynchronizeObjectType[1].DisplayName);
        }


    }
}
