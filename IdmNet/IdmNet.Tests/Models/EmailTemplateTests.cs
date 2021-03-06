using System;
using System.Collections.Generic;
using IdmNet.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable ObjectCreationAsStatement
// ReSharper disable UseObjectOrCollectionInitializer

namespace IdmNet.Models.Tests
{
    [TestClass]
    public class EmailTemplateTests
    {
        private EmailTemplate _it;

        public EmailTemplateTests()
        {
            _it = new EmailTemplate();
        }

        [TestMethod]
        public void It_has_a_paremeterless_constructor()
        {
            Assert.AreEqual("EmailTemplate", _it.ObjectType);
        }

        [TestMethod]
        public void It_has_a_constructor_that_takes_an_IdmResource()
        {
            var resource = new IdmResource
            {
                DisplayName = "My Display Name",
                Creator = new Person { DisplayName = "Creator Display Name", ObjectID = "Creator ObjectID"},
            };
            var it = new EmailTemplate(resource);

            Assert.AreEqual("EmailTemplate", it.ObjectType);
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
            var it = new EmailTemplate(resource);

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
        public void It_can_get_and_set_EmailBody()
        {
            // Act
            _it.EmailBody = "A string";

            // Assert
            Assert.AreEqual("A string", _it.EmailBody);
        }


        [TestMethod]
        public void It_can_get_and_set_EmailSubject()
        {
            // Act
            _it.EmailSubject = "A string";

            // Assert
            Assert.AreEqual("A string", _it.EmailSubject);
        }


        [TestMethod]
        public void It_can_get_and_set_EmailTemplateType()
        {
            // Act
            _it.EmailTemplateType = "A string";

            // Assert
            Assert.AreEqual("A string", _it.EmailTemplateType);
        }


    }
}
