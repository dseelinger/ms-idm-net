using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable UseObjectOrCollectionInitializer

namespace IdmNet.Tests
{
    [TestClass]
    public class IdmAttributeTests
    {
        [TestMethod]
        public void It_should_return_null_if_no_value_set()
        {
            var it = new IdmAttribute();

            Assert.IsNull(it.Value);
        }

        [TestMethod]
        public void It_should_return_just_the_value_if_value_set()
        {
            var it = new IdmAttribute { Values = new List<string> { "foo" } };

            Assert.AreEqual("foo", it.Value);
        }

        [TestMethod]
        public void It_should_return_the_first_value_if_multiple_values_set()
        {
            var it = new IdmAttribute { Values = new List<string> { "foo", "bar", "bat" } };

            Assert.AreEqual("foo", it.Value);
        }

        [TestMethod]
        public void It_should_set_the_value_if_it_is_empty_to_start()
        {
            var it = new IdmAttribute();

            it.Value = "foo";

            Assert.AreEqual("foo", it.Value);
        }

        [TestMethod]
        public void It_should_set_the_value_if_it_is_not_empty_to_start()
        {
            var it = new IdmAttribute { Values = new List<string> { "bar" } };

            it.Value = "foo";

            Assert.AreEqual("foo", it.Value);
        }

        [TestMethod]
        public void It_should_set_the_value_if_it_is_multiple_values_to_start()
        {
            var it = new IdmAttribute { Values = new List<string> { "bar", "bat" } };

            it.Value = "foo";

            Assert.AreEqual("foo", it.Value);
        }

        [TestMethod]
        public void It_should_replace_all_values_on_setting_Value()
        {
            var it = new IdmAttribute { Values = new List<string> { "bar", "bat" } };

            it.Value = "foo";

            Assert.AreEqual(1, it.Values.Count);
        }

    }
}
