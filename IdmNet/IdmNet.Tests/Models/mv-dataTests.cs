using System;
using System.Collections.Generic;
using IdmNet.Models;
using Xunit;
using FluentAssertions;
// ReSharper disable ObjectCreationAsStatement
// ReSharper disable UseObjectOrCollectionInitializer

namespace IdmNet.Models.Tests
{
    public class mv_dataTests
    {
        private mv_data _it;

        public mv_dataTests()
        {
            _it = new mv_data();
        }

        [Fact]
        public void It_has_a_paremeterless_constructor()
        {
            _it.ObjectType.Should().Be("mv-data");
        }

        [Fact]
        public void It_has_a_constructor_that_takes_an_IdmResource()
        {
            var resource = new IdmResource
            {
                DisplayName = "My Display Name",
                Creator = new Person { DisplayName = "Creator Display Name", ObjectID = "Creator ObjectID"},
            };
            var it = new mv_data(resource);

            it.ObjectType.Should().Be("mv-data");
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
            var it = new mv_data(resource);

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
        public void It_can_get_and_set_SyncConfig_import_attribute_flow()
        {
            // Act
            _it.SyncConfig_import_attribute_flow = "A string";

            // Assert
            _it.SyncConfig_import_attribute_flow.Should().Be("A string");
        }


        [Fact]
        public void It_can_get_and_set_SyncConfig_mv_deletion()
        {
            // Act
            _it.SyncConfig_mv_deletion = "A string";

            // Assert
            _it.SyncConfig_mv_deletion.Should().Be("A string");
        }


        [Fact]
        public void It_has_SyncConfig_password_change_history_size_which_is_null_by_default()
        {
            // Assert
            _it.SyncConfig_password_change_history_size.Should().Be(null);
        }

        [Fact]
        public void It_has_SyncConfig_password_change_history_size_which_can_be_set_back_to_null()
        {
            // Arrange
            _it.SyncConfig_password_change_history_size = 123;

            // Act
            _it.SyncConfig_password_change_history_size = null;

            // Assert
            _it.SyncConfig_password_change_history_size.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_SyncConfig_password_change_history_size()
        {
            // Act
            _it.SyncConfig_password_change_history_size = 123;

            // Assert
            _it.SyncConfig_password_change_history_size.Should().Be(123);
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
        public void It_can_get_and_set_SyncConfig_provisioning()
        {
            // Act
            _it.SyncConfig_provisioning = "A string";

            // Assert
            _it.SyncConfig_provisioning.Should().Be("A string");
        }


        [Fact]
        public void It_can_get_and_set_SyncConfig_provisioning_type()
        {
            // Act
            _it.SyncConfig_provisioning_type = "A string";

            // Assert
            _it.SyncConfig_provisioning_type.Should().Be("A string");
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
