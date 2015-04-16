using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable ObjectCreationAsStatement
// ReSharper disable UseObjectOrCollectionInitializer

namespace IdmNet.Tests
{
    [TestClass]
    public class PersonTests
    {
        [TestMethod]
        public void It_has_a_paremeterless_constructor()
        {
            var it = new Person();

            Assert.AreEqual("Person", it.ObjectType);
        }

        [TestMethod]
        public void It_has_a_constructor_that_takes_a_SecurityIdentifierResource_without_a_domain_configuration()
        {
            var securityIdentifier = new SecurityIdentifierResource();
            var it = new Person(securityIdentifier);

            Assert.AreEqual("Person", it.ObjectType);
        }

        [TestMethod]
        public void It_has_a_constructor_that_takes_a_SecurityIdentifierResource_WITH_a_domain_configuration()
        {
            var domainConfig = new IdmResource{DisplayName = "myDomainConfig"};
            var securityIdentifier = new SecurityIdentifierResource{DomainConfiguration = domainConfig};
            var it = new Person(securityIdentifier);

            Assert.AreEqual("Person", it.ObjectType);
        }

        [TestMethod]
        public void It_has_a_constructor_that_takes_an_IdmResource()
        {
            var baseClass = new IdmResource();
            var it = new Person(baseClass);

            Assert.AreEqual("Person", it.ObjectType);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void It_throws_when_you_try_to_set_ObjectType_to_anything_other_than_Person()
        {
            new Person { ObjectType = "foo" };
        }

        [TestMethod]
        public void It_returns_null_for_not_present_properties()
        {
            var it = new Person();

            Assert.IsNull(it.AD_UserCannotChangePassword);
            Assert.IsNull(it.Address);
            Assert.IsNull(it.Assistant);
            Assert.IsNull(it.AuthNLockoutRegistrationID);
            Assert.IsNull(it.City);
            Assert.IsNull(it.Company);
            Assert.IsNull(it.CostCenter);
            Assert.IsNull(it.CostCenterName);
            Assert.IsNull(it.Country);
            Assert.IsNull(it.Department);
            Assert.IsNull(it.EmployeeEndDate);
            Assert.IsNull(it.EmployeeID);
            Assert.IsNull(it.EmployeeStartDate);
            Assert.IsNull(it.EmployeeType);
            Assert.IsNull(it.FirstName);
            Assert.IsNull(it.FreezeCount);
            Assert.IsNull(it.FreezeLevel);
            Assert.IsNull(it.IsRASEnabled);
            Assert.IsNull(it.JobTitle);
            Assert.IsNull(it.LastName);
            Assert.IsNull(it.LastResetAttemptTime);
            Assert.IsNull(it.LoginName);
            Assert.IsNull(it.Manager);
            Assert.IsNull(it.MiddleName);
            Assert.IsNull(it.MobilePhone);
            Assert.IsNull(it.OfficeFax);
            Assert.IsNull(it.OfficeLocation);
            Assert.IsNull(it.OfficePhone);
            Assert.IsNull(it.Photo);
            Assert.IsNull(it.PostalCode);
            Assert.IsNull(it.ResetPassword);
            Assert.IsNull(it.Register);
            Assert.IsNull(it.RegistrationRequired);
            Assert.IsNull(it.TimeZone);
            Assert.IsNull(it.msidmOneTimePasswordEmailAddress);
            Assert.IsNull(it.msidmOneTimePasswordMobilePhone);
        }

        [TestMethod]
        public void It_can_set_and_get_bool_properties()
        {
            var it = new Person
            {
                AD_UserCannotChangePassword = true,
                IsRASEnabled =  true,
                Register = true,
                RegistrationRequired = true
            };

            Assert.AreEqual(true, it.AD_UserCannotChangePassword);
            Assert.AreEqual(true, it.IsRASEnabled);
            Assert.AreEqual(true, it.Register);
            Assert.AreEqual(true, it.RegistrationRequired);
        }

        [TestMethod]
        public void It_can_set_and_get_string_properties()
        {
            var it = new Person
            {
                Address = "Test Address",
                City = "Test City",
                Company = "Test Company",
                CostCenter = "Test CostCenter",
                CostCenterName = "Test CostCenterName",
                Country = "Test Country",
                Department = "Test Department",
                EmployeeID = "Test EmployeeID",
                EmployeeType = "Test EmployeeType",
                OfficeFax = "Test OfficeFax",
                FirstName = "Test FirstName",
                FreezeLevel = "Test FreezeLevel",
                JobTitle = "Test JobTitle",
                LastName = "Test LastName",
                LoginName = "Test LoginName",
                MiddleName = "Test MiddleName",
                MobilePhone = "Test MobilePhone",
                OfficeLocation = "Test OfficeLocation",
                OfficePhone = "Test OfficePhone",
                msidmOneTimePasswordEmailAddress = "Test msidmOneTimePasswordEmailAddress",
                msidmOneTimePasswordMobilePhone = "Test msidmOneTimePasswordMobilePhone",
                PostalCode = "Test PostalCode",
                ResetPassword = "Test ResetPassword"
            };

            Assert.AreEqual("Test Address", it.Address);
            Assert.AreEqual("Test City", it.City);
            Assert.AreEqual("Test Company", it.Company);
            Assert.AreEqual("Test CostCenter", it.CostCenter);
            Assert.AreEqual("Test CostCenterName", it.CostCenterName);
            Assert.AreEqual("Test Department", it.Department);
            Assert.AreEqual("Test EmployeeID", it.EmployeeID);
            Assert.AreEqual("Test EmployeeType", it.EmployeeType);
            Assert.AreEqual("Test OfficeFax", it.OfficeFax);
            Assert.AreEqual("Test FirstName", it.FirstName);
            Assert.AreEqual("Test FreezeLevel", it.FreezeLevel);
            Assert.AreEqual("Test JobTitle", it.JobTitle);
            Assert.AreEqual("Test LastName", it.LastName);
            Assert.AreEqual("Test LoginName", it.LoginName);
            Assert.AreEqual("Test MiddleName", it.MiddleName);
            Assert.AreEqual("Test MobilePhone", it.MobilePhone);
            Assert.AreEqual("Test OfficeLocation", it.OfficeLocation);
            Assert.AreEqual("Test OfficePhone", it.OfficePhone);
            Assert.AreEqual("Test msidmOneTimePasswordEmailAddress", it.msidmOneTimePasswordEmailAddress);
            Assert.AreEqual("Test msidmOneTimePasswordMobilePhone", it.msidmOneTimePasswordMobilePhone);
            Assert.AreEqual("Test PostalCode", it.PostalCode);
            Assert.AreEqual("Test ResetPassword", it.ResetPassword);
        }

        [TestMethod]
        public void It_should_be_able_to_set_DateTime_based_single_value_properties()
        {
            var now = DateTime.Now;
            var testTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);
            var it = new Person();

            it.EmployeeEndDate = testTime;
            Assert.AreEqual(testTime, it.EmployeeEndDate);

            it.EmployeeStartDate = testTime;
            Assert.AreEqual(testTime, it.EmployeeStartDate);

            it.LastResetAttemptTime = testTime;
            Assert.AreEqual(testTime, it.LastResetAttemptTime);

            it.ResourceTime = testTime;
            Assert.AreEqual(testTime, it.ResourceTime);
        }

        [TestMethod]
        public void It_can_set_and_get_FreezeCount()
        {
            var it = new Person
            {
                FreezeCount = 1,
            };

            Assert.AreEqual(1, it.FreezeCount);
        }

        [TestMethod]
        public void It_can_set_and_get_AuthNLockoutRegistrationID()
        {
            var subObject1 = new IdmResource { DisplayName = "foo1", ObjectID = "Foo1"};
            var subObject2 = new IdmResource { DisplayName = "foo2", ObjectID = "Foo2"};
            var list = new List<IdmResource> { subObject1, subObject2 };

            var it = new Person
            {
                AuthNLockoutRegistrationID = list                
            };

            Assert.AreEqual("foo1", it.AuthNLockoutRegistrationID[0].DisplayName);
            Assert.AreEqual("foo2", it.AuthNLockoutRegistrationID[1].DisplayName);
        }

    }
}
