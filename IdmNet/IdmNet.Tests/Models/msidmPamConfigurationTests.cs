using System;
using System.Collections.Generic;
using IdmNet.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable ObjectCreationAsStatement
// ReSharper disable UseObjectOrCollectionInitializer

namespace IdmNet.Models.Tests
{
    [TestClass]
    public class msidmPamConfigurationTests
    {
        private msidmPamConfiguration _it;

        public msidmPamConfigurationTests()
        {
            _it = new msidmPamConfiguration();
        }

        [TestMethod]
        public void It_has_a_paremeterless_constructor()
        {
            Assert.AreEqual("msidmPamConfiguration", _it.ObjectType);
        }

        [TestMethod]
        public void It_has_a_constructor_that_takes_an_IdmResource()
        {
            var resource = new IdmResource
            {
                DisplayName = "My Display Name",
                Creator = new Person { DisplayName = "Creator Display Name", ObjectID = "Creator ObjectID"},
            };
            var it = new msidmPamConfiguration(resource);

            Assert.AreEqual("msidmPamConfiguration", it.ObjectType);
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
            var it = new msidmPamConfiguration(resource);

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
        public void It_can_get_and_set_msidmDefaultADContainer()
        {
            // Act
            _it.msidmDefaultADContainer = "A string";

            // Assert
            Assert.AreEqual("A string", _it.msidmDefaultADContainer);
        }


        [TestMethod]
        public void It_can_get_and_set_msidmPamForestFunctionality()
        {
            // Act
            _it.msidmPamForestFunctionality = "A string";

            // Assert
            Assert.AreEqual("A string", _it.msidmPamForestFunctionality);
        }


        [TestMethod]
        public void It_can_get_and_set_msidmPamPrivUserPrefix()
        {
            // Act
            _it.msidmPamPrivUserPrefix = "A string";

            // Assert
            Assert.AreEqual("A string", _it.msidmPamPrivUserPrefix);
        }


        [TestMethod]
        public void It_can_get_and_set_msidmPamRequestExpirationInDays()
        {
            // Act
            _it.msidmPamRequestExpirationInDays = 123;

            // Assert
            Assert.AreEqual(123, _it.msidmPamRequestExpirationInDays);
        }


        [TestMethod]
        public void It_can_get_and_set_msidmPamRoleDefaultDurationInSeconds()
        {
            // Act
            _it.msidmPamRoleDefaultDurationInSeconds = 123;

            // Assert
            Assert.AreEqual(123, _it.msidmPamRoleDefaultDurationInSeconds);
        }


        [TestMethod]
        public void It_can_get_and_set_msidmPamRoleMaximalDurationInSeconds()
        {
            // Act
            _it.msidmPamRoleMaximalDurationInSeconds = 123;

            // Assert
            Assert.AreEqual(123, _it.msidmPamRoleMaximalDurationInSeconds);
        }


        [TestMethod]
        public void It_can_get_and_set_msidmPamRoleMinimalDurationInSeconds()
        {
            // Act
            _it.msidmPamRoleMinimalDurationInSeconds = 123;

            // Assert
            Assert.AreEqual(123, _it.msidmPamRoleMinimalDurationInSeconds);
        }


        [TestMethod]
        public void It_can_get_and_set_msidmPamUserAdminPasswordLength()
        {
            // Act
            _it.msidmPamUserAdminPasswordLength = 123;

            // Assert
            Assert.AreEqual(123, _it.msidmPamUserAdminPasswordLength);
        }


    }
}
