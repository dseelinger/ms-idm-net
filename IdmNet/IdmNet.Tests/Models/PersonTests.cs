using System;
using System.Collections.Generic;
using IdmNet.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable ObjectCreationAsStatement
// ReSharper disable UseObjectOrCollectionInitializer

namespace IdmNet.Models.Tests
{
    [TestClass]
    public class PersonTests
    {
        private Person _it;

        public PersonTests()
        {
            _it = new Person();
        }

        [TestMethod]
        public void It_has_a_paremeterless_constructor()
        {
            Assert.AreEqual("Person", _it.ObjectType);
        }

        [TestMethod]
        public void It_has_a_constructor_that_takes_an_IdmResource()
        {
            var resource = new IdmResource
            {
                DisplayName = "My Display Name",
                Creator = new Person { DisplayName = "Creator Display Name", ObjectID = "Creator ObjectID"},
            };
            var it = new Person(resource);

            Assert.AreEqual("Person", it.ObjectType);
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
            var it = new Person(resource);

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
        public void It_can_get_and_set_AccountName()
        {
            // Act
            _it.AccountName = "A string";

            // Assert
            Assert.AreEqual("A string", _it.AccountName);
        }


        [TestMethod]
        public void It_can_get_and_set_Address()
        {
            // Act
            _it.Address = "A string";

            // Assert
            Assert.AreEqual("A string", _it.Address);
        }


        [TestMethod]
        public void It_can_get_and_set_City()
        {
            // Act
            _it.City = "A string";

            // Assert
            Assert.AreEqual("A string", _it.City);
        }


        [TestMethod]
        public void It_can_get_and_set_Company()
        {
            // Act
            _it.Company = "A string";

            // Assert
            Assert.AreEqual("A string", _it.Company);
        }


        [TestMethod]
        public void It_can_get_and_set_CostCenter()
        {
            // Act
            _it.CostCenter = "A string";

            // Assert
            Assert.AreEqual("A string", _it.CostCenter);
        }


        [TestMethod]
        public void It_can_get_and_set_CostCenterName()
        {
            // Act
            _it.CostCenterName = "A string";

            // Assert
            Assert.AreEqual("A string", _it.CostCenterName);
        }


        [TestMethod]
        public void It_can_get_and_set_Country()
        {
            // Act
            _it.Country = "A string";

            // Assert
            Assert.AreEqual("A string", _it.Country);
        }


        [TestMethod]
        public void It_can_get_and_set_Department()
        {
            // Act
            _it.Department = "A string";

            // Assert
            Assert.AreEqual("A string", _it.Department);
        }


        [TestMethod]
        public void It_can_get_and_set_Domain()
        {
            // Act
            _it.Domain = "A string";

            // Assert
            Assert.AreEqual("A string", _it.Domain);
        }


        [TestMethod]
        public void It_can_get_and_set_Email()
        {
            // Act
            _it.Email = "A string";

            // Assert
            Assert.AreEqual("A string", _it.Email);
        }


        [TestMethod]
        public void It_can_get_and_set_MailNickname()
        {
            // Act
            _it.MailNickname = "A string";

            // Assert
            Assert.AreEqual("A string", _it.MailNickname);
        }


        [TestMethod]
        public void It_can_get_and_set_EmployeeID()
        {
            // Act
            _it.EmployeeID = "A string";

            // Assert
            Assert.AreEqual("A string", _it.EmployeeID);
        }


        [TestMethod]
        public void It_can_get_and_set_EmployeeType()
        {
            // Act
            _it.EmployeeType = "A string";

            // Assert
            Assert.AreEqual("A string", _it.EmployeeType);
        }


        [TestMethod]
        public void It_can_get_and_set_OfficeFax()
        {
            // Act
            _it.OfficeFax = "A string";

            // Assert
            Assert.AreEqual("A string", _it.OfficeFax);
        }


        [TestMethod]
        public void It_can_get_and_set_FirstName()
        {
            // Act
            _it.FirstName = "A string";

            // Assert
            Assert.AreEqual("A string", _it.FirstName);
        }


        [TestMethod]
        public void It_can_get_and_set_FreezeLevel()
        {
            // Act
            _it.FreezeLevel = "A string";

            // Assert
            Assert.AreEqual("A string", _it.FreezeLevel);
        }


        [TestMethod]
        public void It_can_get_and_set_JobTitle()
        {
            // Act
            _it.JobTitle = "A string";

            // Assert
            Assert.AreEqual("A string", _it.JobTitle);
        }


        [TestMethod]
        public void It_can_get_and_set_LastName()
        {
            // Act
            _it.LastName = "A string";

            // Assert
            Assert.AreEqual("A string", _it.LastName);
        }


        [TestMethod]
        public void It_can_get_and_set_LoginName()
        {
            // Act
            _it.LoginName = "A string";

            // Assert
            Assert.AreEqual("A string", _it.LoginName);
        }


        [TestMethod]
        public void It_can_get_and_set_MiddleName()
        {
            // Act
            _it.MiddleName = "A string";

            // Assert
            Assert.AreEqual("A string", _it.MiddleName);
        }


        [TestMethod]
        public void It_can_get_and_set_MobilePhone()
        {
            // Act
            _it.MobilePhone = "A string";

            // Assert
            Assert.AreEqual("A string", _it.MobilePhone);
        }


        [TestMethod]
        public void It_can_get_and_set_OfficeLocation()
        {
            // Act
            _it.OfficeLocation = "A string";

            // Assert
            Assert.AreEqual("A string", _it.OfficeLocation);
        }


        [TestMethod]
        public void It_can_get_and_set_OfficePhone()
        {
            // Act
            _it.OfficePhone = "A string";

            // Assert
            Assert.AreEqual("A string", _it.OfficePhone);
        }


        [TestMethod]
        public void It_can_get_and_set_msidmOneTimePasswordEmailAddress()
        {
            // Act
            _it.msidmOneTimePasswordEmailAddress = "A string";

            // Assert
            Assert.AreEqual("A string", _it.msidmOneTimePasswordEmailAddress);
        }


        [TestMethod]
        public void It_can_get_and_set_msidmOneTimePasswordMobilePhone()
        {
            // Act
            _it.msidmOneTimePasswordMobilePhone = "A string";

            // Assert
            Assert.AreEqual("A string", _it.msidmOneTimePasswordMobilePhone);
        }


        [TestMethod]
        public void It_can_get_and_set_PostalCode()
        {
            // Act
            _it.PostalCode = "A string";

            // Assert
            Assert.AreEqual("A string", _it.PostalCode);
        }


        [TestMethod]
        public void It_can_get_and_set_ResetPassword()
        {
            // Act
            _it.ResetPassword = "A string";

            // Assert
            Assert.AreEqual("A string", _it.ResetPassword);
        }


    }
}
