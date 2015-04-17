using System;
using System.Collections.Generic;
using IdmNet.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable UseObjectOrCollectionInitializer

namespace IdmNet.Tests.Models
{
    [TestClass]
    public class SecurityIdentifierResourceTests
    {
        [TestMethod]
        public void It_should_return_null_for_empty_properties()
        {
            var it = new SecurityIdentifierResource();

            Assert.IsNull(it.AccountName);
            Assert.IsNull(it.Domain);
            Assert.IsNull(it.DomainConfiguration);
            Assert.IsNull(it.Email);
            Assert.IsNull(it.MailNickname);
            Assert.IsNull(it.ObjectSID);
            Assert.IsNull(it.SIDHistory);
        }

        [TestMethod]
        public void It_should_be_able_to_set_string_based_single_value_properties()
        {
            var it = new SecurityIdentifierResource();

            it.AccountName = "foo";
            Assert.AreEqual("foo", it.AccountName);

            it.Domain = "foo";
            Assert.AreEqual("foo", it.Domain);

            it.Email = "foo";
            Assert.AreEqual("foo", it.Email);

            it.MailNickname = "foo";
            Assert.AreEqual("foo", it.MailNickname);

            it.ObjectSID = "foo";
            Assert.AreEqual("foo", it.ObjectSID);

        }

        [TestMethod]
        public void It_should_be_able_to_set_and_get_DomainConfiguration()
        {
            const string expectedValue = "Domain Config Description";
            var domainConfig = new IdmResource
            {
                CreatedTime = DateTime.Now,
                Description = "Domain Config Description",
                DisplayName = "Domain Config DisplayName",
                ExpirationTime = DateTime.Now + TimeSpan.FromDays(1),
                MVObjectID = Guid.NewGuid().ToString("D"),
                ObjectID = Guid.NewGuid().ToString("D"),
                ObjectType = "DomainConfiguration",
                ResourceTime = DateTime.Now
            };

            var it = new SecurityIdentifierResource();

            it.DomainConfiguration = domainConfig;

            Assert.AreEqual(expectedValue, it.DomainConfiguration.Description);
        }


        [TestMethod]
        public void It_should_be_able_to_set_and_get_SIDHistory()
        {
            var expectedValues = new List<string> { "value1", "value2" };

            var it = new SecurityIdentifierResource();

            it.SIDHistory = expectedValues;

            Assert.AreEqual("value1", it.SIDHistory[0]);
            Assert.AreEqual("value2", it.SIDHistory[1]);
        }

        [TestMethod]
        public void It_should_be_able_construct_itself_from_an_IdmResource()
        {
            // Arrange
            const string description = "SecurityIdentifierResource starting out as an IdmResource";
            const string displayName = "SIR Resource";
            const string objectType = "SecurityIdentifierResource";
            const string accountname = "Test AccountName";
            const string domain = "Test Domain";
            const string email = "Test Email";
            const string mailnickname = "Test MailNickname";
            const string objectsid = "Test ObjectSID";
            var domainCOnfig = Guid.NewGuid().ToString("D");
            var now = DateTime.Now;
            var createdTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);
            var expirationTime = createdTime + TimeSpan.FromDays(1);
            var resourceTime = createdTime + TimeSpan.FromHours(1);
            var mvObjectID = Guid.NewGuid().ToString("D");
            var objectID = Guid.NewGuid().ToString("D");
            var resource = new IdmResource()
            {
                CreatedTime = createdTime,
                Description = description,
                DisplayName = displayName,
                ExpirationTime = expirationTime,
                MVObjectID = mvObjectID,
                ObjectID = objectID,
                ObjectType = objectType,
                ResourceTime = resourceTime
            };
            resource.SetAttrValue("AccountName", accountname);
            resource.SetAttrValue("Domain", domain);
            resource.SetAttrValue("Email", email);
            resource.SetAttrValue("MailNickname", mailnickname);
            resource.SetAttrValue("ObjectSID", objectsid);
            resource.SetAttrValues("SIDHistory", new List<string> { "Test SIDHistory1", "Test SIDHistory2", "Test SIDHistory3" });
            resource.SetAttrValue("DomainConfiguration", domainCOnfig);

            var creator = new Person
            {
                CreatedTime = DateTime.Now,
                Description = "Test creator",
                DisplayName = "Joe User",
                ExpirationTime = DateTime.Now + TimeSpan.FromDays(1),
                MVObjectID = Guid.NewGuid().ToString("D"),
                ObjectID = Guid.NewGuid().ToString("D"),
                ObjectType = "Person",
                ResourceTime = DateTime.Now
            };
            resource.Creator = creator;


            // Act
            var it = new SecurityIdentifierResource(resource);


            // Assert
            Assert.AreEqual(createdTime, it.CreatedTime);
            Assert.AreEqual(description, it.Description);
            Assert.AreEqual(displayName, it.DisplayName);
            Assert.AreEqual(expirationTime, it.ExpirationTime);
            Assert.AreEqual(mvObjectID, it.MVObjectID);
            Assert.AreEqual(objectID, it.ObjectID);
            Assert.AreEqual(objectType, it.ObjectType);
            Assert.AreEqual(resourceTime, it.ResourceTime);
            Assert.AreEqual(accountname, it.AccountName);
            Assert.AreEqual(domain, it.Domain);
            Assert.AreEqual(email, it.Email);
            Assert.AreEqual(mailnickname, it.MailNickname);
            Assert.AreEqual(objectsid, it.ObjectSID);
            Assert.AreEqual("Test SIDHistory1", it.SIDHistory[0]);
            Assert.AreEqual("Test SIDHistory2", it.SIDHistory[1]);
            Assert.AreEqual("Test SIDHistory3", it.SIDHistory[2]);
            Assert.AreEqual(creator, it.Creator);
        }

        [TestMethod]
        public void It_should_be_able_construct_itself_from_an_IdmResource_without_a_creator()
        {
            // Arrange
            var resource = new IdmResource();
            var creator = new Person
            {
                CreatedTime = DateTime.Now,
                Description = "Test creator",
                DisplayName = "Joe User",
                ExpirationTime = DateTime.Now + TimeSpan.FromDays(1),
                MVObjectID = Guid.NewGuid().ToString("D"),
                ObjectID = Guid.NewGuid().ToString("D"),
                ObjectType = "Person",
                ResourceTime = DateTime.Now
            };
            resource.Creator = creator;


            // Act
            var it = new SecurityIdentifierResource(resource);


            // Assert
            Assert.AreEqual(creator, it.Creator);
        }

        [TestMethod]
        public void It_may_be_without_a_creator()
        {
            // Arrange
            var resource = new IdmResource();


            // Act
            var it = new SecurityIdentifierResource(resource);


            // Assert
            Assert.IsNull(it.Creator);
        }
    }
}
