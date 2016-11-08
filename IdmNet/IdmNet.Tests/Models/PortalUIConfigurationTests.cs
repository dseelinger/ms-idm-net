using System;
using System.Collections.Generic;
using IdmNet.Models;
using Xunit;
using FluentAssertions;
// ReSharper disable ObjectCreationAsStatement
// ReSharper disable UseObjectOrCollectionInitializer

namespace IdmNet.Models.Tests
{
    public class PortalUIConfigurationTests
    {
        private PortalUIConfiguration _it;

        public PortalUIConfigurationTests()
        {
            _it = new PortalUIConfiguration();
        }

        [Fact]
        public void It_has_a_paremeterless_constructor()
        {
            _it.ObjectType.Should().Be("PortalUIConfiguration");
        }

        [Fact]
        public void It_has_a_constructor_that_takes_an_IdmResource()
        {
            var resource = new IdmResource
            {
                DisplayName = "My Display Name",
                Creator = new Person { DisplayName = "Creator Display Name", ObjectID = "Creator ObjectID"},
            };
            var it = new PortalUIConfiguration(resource);

            it.ObjectType.Should().Be("PortalUIConfiguration");
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
            var it = new PortalUIConfiguration(resource);

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
        public void It_can_get_and_set_BrandingCenterText()
        {
            // Act
            _it.BrandingCenterText = "A string";

            // Assert
            _it.BrandingCenterText.Should().Be("A string");
        }


        [Fact]
        public void It_can_get_and_set_BrandingLeftImage()
        {
            // Act
            _it.BrandingLeftImage = "A string";

            // Assert
            _it.BrandingLeftImage.Should().Be("A string");
        }


        [Fact]
        public void It_can_get_and_set_BrandingRightImage()
        {
            // Act
            _it.BrandingRightImage = "A string";

            // Assert
            _it.BrandingRightImage.Should().Be("A string");
        }


        [Fact]
        public void It_can_get_and_set_UICacheTime()
        {
            // Act
            _it.UICacheTime = 123;

            // Assert
            _it.UICacheTime.Should().Be(123);
        }


        [Fact]
        public void It_has_IsConfigurationType_which_is_null_by_default()
        {
            // Assert
            _it.IsConfigurationType.Should().Be(null);
        }

        [Fact]
        public void It_has_IsConfigurationType_which_can_be_set_back_to_null()
        {
            // Arrange
            _it.IsConfigurationType = true;

            // Act
            _it.IsConfigurationType = null;

            // Assert
            _it.IsConfigurationType.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_IsConfigurationType()
        {
            // Act
            _it.IsConfigurationType = true;

            // Assert
            _it.IsConfigurationType.Should().Be(true);
        }


        [Fact]
        public void It_can_get_and_set_ListViewCacheTimeOut()
        {
            // Act
            _it.ListViewCacheTimeOut = 123;

            // Assert
            _it.ListViewCacheTimeOut.Should().Be(123);
        }


        [Fact]
        public void It_can_get_and_set_ListViewPageSize()
        {
            // Act
            _it.ListViewPageSize = 123;

            // Assert
            _it.ListViewPageSize.Should().Be(123);
        }


        [Fact]
        public void It_can_get_and_set_ListViewPagesToCache()
        {
            // Act
            _it.ListViewPagesToCache = 123;

            // Assert
            _it.ListViewPagesToCache.Should().Be(123);
        }


        [Fact]
        public void It_can_get_and_set_UICountCacheTime()
        {
            // Act
            _it.UICountCacheTime = 123;

            // Assert
            _it.UICountCacheTime.Should().Be(123);
        }


        [Fact]
        public void It_can_get_and_set_UIUserCacheTime()
        {
            // Act
            _it.UIUserCacheTime = 123;

            // Assert
            _it.UIUserCacheTime.Should().Be(123);
        }


        [Fact]
        public void It_has_TimeZone_which_is_null_by_default()
        {
            // Assert
            _it.TimeZone.Should().Be(null);
        }

        [Fact]
        public void It_has_TimeZone_which_can_be_set_back_to_null()
        {
            // Arrange
            var testTimeZoneConfiguration = new TimeZoneConfiguration { DisplayName = "Test TimeZoneConfiguration" };			
            _it.TimeZone = testTimeZoneConfiguration; 

            // Act
            _it.TimeZone = null;

            // Assert
            _it.TimeZone.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_TimeZone()
        {
            // Act
			var testTimeZoneConfiguration = new TimeZoneConfiguration { DisplayName = "Test TimeZoneConfiguration" };			
            _it.TimeZone = testTimeZoneConfiguration; 

            // Assert
            _it.TimeZone.DisplayName.Should().Be(testTimeZoneConfiguration.DisplayName);
        }


    }
}
