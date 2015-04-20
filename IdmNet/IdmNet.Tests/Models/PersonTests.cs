using System;
using System.Collections.Generic;
using IdmNet.Models;
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
            var baseClass = new SecurityIdentifierResource
            {
                DisplayName = "Person DisplayName",
                Email = "a@b.com",
                Creator = new Person { DisplayName = "Creator Name", ObjectID = "Creator ObjectID"},
                DomainConfiguration = new IdmResource { DisplayName = "My Domain Config", ObjectID = "Domain Config ObjectID"}

            };
            IdmResource idmResource = baseClass;
            var it = new Person(idmResource);

            Assert.AreEqual("Person", it.ObjectType);
            Assert.AreEqual("Person DisplayName", it.DisplayName);
            Assert.AreEqual("a@b.com", it.Email);
            Assert.AreEqual("Creator Name", it.Creator.DisplayName);
            Assert.AreEqual("My Domain Config", it.DomainConfiguration.DisplayName);
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
            var subObject1 = new IdmResource { DisplayName = "foo1", ObjectID = "Foo1" };
            var subObject2 = new IdmResource { DisplayName = "foo2", ObjectID = "Foo2" };
            var list = new List<IdmResource> { subObject1, subObject2 };

            var it = new Person
            {
                AuthNLockoutRegistrationID = list
            };

            Assert.AreEqual("foo1", it.AuthNLockoutRegistrationID[0].DisplayName);
            Assert.AreEqual("foo2", it.AuthNLockoutRegistrationID[1].DisplayName);
        }

        [TestMethod]
        public void It_can_set_and_get_Asssitant()
        {
            var subObject1 = new Person { DisplayName = "foo1", ObjectID = "Foo1" };
            var it = new Person
            {
                Assistant = subObject1
            };

            Assert.AreEqual("foo1", it.Assistant.DisplayName);
        }

        [TestMethod]
        public void It_can_set_and_get_Manager()
        {
            var subObject1 = new Person { DisplayName = "foo1", ObjectID = "Foo1" };
            var it = new Person
            {
                Manager = subObject1
            };

            Assert.AreEqual("foo1", it.Manager.DisplayName);
        }

        [TestMethod]
        public void It_can_set_and_get_Photo()
        {
            var stringReprentation = @"/9j/4AAQSkZJRgABAQEAYABgAAD/2wBDAAoHBwkHBgoJCAkLCwoMDxkQDw4ODx4WFxIZJCAmJSMgIyIoLTkwKCo2KyIjMkQyNjs9QEBAJjBGS0U+Sjk/QD3/2wBDAQsLCw8NDx0QEB09KSMpPT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT3/wAARCAAyADIDASIAAhEBAxEB/8QAHwAAAQUBAQEBAQEAAAAAAAAAAAECAwQFBgcICQoL/8QAtRAAAgEDAwIEAwUFBAQAAAF9AQIDAAQRBRIhMUEGE1FhByJxFDKBkaEII0KxwRVS0fAkM2JyggkKFhcYGRolJicoKSo0NTY3ODk6Q0RFRkdISUpTVFVWV1hZWmNkZWZnaGlqc3R1dnd4eXqDhIWGh4iJipKTlJWWl5iZmqKjpKWmp6ipqrKztLW2t7i5usLDxMXGx8jJytLT1NXW19jZ2uHi4+Tl5ufo6erx8vP09fb3+Pn6/8QAHwEAAwEBAQEBAQEBAQAAAAAAAAECAwQFBgcICQoL/8QAtREAAgECBAQDBAcFBAQAAQJ3AAECAxEEBSExBhJBUQdhcRMiMoEIFEKRobHBCSMzUvAVYnLRChYkNOEl8RcYGRomJygpKjU2Nzg5OkNERUZHSElKU1RVVldYWVpjZGVmZ2hpanN0dXZ3eHl6goOEhYaHiImKkpOUlZaXmJmaoqOkpaanqKmqsrO0tba3uLm6wsPExcbHyMnK0tPU1dbX2Nna4uPk5ebn6Onq8vP09fb3+Pn6/9oADAMBAAIRAxEAPwD2CS6t42KvPGrDqCwBpv221/5+Yf8AvsV494+O3xpfgZGPL7/9M1rnsn1P51i6tnY+pw/DqrUYVPaW5knt3XqfQDXdqf8Al4h/77FcBoHjKPS9dvNOvmAs3uZDFLj/AFZLHr6g+vb6V59uPrRuO7Oec5zUuo2d+H4fp04ThOXMpeVreZ9DowYZBBUjIIPWnV5Z4L8anTymn6m5a0J2xSt/yy9if7v8vpXqKuGAKkFSMgg9a2jJSR8rjsBUwdTknt0fcfRSUVRwni/j/wD5HXUP+2f/AKLWudrovH//ACOuof8AbP8A9FrXO1yS3Z+nYD/dKX+GP5IKKKKk6xQcGu18GeNTpzJp2pvm0biOVusR9D/s/wAq4quu8F+Dn1iVb29QixjbhT/y2I7fT1NXC99Dzs0jhnh5fWNvxv5ef9bHqI1K1IBE8WP94UUz+ybD/nzg/wC/YorqPz21Lz/A8k8e8eMr/wD7Z/8Aota57Nez6n4L0nVtQlu7qKRppMbiJCBwABx9BVX/AIVxoX/PvL/3+NYSpSbbPrcLn+FpUIU5J3SS27L1PIutBGK9e/4VzoOP9RLn/rsa4rRfB0ms+ILqLDR6fbTMjv3wGPyj3x+VQ6ckd9DOsLWjKaulHe4zwd4RfX7nz7oMlhEfmYcGQ/3R/U16/DBHBCkUKCONAAqqMACmWlpDZ26W9tGI4Y1Cqi9ABU/WuiEeVHx2Y5jPHVOZ6RWy/rqFFLRVHnBRRRQA09DWP4aH/EumPf7TN/6GaKKSOin/AAJ+q/U2aWiimc4UUUUAf//Z";
            var byteArray = Convert.FromBase64String(stringReprentation);

            var it = new Person
            {
                Photo = byteArray
            };

            Assert.AreEqual(byteArray[0], it.Photo[0]);
            Assert.AreEqual(byteArray[1], it.Photo[1]);
            Assert.AreEqual(byteArray[2], it.Photo[2]);
            Assert.AreEqual(byteArray[byteArray.Length - 1], it.Photo[it.Photo.Length - 1]);
        }

        [TestMethod]
        public void It_can_set_and_get_ProxyAddressCollection()
        {
            var subObject1 = "foo1";
            var subObject2 = "foo2";
            var list = new List<string> { subObject1, subObject2 };

            var it = new Person
            {
                ProxyAddressCollection = list
            };

            Assert.AreEqual("foo1", it.ProxyAddressCollection[0]);
            Assert.AreEqual("foo2", it.ProxyAddressCollection[1]);
        }

        [TestMethod]
        public void It_can_set_and_get_TimeZone()
        {
            var subObject1 = new Person { DisplayName = "foo1", ObjectID = "Foo1" };
            var it = new Person
            {
                TimeZone = subObject1
            };

            Assert.AreEqual("foo1", it.TimeZone.DisplayName);
        }


        [TestMethod]
        public void It_can_set_complex_properties_to_null()
        {
            // Arrange
            var it = new Person
            {
                Assistant = new Person { DisplayName = "foo" },
                Manager = new Person { DisplayName = "foo" },
                TimeZone = new Person { DisplayName = "foo" },
                AuthNLockoutRegistrationID = new List<IdmResource>
                {
                    new IdmResource {DisplayName = "res1", ObjectID = "res1"},
                    new IdmResource {DisplayName = "res2", ObjectID = "res2"},
                }
            };

            // Act
            it.Assistant = null;
            it.Manager = null;
            it.TimeZone = null;
            it.AuthNLockoutRegistrationID = null;

            // Assert
            Assert.IsNull(it.Assistant);
            Assert.IsNull(it.Manager);
            Assert.IsNull(it.TimeZone);
            Assert.IsNull(it.AuthNLockoutRegistrationID);
        }
    }
}
