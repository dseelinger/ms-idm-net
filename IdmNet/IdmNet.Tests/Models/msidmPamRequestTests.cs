using System;
using System.Collections.Generic;
using IdmNet.Models;
using Xunit;
using FluentAssertions;
// ReSharper disable ObjectCreationAsStatement
// ReSharper disable UseObjectOrCollectionInitializer

namespace IdmNet.Models.Tests
{
    public class msidmPamRequestTests
    {
        private msidmPamRequest _it;

        public msidmPamRequestTests()
        {
            _it = new msidmPamRequest();
        }

        [Fact]
        public void It_has_a_paremeterless_constructor()
        {
            _it.ObjectType.Should().Be("msidmPamRequest");
        }

        [Fact]
        public void It_has_a_constructor_that_takes_an_IdmResource()
        {
            var resource = new IdmResource
            {
                DisplayName = "My Display Name",
                Creator = new Person { DisplayName = "Creator Display Name", ObjectID = "Creator ObjectID"},
            };
            var it = new msidmPamRequest(resource);

            it.ObjectType.Should().Be("msidmPamRequest");
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
            var it = new msidmPamRequest(resource);

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
        public void It_can_get_and_set_msidmPamRequestCreationMethod()
        {
            // Act
            _it.msidmPamRequestCreationMethod = "A string";

            // Assert
            _it.msidmPamRequestCreationMethod.Should().Be("A string");
        }


        [Fact]
        public void It_can_get_and_set_msidmPamRequestElevatedUserSid()
        {
            // Act
            _it.msidmPamRequestElevatedUserSid = "A string";

            // Assert
            _it.msidmPamRequestElevatedUserSid.Should().Be("A string");
        }


        [Fact]
        public void It_can_get_and_set_msidmPamRequestExpirationProcessedState()
        {
            // Act
            _it.msidmPamRequestExpirationProcessedState = "A string";

            // Assert
            _it.msidmPamRequestExpirationProcessedState.Should().Be("A string");
        }


        [Fact]
        public void It_can_get_and_set_msidmPamRequestExpirationStatusInfo()
        {
            // Act
            _it.msidmPamRequestExpirationStatusInfo = "A string";

            // Assert
            _it.msidmPamRequestExpirationStatusInfo.Should().Be("A string");
        }


        [Fact]
        public void It_has_msidmPamRequestGroupSidList_which_is_an_empty_collection_by_default()
        {
            // Assert
            _it.msidmPamRequestGroupSidList.Should().BeEmpty();
        }

        [Fact]
        public void It_has_msidmPamRequestGroupSidList_which_as_a_collection_cannot_be_set_to_null()
        {
            // Assert
            Action action = () => _it.msidmPamRequestGroupSidList = null;
            action.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void It_can_get_and_set_msidmPamRequestGroupSidList()
        {
            var subObject1 = "foo1";
            var subObject2 = "foo2";
            var list = new List<string> { subObject1, subObject2 };

            // Act
            _it.msidmPamRequestGroupSidList = list; 

            // Assert
            _it.msidmPamRequestGroupSidList[0].Should().Be("foo1");
            _it.msidmPamRequestGroupSidList[1].Should().Be("foo2");
        }


        [Fact]
        public void It_has_msidmPamRequestExpirationDate_which_is_null_by_default()
        {
            // Assert
            _it.msidmPamRequestExpirationDate.Should().Be(null);
        }

        [Fact]
        public void It_has_msidmPamRequestExpirationDate_which_can_be_set_back_to_null()
        {
            // Arrange
            var now = DateTime.Now;
            var testTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);
            _it.msidmPamRequestExpirationDate = testTime;

            // Act
            _it.msidmPamRequestExpirationDate = null;

            // Assert
            _it.msidmPamRequestExpirationDate.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_msidmPamRequestExpirationDate()
        {
            // Act
            var now = DateTime.Now;
            var testTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);
            _it.msidmPamRequestExpirationDate = testTime;

            // Assert
            _it.msidmPamRequestExpirationDate.Should().Be(testTime);
        }


        [Fact]
        public void It_has_msidmPamRequestRole_which_is_null_by_default()
        {
            // Assert
            _it.msidmPamRequestRole.Should().Be(null);
        }

        [Fact]
        public void It_has_msidmPamRequestRole_which_can_be_set_back_to_null()
        {
            // Arrange
            var testIdmResource = new IdmResource { DisplayName = "Test IdmResource" };			
            _it.msidmPamRequestRole = testIdmResource; 

            // Act
            _it.msidmPamRequestRole = null;

            // Assert
            _it.msidmPamRequestRole.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_msidmPamRequestRole()
        {
            // Act
			var testIdmResource = new IdmResource { DisplayName = "Test IdmResource" };			
            _it.msidmPamRequestRole = testIdmResource; 

            // Assert
            _it.msidmPamRequestRole.DisplayName.Should().Be(testIdmResource.DisplayName);
        }


        [Fact]
        public void It_has_msidmPamRequestTime_which_is_null_by_default()
        {
            // Assert
            _it.msidmPamRequestTime.Should().Be(null);
        }

        [Fact]
        public void It_has_msidmPamRequestTime_which_can_be_set_back_to_null()
        {
            // Arrange
            var now = DateTime.Now;
            var testTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);
            _it.msidmPamRequestTime = testTime;

            // Act
            _it.msidmPamRequestTime = null;

            // Assert
            _it.msidmPamRequestTime.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_msidmPamRequestTime()
        {
            // Act
            var now = DateTime.Now;
            var testTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);
            _it.msidmPamRequestTime = testTime;

            // Assert
            _it.msidmPamRequestTime.Should().Be(testTime);
        }


        [Fact]
        public void It_has_msidmPamRequestWasClosed_which_is_null_by_default()
        {
            // Assert
            _it.msidmPamRequestWasClosed.Should().Be(null);
        }

        [Fact]
        public void It_has_msidmPamRequestWasClosed_which_can_be_set_back_to_null()
        {
            // Arrange
            _it.msidmPamRequestWasClosed = true;

            // Act
            _it.msidmPamRequestWasClosed = null;

            // Assert
            _it.msidmPamRequestWasClosed.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_msidmPamRequestWasClosed()
        {
            // Act
            _it.msidmPamRequestWasClosed = true;

            // Assert
            _it.msidmPamRequestWasClosed.Should().Be(true);
        }


        [Fact]
        public void It_has_msidmPamRequestTTL_which_is_null_by_default()
        {
            // Assert
            _it.msidmPamRequestTTL.Should().Be(null);
        }

        [Fact]
        public void It_has_msidmPamRequestTTL_which_can_be_set_back_to_null()
        {
            // Arrange
            _it.msidmPamRequestTTL = 123;

            // Act
            _it.msidmPamRequestTTL = null;

            // Assert
            _it.msidmPamRequestTTL.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_msidmPamRequestTTL()
        {
            // Act
            _it.msidmPamRequestTTL = 123;

            // Assert
            _it.msidmPamRequestTTL.Should().Be(123);
        }


    }
}
