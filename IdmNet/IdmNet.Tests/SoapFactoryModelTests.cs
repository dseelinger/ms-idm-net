using System;
using System.Xml;
using IdmNet.SoapModels;
using Xunit;

namespace IdmNet.Tests
{
    public class SoapFactoryModelsTests
    {
        [Fact]
        public void It_has_an_AddRequest_model()
        {
            var it = new AddRequest();

            Assert.Equal(SoapConstants.IdentityAttributeTypeDialect, it.Dialect);
        }

        [Fact]
        public void It_has_an_AttributeTypeAndValue_model_with_a_default_ctor_that_doesnt_do_anything()
        {
            var it = new AttributeTypeAndValue();

            Assert.Null(it.AttributeName);
            Assert.Null(it.AttributeValue);
        }

        [Fact]
        public void It_has_an_AttributeTypeAndValue_model_with_a_ctor_that_allows_you_to_set_the_AttributeName_and_AttributeValue()
        {
            var it = new AttributeTypeAndValue("attrName", "attrValue");

            Assert.Equal("attrName", it.AttributeName);
            Assert.IsType<XmlElement>(it.AttributeValue);

            var element = (XmlElement)it.AttributeValue;

            Assert.Equal("attrValue", element.InnerText);
        }

        // TODO 001: Continue Here
        //[Fact]
        //[ExpectedException(typeof(ArgumentException))]
        //public void It_throws_when_AttributeTypeAndValue_ctor_is_passed_null_AttributeName()
        //{
        //    new AttributeTypeAndValue(null, "attrValue");
        //}

        //[Fact]
        //[ExpectedException(typeof(ArgumentException))]
        //public void It_throws_when_AttributeTypeAndValue_ctor_is_passed_an_empty_string_for_AttributeName()
        //{
        //    new AttributeTypeAndValue("", "attrValue");
        //}

        //[Fact]
        //[ExpectedException(typeof(ArgumentException))]
        //public void It_throws_when_AttributeTypeAndValue_ctor_is_passed_whitespace_AttributeName()
        //{
        //    new AttributeTypeAndValue(" \t", "attrValue");
        //}

        //[Fact]
        //[ExpectedException(typeof(ArgumentException))]
        //public void It_throws_when_AttributeTypeAndValue_ctor_is_passed_AttributeName_containing_whitespace()
        //{
        //    new AttributeTypeAndValue("foo bar", "attrValue");
        //}

        //[Fact]
        //[ExpectedException(typeof(ArgumentException))]
        //public void It_throws_when_AttributeTypeAndValue_ctor_is_passed_AttributeName_that_doesnt_start_with_letter()
        //{
        //    new AttributeTypeAndValue("123Foo", "attrValue");
        //}

        //[Fact]
        //public void It_has_an_AttributeTypeAndValue_model_with_a_ctor_that_allows_you_to_set_AttributeValue_to_null_to_signify_removing_an_attributeValue()
        //{
        //    var it = new AttributeTypeAndValue("attrName", null);

        //    Assert.Equal("attrName", it.AttributeName);
        //    Assert.InstanceOfType(it.AttributeValue, typeof(XmlElement));

        //    var element = (XmlElement)it.AttributeValue;

        //    Assert.Equal("", element.InnerText);
        //}

        //[Fact]
        //public void It_has_a_ResourceCreated_model_with_a_default_ctor_that_does_nothing()
        //{
        //    var it = new ResourceCreated();

        //    Assert.Null(it.EndpointReference);
        //}

        //[Fact]
        //public void It_has_a_EndpointReference_model_with_a_default_ctor_that_does_nothing()
        //{
        //    var it = new EndpointReference();

        //    Assert.Null(it.Address);
        //    Assert.Null(it.ReferenceProperties);
        //}


    }
}
