using System.Collections.Generic;
using IdmNet.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable ObjectCreationAsStatement
// ReSharper disable UseObjectOrCollectionInitializer

namespace IdmNet.Tests.Models
{
    [TestClass]
    public class BindingDescriptionTests
    {
        [TestMethod]
        public void It_has_a_paremeterless_constructor()
        {
            var it = new BindingDescription();

            Assert.IsNotNull(it);
        }

        [TestMethod]
        public void It_has_a_constructor_that_takes_the_lowest_possible_base_class()
        {
            var it = new BindingDescription(TestUtils.BuildAttrInfoAsIdmResource());

            TestUtils.AssertAttrInfoOk(it);
        }

        [TestMethod]
        public void It_returns_default_for_not_present_properties()
        {
            var it = new BindingDescription();

            Assert.IsNull(it.Required);
            Assert.IsNull(it.BoundAttributeType);
            Assert.IsNull(it.BoundObjectType);
        }

        [TestMethod]
        public void It_can_set_and_get_attribute_properties()
        {
            var it = new BindingDescription
            {
                Required = true,
                BoundAttributeType = new AttributeTypeDescription { DisplayName = "Test AttributeTypeDescription" },
                BoundObjectType = new ObjectTypeDescription { DisplayName = "Test BoundObjectType" }
            };

            Assert.AreEqual(true, it.Required);
            Assert.AreEqual("Test AttributeTypeDescription", it.BoundAttributeType.DisplayName);
            Assert.AreEqual("Test BoundObjectType", it.BoundObjectType.DisplayName);
        }

        [TestMethod]
        public void
            It_can_set_complex_properties_to_null()
        {
            // Arrange
            var it = new BindingDescription
            {
                BoundAttributeType = new AttributeTypeDescription { DisplayName = "foo" },
                BoundObjectType = new ObjectTypeDescription() { DisplayName = "bar" },
            };

            // Act
            it.BoundAttributeType = null;
            it.BoundObjectType = null;

            // Assert
            Assert.IsNull(it.BoundAttributeType);
        }
    }
}
