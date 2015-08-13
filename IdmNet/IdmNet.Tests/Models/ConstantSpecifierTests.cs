using System;
using System.Collections.Generic;
using IdmNet.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable ObjectCreationAsStatement
// ReSharper disable UseObjectOrCollectionInitializer

namespace IdmNet.Models.Tests
{
    [TestClass]
    public class ConstantSpecifierTests
    {
        private ConstantSpecifier _it;

        public ConstantSpecifierTests()
        {
            _it = new ConstantSpecifier();
        }

        [TestMethod]
        public void It_has_a_paremeterless_constructor()
        {
            Assert.AreEqual("ConstantSpecifier", _it.ObjectType);
        }

        [TestMethod]
        public void It_has_a_constructor_that_takes_an_IdmResource()
        {
            var resource = new IdmResource
            {
                DisplayName = "My Display Name",
                Creator = new Person { DisplayName = "Creator Display Name", ObjectID = "Creator ObjectID"},
            };
            var it = new ConstantSpecifier(resource);

            Assert.AreEqual("ConstantSpecifier", it.ObjectType);
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
            var it = new ConstantSpecifier(resource);

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
        public void It_has_BoundAttributeType_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.BoundAttributeType);
        }

        [TestMethod]
        public void It_has_BoundAttributeType_which_can_be_set_back_to_null()
        {
            // Arrange
            var testAttributeTypeDescription = new AttributeTypeDescription { DisplayName = "Test AttributeTypeDescription" };			
            _it.BoundAttributeType = testAttributeTypeDescription; 

            // Act
            _it.BoundAttributeType = null;

            // Assert
            Assert.IsNull(_it.BoundAttributeType);
        }

        [TestMethod]
        public void It_can_get_and_set_BoundAttributeType()
        {
            // Act
			var testAttributeTypeDescription = new AttributeTypeDescription { DisplayName = "Test AttributeTypeDescription" };			
            _it.BoundAttributeType = testAttributeTypeDescription; 

            // Assert
            Assert.AreEqual(testAttributeTypeDescription.DisplayName, _it.BoundAttributeType.DisplayName);
        }


        [TestMethod]
        public void It_can_get_and_set_ConstantValueKey()
        {
            // Act
            _it.ConstantValueKey = "A string";

            // Assert
            Assert.AreEqual("A string", _it.ConstantValueKey);
        }


        [TestMethod]
        public void It_has_BoundObjectType_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.BoundObjectType);
        }

        [TestMethod]
        public void It_has_BoundObjectType_which_can_be_set_back_to_null()
        {
            // Arrange
            var testObjectTypeDescription = new ObjectTypeDescription { DisplayName = "Test ObjectTypeDescription" };			
            _it.BoundObjectType = testObjectTypeDescription; 

            // Act
            _it.BoundObjectType = null;

            // Assert
            Assert.IsNull(_it.BoundObjectType);
        }

        [TestMethod]
        public void It_can_get_and_set_BoundObjectType()
        {
            // Act
			var testObjectTypeDescription = new ObjectTypeDescription { DisplayName = "Test ObjectTypeDescription" };			
            _it.BoundObjectType = testObjectTypeDescription; 

            // Assert
            Assert.AreEqual(testObjectTypeDescription.DisplayName, _it.BoundObjectType.DisplayName);
        }


    }
}
