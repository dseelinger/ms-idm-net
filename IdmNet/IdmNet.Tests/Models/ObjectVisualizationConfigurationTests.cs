using System;
using System.Collections.Generic;
using IdmNet.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable ObjectCreationAsStatement
// ReSharper disable UseObjectOrCollectionInitializer

namespace IdmNet.Models.Tests
{
    [TestClass]
    public class ObjectVisualizationConfigurationTests
    {
        private ObjectVisualizationConfiguration _it;

        public ObjectVisualizationConfigurationTests()
        {
            _it = new ObjectVisualizationConfiguration();
        }

        [TestMethod]
        public void It_has_a_paremeterless_constructor()
        {
            Assert.AreEqual("ObjectVisualizationConfiguration", _it.ObjectType);
        }

        [TestMethod]
        public void It_has_a_constructor_that_takes_an_IdmResource()
        {
            var resource = new IdmResource
            {
                DisplayName = "My Display Name",
                Creator = new Person { DisplayName = "Creator Display Name", ObjectID = "Creator ObjectID"},
            };
            var it = new ObjectVisualizationConfiguration(resource);

            Assert.AreEqual("ObjectVisualizationConfiguration", it.ObjectType);
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
            var it = new ObjectVisualizationConfiguration(resource);

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
        public void It_can_get_and_set_AppliesToCreate()
        {
            // Act
            _it.AppliesToCreate = true;

            // Assert
            Assert.AreEqual(true, _it.AppliesToCreate);
        }


        [TestMethod]
        public void It_can_get_and_set_AppliesToEdit()
        {
            // Act
            _it.AppliesToEdit = true;

            // Assert
            Assert.AreEqual(true, _it.AppliesToEdit);
        }


        [TestMethod]
        public void It_can_get_and_set_AppliesToView()
        {
            // Act
            _it.AppliesToView = true;

            // Assert
            Assert.AreEqual(true, _it.AppliesToView);
        }


        [TestMethod]
        public void It_can_get_and_set_ConfigurationData()
        {
            // Act
            _it.ConfigurationData = "A string";

            // Assert
            Assert.AreEqual("A string", _it.ConfigurationData);
        }


        [TestMethod]
        public void It_has_IsConfigurationType_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.IsConfigurationType);
        }

        [TestMethod]
        public void It_has_IsConfigurationType_which_can_be_set_back_to_null()
        {
            // Arrange
            _it.IsConfigurationType = true;

            // Act
            _it.IsConfigurationType = null;

            // Assert
            Assert.IsNull(_it.IsConfigurationType);
        }

        [TestMethod]
        public void It_can_get_and_set_IsConfigurationType()
        {
            // Act
            _it.IsConfigurationType = true;

            // Assert
            Assert.AreEqual(true, _it.IsConfigurationType);
        }


        [TestMethod]
        public void It_can_get_and_set_StringResources()
        {
            // Act
            _it.StringResources = "A string";

            // Assert
            Assert.AreEqual("A string", _it.StringResources);
        }


        [TestMethod]
        public void It_can_get_and_set_TargetObjectType()
        {
            // Act
            _it.TargetObjectType = "A string";

            // Assert
            Assert.AreEqual("A string", _it.TargetObjectType);
        }


    }
}
