using System;
using System.Collections.Generic;
using IdmNet.Models;
using Xunit;
using FluentAssertions;
// ReSharper disable ObjectCreationAsStatement
// ReSharper disable UseObjectOrCollectionInitializer

namespace IdmNet.Models.Tests
{
    public class PersonTests
    {
        private Person _it;

        public PersonTests()
        {
            _it = new Person();
        }

        [Fact]
        public void It_has_a_paremeterless_constructor()
        {
            _it.ObjectType.Should().Be("Person");
        }

        [Fact]
        public void It_has_a_constructor_that_takes_an_IdmResource()
        {
            var resource = new IdmResource
            {
                DisplayName = "My Display Name",
                Creator = new Person { DisplayName = "Creator Display Name", ObjectID = "Creator ObjectID"},
            };
            var it = new Person(resource);

            it.ObjectType.Should().Be("Person");
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
            var it = new Person(resource);

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
        public void It_can_get_and_set_AccountName()
        {
            // Act
            _it.AccountName = "A string";

            // Assert
            _it.AccountName.Should().Be("A string");
        }


        [Fact]
        public void It_has_AD_UserCannotChangePassword_which_is_null_by_default()
        {
            // Assert
            _it.AD_UserCannotChangePassword.Should().Be(null);
        }

        [Fact]
        public void It_has_AD_UserCannotChangePassword_which_can_be_set_back_to_null()
        {
            // Arrange
            _it.AD_UserCannotChangePassword = true;

            // Act
            _it.AD_UserCannotChangePassword = null;

            // Assert
            _it.AD_UserCannotChangePassword.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_AD_UserCannotChangePassword()
        {
            // Act
            _it.AD_UserCannotChangePassword = true;

            // Assert
            _it.AD_UserCannotChangePassword.Should().Be(true);
        }


        [Fact]
        public void It_can_get_and_set_Address()
        {
            // Act
            _it.Address = "A string";

            // Assert
            _it.Address.Should().Be("A string");
        }


        [Fact]
        public void It_has_Assistant_which_is_null_by_default()
        {
            // Assert
            _it.Assistant.Should().Be(null);
        }

        [Fact]
        public void It_has_Assistant_which_can_be_set_back_to_null()
        {
            // Arrange
            var testPerson = new Person { DisplayName = "Test Person" };			
            _it.Assistant = testPerson; 

            // Act
            _it.Assistant = null;

            // Assert
            _it.Assistant.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_Assistant()
        {
            // Act
			var testPerson = new Person { DisplayName = "Test Person" };			
            _it.Assistant = testPerson; 

            // Assert
            _it.Assistant.DisplayName.Should().Be(testPerson.DisplayName);
        }


        [Fact]
        public void It_has_AuthNWFLockedOut_which_is_an_empty_collection_by_default()
        {
            // Assert
            _it.AuthNWFLockedOut.Should().BeEmpty();
        }

        [Fact]
        public void It_has_AuthNWFLockedOut_which_as_a_collection_cannot_be_set_to_null()
        {
            // Assert
            Action action = () => _it.AuthNWFLockedOut = null;
            action.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
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
            _it.AuthNWFLockedOut[0].DisplayName.Should().Be(list[0].DisplayName);
            _it.AuthNWFLockedOut[1].DisplayName.Should().Be(list[1].DisplayName);
        }

        [Fact]
        public void It_has_AuthNWFRegistered_which_is_an_empty_collection_by_default()
        {
            // Assert
            _it.AuthNWFRegistered.Should().BeEmpty();
        }

        [Fact]
        public void It_has_AuthNWFRegistered_which_as_a_collection_cannot_be_set_to_null()
        {
            // Assert
            Action action = () => _it.AuthNWFRegistered = null;
            action.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
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
            _it.AuthNWFRegistered[0].DisplayName.Should().Be(list[0].DisplayName);
            _it.AuthNWFRegistered[1].DisplayName.Should().Be(list[1].DisplayName);
        }

        [Fact]
        public void It_can_get_and_set_City()
        {
            // Act
            _it.City = "A string";

            // Assert
            _it.City.Should().Be("A string");
        }


        [Fact]
        public void It_can_get_and_set_Company()
        {
            // Act
            _it.Company = "A string";

            // Assert
            _it.Company.Should().Be("A string");
        }


        [Fact]
        public void It_can_get_and_set_CostCenter()
        {
            // Act
            _it.CostCenter = "A string";

            // Assert
            _it.CostCenter.Should().Be("A string");
        }


        [Fact]
        public void It_can_get_and_set_CostCenterName()
        {
            // Act
            _it.CostCenterName = "A string";

            // Assert
            _it.CostCenterName.Should().Be("A string");
        }


        [Fact]
        public void It_can_get_and_set_Country()
        {
            // Act
            _it.Country = "A string";

            // Assert
            _it.Country.Should().Be("A string");
        }


        [Fact]
        public void It_can_get_and_set_Department()
        {
            // Act
            _it.Department = "A string";

            // Assert
            _it.Department.Should().Be("A string");
        }


        [Fact]
        public void It_can_get_and_set_Domain()
        {
            // Act
            _it.Domain = "A string";

            // Assert
            _it.Domain.Should().Be("A string");
        }


        [Fact]
        public void It_has_DomainConfiguration_which_is_null_by_default()
        {
            // Assert
            _it.DomainConfiguration.Should().Be(null);
        }

        [Fact]
        public void It_has_DomainConfiguration_which_can_be_set_back_to_null()
        {
            // Arrange
            var testDomainConfiguration = new DomainConfiguration { DisplayName = "Test DomainConfiguration" };			
            _it.DomainConfiguration = testDomainConfiguration; 

            // Act
            _it.DomainConfiguration = null;

            // Assert
            _it.DomainConfiguration.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_DomainConfiguration()
        {
            // Act
			var testDomainConfiguration = new DomainConfiguration { DisplayName = "Test DomainConfiguration" };			
            _it.DomainConfiguration = testDomainConfiguration; 

            // Assert
            _it.DomainConfiguration.DisplayName.Should().Be(testDomainConfiguration.DisplayName);
        }


        [Fact]
        public void It_can_get_and_set_Email()
        {
            // Act
            _it.Email = "A string";

            // Assert
            _it.Email.Should().Be("A string");
        }


        [Fact]
        public void It_can_get_and_set_MailNickname()
        {
            // Act
            _it.MailNickname = "A string";

            // Assert
            _it.MailNickname.Should().Be("A string");
        }


        [Fact]
        public void It_has_EmployeeEndDate_which_is_null_by_default()
        {
            // Assert
            _it.EmployeeEndDate.Should().Be(null);
        }

        [Fact]
        public void It_has_EmployeeEndDate_which_can_be_set_back_to_null()
        {
            // Arrange
            var now = DateTime.Now;
            var testTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);
            _it.EmployeeEndDate = testTime;

            // Act
            _it.EmployeeEndDate = null;

            // Assert
            _it.EmployeeEndDate.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_EmployeeEndDate()
        {
            // Act
            var now = DateTime.Now;
            var testTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);
            _it.EmployeeEndDate = testTime;

            // Assert
            _it.EmployeeEndDate.Should().Be(testTime);
        }


        [Fact]
        public void It_can_get_and_set_EmployeeID()
        {
            // Act
            _it.EmployeeID = "A string";

            // Assert
            _it.EmployeeID.Should().Be("A string");
        }


        [Fact]
        public void It_has_EmployeeStartDate_which_is_null_by_default()
        {
            // Assert
            _it.EmployeeStartDate.Should().Be(null);
        }

        [Fact]
        public void It_has_EmployeeStartDate_which_can_be_set_back_to_null()
        {
            // Arrange
            var now = DateTime.Now;
            var testTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);
            _it.EmployeeStartDate = testTime;

            // Act
            _it.EmployeeStartDate = null;

            // Assert
            _it.EmployeeStartDate.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_EmployeeStartDate()
        {
            // Act
            var now = DateTime.Now;
            var testTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);
            _it.EmployeeStartDate = testTime;

            // Assert
            _it.EmployeeStartDate.Should().Be(testTime);
        }


        [Fact]
        public void It_can_get_and_set_EmployeeType()
        {
            // Act
            _it.EmployeeType = "A string";

            // Assert
            _it.EmployeeType.Should().Be("A string");
        }


        [Fact]
        public void It_can_get_and_set_OfficeFax()
        {
            // Act
            _it.OfficeFax = "A string";

            // Assert
            _it.OfficeFax.Should().Be("A string");
        }


        [Fact]
        public void It_can_get_and_set_FirstName()
        {
            // Act
            _it.FirstName = "A string";

            // Assert
            _it.FirstName.Should().Be("A string");
        }


        [Fact]
        public void It_has_FreezeCount_which_is_null_by_default()
        {
            // Assert
            _it.FreezeCount.Should().Be(null);
        }

        [Fact]
        public void It_has_FreezeCount_which_can_be_set_back_to_null()
        {
            // Arrange
            _it.FreezeCount = 123;

            // Act
            _it.FreezeCount = null;

            // Assert
            _it.FreezeCount.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_FreezeCount()
        {
            // Act
            _it.FreezeCount = 123;

            // Assert
            _it.FreezeCount.Should().Be(123);
        }


        [Fact]
        public void It_can_get_and_set_FreezeLevel()
        {
            // Act
            _it.FreezeLevel = "A string";

            // Assert
            _it.FreezeLevel.Should().Be("A string");
        }


        [Fact]
        public void It_can_get_and_set_JobTitle()
        {
            // Act
            _it.JobTitle = "A string";

            // Assert
            _it.JobTitle.Should().Be("A string");
        }


        [Fact]
        public void It_can_get_and_set_LastName()
        {
            // Act
            _it.LastName = "A string";

            // Assert
            _it.LastName.Should().Be("A string");
        }


        [Fact]
        public void It_has_LastResetAttemptTime_which_is_null_by_default()
        {
            // Assert
            _it.LastResetAttemptTime.Should().Be(null);
        }

        [Fact]
        public void It_has_LastResetAttemptTime_which_can_be_set_back_to_null()
        {
            // Arrange
            var now = DateTime.Now;
            var testTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);
            _it.LastResetAttemptTime = testTime;

            // Act
            _it.LastResetAttemptTime = null;

            // Assert
            _it.LastResetAttemptTime.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_LastResetAttemptTime()
        {
            // Act
            var now = DateTime.Now;
            var testTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);
            _it.LastResetAttemptTime = testTime;

            // Assert
            _it.LastResetAttemptTime.Should().Be(testTime);
        }


        [Fact]
        public void It_has_AuthNLockoutRegistrationID_which_is_an_empty_collection_by_default()
        {
            // Assert
            _it.AuthNLockoutRegistrationID.Should().BeEmpty();
        }

        [Fact]
        public void It_has_AuthNLockoutRegistrationID_which_as_a_collection_cannot_be_set_to_null()
        {
            // Assert
            Action action = () => _it.AuthNLockoutRegistrationID = null;
            action.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
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
            _it.AuthNLockoutRegistrationID[0].DisplayName.Should().Be(list[0].DisplayName);
            _it.AuthNLockoutRegistrationID[1].DisplayName.Should().Be(list[1].DisplayName);
        }

        [Fact]
        public void It_can_get_and_set_LoginName()
        {
            // Act
            _it.LoginName = "A string";

            // Assert
            _it.LoginName.Should().Be("A string");
        }


        [Fact]
        public void It_has_Manager_which_is_null_by_default()
        {
            // Assert
            _it.Manager.Should().Be(null);
        }

        [Fact]
        public void It_has_Manager_which_can_be_set_back_to_null()
        {
            // Arrange
            var testPerson = new Person { DisplayName = "Test Person" };			
            _it.Manager = testPerson; 

            // Act
            _it.Manager = null;

            // Assert
            _it.Manager.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_Manager()
        {
            // Act
			var testPerson = new Person { DisplayName = "Test Person" };			
            _it.Manager = testPerson; 

            // Assert
            _it.Manager.DisplayName.Should().Be(testPerson.DisplayName);
        }


        [Fact]
        public void It_can_get_and_set_msidmMFAPINCode()
        {
            // Act
            _it.msidmMFAPINCode = "A string";

            // Assert
            _it.msidmMFAPINCode.Should().Be("A string");
        }


        [Fact]
        public void It_can_get_and_set_MiddleName()
        {
            // Act
            _it.MiddleName = "A string";

            // Assert
            _it.MiddleName.Should().Be("A string");
        }


        [Fact]
        public void It_can_get_and_set_MobilePhone()
        {
            // Act
            _it.MobilePhone = "A string";

            // Assert
            _it.MobilePhone.Should().Be("A string");
        }


        [Fact]
        public void It_can_get_and_set_OfficeLocation()
        {
            // Act
            _it.OfficeLocation = "A string";

            // Assert
            _it.OfficeLocation.Should().Be("A string");
        }


        [Fact]
        public void It_can_get_and_set_OfficePhone()
        {
            // Act
            _it.OfficePhone = "A string";

            // Assert
            _it.OfficePhone.Should().Be("A string");
        }


        [Fact]
        public void It_can_get_and_set_msidmOneTimePasswordEmailAddress()
        {
            // Act
            _it.msidmOneTimePasswordEmailAddress = "A string";

            // Assert
            _it.msidmOneTimePasswordEmailAddress.Should().Be("A string");
        }


        [Fact]
        public void It_can_get_and_set_msidmOneTimePasswordMobilePhone()
        {
            // Act
            _it.msidmOneTimePasswordMobilePhone = "A string";

            // Assert
            _it.msidmOneTimePasswordMobilePhone.Should().Be("A string");
        }


        [Fact]
        public void It_has_msidmPamLinkedUser_which_is_null_by_default()
        {
            // Assert
            _it.msidmPamLinkedUser.Should().Be(null);
        }

        [Fact]
        public void It_has_msidmPamLinkedUser_which_can_be_set_back_to_null()
        {
            // Arrange
            var testIdmResource = new IdmResource { DisplayName = "Test IdmResource" };			
            _it.msidmPamLinkedUser = testIdmResource; 

            // Act
            _it.msidmPamLinkedUser = null;

            // Assert
            _it.msidmPamLinkedUser.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_msidmPamLinkedUser()
        {
            // Act
			var testIdmResource = new IdmResource { DisplayName = "Test IdmResource" };			
            _it.msidmPamLinkedUser = testIdmResource; 

            // Assert
            _it.msidmPamLinkedUser.DisplayName.Should().Be(testIdmResource.DisplayName);
        }


        [Fact]
        public void It_can_get_and_set_msidmPhoneGatePhoneNumber()
        {
            // Act
            _it.msidmPhoneGatePhoneNumber = "A string";

            // Assert
            _it.msidmPhoneGatePhoneNumber.Should().Be("A string");
        }


        [Fact]
        public void It_has_Photo_which_is_null_by_default()
        {
            // Assert
            _it.Photo.Should().BeNull();
        }

        [Fact]
        public void It_has_Photo_which_can_be_set_back_to_null()
        {
            // Arrange
            var stringReprentation = @"/9j/4AAQSkZJRgABAQEAYABgAAD/2wBDAAoHBwkHBgoJCAkLCwoMDxkQDw4ODx4WFxIZJCAmJSMgIyIoLTkwKCo2KyIjMkQyNjs9QEBAJjBGS0U+Sjk/QD3/2wBDAQsLCw8NDx0QEB09KSMpPT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT3/wAARCAAyADIDASIAAhEBAxEB/8QAHwAAAQUBAQEBAQEAAAAAAAAAAAECAwQFBgcICQoL/8QAtRAAAgEDAwIEAwUFBAQAAAF9AQIDAAQRBRIhMUEGE1FhByJxFDKBkaEII0KxwRVS0fAkM2JyggkKFhcYGRolJicoKSo0NTY3ODk6Q0RFRkdISUpTVFVWV1hZWmNkZWZnaGlqc3R1dnd4eXqDhIWGh4iJipKTlJWWl5iZmqKjpKWmp6ipqrKztLW2t7i5usLDxMXGx8jJytLT1NXW19jZ2uHi4+Tl5ufo6erx8vP09fb3+Pn6/8QAHwEAAwEBAQEBAQEBAQAAAAAAAAECAwQFBgcICQoL/8QAtREAAgECBAQDBAcFBAQAAQJ3AAECAxEEBSExBhJBUQdhcRMiMoEIFEKRobHBCSMzUvAVYnLRChYkNOEl8RcYGRomJygpKjU2Nzg5OkNERUZHSElKU1RVVldYWVpjZGVmZ2hpanN0dXZ3eHl6goOEhYaHiImKkpOUlZaXmJmaoqOkpaanqKmqsrO0tba3uLm6wsPExcbHyMnK0tPU1dbX2Nna4uPk5ebn6Onq8vP09fb3+Pn6/9oADAMBAAIRAxEAPwD2CS6t42KvPGrDqCwBpv221/5+Yf8AvsV494+O3xpfgZGPL7/9M1rnsn1P51i6tnY+pw/DqrUYVPaW5knt3XqfQDXdqf8Al4h/77FcBoHjKPS9dvNOvmAs3uZDFLj/AFZLHr6g+vb6V59uPrRuO7Oec5zUuo2d+H4fp04ThOXMpeVreZ9DowYZBBUjIIPWnV5Z4L8anTymn6m5a0J2xSt/yy9if7v8vpXqKuGAKkFSMgg9a2jJSR8rjsBUwdTknt0fcfRSUVRwni/j/wD5HXUP+2f/AKLWudrovH//ACOuof8AbP8A9FrXO1yS3Z+nYD/dKX+GP5IKKKKk6xQcGu18GeNTpzJp2pvm0biOVusR9D/s/wAq4quu8F+Dn1iVb29QixjbhT/y2I7fT1NXC99Dzs0jhnh5fWNvxv5ef9bHqI1K1IBE8WP94UUz+ybD/nzg/wC/YorqPz21Lz/A8k8e8eMr/wD7Z/8Aota57Nez6n4L0nVtQlu7qKRppMbiJCBwABx9BVX/AIVxoX/PvL/3+NYSpSbbPrcLn+FpUIU5J3SS27L1PIutBGK9e/4VzoOP9RLn/rsa4rRfB0ms+ILqLDR6fbTMjv3wGPyj3x+VQ6ckd9DOsLWjKaulHe4zwd4RfX7nz7oMlhEfmYcGQ/3R/U16/DBHBCkUKCONAAqqMACmWlpDZ26W9tGI4Y1Cqi9ABU/WuiEeVHx2Y5jPHVOZ6RWy/rqFFLRVHnBRRRQA09DWP4aH/EumPf7TN/6GaKKSOin/AAJ+q/U2aWiimc4UUUUAf//Z";
            var byteArray = Convert.FromBase64String(stringReprentation);
            _it.Photo = byteArray; 

            // Act
            _it.Photo = null;

            // Assert
            _it.Photo.Should().BeNull();
        }

        [Fact]
        public void It_can_get_and_set_Photo()
        {
            // Arrange
            var stringReprentation = @"/9j/4AAQSkZJRgABAQEAYABgAAD/2wBDAAoHBwkHBgoJCAkLCwoMDxkQDw4ODx4WFxIZJCAmJSMgIyIoLTkwKCo2KyIjMkQyNjs9QEBAJjBGS0U+Sjk/QD3/2wBDAQsLCw8NDx0QEB09KSMpPT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT3/wAARCAAyADIDASIAAhEBAxEB/8QAHwAAAQUBAQEBAQEAAAAAAAAAAAECAwQFBgcICQoL/8QAtRAAAgEDAwIEAwUFBAQAAAF9AQIDAAQRBRIhMUEGE1FhByJxFDKBkaEII0KxwRVS0fAkM2JyggkKFhcYGRolJicoKSo0NTY3ODk6Q0RFRkdISUpTVFVWV1hZWmNkZWZnaGlqc3R1dnd4eXqDhIWGh4iJipKTlJWWl5iZmqKjpKWmp6ipqrKztLW2t7i5usLDxMXGx8jJytLT1NXW19jZ2uHi4+Tl5ufo6erx8vP09fb3+Pn6/8QAHwEAAwEBAQEBAQEBAQAAAAAAAAECAwQFBgcICQoL/8QAtREAAgECBAQDBAcFBAQAAQJ3AAECAxEEBSExBhJBUQdhcRMiMoEIFEKRobHBCSMzUvAVYnLRChYkNOEl8RcYGRomJygpKjU2Nzg5OkNERUZHSElKU1RVVldYWVpjZGVmZ2hpanN0dXZ3eHl6goOEhYaHiImKkpOUlZaXmJmaoqOkpaanqKmqsrO0tba3uLm6wsPExcbHyMnK0tPU1dbX2Nna4uPk5ebn6Onq8vP09fb3+Pn6/9oADAMBAAIRAxEAPwD2CS6t42KvPGrDqCwBpv221/5+Yf8AvsV494+O3xpfgZGPL7/9M1rnsn1P51i6tnY+pw/DqrUYVPaW5knt3XqfQDXdqf8Al4h/77FcBoHjKPS9dvNOvmAs3uZDFLj/AFZLHr6g+vb6V59uPrRuO7Oec5zUuo2d+H4fp04ThOXMpeVreZ9DowYZBBUjIIPWnV5Z4L8anTymn6m5a0J2xSt/yy9if7v8vpXqKuGAKkFSMgg9a2jJSR8rjsBUwdTknt0fcfRSUVRwni/j/wD5HXUP+2f/AKLWudrovH//ACOuof8AbP8A9FrXO1yS3Z+nYD/dKX+GP5IKKKKk6xQcGu18GeNTpzJp2pvm0biOVusR9D/s/wAq4quu8F+Dn1iVb29QixjbhT/y2I7fT1NXC99Dzs0jhnh5fWNvxv5ef9bHqI1K1IBE8WP94UUz+ybD/nzg/wC/YorqPz21Lz/A8k8e8eMr/wD7Z/8Aota57Nez6n4L0nVtQlu7qKRppMbiJCBwABx9BVX/AIVxoX/PvL/3+NYSpSbbPrcLn+FpUIU5J3SS27L1PIutBGK9e/4VzoOP9RLn/rsa4rRfB0ms+ILqLDR6fbTMjv3wGPyj3x+VQ6ckd9DOsLWjKaulHe4zwd4RfX7nz7oMlhEfmYcGQ/3R/U16/DBHBCkUKCONAAqqMACmWlpDZ26W9tGI4Y1Cqi9ABU/WuiEeVHx2Y5jPHVOZ6RWy/rqFFLRVHnBRRRQA09DWP4aH/EumPf7TN/6GaKKSOin/AAJ+q/U2aWiimc4UUUUAf//Z";
            var byteArray = Convert.FromBase64String(stringReprentation);

            // Act
            _it.Photo = byteArray; 

            // Assert
            _it.Photo[0].Should().Be(byteArray[0]);
            _it.Photo[1].Should().Be(byteArray[1]);
            _it.Photo[2].Should().Be(byteArray[2]);
            _it.Photo[_it.Photo.Length - 1].Should().Be(byteArray[byteArray.Length - 1]);
        }


        [Fact]
        public void It_can_get_and_set_PostalCode()
        {
            // Act
            _it.PostalCode = "A string";

            // Assert
            _it.PostalCode.Should().Be("A string");
        }


        [Fact]
        public void It_has_ProxyAddressCollection_which_is_an_empty_collection_by_default()
        {
            // Assert
            _it.ProxyAddressCollection.Should().BeEmpty();
        }

        [Fact]
        public void It_has_ProxyAddressCollection_which_as_a_collection_cannot_be_set_to_null()
        {
            // Assert
            Action action = () => _it.ProxyAddressCollection = null;
            action.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void It_can_get_and_set_ProxyAddressCollection()
        {
            var subObject1 = "foo1";
            var subObject2 = "foo2";
            var list = new List<string> { subObject1, subObject2 };

            // Act
            _it.ProxyAddressCollection = list; 

            // Assert
            _it.ProxyAddressCollection[0].Should().Be("foo1");
            _it.ProxyAddressCollection[1].Should().Be("foo2");
        }


        [Fact]
        public void It_has_IsRASEnabled_which_is_null_by_default()
        {
            // Assert
            _it.IsRASEnabled.Should().Be(null);
        }

        [Fact]
        public void It_has_IsRASEnabled_which_can_be_set_back_to_null()
        {
            // Arrange
            _it.IsRASEnabled = true;

            // Act
            _it.IsRASEnabled = null;

            // Assert
            _it.IsRASEnabled.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_IsRASEnabled()
        {
            // Act
            _it.IsRASEnabled = true;

            // Assert
            _it.IsRASEnabled.Should().Be(true);
        }


        [Fact]
        public void It_has_Register_which_is_null_by_default()
        {
            // Assert
            _it.Register.Should().Be(null);
        }

        [Fact]
        public void It_has_Register_which_can_be_set_back_to_null()
        {
            // Arrange
            _it.Register = true;

            // Act
            _it.Register = null;

            // Assert
            _it.Register.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_Register()
        {
            // Act
            _it.Register = true;

            // Assert
            _it.Register.Should().Be(true);
        }


        [Fact]
        public void It_has_RegistrationRequired_which_is_null_by_default()
        {
            // Assert
            _it.RegistrationRequired.Should().Be(null);
        }

        [Fact]
        public void It_has_RegistrationRequired_which_can_be_set_back_to_null()
        {
            // Arrange
            _it.RegistrationRequired = true;

            // Act
            _it.RegistrationRequired = null;

            // Assert
            _it.RegistrationRequired.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_RegistrationRequired()
        {
            // Act
            _it.RegistrationRequired = true;

            // Assert
            _it.RegistrationRequired.Should().Be(true);
        }


        [Fact]
        public void It_can_get_and_set_ResetPassword()
        {
            // Act
            _it.ResetPassword = "A string";

            // Assert
            _it.ResetPassword.Should().Be("A string");
        }


        [Fact]
        public void It_has_ObjectSID_which_is_null_by_default()
        {
            // Assert
            _it.ObjectSID.Should().BeNull();
        }

        [Fact]
        public void It_has_ObjectSID_which_can_be_set_back_to_null()
        {
            // Arrange
            var stringReprentation = @"/9j/4AAQSkZJRgABAQEAYABgAAD/2wBDAAoHBwkHBgoJCAkLCwoMDxkQDw4ODx4WFxIZJCAmJSMgIyIoLTkwKCo2KyIjMkQyNjs9QEBAJjBGS0U+Sjk/QD3/2wBDAQsLCw8NDx0QEB09KSMpPT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT3/wAARCAAyADIDASIAAhEBAxEB/8QAHwAAAQUBAQEBAQEAAAAAAAAAAAECAwQFBgcICQoL/8QAtRAAAgEDAwIEAwUFBAQAAAF9AQIDAAQRBRIhMUEGE1FhByJxFDKBkaEII0KxwRVS0fAkM2JyggkKFhcYGRolJicoKSo0NTY3ODk6Q0RFRkdISUpTVFVWV1hZWmNkZWZnaGlqc3R1dnd4eXqDhIWGh4iJipKTlJWWl5iZmqKjpKWmp6ipqrKztLW2t7i5usLDxMXGx8jJytLT1NXW19jZ2uHi4+Tl5ufo6erx8vP09fb3+Pn6/8QAHwEAAwEBAQEBAQEBAQAAAAAAAAECAwQFBgcICQoL/8QAtREAAgECBAQDBAcFBAQAAQJ3AAECAxEEBSExBhJBUQdhcRMiMoEIFEKRobHBCSMzUvAVYnLRChYkNOEl8RcYGRomJygpKjU2Nzg5OkNERUZHSElKU1RVVldYWVpjZGVmZ2hpanN0dXZ3eHl6goOEhYaHiImKkpOUlZaXmJmaoqOkpaanqKmqsrO0tba3uLm6wsPExcbHyMnK0tPU1dbX2Nna4uPk5ebn6Onq8vP09fb3+Pn6/9oADAMBAAIRAxEAPwD2CS6t42KvPGrDqCwBpv221/5+Yf8AvsV494+O3xpfgZGPL7/9M1rnsn1P51i6tnY+pw/DqrUYVPaW5knt3XqfQDXdqf8Al4h/77FcBoHjKPS9dvNOvmAs3uZDFLj/AFZLHr6g+vb6V59uPrRuO7Oec5zUuo2d+H4fp04ThOXMpeVreZ9DowYZBBUjIIPWnV5Z4L8anTymn6m5a0J2xSt/yy9if7v8vpXqKuGAKkFSMgg9a2jJSR8rjsBUwdTknt0fcfRSUVRwni/j/wD5HXUP+2f/AKLWudrovH//ACOuof8AbP8A9FrXO1yS3Z+nYD/dKX+GP5IKKKKk6xQcGu18GeNTpzJp2pvm0biOVusR9D/s/wAq4quu8F+Dn1iVb29QixjbhT/y2I7fT1NXC99Dzs0jhnh5fWNvxv5ef9bHqI1K1IBE8WP94UUz+ybD/nzg/wC/YorqPz21Lz/A8k8e8eMr/wD7Z/8Aota57Nez6n4L0nVtQlu7qKRppMbiJCBwABx9BVX/AIVxoX/PvL/3+NYSpSbbPrcLn+FpUIU5J3SS27L1PIutBGK9e/4VzoOP9RLn/rsa4rRfB0ms+ILqLDR6fbTMjv3wGPyj3x+VQ6ckd9DOsLWjKaulHe4zwd4RfX7nz7oMlhEfmYcGQ/3R/U16/DBHBCkUKCONAAqqMACmWlpDZ26W9tGI4Y1Cqi9ABU/WuiEeVHx2Y5jPHVOZ6RWy/rqFFLRVHnBRRRQA09DWP4aH/EumPf7TN/6GaKKSOin/AAJ+q/U2aWiimc4UUUUAf//Z";
            var byteArray = Convert.FromBase64String(stringReprentation);
            _it.ObjectSID = byteArray; 

            // Act
            _it.ObjectSID = null;

            // Assert
            _it.ObjectSID.Should().BeNull();
        }

        [Fact]
        public void It_can_get_and_set_ObjectSID()
        {
            // Arrange
            var stringReprentation = @"/9j/4AAQSkZJRgABAQEAYABgAAD/2wBDAAoHBwkHBgoJCAkLCwoMDxkQDw4ODx4WFxIZJCAmJSMgIyIoLTkwKCo2KyIjMkQyNjs9QEBAJjBGS0U+Sjk/QD3/2wBDAQsLCw8NDx0QEB09KSMpPT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT3/wAARCAAyADIDASIAAhEBAxEB/8QAHwAAAQUBAQEBAQEAAAAAAAAAAAECAwQFBgcICQoL/8QAtRAAAgEDAwIEAwUFBAQAAAF9AQIDAAQRBRIhMUEGE1FhByJxFDKBkaEII0KxwRVS0fAkM2JyggkKFhcYGRolJicoKSo0NTY3ODk6Q0RFRkdISUpTVFVWV1hZWmNkZWZnaGlqc3R1dnd4eXqDhIWGh4iJipKTlJWWl5iZmqKjpKWmp6ipqrKztLW2t7i5usLDxMXGx8jJytLT1NXW19jZ2uHi4+Tl5ufo6erx8vP09fb3+Pn6/8QAHwEAAwEBAQEBAQEBAQAAAAAAAAECAwQFBgcICQoL/8QAtREAAgECBAQDBAcFBAQAAQJ3AAECAxEEBSExBhJBUQdhcRMiMoEIFEKRobHBCSMzUvAVYnLRChYkNOEl8RcYGRomJygpKjU2Nzg5OkNERUZHSElKU1RVVldYWVpjZGVmZ2hpanN0dXZ3eHl6goOEhYaHiImKkpOUlZaXmJmaoqOkpaanqKmqsrO0tba3uLm6wsPExcbHyMnK0tPU1dbX2Nna4uPk5ebn6Onq8vP09fb3+Pn6/9oADAMBAAIRAxEAPwD2CS6t42KvPGrDqCwBpv221/5+Yf8AvsV494+O3xpfgZGPL7/9M1rnsn1P51i6tnY+pw/DqrUYVPaW5knt3XqfQDXdqf8Al4h/77FcBoHjKPS9dvNOvmAs3uZDFLj/AFZLHr6g+vb6V59uPrRuO7Oec5zUuo2d+H4fp04ThOXMpeVreZ9DowYZBBUjIIPWnV5Z4L8anTymn6m5a0J2xSt/yy9if7v8vpXqKuGAKkFSMgg9a2jJSR8rjsBUwdTknt0fcfRSUVRwni/j/wD5HXUP+2f/AKLWudrovH//ACOuof8AbP8A9FrXO1yS3Z+nYD/dKX+GP5IKKKKk6xQcGu18GeNTpzJp2pvm0biOVusR9D/s/wAq4quu8F+Dn1iVb29QixjbhT/y2I7fT1NXC99Dzs0jhnh5fWNvxv5ef9bHqI1K1IBE8WP94UUz+ybD/nzg/wC/YorqPz21Lz/A8k8e8eMr/wD7Z/8Aota57Nez6n4L0nVtQlu7qKRppMbiJCBwABx9BVX/AIVxoX/PvL/3+NYSpSbbPrcLn+FpUIU5J3SS27L1PIutBGK9e/4VzoOP9RLn/rsa4rRfB0ms+ILqLDR6fbTMjv3wGPyj3x+VQ6ckd9DOsLWjKaulHe4zwd4RfX7nz7oMlhEfmYcGQ/3R/U16/DBHBCkUKCONAAqqMACmWlpDZ26W9tGI4Y1Cqi9ABU/WuiEeVHx2Y5jPHVOZ6RWy/rqFFLRVHnBRRRQA09DWP4aH/EumPf7TN/6GaKKSOin/AAJ+q/U2aWiimc4UUUUAf//Z";
            var byteArray = Convert.FromBase64String(stringReprentation);

            // Act
            _it.ObjectSID = byteArray; 

            // Assert
            _it.ObjectSID[0].Should().Be(byteArray[0]);
            _it.ObjectSID[1].Should().Be(byteArray[1]);
            _it.ObjectSID[2].Should().Be(byteArray[2]);
            _it.ObjectSID[_it.ObjectSID.Length - 1].Should().Be(byteArray[byteArray.Length - 1]);
        }


        [Fact]
        public void It_has_SIDHistory_which_is_an_empty_collection_by_default()
        {
            // Assert
            _it.SIDHistory.Should().BeEmpty();
        }

        [Fact]
        public void It_has_SIDHistory_which_as_a_collection_cannot_be_set_to_null()
        {
            // Assert
            Action action = () => _it.SIDHistory = null;
            action.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
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
            _it.SIDHistory[0][0].Should().Be(byteArray[0]);
            _it.SIDHistory[0][1].Should().Be(byteArray[1]);
            _it.SIDHistory[0][2].Should().Be(byteArray[2]);
            _it.SIDHistory[1][0].Should().Be(byteArray[0]);
            _it.SIDHistory[1][1].Should().Be(byteArray[1]);
            _it.SIDHistory[1][2].Should().Be(byteArray[2]);
            _it.SIDHistory[0][_it.SIDHistory[0].Length - 1].Should().Be(byteArray[byteArray.Length - 1]);
            _it.SIDHistory[1][_it.SIDHistory[0].Length - 1].Should().Be(byteArray[byteArray.Length - 1]);
        }


        [Fact]
        public void It_has_TimeZone_which_is_null_by_default()
        {
            // Assert
            _it.TimeZone.Should().Be(null);
        }

        [Fact]
        public void It_has_TimeZone_which_can_be_set_back_to_null()
        {
            // Arrange
            var testTimeZoneConfiguration = new TimeZoneConfiguration { DisplayName = "Test TimeZoneConfiguration" };			
            _it.TimeZone = testTimeZoneConfiguration; 

            // Act
            _it.TimeZone = null;

            // Assert
            _it.TimeZone.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_TimeZone()
        {
            // Act
			var testTimeZoneConfiguration = new TimeZoneConfiguration { DisplayName = "Test TimeZoneConfiguration" };			
            _it.TimeZone = testTimeZoneConfiguration; 

            // Assert
            _it.TimeZone.DisplayName.Should().Be(testTimeZoneConfiguration.DisplayName);
        }


    }
}
