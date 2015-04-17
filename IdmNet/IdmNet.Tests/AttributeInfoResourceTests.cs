using System.Collections.Generic;
using IdmNet.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable ObjectCreationAsStatement
// ReSharper disable UseObjectOrCollectionInitializer

namespace IdmNet.Tests
{
    [TestClass]
    public class AttributeInfoResourceTests
    {
        [TestMethod]
        public void It_has_a_paremeterless_constructor()
        {
            var it = new AttributeInfoResource();

            Assert.IsNotNull(it);
        }

        [TestMethod]
        public void It_has_a_constructor_that_takes_the_lowes_possible_base_class()
        {
            var baseClass = new KeywordedResource{ Name = "Test Name"};
            var it = new AttributeInfoResource(baseClass);

            Assert.AreEqual("Test Name", it.Name);
        }

        [TestMethod]
        public void It_has_a_constructor_that_wors_with_an_IdmResource()
        {
            var baseClass = new AttributeInfoResource
            {
                DisplayName = "AttributeInfoResource DisplayName",
                Creator = new Person { DisplayName = "Creator Name", ObjectID = "Creator ObjectID" },
                ObjectID = "Test ObjectID",
                Name = "Test Name",
                UsageKeyword = new List<string> { "Test UsageKeyword1", "Test UsageKeyword2" }
            };
            IdmResource idmResource = baseClass;
            var it = new AttributeInfoResource(idmResource);

            Assert.AreEqual("AttributeInfoResource DisplayName", it.DisplayName);
            Assert.AreEqual("Creator Name", it.Creator.DisplayName);
            Assert.AreEqual("Test ObjectID", it.ObjectID);
            Assert.AreEqual("Test Name", it.Name);
            Assert.AreEqual("Test UsageKeyword1", it.UsageKeyword[0]);
            Assert.AreEqual("Test UsageKeyword2", it.UsageKeyword[1]);
        }

        [TestMethod]
        public void It_returns_null_for_not_present_properties()
        {
            var it = new AttributeInfoResource();

            Assert.IsNull(it.IntegerMaximum);
            Assert.IsNull(it.IntegerMinimum);
            Assert.IsNull(it.Localizable);
            Assert.IsNull(it.StringRegex);
        }

        [TestMethod]
        public void It_can_set_and_get_attribute_properties()
        {
            var it = new AttributeInfoResource
            {
                IntegerMinimum = 1,
                IntegerMaximum = 10,
                Localizable = true,
                StringRegex = "Test StringRegEx"
            };

            Assert.AreEqual(1, it.IntegerMinimum);
            Assert.AreEqual(10, it.IntegerMaximum);
            Assert.AreEqual(true, it.Localizable);
            Assert.AreEqual("Test StringRegEx", it.StringRegex);
        }
    }
}
