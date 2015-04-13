using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable UseObjectOrCollectionInitializer
// ReSharper disable PossibleInvalidOperationException

namespace IdmNet.Tests
{
    [TestClass]
    public class IdmResourceTests
    {
        [TestMethod]
        public void It_should_return_null_for_empty_properties()
        {
            var it = new IdmResource();

            Assert.IsNull(it.ObjectID);
            Assert.IsNull(it.ObjectType);
            Assert.IsNull(it.CreatedTime);
            Assert.IsNull(it.Creator);
            Assert.IsNull(it.DeletedTime);
            Assert.IsNull(it.Description);
            Assert.IsNull(it.DisplayName);
            Assert.IsNull(it.ExpirationTime);
            Assert.IsNull(it.MVObjectID);
            Assert.IsNull(it.ResourceTime);
        }

        [TestMethod]
        public void It_should_return_null_for_empty_attributes()
        {
            var it = new IdmResource();

            Assert.IsNull(it.GetAttr("foo"));
            Assert.IsNull(it.GetAttrValue("foo"));
            Assert.IsNull(it.GetAttrValues("foo"));
        }

        [TestMethod]
        public void It_should_be_able_to_set_string_based_single_value_properties()
        {
            var it = new IdmResource();

            it.ObjectID = "foo";
            Assert.AreEqual("foo", it.ObjectID);

            it.ObjectType = "foo";
            Assert.AreEqual("foo", it.ObjectType);

            it.Description = "foo";
            Assert.AreEqual("foo", it.Description);

            it.DisplayName = "foo";
            Assert.AreEqual("foo", it.DisplayName);

            it.MVObjectID = "foo";
            Assert.AreEqual("foo", it.MVObjectID);

            // and attributes
            it.SetAttrValue("foo", "bar");
            Assert.AreEqual("bar", it.GetAttrValue("foo"));
        }

        [TestMethod]
        public void It_should_be_able_to_set_DateTime_based_single_value_properties()
        {
            var now = DateTime.Now;
            var testTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);
            var it = new IdmResource();

            it.CreatedTime = testTime;
            Assert.AreEqual(testTime, it.CreatedTime);

            it.DeletedTime = testTime;
            Assert.AreEqual(testTime, it.DeletedTime);

            it.ExpirationTime = testTime;
            Assert.AreEqual(testTime, it.ExpirationTime);

            it.ResourceTime = testTime;
            Assert.AreEqual(testTime, it.ResourceTime);

        }

        [TestMethod]
        public void It_should_be_able_to_set_Creator()
        {
            var creator = new IdmResource
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

            var it = new IdmResource();

            it.Creator = creator;

            Assert.AreEqual("Test creator", it.Creator.Description);
        }

        [TestMethod]
        public void It_can_GetAttrValues_after_they_have_been_created()
        {
            var it = new IdmResource
            {
                Attributes =
                    new List<IdmAttribute> { new IdmAttribute { Name = "foo", Values = new List<string> { "foo", "bar" } } }
            };

            var result = it.GetAttrValues("foo");

            Assert.AreEqual("foo", result[0]);
            Assert.AreEqual("bar", result[1]);
        }

        [TestMethod]
        public void It_can_SetAttrValue_on_an_attribute_that_already_has_a_value()
        {
            var it = new IdmResource { Description = "foo" };

            it.SetAttrValue("Description", "bar");

            Assert.AreEqual("bar", it.Description);
        }

        [TestMethod]
        public void It_can_SetAttrValues_on_an_attribute_that_already_has_values()
        {
            var it = new IdmResource
            {
                Attributes =
                    new List<IdmAttribute> { new IdmAttribute { Name = "foo", Values = new List<string> { "foo", "bar" } } }
            };

            it.SetAttrValues("foo", new List<string>{"fiz", "buz"});

            var result = it.GetAttrValues("foo");

            Assert.AreEqual("fiz", result[0]);
            Assert.AreEqual("buz", result[1]);
        }

        [TestMethod]
        public void It_can_convert_one_of_its_attributes_to_bool()
        {
            var it = new IdmResource
            {
                Attributes =
                    new List<IdmAttribute> {new IdmAttribute {Name = "foo", Values = new List<string> {"true"}}}
            };

            var result = it.AttributeToBool("foo");

            Assert.IsTrue(result.Value);
        }

        [TestMethod]
        public void
            It_can_GetAttributeAsComplexObject_when_the_attribute_has_a_refId_value_and_the_backing_field_is_null()
        {
            var creatorObjectID = Guid.NewGuid().ToString("D");
            IdmResource subResource = null;

            var it = new IdmResource { Attributes = new List<IdmAttribute> { new IdmAttribute { Name = "Creator", Value = creatorObjectID } } };

            // ReSharper disable once ExpressionIsAlwaysNull
            it.GetAttributeAsComplexObject("Creator", subResource);

            Assert.AreEqual(creatorObjectID, it.Creator.ObjectID);
        }

        [TestMethod]
        public void
            It_can_GetAttributeAsComplexObject_when_the_attribute_has_a_refId_value_and_the_backing_field_ObjetID_differs_from_the_value_in_the_attribute()
        {
            var staleCreatorObjectID = Guid.NewGuid().ToString("D");
            var freshCreatorObjectID = Guid.NewGuid().ToString("D");

            var creator = new IdmResource
            {
                CreatedTime = DateTime.Now,
                Description = "Test creator",
                DisplayName = "Joe User",
                ExpirationTime = DateTime.Now + TimeSpan.FromDays(1),
                MVObjectID = Guid.NewGuid().ToString("D"),
                ObjectID = staleCreatorObjectID,
                ObjectType = "Person",
                ResourceTime = DateTime.Now
            };

            var it = new IdmResource { Attributes = new List<IdmAttribute> { new IdmAttribute { Name = "Creator", Value = freshCreatorObjectID } } };

            it.GetAttributeAsComplexObject("Creator", creator);

            Assert.AreEqual(freshCreatorObjectID, it.Creator.ObjectID);
        }

        [TestMethod]
        public void
            It_can_GetAttributeAsComplexObject_when_the_attribute_has_a_refId_value_and_the_backing_field_ObjetID_matches_the_value_in_the_attribute()
        {
            var freshCreatorObjectID = Guid.NewGuid().ToString("D");

            var creator = new IdmResource
            {
                CreatedTime = DateTime.Now,
                Description = "Test creator",
                DisplayName = "Joe User",
                ExpirationTime = DateTime.Now + TimeSpan.FromDays(1),
                MVObjectID = Guid.NewGuid().ToString("D"),
                ObjectID = freshCreatorObjectID,
                ObjectType = "Person",
                ResourceTime = DateTime.Now
            };

            var it = new IdmResource { Attributes = new List<IdmAttribute> { new IdmAttribute { Name = "Creator", Value = freshCreatorObjectID } } };

            var result = it.GetAttributeAsComplexObject("Creator", creator);

            Assert.AreEqual(freshCreatorObjectID, it.Creator.ObjectID);
            Assert.AreEqual("Joe User", result.DisplayName);
        }

        [TestMethod]
        public void
            It_can_get_Creator_when_the_attribute_has_a_refId_value()
        {
            var creatorObjectID = Guid.NewGuid().ToString("D");

            var it = new IdmResource { Attributes = new List<IdmAttribute> { new IdmAttribute { Name = "Creator", Value = creatorObjectID } } };

            Assert.AreEqual(creatorObjectID, it.Creator.ObjectID);
        }

        [TestMethod]
        public void
            It_can_GetMultiValuedAttrAsComplexObjects_when_the_attribute_has_values_and_matches_backing_field()
        {
            var subObjectID1 = Guid.NewGuid().ToString("D");
            var subObjectID2 = Guid.NewGuid().ToString("D");

            var resources = new List<IdmResource>
            {
                new IdmResource
                {
                    CreatedTime = DateTime.Now,
                    Description = "Test resource",
                    DisplayName = "sub resource 1",
                    ExpirationTime = DateTime.Now + TimeSpan.FromDays(1),
                    MVObjectID = Guid.NewGuid().ToString("D"),
                    ObjectID = subObjectID1,
                    ObjectType = "Resource",
                    ResourceTime = DateTime.Now
                },
                new IdmResource
                {
                    CreatedTime = DateTime.Now,
                    Description = "Test resource",
                    DisplayName = "sub resource 2",
                    ExpirationTime = DateTime.Now + TimeSpan.FromDays(1),
                    MVObjectID = Guid.NewGuid().ToString("D"),
                    ObjectID = subObjectID2,
                    ObjectType = "Resource",
                    ResourceTime = DateTime.Now
                }

            };

            var it = new IdmResource
            {
                Attributes =
                    new List<IdmAttribute> { new IdmAttribute { Name = "MultiValuedReferenceIDs", Values = new List<string> { subObjectID1, subObjectID2 } } }
            };

            var result = it.GetMultiValuedAttrAsComplexObjects("MultiValuedReferenceIDs", resources);

            Assert.AreEqual("sub resource 1", result[0].DisplayName);
            Assert.AreEqual("sub resource 2", result[1].DisplayName);
        }

        [TestMethod]
        public void
            It_can_GetMultiValuedAttrAsComplexObjects_when_only_some_of_the_items_are_in_the_backing_field()
        {
            var subObjectID1 = Guid.NewGuid().ToString("D");
            var subObjectID2 = Guid.NewGuid().ToString("D");
            var subObjectID3 = Guid.NewGuid().ToString("D");

            var resources = new List<IdmResource>
            {
                new IdmResource
                {
                    CreatedTime = DateTime.Now,
                    Description = "Test resource",
                    DisplayName = "sub resource 1",
                    ExpirationTime = DateTime.Now + TimeSpan.FromDays(1),
                    MVObjectID = Guid.NewGuid().ToString("D"),
                    ObjectID = subObjectID1,
                    ObjectType = "Resource",
                    ResourceTime = DateTime.Now
                },
                new IdmResource
                {
                    CreatedTime = DateTime.Now,
                    Description = "Test resource",
                    DisplayName = "sub resource 2",
                    ExpirationTime = DateTime.Now + TimeSpan.FromDays(1),
                    MVObjectID = Guid.NewGuid().ToString("D"),
                    ObjectID = subObjectID2,
                    ObjectType = "Resource",
                    ResourceTime = DateTime.Now
                }

            };

            var it = new IdmResource
            {
                Attributes =
                    new List<IdmAttribute> { new IdmAttribute { Name = "MultiValuedReferenceIDs", Values = new List<string> { subObjectID1, subObjectID2, subObjectID3 } } }
            };

            var result = it.GetMultiValuedAttrAsComplexObjects("MultiValuedReferenceIDs", resources);

            Assert.AreEqual("sub resource 1", result[0].DisplayName);
            Assert.AreEqual("sub resource 2", result[1].DisplayName);
            Assert.AreEqual(subObjectID3, result[2].ObjectID);
        }

        [TestMethod]
        public void
            It_can_GetMultiValuedAttrAsComplexObjects_when_the_backing_field_is_null()
        {
            var subObjectID1 = Guid.NewGuid().ToString("D");
            var subObjectID2 = Guid.NewGuid().ToString("D");
            var subObjectID3 = Guid.NewGuid().ToString("D");

            List<IdmResource> resources = null;

            var it = new IdmResource
            {
                Attributes =
                    new List<IdmAttribute> { new IdmAttribute { Name = "MultiValuedReferenceIDs", Values = new List<string> { subObjectID1, subObjectID2, subObjectID3 } } }
            };

            // ReSharper disable once ExpressionIsAlwaysNull
            var result = it.GetMultiValuedAttrAsComplexObjects("MultiValuedReferenceIDs", resources);

            Assert.AreEqual(subObjectID1, result[0].ObjectID);
            Assert.AreEqual(subObjectID2, result[1].ObjectID);
            Assert.AreEqual(subObjectID3, result[2].ObjectID);
        }


        [TestMethod]
        public void
            It_can_SetMultiValuedAttrAsComplexObjects_when_only_some_of_the_items_are_in_the_backing_field()
        {
            var subObjectID1 = Guid.NewGuid().ToString("D");
            var subObjectID2 = Guid.NewGuid().ToString("D");

            List<IdmResource> backingField;
            var resources = new List<IdmResource>
            {
                new IdmResource
                {
                    CreatedTime = DateTime.Now,
                    Description = "Test resource",
                    DisplayName = "sub resource 1",
                    ExpirationTime = DateTime.Now + TimeSpan.FromDays(1),
                    MVObjectID = Guid.NewGuid().ToString("D"),
                    ObjectID = subObjectID1,
                    ObjectType = "Resource",
                    ResourceTime = DateTime.Now
                },
                new IdmResource
                {
                    CreatedTime = DateTime.Now,
                    Description = "Test resource",
                    DisplayName = "sub resource 2",
                    ExpirationTime = DateTime.Now + TimeSpan.FromDays(1),
                    MVObjectID = Guid.NewGuid().ToString("D"),
                    ObjectID = subObjectID2,
                    ObjectType = "Resource",
                    ResourceTime = DateTime.Now
                }

            };

            var it = new IdmResource();

            it.SetMultiValuedAttrAsComplexObjects("MultiValuedReferenceIDs", out backingField, resources);

            Assert.AreEqual("sub resource 1", backingField[0].DisplayName);
            Assert.AreEqual("sub resource 2", backingField[1].DisplayName);
        }


        [TestMethod]
        public void It_can_GettAttr_that_then_allows_modification_of_the_attr()
        {
            var it = new IdmResource
            {
                Attributes =
                    new List<IdmAttribute> { new IdmAttribute { Name = "foo", Values = new List<string> { "foo", "bar" } } }
            };

            var attr = it.GetAttr("foo");

            attr.Values.Add("bat");

            var result = it.GetAttrValues("foo");

            Assert.AreEqual("foo", result[0]);
            Assert.AreEqual("bar", result[1]);
            Assert.AreEqual("bat", result[2]);
        }

        [TestMethod]
        public void It_can_retrieve_attributes_with_an_indexer()
        {
            var it = new IdmResource
            {
                Attributes =
                    new List<IdmAttribute>
                    {
                        new IdmAttribute { Name = "foo1", Values = new List<string> { "foo1", "bar1" } },
                        new IdmAttribute { Name = "foo2", Values = new List<string> { "foo2", "bar2" } },
                        new IdmAttribute { Name = "foo3", Values = new List<string> { "foo3", "bar3" } },
                        new IdmAttribute { Name = "foo4", Values = new List<string> { "foo4", "bar4" } },
                        new IdmAttribute { Name = "foo5", Values = new List<string> { "foo5", "bar5" } }
                    }
            };

            var result = it["foo1"];

            Assert.AreEqual("foo1", result.Values[0]);
            Assert.AreEqual("bar1", result.Values[1]);
        }

    }
}
