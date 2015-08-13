using System;
using System.Collections.Generic;
using IdmNet.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable ObjectCreationAsStatement
// ReSharper disable UseObjectOrCollectionInitializer

namespace IdmNet.Models.Tests
{
    [TestClass]
    public class ForestConfigurationTests
    {
        private ForestConfiguration _it;

        public ForestConfigurationTests()
        {
            _it = new ForestConfiguration();
        }

        [TestMethod]
        public void It_has_a_paremeterless_constructor()
        {
            Assert.AreEqual("ForestConfiguration", _it.ObjectType);
        }

        [TestMethod]
        public void It_has_a_constructor_that_takes_an_IdmResource()
        {
            var resource = new IdmResource
            {
                DisplayName = "My Display Name",
                Creator = new Person { DisplayName = "Creator Display Name", ObjectID = "Creator ObjectID"},
            };
            var it = new ForestConfiguration(resource);

            Assert.AreEqual("ForestConfiguration", it.ObjectType);
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
            var it = new ForestConfiguration(resource);

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
        public void It_has_ContactSet_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.ContactSet);
        }

        [TestMethod]
        public void It_has_ContactSet_which_can_be_set_back_to_null()
        {
            // Arrange
            var testSet = new Set { DisplayName = "Test Set" };			
            _it.ContactSet = testSet; 

            // Act
            _it.ContactSet = null;

            // Assert
            Assert.IsNull(_it.ContactSet);
        }

        [TestMethod]
        public void It_can_get_and_set_ContactSet()
        {
            // Act
			var testSet = new Set { DisplayName = "Test Set" };			
            _it.ContactSet = testSet; 

            // Assert
            Assert.AreEqual(testSet.DisplayName, _it.ContactSet.DisplayName);
        }


        [TestMethod]
        public void It_has_DistributionListDomain_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.DistributionListDomain);
        }

        [TestMethod]
        public void It_has_DistributionListDomain_which_can_be_set_back_to_null()
        {
            // Arrange
            var testDomainConfiguration = new DomainConfiguration { DisplayName = "Test DomainConfiguration" };			
            _it.DistributionListDomain = testDomainConfiguration; 

            // Act
            _it.DistributionListDomain = null;

            // Assert
            Assert.IsNull(_it.DistributionListDomain);
        }

        [TestMethod]
        public void It_can_get_and_set_DistributionListDomain()
        {
            // Act
			var testDomainConfiguration = new DomainConfiguration { DisplayName = "Test DomainConfiguration" };			
            _it.DistributionListDomain = testDomainConfiguration; 

            // Assert
            Assert.AreEqual(testDomainConfiguration.DisplayName, _it.DistributionListDomain.DisplayName);
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
        public void It_has_TrustedForest_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.TrustedForest);
        }

        [TestMethod]
        public void It_has_TrustedForest_which_can_be_set_back_to_null()
        {
            // Arrange
            var list = new List<ForestConfiguration>
            {
                new ForestConfiguration { DisplayName = "Test ForestConfiguration1", ObjectID = "guid1" },
                new ForestConfiguration { DisplayName = "Test ForestConfiguration2", ObjectID = "guid2" }
            };
            _it.TrustedForest = list;

            // Act
            _it.TrustedForest = null;

            // Assert
            Assert.IsNull(_it.TrustedForest);
        }

        [TestMethod]
        public void It_can_get_and_set_TrustedForest()
        {
            // Arrange
            var list = new List<ForestConfiguration>
            {
                new ForestConfiguration { DisplayName = "Test ForestConfiguration1", ObjectID = "guid1" },
                new ForestConfiguration { DisplayName = "Test ForestConfiguration2", ObjectID = "guid2" }
            };

            // Act
            _it.TrustedForest = list;

            // Assert
            Assert.AreEqual(list[0].DisplayName, _it.TrustedForest[0].DisplayName);
            Assert.AreEqual(list[1].DisplayName, _it.TrustedForest[1].DisplayName);
        }


    }
}
