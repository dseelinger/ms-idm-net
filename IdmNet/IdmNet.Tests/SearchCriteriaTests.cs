using System.Collections.Generic;
using IdmNet.SoapModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IdmNet.Tests
{
    [TestClass]
    public class SearchCriteriaTests
    {
        [TestMethod]
        public void It_has_a_Selection_that_contains_ObjectID_and_ObjectType_by_default()
        {
            var it = new SearchCriteria();

            Assert.AreEqual("ObjectID", it.Selection[0]);
            Assert.AreEqual("ObjectType", it.Selection[1]);
        }

        [TestMethod]
        public void It_has_a_Selection_that_contains_ObjectID_and_ObjectType_even_if_set_to_null()
        {
            var it = new SearchCriteria { Selection = null };

            Assert.AreEqual("ObjectID", it.Selection[0]);
            Assert.AreEqual("ObjectType", it.Selection[1]);
        }

        [TestMethod]
        public void It_has_a_Selection_that_contains_ObjectID_and_ObjectType_even_if_set_to_empty_list()
        {
            var it = new SearchCriteria { Selection = new List<string>() };

            Assert.AreEqual("ObjectID", it.Selection[0]);
            Assert.AreEqual("ObjectType", it.Selection[1]);
        }

        [TestMethod]
        public void It_has_a_Selection_that_contains_ObjectID_and_ObjectType_even_if_one_of_thos_values_is_missing()
        {
            var it = new SearchCriteria { Selection = new List<string>{ "ObjectID" } };

            Assert.AreEqual("ObjectID", it.Selection[0]);
            Assert.AreEqual("ObjectType", it.Selection[1]);
        }
    }
}
