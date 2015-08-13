using System;
using System.Collections.Generic;
using IdmNet.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable ObjectCreationAsStatement
// ReSharper disable UseObjectOrCollectionInitializer

namespace IdmNet.Models.Tests
{
    [TestClass]
    public class GroupTests
    {
        private Group _it;

        public GroupTests()
        {
            _it = new Group();
        }

        [TestMethod]
        public void It_has_a_paremeterless_constructor()
        {
            Assert.AreEqual("Group", _it.ObjectType);
        }

        [TestMethod]
        public void It_has_a_constructor_that_takes_an_IdmResource()
        {
            var resource = new IdmResource
            {
                DisplayName = "My Display Name",
                Creator = new Person { DisplayName = "Creator Display Name", ObjectID = "Creator ObjectID"},
            };
            var it = new Group(resource);

            Assert.AreEqual("Group", it.ObjectType);
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
            var it = new Group(resource);

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
        public void It_can_get_and_set_AccountName()
        {
            // Act
            _it.AccountName = "A string";

            // Assert
            Assert.AreEqual("A string", _it.AccountName);
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
        public void It_has_msidmDeferredEvaluation_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.msidmDeferredEvaluation);
        }

        [TestMethod]
        public void It_has_msidmDeferredEvaluation_which_can_be_set_back_to_null()
        {
            // Arrange
            _it.msidmDeferredEvaluation = true;

            // Act
            _it.msidmDeferredEvaluation = null;

            // Assert
            Assert.IsNull(_it.msidmDeferredEvaluation);
        }

        [TestMethod]
        public void It_can_get_and_set_msidmDeferredEvaluation()
        {
            // Act
            _it.msidmDeferredEvaluation = true;

            // Assert
            Assert.AreEqual(true, _it.msidmDeferredEvaluation);
        }


        [TestMethod]
        public void It_has_DisplayedOwner_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.DisplayedOwner);
        }

        [TestMethod]
        public void It_has_DisplayedOwner_which_can_be_set_back_to_null()
        {
            // Arrange
            var testPerson = new Person { DisplayName = "Test Person" };			
            _it.DisplayedOwner = testPerson; 

            // Act
            _it.DisplayedOwner = null;

            // Assert
            Assert.IsNull(_it.DisplayedOwner);
        }

        [TestMethod]
        public void It_can_get_and_set_DisplayedOwner()
        {
            // Act
			var testPerson = new Person { DisplayName = "Test Person" };			
            _it.DisplayedOwner = testPerson; 

            // Assert
            Assert.AreEqual(testPerson.DisplayName, _it.DisplayedOwner.DisplayName);
        }


        [TestMethod]
        public void It_can_get_and_set_Domain()
        {
            // Act
            _it.Domain = "A string";

            // Assert
            Assert.AreEqual("A string", _it.Domain);
        }


        [TestMethod]
        public void It_has_DomainConfiguration_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.DomainConfiguration);
        }

        [TestMethod]
        public void It_has_DomainConfiguration_which_can_be_set_back_to_null()
        {
            // Arrange
            var testDomainConfiguration = new DomainConfiguration { DisplayName = "Test DomainConfiguration" };			
            _it.DomainConfiguration = testDomainConfiguration; 

            // Act
            _it.DomainConfiguration = null;

            // Assert
            Assert.IsNull(_it.DomainConfiguration);
        }

        [TestMethod]
        public void It_can_get_and_set_DomainConfiguration()
        {
            // Act
			var testDomainConfiguration = new DomainConfiguration { DisplayName = "Test DomainConfiguration" };			
            _it.DomainConfiguration = testDomainConfiguration; 

            // Assert
            Assert.AreEqual(testDomainConfiguration.DisplayName, _it.DomainConfiguration.DisplayName);
        }


        [TestMethod]
        public void It_can_get_and_set_Email()
        {
            // Act
            _it.Email = "A string";

            // Assert
            Assert.AreEqual("A string", _it.Email);
        }


        [TestMethod]
        public void It_can_get_and_set_MailNickname()
        {
            // Act
            _it.MailNickname = "A string";

            // Assert
            Assert.AreEqual("A string", _it.MailNickname);
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
        public void It_can_get_and_set_MembershipAddWorkflow()
        {
            // Act
            _it.MembershipAddWorkflow = "A string";

            // Assert
            Assert.AreEqual("A string", _it.MembershipAddWorkflow);
        }


        [TestMethod]
        public void It_can_get_and_set_MembershipLocked()
        {
            // Act
            _it.MembershipLocked = true;

            // Assert
            Assert.AreEqual(true, _it.MembershipLocked);
        }


        [TestMethod]
        public void It_has_Owner_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.Owner);
        }

        [TestMethod]
        public void It_has_Owner_which_can_be_set_back_to_null()
        {
            // Arrange
            var list = new List<Person>
            {
                new Person { DisplayName = "Test Person1", ObjectID = "guid1" },
                new Person { DisplayName = "Test Person2", ObjectID = "guid2" }
            };
            _it.Owner = list;

            // Act
            _it.Owner = null;

            // Assert
            Assert.IsNull(_it.Owner);
        }

        [TestMethod]
        public void It_can_get_and_set_Owner()
        {
            // Arrange
            var list = new List<Person>
            {
                new Person { DisplayName = "Test Person1", ObjectID = "guid1" },
                new Person { DisplayName = "Test Person2", ObjectID = "guid2" }
            };

            // Act
            _it.Owner = list;

            // Assert
            Assert.AreEqual(list[0].DisplayName, _it.Owner[0].DisplayName);
            Assert.AreEqual(list[1].DisplayName, _it.Owner[1].DisplayName);
        }


        [TestMethod]
        public void It_has_ObjectSID_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.ObjectSID);
        }

        [TestMethod]
        public void It_has_ObjectSID_which_can_be_set_back_to_null()
        {
            // Arrange
            var stringReprentation = @"/9j/4AAQSkZJRgABAQEAYABgAAD/2wBDAAoHBwkHBgoJCAkLCwoMDxkQDw4ODx4WFxIZJCAmJSMgIyIoLTkwKCo2KyIjMkQyNjs9QEBAJjBGS0U+Sjk/QD3/2wBDAQsLCw8NDx0QEB09KSMpPT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT3/wAARCAAyADIDASIAAhEBAxEB/8QAHwAAAQUBAQEBAQEAAAAAAAAAAAECAwQFBgcICQoL/8QAtRAAAgEDAwIEAwUFBAQAAAF9AQIDAAQRBRIhMUEGE1FhByJxFDKBkaEII0KxwRVS0fAkM2JyggkKFhcYGRolJicoKSo0NTY3ODk6Q0RFRkdISUpTVFVWV1hZWmNkZWZnaGlqc3R1dnd4eXqDhIWGh4iJipKTlJWWl5iZmqKjpKWmp6ipqrKztLW2t7i5usLDxMXGx8jJytLT1NXW19jZ2uHi4+Tl5ufo6erx8vP09fb3+Pn6/8QAHwEAAwEBAQEBAQEBAQAAAAAAAAECAwQFBgcICQoL/8QAtREAAgECBAQDBAcFBAQAAQJ3AAECAxEEBSExBhJBUQdhcRMiMoEIFEKRobHBCSMzUvAVYnLRChYkNOEl8RcYGRomJygpKjU2Nzg5OkNERUZHSElKU1RVVldYWVpjZGVmZ2hpanN0dXZ3eHl6goOEhYaHiImKkpOUlZaXmJmaoqOkpaanqKmqsrO0tba3uLm6wsPExcbHyMnK0tPU1dbX2Nna4uPk5ebn6Onq8vP09fb3+Pn6/9oADAMBAAIRAxEAPwD2CS6t42KvPGrDqCwBpv221/5+Yf8AvsV494+O3xpfgZGPL7/9M1rnsn1P51i6tnY+pw/DqrUYVPaW5knt3XqfQDXdqf8Al4h/77FcBoHjKPS9dvNOvmAs3uZDFLj/AFZLHr6g+vb6V59uPrRuO7Oec5zUuo2d+H4fp04ThOXMpeVreZ9DowYZBBUjIIPWnV5Z4L8anTymn6m5a0J2xSt/yy9if7v8vpXqKuGAKkFSMgg9a2jJSR8rjsBUwdTknt0fcfRSUVRwni/j/wD5HXUP+2f/AKLWudrovH//ACOuof8AbP8A9FrXO1yS3Z+nYD/dKX+GP5IKKKKk6xQcGu18GeNTpzJp2pvm0biOVusR9D/s/wAq4quu8F+Dn1iVb29QixjbhT/y2I7fT1NXC99Dzs0jhnh5fWNvxv5ef9bHqI1K1IBE8WP94UUz+ybD/nzg/wC/YorqPz21Lz/A8k8e8eMr/wD7Z/8Aota57Nez6n4L0nVtQlu7qKRppMbiJCBwABx9BVX/AIVxoX/PvL/3+NYSpSbbPrcLn+FpUIU5J3SS27L1PIutBGK9e/4VzoOP9RLn/rsa4rRfB0ms+ILqLDR6fbTMjv3wGPyj3x+VQ6ckd9DOsLWjKaulHe4zwd4RfX7nz7oMlhEfmYcGQ/3R/U16/DBHBCkUKCONAAqqMACmWlpDZ26W9tGI4Y1Cqi9ABU/WuiEeVHx2Y5jPHVOZ6RWy/rqFFLRVHnBRRRQA09DWP4aH/EumPf7TN/6GaKKSOin/AAJ+q/U2aWiimc4UUUUAf//Z";
            var byteArray = Convert.FromBase64String(stringReprentation);
            _it.ObjectSID = byteArray; 

            // Act
            _it.ObjectSID = null;

            // Assert
            Assert.IsNull(_it.ObjectSID);
        }

        [TestMethod]
        public void It_can_get_and_set_ObjectSID()
        {
            // Arrange
            var stringReprentation = @"/9j/4AAQSkZJRgABAQEAYABgAAD/2wBDAAoHBwkHBgoJCAkLCwoMDxkQDw4ODx4WFxIZJCAmJSMgIyIoLTkwKCo2KyIjMkQyNjs9QEBAJjBGS0U+Sjk/QD3/2wBDAQsLCw8NDx0QEB09KSMpPT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT3/wAARCAAyADIDASIAAhEBAxEB/8QAHwAAAQUBAQEBAQEAAAAAAAAAAAECAwQFBgcICQoL/8QAtRAAAgEDAwIEAwUFBAQAAAF9AQIDAAQRBRIhMUEGE1FhByJxFDKBkaEII0KxwRVS0fAkM2JyggkKFhcYGRolJicoKSo0NTY3ODk6Q0RFRkdISUpTVFVWV1hZWmNkZWZnaGlqc3R1dnd4eXqDhIWGh4iJipKTlJWWl5iZmqKjpKWmp6ipqrKztLW2t7i5usLDxMXGx8jJytLT1NXW19jZ2uHi4+Tl5ufo6erx8vP09fb3+Pn6/8QAHwEAAwEBAQEBAQEBAQAAAAAAAAECAwQFBgcICQoL/8QAtREAAgECBAQDBAcFBAQAAQJ3AAECAxEEBSExBhJBUQdhcRMiMoEIFEKRobHBCSMzUvAVYnLRChYkNOEl8RcYGRomJygpKjU2Nzg5OkNERUZHSElKU1RVVldYWVpjZGVmZ2hpanN0dXZ3eHl6goOEhYaHiImKkpOUlZaXmJmaoqOkpaanqKmqsrO0tba3uLm6wsPExcbHyMnK0tPU1dbX2Nna4uPk5ebn6Onq8vP09fb3+Pn6/9oADAMBAAIRAxEAPwD2CS6t42KvPGrDqCwBpv221/5+Yf8AvsV494+O3xpfgZGPL7/9M1rnsn1P51i6tnY+pw/DqrUYVPaW5knt3XqfQDXdqf8Al4h/77FcBoHjKPS9dvNOvmAs3uZDFLj/AFZLHr6g+vb6V59uPrRuO7Oec5zUuo2d+H4fp04ThOXMpeVreZ9DowYZBBUjIIPWnV5Z4L8anTymn6m5a0J2xSt/yy9if7v8vpXqKuGAKkFSMgg9a2jJSR8rjsBUwdTknt0fcfRSUVRwni/j/wD5HXUP+2f/AKLWudrovH//ACOuof8AbP8A9FrXO1yS3Z+nYD/dKX+GP5IKKKKk6xQcGu18GeNTpzJp2pvm0biOVusR9D/s/wAq4quu8F+Dn1iVb29QixjbhT/y2I7fT1NXC99Dzs0jhnh5fWNvxv5ef9bHqI1K1IBE8WP94UUz+ybD/nzg/wC/YorqPz21Lz/A8k8e8eMr/wD7Z/8Aota57Nez6n4L0nVtQlu7qKRppMbiJCBwABx9BVX/AIVxoX/PvL/3+NYSpSbbPrcLn+FpUIU5J3SS27L1PIutBGK9e/4VzoOP9RLn/rsa4rRfB0ms+ILqLDR6fbTMjv3wGPyj3x+VQ6ckd9DOsLWjKaulHe4zwd4RfX7nz7oMlhEfmYcGQ/3R/U16/DBHBCkUKCONAAqqMACmWlpDZ26W9tGI4Y1Cqi9ABU/WuiEeVHx2Y5jPHVOZ6RWy/rqFFLRVHnBRRRQA09DWP4aH/EumPf7TN/6GaKKSOin/AAJ+q/U2aWiimc4UUUUAf//Z";
            var byteArray = Convert.FromBase64String(stringReprentation);

            // Act
            _it.ObjectSID = byteArray; 

            // Assert
            Assert.AreEqual(byteArray[0], _it.ObjectSID[0]);
            Assert.AreEqual(byteArray[1], _it.ObjectSID[1]);
            Assert.AreEqual(byteArray[2], _it.ObjectSID[2]);
            Assert.AreEqual(byteArray[byteArray.Length - 1], _it.ObjectSID[_it.ObjectSID.Length - 1]);
        }


        [TestMethod]
        public void It_can_get_and_set_Scope()
        {
            // Act
            _it.Scope = "A string";

            // Assert
            Assert.AreEqual("A string", _it.Scope);
        }


        [TestMethod]
        public void It_has_SIDHistory_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.SIDHistory);
        }

        [TestMethod]
        public void It_has_SIDHistory_which_can_be_set_back_to_null()
        {
            // Arrange
            var stringReprentation = @"/9j/4AAQSkZJRgABAQEAYABgAAD/2wBDAAoHBwkHBgoJCAkLCwoMDxkQDw4ODx4WFxIZJCAmJSMgIyIoLTkwKCo2KyIjMkQyNjs9QEBAJjBGS0U+Sjk/QD3/2wBDAQsLCw8NDx0QEB09KSMpPT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT3/wAARCAAyADIDASIAAhEBAxEB/8QAHwAAAQUBAQEBAQEAAAAAAAAAAAECAwQFBgcICQoL/8QAtRAAAgEDAwIEAwUFBAQAAAF9AQIDAAQRBRIhMUEGE1FhByJxFDKBkaEII0KxwRVS0fAkM2JyggkKFhcYGRolJicoKSo0NTY3ODk6Q0RFRkdISUpTVFVWV1hZWmNkZWZnaGlqc3R1dnd4eXqDhIWGh4iJipKTlJWWl5iZmqKjpKWmp6ipqrKztLW2t7i5usLDxMXGx8jJytLT1NXW19jZ2uHi4+Tl5ufo6erx8vP09fb3+Pn6/8QAHwEAAwEBAQEBAQEBAQAAAAAAAAECAwQFBgcICQoL/8QAtREAAgECBAQDBAcFBAQAAQJ3AAECAxEEBSExBhJBUQdhcRMiMoEIFEKRobHBCSMzUvAVYnLRChYkNOEl8RcYGRomJygpKjU2Nzg5OkNERUZHSElKU1RVVldYWVpjZGVmZ2hpanN0dXZ3eHl6goOEhYaHiImKkpOUlZaXmJmaoqOkpaanqKmqsrO0tba3uLm6wsPExcbHyMnK0tPU1dbX2Nna4uPk5ebn6Onq8vP09fb3+Pn6/9oADAMBAAIRAxEAPwD2CS6t42KvPGrDqCwBpv221/5+Yf8AvsV494+O3xpfgZGPL7/9M1rnsn1P51i6tnY+pw/DqrUYVPaW5knt3XqfQDXdqf8Al4h/77FcBoHjKPS9dvNOvmAs3uZDFLj/AFZLHr6g+vb6V59uPrRuO7Oec5zUuo2d+H4fp04ThOXMpeVreZ9DowYZBBUjIIPWnV5Z4L8anTymn6m5a0J2xSt/yy9if7v8vpXqKuGAKkFSMgg9a2jJSR8rjsBUwdTknt0fcfRSUVRwni/j/wD5HXUP+2f/AKLWudrovH//ACOuof8AbP8A9FrXO1yS3Z+nYD/dKX+GP5IKKKKk6xQcGu18GeNTpzJp2pvm0biOVusR9D/s/wAq4quu8F+Dn1iVb29QixjbhT/y2I7fT1NXC99Dzs0jhnh5fWNvxv5ef9bHqI1K1IBE8WP94UUz+ybD/nzg/wC/YorqPz21Lz/A8k8e8eMr/wD7Z/8Aota57Nez6n4L0nVtQlu7qKRppMbiJCBwABx9BVX/AIVxoX/PvL/3+NYSpSbbPrcLn+FpUIU5J3SS27L1PIutBGK9e/4VzoOP9RLn/rsa4rRfB0ms+ILqLDR6fbTMjv3wGPyj3x+VQ6ckd9DOsLWjKaulHe4zwd4RfX7nz7oMlhEfmYcGQ/3R/U16/DBHBCkUKCONAAqqMACmWlpDZ26W9tGI4Y1Cqi9ABU/WuiEeVHx2Y5jPHVOZ6RWy/rqFFLRVHnBRRRQA09DWP4aH/EumPf7TN/6GaKKSOin/AAJ+q/U2aWiimc4UUUUAf//Z";
            var byteArray = Convert.FromBase64String(stringReprentation);
            var list = new List<byte[]> {
                byteArray,
                byteArray
            };
            _it.SIDHistory = list; 

            // Act
            _it.SIDHistory = null;

            // Assert
            Assert.IsNull(_it.SIDHistory);
        }

        [TestMethod]
        public void It_can_get_and_set_SIDHistory()
        {
            // Arrange
            var stringReprentation = @"/9j/4AAQSkZJRgABAQEAYABgAAD/2wBDAAoHBwkHBgoJCAkLCwoMDxkQDw4ODx4WFxIZJCAmJSMgIyIoLTkwKCo2KyIjMkQyNjs9QEBAJjBGS0U+Sjk/QD3/2wBDAQsLCw8NDx0QEB09KSMpPT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT3/wAARCAAyADIDASIAAhEBAxEB/8QAHwAAAQUBAQEBAQEAAAAAAAAAAAECAwQFBgcICQoL/8QAtRAAAgEDAwIEAwUFBAQAAAF9AQIDAAQRBRIhMUEGE1FhByJxFDKBkaEII0KxwRVS0fAkM2JyggkKFhcYGRolJicoKSo0NTY3ODk6Q0RFRkdISUpTVFVWV1hZWmNkZWZnaGlqc3R1dnd4eXqDhIWGh4iJipKTlJWWl5iZmqKjpKWmp6ipqrKztLW2t7i5usLDxMXGx8jJytLT1NXW19jZ2uHi4+Tl5ufo6erx8vP09fb3+Pn6/8QAHwEAAwEBAQEBAQEBAQAAAAAAAAECAwQFBgcICQoL/8QAtREAAgECBAQDBAcFBAQAAQJ3AAECAxEEBSExBhJBUQdhcRMiMoEIFEKRobHBCSMzUvAVYnLRChYkNOEl8RcYGRomJygpKjU2Nzg5OkNERUZHSElKU1RVVldYWVpjZGVmZ2hpanN0dXZ3eHl6goOEhYaHiImKkpOUlZaXmJmaoqOkpaanqKmqsrO0tba3uLm6wsPExcbHyMnK0tPU1dbX2Nna4uPk5ebn6Onq8vP09fb3+Pn6/9oADAMBAAIRAxEAPwD2CS6t42KvPGrDqCwBpv221/5+Yf8AvsV494+O3xpfgZGPL7/9M1rnsn1P51i6tnY+pw/DqrUYVPaW5knt3XqfQDXdqf8Al4h/77FcBoHjKPS9dvNOvmAs3uZDFLj/AFZLHr6g+vb6V59uPrRuO7Oec5zUuo2d+H4fp04ThOXMpeVreZ9DowYZBBUjIIPWnV5Z4L8anTymn6m5a0J2xSt/yy9if7v8vpXqKuGAKkFSMgg9a2jJSR8rjsBUwdTknt0fcfRSUVRwni/j/wD5HXUP+2f/AKLWudrovH//ACOuof8AbP8A9FrXO1yS3Z+nYD/dKX+GP5IKKKKk6xQcGu18GeNTpzJp2pvm0biOVusR9D/s/wAq4quu8F+Dn1iVb29QixjbhT/y2I7fT1NXC99Dzs0jhnh5fWNvxv5ef9bHqI1K1IBE8WP94UUz+ybD/nzg/wC/YorqPz21Lz/A8k8e8eMr/wD7Z/8Aota57Nez6n4L0nVtQlu7qKRppMbiJCBwABx9BVX/AIVxoX/PvL/3+NYSpSbbPrcLn+FpUIU5J3SS27L1PIutBGK9e/4VzoOP9RLn/rsa4rRfB0ms+ILqLDR6fbTMjv3wGPyj3x+VQ6ckd9DOsLWjKaulHe4zwd4RfX7nz7oMlhEfmYcGQ/3R/U16/DBHBCkUKCONAAqqMACmWlpDZ26W9tGI4Y1Cqi9ABU/WuiEeVHx2Y5jPHVOZ6RWy/rqFFLRVHnBRRRQA09DWP4aH/EumPf7TN/6GaKKSOin/AAJ+q/U2aWiimc4UUUUAf//Z";
            var byteArray = Convert.FromBase64String(stringReprentation);
            var list = new List<byte[]> {
                byteArray,
                byteArray
            };

            // Act
            _it.SIDHistory = list; 

            // Assert
            Assert.AreEqual(byteArray[0], _it.SIDHistory[0][0]);
            Assert.AreEqual(byteArray[1], _it.SIDHistory[0][1]);
            Assert.AreEqual(byteArray[2], _it.SIDHistory[0][2]);
            Assert.AreEqual(byteArray[0], _it.SIDHistory[1][0]);
            Assert.AreEqual(byteArray[1], _it.SIDHistory[1][1]);
            Assert.AreEqual(byteArray[2], _it.SIDHistory[1][2]);
            Assert.AreEqual(byteArray[byteArray.Length - 1], _it.SIDHistory[0][_it.SIDHistory[0].Length - 1]);
            Assert.AreEqual(byteArray[byteArray.Length - 1], _it.SIDHistory[1][_it.SIDHistory[1].Length - 1]);
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


        [TestMethod]
        public void It_can_get_and_set_Type()
        {
            // Act
            _it.Type = "A string";

            // Assert
            Assert.AreEqual("A string", _it.Type);
        }


    }
}
