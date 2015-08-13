using System;
using System.Collections.Generic;
using IdmNet.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable ObjectCreationAsStatement
// ReSharper disable UseObjectOrCollectionInitializer

namespace IdmNet.Models.Tests
{
    [TestClass]
    public class msidmRequestTargetDetailTests
    {
        private msidmRequestTargetDetail _it;

        public msidmRequestTargetDetailTests()
        {
            _it = new msidmRequestTargetDetail();
        }

        [TestMethod]
        public void It_has_a_paremeterless_constructor()
        {
            Assert.AreEqual("msidmRequestTargetDetail", _it.ObjectType);
        }

        [TestMethod]
        public void It_has_a_constructor_that_takes_an_IdmResource()
        {
            var resource = new IdmResource
            {
                DisplayName = "My Display Name",
                Creator = new Person { DisplayName = "Creator Display Name", ObjectID = "Creator ObjectID"},
            };
            var it = new msidmRequestTargetDetail(resource);

            Assert.AreEqual("msidmRequestTargetDetail", it.ObjectType);
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
            var it = new msidmRequestTargetDetail(resource);

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
        public void It_can_get_and_set_msidmAttributeName()
        {
            // Act
            _it.msidmAttributeName = "A string";

            // Assert
            Assert.AreEqual("A string", _it.msidmAttributeName);
        }


        [TestMethod]
        public void It_has_msidmAttributeTypeID_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.msidmAttributeTypeID);
        }

        [TestMethod]
        public void It_has_msidmAttributeTypeID_which_can_be_set_back_to_null()
        {
            // Arrange
            var testIdmResource = new IdmResource { DisplayName = "Test IdmResource" };			
            _it.msidmAttributeTypeID = testIdmResource; 

            // Act
            _it.msidmAttributeTypeID = null;

            // Assert
            Assert.IsNull(_it.msidmAttributeTypeID);
        }

        [TestMethod]
        public void It_can_get_and_set_msidmAttributeTypeID()
        {
            // Act
			var testIdmResource = new IdmResource { DisplayName = "Test IdmResource" };			
            _it.msidmAttributeTypeID = testIdmResource; 

            // Assert
            Assert.AreEqual(testIdmResource.DisplayName, _it.msidmAttributeTypeID.DisplayName);
        }


        [TestMethod]
        public void It_has_msidmAttributeTypeKey_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.msidmAttributeTypeKey);
        }

        [TestMethod]
        public void It_has_msidmAttributeTypeKey_which_can_be_set_back_to_null()
        {
            // Arrange
            _it.msidmAttributeTypeKey = 123;

            // Act
            _it.msidmAttributeTypeKey = null;

            // Assert
            Assert.IsNull(_it.msidmAttributeTypeKey);
        }

        [TestMethod]
        public void It_can_get_and_set_msidmAttributeTypeKey()
        {
            // Act
            _it.msidmAttributeTypeKey = 123;

            // Assert
            Assert.AreEqual(123, _it.msidmAttributeTypeKey);
        }


        [TestMethod]
        public void It_can_get_and_set_msidmAttributeValue()
        {
            // Act
            _it.msidmAttributeValue = "A string";

            // Assert
            Assert.AreEqual("A string", _it.msidmAttributeValue);
        }


        [TestMethod]
        public void It_has_msidmIsReference_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.msidmIsReference);
        }

        [TestMethod]
        public void It_has_msidmIsReference_which_can_be_set_back_to_null()
        {
            // Arrange
            _it.msidmIsReference = 123;

            // Act
            _it.msidmIsReference = null;

            // Assert
            Assert.IsNull(_it.msidmIsReference);
        }

        [TestMethod]
        public void It_can_get_and_set_msidmIsReference()
        {
            // Act
            _it.msidmIsReference = 123;

            // Assert
            Assert.AreEqual(123, _it.msidmIsReference);
        }


        [TestMethod]
        public void It_can_get_and_set_msidmMode()
        {
            // Act
            _it.msidmMode = "A string";

            // Assert
            Assert.AreEqual("A string", _it.msidmMode);
        }


        [TestMethod]
        public void It_has_Request_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.Request);
        }

        [TestMethod]
        public void It_has_Request_which_can_be_set_back_to_null()
        {
            // Arrange
            var testRequest = new Request { DisplayName = "Test Request" };			
            _it.Request = testRequest; 

            // Act
            _it.Request = null;

            // Assert
            Assert.IsNull(_it.Request);
        }

        [TestMethod]
        public void It_can_get_and_set_Request()
        {
            // Act
			var testRequest = new Request { DisplayName = "Test Request" };			
            _it.Request = testRequest; 

            // Assert
            Assert.AreEqual(testRequest.DisplayName, _it.Request.DisplayName);
        }


        [TestMethod]
        public void It_has_msidmSequenceID_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.msidmSequenceID);
        }

        [TestMethod]
        public void It_has_msidmSequenceID_which_can_be_set_back_to_null()
        {
            // Arrange
            _it.msidmSequenceID = 123;

            // Act
            _it.msidmSequenceID = null;

            // Assert
            Assert.IsNull(_it.msidmSequenceID);
        }

        [TestMethod]
        public void It_can_get_and_set_msidmSequenceID()
        {
            // Act
            _it.msidmSequenceID = 123;

            // Assert
            Assert.AreEqual(123, _it.msidmSequenceID);
        }


        [TestMethod]
        public void It_has_Target_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.Target);
        }

        [TestMethod]
        public void It_has_Target_which_can_be_set_back_to_null()
        {
            // Arrange
            var testIdmResource = new IdmResource { DisplayName = "Test IdmResource" };			
            _it.Target = testIdmResource; 

            // Act
            _it.Target = null;

            // Assert
            Assert.IsNull(_it.Target);
        }

        [TestMethod]
        public void It_can_get_and_set_Target()
        {
            // Act
			var testIdmResource = new IdmResource { DisplayName = "Test IdmResource" };			
            _it.Target = testIdmResource; 

            // Assert
            Assert.AreEqual(testIdmResource.DisplayName, _it.Target.DisplayName);
        }


        [TestMethod]
        public void It_has_msidmTargetObjectTypeIdentifier_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.msidmTargetObjectTypeIdentifier);
        }

        [TestMethod]
        public void It_has_msidmTargetObjectTypeIdentifier_which_can_be_set_back_to_null()
        {
            // Arrange
            var testObjectTypeDescription = new ObjectTypeDescription { DisplayName = "Test ObjectTypeDescription" };			
            _it.msidmTargetObjectTypeIdentifier = testObjectTypeDescription; 

            // Act
            _it.msidmTargetObjectTypeIdentifier = null;

            // Assert
            Assert.IsNull(_it.msidmTargetObjectTypeIdentifier);
        }

        [TestMethod]
        public void It_can_get_and_set_msidmTargetObjectTypeIdentifier()
        {
            // Act
			var testObjectTypeDescription = new ObjectTypeDescription { DisplayName = "Test ObjectTypeDescription" };			
            _it.msidmTargetObjectTypeIdentifier = testObjectTypeDescription; 

            // Assert
            Assert.AreEqual(testObjectTypeDescription.DisplayName, _it.msidmTargetObjectTypeIdentifier.DisplayName);
        }


    }
}
