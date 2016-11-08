using System;
using System.Collections.Generic;
using IdmNet.Models;
using Xunit;
using FluentAssertions;
// ReSharper disable ObjectCreationAsStatement
// ReSharper disable UseObjectOrCollectionInitializer

namespace IdmNet.Models.Tests
{
    public class GroupTests
    {
        private Group _it;

        public GroupTests()
        {
            _it = new Group();
        }

        [Fact]
        public void It_has_a_paremeterless_constructor()
        {
            _it.ObjectType.Should().Be("Group");
        }

        [Fact]
        public void It_has_a_constructor_that_takes_an_IdmResource()
        {
            var resource = new IdmResource
            {
                DisplayName = "My Display Name",
                Creator = new Person { DisplayName = "Creator Display Name", ObjectID = "Creator ObjectID"},
            };
            var it = new Group(resource);

            it.ObjectType.Should().Be("Group");
            it.DisplayName.Should().Be("My Display Name");
            it.Creator.DisplayName.Should().Be("Creator Display Name");
        }

        [Fact]
        public void It_has_a_constructor_that_takes_an_IdmResource_without_Creator()
        {
            var resource = new IdmResource
            {
                DisplayName = "My Display Name",
            };
            var it = new Group(resource);

            it.DisplayName.Should().Be("My Display Name");
            it.Creator.Should().Be(null);
        }

        [Fact]
        public void It_throws_when_you_try_to_set_ObjectType_to_anything_other_than_its_primary_ObjectType()
        {
            Action action = () => _it.ObjectType = "Invalid Object Type";
            action.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void It_can_get_and_set_AccountName()
        {
            // Act
            _it.AccountName = "A string";

            // Assert
            _it.AccountName.Should().Be("A string");
        }


        [Fact]
        public void It_has_ComputedMember_which_is_an_empty_collection_by_default()
        {
            // Assert
            _it.ComputedMember.Should().BeEmpty();
        }

        [Fact]
        public void It_has_ComputedMember_which_as_a_collection_cannot_be_set_to_null()
        {
            // Assert
            Action action = () => _it.ComputedMember = null;
            action.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
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
            _it.ComputedMember[0].DisplayName.Should().Be(list[0].DisplayName);
            _it.ComputedMember[1].DisplayName.Should().Be(list[1].DisplayName);
        }

        [Fact]
        public void It_has_msidmDeferredEvaluation_which_is_null_by_default()
        {
            // Assert
            _it.msidmDeferredEvaluation.Should().Be(null);
        }

        [Fact]
        public void It_has_msidmDeferredEvaluation_which_can_be_set_back_to_null()
        {
            // Arrange
            _it.msidmDeferredEvaluation = true;

            // Act
            _it.msidmDeferredEvaluation = null;

            // Assert
            _it.msidmDeferredEvaluation.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_msidmDeferredEvaluation()
        {
            // Act
            _it.msidmDeferredEvaluation = true;

            // Assert
            _it.msidmDeferredEvaluation.Should().Be(true);
        }


        [Fact]
        public void It_has_DisplayedOwner_which_is_null_by_default()
        {
            // Assert
            _it.DisplayedOwner.Should().Be(null);
        }

        [Fact]
        public void It_has_DisplayedOwner_which_can_be_set_back_to_null()
        {
            // Arrange
            var testPerson = new Person { DisplayName = "Test Person" };			
            _it.DisplayedOwner = testPerson; 

            // Act
            _it.DisplayedOwner = null;

            // Assert
            _it.DisplayedOwner.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_DisplayedOwner()
        {
            // Act
			var testPerson = new Person { DisplayName = "Test Person" };			
            _it.DisplayedOwner = testPerson; 

            // Assert
            _it.DisplayedOwner.DisplayName.Should().Be(testPerson.DisplayName);
        }


        [Fact]
        public void It_can_get_and_set_Domain()
        {
            // Act
            _it.Domain = "A string";

            // Assert
            _it.Domain.Should().Be("A string");
        }


        [Fact]
        public void It_has_DomainConfiguration_which_is_null_by_default()
        {
            // Assert
            _it.DomainConfiguration.Should().Be(null);
        }

        [Fact]
        public void It_has_DomainConfiguration_which_can_be_set_back_to_null()
        {
            // Arrange
            var testDomainConfiguration = new DomainConfiguration { DisplayName = "Test DomainConfiguration" };			
            _it.DomainConfiguration = testDomainConfiguration; 

            // Act
            _it.DomainConfiguration = null;

            // Assert
            _it.DomainConfiguration.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_DomainConfiguration()
        {
            // Act
			var testDomainConfiguration = new DomainConfiguration { DisplayName = "Test DomainConfiguration" };			
            _it.DomainConfiguration = testDomainConfiguration; 

            // Assert
            _it.DomainConfiguration.DisplayName.Should().Be(testDomainConfiguration.DisplayName);
        }


        [Fact]
        public void It_can_get_and_set_Email()
        {
            // Act
            _it.Email = "A string";

            // Assert
            _it.Email.Should().Be("A string");
        }


        [Fact]
        public void It_can_get_and_set_MailNickname()
        {
            // Act
            _it.MailNickname = "A string";

            // Assert
            _it.MailNickname.Should().Be("A string");
        }


        [Fact]
        public void It_can_get_and_set_Filter()
        {
            // Act
            _it.Filter = "A string";

            // Assert
            _it.Filter.Should().Be("A string");
        }


        [Fact]
        public void It_has_ExplicitMember_which_is_an_empty_collection_by_default()
        {
            // Assert
            _it.ExplicitMember.Should().BeEmpty();
        }

        [Fact]
        public void It_has_ExplicitMember_which_as_a_collection_cannot_be_set_to_null()
        {
            // Assert
            Action action = () => _it.ExplicitMember = null;
            action.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
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
            _it.ExplicitMember[0].DisplayName.Should().Be(list[0].DisplayName);
            _it.ExplicitMember[1].DisplayName.Should().Be(list[1].DisplayName);
        }

        [Fact]
        public void It_can_get_and_set_MembershipAddWorkflow()
        {
            // Act
            _it.MembershipAddWorkflow = "A string";

            // Assert
            _it.MembershipAddWorkflow.Should().Be("A string");
        }


        [Fact]
        public void It_can_get_and_set_MembershipLocked()
        {
            // Act
            _it.MembershipLocked = true;

            // Assert
            _it.MembershipLocked.Should().Be(true);
        }


        [Fact]
        public void It_has_Owner_which_is_an_empty_collection_by_default()
        {
            // Assert
            _it.Owner.Should().BeEmpty();
        }

        [Fact]
        public void It_has_Owner_which_as_a_collection_cannot_be_set_to_null()
        {
            // Assert
            Action action = () => _it.Owner = null;
            action.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
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
            _it.Owner[0].DisplayName.Should().Be(list[0].DisplayName);
            _it.Owner[1].DisplayName.Should().Be(list[1].DisplayName);
        }

        [Fact]
        public void It_has_msidmPamEnabled_which_is_null_by_default()
        {
            // Assert
            _it.msidmPamEnabled.Should().Be(null);
        }

        [Fact]
        public void It_has_msidmPamEnabled_which_can_be_set_back_to_null()
        {
            // Arrange
            _it.msidmPamEnabled = true;

            // Act
            _it.msidmPamEnabled = null;

            // Assert
            _it.msidmPamEnabled.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_msidmPamEnabled()
        {
            // Act
            _it.msidmPamEnabled = true;

            // Assert
            _it.msidmPamEnabled.Should().Be(true);
        }


        [Fact]
        public void It_can_get_and_set_msidmPamSourceDomainName()
        {
            // Act
            _it.msidmPamSourceDomainName = "A string";

            // Assert
            _it.msidmPamSourceDomainName.Should().Be("A string");
        }


        [Fact]
        public void It_has_msidmPamSourceSid_which_is_null_by_default()
        {
            // Assert
            _it.msidmPamSourceSid.Should().BeNull();
        }

        [Fact]
        public void It_has_msidmPamSourceSid_which_can_be_set_back_to_null()
        {
            // Arrange
            var stringReprentation = @"/9j/4AAQSkZJRgABAQEAYABgAAD/2wBDAAoHBwkHBgoJCAkLCwoMDxkQDw4ODx4WFxIZJCAmJSMgIyIoLTkwKCo2KyIjMkQyNjs9QEBAJjBGS0U+Sjk/QD3/2wBDAQsLCw8NDx0QEB09KSMpPT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT3/wAARCAAyADIDASIAAhEBAxEB/8QAHwAAAQUBAQEBAQEAAAAAAAAAAAECAwQFBgcICQoL/8QAtRAAAgEDAwIEAwUFBAQAAAF9AQIDAAQRBRIhMUEGE1FhByJxFDKBkaEII0KxwRVS0fAkM2JyggkKFhcYGRolJicoKSo0NTY3ODk6Q0RFRkdISUpTVFVWV1hZWmNkZWZnaGlqc3R1dnd4eXqDhIWGh4iJipKTlJWWl5iZmqKjpKWmp6ipqrKztLW2t7i5usLDxMXGx8jJytLT1NXW19jZ2uHi4+Tl5ufo6erx8vP09fb3+Pn6/8QAHwEAAwEBAQEBAQEBAQAAAAAAAAECAwQFBgcICQoL/8QAtREAAgECBAQDBAcFBAQAAQJ3AAECAxEEBSExBhJBUQdhcRMiMoEIFEKRobHBCSMzUvAVYnLRChYkNOEl8RcYGRomJygpKjU2Nzg5OkNERUZHSElKU1RVVldYWVpjZGVmZ2hpanN0dXZ3eHl6goOEhYaHiImKkpOUlZaXmJmaoqOkpaanqKmqsrO0tba3uLm6wsPExcbHyMnK0tPU1dbX2Nna4uPk5ebn6Onq8vP09fb3+Pn6/9oADAMBAAIRAxEAPwD2CS6t42KvPGrDqCwBpv221/5+Yf8AvsV494+O3xpfgZGPL7/9M1rnsn1P51i6tnY+pw/DqrUYVPaW5knt3XqfQDXdqf8Al4h/77FcBoHjKPS9dvNOvmAs3uZDFLj/AFZLHr6g+vb6V59uPrRuO7Oec5zUuo2d+H4fp04ThOXMpeVreZ9DowYZBBUjIIPWnV5Z4L8anTymn6m5a0J2xSt/yy9if7v8vpXqKuGAKkFSMgg9a2jJSR8rjsBUwdTknt0fcfRSUVRwni/j/wD5HXUP+2f/AKLWudrovH//ACOuof8AbP8A9FrXO1yS3Z+nYD/dKX+GP5IKKKKk6xQcGu18GeNTpzJp2pvm0biOVusR9D/s/wAq4quu8F+Dn1iVb29QixjbhT/y2I7fT1NXC99Dzs0jhnh5fWNvxv5ef9bHqI1K1IBE8WP94UUz+ybD/nzg/wC/YorqPz21Lz/A8k8e8eMr/wD7Z/8Aota57Nez6n4L0nVtQlu7qKRppMbiJCBwABx9BVX/AIVxoX/PvL/3+NYSpSbbPrcLn+FpUIU5J3SS27L1PIutBGK9e/4VzoOP9RLn/rsa4rRfB0ms+ILqLDR6fbTMjv3wGPyj3x+VQ6ckd9DOsLWjKaulHe4zwd4RfX7nz7oMlhEfmYcGQ/3R/U16/DBHBCkUKCONAAqqMACmWlpDZ26W9tGI4Y1Cqi9ABU/WuiEeVHx2Y5jPHVOZ6RWy/rqFFLRVHnBRRRQA09DWP4aH/EumPf7TN/6GaKKSOin/AAJ+q/U2aWiimc4UUUUAf//Z";
            var byteArray = Convert.FromBase64String(stringReprentation);
            _it.msidmPamSourceSid = byteArray; 

            // Act
            _it.msidmPamSourceSid = null;

            // Assert
            _it.msidmPamSourceSid.Should().BeNull();
        }

        [Fact]
        public void It_can_get_and_set_msidmPamSourceSid()
        {
            // Arrange
            var stringReprentation = @"/9j/4AAQSkZJRgABAQEAYABgAAD/2wBDAAoHBwkHBgoJCAkLCwoMDxkQDw4ODx4WFxIZJCAmJSMgIyIoLTkwKCo2KyIjMkQyNjs9QEBAJjBGS0U+Sjk/QD3/2wBDAQsLCw8NDx0QEB09KSMpPT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT3/wAARCAAyADIDASIAAhEBAxEB/8QAHwAAAQUBAQEBAQEAAAAAAAAAAAECAwQFBgcICQoL/8QAtRAAAgEDAwIEAwUFBAQAAAF9AQIDAAQRBRIhMUEGE1FhByJxFDKBkaEII0KxwRVS0fAkM2JyggkKFhcYGRolJicoKSo0NTY3ODk6Q0RFRkdISUpTVFVWV1hZWmNkZWZnaGlqc3R1dnd4eXqDhIWGh4iJipKTlJWWl5iZmqKjpKWmp6ipqrKztLW2t7i5usLDxMXGx8jJytLT1NXW19jZ2uHi4+Tl5ufo6erx8vP09fb3+Pn6/8QAHwEAAwEBAQEBAQEBAQAAAAAAAAECAwQFBgcICQoL/8QAtREAAgECBAQDBAcFBAQAAQJ3AAECAxEEBSExBhJBUQdhcRMiMoEIFEKRobHBCSMzUvAVYnLRChYkNOEl8RcYGRomJygpKjU2Nzg5OkNERUZHSElKU1RVVldYWVpjZGVmZ2hpanN0dXZ3eHl6goOEhYaHiImKkpOUlZaXmJmaoqOkpaanqKmqsrO0tba3uLm6wsPExcbHyMnK0tPU1dbX2Nna4uPk5ebn6Onq8vP09fb3+Pn6/9oADAMBAAIRAxEAPwD2CS6t42KvPGrDqCwBpv221/5+Yf8AvsV494+O3xpfgZGPL7/9M1rnsn1P51i6tnY+pw/DqrUYVPaW5knt3XqfQDXdqf8Al4h/77FcBoHjKPS9dvNOvmAs3uZDFLj/AFZLHr6g+vb6V59uPrRuO7Oec5zUuo2d+H4fp04ThOXMpeVreZ9DowYZBBUjIIPWnV5Z4L8anTymn6m5a0J2xSt/yy9if7v8vpXqKuGAKkFSMgg9a2jJSR8rjsBUwdTknt0fcfRSUVRwni/j/wD5HXUP+2f/AKLWudrovH//ACOuof8AbP8A9FrXO1yS3Z+nYD/dKX+GP5IKKKKk6xQcGu18GeNTpzJp2pvm0biOVusR9D/s/wAq4quu8F+Dn1iVb29QixjbhT/y2I7fT1NXC99Dzs0jhnh5fWNvxv5ef9bHqI1K1IBE8WP94UUz+ybD/nzg/wC/YorqPz21Lz/A8k8e8eMr/wD7Z/8Aota57Nez6n4L0nVtQlu7qKRppMbiJCBwABx9BVX/AIVxoX/PvL/3+NYSpSbbPrcLn+FpUIU5J3SS27L1PIutBGK9e/4VzoOP9RLn/rsa4rRfB0ms+ILqLDR6fbTMjv3wGPyj3x+VQ6ckd9DOsLWjKaulHe4zwd4RfX7nz7oMlhEfmYcGQ/3R/U16/DBHBCkUKCONAAqqMACmWlpDZ26W9tGI4Y1Cqi9ABU/WuiEeVHx2Y5jPHVOZ6RWy/rqFFLRVHnBRRRQA09DWP4aH/EumPf7TN/6GaKKSOin/AAJ+q/U2aWiimc4UUUUAf//Z";
            var byteArray = Convert.FromBase64String(stringReprentation);

            // Act
            _it.msidmPamSourceSid = byteArray; 

            // Assert
            _it.msidmPamSourceSid[0].Should().Be(byteArray[0]);
            _it.msidmPamSourceSid[1].Should().Be(byteArray[1]);
            _it.msidmPamSourceSid[2].Should().Be(byteArray[2]);
            _it.msidmPamSourceSid[_it.msidmPamSourceSid.Length - 1].Should().Be(byteArray[byteArray.Length - 1]);
        }


        [Fact]
        public void It_can_get_and_set_msidmPamSourceGroupName()
        {
            // Act
            _it.msidmPamSourceGroupName = "A string";

            // Assert
            _it.msidmPamSourceGroupName.Should().Be("A string");
        }


        [Fact]
        public void It_has_ObjectSID_which_is_null_by_default()
        {
            // Assert
            _it.ObjectSID.Should().BeNull();
        }

        [Fact]
        public void It_has_ObjectSID_which_can_be_set_back_to_null()
        {
            // Arrange
            var stringReprentation = @"/9j/4AAQSkZJRgABAQEAYABgAAD/2wBDAAoHBwkHBgoJCAkLCwoMDxkQDw4ODx4WFxIZJCAmJSMgIyIoLTkwKCo2KyIjMkQyNjs9QEBAJjBGS0U+Sjk/QD3/2wBDAQsLCw8NDx0QEB09KSMpPT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT3/wAARCAAyADIDASIAAhEBAxEB/8QAHwAAAQUBAQEBAQEAAAAAAAAAAAECAwQFBgcICQoL/8QAtRAAAgEDAwIEAwUFBAQAAAF9AQIDAAQRBRIhMUEGE1FhByJxFDKBkaEII0KxwRVS0fAkM2JyggkKFhcYGRolJicoKSo0NTY3ODk6Q0RFRkdISUpTVFVWV1hZWmNkZWZnaGlqc3R1dnd4eXqDhIWGh4iJipKTlJWWl5iZmqKjpKWmp6ipqrKztLW2t7i5usLDxMXGx8jJytLT1NXW19jZ2uHi4+Tl5ufo6erx8vP09fb3+Pn6/8QAHwEAAwEBAQEBAQEBAQAAAAAAAAECAwQFBgcICQoL/8QAtREAAgECBAQDBAcFBAQAAQJ3AAECAxEEBSExBhJBUQdhcRMiMoEIFEKRobHBCSMzUvAVYnLRChYkNOEl8RcYGRomJygpKjU2Nzg5OkNERUZHSElKU1RVVldYWVpjZGVmZ2hpanN0dXZ3eHl6goOEhYaHiImKkpOUlZaXmJmaoqOkpaanqKmqsrO0tba3uLm6wsPExcbHyMnK0tPU1dbX2Nna4uPk5ebn6Onq8vP09fb3+Pn6/9oADAMBAAIRAxEAPwD2CS6t42KvPGrDqCwBpv221/5+Yf8AvsV494+O3xpfgZGPL7/9M1rnsn1P51i6tnY+pw/DqrUYVPaW5knt3XqfQDXdqf8Al4h/77FcBoHjKPS9dvNOvmAs3uZDFLj/AFZLHr6g+vb6V59uPrRuO7Oec5zUuo2d+H4fp04ThOXMpeVreZ9DowYZBBUjIIPWnV5Z4L8anTymn6m5a0J2xSt/yy9if7v8vpXqKuGAKkFSMgg9a2jJSR8rjsBUwdTknt0fcfRSUVRwni/j/wD5HXUP+2f/AKLWudrovH//ACOuof8AbP8A9FrXO1yS3Z+nYD/dKX+GP5IKKKKk6xQcGu18GeNTpzJp2pvm0biOVusR9D/s/wAq4quu8F+Dn1iVb29QixjbhT/y2I7fT1NXC99Dzs0jhnh5fWNvxv5ef9bHqI1K1IBE8WP94UUz+ybD/nzg/wC/YorqPz21Lz/A8k8e8eMr/wD7Z/8Aota57Nez6n4L0nVtQlu7qKRppMbiJCBwABx9BVX/AIVxoX/PvL/3+NYSpSbbPrcLn+FpUIU5J3SS27L1PIutBGK9e/4VzoOP9RLn/rsa4rRfB0ms+ILqLDR6fbTMjv3wGPyj3x+VQ6ckd9DOsLWjKaulHe4zwd4RfX7nz7oMlhEfmYcGQ/3R/U16/DBHBCkUKCONAAqqMACmWlpDZ26W9tGI4Y1Cqi9ABU/WuiEeVHx2Y5jPHVOZ6RWy/rqFFLRVHnBRRRQA09DWP4aH/EumPf7TN/6GaKKSOin/AAJ+q/U2aWiimc4UUUUAf//Z";
            var byteArray = Convert.FromBase64String(stringReprentation);
            _it.ObjectSID = byteArray; 

            // Act
            _it.ObjectSID = null;

            // Assert
            _it.ObjectSID.Should().BeNull();
        }

        [Fact]
        public void It_can_get_and_set_ObjectSID()
        {
            // Arrange
            var stringReprentation = @"/9j/4AAQSkZJRgABAQEAYABgAAD/2wBDAAoHBwkHBgoJCAkLCwoMDxkQDw4ODx4WFxIZJCAmJSMgIyIoLTkwKCo2KyIjMkQyNjs9QEBAJjBGS0U+Sjk/QD3/2wBDAQsLCw8NDx0QEB09KSMpPT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT3/wAARCAAyADIDASIAAhEBAxEB/8QAHwAAAQUBAQEBAQEAAAAAAAAAAAECAwQFBgcICQoL/8QAtRAAAgEDAwIEAwUFBAQAAAF9AQIDAAQRBRIhMUEGE1FhByJxFDKBkaEII0KxwRVS0fAkM2JyggkKFhcYGRolJicoKSo0NTY3ODk6Q0RFRkdISUpTVFVWV1hZWmNkZWZnaGlqc3R1dnd4eXqDhIWGh4iJipKTlJWWl5iZmqKjpKWmp6ipqrKztLW2t7i5usLDxMXGx8jJytLT1NXW19jZ2uHi4+Tl5ufo6erx8vP09fb3+Pn6/8QAHwEAAwEBAQEBAQEBAQAAAAAAAAECAwQFBgcICQoL/8QAtREAAgECBAQDBAcFBAQAAQJ3AAECAxEEBSExBhJBUQdhcRMiMoEIFEKRobHBCSMzUvAVYnLRChYkNOEl8RcYGRomJygpKjU2Nzg5OkNERUZHSElKU1RVVldYWVpjZGVmZ2hpanN0dXZ3eHl6goOEhYaHiImKkpOUlZaXmJmaoqOkpaanqKmqsrO0tba3uLm6wsPExcbHyMnK0tPU1dbX2Nna4uPk5ebn6Onq8vP09fb3+Pn6/9oADAMBAAIRAxEAPwD2CS6t42KvPGrDqCwBpv221/5+Yf8AvsV494+O3xpfgZGPL7/9M1rnsn1P51i6tnY+pw/DqrUYVPaW5knt3XqfQDXdqf8Al4h/77FcBoHjKPS9dvNOvmAs3uZDFLj/AFZLHr6g+vb6V59uPrRuO7Oec5zUuo2d+H4fp04ThOXMpeVreZ9DowYZBBUjIIPWnV5Z4L8anTymn6m5a0J2xSt/yy9if7v8vpXqKuGAKkFSMgg9a2jJSR8rjsBUwdTknt0fcfRSUVRwni/j/wD5HXUP+2f/AKLWudrovH//ACOuof8AbP8A9FrXO1yS3Z+nYD/dKX+GP5IKKKKk6xQcGu18GeNTpzJp2pvm0biOVusR9D/s/wAq4quu8F+Dn1iVb29QixjbhT/y2I7fT1NXC99Dzs0jhnh5fWNvxv5ef9bHqI1K1IBE8WP94UUz+ybD/nzg/wC/YorqPz21Lz/A8k8e8eMr/wD7Z/8Aota57Nez6n4L0nVtQlu7qKRppMbiJCBwABx9BVX/AIVxoX/PvL/3+NYSpSbbPrcLn+FpUIU5J3SS27L1PIutBGK9e/4VzoOP9RLn/rsa4rRfB0ms+ILqLDR6fbTMjv3wGPyj3x+VQ6ckd9DOsLWjKaulHe4zwd4RfX7nz7oMlhEfmYcGQ/3R/U16/DBHBCkUKCONAAqqMACmWlpDZ26W9tGI4Y1Cqi9ABU/WuiEeVHx2Y5jPHVOZ6RWy/rqFFLRVHnBRRRQA09DWP4aH/EumPf7TN/6GaKKSOin/AAJ+q/U2aWiimc4UUUUAf//Z";
            var byteArray = Convert.FromBase64String(stringReprentation);

            // Act
            _it.ObjectSID = byteArray; 

            // Assert
            _it.ObjectSID[0].Should().Be(byteArray[0]);
            _it.ObjectSID[1].Should().Be(byteArray[1]);
            _it.ObjectSID[2].Should().Be(byteArray[2]);
            _it.ObjectSID[_it.ObjectSID.Length - 1].Should().Be(byteArray[byteArray.Length - 1]);
        }


        [Fact]
        public void It_can_get_and_set_Scope()
        {
            // Act
            _it.Scope = "A string";

            // Assert
            _it.Scope.Should().Be("A string");
        }


        [Fact]
        public void It_has_SIDHistory_which_is_an_empty_collection_by_default()
        {
            // Assert
            _it.SIDHistory.Should().BeEmpty();
        }

        [Fact]
        public void It_has_SIDHistory_which_as_a_collection_cannot_be_set_to_null()
        {
            // Assert
            Action action = () => _it.SIDHistory = null;
            action.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
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
            _it.SIDHistory[0][0].Should().Be(byteArray[0]);
            _it.SIDHistory[0][1].Should().Be(byteArray[1]);
            _it.SIDHistory[0][2].Should().Be(byteArray[2]);
            _it.SIDHistory[1][0].Should().Be(byteArray[0]);
            _it.SIDHistory[1][1].Should().Be(byteArray[1]);
            _it.SIDHistory[1][2].Should().Be(byteArray[2]);
            _it.SIDHistory[0][_it.SIDHistory[0].Length - 1].Should().Be(byteArray[byteArray.Length - 1]);
            _it.SIDHistory[1][_it.SIDHistory[0].Length - 1].Should().Be(byteArray[byteArray.Length - 1]);
        }


        [Fact]
        public void It_has_Temporal_which_is_null_by_default()
        {
            // Assert
            _it.Temporal.Should().Be(null);
        }

        [Fact]
        public void It_has_Temporal_which_can_be_set_back_to_null()
        {
            // Arrange
            _it.Temporal = true;

            // Act
            _it.Temporal = null;

            // Assert
            _it.Temporal.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_Temporal()
        {
            // Act
            _it.Temporal = true;

            // Assert
            _it.Temporal.Should().Be(true);
        }


        [Fact]
        public void It_can_get_and_set_Type()
        {
            // Act
            _it.Type = "A string";

            // Assert
            _it.Type.Should().Be("A string");
        }


        [Fact]
        public void It_has_msidmPamUsesSIDHistory_which_is_null_by_default()
        {
            // Assert
            _it.msidmPamUsesSIDHistory.Should().Be(null);
        }

        [Fact]
        public void It_has_msidmPamUsesSIDHistory_which_can_be_set_back_to_null()
        {
            // Arrange
            _it.msidmPamUsesSIDHistory = true;

            // Act
            _it.msidmPamUsesSIDHistory = null;

            // Assert
            _it.msidmPamUsesSIDHistory.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_msidmPamUsesSIDHistory()
        {
            // Act
            _it.msidmPamUsesSIDHistory = true;

            // Assert
            _it.msidmPamUsesSIDHistory.Should().Be(true);
        }


    }
}
