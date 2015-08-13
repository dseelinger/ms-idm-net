using System;
using System.Collections.Generic;
using IdmNet.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable ObjectCreationAsStatement
// ReSharper disable UseObjectOrCollectionInitializer

namespace IdmNet.Models.Tests
{
    [TestClass]
    public class mv_dataTests
    {
        private mv_data _it;

        public mv_dataTests()
        {
            _it = new mv_data();
        }

        [TestMethod]
        public void It_has_a_paremeterless_constructor()
        {
            Assert.AreEqual("mv-data", _it.ObjectType);
        }

        [TestMethod]
        public void It_has_a_constructor_that_takes_an_IdmResource()
        {
            var resource = new IdmResource
            {
                DisplayName = "My Display Name",
                Creator = new Person { DisplayName = "Creator Display Name", ObjectID = "Creator ObjectID"},
            };
            var it = new mv_data(resource);

            Assert.AreEqual("mv-data", it.ObjectType);
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
            var it = new mv_data(resource);

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
        public void It_can_get_and_set_SyncConfig_extension()
        {
            // Act
            _it.SyncConfig_extension = "A string";

            // Assert
            Assert.AreEqual("A string", _it.SyncConfig_extension);
        }


        [TestMethod]
        public void It_has_SyncConfig_format_version_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.SyncConfig_format_version);
        }

        [TestMethod]
        public void It_has_SyncConfig_format_version_which_can_be_set_back_to_null()
        {
            // Arrange
            _it.SyncConfig_format_version = 123;

            // Act
            _it.SyncConfig_format_version = null;

            // Assert
            Assert.IsNull(_it.SyncConfig_format_version);
        }

        [TestMethod]
        public void It_can_get_and_set_SyncConfig_format_version()
        {
            // Act
            _it.SyncConfig_format_version = 123;

            // Assert
            Assert.AreEqual(123, _it.SyncConfig_format_version);
        }


        [TestMethod]
        public void It_can_get_and_set_SyncConfig_import_attribute_flow()
        {
            // Act
            _it.SyncConfig_import_attribute_flow = "A string";

            // Assert
            Assert.AreEqual("A string", _it.SyncConfig_import_attribute_flow);
        }


        [TestMethod]
        public void It_can_get_and_set_SyncConfig_mv_deletion()
        {
            // Act
            _it.SyncConfig_mv_deletion = "A string";

            // Assert
            Assert.AreEqual("A string", _it.SyncConfig_mv_deletion);
        }


        [TestMethod]
        public void It_has_SyncConfig_password_change_history_size_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.SyncConfig_password_change_history_size);
        }

        [TestMethod]
        public void It_has_SyncConfig_password_change_history_size_which_can_be_set_back_to_null()
        {
            // Arrange
            _it.SyncConfig_password_change_history_size = 123;

            // Act
            _it.SyncConfig_password_change_history_size = null;

            // Assert
            Assert.IsNull(_it.SyncConfig_password_change_history_size);
        }

        [TestMethod]
        public void It_can_get_and_set_SyncConfig_password_change_history_size()
        {
            // Act
            _it.SyncConfig_password_change_history_size = 123;

            // Assert
            Assert.AreEqual(123, _it.SyncConfig_password_change_history_size);
        }


        [TestMethod]
        public void It_can_get_and_set_SyncConfig_password_sync()
        {
            // Act
            _it.SyncConfig_password_sync = "A string";

            // Assert
            Assert.AreEqual("A string", _it.SyncConfig_password_sync);
        }


        [TestMethod]
        public void It_can_get_and_set_SyncConfig_provisioning()
        {
            // Act
            _it.SyncConfig_provisioning = "A string";

            // Assert
            Assert.AreEqual("A string", _it.SyncConfig_provisioning);
        }


        [TestMethod]
        public void It_can_get_and_set_SyncConfig_provisioning_type()
        {
            // Act
            _it.SyncConfig_provisioning_type = "A string";

            // Assert
            Assert.AreEqual("A string", _it.SyncConfig_provisioning_type);
        }


        [TestMethod]
        public void It_can_get_and_set_SyncConfig_schema()
        {
            // Act
            _it.SyncConfig_schema = "A string";

            // Assert
            Assert.AreEqual("A string", _it.SyncConfig_schema);
        }


        [TestMethod]
        public void It_has_SyncConfig_version_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.SyncConfig_version);
        }

        [TestMethod]
        public void It_has_SyncConfig_version_which_can_be_set_back_to_null()
        {
            // Arrange
            _it.SyncConfig_version = 123;

            // Act
            _it.SyncConfig_version = null;

            // Assert
            Assert.IsNull(_it.SyncConfig_version);
        }

        [TestMethod]
        public void It_can_get_and_set_SyncConfig_version()
        {
            // Act
            _it.SyncConfig_version = 123;

            // Assert
            Assert.AreEqual(123, _it.SyncConfig_version);
        }


    }
}
