using System;
using System.Collections.Generic;
using IdmNet.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable ObjectCreationAsStatement
// ReSharper disable UseObjectOrCollectionInitializer

namespace IdmNet.Models.Tests
{
    [TestClass]
    public class FunctionTests
    {
        private Function _it;

        public FunctionTests()
        {
            _it = new Function();
        }

        [TestMethod]
        public void It_has_a_paremeterless_constructor()
        {
            Assert.AreEqual("Function", _it.ObjectType);
        }

        [TestMethod]
        public void It_has_a_constructor_that_takes_an_IdmResource()
        {
            var resource = new IdmResource
            {
                DisplayName = "My Display Name",
                Creator = new Person { DisplayName = "Creator Display Name", ObjectID = "Creator ObjectID"},
            };
            var it = new Function(resource);

            Assert.AreEqual("Function", it.ObjectType);
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
            var it = new Function(resource);

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
        public void It_can_get_and_set_Assembly()
        {
            // Act
            _it.Assembly = "A string";

            // Assert
            Assert.AreEqual("A string", _it.Assembly);
        }


        [TestMethod]
        public void It_can_get_and_set_FunctionName()
        {
            // Act
            _it.FunctionName = "A string";

            // Assert
            Assert.AreEqual("A string", _it.FunctionName);
        }


        [TestMethod]
        public void It_can_get_and_set_Namespace()
        {
            // Act
            _it.Namespace = "A string";

            // Assert
            Assert.AreEqual("A string", _it.Namespace);
        }


        [TestMethod]
        public void It_can_get_and_set_FunctionParameters()
        {
            // Act
            _it.FunctionParameters = "A string";

            // Assert
            Assert.AreEqual("A string", _it.FunctionParameters);
        }


        [TestMethod]
        public void It_can_get_and_set_ReturnType()
        {
            // Act
            _it.ReturnType = "A string";

            // Assert
            Assert.AreEqual("A string", _it.ReturnType);
        }


    }
}
