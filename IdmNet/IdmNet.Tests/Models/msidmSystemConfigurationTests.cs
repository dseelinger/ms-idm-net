using System;
using System.Collections.Generic;
using IdmNet.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable ObjectCreationAsStatement
// ReSharper disable UseObjectOrCollectionInitializer

namespace IdmNet.Models.Tests
{
    [TestClass]
    public class msidmSystemConfigurationTests
    {
        private msidmSystemConfiguration _it;

        public msidmSystemConfigurationTests()
        {
            _it = new msidmSystemConfiguration();
        }

        [TestMethod]
        public void It_has_a_paremeterless_constructor()
        {
            Assert.AreEqual("msidmSystemConfiguration", _it.ObjectType);
        }

        [TestMethod]
        public void It_has_a_constructor_that_takes_an_IdmResource()
        {
            var resource = new IdmResource
            {
                DisplayName = "My Display Name",
                Creator = new Person { DisplayName = "Creator Display Name", ObjectID = "Creator ObjectID"},
            };
            var it = new msidmSystemConfiguration(resource);

            Assert.AreEqual("msidmSystemConfiguration", it.ObjectType);
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
            var it = new msidmSystemConfiguration(resource);

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
        public void It_has_msidmCreateCriteriaBasedGroupsAsDeferredByDefault_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.msidmCreateCriteriaBasedGroupsAsDeferredByDefault);
        }

        [TestMethod]
        public void It_has_msidmCreateCriteriaBasedGroupsAsDeferredByDefault_which_can_be_set_back_to_null()
        {
            // Arrange
            _it.msidmCreateCriteriaBasedGroupsAsDeferredByDefault = true;

            // Act
            _it.msidmCreateCriteriaBasedGroupsAsDeferredByDefault = null;

            // Assert
            Assert.IsNull(_it.msidmCreateCriteriaBasedGroupsAsDeferredByDefault);
        }

        [TestMethod]
        public void It_can_get_and_set_msidmCreateCriteriaBasedGroupsAsDeferredByDefault()
        {
            // Act
            _it.msidmCreateCriteriaBasedGroupsAsDeferredByDefault = true;

            // Assert
            Assert.AreEqual(true, _it.msidmCreateCriteriaBasedGroupsAsDeferredByDefault);
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
        public void It_can_get_and_set_msidmReportingLoggingEnabled()
        {
            // Act
            _it.msidmReportingLoggingEnabled = true;

            // Assert
            Assert.AreEqual(true, _it.msidmReportingLoggingEnabled);
        }


        [TestMethod]
        public void It_can_get_and_set_msidmRequestMaximumActiveDuration()
        {
            // Act
            _it.msidmRequestMaximumActiveDuration = 123;

            // Assert
            Assert.AreEqual(123, _it.msidmRequestMaximumActiveDuration);
        }


        [TestMethod]
        public void It_can_get_and_set_msidmRequestMaximumCancelingDuration()
        {
            // Act
            _it.msidmRequestMaximumCancelingDuration = 123;

            // Assert
            Assert.AreEqual(123, _it.msidmRequestMaximumCancelingDuration);
        }


        [TestMethod]
        public void It_can_get_and_set_msidmSystemThrottleLevel()
        {
            // Act
            _it.msidmSystemThrottleLevel = 123;

            // Assert
            Assert.AreEqual(123, _it.msidmSystemThrottleLevel);
        }


    }
}
