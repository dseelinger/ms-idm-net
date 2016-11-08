using System;
using System.Collections.Generic;
using IdmNet.Models;
using Xunit;
using FluentAssertions;
// ReSharper disable ObjectCreationAsStatement
// ReSharper disable UseObjectOrCollectionInitializer

namespace IdmNet.Models.Tests
{
    public class ma_dataTests
    {
        private ma_data _it;

        public ma_dataTests()
        {
            _it = new ma_data();
        }

        [Fact]
        public void It_has_a_paremeterless_constructor()
        {
            _it.ObjectType.Should().Be("ma-data");
        }

        [Fact]
        public void It_has_a_constructor_that_takes_an_IdmResource()
        {
            var resource = new IdmResource
            {
                DisplayName = "My Display Name",
                Creator = new Person { DisplayName = "Creator Display Name", ObjectID = "Creator ObjectID"},
            };
            var it = new ma_data(resource);

            it.ObjectType.Should().Be("ma-data");
            it.DisplayName.Should().Be("My Display Name");
            it.Creator.DisplayName.Should().Be("Creator Display Name");
        }

        [Fact]
        public void It_has_a_constructor_that_takes_an_IdmResource_without_Creator()
        {
            var resource = new IdmResource
            {
                DisplayName = "My Display Name",
            };
            var it = new ma_data(resource);

            it.DisplayName.Should().Be("My Display Name");
            it.Creator.Should().Be(null);
        }

        [Fact]
        public void It_throws_when_you_try_to_set_ObjectType_to_anything_other_than_its_primary_ObjectType()
        {
            Action action = () => _it.ObjectType = "Invalid Object Type";
            action.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void It_can_get_and_set_SyncConfig_attribute_inclusion()
        {
            // Act
            _it.SyncConfig_attribute_inclusion = "A string";

            // Assert
            _it.SyncConfig_attribute_inclusion.Should().Be("A string");
        }


        [Fact]
        public void It_has_SyncConfig_capabilities_mask_which_is_null_by_default()
        {
            // Assert
            _it.SyncConfig_capabilities_mask.Should().Be(null);
        }

        [Fact]
        public void It_has_SyncConfig_capabilities_mask_which_can_be_set_back_to_null()
        {
            // Arrange
            _it.SyncConfig_capabilities_mask = 123;

            // Act
            _it.SyncConfig_capabilities_mask = null;

            // Assert
            _it.SyncConfig_capabilities_mask.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_SyncConfig_capabilities_mask()
        {
            // Act
            _it.SyncConfig_capabilities_mask = 123;

            // Assert
            _it.SyncConfig_capabilities_mask.Should().Be(123);
        }


        [Fact]
        public void It_can_get_and_set_SyncConfig_category()
        {
            // Act
            _it.SyncConfig_category = "A string";

            // Assert
            _it.SyncConfig_category.Should().Be("A string");
        }


        [Fact]
        public void It_can_get_and_set_SyncConfig_component_mappings()
        {
            // Act
            _it.SyncConfig_component_mappings = "A string";

            // Assert
            _it.SyncConfig_component_mappings.Should().Be("A string");
        }


        [Fact]
        public void It_can_get_and_set_SyncConfig_controller_configuration()
        {
            // Act
            _it.SyncConfig_controller_configuration = "A string";

            // Assert
            _it.SyncConfig_controller_configuration.Should().Be("A string");
        }


        [Fact]
        public void It_can_get_and_set_SyncConfig_creation_time()
        {
            // Act
            _it.SyncConfig_creation_time = "A string";

            // Assert
            _it.SyncConfig_creation_time.Should().Be("A string");
        }


        [Fact]
        public void It_can_get_and_set_SyncConfig_dn_construction()
        {
            // Act
            _it.SyncConfig_dn_construction = "A string";

            // Assert
            _it.SyncConfig_dn_construction.Should().Be("A string");
        }


        [Fact]
        public void It_can_get_and_set_SyncConfig_encrypted_attributes()
        {
            // Act
            _it.SyncConfig_encrypted_attributes = "A string";

            // Assert
            _it.SyncConfig_encrypted_attributes.Should().Be("A string");
        }


        [Fact]
        public void It_can_get_and_set_SyncConfig_export_attribute_flow()
        {
            // Act
            _it.SyncConfig_export_attribute_flow = "A string";

            // Assert
            _it.SyncConfig_export_attribute_flow.Should().Be("A string");
        }


        [Fact]
        public void It_has_SyncConfig_export_type_which_is_null_by_default()
        {
            // Assert
            _it.SyncConfig_export_type.Should().Be(null);
        }

        [Fact]
        public void It_has_SyncConfig_export_type_which_can_be_set_back_to_null()
        {
            // Arrange
            _it.SyncConfig_export_type = 123;

            // Act
            _it.SyncConfig_export_type = null;

            // Assert
            _it.SyncConfig_export_type.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_SyncConfig_export_type()
        {
            // Act
            _it.SyncConfig_export_type = 123;

            // Assert
            _it.SyncConfig_export_type.Should().Be(123);
        }


        [Fact]
        public void It_can_get_and_set_SyncConfig_extension()
        {
            // Act
            _it.SyncConfig_extension = "A string";

            // Assert
            _it.SyncConfig_extension.Should().Be("A string");
        }


        [Fact]
        public void It_has_SyncConfig_format_version_which_is_null_by_default()
        {
            // Assert
            _it.SyncConfig_format_version.Should().Be(null);
        }

        [Fact]
        public void It_has_SyncConfig_format_version_which_can_be_set_back_to_null()
        {
            // Arrange
            _it.SyncConfig_format_version = 123;

            // Act
            _it.SyncConfig_format_version = null;

            // Assert
            _it.SyncConfig_format_version.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_SyncConfig_format_version()
        {
            // Act
            _it.SyncConfig_format_version = 123;

            // Assert
            _it.SyncConfig_format_version.Should().Be(123);
        }


        [Fact]
        public void It_can_get_and_set_SyncConfig_id()
        {
            // Act
            _it.SyncConfig_id = "A string";

            // Assert
            _it.SyncConfig_id.Should().Be("A string");
        }


        [Fact]
        public void It_has_SyncConfig_internal_version_which_is_null_by_default()
        {
            // Assert
            _it.SyncConfig_internal_version.Should().Be(null);
        }

        [Fact]
        public void It_has_SyncConfig_internal_version_which_can_be_set_back_to_null()
        {
            // Arrange
            _it.SyncConfig_internal_version = 123;

            // Act
            _it.SyncConfig_internal_version = null;

            // Assert
            _it.SyncConfig_internal_version.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_SyncConfig_internal_version()
        {
            // Act
            _it.SyncConfig_internal_version = 123;

            // Assert
            _it.SyncConfig_internal_version.Should().Be(123);
        }


        [Fact]
        public void It_can_get_and_set_SyncConfig_join()
        {
            // Act
            _it.SyncConfig_join = "A string";

            // Assert
            _it.SyncConfig_join.Should().Be("A string");
        }


        [Fact]
        public void It_can_get_and_set_SyncConfig_last_modification_time()
        {
            // Act
            _it.SyncConfig_last_modification_time = "A string";

            // Assert
            _it.SyncConfig_last_modification_time.Should().Be("A string");
        }


        [Fact]
        public void It_can_get_and_set_SyncConfig_ma_companyname()
        {
            // Act
            _it.SyncConfig_ma_companyname = "A string";

            // Assert
            _it.SyncConfig_ma_companyname.Should().Be("A string");
        }


        [Fact]
        public void It_can_get_and_set_SyncConfig_ma_listname()
        {
            // Act
            _it.SyncConfig_ma_listname = "A string";

            // Assert
            _it.SyncConfig_ma_listname.Should().Be("A string");
        }


        [Fact]
        public void It_has_SyncConfig_ma_partition_data_which_is_an_empty_collection_by_default()
        {
            // Assert
            _it.SyncConfig_ma_partition_data.Should().BeEmpty();
        }

        [Fact]
        public void It_has_SyncConfig_ma_partition_data_which_as_a_collection_cannot_be_set_to_null()
        {
            // Assert
            Action action = () => _it.SyncConfig_ma_partition_data = null;
            action.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void It_can_get_and_set_SyncConfig_ma_partition_data()
        {
            var subObject1 = "foo1";
            var subObject2 = "foo2";
            var list = new List<string> { subObject1, subObject2 };

            // Act
            _it.SyncConfig_ma_partition_data = list; 

            // Assert
            _it.SyncConfig_ma_partition_data[0].Should().Be("foo1");
            _it.SyncConfig_ma_partition_data[1].Should().Be("foo2");
        }


        [Fact]
        public void It_has_SyncConfig_ma_run_data_which_is_an_empty_collection_by_default()
        {
            // Assert
            _it.SyncConfig_ma_run_data.Should().BeEmpty();
        }

        [Fact]
        public void It_has_SyncConfig_ma_run_data_which_as_a_collection_cannot_be_set_to_null()
        {
            // Assert
            Action action = () => _it.SyncConfig_ma_run_data = null;
            action.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void It_can_get_and_set_SyncConfig_ma_run_data()
        {
            var subObject1 = "foo1";
            var subObject2 = "foo2";
            var list = new List<string> { subObject1, subObject2 };

            // Act
            _it.SyncConfig_ma_run_data = list; 

            // Assert
            _it.SyncConfig_ma_run_data[0].Should().Be("foo1");
            _it.SyncConfig_ma_run_data[1].Should().Be("foo2");
        }


        [Fact]
        public void It_can_get_and_set_SyncConfig_ma_ui_settings()
        {
            // Act
            _it.SyncConfig_ma_ui_settings = "A string";

            // Assert
            _it.SyncConfig_ma_ui_settings.Should().Be("A string");
        }


        [Fact]
        public void It_can_get_and_set_SyncConfig_password_sync()
        {
            // Act
            _it.SyncConfig_password_sync = "A string";

            // Assert
            _it.SyncConfig_password_sync.Should().Be("A string");
        }


        [Fact]
        public void It_has_SyncConfig_password_sync_allowed_which_is_null_by_default()
        {
            // Assert
            _it.SyncConfig_password_sync_allowed.Should().Be(null);
        }

        [Fact]
        public void It_has_SyncConfig_password_sync_allowed_which_can_be_set_back_to_null()
        {
            // Arrange
            _it.SyncConfig_password_sync_allowed = 123;

            // Act
            _it.SyncConfig_password_sync_allowed = null;

            // Assert
            _it.SyncConfig_password_sync_allowed.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_SyncConfig_password_sync_allowed()
        {
            // Act
            _it.SyncConfig_password_sync_allowed = 123;

            // Assert
            _it.SyncConfig_password_sync_allowed.Should().Be(123);
        }


        [Fact]
        public void It_can_get_and_set_SyncConfig_private_configuration()
        {
            // Act
            _it.SyncConfig_private_configuration = "A string";

            // Assert
            _it.SyncConfig_private_configuration.Should().Be("A string");
        }


        [Fact]
        public void It_can_get_and_set_SyncConfig_projection()
        {
            // Act
            _it.SyncConfig_projection = "A string";

            // Assert
            _it.SyncConfig_projection.Should().Be("A string");
        }


        [Fact]
        public void It_can_get_and_set_SyncConfig_provisioning_cleanup()
        {
            // Act
            _it.SyncConfig_provisioning_cleanup = "A string";

            // Assert
            _it.SyncConfig_provisioning_cleanup.Should().Be("A string");
        }


        [Fact]
        public void It_can_get_and_set_SyncConfig_provisioning_cleanup_type()
        {
            // Act
            _it.SyncConfig_provisioning_cleanup_type = "A string";

            // Assert
            _it.SyncConfig_provisioning_cleanup_type.Should().Be("A string");
        }


        [Fact]
        public void It_has_SyncConfig_refresh_schema_which_is_null_by_default()
        {
            // Assert
            _it.SyncConfig_refresh_schema.Should().Be(null);
        }

        [Fact]
        public void It_has_SyncConfig_refresh_schema_which_can_be_set_back_to_null()
        {
            // Arrange
            _it.SyncConfig_refresh_schema = 123;

            // Act
            _it.SyncConfig_refresh_schema = null;

            // Assert
            _it.SyncConfig_refresh_schema.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_SyncConfig_refresh_schema()
        {
            // Act
            _it.SyncConfig_refresh_schema = 123;

            // Assert
            _it.SyncConfig_refresh_schema.Should().Be(123);
        }


        [Fact]
        public void It_can_get_and_set_SyncConfig_schema()
        {
            // Act
            _it.SyncConfig_schema = "A string";

            // Assert
            _it.SyncConfig_schema.Should().Be("A string");
        }


        [Fact]
        public void It_can_get_and_set_SyncConfig_stay_disconnector()
        {
            // Act
            _it.SyncConfig_stay_disconnector = "A string";

            // Assert
            _it.SyncConfig_stay_disconnector.Should().Be("A string");
        }


        [Fact]
        public void It_can_get_and_set_SyncConfig_sub_type()
        {
            // Act
            _it.SyncConfig_sub_type = "A string";

            // Assert
            _it.SyncConfig_sub_type.Should().Be("A string");
        }


        [Fact]
        public void It_has_SyncConfig_version_which_is_null_by_default()
        {
            // Assert
            _it.SyncConfig_version.Should().Be(null);
        }

        [Fact]
        public void It_has_SyncConfig_version_which_can_be_set_back_to_null()
        {
            // Arrange
            _it.SyncConfig_version = 123;

            // Act
            _it.SyncConfig_version = null;

            // Assert
            _it.SyncConfig_version.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_SyncConfig_version()
        {
            // Act
            _it.SyncConfig_version = 123;

            // Assert
            _it.SyncConfig_version.Should().Be(123);
        }


    }
}
