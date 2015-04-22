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
            var it = new AttributeTypeDescription(TestUtils.BuildAttrInfoAsIdmResource());

            TestUtils.AssertAttrInfoOk(it);
        }

        [TestMethod]
        public void It_can_set_and_get_attribute_properties()
        {
            var it = new AttributeTypeDescription
            {
                Multivalued = true,
                DataType = "Test DataType"
            };

            Assert.AreEqual(true, it.Multivalued);
            Assert.AreEqual("Test DataType", it.DataType);
        }

        [TestMethod]
        public void It_returns_default_for_not_present_properties()
        {
            var it = new AttributeTypeDescription();

            Assert.IsNull(it.DataType);
            Assert.IsFalse(it.Multivalued);
        }

    }
}
