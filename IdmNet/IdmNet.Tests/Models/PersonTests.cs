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
        public void It_has_AD_UserCannotChangePassword_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.AD_UserCannotChangePassword);
        }

        [TestMethod]
        public void It_has_AD_UserCannotChangePassword_which_can_be_set_back_to_null()
        {
            // Arrange
            _it.AD_UserCannotChangePassword = true;

            // Act
            _it.AD_UserCannotChangePassword = null;

            // Assert
            Assert.IsNull(_it.AD_UserCannotChangePassword);
        }

        [TestMethod]
        public void It_can_get_and_set_AD_UserCannotChangePassword()
        {
            // Act
            _it.AD_UserCannotChangePassword = true;

            // Assert
            Assert.AreEqual(true, _it.AD_UserCannotChangePassword);
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
        public void It_has_Assistant_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.Assistant);
        }

        [TestMethod]
        public void It_has_Assistant_which_can_be_set_back_to_null()
        {
            // Arrange
            var testPerson = new Person { DisplayName = "Test Person" };			
            _it.Assistant = testPerson; 

            // Act
            _it.Assistant = null;

            // Assert
            Assert.IsNull(_it.Assistant);
        }

        [TestMethod]
        public void It_can_get_and_set_Assistant()
        {
            // Act
			var testPerson = new Person { DisplayName = "Test Person" };			
            _it.Assistant = testPerson; 

            // Assert
            Assert.AreEqual(testPerson.DisplayName, _it.Assistant.DisplayName);
        }


        [TestMethod]
        public void It_has_AuthNWFLockedOut_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.AuthNWFLockedOut);
        }

        [TestMethod]
        public void It_has_AuthNWFLockedOut_which_can_be_set_back_to_null()
        {
            // Arrange
            var list = new List<WorkflowDefinition>
            {
                new WorkflowDefinition { DisplayName = "Test WorkflowDefinition1", ObjectID = "guid1" },
                new WorkflowDefinition { DisplayName = "Test WorkflowDefinition2", ObjectID = "guid2" }
            };
            _it.AuthNWFLockedOut = list;

            // Act
            _it.AuthNWFLockedOut = null;

            // Assert
            Assert.IsNull(_it.AuthNWFLockedOut);
        }

        [TestMethod]
        public void It_can_get_and_set_AuthNWFLockedOut()
        {
            // Arrange
            var list = new List<WorkflowDefinition>
            {
                new WorkflowDefinition { DisplayName = "Test WorkflowDefinition1", ObjectID = "guid1" },
                new WorkflowDefinition { DisplayName = "Test WorkflowDefinition2", ObjectID = "guid2" }
            };

            // Act
            _it.AuthNWFLockedOut = list;

            // Assert
            Assert.AreEqual(list[0].DisplayName, _it.AuthNWFLockedOut[0].DisplayName);
            Assert.AreEqual(list[1].DisplayName, _it.AuthNWFLockedOut[1].DisplayName);
        }


        [TestMethod]
        public void It_has_AuthNWFRegistered_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.AuthNWFRegistered);
        }

        [TestMethod]
        public void It_has_AuthNWFRegistered_which_can_be_set_back_to_null()
        {
            // Arrange
            var list = new List<WorkflowDefinition>
            {
                new WorkflowDefinition { DisplayName = "Test WorkflowDefinition1", ObjectID = "guid1" },
                new WorkflowDefinition { DisplayName = "Test WorkflowDefinition2", ObjectID = "guid2" }
            };
            _it.AuthNWFRegistered = list;

            // Act
            _it.AuthNWFRegistered = null;

            // Assert
            Assert.IsNull(_it.AuthNWFRegistered);
        }

        [TestMethod]
        public void It_can_get_and_set_AuthNWFRegistered()
        {
            // Arrange
            var list = new List<WorkflowDefinition>
            {
                new WorkflowDefinition { DisplayName = "Test WorkflowDefinition1", ObjectID = "guid1" },
                new WorkflowDefinition { DisplayName = "Test WorkflowDefinition2", ObjectID = "guid2" }
            };

            // Act
            _it.AuthNWFRegistered = list;

            // Assert
            Assert.AreEqual(list[0].DisplayName, _it.AuthNWFRegistered[0].DisplayName);
            Assert.AreEqual(list[1].DisplayName, _it.AuthNWFRegistered[1].DisplayName);
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
        public void It_has_DomainConfiguration_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.DomainConfiguration);
        }

        [TestMethod]
        public void It_has_DomainConfiguration_which_can_be_set_back_to_null()
        {
            // Arrange
            var testDomainConfiguration = new DomainConfiguration { DisplayName = "Test DomainConfiguration" };			
            _it.DomainConfiguration = testDomainConfiguration; 

            // Act
            _it.DomainConfiguration = null;

            // Assert
            Assert.IsNull(_it.DomainConfiguration);
        }

        [TestMethod]
        public void It_can_get_and_set_DomainConfiguration()
        {
            // Act
			var testDomainConfiguration = new DomainConfiguration { DisplayName = "Test DomainConfiguration" };			
            _it.DomainConfiguration = testDomainConfiguration; 

            // Assert
            Assert.AreEqual(testDomainConfiguration.DisplayName, _it.DomainConfiguration.DisplayName);
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
        public void It_has_EmployeeEndDate_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.EmployeeEndDate);
        }

        [TestMethod]
        public void It_has_EmployeeEndDate_which_can_be_set_back_to_null()
        {
            // Arrange
            var now = DateTime.Now;
            var testTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);
            _it.EmployeeEndDate = testTime;

            // Act
            _it.EmployeeEndDate = null;

            // Assert
            Assert.IsNull(_it.EmployeeEndDate);
        }

        [TestMethod]
        public void It_can_get_and_set_EmployeeEndDate()
        {
            // Act
            var now = DateTime.Now;
            var testTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);
            _it.EmployeeEndDate = testTime;

            // Assert
            Assert.AreEqual(testTime, _it.EmployeeEndDate);
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
        public void It_has_EmployeeStartDate_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.EmployeeStartDate);
        }

        [TestMethod]
        public void It_has_EmployeeStartDate_which_can_be_set_back_to_null()
        {
            // Arrange
            var now = DateTime.Now;
            var testTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);
            _it.EmployeeStartDate = testTime;

            // Act
            _it.EmployeeStartDate = null;

            // Assert
            Assert.IsNull(_it.EmployeeStartDate);
        }

        [TestMethod]
        public void It_can_get_and_set_EmployeeStartDate()
        {
            // Act
            var now = DateTime.Now;
            var testTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);
            _it.EmployeeStartDate = testTime;

            // Assert
            Assert.AreEqual(testTime, _it.EmployeeStartDate);
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
        public void It_has_FreezeCount_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.FreezeCount);
        }

        [TestMethod]
        public void It_has_FreezeCount_which_can_be_set_back_to_null()
        {
            // Arrange
            _it.FreezeCount = 123;

            // Act
            _it.FreezeCount = null;

            // Assert
            Assert.IsNull(_it.FreezeCount);
        }

        [TestMethod]
        public void It_can_get_and_set_FreezeCount()
        {
            // Act
            _it.FreezeCount = 123;

            // Assert
            Assert.AreEqual(123, _it.FreezeCount);
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
        public void It_has_LastResetAttemptTime_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.LastResetAttemptTime);
        }

        [TestMethod]
        public void It_has_LastResetAttemptTime_which_can_be_set_back_to_null()
        {
            // Arrange
            var now = DateTime.Now;
            var testTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);
            _it.LastResetAttemptTime = testTime;

            // Act
            _it.LastResetAttemptTime = null;

            // Assert
            Assert.IsNull(_it.LastResetAttemptTime);
        }

        [TestMethod]
        public void It_can_get_and_set_LastResetAttemptTime()
        {
            // Act
            var now = DateTime.Now;
            var testTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);
            _it.LastResetAttemptTime = testTime;

            // Assert
            Assert.AreEqual(testTime, _it.LastResetAttemptTime);
        }


        [TestMethod]
        public void It_has_AuthNLockoutRegistrationID_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.AuthNLockoutRegistrationID);
        }

        [TestMethod]
        public void It_has_AuthNLockoutRegistrationID_which_can_be_set_back_to_null()
        {
            // Arrange
            var list = new List<GateRegistration>
            {
                new GateRegistration { DisplayName = "Test GateRegistration1", ObjectID = "guid1" },
                new GateRegistration { DisplayName = "Test GateRegistration2", ObjectID = "guid2" }
            };
            _it.AuthNLockoutRegistrationID = list;

            // Act
            _it.AuthNLockoutRegistrationID = null;

            // Assert
            Assert.IsNull(_it.AuthNLockoutRegistrationID);
        }

        [TestMethod]
        public void It_can_get_and_set_AuthNLockoutRegistrationID()
        {
            // Arrange
            var list = new List<GateRegistration>
            {
                new GateRegistration { DisplayName = "Test GateRegistration1", ObjectID = "guid1" },
                new GateRegistration { DisplayName = "Test GateRegistration2", ObjectID = "guid2" }
            };

            // Act
            _it.AuthNLockoutRegistrationID = list;

            // Assert
            Assert.AreEqual(list[0].DisplayName, _it.AuthNLockoutRegistrationID[0].DisplayName);
            Assert.AreEqual(list[1].DisplayName, _it.AuthNLockoutRegistrationID[1].DisplayName);
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
        public void It_has_Manager_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.Manager);
        }

        [TestMethod]
        public void It_has_Manager_which_can_be_set_back_to_null()
        {
            // Arrange
            var testPerson = new Person { DisplayName = "Test Person" };			
            _it.Manager = testPerson; 

            // Act
            _it.Manager = null;

            // Assert
            Assert.IsNull(_it.Manager);
        }

        [TestMethod]
        public void It_can_get_and_set_Manager()
        {
            // Act
			var testPerson = new Person { DisplayName = "Test Person" };			
            _it.Manager = testPerson; 

            // Assert
            Assert.AreEqual(testPerson.DisplayName, _it.Manager.DisplayName);
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
        public void It_has_Photo_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.Photo);
        }

        [TestMethod]
        public void It_has_Photo_which_can_be_set_back_to_null()
        {
            // Arrange
            var stringReprentation = @"/9j/4AAQSkZJRgABAQEAYABgAAD/2wBDAAoHBwkHBgoJCAkLCwoMDxkQDw4ODx4WFxIZJCAmJSMgIyIoLTkwKCo2KyIjMkQyNjs9QEBAJjBGS0U+Sjk/QD3/2wBDAQsLCw8NDx0QEB09KSMpPT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT3/wAARCAAyADIDASIAAhEBAxEB/8QAHwAAAQUBAQEBAQEAAAAAAAAAAAECAwQFBgcICQoL/8QAtRAAAgEDAwIEAwUFBAQAAAF9AQIDAAQRBRIhMUEGE1FhByJxFDKBkaEII0KxwRVS0fAkM2JyggkKFhcYGRolJicoKSo0NTY3ODk6Q0RFRkdISUpTVFVWV1hZWmNkZWZnaGlqc3R1dnd4eXqDhIWGh4iJipKTlJWWl5iZmqKjpKWmp6ipqrKztLW2t7i5usLDxMXGx8jJytLT1NXW19jZ2uHi4+Tl5ufo6erx8vP09fb3+Pn6/8QAHwEAAwEBAQEBAQEBAQAAAAAAAAECAwQFBgcICQoL/8QAtREAAgECBAQDBAcFBAQAAQJ3AAECAxEEBSExBhJBUQdhcRMiMoEIFEKRobHBCSMzUvAVYnLRChYkNOEl8RcYGRomJygpKjU2Nzg5OkNERUZHSElKU1RVVldYWVpjZGVmZ2hpanN0dXZ3eHl6goOEhYaHiImKkpOUlZaXmJmaoqOkpaanqKmqsrO0tba3uLm6wsPExcbHyMnK0tPU1dbX2Nna4uPk5ebn6Onq8vP09fb3+Pn6/9oADAMBAAIRAxEAPwD2CS6t42KvPGrDqCwBpv221/5+Yf8AvsV494+O3xpfgZGPL7/9M1rnsn1P51i6tnY+pw/DqrUYVPaW5knt3XqfQDXdqf8Al4h/77FcBoHjKPS9dvNOvmAs3uZDFLj/AFZLHr6g+vb6V59uPrRuO7Oec5zUuo2d+H4fp04ThOXMpeVreZ9DowYZBBUjIIPWnV5Z4L8anTymn6m5a0J2xSt/yy9if7v8vpXqKuGAKkFSMgg9a2jJSR8rjsBUwdTknt0fcfRSUVRwni/j/wD5HXUP+2f/AKLWudrovH//ACOuof8AbP8A9FrXO1yS3Z+nYD/dKX+GP5IKKKKk6xQcGu18GeNTpzJp2pvm0biOVusR9D/s/wAq4quu8F+Dn1iVb29QixjbhT/y2I7fT1NXC99Dzs0jhnh5fWNvxv5ef9bHqI1K1IBE8WP94UUz+ybD/nzg/wC/YorqPz21Lz/A8k8e8eMr/wD7Z/8Aota57Nez6n4L0nVtQlu7qKRppMbiJCBwABx9BVX/AIVxoX/PvL/3+NYSpSbbPrcLn+FpUIU5J3SS27L1PIutBGK9e/4VzoOP9RLn/rsa4rRfB0ms+ILqLDR6fbTMjv3wGPyj3x+VQ6ckd9DOsLWjKaulHe4zwd4RfX7nz7oMlhEfmYcGQ/3R/U16/DBHBCkUKCONAAqqMACmWlpDZ26W9tGI4Y1Cqi9ABU/WuiEeVHx2Y5jPHVOZ6RWy/rqFFLRVHnBRRRQA09DWP4aH/EumPf7TN/6GaKKSOin/AAJ+q/U2aWiimc4UUUUAf//Z";
            var byteArray = Convert.FromBase64String(stringReprentation);
            _it.Photo = byteArray; 

            // Act
            _it.Photo = null;

            // Assert
            Assert.IsNull(_it.Photo);
        }

        [TestMethod]
        public void It_can_get_and_set_Photo()
        {
            // Arrange
            var stringReprentation = @"/9j/4AAQSkZJRgABAQEAYABgAAD/2wBDAAoHBwkHBgoJCAkLCwoMDxkQDw4ODx4WFxIZJCAmJSMgIyIoLTkwKCo2KyIjMkQyNjs9QEBAJjBGS0U+Sjk/QD3/2wBDAQsLCw8NDx0QEB09KSMpPT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT3/wAARCAAyADIDASIAAhEBAxEB/8QAHwAAAQUBAQEBAQEAAAAAAAAAAAECAwQFBgcICQoL/8QAtRAAAgEDAwIEAwUFBAQAAAF9AQIDAAQRBRIhMUEGE1FhByJxFDKBkaEII0KxwRVS0fAkM2JyggkKFhcYGRolJicoKSo0NTY3ODk6Q0RFRkdISUpTVFVWV1hZWmNkZWZnaGlqc3R1dnd4eXqDhIWGh4iJipKTlJWWl5iZmqKjpKWmp6ipqrKztLW2t7i5usLDxMXGx8jJytLT1NXW19jZ2uHi4+Tl5ufo6erx8vP09fb3+Pn6/8QAHwEAAwEBAQEBAQEBAQAAAAAAAAECAwQFBgcICQoL/8QAtREAAgECBAQDBAcFBAQAAQJ3AAECAxEEBSExBhJBUQdhcRMiMoEIFEKRobHBCSMzUvAVYnLRChYkNOEl8RcYGRomJygpKjU2Nzg5OkNERUZHSElKU1RVVldYWVpjZGVmZ2hpanN0dXZ3eHl6goOEhYaHiImKkpOUlZaXmJmaoqOkpaanqKmqsrO0tba3uLm6wsPExcbHyMnK0tPU1dbX2Nna4uPk5ebn6Onq8vP09fb3+Pn6/9oADAMBAAIRAxEAPwD2CS6t42KvPGrDqCwBpv221/5+Yf8AvsV494+O3xpfgZGPL7/9M1rnsn1P51i6tnY+pw/DqrUYVPaW5knt3XqfQDXdqf8Al4h/77FcBoHjKPS9dvNOvmAs3uZDFLj/AFZLHr6g+vb6V59uPrRuO7Oec5zUuo2d+H4fp04ThOXMpeVreZ9DowYZBBUjIIPWnV5Z4L8anTymn6m5a0J2xSt/yy9if7v8vpXqKuGAKkFSMgg9a2jJSR8rjsBUwdTknt0fcfRSUVRwni/j/wD5HXUP+2f/AKLWudrovH//ACOuof8AbP8A9FrXO1yS3Z+nYD/dKX+GP5IKKKKk6xQcGu18GeNTpzJp2pvm0biOVusR9D/s/wAq4quu8F+Dn1iVb29QixjbhT/y2I7fT1NXC99Dzs0jhnh5fWNvxv5ef9bHqI1K1IBE8WP94UUz+ybD/nzg/wC/YorqPz21Lz/A8k8e8eMr/wD7Z/8Aota57Nez6n4L0nVtQlu7qKRppMbiJCBwABx9BVX/AIVxoX/PvL/3+NYSpSbbPrcLn+FpUIU5J3SS27L1PIutBGK9e/4VzoOP9RLn/rsa4rRfB0ms+ILqLDR6fbTMjv3wGPyj3x+VQ6ckd9DOsLWjKaulHe4zwd4RfX7nz7oMlhEfmYcGQ/3R/U16/DBHBCkUKCONAAqqMACmWlpDZ26W9tGI4Y1Cqi9ABU/WuiEeVHx2Y5jPHVOZ6RWy/rqFFLRVHnBRRRQA09DWP4aH/EumPf7TN/6GaKKSOin/AAJ+q/U2aWiimc4UUUUAf//Z";
            var byteArray = Convert.FromBase64String(stringReprentation);

            // Act
            _it.Photo = byteArray; 

            // Assert
            Assert.AreEqual(byteArray[0], _it.Photo[0]);
            Assert.AreEqual(byteArray[1], _it.Photo[1]);
            Assert.AreEqual(byteArray[2], _it.Photo[2]);
            Assert.AreEqual(byteArray[byteArray.Length - 1], _it.Photo[_it.Photo.Length - 1]);
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
        public void It_has_ProxyAddressCollection_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.ProxyAddressCollection);
        }

        [TestMethod]
        public void It_has_ProxyAddressCollection_which_can_be_set_back_to_null()
        {
            // Arrange
            var subObject1 = "foo1";
            var subObject2 = "foo2";
            var list = new List<string> { subObject1, subObject2 };
            _it.ProxyAddressCollection = list; 

            // Act
            _it.ProxyAddressCollection = null;

            // Assert
            Assert.IsNull(_it.ProxyAddressCollection);
        }

        [TestMethod]
        public void It_can_get_and_set_ProxyAddressCollection()
        {
            var subObject1 = "foo1";
            var subObject2 = "foo2";
            var list = new List<string> { subObject1, subObject2 };

            // Act
            _it.ProxyAddressCollection = list; 

            // Assert
            Assert.AreEqual("foo1", _it.ProxyAddressCollection[0]);
            Assert.AreEqual("foo2", _it.ProxyAddressCollection[1]);
        }


        [TestMethod]
        public void It_has_IsRASEnabled_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.IsRASEnabled);
        }

        [TestMethod]
        public void It_has_IsRASEnabled_which_can_be_set_back_to_null()
        {
            // Arrange
            _it.IsRASEnabled = true;

            // Act
            _it.IsRASEnabled = null;

            // Assert
            Assert.IsNull(_it.IsRASEnabled);
        }

        [TestMethod]
        public void It_can_get_and_set_IsRASEnabled()
        {
            // Act
            _it.IsRASEnabled = true;

            // Assert
            Assert.AreEqual(true, _it.IsRASEnabled);
        }


        [TestMethod]
        public void It_has_Register_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.Register);
        }

        [TestMethod]
        public void It_has_Register_which_can_be_set_back_to_null()
        {
            // Arrange
            _it.Register = true;

            // Act
            _it.Register = null;

            // Assert
            Assert.IsNull(_it.Register);
        }

        [TestMethod]
        public void It_can_get_and_set_Register()
        {
            // Act
            _it.Register = true;

            // Assert
            Assert.AreEqual(true, _it.Register);
        }


        [TestMethod]
        public void It_has_RegistrationRequired_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.RegistrationRequired);
        }

        [TestMethod]
        public void It_has_RegistrationRequired_which_can_be_set_back_to_null()
        {
            // Arrange
            _it.RegistrationRequired = true;

            // Act
            _it.RegistrationRequired = null;

            // Assert
            Assert.IsNull(_it.RegistrationRequired);
        }

        [TestMethod]
        public void It_can_get_and_set_RegistrationRequired()
        {
            // Act
            _it.RegistrationRequired = true;

            // Assert
            Assert.AreEqual(true, _it.RegistrationRequired);
        }


        [TestMethod]
        public void It_can_get_and_set_ResetPassword()
        {
            // Act
            _it.ResetPassword = "A string";

            // Assert
            Assert.AreEqual("A string", _it.ResetPassword);
        }


        [TestMethod]
        public void It_has_ObjectSID_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.ObjectSID);
        }

        [TestMethod]
        public void It_has_ObjectSID_which_can_be_set_back_to_null()
        {
            // Arrange
            var stringReprentation = @"/9j/4AAQSkZJRgABAQEAYABgAAD/2wBDAAoHBwkHBgoJCAkLCwoMDxkQDw4ODx4WFxIZJCAmJSMgIyIoLTkwKCo2KyIjMkQyNjs9QEBAJjBGS0U+Sjk/QD3/2wBDAQsLCw8NDx0QEB09KSMpPT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT3/wAARCAAyADIDASIAAhEBAxEB/8QAHwAAAQUBAQEBAQEAAAAAAAAAAAECAwQFBgcICQoL/8QAtRAAAgEDAwIEAwUFBAQAAAF9AQIDAAQRBRIhMUEGE1FhByJxFDKBkaEII0KxwRVS0fAkM2JyggkKFhcYGRolJicoKSo0NTY3ODk6Q0RFRkdISUpTVFVWV1hZWmNkZWZnaGlqc3R1dnd4eXqDhIWGh4iJipKTlJWWl5iZmqKjpKWmp6ipqrKztLW2t7i5usLDxMXGx8jJytLT1NXW19jZ2uHi4+Tl5ufo6erx8vP09fb3+Pn6/8QAHwEAAwEBAQEBAQEBAQAAAAAAAAECAwQFBgcICQoL/8QAtREAAgECBAQDBAcFBAQAAQJ3AAECAxEEBSExBhJBUQdhcRMiMoEIFEKRobHBCSMzUvAVYnLRChYkNOEl8RcYGRomJygpKjU2Nzg5OkNERUZHSElKU1RVVldYWVpjZGVmZ2hpanN0dXZ3eHl6goOEhYaHiImKkpOUlZaXmJmaoqOkpaanqKmqsrO0tba3uLm6wsPExcbHyMnK0tPU1dbX2Nna4uPk5ebn6Onq8vP09fb3+Pn6/9oADAMBAAIRAxEAPwD2CS6t42KvPGrDqCwBpv221/5+Yf8AvsV494+O3xpfgZGPL7/9M1rnsn1P51i6tnY+pw/DqrUYVPaW5knt3XqfQDXdqf8Al4h/77FcBoHjKPS9dvNOvmAs3uZDFLj/AFZLHr6g+vb6V59uPrRuO7Oec5zUuo2d+H4fp04ThOXMpeVreZ9DowYZBBUjIIPWnV5Z4L8anTymn6m5a0J2xSt/yy9if7v8vpXqKuGAKkFSMgg9a2jJSR8rjsBUwdTknt0fcfRSUVRwni/j/wD5HXUP+2f/AKLWudrovH//ACOuof8AbP8A9FrXO1yS3Z+nYD/dKX+GP5IKKKKk6xQcGu18GeNTpzJp2pvm0biOVusR9D/s/wAq4quu8F+Dn1iVb29QixjbhT/y2I7fT1NXC99Dzs0jhnh5fWNvxv5ef9bHqI1K1IBE8WP94UUz+ybD/nzg/wC/YorqPz21Lz/A8k8e8eMr/wD7Z/8Aota57Nez6n4L0nVtQlu7qKRppMbiJCBwABx9BVX/AIVxoX/PvL/3+NYSpSbbPrcLn+FpUIU5J3SS27L1PIutBGK9e/4VzoOP9RLn/rsa4rRfB0ms+ILqLDR6fbTMjv3wGPyj3x+VQ6ckd9DOsLWjKaulHe4zwd4RfX7nz7oMlhEfmYcGQ/3R/U16/DBHBCkUKCONAAqqMACmWlpDZ26W9tGI4Y1Cqi9ABU/WuiEeVHx2Y5jPHVOZ6RWy/rqFFLRVHnBRRRQA09DWP4aH/EumPf7TN/6GaKKSOin/AAJ+q/U2aWiimc4UUUUAf//Z";
            var byteArray = Convert.FromBase64String(stringReprentation);
            _it.ObjectSID = byteArray; 

            // Act
            _it.ObjectSID = null;

            // Assert
            Assert.IsNull(_it.ObjectSID);
        }

        [TestMethod]
        public void It_can_get_and_set_ObjectSID()
        {
            // Arrange
            var stringReprentation = @"/9j/4AAQSkZJRgABAQEAYABgAAD/2wBDAAoHBwkHBgoJCAkLCwoMDxkQDw4ODx4WFxIZJCAmJSMgIyIoLTkwKCo2KyIjMkQyNjs9QEBAJjBGS0U+Sjk/QD3/2wBDAQsLCw8NDx0QEB09KSMpPT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT3/wAARCAAyADIDASIAAhEBAxEB/8QAHwAAAQUBAQEBAQEAAAAAAAAAAAECAwQFBgcICQoL/8QAtRAAAgEDAwIEAwUFBAQAAAF9AQIDAAQRBRIhMUEGE1FhByJxFDKBkaEII0KxwRVS0fAkM2JyggkKFhcYGRolJicoKSo0NTY3ODk6Q0RFRkdISUpTVFVWV1hZWmNkZWZnaGlqc3R1dnd4eXqDhIWGh4iJipKTlJWWl5iZmqKjpKWmp6ipqrKztLW2t7i5usLDxMXGx8jJytLT1NXW19jZ2uHi4+Tl5ufo6erx8vP09fb3+Pn6/8QAHwEAAwEBAQEBAQEBAQAAAAAAAAECAwQFBgcICQoL/8QAtREAAgECBAQDBAcFBAQAAQJ3AAECAxEEBSExBhJBUQdhcRMiMoEIFEKRobHBCSMzUvAVYnLRChYkNOEl8RcYGRomJygpKjU2Nzg5OkNERUZHSElKU1RVVldYWVpjZGVmZ2hpanN0dXZ3eHl6goOEhYaHiImKkpOUlZaXmJmaoqOkpaanqKmqsrO0tba3uLm6wsPExcbHyMnK0tPU1dbX2Nna4uPk5ebn6Onq8vP09fb3+Pn6/9oADAMBAAIRAxEAPwD2CS6t42KvPGrDqCwBpv221/5+Yf8AvsV494+O3xpfgZGPL7/9M1rnsn1P51i6tnY+pw/DqrUYVPaW5knt3XqfQDXdqf8Al4h/77FcBoHjKPS9dvNOvmAs3uZDFLj/AFZLHr6g+vb6V59uPrRuO7Oec5zUuo2d+H4fp04ThOXMpeVreZ9DowYZBBUjIIPWnV5Z4L8anTymn6m5a0J2xSt/yy9if7v8vpXqKuGAKkFSMgg9a2jJSR8rjsBUwdTknt0fcfRSUVRwni/j/wD5HXUP+2f/AKLWudrovH//ACOuof8AbP8A9FrXO1yS3Z+nYD/dKX+GP5IKKKKk6xQcGu18GeNTpzJp2pvm0biOVusR9D/s/wAq4quu8F+Dn1iVb29QixjbhT/y2I7fT1NXC99Dzs0jhnh5fWNvxv5ef9bHqI1K1IBE8WP94UUz+ybD/nzg/wC/YorqPz21Lz/A8k8e8eMr/wD7Z/8Aota57Nez6n4L0nVtQlu7qKRppMbiJCBwABx9BVX/AIVxoX/PvL/3+NYSpSbbPrcLn+FpUIU5J3SS27L1PIutBGK9e/4VzoOP9RLn/rsa4rRfB0ms+ILqLDR6fbTMjv3wGPyj3x+VQ6ckd9DOsLWjKaulHe4zwd4RfX7nz7oMlhEfmYcGQ/3R/U16/DBHBCkUKCONAAqqMACmWlpDZ26W9tGI4Y1Cqi9ABU/WuiEeVHx2Y5jPHVOZ6RWy/rqFFLRVHnBRRRQA09DWP4aH/EumPf7TN/6GaKKSOin/AAJ+q/U2aWiimc4UUUUAf//Z";
            var byteArray = Convert.FromBase64String(stringReprentation);

            // Act
            _it.ObjectSID = byteArray; 

            // Assert
            Assert.AreEqual(byteArray[0], _it.ObjectSID[0]);
            Assert.AreEqual(byteArray[1], _it.ObjectSID[1]);
            Assert.AreEqual(byteArray[2], _it.ObjectSID[2]);
            Assert.AreEqual(byteArray[byteArray.Length - 1], _it.ObjectSID[_it.ObjectSID.Length - 1]);
        }


        [TestMethod]
        public void It_has_SIDHistory_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.SIDHistory);
        }

        [TestMethod]
        public void It_has_SIDHistory_which_can_be_set_back_to_null()
        {
            // Arrange
            var stringReprentation = @"/9j/4AAQSkZJRgABAQEAYABgAAD/2wBDAAoHBwkHBgoJCAkLCwoMDxkQDw4ODx4WFxIZJCAmJSMgIyIoLTkwKCo2KyIjMkQyNjs9QEBAJjBGS0U+Sjk/QD3/2wBDAQsLCw8NDx0QEB09KSMpPT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT3/wAARCAAyADIDASIAAhEBAxEB/8QAHwAAAQUBAQEBAQEAAAAAAAAAAAECAwQFBgcICQoL/8QAtRAAAgEDAwIEAwUFBAQAAAF9AQIDAAQRBRIhMUEGE1FhByJxFDKBkaEII0KxwRVS0fAkM2JyggkKFhcYGRolJicoKSo0NTY3ODk6Q0RFRkdISUpTVFVWV1hZWmNkZWZnaGlqc3R1dnd4eXqDhIWGh4iJipKTlJWWl5iZmqKjpKWmp6ipqrKztLW2t7i5usLDxMXGx8jJytLT1NXW19jZ2uHi4+Tl5ufo6erx8vP09fb3+Pn6/8QAHwEAAwEBAQEBAQEBAQAAAAAAAAECAwQFBgcICQoL/8QAtREAAgECBAQDBAcFBAQAAQJ3AAECAxEEBSExBhJBUQdhcRMiMoEIFEKRobHBCSMzUvAVYnLRChYkNOEl8RcYGRomJygpKjU2Nzg5OkNERUZHSElKU1RVVldYWVpjZGVmZ2hpanN0dXZ3eHl6goOEhYaHiImKkpOUlZaXmJmaoqOkpaanqKmqsrO0tba3uLm6wsPExcbHyMnK0tPU1dbX2Nna4uPk5ebn6Onq8vP09fb3+Pn6/9oADAMBAAIRAxEAPwD2CS6t42KvPGrDqCwBpv221/5+Yf8AvsV494+O3xpfgZGPL7/9M1rnsn1P51i6tnY+pw/DqrUYVPaW5knt3XqfQDXdqf8Al4h/77FcBoHjKPS9dvNOvmAs3uZDFLj/AFZLHr6g+vb6V59uPrRuO7Oec5zUuo2d+H4fp04ThOXMpeVreZ9DowYZBBUjIIPWnV5Z4L8anTymn6m5a0J2xSt/yy9if7v8vpXqKuGAKkFSMgg9a2jJSR8rjsBUwdTknt0fcfRSUVRwni/j/wD5HXUP+2f/AKLWudrovH//ACOuof8AbP8A9FrXO1yS3Z+nYD/dKX+GP5IKKKKk6xQcGu18GeNTpzJp2pvm0biOVusR9D/s/wAq4quu8F+Dn1iVb29QixjbhT/y2I7fT1NXC99Dzs0jhnh5fWNvxv5ef9bHqI1K1IBE8WP94UUz+ybD/nzg/wC/YorqPz21Lz/A8k8e8eMr/wD7Z/8Aota57Nez6n4L0nVtQlu7qKRppMbiJCBwABx9BVX/AIVxoX/PvL/3+NYSpSbbPrcLn+FpUIU5J3SS27L1PIutBGK9e/4VzoOP9RLn/rsa4rRfB0ms+ILqLDR6fbTMjv3wGPyj3x+VQ6ckd9DOsLWjKaulHe4zwd4RfX7nz7oMlhEfmYcGQ/3R/U16/DBHBCkUKCONAAqqMACmWlpDZ26W9tGI4Y1Cqi9ABU/WuiEeVHx2Y5jPHVOZ6RWy/rqFFLRVHnBRRRQA09DWP4aH/EumPf7TN/6GaKKSOin/AAJ+q/U2aWiimc4UUUUAf//Z";
            var byteArray = Convert.FromBase64String(stringReprentation);
            var list = new List<byte[]> {
                byteArray,
                byteArray
            };
            _it.SIDHistory = list; 

            // Act
            _it.SIDHistory = null;

            // Assert
            Assert.IsNull(_it.SIDHistory);
        }

        [TestMethod]
        public void It_can_get_and_set_SIDHistory()
        {
            // Arrange
            var stringReprentation = @"/9j/4AAQSkZJRgABAQEAYABgAAD/2wBDAAoHBwkHBgoJCAkLCwoMDxkQDw4ODx4WFxIZJCAmJSMgIyIoLTkwKCo2KyIjMkQyNjs9QEBAJjBGS0U+Sjk/QD3/2wBDAQsLCw8NDx0QEB09KSMpPT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT3/wAARCAAyADIDASIAAhEBAxEB/8QAHwAAAQUBAQEBAQEAAAAAAAAAAAECAwQFBgcICQoL/8QAtRAAAgEDAwIEAwUFBAQAAAF9AQIDAAQRBRIhMUEGE1FhByJxFDKBkaEII0KxwRVS0fAkM2JyggkKFhcYGRolJicoKSo0NTY3ODk6Q0RFRkdISUpTVFVWV1hZWmNkZWZnaGlqc3R1dnd4eXqDhIWGh4iJipKTlJWWl5iZmqKjpKWmp6ipqrKztLW2t7i5usLDxMXGx8jJytLT1NXW19jZ2uHi4+Tl5ufo6erx8vP09fb3+Pn6/8QAHwEAAwEBAQEBAQEBAQAAAAAAAAECAwQFBgcICQoL/8QAtREAAgECBAQDBAcFBAQAAQJ3AAECAxEEBSExBhJBUQdhcRMiMoEIFEKRobHBCSMzUvAVYnLRChYkNOEl8RcYGRomJygpKjU2Nzg5OkNERUZHSElKU1RVVldYWVpjZGVmZ2hpanN0dXZ3eHl6goOEhYaHiImKkpOUlZaXmJmaoqOkpaanqKmqsrO0tba3uLm6wsPExcbHyMnK0tPU1dbX2Nna4uPk5ebn6Onq8vP09fb3+Pn6/9oADAMBAAIRAxEAPwD2CS6t42KvPGrDqCwBpv221/5+Yf8AvsV494+O3xpfgZGPL7/9M1rnsn1P51i6tnY+pw/DqrUYVPaW5knt3XqfQDXdqf8Al4h/77FcBoHjKPS9dvNOvmAs3uZDFLj/AFZLHr6g+vb6V59uPrRuO7Oec5zUuo2d+H4fp04ThOXMpeVreZ9DowYZBBUjIIPWnV5Z4L8anTymn6m5a0J2xSt/yy9if7v8vpXqKuGAKkFSMgg9a2jJSR8rjsBUwdTknt0fcfRSUVRwni/j/wD5HXUP+2f/AKLWudrovH//ACOuof8AbP8A9FrXO1yS3Z+nYD/dKX+GP5IKKKKk6xQcGu18GeNTpzJp2pvm0biOVusR9D/s/wAq4quu8F+Dn1iVb29QixjbhT/y2I7fT1NXC99Dzs0jhnh5fWNvxv5ef9bHqI1K1IBE8WP94UUz+ybD/nzg/wC/YorqPz21Lz/A8k8e8eMr/wD7Z/8Aota57Nez6n4L0nVtQlu7qKRppMbiJCBwABx9BVX/AIVxoX/PvL/3+NYSpSbbPrcLn+FpUIU5J3SS27L1PIutBGK9e/4VzoOP9RLn/rsa4rRfB0ms+ILqLDR6fbTMjv3wGPyj3x+VQ6ckd9DOsLWjKaulHe4zwd4RfX7nz7oMlhEfmYcGQ/3R/U16/DBHBCkUKCONAAqqMACmWlpDZ26W9tGI4Y1Cqi9ABU/WuiEeVHx2Y5jPHVOZ6RWy/rqFFLRVHnBRRRQA09DWP4aH/EumPf7TN/6GaKKSOin/AAJ+q/U2aWiimc4UUUUAf//Z";
            var byteArray = Convert.FromBase64String(stringReprentation);
            var list = new List<byte[]> {
                byteArray,
                byteArray
            };

            // Act
            _it.SIDHistory = list; 

            // Assert
            Assert.AreEqual(byteArray[0], _it.SIDHistory[0][0]);
            Assert.AreEqual(byteArray[1], _it.SIDHistory[0][1]);
            Assert.AreEqual(byteArray[2], _it.SIDHistory[0][2]);
            Assert.AreEqual(byteArray[0], _it.SIDHistory[1][0]);
            Assert.AreEqual(byteArray[1], _it.SIDHistory[1][1]);
            Assert.AreEqual(byteArray[2], _it.SIDHistory[1][2]);
            Assert.AreEqual(byteArray[byteArray.Length - 1], _it.SIDHistory[0][_it.SIDHistory[0].Length - 1]);
            Assert.AreEqual(byteArray[byteArray.Length - 1], _it.SIDHistory[1][_it.SIDHistory[1].Length - 1]);
        }


        [TestMethod]
        public void It_has_TimeZone_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.TimeZone);
        }

        [TestMethod]
        public void It_has_TimeZone_which_can_be_set_back_to_null()
        {
            // Arrange
            var testTimeZoneConfiguration = new TimeZoneConfiguration { DisplayName = "Test TimeZoneConfiguration" };			
            _it.TimeZone = testTimeZoneConfiguration; 

            // Act
            _it.TimeZone = null;

            // Assert
            Assert.IsNull(_it.TimeZone);
        }

        [TestMethod]
        public void It_can_get_and_set_TimeZone()
        {
            // Act
			var testTimeZoneConfiguration = new TimeZoneConfiguration { DisplayName = "Test TimeZoneConfiguration" };			
            _it.TimeZone = testTimeZoneConfiguration; 

            // Assert
            Assert.AreEqual(testTimeZoneConfiguration.DisplayName, _it.TimeZone.DisplayName);
        }


    }
}
