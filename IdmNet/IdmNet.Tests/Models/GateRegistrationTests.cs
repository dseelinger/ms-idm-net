using System;
using System.Collections.Generic;
using IdmNet.Models;
using Xunit;
using FluentAssertions;
// ReSharper disable ObjectCreationAsStatement
// ReSharper disable UseObjectOrCollectionInitializer

namespace IdmNet.Models.Tests
{
    public class GateRegistrationTests
    {
        private GateRegistration _it;

        public GateRegistrationTests()
        {
            _it = new GateRegistration();
        }

        [Fact]
        public void It_has_a_paremeterless_constructor()
        {
            _it.ObjectType.Should().Be("GateRegistration");
        }

        [Fact]
        public void It_has_a_constructor_that_takes_an_IdmResource()
        {
            var resource = new IdmResource
            {
                DisplayName = "My Display Name",
                Creator = new Person { DisplayName = "Creator Display Name", ObjectID = "Creator ObjectID"},
            };
            var it = new GateRegistration(resource);

            it.ObjectType.Should().Be("GateRegistration");
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
            var it = new GateRegistration(resource);

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
        public void It_can_get_and_set_GateData()
        {
            // Arrange
            var stringReprentation = @"/9j/4AAQSkZJRgABAQEAYABgAAD/2wBDAAoHBwkHBgoJCAkLCwoMDxkQDw4ODx4WFxIZJCAmJSMgIyIoLTkwKCo2KyIjMkQyNjs9QEBAJjBGS0U+Sjk/QD3/2wBDAQsLCw8NDx0QEB09KSMpPT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT3/wAARCAAyADIDASIAAhEBAxEB/8QAHwAAAQUBAQEBAQEAAAAAAAAAAAECAwQFBgcICQoL/8QAtRAAAgEDAwIEAwUFBAQAAAF9AQIDAAQRBRIhMUEGE1FhByJxFDKBkaEII0KxwRVS0fAkM2JyggkKFhcYGRolJicoKSo0NTY3ODk6Q0RFRkdISUpTVFVWV1hZWmNkZWZnaGlqc3R1dnd4eXqDhIWGh4iJipKTlJWWl5iZmqKjpKWmp6ipqrKztLW2t7i5usLDxMXGx8jJytLT1NXW19jZ2uHi4+Tl5ufo6erx8vP09fb3+Pn6/8QAHwEAAwEBAQEBAQEBAQAAAAAAAAECAwQFBgcICQoL/8QAtREAAgECBAQDBAcFBAQAAQJ3AAECAxEEBSExBhJBUQdhcRMiMoEIFEKRobHBCSMzUvAVYnLRChYkNOEl8RcYGRomJygpKjU2Nzg5OkNERUZHSElKU1RVVldYWVpjZGVmZ2hpanN0dXZ3eHl6goOEhYaHiImKkpOUlZaXmJmaoqOkpaanqKmqsrO0tba3uLm6wsPExcbHyMnK0tPU1dbX2Nna4uPk5ebn6Onq8vP09fb3+Pn6/9oADAMBAAIRAxEAPwD2CS6t42KvPGrDqCwBpv221/5+Yf8AvsV494+O3xpfgZGPL7/9M1rnsn1P51i6tnY+pw/DqrUYVPaW5knt3XqfQDXdqf8Al4h/77FcBoHjKPS9dvNOvmAs3uZDFLj/AFZLHr6g+vb6V59uPrRuO7Oec5zUuo2d+H4fp04ThOXMpeVreZ9DowYZBBUjIIPWnV5Z4L8anTymn6m5a0J2xSt/yy9if7v8vpXqKuGAKkFSMgg9a2jJSR8rjsBUwdTknt0fcfRSUVRwni/j/wD5HXUP+2f/AKLWudrovH//ACOuof8AbP8A9FrXO1yS3Z+nYD/dKX+GP5IKKKKk6xQcGu18GeNTpzJp2pvm0biOVusR9D/s/wAq4quu8F+Dn1iVb29QixjbhT/y2I7fT1NXC99Dzs0jhnh5fWNvxv5ef9bHqI1K1IBE8WP94UUz+ybD/nzg/wC/YorqPz21Lz/A8k8e8eMr/wD7Z/8Aota57Nez6n4L0nVtQlu7qKRppMbiJCBwABx9BVX/AIVxoX/PvL/3+NYSpSbbPrcLn+FpUIU5J3SS27L1PIutBGK9e/4VzoOP9RLn/rsa4rRfB0ms+ILqLDR6fbTMjv3wGPyj3x+VQ6ckd9DOsLWjKaulHe4zwd4RfX7nz7oMlhEfmYcGQ/3R/U16/DBHBCkUKCONAAqqMACmWlpDZ26W9tGI4Y1Cqi9ABU/WuiEeVHx2Y5jPHVOZ6RWy/rqFFLRVHnBRRRQA09DWP4aH/EumPf7TN/6GaKKSOin/AAJ+q/U2aWiimc4UUUUAf//Z";
            var byteArray = Convert.FromBase64String(stringReprentation);

            // Act
            _it.GateData = byteArray; 

            // Assert
            _it.GateData[0].Should().Be(byteArray[0]);
            _it.GateData[1].Should().Be(byteArray[1]);
            _it.GateData[2].Should().Be(byteArray[2]);
            _it.GateData[_it.GateData.Length - 1].Should().Be(byteArray[byteArray.Length - 1]);
        }


        [Fact]
        public void It_can_get_and_set_GateID()
        {
            // Act
            _it.GateID = "A string";

            // Assert
            _it.GateID.Should().Be("A string");
        }


        [Fact]
        public void It_can_get_and_set_GateTypeId()
        {
            // Act
            _it.GateTypeId = "A string";

            // Assert
            _it.GateTypeId.Should().Be("A string");
        }


        [Fact]
        public void It_has_UserID_which_is_null_by_default()
        {
            // Assert
            _it.UserID.Should().Be(null);
        }

        [Fact]
        public void It_has_UserID_which_can_be_set_back_to_null()
        {
            // Arrange
            var testPerson = new Person { DisplayName = "Test Person" };			
            _it.UserID = testPerson; 

            // Act
            _it.UserID = null;

            // Assert
            _it.UserID.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_UserID()
        {
            // Act
			var testPerson = new Person { DisplayName = "Test Person" };			
            _it.UserID = testPerson; 

            // Assert
            _it.UserID.DisplayName.Should().Be(testPerson.DisplayName);
        }


        [Fact]
        public void It_has_WorkflowDefinition_which_is_null_by_default()
        {
            // Assert
            _it.WorkflowDefinition.Should().Be(null);
        }

        [Fact]
        public void It_has_WorkflowDefinition_which_can_be_set_back_to_null()
        {
            // Arrange
            var testWorkflowDefinition = new WorkflowDefinition { DisplayName = "Test WorkflowDefinition" };			
            _it.WorkflowDefinition = testWorkflowDefinition; 

            // Act
            _it.WorkflowDefinition = null;

            // Assert
            _it.WorkflowDefinition.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_WorkflowDefinition()
        {
            // Act
			var testWorkflowDefinition = new WorkflowDefinition { DisplayName = "Test WorkflowDefinition" };			
            _it.WorkflowDefinition = testWorkflowDefinition; 

            // Assert
            _it.WorkflowDefinition.DisplayName.Should().Be(testWorkflowDefinition.DisplayName);
        }


    }
}
