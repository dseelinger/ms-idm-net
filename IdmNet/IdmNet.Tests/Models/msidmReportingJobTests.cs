using System;
using System.Collections.Generic;
using IdmNet.Models;
using Xunit;
using FluentAssertions;
// ReSharper disable ObjectCreationAsStatement
// ReSharper disable UseObjectOrCollectionInitializer

namespace IdmNet.Models.Tests
{
    public class msidmReportingJobTests
    {
        private msidmReportingJob _it;

        public msidmReportingJobTests()
        {
            _it = new msidmReportingJob();
        }

        [Fact]
        public void It_has_a_paremeterless_constructor()
        {
            _it.ObjectType.Should().Be("msidmReportingJob");
        }

        [Fact]
        public void It_has_a_constructor_that_takes_an_IdmResource()
        {
            var resource = new IdmResource
            {
                DisplayName = "My Display Name",
                Creator = new Person { DisplayName = "Creator Display Name", ObjectID = "Creator ObjectID"},
            };
            var it = new msidmReportingJob(resource);

            it.ObjectType.Should().Be("msidmReportingJob");
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
            var it = new msidmReportingJob(resource);

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
        public void It_has_msidmCompletedTime_which_is_null_by_default()
        {
            // Assert
            _it.msidmCompletedTime.Should().Be(null);
        }

        [Fact]
        public void It_has_msidmCompletedTime_which_can_be_set_back_to_null()
        {
            // Arrange
            var now = DateTime.Now;
            var testTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);
            _it.msidmCompletedTime = testTime;

            // Act
            _it.msidmCompletedTime = null;

            // Assert
            _it.msidmCompletedTime.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_msidmCompletedTime()
        {
            // Act
            var now = DateTime.Now;
            var testTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);
            _it.msidmCompletedTime = testTime;

            // Assert
            _it.msidmCompletedTime.Should().Be(testTime);
        }


        [Fact]
        public void It_can_get_and_set_msidmReportingJobDetails()
        {
            // Act
            _it.msidmReportingJobDetails = "A string";

            // Assert
            _it.msidmReportingJobDetails.Should().Be("A string");
        }


        [Fact]
        public void It_can_get_and_set_msidmReportingJobStatus()
        {
            // Act
            _it.msidmReportingJobStatus = "A string";

            // Assert
            _it.msidmReportingJobStatus.Should().Be("A string");
        }


        [Fact]
        public void It_can_get_and_set_msidmReportingJobType()
        {
            // Act
            _it.msidmReportingJobType = "A string";

            // Assert
            _it.msidmReportingJobType.Should().Be("A string");
        }


        [Fact]
        public void It_has_msidmStartTime_which_is_null_by_default()
        {
            // Assert
            _it.msidmStartTime.Should().Be(null);
        }

        [Fact]
        public void It_has_msidmStartTime_which_can_be_set_back_to_null()
        {
            // Arrange
            var now = DateTime.Now;
            var testTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);
            _it.msidmStartTime = testTime;

            // Act
            _it.msidmStartTime = null;

            // Assert
            _it.msidmStartTime.Should().Be(null);
        }

        [Fact]
        public void It_can_get_and_set_msidmStartTime()
        {
            // Act
            var now = DateTime.Now;
            var testTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);
            _it.msidmStartTime = testTime;

            // Assert
            _it.msidmStartTime.Should().Be(testTime);
        }


    }
}
