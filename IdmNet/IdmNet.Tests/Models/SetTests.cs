using System;
using System.Collections.Generic;
using IdmNet.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable ObjectCreationAsStatement
// ReSharper disable UseObjectOrCollectionInitializer

namespace IdmNet.Models.Tests
{
    [TestClass]
    public class SetTests
    {
        private Set _it;

        public SetTests()
        {
            _it = new Set();
        }

        [TestMethod]
        public void It_has_a_paremeterless_constructor()
        {
            Assert.AreEqual("Set", _it.ObjectType);
        }

        [TestMethod]
        public void It_has_a_constructor_that_takes_an_IdmResource()
        {
            var resource = new IdmResource
            {
                DisplayName = "My Display Name",
                Creator = new Person { DisplayName = "Creator Display Name", ObjectID = "Creator ObjectID"},
            };
            var it = new Set(resource);

            Assert.AreEqual("Set", it.ObjectType);
            Assert.AreEqual("My Display Name", it.DisplayName);
            Assert.AreEqual("Creator Display Name", it.Creator.DisplayName);
        }

        [TestMethod]
        public void It_has_a_constructor_that_takes_an_IdmResource_without_Creator()
        {
            var resource = new IdmResource
            {
                DisplayName = "My Display Name",
            };
            var it = new Set(resource);

            Assert.AreEqual("My Display Name", it.DisplayName);
            Assert.IsNull(it.Creator);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void It_throws_when_you_try_to_set_ObjectType_to_anything_other_than_its_primary_ObjectType()
        {
            _it.ObjectType = "Invalid Object Type";
        }

        [TestMethod]
        public void It_has_ComputedMember_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.ComputedMember);
        }

        [TestMethod]
        public void It_has_ComputedMember_which_can_be_set_back_to_null()
        {
            // Arrange
            var list = new List<IdmResource>
            {
                new IdmResource { DisplayName = "Test IdmResource1", ObjectID = "guid1" },
                new IdmResource { DisplayName = "Test IdmResource2", ObjectID = "guid2" }
            };
            _it.ComputedMember = list;

            // Act
            _it.ComputedMember = null;

            // Assert
            Assert.IsNull(_it.ComputedMember);
        }

        [TestMethod]
        public void It_can_get_and_set_ComputedMember()
        {
            // Arrange
            var list = new List<IdmResource>
            {
                new IdmResource { DisplayName = "Test IdmResource1", ObjectID = "guid1" },
                new IdmResource { DisplayName = "Test IdmResource2", ObjectID = "guid2" }
            };

            // Act
            _it.ComputedMember = list;

            // Assert
            Assert.AreEqual(list[0].DisplayName, _it.ComputedMember[0].DisplayName);
            Assert.AreEqual(list[1].DisplayName, _it.ComputedMember[1].DisplayName);
        }


        [TestMethod]
        public void It_can_get_and_set_Filter()
        {
            // Act
            _it.Filter = "A string";

            // Assert
            Assert.AreEqual("A string", _it.Filter);
        }


        [TestMethod]
        public void It_has_ExplicitMember_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.ExplicitMember);
        }

        [TestMethod]
        public void It_has_ExplicitMember_which_can_be_set_back_to_null()
        {
            // Arrange
            var list = new List<IdmResource>
            {
                new IdmResource { DisplayName = "Test IdmResource1", ObjectID = "guid1" },
                new IdmResource { DisplayName = "Test IdmResource2", ObjectID = "guid2" }
            };
            _it.ExplicitMember = list;

            // Act
            _it.ExplicitMember = null;

            // Assert
            Assert.IsNull(_it.ExplicitMember);
        }

        [TestMethod]
        public void It_can_get_and_set_ExplicitMember()
        {
            // Arrange
            var list = new List<IdmResource>
            {
                new IdmResource { DisplayName = "Test IdmResource1", ObjectID = "guid1" },
                new IdmResource { DisplayName = "Test IdmResource2", ObjectID = "guid2" }
            };

            // Act
            _it.ExplicitMember = list;

            // Assert
            Assert.AreEqual(list[0].DisplayName, _it.ExplicitMember[0].DisplayName);
            Assert.AreEqual(list[1].DisplayName, _it.ExplicitMember[1].DisplayName);
        }


        [TestMethod]
        public void It_has_Temporal_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.Temporal);
        }

        [TestMethod]
        public void It_has_Temporal_which_can_be_set_back_to_null()
        {
            // Arrange
            _it.Temporal = true;

            // Act
            _it.Temporal = null;

            // Assert
            Assert.IsNull(_it.Temporal);
        }

        [TestMethod]
        public void It_can_get_and_set_Temporal()
        {
            // Act
            _it.Temporal = true;

            // Assert
            Assert.AreEqual(true, _it.Temporal);
        }


    }
}
