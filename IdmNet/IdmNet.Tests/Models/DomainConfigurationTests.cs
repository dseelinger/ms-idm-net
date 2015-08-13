using System;
using System.Collections.Generic;
using IdmNet.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable ObjectCreationAsStatement
// ReSharper disable UseObjectOrCollectionInitializer

namespace IdmNet.Models.Tests
{
    [TestClass]
    public class DomainConfigurationTests
    {
        private DomainConfiguration _it;

        public DomainConfigurationTests()
        {
            _it = new DomainConfiguration();
        }

        [TestMethod]
        public void It_has_a_paremeterless_constructor()
        {
            Assert.AreEqual("DomainConfiguration", _it.ObjectType);
        }

        [TestMethod]
        public void It_has_a_constructor_that_takes_an_IdmResource()
        {
            var resource = new IdmResource
            {
                DisplayName = "My Display Name",
                Creator = new Person { DisplayName = "Creator Display Name", ObjectID = "Creator ObjectID"},
            };
            var it = new DomainConfiguration(resource);

            Assert.AreEqual("DomainConfiguration", it.ObjectType);
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
            var it = new DomainConfiguration(resource);

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
        public void It_can_get_and_set_Domain()
        {
            // Act
            _it.Domain = "A string";

            // Assert
            Assert.AreEqual("A string", _it.Domain);
        }


        [TestMethod]
        public void It_has_ForeignSecurityPrincipalSet_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.ForeignSecurityPrincipalSet);
        }

        [TestMethod]
        public void It_has_ForeignSecurityPrincipalSet_which_can_be_set_back_to_null()
        {
            // Arrange
            var testSet = new Set { DisplayName = "Test Set" };			
            _it.ForeignSecurityPrincipalSet = testSet; 

            // Act
            _it.ForeignSecurityPrincipalSet = null;

            // Assert
            Assert.IsNull(_it.ForeignSecurityPrincipalSet);
        }

        [TestMethod]
        public void It_can_get_and_set_ForeignSecurityPrincipalSet()
        {
            // Act
			var testSet = new Set { DisplayName = "Test Set" };			
            _it.ForeignSecurityPrincipalSet = testSet; 

            // Assert
            Assert.AreEqual(testSet.DisplayName, _it.ForeignSecurityPrincipalSet.DisplayName);
        }


        [TestMethod]
        public void It_has_ForestConfiguration_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.ForestConfiguration);
        }

        [TestMethod]
        public void It_has_ForestConfiguration_which_can_be_set_back_to_null()
        {
            // Arrange
            var testForestConfiguration = new ForestConfiguration { DisplayName = "Test ForestConfiguration" };			
            _it.ForestConfiguration = testForestConfiguration; 

            // Act
            _it.ForestConfiguration = null;

            // Assert
            Assert.IsNull(_it.ForestConfiguration);
        }

        [TestMethod]
        public void It_can_get_and_set_ForestConfiguration()
        {
            // Act
			var testForestConfiguration = new ForestConfiguration { DisplayName = "Test ForestConfiguration" };			
            _it.ForestConfiguration = testForestConfiguration; 

            // Assert
            Assert.AreEqual(testForestConfiguration.DisplayName, _it.ForestConfiguration.DisplayName);
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


    }
}
