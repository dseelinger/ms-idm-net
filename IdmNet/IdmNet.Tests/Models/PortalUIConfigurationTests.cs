using System;
using System.Collections.Generic;
using IdmNet.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable ObjectCreationAsStatement
// ReSharper disable UseObjectOrCollectionInitializer

namespace IdmNet.Models.Tests
{
    [TestClass]
    public class PortalUIConfigurationTests
    {
        private PortalUIConfiguration _it;

        public PortalUIConfigurationTests()
        {
            _it = new PortalUIConfiguration();
        }

        [TestMethod]
        public void It_has_a_paremeterless_constructor()
        {
            Assert.AreEqual("PortalUIConfiguration", _it.ObjectType);
        }

        [TestMethod]
        public void It_has_a_constructor_that_takes_an_IdmResource()
        {
            var resource = new IdmResource
            {
                DisplayName = "My Display Name",
                Creator = new Person { DisplayName = "Creator Display Name", ObjectID = "Creator ObjectID"},
            };
            var it = new PortalUIConfiguration(resource);

            Assert.AreEqual("PortalUIConfiguration", it.ObjectType);
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
            var it = new PortalUIConfiguration(resource);

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
        public void It_can_get_and_set_BrandingCenterText()
        {
            // Act
            _it.BrandingCenterText = "A string";

            // Assert
            Assert.AreEqual("A string", _it.BrandingCenterText);
        }


        [TestMethod]
        public void It_can_get_and_set_BrandingLeftImage()
        {
            // Act
            _it.BrandingLeftImage = "A string";

            // Assert
            Assert.AreEqual("A string", _it.BrandingLeftImage);
        }


        [TestMethod]
        public void It_can_get_and_set_BrandingRightImage()
        {
            // Act
            _it.BrandingRightImage = "A string";

            // Assert
            Assert.AreEqual("A string", _it.BrandingRightImage);
        }


        [TestMethod]
        public void It_can_get_and_set_UICacheTime()
        {
            // Act
            _it.UICacheTime = 123;

            // Assert
            Assert.AreEqual(123, _it.UICacheTime);
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
        public void It_can_get_and_set_ListViewCacheTimeOut()
        {
            // Act
            _it.ListViewCacheTimeOut = 123;

            // Assert
            Assert.AreEqual(123, _it.ListViewCacheTimeOut);
        }


        [TestMethod]
        public void It_can_get_and_set_ListViewPageSize()
        {
            // Act
            _it.ListViewPageSize = 123;

            // Assert
            Assert.AreEqual(123, _it.ListViewPageSize);
        }


        [TestMethod]
        public void It_can_get_and_set_ListViewPagesToCache()
        {
            // Act
            _it.ListViewPagesToCache = 123;

            // Assert
            Assert.AreEqual(123, _it.ListViewPagesToCache);
        }


        [TestMethod]
        public void It_can_get_and_set_UICountCacheTime()
        {
            // Act
            _it.UICountCacheTime = 123;

            // Assert
            Assert.AreEqual(123, _it.UICountCacheTime);
        }


        [TestMethod]
        public void It_can_get_and_set_UIUserCacheTime()
        {
            // Act
            _it.UIUserCacheTime = 123;

            // Assert
            Assert.AreEqual(123, _it.UIUserCacheTime);
        }


        [TestMethod]
        public void It_has_TimeZone_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.TimeZone);
        }

        [TestMethod]
        public void It_has_TimeZone_which_can_be_set_back_to_null()
        {
            // Arrange
            var testTimeZoneConfiguration = new TimeZoneConfiguration { DisplayName = "Test TimeZoneConfiguration" };			
            _it.TimeZone = testTimeZoneConfiguration; 

            // Act
            _it.TimeZone = null;

            // Assert
            Assert.IsNull(_it.TimeZone);
        }

        [TestMethod]
        public void It_can_get_and_set_TimeZone()
        {
            // Act
			var testTimeZoneConfiguration = new TimeZoneConfiguration { DisplayName = "Test TimeZoneConfiguration" };			
            _it.TimeZone = testTimeZoneConfiguration; 

            // Assert
            Assert.AreEqual(testTimeZoneConfiguration.DisplayName, _it.TimeZone.DisplayName);
        }


    }
}
