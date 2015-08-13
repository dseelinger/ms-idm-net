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
        public void It_has_IntegerMaximum_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.IntegerMaximum);
        }

        [TestMethod]
        public void It_has_IntegerMaximum_which_can_be_set_back_to_null()
        {
            // Arrange
            _it.IntegerMaximum = 123;

            // Act
            _it.IntegerMaximum = null;

            // Assert
            Assert.IsNull(_it.IntegerMaximum);
        }

        [TestMethod]
        public void It_can_get_and_set_IntegerMaximum()
        {
            // Act
            _it.IntegerMaximum = 123;

            // Assert
            Assert.AreEqual(123, _it.IntegerMaximum);
        }


        [TestMethod]
        public void It_has_IntegerMinimum_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.IntegerMinimum);
        }

        [TestMethod]
        public void It_has_IntegerMinimum_which_can_be_set_back_to_null()
        {
            // Arrange
            _it.IntegerMinimum = 123;

            // Act
            _it.IntegerMinimum = null;

            // Assert
            Assert.IsNull(_it.IntegerMinimum);
        }

        [TestMethod]
        public void It_can_get_and_set_IntegerMinimum()
        {
            // Act
            _it.IntegerMinimum = 123;

            // Assert
            Assert.AreEqual(123, _it.IntegerMinimum);
        }


        [TestMethod]
        public void It_has_Localizable_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.Localizable);
        }

        [TestMethod]
        public void It_has_Localizable_which_can_be_set_back_to_null()
        {
            // Arrange
            _it.Localizable = true;

            // Act
            _it.Localizable = null;

            // Assert
            Assert.IsNull(_it.Localizable);
        }

        [TestMethod]
        public void It_can_get_and_set_Localizable()
        {
            // Act
            _it.Localizable = true;

            // Assert
            Assert.AreEqual(true, _it.Localizable);
        }


        [TestMethod]
        public void It_can_get_and_set_Multivalued()
        {
            // Act
            _it.Multivalued = true;

            // Assert
            Assert.AreEqual(true, _it.Multivalued);
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


        [TestMethod]
        public void It_has_UsageKeyword_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.UsageKeyword);
        }

        [TestMethod]
        public void It_has_UsageKeyword_which_can_be_set_back_to_null()
        {
            // Arrange
            var subObject1 = "foo1";
            var subObject2 = "foo2";
            var list = new List<string> { subObject1, subObject2 };
            _it.UsageKeyword = list; 

            // Act
            _it.UsageKeyword = null;

            // Assert
            Assert.IsNull(_it.UsageKeyword);
        }

        [TestMethod]
        public void It_can_get_and_set_UsageKeyword()
        {
            var subObject1 = "foo1";
            var subObject2 = "foo2";
            var list = new List<string> { subObject1, subObject2 };

            // Act
            _it.UsageKeyword = list; 

            // Assert
            Assert.AreEqual("foo1", _it.UsageKeyword[0]);
            Assert.AreEqual("foo2", _it.UsageKeyword[1]);
        }


    }
}
