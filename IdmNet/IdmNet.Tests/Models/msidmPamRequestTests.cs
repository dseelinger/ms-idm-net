using System;
using System.Collections.Generic;
using IdmNet.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable ObjectCreationAsStatement
// ReSharper disable UseObjectOrCollectionInitializer

namespace IdmNet.Models.Tests
{
    [TestClass]
    public class msidmPamRequestTests
    {
        private msidmPamRequest _it;

        public msidmPamRequestTests()
        {
            _it = new msidmPamRequest();
        }

        [TestMethod]
        public void It_has_a_paremeterless_constructor()
        {
            Assert.AreEqual("msidmPamRequest", _it.ObjectType);
        }

        [TestMethod]
        public void It_has_a_constructor_that_takes_an_IdmResource()
        {
            var resource = new IdmResource
            {
                DisplayName = "My Display Name",
                Creator = new Person { DisplayName = "Creator Display Name", ObjectID = "Creator ObjectID"},
            };
            var it = new msidmPamRequest(resource);

            Assert.AreEqual("msidmPamRequest", it.ObjectType);
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
            var it = new msidmPamRequest(resource);

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
        public void It_can_get_and_set_msidmPamRequestCreationMethod()
        {
            // Act
            _it.msidmPamRequestCreationMethod = "A string";

            // Assert
            Assert.AreEqual("A string", _it.msidmPamRequestCreationMethod);
        }


        [TestMethod]
        public void It_can_get_and_set_msidmPamRequestElevatedUserSid()
        {
            // Act
            _it.msidmPamRequestElevatedUserSid = "A string";

            // Assert
            Assert.AreEqual("A string", _it.msidmPamRequestElevatedUserSid);
        }


        [TestMethod]
        public void It_can_get_and_set_msidmPamRequestExpirationProcessedState()
        {
            // Act
            _it.msidmPamRequestExpirationProcessedState = "A string";

            // Assert
            Assert.AreEqual("A string", _it.msidmPamRequestExpirationProcessedState);
        }


        [TestMethod]
        public void It_can_get_and_set_msidmPamRequestExpirationStatusInfo()
        {
            // Act
            _it.msidmPamRequestExpirationStatusInfo = "A string";

            // Assert
            Assert.AreEqual("A string", _it.msidmPamRequestExpirationStatusInfo);
        }


        [TestMethod]
        public void It_has_msidmPamRequestGroupSidList_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.msidmPamRequestGroupSidList);
        }

        [TestMethod]
        public void It_has_msidmPamRequestGroupSidList_which_can_be_set_back_to_null()
        {
            // Arrange
            var subObject1 = "foo1";
            var subObject2 = "foo2";
            var list = new List<string> { subObject1, subObject2 };
            _it.msidmPamRequestGroupSidList = list; 

            // Act
            _it.msidmPamRequestGroupSidList = null;

            // Assert
            Assert.IsNull(_it.msidmPamRequestGroupSidList);
        }

        [TestMethod]
        public void It_can_get_and_set_msidmPamRequestGroupSidList()
        {
            var subObject1 = "foo1";
            var subObject2 = "foo2";
            var list = new List<string> { subObject1, subObject2 };

            // Act
            _it.msidmPamRequestGroupSidList = list; 

            // Assert
            Assert.AreEqual("foo1", _it.msidmPamRequestGroupSidList[0]);
            Assert.AreEqual("foo2", _it.msidmPamRequestGroupSidList[1]);
        }


        [TestMethod]
        public void It_has_msidmPamRequestExpirationDate_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.msidmPamRequestExpirationDate);
        }

        [TestMethod]
        public void It_has_msidmPamRequestExpirationDate_which_can_be_set_back_to_null()
        {
            // Arrange
            var now = DateTime.Now;
            var testTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);
            _it.msidmPamRequestExpirationDate = testTime;

            // Act
            _it.msidmPamRequestExpirationDate = null;

            // Assert
            Assert.IsNull(_it.msidmPamRequestExpirationDate);
        }

        [TestMethod]
        public void It_can_get_and_set_msidmPamRequestExpirationDate()
        {
            // Act
            var now = DateTime.Now;
            var testTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);
            _it.msidmPamRequestExpirationDate = testTime;

            // Assert
            Assert.AreEqual(testTime, _it.msidmPamRequestExpirationDate);
        }


        [TestMethod]
        public void It_has_msidmPamRequestRole_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.msidmPamRequestRole);
        }

        [TestMethod]
        public void It_has_msidmPamRequestRole_which_can_be_set_back_to_null()
        {
            // Arrange
            var testIdmResource = new IdmResource { DisplayName = "Test IdmResource" };			
            _it.msidmPamRequestRole = testIdmResource; 

            // Act
            _it.msidmPamRequestRole = null;

            // Assert
            Assert.IsNull(_it.msidmPamRequestRole);
        }

        [TestMethod]
        public void It_can_get_and_set_msidmPamRequestRole()
        {
            // Act
			var testIdmResource = new IdmResource { DisplayName = "Test IdmResource" };			
            _it.msidmPamRequestRole = testIdmResource; 

            // Assert
            Assert.AreEqual(testIdmResource.DisplayName, _it.msidmPamRequestRole.DisplayName);
        }


        [TestMethod]
        public void It_has_msidmPamRequestTime_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.msidmPamRequestTime);
        }

        [TestMethod]
        public void It_has_msidmPamRequestTime_which_can_be_set_back_to_null()
        {
            // Arrange
            var now = DateTime.Now;
            var testTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);
            _it.msidmPamRequestTime = testTime;

            // Act
            _it.msidmPamRequestTime = null;

            // Assert
            Assert.IsNull(_it.msidmPamRequestTime);
        }

        [TestMethod]
        public void It_can_get_and_set_msidmPamRequestTime()
        {
            // Act
            var now = DateTime.Now;
            var testTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);
            _it.msidmPamRequestTime = testTime;

            // Assert
            Assert.AreEqual(testTime, _it.msidmPamRequestTime);
        }


        [TestMethod]
        public void It_has_msidmPamRequestWasClosed_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.msidmPamRequestWasClosed);
        }

        [TestMethod]
        public void It_has_msidmPamRequestWasClosed_which_can_be_set_back_to_null()
        {
            // Arrange
            _it.msidmPamRequestWasClosed = true;

            // Act
            _it.msidmPamRequestWasClosed = null;

            // Assert
            Assert.IsNull(_it.msidmPamRequestWasClosed);
        }

        [TestMethod]
        public void It_can_get_and_set_msidmPamRequestWasClosed()
        {
            // Act
            _it.msidmPamRequestWasClosed = true;

            // Assert
            Assert.AreEqual(true, _it.msidmPamRequestWasClosed);
        }


        [TestMethod]
        public void It_has_msidmPamRequestTTL_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.msidmPamRequestTTL);
        }

        [TestMethod]
        public void It_has_msidmPamRequestTTL_which_can_be_set_back_to_null()
        {
            // Arrange
            _it.msidmPamRequestTTL = 123;

            // Act
            _it.msidmPamRequestTTL = null;

            // Assert
            Assert.IsNull(_it.msidmPamRequestTTL);
        }

        [TestMethod]
        public void It_can_get_and_set_msidmPamRequestTTL()
        {
            // Act
            _it.msidmPamRequestTTL = 123;

            // Assert
            Assert.AreEqual(123, _it.msidmPamRequestTTL);
        }


    }
}
