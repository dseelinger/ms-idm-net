using System;
using System.Collections.Generic;
using IdmNet.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable ObjectCreationAsStatement
// ReSharper disable UseObjectOrCollectionInitializer

namespace IdmNet.Models.Tests
{
    [TestClass]
    public class msidmReportingJobTests
    {
        private msidmReportingJob _it;

        public msidmReportingJobTests()
        {
            _it = new msidmReportingJob();
        }

        [TestMethod]
        public void It_has_a_paremeterless_constructor()
        {
            Assert.AreEqual("msidmReportingJob", _it.ObjectType);
        }

        [TestMethod]
        public void It_has_a_constructor_that_takes_an_IdmResource()
        {
            var resource = new IdmResource
            {
                DisplayName = "My Display Name",
                Creator = new Person { DisplayName = "Creator Display Name", ObjectID = "Creator ObjectID"},
            };
            var it = new msidmReportingJob(resource);

            Assert.AreEqual("msidmReportingJob", it.ObjectType);
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
            var it = new msidmReportingJob(resource);

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
        public void It_has_msidmCompletedTime_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.msidmCompletedTime);
        }

        [TestMethod]
        public void It_has_msidmCompletedTime_which_can_be_set_back_to_null()
        {
            // Arrange
            var now = DateTime.Now;
            var testTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);
            _it.msidmCompletedTime = testTime;

            // Act
            _it.msidmCompletedTime = null;

            // Assert
            Assert.IsNull(_it.msidmCompletedTime);
        }

        [TestMethod]
        public void It_can_get_and_set_msidmCompletedTime()
        {
            // Act
            var now = DateTime.Now;
            var testTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);
            _it.msidmCompletedTime = testTime;

            // Assert
            Assert.AreEqual(testTime, _it.msidmCompletedTime);
        }


        [TestMethod]
        public void It_can_get_and_set_msidmReportingJobDetails()
        {
            // Act
            _it.msidmReportingJobDetails = "A string";

            // Assert
            Assert.AreEqual("A string", _it.msidmReportingJobDetails);
        }


        [TestMethod]
        public void It_can_get_and_set_msidmReportingJobStatus()
        {
            // Act
            _it.msidmReportingJobStatus = "A string";

            // Assert
            Assert.AreEqual("A string", _it.msidmReportingJobStatus);
        }


        [TestMethod]
        public void It_can_get_and_set_msidmReportingJobType()
        {
            // Act
            _it.msidmReportingJobType = "A string";

            // Assert
            Assert.AreEqual("A string", _it.msidmReportingJobType);
        }


        [TestMethod]
        public void It_has_msidmStartTime_which_is_null_by_default()
        {
            // Assert
            Assert.IsNull(_it.msidmStartTime);
        }

        [TestMethod]
        public void It_has_msidmStartTime_which_can_be_set_back_to_null()
        {
            // Arrange
            var now = DateTime.Now;
            var testTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);
            _it.msidmStartTime = testTime;

            // Act
            _it.msidmStartTime = null;

            // Assert
            Assert.IsNull(_it.msidmStartTime);
        }

        [TestMethod]
        public void It_can_get_and_set_msidmStartTime()
        {
            // Act
            var now = DateTime.Now;
            var testTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);
            _it.msidmStartTime = testTime;

            // Assert
            Assert.AreEqual(testTime, _it.msidmStartTime);
        }


    }
}
