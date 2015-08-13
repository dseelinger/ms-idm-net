using System;
using System.Collections.Generic;
using IdmNet.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable ObjectCreationAsStatement
// ReSharper disable UseObjectOrCollectionInitializer

namespace IdmNet.Models.Tests
{
    [TestClass]
    public class ObjectTypeDescriptionTests
    {
        private ObjectTypeDescription _it;

        public ObjectTypeDescriptionTests()
        {
            _it = new ObjectTypeDescription();
        }

        [TestMethod]
        public void It_has_a_paremeterless_constructor()
        {
            Assert.AreEqual("ObjectTypeDescription", _it.ObjectType);
        }

        [TestMethod]
        public void It_has_a_constructor_that_takes_an_IdmResource()
        {
            var resource = new IdmResource
            {
                DisplayName = "My Display Name",
                Creator = new Person { DisplayName = "Creator Display Name", ObjectID = "Creator ObjectID"},
            };
            var it = new ObjectTypeDescription(resource);

            Assert.AreEqual("ObjectTypeDescription", it.ObjectType);
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
            var it = new ObjectTypeDescription(resource);

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
        public void It_can_get_and_set_Name()
        {
            // Act
            _it.Name = "A string";

            // Assert
            Assert.AreEqual("A string", _it.Name);
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
