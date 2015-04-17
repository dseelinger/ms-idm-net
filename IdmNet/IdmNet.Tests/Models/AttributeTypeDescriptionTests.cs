using System.Collections.Generic;
using IdmNet.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable ObjectCreationAsStatement
// ReSharper disable UseObjectOrCollectionInitializer


namespace IdmNet.Tests.Models
{
    [TestClass]
    public class AttributeTypeDescriptionTests
    {
        [TestMethod]
        public void It_has_a_paremeterless_constructor()
        {
            var it = new AttributeTypeDescription();

            Assert.IsNotNull(it);
        }

        [TestMethod]
        public void It_has_a_constructor_that_takes_the_lowest_possible_base_class()
        {
            var baseClass = new AttributeTypeDescription
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
            var it = new AttributeTypeDescription(idmResource);

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

        [TestMethod]
        public void It_returns_default_for_not_present_properties()
        {
            var it = new AttributeTypeDescription();

            Assert.IsNull(it.DataType);
            Assert.IsFalse(it.MultiValued);
        }

        [TestMethod]
        public void It_can_set_and_get_attribute_properties()
        {
            var it = new AttributeTypeDescription
            {
                MultiValued = true,
                DataType = "Test DataType"
            };

            Assert.AreEqual(true, it.MultiValued);
            Assert.AreEqual("Test DataType", it.DataType);
        }

    }
}
