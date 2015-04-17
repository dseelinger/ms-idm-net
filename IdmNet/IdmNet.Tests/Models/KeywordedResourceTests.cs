using System;
using System.Collections.Generic;
using IdmNet.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable InconsistentNaming

namespace IdmNet.Tests.Models
{
    [TestClass]
    public class KeywordedResourceTests
    {
        [TestMethod]
        public void It_should_return_null_for_empty_properties()
        {
            var it = new KeywordedResource();

            Assert.IsNull(it.Name);
            Assert.IsNull(it.UsageKeyword);
        }


        [TestMethod]
        public void It_can_get_and_set_Name()
        {
            var it = new KeywordedResource {Name = "foo"};

            Assert.AreEqual("foo", it.Name);
        }

        [TestMethod]
        public void It_can_set_and_get_ProxyAddressCollection()
        {
            var subObject1 = "foo1";
            var subObject2 = "foo2";
            var list = new List<string> { subObject1, subObject2 };

            var it = new KeywordedResource
            {
                UsageKeyword = list
            };

            Assert.AreEqual("foo1", it.UsageKeyword[0]);
            Assert.AreEqual("foo2", it.UsageKeyword[1]);
        }

        [TestMethod]
        public void It_should_be_able_construct_itself_from_an_IdmResource()
        {
            // Arrange
            const string description = "KeywordedResource starting out as an IdmResource";
            const string displayName = "SIR Resource";
            const string objectType = "KeywordedResource";
            var now = DateTime.Now;
            var createdTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);
            var expirationTime = createdTime + TimeSpan.FromDays(1);
            var resourceTime = createdTime + TimeSpan.FromHours(1);
            var mvObjectID = Guid.NewGuid().ToString("D");
            var objectID = Guid.NewGuid().ToString("D");
            var name = "Test Name";
            var usageKeywords = new List<string> { "Test UsageKeyword1", "Test UsageKeyword2" };
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
            resource.SetAttrValue("Name", name);
            resource.SetAttrValues("UsageKeyword", usageKeywords);

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
            var it = new KeywordedResource(resource);


            // Assert
            Assert.AreEqual(createdTime, it.CreatedTime);
            Assert.AreEqual(description, it.Description);
            Assert.AreEqual(displayName, it.DisplayName);
            Assert.AreEqual(expirationTime, it.ExpirationTime);
            Assert.AreEqual(mvObjectID, it.MVObjectID);
            Assert.AreEqual(objectID, it.ObjectID);
            Assert.AreEqual(objectType, it.ObjectType);
            Assert.AreEqual(resourceTime, it.ResourceTime);
            Assert.AreEqual(name, it.Name);
            Assert.AreEqual(creator, it.Creator);
            Assert.AreEqual(usageKeywords[0], it.UsageKeyword[0]);
            Assert.AreEqual(usageKeywords[1], it.UsageKeyword[1]);
        }

        [TestMethod]
        public void It_should_be_able_construct_itself_from_an_IdmResource_without_a_creator()
        {
            // Arrange
            const string description = "KeywordedResource starting out as an IdmResource";
            const string displayName = "SIR Resource";
            const string objectType = "KeywordedResource";
            var now = DateTime.Now;
            var createdTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);
            var expirationTime = createdTime + TimeSpan.FromDays(1);
            var resourceTime = createdTime + TimeSpan.FromHours(1);
            var mvObjectID = Guid.NewGuid().ToString("D");
            var objectID = Guid.NewGuid().ToString("D");
            var name = "Test Name";
            var usageKeywords = new List<string> { "Test UsageKeyword1", "Test UsageKeyword2" };
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
            resource.SetAttrValue("Name", name);
            resource.SetAttrValues("UsageKeyword", usageKeywords);


            // Act
            var it = new KeywordedResource(resource);


            // Assert
            Assert.AreEqual(createdTime, it.CreatedTime);
            Assert.AreEqual(description, it.Description);
            Assert.AreEqual(displayName, it.DisplayName);
            Assert.AreEqual(expirationTime, it.ExpirationTime);
            Assert.AreEqual(mvObjectID, it.MVObjectID);
            Assert.AreEqual(objectID, it.ObjectID);
            Assert.AreEqual(objectType, it.ObjectType);
            Assert.AreEqual(resourceTime, it.ResourceTime);
            Assert.AreEqual(name, it.Name);
            Assert.AreEqual(usageKeywords[0], it.UsageKeyword[0]);
            Assert.AreEqual(usageKeywords[1], it.UsageKeyword[1]);
        }


        [TestMethod]
        public void It_may_be_without_a_creator()
        {
            // Arrange
            var resource = new IdmResource();


            // Act
            var it = new KeywordedResource(resource);


            // Assert
            Assert.IsNull(it.Creator);
        }

        [TestMethod]
        public void It_can_build_itself_from_another_one_just_like_it()
        {
            // Arrange
            var kwResource = new KeywordedResource { Name = "Test Name" };
            var it = new KeywordedResource();

            // Act
            it.CloneFrom(kwResource);


            // Assert
            Assert.AreEqual("Test Name", it.Name);
        }

        [TestMethod]
        public void It_can_build_itself_from_another_one_just_like_it_including_Creator()
        {
            // Arrange
            var creator = new Person{DisplayName = "Test Creator"};
            var kwResource = new KeywordedResource { Name = "Test Name", Creator = creator};
            var it = new KeywordedResource();

            // Act
            it.CloneFrom(kwResource);


            // Assert
            Assert.AreEqual("Test Creator", it.Creator.DisplayName);
        }
    }
}
