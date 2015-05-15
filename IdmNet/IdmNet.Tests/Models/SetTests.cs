using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IdmNet.Tests.Models
{
    [TestClass]
    public class SetTests
    {
        [TestMethod]
        public void It_has_a_paremeterless_constructor()
        {
            var it = new Set();

            Assert.AreEqual("Set", it.ObjectType);
        }

        //[TestMethod]
        //public void It_has_a_constructor_that_takes_a_SecurityIdentifierResource_without_a_domain_configuration()
        //{
        //    var securityIdentifier = new SecurityIdentifierResource();
        //    var it = new Set(securityIdentifier);

        //    Assert.AreEqual("Set", it.ObjectType);
        //}

        //[TestMethod]
        //public void It_has_a_constructor_that_takes_a_SecurityIdentifierResource_WITH_a_domain_configuration()
        //{
        //    var domainConfig = new IdmResource { DisplayName = "myDomainConfig" };
        //    var securityIdentifier = new SecurityIdentifierResource { DomainConfiguration = domainConfig };
        //    var it = new Set(securityIdentifier);

        //    Assert.AreEqual("Set", it.ObjectType);
        //}

        //[TestMethod]
        //public void It_has_a_constructor_that_takes_an_IdmResource()
        //{
        //    var baseClass = new SecurityIdentifierResource
        //    {
        //        DisplayName = "Set DisplayName",
        //        Email = "a@b.com",
        //        Creator = new Person { DisplayName = "Creator Name", ObjectID = "Creator ObjectID" },
        //        DomainConfiguration = new IdmResource { DisplayName = "My Domain Config", ObjectID = "Domain Config ObjectID" }

        //    };
        //    IdmResource idmResource = baseClass;
        //    var it = new Set(idmResource);

        //    Assert.AreEqual("Set", it.ObjectType);
        //    Assert.AreEqual("Set DisplayName", it.DisplayName);
        //    Assert.AreEqual("a@b.com", it.Email);
        //    Assert.AreEqual("Creator Name", it.Creator.DisplayName);
        //    Assert.AreEqual("My Domain Config", it.DomainConfiguration.DisplayName);
        //}

        //[TestMethod]
        //[ExpectedException(typeof(InvalidOperationException))]
        //public void It_throws_when_you_try_to_set_ObjectType_to_anything_other_than_Person()
        //{
        //    new Set { ObjectType = "foo" };
        //}

        //[TestMethod]
        //public void It_returns_null_for_not_present_properties()
        //{
        //    var it = new Set();

        //    Assert.IsNull(it.ComputedMember);
        //    Assert.IsNull(it.DisplayedOwner);
        //    Assert.IsNull(it.ExplicitMember);
        //    Assert.IsNull(it.Filter);
        //    Assert.IsNull(it.MembershipAddWorkflow);
        //    Assert.IsNull(it.MembershipLocked);
        //    Assert.IsNull(it.Owner);
        //    Assert.IsNull(it.Scope);
        //    Assert.IsNull(it.Temporal);
        //    Assert.IsNull(it.msidmDeferredEvaluation);
        //}

        //[TestMethod]
        //public void It_can_set_and_get_bool_properties()
        //{
        //    var it = new Set
        //    {
        //        MembershipLocked = true,
        //        Temporal = true,
        //        msidmDeferredEvaluation = true
        //    };

        //    Assert.AreEqual(true, it.MembershipLocked);
        //    Assert.AreEqual(true, it.Temporal);
        //    Assert.AreEqual(true, it.msidmDeferredEvaluation);
        //}

        //[TestMethod]
        //public void It_can_set_and_get_string_properties()
        //{
        //    var it = new Set
        //    {
        //        Filter = "Test Filter",
        //        MembershipAddWorkflow = "Test MembershipAddWorkflow",
        //        Scope = "Universal",
        //    };

        //    Assert.AreEqual("Test Filter", it.Filter);
        //    Assert.AreEqual("Test MembershipAddWorkflow", it.MembershipAddWorkflow);
        //    Assert.AreEqual("Universal", it.Scope);
        //}

        //[TestMethod]
        //public void It_can_set_and_get_Owner()
        //{
        //    var it = new Set
        //    {
        //        Owner =
        //            new List<Person>
        //            {
        //                new Person
        //                {
        //                    DisplayName = "Person1",
        //                    ObjectID = "Person1",
        //                    Assistant = new Person {DisplayName = "Assistant1", ObjectID = "Assistant1"}
        //                },
        //                new Person
        //                {
        //                    DisplayName = "Person2",
        //                    ObjectID = "Person2",
        //                    Assistant = new Person {DisplayName = "Assistant2", ObjectID = "Assistant2"}
        //                },
        //            }
        //    };

        //    Assert.AreEqual("Assistant1", it.Owner[0].Assistant.DisplayName);
        //    Assert.AreEqual("Assistant2", it.Owner[1].Assistant.DisplayName);
        //}

        //[TestMethod]
        //public void It_can_set_and_get_ComputedMember()
        //{
        //    var it = new Set
        //    {
        //        ComputedMember =
        //            new List<SecurityIdentifierResource>
        //            {
        //                new Person
        //                {
        //                    DisplayName = "Person1",
        //                    ObjectID = "Person1",
        //                    Assistant = new Person {DisplayName = "Assistant1", ObjectID = "Assistant1"}
        //                },
        //                new Person
        //                {
        //                    DisplayName = "Person2",
        //                    ObjectID = "Person2",
        //                    Assistant = new Person {DisplayName = "Assistant2", ObjectID = "Assistant2"}
        //                },
        //            }
        //    };

        //    Assert.AreEqual("Assistant1", ((Person)(it.ComputedMember[0])).Assistant.DisplayName);
        //    Assert.AreEqual("Assistant2", ((Person)(it.ComputedMember[1])).Assistant.DisplayName);
        //}

        //[TestMethod]
        //public void It_can_set_and_get_ExplicitMember()
        //{
        //    var it = new Set
        //    {
        //        ExplicitMember =
        //            new List<SecurityIdentifierResource>
        //            {
        //                new Person
        //                {
        //                    DisplayName = "Person1",
        //                    ObjectID = "Person1",
        //                    Assistant = new Person {DisplayName = "Assistant1", ObjectID = "Assistant1"}
        //                },
        //                new Person
        //                {
        //                    DisplayName = "Person2",
        //                    ObjectID = "Person2",
        //                    Assistant = new Person {DisplayName = "Assistant2", ObjectID = "Assistant2"}
        //                },
        //            }
        //    };

        //    Assert.AreEqual("Assistant1", ((Person)(it.ExplicitMember[0])).Assistant.DisplayName);
        //    Assert.AreEqual("Assistant2", ((Person)(it.ExplicitMember[1])).Assistant.DisplayName);
        //}

        //[TestMethod]
        //public void It_can_set_and_get_DisplayedOwner()
        //{
        //    var it = new Set
        //    {
        //        DisplayedOwner =
        //            new Person
        //            {
        //                DisplayName = "Person1",
        //                ObjectID = "Person1",
        //                Assistant = new Person { DisplayName = "Assistant1", ObjectID = "Assistant1" }
        //            },
        //    };

        //    Assert.AreEqual("Assistant1", it.DisplayedOwner.Assistant.DisplayName);
        //}


        //[TestMethod]
        //public void
        //    It_can_set_complex_properties_to_null()
        //{
        //    // Arrange
        //    var it = new Set
        //    {
        //        DisplayedOwner = new Person { DisplayName = "foo" },
        //        Owner = new List<Person>
        //        {
        //            new Person { DisplayName = "person1", ObjectID = "person1"},
        //            new Person { DisplayName = "person2", ObjectID = "person2" },
        //        },
        //        ComputedMember = new List<SecurityIdentifierResource>
        //        {
        //            new Person { DisplayName = "person3", ObjectID = "person3"},
        //            new Person { DisplayName = "person4", ObjectID = "person4" },
        //        },
        //        ExplicitMember = new List<SecurityIdentifierResource>
        //        {
        //            new Person { DisplayName = "person5", ObjectID = "person5"},
        //            new Person { DisplayName = "person6", ObjectID = "person6" },
        //        }
        //    };

        //    // Act
        //    it.DisplayedOwner = null;
        //    it.Owner = null;
        //    it.ComputedMember = null;
        //    it.ExplicitMember = null;

        //    // Assert
        //    Assert.IsNull(it.DisplayedOwner);
        //    Assert.IsNull(it.Owner);
        //    Assert.IsNull(it.ComputedMember);
        //    Assert.IsNull(it.ExplicitMember);
        //}
    }
}
