using System;
using System.Collections.Generic;
using IdmNet.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable ObjectCreationAsStatement
// ReSharper disable UseObjectOrCollectionInitializer

namespace IdmNet.Models.Tests
{
    [TestClass]
    public class ActivityInformationConfigurationTests
    {
        private ActivityInformationConfiguration _it;

        public ActivityInformationConfigurationTests()
        {
            _it = new ActivityInformationConfiguration();
        }

        [TestMethod]
        public void It_has_a_paremeterless_constructor()
        {
            Assert.AreEqual("ActivityInformationConfiguration", _it.ObjectType);
        }

        [TestMethod]
        public void It_has_a_constructor_that_takes_an_IdmResource()
        {
            var resource = new IdmResource
            {
                DisplayName = "My Display Name",
                Creator = new Person { DisplayName = "Creator Display Name", ObjectID = "Creator ObjectID"},
            };
            var it = new ActivityInformationConfiguration(resource);

            Assert.AreEqual("ActivityInformationConfiguration", it.ObjectType);
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
            var it = new ActivityInformationConfiguration(resource);

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
        public void It_can_get_and_set_ActivityName()
        {
            // Act
            _it.ActivityName = "A string";

            // Assert
            Assert.AreEqual("A string", _it.ActivityName);
        }


        [TestMethod]
        public void It_can_get_and_set_AssemblyName()
        {
            // Act
            _it.AssemblyName = "A string";

            // Assert
            Assert.AreEqual("A string", _it.AssemblyName);
        }


        [TestMethod]
        public void It_can_get_and_set_IsActionActivity()
        {
            // Act
            _it.IsActionActivity = true;

            // Assert
            Assert.AreEqual(true, _it.IsActionActivity);
        }


        [TestMethod]
        public void It_can_get_and_set_IsAuthenticationActivity()
        {
            // Act
            _it.IsAuthenticationActivity = true;

            // Assert
            Assert.AreEqual(true, _it.IsAuthenticationActivity);
        }


        [TestMethod]
        public void It_can_get_and_set_IsAuthorizationActivity()
        {
            // Act
            _it.IsAuthorizationActivity = true;

            // Assert
            Assert.AreEqual(true, _it.IsAuthorizationActivity);
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
        public void It_can_get_and_set_TypeName()
        {
            // Act
            _it.TypeName = "A string";

            // Assert
            Assert.AreEqual("A string", _it.TypeName);
        }


    }
}
