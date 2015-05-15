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

    }
}
