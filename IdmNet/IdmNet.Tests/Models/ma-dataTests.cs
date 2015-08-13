using System;
using System.Collections.Generic;
using IdmNet.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable ObjectCreationAsStatement
// ReSharper disable UseObjectOrCollectionInitializer

namespace IdmNet.Models.Tests
{
    [TestClass]
    public class ma_dataTests
    {
        private ma_data _it;

        public ma_dataTests()
        {
            _it = new ma_data();
        }

        [TestMethod]
        public void It_has_a_paremeterless_constructor()
        {
            Assert.AreEqual("ma-data", _it.ObjectType);
        }

        [TestMethod]
        public void It_has_a_constructor_that_takes_an_IdmResource()
        {
            var resource = new IdmResource
            {
                DisplayName = "My Display Name",
                Creator = new Person { DisplayName = "Creator Display Name", ObjectID = "Creator ObjectID"},
            };
            var it = new ma_data(resource);

            Assert.AreEqual("ma-data", it.ObjectType);
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
            var it = new ma_data(resource);

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
        public void It_can_get_and_set_SyncConfig_attribute_inclusion()
        {
            // Act
            _it.SyncConfig_attribute_inclusion = "A string";

            // Assert
            Assert.AreEqual("A string", _it.SyncConfig_attribute_inclusion);
        }


        [TestMethod]
        public void It_has_SyncConfig_capabilities_mask_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.SyncConfig_capabilities_mask);
        }

        [TestMethod]
        public void It_has_SyncConfig_capabilities_mask_which_can_be_set_back_to_null()
        {
            // Arrange
            _it.SyncConfig_capabilities_mask = 123;

            // Act
            _it.SyncConfig_capabilities_mask = null;

            // Assert
            Assert.IsNull(_it.SyncConfig_capabilities_mask);
        }

        [TestMethod]
        public void It_can_get_and_set_SyncConfig_capabilities_mask()
        {
            // Act
            _it.SyncConfig_capabilities_mask = 123;

            // Assert
            Assert.AreEqual(123, _it.SyncConfig_capabilities_mask);
        }


        [TestMethod]
        public void It_can_get_and_set_SyncConfig_category()
        {
            // Act
            _it.SyncConfig_category = "A string";

            // Assert
            Assert.AreEqual("A string", _it.SyncConfig_category);
        }


        [TestMethod]
        public void It_can_get_and_set_SyncConfig_component_mappings()
        {
            // Act
            _it.SyncConfig_component_mappings = "A string";

            // Assert
            Assert.AreEqual("A string", _it.SyncConfig_component_mappings);
        }


        [TestMethod]
        public void It_can_get_and_set_SyncConfig_controller_configuration()
        {
            // Act
            _it.SyncConfig_controller_configuration = "A string";

            // Assert
            Assert.AreEqual("A string", _it.SyncConfig_controller_configuration);
        }


        [TestMethod]
        public void It_can_get_and_set_SyncConfig_creation_time()
        {
            // Act
            _it.SyncConfig_creation_time = "A string";

            // Assert
            Assert.AreEqual("A string", _it.SyncConfig_creation_time);
        }


        [TestMethod]
        public void It_can_get_and_set_SyncConfig_dn_construction()
        {
            // Act
            _it.SyncConfig_dn_construction = "A string";

            // Assert
            Assert.AreEqual("A string", _it.SyncConfig_dn_construction);
        }


        [TestMethod]
        public void It_can_get_and_set_SyncConfig_encrypted_attributes()
        {
            // Act
            _it.SyncConfig_encrypted_attributes = "A string";

            // Assert
            Assert.AreEqual("A string", _it.SyncConfig_encrypted_attributes);
        }


        [TestMethod]
        public void It_can_get_and_set_SyncConfig_export_attribute_flow()
        {
            // Act
            _it.SyncConfig_export_attribute_flow = "A string";

            // Assert
            Assert.AreEqual("A string", _it.SyncConfig_export_attribute_flow);
        }


        [TestMethod]
        public void It_has_SyncConfig_export_type_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.SyncConfig_export_type);
        }

        [TestMethod]
        public void It_has_SyncConfig_export_type_which_can_be_set_back_to_null()
        {
            // Arrange
            _it.SyncConfig_export_type = 123;

            // Act
            _it.SyncConfig_export_type = null;

            // Assert
            Assert.IsNull(_it.SyncConfig_export_type);
        }

        [TestMethod]
        public void It_can_get_and_set_SyncConfig_export_type()
        {
            // Act
            _it.SyncConfig_export_type = 123;

            // Assert
            Assert.AreEqual(123, _it.SyncConfig_export_type);
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
        public void It_can_get_and_set_SyncConfig_id()
        {
            // Act
            _it.SyncConfig_id = "A string";

            // Assert
            Assert.AreEqual("A string", _it.SyncConfig_id);
        }


        [TestMethod]
        public void It_has_SyncConfig_internal_version_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.SyncConfig_internal_version);
        }

        [TestMethod]
        public void It_has_SyncConfig_internal_version_which_can_be_set_back_to_null()
        {
            // Arrange
            _it.SyncConfig_internal_version = 123;

            // Act
            _it.SyncConfig_internal_version = null;

            // Assert
            Assert.IsNull(_it.SyncConfig_internal_version);
        }

        [TestMethod]
        public void It_can_get_and_set_SyncConfig_internal_version()
        {
            // Act
            _it.SyncConfig_internal_version = 123;

            // Assert
            Assert.AreEqual(123, _it.SyncConfig_internal_version);
        }


        [TestMethod]
        public void It_can_get_and_set_SyncConfig_join()
        {
            // Act
            _it.SyncConfig_join = "A string";

            // Assert
            Assert.AreEqual("A string", _it.SyncConfig_join);
        }


        [TestMethod]
        public void It_can_get_and_set_SyncConfig_last_modification_time()
        {
            // Act
            _it.SyncConfig_last_modification_time = "A string";

            // Assert
            Assert.AreEqual("A string", _it.SyncConfig_last_modification_time);
        }


        [TestMethod]
        public void It_can_get_and_set_SyncConfig_ma_companyname()
        {
            // Act
            _it.SyncConfig_ma_companyname = "A string";

            // Assert
            Assert.AreEqual("A string", _it.SyncConfig_ma_companyname);
        }


        [TestMethod]
        public void It_can_get_and_set_SyncConfig_ma_listname()
        {
            // Act
            _it.SyncConfig_ma_listname = "A string";

            // Assert
            Assert.AreEqual("A string", _it.SyncConfig_ma_listname);
        }


        [TestMethod]
        public void It_has_SyncConfig_ma_partition_data_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.SyncConfig_ma_partition_data);
        }

        [TestMethod]
        public void It_has_SyncConfig_ma_partition_data_which_can_be_set_back_to_null()
        {
            // Arrange
            var subObject1 = "foo1";
            var subObject2 = "foo2";
            var list = new List<string> { subObject1, subObject2 };
            _it.SyncConfig_ma_partition_data = list; 

            // Act
            _it.SyncConfig_ma_partition_data = null;

            // Assert
            Assert.IsNull(_it.SyncConfig_ma_partition_data);
        }

        [TestMethod]
        public void It_can_get_and_set_SyncConfig_ma_partition_data()
        {
            var subObject1 = "foo1";
            var subObject2 = "foo2";
            var list = new List<string> { subObject1, subObject2 };

            // Act
            _it.SyncConfig_ma_partition_data = list; 

            // Assert
            Assert.AreEqual("foo1", _it.SyncConfig_ma_partition_data[0]);
            Assert.AreEqual("foo2", _it.SyncConfig_ma_partition_data[1]);
        }


        [TestMethod]
        public void It_has_SyncConfig_ma_run_data_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.SyncConfig_ma_run_data);
        }

        [TestMethod]
        public void It_has_SyncConfig_ma_run_data_which_can_be_set_back_to_null()
        {
            // Arrange
            var subObject1 = "foo1";
            var subObject2 = "foo2";
            var list = new List<string> { subObject1, subObject2 };
            _it.SyncConfig_ma_run_data = list; 

            // Act
            _it.SyncConfig_ma_run_data = null;

            // Assert
            Assert.IsNull(_it.SyncConfig_ma_run_data);
        }

        [TestMethod]
        public void It_can_get_and_set_SyncConfig_ma_run_data()
        {
            var subObject1 = "foo1";
            var subObject2 = "foo2";
            var list = new List<string> { subObject1, subObject2 };

            // Act
            _it.SyncConfig_ma_run_data = list; 

            // Assert
            Assert.AreEqual("foo1", _it.SyncConfig_ma_run_data[0]);
            Assert.AreEqual("foo2", _it.SyncConfig_ma_run_data[1]);
        }


        [TestMethod]
        public void It_can_get_and_set_SyncConfig_ma_ui_settings()
        {
            // Act
            _it.SyncConfig_ma_ui_settings = "A string";

            // Assert
            Assert.AreEqual("A string", _it.SyncConfig_ma_ui_settings);
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
        public void It_has_SyncConfig_password_sync_allowed_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.SyncConfig_password_sync_allowed);
        }

        [TestMethod]
        public void It_has_SyncConfig_password_sync_allowed_which_can_be_set_back_to_null()
        {
            // Arrange
            _it.SyncConfig_password_sync_allowed = 123;

            // Act
            _it.SyncConfig_password_sync_allowed = null;

            // Assert
            Assert.IsNull(_it.SyncConfig_password_sync_allowed);
        }

        [TestMethod]
        public void It_can_get_and_set_SyncConfig_password_sync_allowed()
        {
            // Act
            _it.SyncConfig_password_sync_allowed = 123;

            // Assert
            Assert.AreEqual(123, _it.SyncConfig_password_sync_allowed);
        }


        [TestMethod]
        public void It_can_get_and_set_SyncConfig_private_configuration()
        {
            // Act
            _it.SyncConfig_private_configuration = "A string";

            // Assert
            Assert.AreEqual("A string", _it.SyncConfig_private_configuration);
        }


        [TestMethod]
        public void It_can_get_and_set_SyncConfig_projection()
        {
            // Act
            _it.SyncConfig_projection = "A string";

            // Assert
            Assert.AreEqual("A string", _it.SyncConfig_projection);
        }


        [TestMethod]
        public void It_can_get_and_set_SyncConfig_provisioning_cleanup()
        {
            // Act
            _it.SyncConfig_provisioning_cleanup = "A string";

            // Assert
            Assert.AreEqual("A string", _it.SyncConfig_provisioning_cleanup);
        }


        [TestMethod]
        public void It_can_get_and_set_SyncConfig_provisioning_cleanup_type()
        {
            // Act
            _it.SyncConfig_provisioning_cleanup_type = "A string";

            // Assert
            Assert.AreEqual("A string", _it.SyncConfig_provisioning_cleanup_type);
        }


        [TestMethod]
        public void It_has_SyncConfig_refresh_schema_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.SyncConfig_refresh_schema);
        }

        [TestMethod]
        public void It_has_SyncConfig_refresh_schema_which_can_be_set_back_to_null()
        {
            // Arrange
            _it.SyncConfig_refresh_schema = 123;

            // Act
            _it.SyncConfig_refresh_schema = null;

            // Assert
            Assert.IsNull(_it.SyncConfig_refresh_schema);
        }

        [TestMethod]
        public void It_can_get_and_set_SyncConfig_refresh_schema()
        {
            // Act
            _it.SyncConfig_refresh_schema = 123;

            // Assert
            Assert.AreEqual(123, _it.SyncConfig_refresh_schema);
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
        public void It_can_get_and_set_SyncConfig_stay_disconnector()
        {
            // Act
            _it.SyncConfig_stay_disconnector = "A string";

            // Assert
            Assert.AreEqual("A string", _it.SyncConfig_stay_disconnector);
        }


        [TestMethod]
        public void It_can_get_and_set_SyncConfig_sub_type()
        {
            // Act
            _it.SyncConfig_sub_type = "A string";

            // Assert
            Assert.AreEqual("A string", _it.SyncConfig_sub_type);
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
