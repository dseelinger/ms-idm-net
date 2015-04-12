using System;
using System.ServiceModel.Configuration;
using System.Xml;
using IdmNet.SoapModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable ObjectCreationAsStatement

namespace IdmNet.Tests
{
    [TestClass]
    public class SoapFactoryModelsTests
    {
        [TestMethod]
        public void It_has_an_AddRequest_model()
        {
            var it = new AddRequest();

            Assert.AreEqual(SoapConstants.IdentityAttributeTypeDialect, it.Dialect);
        }

        [TestMethod]
        public void It_has_an_AttributeTypeAndValue_model_with_a_default_ctor_that_doesnt_do_anything()
        {
            var it = new AttributeTypeAndValue();

            Assert.IsNull(it.AttributeName);
            Assert.IsNull(it.AttributeValue);
        }

        [TestMethod]
        public void It_has_an_AttributeTypeAndValue_model_with_a_ctor_that_allows_you_to_set_the_AttributeName_and_AttributeValue()
        {
            var it = new AttributeTypeAndValue("attrName", "attrValue");

            Assert.AreEqual("attrName", it.AttributeName);
            Assert.IsInstanceOfType(it.AttributeValue, typeof(XmlElement));

            var element = (XmlElement)it.AttributeValue;

            Assert.AreEqual("attrValue", element.InnerText);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void It_throws_when_AttributeTypeAndValue_ctor_is_passed_null_AttributeName()
        {
            new AttributeTypeAndValue(null, "attrValue");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void It_throws_when_AttributeTypeAndValue_ctor_is_passed_an_empty_string_for_AttributeName()
        {
            new AttributeTypeAndValue("", "attrValue");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void It_throws_when_AttributeTypeAndValue_ctor_is_passed_whitespace_AttributeName()
        {
            new AttributeTypeAndValue(" \t", "attrValue");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void It_throws_when_AttributeTypeAndValue_ctor_is_passed_AttributeName_containing_whitespace()
        {
            new AttributeTypeAndValue("foo bar", "attrValue");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void It_throws_when_AttributeTypeAndValue_ctor_is_passed_AttributeName_that_doesnt_start_with_letter()
        {
            new AttributeTypeAndValue("123Foo", "attrValue");
        }

        [TestMethod]
        public void It_has_an_AttributeTypeAndValue_model_with_a_ctor_that_allows_you_to_set_AttributeValue_to_null_to_signify_removing_an_attributeValue()
        {
            var it = new AttributeTypeAndValue("attrName", null);

            Assert.AreEqual("attrName", it.AttributeName);
            Assert.IsInstanceOfType(it.AttributeValue, typeof(XmlElement));

            var element = (XmlElement)it.AttributeValue;

            Assert.AreEqual("", element.InnerText);
        }

        [TestMethod]
        public void It_has_a_ResourceCreated_model_with_a_default_ctor_that_does_nothing()
        {
            var it = new ResourceCreated();

            Assert.IsNull(it.EndpointReference);
        }

        [TestMethod]
        public void It_has_a_EndpointReference_model_with_a_default_ctor_that_does_nothing()
        {
            var it = new EndpointReference();

            Assert.IsNull(it.Address);
            Assert.IsNull(it.ReferenceProperties);
        }


    }
}
