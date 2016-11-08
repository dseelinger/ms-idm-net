using System;
using System.Collections.Generic;
using IdmNet.Models;
using Xunit;
using FluentAssertions;
// ReSharper disable ObjectCreationAsStatement
// ReSharper disable UseObjectOrCollectionInitializer

namespace IdmNet.Models.Tests
{
    public class ApprovalResponseTests
    {
        private ApprovalResponse _it;

        public ApprovalResponseTests()
        {
            _it = new ApprovalResponse();
        }

        [Fact]
        public void It_has_a_paremeterless_constructor()
        {
            _it.ObjectType.Should().Be("ApprovalResponse");
        }

        [Fact]
        public void It_has_a_constructor_that_takes_an_IdmResource()
        {
            var resource = new IdmResource
            {
                DisplayName = "My Display Name",
                Creator = new Person { DisplayName = "Creator Display Name", ObjectID = "Creator ObjectID"},
            };
            var it = new ApprovalResponse(resource);

            it.ObjectType.Should().Be("ApprovalResponse");
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
            var it = new ApprovalResponse(resource);

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
        public void It_has_Approval_which_is_null_by_default()
        {
            // Assert
            _it.Approval.Should().Be(null);
        }

        [Fact]
        public void It_has_Approval_which_can_be_set_back_to_null()
        {
            // Arrange
            var testApproval = new Approval { DisplayName = "Test Approval" };			
            _it.Approval = testApproval; 

            // Act
            _it.Approval = null;

            // Assert
            _it.Approval.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_Approval()
        {
            // Act
			var testApproval = new Approval { DisplayName = "Test Approval" };			
            _it.Approval = testApproval; 

            // Assert
            _it.Approval.DisplayName.Should().Be(testApproval.DisplayName);
        }


        [Fact]
        public void It_has_ComputedActor_which_is_an_empty_collection_by_default()
        {
            // Assert
            _it.ComputedActor.Should().BeEmpty();
        }

        [Fact]
        public void It_has_ComputedActor_which_as_a_collection_cannot_be_set_to_null()
        {
            // Assert
            Action action = () => _it.ComputedActor = null;
            action.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void It_can_get_and_set_ComputedActor()
        {
            // Arrange
            var list = new List<IdmResource>
            {
                new IdmResource { DisplayName = "Test IdmResource1", ObjectID = "guid1" },
                new IdmResource { DisplayName = "Test IdmResource2", ObjectID = "guid2" }
            };

            // Act
            _it.ComputedActor = list;

            // Assert
            _it.ComputedActor[0].DisplayName.Should().Be(list[0].DisplayName);
            _it.ComputedActor[1].DisplayName.Should().Be(list[1].DisplayName);
        }

        [Fact]
        public void It_can_get_and_set_Decision()
        {
            // Act
            _it.Decision = "A string";

            // Assert
            _it.Decision.Should().Be("A string");
        }


        [Fact]
        public void It_can_get_and_set_Reason()
        {
            // Act
            _it.Reason = "A string";

            // Assert
            _it.Reason.Should().Be("A string");
        }


        [Fact]
        public void It_has_Requestor_which_is_null_by_default()
        {
            // Assert
            _it.Requestor.Should().Be(null);
        }

        [Fact]
        public void It_has_Requestor_which_can_be_set_back_to_null()
        {
            // Arrange
            var testIdmResource = new IdmResource { DisplayName = "Test IdmResource" };			
            _it.Requestor = testIdmResource; 

            // Act
            _it.Requestor = null;

            // Assert
            _it.Requestor.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_Requestor()
        {
            // Act
			var testIdmResource = new IdmResource { DisplayName = "Test IdmResource" };			
            _it.Requestor = testIdmResource; 

            // Assert
            _it.Requestor.DisplayName.Should().Be(testIdmResource.DisplayName);
        }


    }
}
