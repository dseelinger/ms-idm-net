using System;
using System.Collections.Generic;
using IdmNet.Models;
using Xunit;
using FluentAssertions;
// ReSharper disable ObjectCreationAsStatement
// ReSharper disable UseObjectOrCollectionInitializer

namespace IdmNet.Models.Tests
{
    public class EmailTemplateTests
    {
        private EmailTemplate _it;

        public EmailTemplateTests()
        {
            _it = new EmailTemplate();
        }

        [Fact]
        public void It_has_a_paremeterless_constructor()
        {
            _it.ObjectType.Should().Be("EmailTemplate");
        }

        [Fact]
        public void It_has_a_constructor_that_takes_an_IdmResource()
        {
            var resource = new IdmResource
            {
                DisplayName = "My Display Name",
                Creator = new Person { DisplayName = "Creator Display Name", ObjectID = "Creator ObjectID"},
            };
            var it = new EmailTemplate(resource);

            it.ObjectType.Should().Be("EmailTemplate");
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
            var it = new EmailTemplate(resource);

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
        public void It_can_get_and_set_EmailBody()
        {
            // Act
            _it.EmailBody = "A string";

            // Assert
            _it.EmailBody.Should().Be("A string");
        }


        [Fact]
        public void It_can_get_and_set_EmailSubject()
        {
            // Act
            _it.EmailSubject = "A string";

            // Assert
            _it.EmailSubject.Should().Be("A string");
        }


        [Fact]
        public void It_can_get_and_set_EmailTemplateType()
        {
            // Act
            _it.EmailTemplateType = "A string";

            // Assert
            _it.EmailTemplateType.Should().Be("A string");
        }


    }
}
