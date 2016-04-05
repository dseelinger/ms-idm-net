using System;
using System.Collections.Generic;
using IdmNet.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable ObjectCreationAsStatement
// ReSharper disable UseObjectOrCollectionInitializer

namespace IdmNet.Models.Tests
{
    [TestClass]
    public class msidmPamRoleTests
    {
        private msidmPamRole _it;

        public msidmPamRoleTests()
        {
            _it = new msidmPamRole();
        }

        [TestMethod]
        public void It_has_a_paremeterless_constructor()
        {
            Assert.AreEqual("msidmPamRole", _it.ObjectType);
        }

        [TestMethod]
        public void It_has_a_constructor_that_takes_an_IdmResource()
        {
            var resource = new IdmResource
            {
                DisplayName = "My Display Name",
                Creator = new Person { DisplayName = "Creator Display Name", ObjectID = "Creator ObjectID"},
            };
            var it = new msidmPamRole(resource);

            Assert.AreEqual("msidmPamRole", it.ObjectType);
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
            var it = new msidmPamRole(resource);

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
        public void It_has_msidmPamIsRoleApprovalNeeded_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.msidmPamIsRoleApprovalNeeded);
        }

        [TestMethod]
        public void It_has_msidmPamIsRoleApprovalNeeded_which_can_be_set_back_to_null()
        {
            // Arrange
            _it.msidmPamIsRoleApprovalNeeded = true;

            // Act
            _it.msidmPamIsRoleApprovalNeeded = null;

            // Assert
            Assert.IsNull(_it.msidmPamIsRoleApprovalNeeded);
        }

        [TestMethod]
        public void It_can_get_and_set_msidmPamIsRoleApprovalNeeded()
        {
            // Act
            _it.msidmPamIsRoleApprovalNeeded = true;

            // Assert
            Assert.AreEqual(true, _it.msidmPamIsRoleApprovalNeeded);
        }


        [TestMethod]
        public void It_has_msidmPamRoleAvailabilityWindowEnabled_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.msidmPamRoleAvailabilityWindowEnabled);
        }

        [TestMethod]
        public void It_has_msidmPamRoleAvailabilityWindowEnabled_which_can_be_set_back_to_null()
        {
            // Arrange
            _it.msidmPamRoleAvailabilityWindowEnabled = true;

            // Act
            _it.msidmPamRoleAvailabilityWindowEnabled = null;

            // Assert
            Assert.IsNull(_it.msidmPamRoleAvailabilityWindowEnabled);
        }

        [TestMethod]
        public void It_can_get_and_set_msidmPamRoleAvailabilityWindowEnabled()
        {
            // Act
            _it.msidmPamRoleAvailabilityWindowEnabled = true;

            // Assert
            Assert.AreEqual(true, _it.msidmPamRoleAvailabilityWindowEnabled);
        }


        [TestMethod]
        public void It_has_msidmPamRoleAvailableFrom_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.msidmPamRoleAvailableFrom);
        }

        [TestMethod]
        public void It_has_msidmPamRoleAvailableFrom_which_can_be_set_back_to_null()
        {
            // Arrange
            var now = DateTime.Now;
            var testTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);
            _it.msidmPamRoleAvailableFrom = testTime;

            // Act
            _it.msidmPamRoleAvailableFrom = null;

            // Assert
            Assert.IsNull(_it.msidmPamRoleAvailableFrom);
        }

        [TestMethod]
        public void It_can_get_and_set_msidmPamRoleAvailableFrom()
        {
            // Act
            var now = DateTime.Now;
            var testTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);
            _it.msidmPamRoleAvailableFrom = testTime;

            // Assert
            Assert.AreEqual(testTime, _it.msidmPamRoleAvailableFrom);
        }


        [TestMethod]
        public void It_has_msidmPamRoleAvailableTo_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.msidmPamRoleAvailableTo);
        }

        [TestMethod]
        public void It_has_msidmPamRoleAvailableTo_which_can_be_set_back_to_null()
        {
            // Arrange
            var now = DateTime.Now;
            var testTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);
            _it.msidmPamRoleAvailableTo = testTime;

            // Act
            _it.msidmPamRoleAvailableTo = null;

            // Assert
            Assert.IsNull(_it.msidmPamRoleAvailableTo);
        }

        [TestMethod]
        public void It_can_get_and_set_msidmPamRoleAvailableTo()
        {
            // Act
            var now = DateTime.Now;
            var testTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);
            _it.msidmPamRoleAvailableTo = testTime;

            // Assert
            Assert.AreEqual(testTime, _it.msidmPamRoleAvailableTo);
        }


        [TestMethod]
        public void It_has_msidmPamRoleMfaEnabled_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.msidmPamRoleMfaEnabled);
        }

        [TestMethod]
        public void It_has_msidmPamRoleMfaEnabled_which_can_be_set_back_to_null()
        {
            // Arrange
            _it.msidmPamRoleMfaEnabled = true;

            // Act
            _it.msidmPamRoleMfaEnabled = null;

            // Assert
            Assert.IsNull(_it.msidmPamRoleMfaEnabled);
        }

        [TestMethod]
        public void It_can_get_and_set_msidmPamRoleMfaEnabled()
        {
            // Act
            _it.msidmPamRoleMfaEnabled = true;

            // Assert
            Assert.AreEqual(true, _it.msidmPamRoleMfaEnabled);
        }


        [TestMethod]
        public void It_has_Owner_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.Owner);
        }

        [TestMethod]
        public void It_has_Owner_which_can_be_set_back_to_null()
        {
            // Arrange
            var list = new List<Person>
            {
                new Person { DisplayName = "Test Person1", ObjectID = "guid1" },
                new Person { DisplayName = "Test Person2", ObjectID = "guid2" }
            };
            _it.Owner = list;

            // Act
            _it.Owner = null;

            // Assert
            Assert.IsNull(_it.Owner);
        }

        [TestMethod]
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
            Assert.AreEqual(list[0].DisplayName, _it.Owner[0].DisplayName);
            Assert.AreEqual(list[1].DisplayName, _it.Owner[1].DisplayName);
        }


        [TestMethod]
        public void It_has_msidmPamCandidates_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.msidmPamCandidates);
        }

        [TestMethod]
        public void It_has_msidmPamCandidates_which_can_be_set_back_to_null()
        {
            // Arrange
            var list = new List<IdmResource>
            {
                new IdmResource { DisplayName = "Test IdmResource1", ObjectID = "guid1" },
                new IdmResource { DisplayName = "Test IdmResource2", ObjectID = "guid2" }
            };
            _it.msidmPamCandidates = list;

            // Act
            _it.msidmPamCandidates = null;

            // Assert
            Assert.IsNull(_it.msidmPamCandidates);
        }

        [TestMethod]
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
            Assert.AreEqual(list[0].DisplayName, _it.msidmPamCandidates[0].DisplayName);
            Assert.AreEqual(list[1].DisplayName, _it.msidmPamCandidates[1].DisplayName);
        }


        [TestMethod]
        public void It_has_msidmPamPrivileges_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.msidmPamPrivileges);
        }

        [TestMethod]
        public void It_has_msidmPamPrivileges_which_can_be_set_back_to_null()
        {
            // Arrange
            var list = new List<IdmResource>
            {
                new IdmResource { DisplayName = "Test IdmResource1", ObjectID = "guid1" },
                new IdmResource { DisplayName = "Test IdmResource2", ObjectID = "guid2" }
            };
            _it.msidmPamPrivileges = list;

            // Act
            _it.msidmPamPrivileges = null;

            // Assert
            Assert.IsNull(_it.msidmPamPrivileges);
        }

        [TestMethod]
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
            Assert.AreEqual(list[0].DisplayName, _it.msidmPamPrivileges[0].DisplayName);
            Assert.AreEqual(list[1].DisplayName, _it.msidmPamPrivileges[1].DisplayName);
        }


        [TestMethod]
        public void It_can_get_and_set_msidmPamRoleTTL()
        {
            // Act
            _it.msidmPamRoleTTL = 123;

            // Assert
            Assert.AreEqual(123, _it.msidmPamRoleTTL);
        }


    }
}
