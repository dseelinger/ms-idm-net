using System;
using System.Collections.Generic;
using IdmNet.Models;
using Xunit;
using FluentAssertions;
// ReSharper disable ObjectCreationAsStatement
// ReSharper disable UseObjectOrCollectionInitializer

namespace IdmNet.Models.Tests
{
    public class msidmRequestTargetDetailTests
    {
        private msidmRequestTargetDetail _it;

        public msidmRequestTargetDetailTests()
        {
            _it = new msidmRequestTargetDetail();
        }

        [Fact]
        public void It_has_a_paremeterless_constructor()
        {
            _it.ObjectType.Should().Be("msidmRequestTargetDetail");
        }

        [Fact]
        public void It_has_a_constructor_that_takes_an_IdmResource()
        {
            var resource = new IdmResource
            {
                DisplayName = "My Display Name",
                Creator = new Person { DisplayName = "Creator Display Name", ObjectID = "Creator ObjectID"},
            };
            var it = new msidmRequestTargetDetail(resource);

            it.ObjectType.Should().Be("msidmRequestTargetDetail");
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
            var it = new msidmRequestTargetDetail(resource);

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
        public void It_can_get_and_set_msidmAttributeName()
        {
            // Act
            _it.msidmAttributeName = "A string";

            // Assert
            _it.msidmAttributeName.Should().Be("A string");
        }


        [Fact]
        public void It_has_msidmAttributeTypeID_which_is_null_by_default()
        {
            // Assert
            _it.msidmAttributeTypeID.Should().Be(null);
        }

        [Fact]
        public void It_has_msidmAttributeTypeID_which_can_be_set_back_to_null()
        {
            // Arrange
            var testIdmResource = new IdmResource { DisplayName = "Test IdmResource" };			
            _it.msidmAttributeTypeID = testIdmResource; 

            // Act
            _it.msidmAttributeTypeID = null;

            // Assert
            _it.msidmAttributeTypeID.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_msidmAttributeTypeID()
        {
            // Act
			var testIdmResource = new IdmResource { DisplayName = "Test IdmResource" };			
            _it.msidmAttributeTypeID = testIdmResource; 

            // Assert
            _it.msidmAttributeTypeID.DisplayName.Should().Be(testIdmResource.DisplayName);
        }


        [Fact]
        public void It_has_msidmAttributeTypeKey_which_is_null_by_default()
        {
            // Assert
            _it.msidmAttributeTypeKey.Should().Be(null);
        }

        [Fact]
        public void It_has_msidmAttributeTypeKey_which_can_be_set_back_to_null()
        {
            // Arrange
            _it.msidmAttributeTypeKey = 123;

            // Act
            _it.msidmAttributeTypeKey = null;

            // Assert
            _it.msidmAttributeTypeKey.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_msidmAttributeTypeKey()
        {
            // Act
            _it.msidmAttributeTypeKey = 123;

            // Assert
            _it.msidmAttributeTypeKey.Should().Be(123);
        }


        [Fact]
        public void It_can_get_and_set_msidmAttributeValue()
        {
            // Act
            _it.msidmAttributeValue = "A string";

            // Assert
            _it.msidmAttributeValue.Should().Be("A string");
        }


        [Fact]
        public void It_has_msidmIsReference_which_is_null_by_default()
        {
            // Assert
            _it.msidmIsReference.Should().Be(null);
        }

        [Fact]
        public void It_has_msidmIsReference_which_can_be_set_back_to_null()
        {
            // Arrange
            _it.msidmIsReference = 123;

            // Act
            _it.msidmIsReference = null;

            // Assert
            _it.msidmIsReference.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_msidmIsReference()
        {
            // Act
            _it.msidmIsReference = 123;

            // Assert
            _it.msidmIsReference.Should().Be(123);
        }


        [Fact]
        public void It_can_get_and_set_msidmMode()
        {
            // Act
            _it.msidmMode = "A string";

            // Assert
            _it.msidmMode.Should().Be("A string");
        }


        [Fact]
        public void It_has_Request_which_is_null_by_default()
        {
            // Assert
            _it.Request.Should().Be(null);
        }

        [Fact]
        public void It_has_Request_which_can_be_set_back_to_null()
        {
            // Arrange
            var testRequest = new Request { DisplayName = "Test Request" };			
            _it.Request = testRequest; 

            // Act
            _it.Request = null;

            // Assert
            _it.Request.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_Request()
        {
            // Act
			var testRequest = new Request { DisplayName = "Test Request" };			
            _it.Request = testRequest; 

            // Assert
            _it.Request.DisplayName.Should().Be(testRequest.DisplayName);
        }


        [Fact]
        public void It_has_msidmSequenceID_which_is_null_by_default()
        {
            // Assert
            _it.msidmSequenceID.Should().Be(null);
        }

        [Fact]
        public void It_has_msidmSequenceID_which_can_be_set_back_to_null()
        {
            // Arrange
            _it.msidmSequenceID = 123;

            // Act
            _it.msidmSequenceID = null;

            // Assert
            _it.msidmSequenceID.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_msidmSequenceID()
        {
            // Act
            _it.msidmSequenceID = 123;

            // Assert
            _it.msidmSequenceID.Should().Be(123);
        }


        [Fact]
        public void It_has_Target_which_is_null_by_default()
        {
            // Assert
            _it.Target.Should().Be(null);
        }

        [Fact]
        public void It_has_Target_which_can_be_set_back_to_null()
        {
            // Arrange
            var testIdmResource = new IdmResource { DisplayName = "Test IdmResource" };			
            _it.Target = testIdmResource; 

            // Act
            _it.Target = null;

            // Assert
            _it.Target.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_Target()
        {
            // Act
			var testIdmResource = new IdmResource { DisplayName = "Test IdmResource" };			
            _it.Target = testIdmResource; 

            // Assert
            _it.Target.DisplayName.Should().Be(testIdmResource.DisplayName);
        }


        [Fact]
        public void It_has_msidmTargetObjectTypeIdentifier_which_is_null_by_default()
        {
            // Assert
            _it.msidmTargetObjectTypeIdentifier.Should().Be(null);
        }

        [Fact]
        public void It_has_msidmTargetObjectTypeIdentifier_which_can_be_set_back_to_null()
        {
            // Arrange
            var testObjectTypeDescription = new ObjectTypeDescription { DisplayName = "Test ObjectTypeDescription" };			
            _it.msidmTargetObjectTypeIdentifier = testObjectTypeDescription; 

            // Act
            _it.msidmTargetObjectTypeIdentifier = null;

            // Assert
            _it.msidmTargetObjectTypeIdentifier.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_msidmTargetObjectTypeIdentifier()
        {
            // Act
			var testObjectTypeDescription = new ObjectTypeDescription { DisplayName = "Test ObjectTypeDescription" };			
            _it.msidmTargetObjectTypeIdentifier = testObjectTypeDescription; 

            // Assert
            _it.msidmTargetObjectTypeIdentifier.DisplayName.Should().Be(testObjectTypeDescription.DisplayName);
        }


    }
}
