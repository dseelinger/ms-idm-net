using System;
using System.Collections.Generic;
using IdmNet.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable ObjectCreationAsStatement
// ReSharper disable UseObjectOrCollectionInitializer

namespace IdmNet.Models.Tests
{
    [TestClass]
    public class AttributeTypeDescriptionTests
    {
        private AttributeTypeDescription _it;

        public AttributeTypeDescriptionTests()
        {
            _it = new AttributeTypeDescription();
        }

        [TestMethod]
        public void It_has_a_paremeterless_constructor()
        {
            Assert.AreEqual("AttributeTypeDescription", _it.ObjectType);
        }

        [TestMethod]
        public void It_has_a_constructor_that_takes_an_IdmResource()
        {
            var resource = new IdmResource
            {
                DisplayName = "My Display Name",
                Creator = new Person { DisplayName = "Creator Display Name", ObjectID = "Creator ObjectID"},
            };
            var it = new AttributeTypeDescription(resource);

            Assert.AreEqual("AttributeTypeDescription", it.ObjectType);
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
            var it = new AttributeTypeDescription(resource);

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
        public void It_can_get_and_set_DataType()
        {
            // Act
            _it.DataType = "A string";

            // Assert
            Assert.AreEqual("A string", _it.DataType);
        }


        [TestMethod]
        public void It_can_get_and_set_Name()
        {
            // Act
            _it.Name = "A string";

            // Assert
            Assert.AreEqual("A string", _it.Name);
        }


        [TestMethod]
        public void It_can_get_and_set_StringRegex()
        {
            // Act
            _it.StringRegex = "A string";

            // Assert
            Assert.AreEqual("A string", _it.StringRegex);
        }


    }
}
