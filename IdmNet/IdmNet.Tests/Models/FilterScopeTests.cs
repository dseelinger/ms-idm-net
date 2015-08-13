using System;
using System.Collections.Generic;
using IdmNet.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable ObjectCreationAsStatement
// ReSharper disable UseObjectOrCollectionInitializer

namespace IdmNet.Models.Tests
{
    [TestClass]
    public class FilterScopeTests
    {
        private FilterScope _it;

        public FilterScopeTests()
        {
            _it = new FilterScope();
        }

        [TestMethod]
        public void It_has_a_paremeterless_constructor()
        {
            Assert.AreEqual("FilterScope", _it.ObjectType);
        }

        [TestMethod]
        public void It_has_a_constructor_that_takes_an_IdmResource()
        {
            var resource = new IdmResource
            {
                DisplayName = "My Display Name",
                Creator = new Person { DisplayName = "Creator Display Name", ObjectID = "Creator ObjectID"},
            };
            var it = new FilterScope(resource);

            Assert.AreEqual("FilterScope", it.ObjectType);
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
            var it = new FilterScope(resource);

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
        public void It_has_AllowedAttributes_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.AllowedAttributes);
        }

        [TestMethod]
        public void It_has_AllowedAttributes_which_can_be_set_back_to_null()
        {
            // Arrange
            var list = new List<AttributeTypeDescription>
            {
                new AttributeTypeDescription { DisplayName = "Test AttributeTypeDescription1", ObjectID = "guid1" },
                new AttributeTypeDescription { DisplayName = "Test AttributeTypeDescription2", ObjectID = "guid2" }
            };
            _it.AllowedAttributes = list;

            // Act
            _it.AllowedAttributes = null;

            // Assert
            Assert.IsNull(_it.AllowedAttributes);
        }

        [TestMethod]
        public void It_can_get_and_set_AllowedAttributes()
        {
            // Arrange
            var list = new List<AttributeTypeDescription>
            {
                new AttributeTypeDescription { DisplayName = "Test AttributeTypeDescription1", ObjectID = "guid1" },
                new AttributeTypeDescription { DisplayName = "Test AttributeTypeDescription2", ObjectID = "guid2" }
            };

            // Act
            _it.AllowedAttributes = list;

            // Assert
            Assert.AreEqual(list[0].DisplayName, _it.AllowedAttributes[0].DisplayName);
            Assert.AreEqual(list[1].DisplayName, _it.AllowedAttributes[1].DisplayName);
        }


        [TestMethod]
        public void It_has_AllowedMembershipReferences_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.AllowedMembershipReferences);
        }

        [TestMethod]
        public void It_has_AllowedMembershipReferences_which_can_be_set_back_to_null()
        {
            // Arrange
            var list = new List<Set>
            {
                new Set { DisplayName = "Test Set1", ObjectID = "guid1" },
                new Set { DisplayName = "Test Set2", ObjectID = "guid2" }
            };
            _it.AllowedMembershipReferences = list;

            // Act
            _it.AllowedMembershipReferences = null;

            // Assert
            Assert.IsNull(_it.AllowedMembershipReferences);
        }

        [TestMethod]
        public void It_can_get_and_set_AllowedMembershipReferences()
        {
            // Arrange
            var list = new List<Set>
            {
                new Set { DisplayName = "Test Set1", ObjectID = "guid1" },
                new Set { DisplayName = "Test Set2", ObjectID = "guid2" }
            };

            // Act
            _it.AllowedMembershipReferences = list;

            // Assert
            Assert.AreEqual(list[0].DisplayName, _it.AllowedMembershipReferences[0].DisplayName);
            Assert.AreEqual(list[1].DisplayName, _it.AllowedMembershipReferences[1].DisplayName);
        }


    }
}
