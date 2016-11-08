using System;
using System.Collections.Generic;
using IdmNet.Models;
using Xunit;
using FluentAssertions;
// ReSharper disable ObjectCreationAsStatement
// ReSharper disable UseObjectOrCollectionInitializer

namespace IdmNet.Models.Tests
{
    public class msidmPamRoleTests
    {
        private msidmPamRole _it;

        public msidmPamRoleTests()
        {
            _it = new msidmPamRole();
        }

        [Fact]
        public void It_has_a_paremeterless_constructor()
        {
            _it.ObjectType.Should().Be("msidmPamRole");
        }

        [Fact]
        public void It_has_a_constructor_that_takes_an_IdmResource()
        {
            var resource = new IdmResource
            {
                DisplayName = "My Display Name",
                Creator = new Person { DisplayName = "Creator Display Name", ObjectID = "Creator ObjectID"},
            };
            var it = new msidmPamRole(resource);

            it.ObjectType.Should().Be("msidmPamRole");
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
            var it = new msidmPamRole(resource);

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
        public void It_has_msidmPamIsRoleApprovalNeeded_which_is_null_by_default()
        {
            // Assert
            _it.msidmPamIsRoleApprovalNeeded.Should().Be(null);
        }

        [Fact]
        public void It_has_msidmPamIsRoleApprovalNeeded_which_can_be_set_back_to_null()
        {
            // Arrange
            _it.msidmPamIsRoleApprovalNeeded = true;

            // Act
            _it.msidmPamIsRoleApprovalNeeded = null;

            // Assert
            _it.msidmPamIsRoleApprovalNeeded.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_msidmPamIsRoleApprovalNeeded()
        {
            // Act
            _it.msidmPamIsRoleApprovalNeeded = true;

            // Assert
            _it.msidmPamIsRoleApprovalNeeded.Should().Be(true);
        }


        [Fact]
        public void It_has_msidmPamRoleAvailabilityWindowEnabled_which_is_null_by_default()
        {
            // Assert
            _it.msidmPamRoleAvailabilityWindowEnabled.Should().Be(null);
        }

        [Fact]
        public void It_has_msidmPamRoleAvailabilityWindowEnabled_which_can_be_set_back_to_null()
        {
            // Arrange
            _it.msidmPamRoleAvailabilityWindowEnabled = true;

            // Act
            _it.msidmPamRoleAvailabilityWindowEnabled = null;

            // Assert
            _it.msidmPamRoleAvailabilityWindowEnabled.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_msidmPamRoleAvailabilityWindowEnabled()
        {
            // Act
            _it.msidmPamRoleAvailabilityWindowEnabled = true;

            // Assert
            _it.msidmPamRoleAvailabilityWindowEnabled.Should().Be(true);
        }


        [Fact]
        public void It_has_msidmPamRoleAvailableFrom_which_is_null_by_default()
        {
            // Assert
            _it.msidmPamRoleAvailableFrom.Should().Be(null);
        }

        [Fact]
        public void It_has_msidmPamRoleAvailableFrom_which_can_be_set_back_to_null()
        {
            // Arrange
            var now = DateTime.Now;
            var testTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);
            _it.msidmPamRoleAvailableFrom = testTime;

            // Act
            _it.msidmPamRoleAvailableFrom = null;

            // Assert
            _it.msidmPamRoleAvailableFrom.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_msidmPamRoleAvailableFrom()
        {
            // Act
            var now = DateTime.Now;
            var testTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);
            _it.msidmPamRoleAvailableFrom = testTime;

            // Assert
            _it.msidmPamRoleAvailableFrom.Should().Be(testTime);
        }


        [Fact]
        public void It_has_msidmPamRoleAvailableTo_which_is_null_by_default()
        {
            // Assert
            _it.msidmPamRoleAvailableTo.Should().Be(null);
        }

        [Fact]
        public void It_has_msidmPamRoleAvailableTo_which_can_be_set_back_to_null()
        {
            // Arrange
            var now = DateTime.Now;
            var testTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);
            _it.msidmPamRoleAvailableTo = testTime;

            // Act
            _it.msidmPamRoleAvailableTo = null;

            // Assert
            _it.msidmPamRoleAvailableTo.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_msidmPamRoleAvailableTo()
        {
            // Act
            var now = DateTime.Now;
            var testTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);
            _it.msidmPamRoleAvailableTo = testTime;

            // Assert
            _it.msidmPamRoleAvailableTo.Should().Be(testTime);
        }


        [Fact]
        public void It_has_msidmPamRoleMfaEnabled_which_is_null_by_default()
        {
            // Assert
            _it.msidmPamRoleMfaEnabled.Should().Be(null);
        }

        [Fact]
        public void It_has_msidmPamRoleMfaEnabled_which_can_be_set_back_to_null()
        {
            // Arrange
            _it.msidmPamRoleMfaEnabled = true;

            // Act
            _it.msidmPamRoleMfaEnabled = null;

            // Assert
            _it.msidmPamRoleMfaEnabled.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_msidmPamRoleMfaEnabled()
        {
            // Act
            _it.msidmPamRoleMfaEnabled = true;

            // Assert
            _it.msidmPamRoleMfaEnabled.Should().Be(true);
        }


        [Fact]
        public void It_has_Owner_which_is_an_empty_collection_by_default()
        {
            // Assert
            _it.Owner.Should().BeEmpty();
        }

        [Fact]
        public void It_has_Owner_which_as_a_collection_cannot_be_set_to_null()
        {
            // Assert
            Action action = () => _it.Owner = null;
            action.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void It_can_get_and_set_Owner()
        {
            // Arrange
            var list = new List<Person>
            {
                new Person { DisplayName = "Test Person1", ObjectID = "guid1" },
                new Person { DisplayName = "Test Person2", ObjectID = "guid2" }
            };

            // Act
            _it.Owner = list;

            // Assert
            _it.Owner[0].DisplayName.Should().Be(list[0].DisplayName);
            _it.Owner[1].DisplayName.Should().Be(list[1].DisplayName);
        }

        [Fact]
        public void It_has_msidmPamCandidates_which_is_an_empty_collection_by_default()
        {
            // Assert
            _it.msidmPamCandidates.Should().BeEmpty();
        }

        [Fact]
        public void It_has_msidmPamCandidates_which_as_a_collection_cannot_be_set_to_null()
        {
            // Assert
            Action action = () => _it.msidmPamCandidates = null;
            action.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void It_can_get_and_set_msidmPamCandidates()
        {
            // Arrange
            var list = new List<IdmResource>
            {
                new IdmResource { DisplayName = "Test IdmResource1", ObjectID = "guid1" },
                new IdmResource { DisplayName = "Test IdmResource2", ObjectID = "guid2" }
            };

            // Act
            _it.msidmPamCandidates = list;

            // Assert
            _it.msidmPamCandidates[0].DisplayName.Should().Be(list[0].DisplayName);
            _it.msidmPamCandidates[1].DisplayName.Should().Be(list[1].DisplayName);
        }

        [Fact]
        public void It_has_msidmPamPrivileges_which_is_an_empty_collection_by_default()
        {
            // Assert
            _it.msidmPamPrivileges.Should().BeEmpty();
        }

        [Fact]
        public void It_has_msidmPamPrivileges_which_as_a_collection_cannot_be_set_to_null()
        {
            // Assert
            Action action = () => _it.msidmPamPrivileges = null;
            action.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void It_can_get_and_set_msidmPamPrivileges()
        {
            // Arrange
            var list = new List<IdmResource>
            {
                new IdmResource { DisplayName = "Test IdmResource1", ObjectID = "guid1" },
                new IdmResource { DisplayName = "Test IdmResource2", ObjectID = "guid2" }
            };

            // Act
            _it.msidmPamPrivileges = list;

            // Assert
            _it.msidmPamPrivileges[0].DisplayName.Should().Be(list[0].DisplayName);
            _it.msidmPamPrivileges[1].DisplayName.Should().Be(list[1].DisplayName);
        }

        [Fact]
        public void It_can_get_and_set_msidmPamRoleTTL()
        {
            // Act
            _it.msidmPamRoleTTL = 123;

            // Assert
            _it.msidmPamRoleTTL.Should().Be(123);
        }


    }
}
