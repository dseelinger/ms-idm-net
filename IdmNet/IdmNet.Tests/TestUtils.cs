using System;
using System.Collections.Generic;
using IdmNet.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable InconsistentNaming

namespace IdmNet.Tests
{
    public static class TestUtils
    {
        public static void AssertIdmResourceOk(DateTime createdTime, IdmResource it, string description,
            string displayName, DateTime expirationTime, string mvObjectID, string objectID, string objectType,
            DateTime resourceTime)
        {
            Assert.AreEqual(createdTime, it.CreatedTime);
            Assert.AreEqual(description, it.Description);
            Assert.AreEqual(displayName, it.DisplayName);
            Assert.AreEqual(expirationTime, it.ExpirationTime);
            Assert.AreEqual(mvObjectID, it.MVObjectID);
            Assert.AreEqual(objectID, it.ObjectID);
            Assert.AreEqual(objectType, it.ObjectType);
            Assert.AreEqual(resourceTime, it.ResourceTime);
        }

        public static IdmResource BuildAttrInfoAsIdmResource()
        {
            var baseClass = new AttributeInfoResource
            {
                DisplayName = "AttributeInfoResource DisplayName",
                Creator = new Person { DisplayName = "Creator Name", ObjectID = "Creator ObjectID" },
                ObjectID = "Test ObjectID",
                Name = "Test Name",
                UsageKeyword = new List<string> { "Test UsageKeyword1", "Test UsageKeyword2" },
                IntegerMaximum = 1,
                IntegerMinimum = 10,
                Localizable = true,
                StringRegex = "Test StringRegex"
            };
            IdmResource idmResource = baseClass;
            return idmResource;
        }

        public static void AssertAttrInfoOk(AttributeInfoResource it)
        {
            Assert.AreEqual("AttributeInfoResource DisplayName", it.DisplayName);
            Assert.AreEqual("Creator Name", it.Creator.DisplayName);
            Assert.AreEqual("Test ObjectID", it.ObjectID);
            Assert.AreEqual("Test Name", it.Name);
            Assert.AreEqual("Test UsageKeyword1", it.UsageKeyword[0]);
            Assert.AreEqual("Test UsageKeyword2", it.UsageKeyword[1]);
            Assert.AreEqual(1, it.IntegerMaximum);
            Assert.AreEqual(10, it.IntegerMinimum);
            Assert.AreEqual(true, it.Localizable);
            Assert.AreEqual("Test StringRegex", it.StringRegex);
        }
    }
}
