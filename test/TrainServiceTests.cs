using System;
using LDBWS;
using Moq;
using NUnit.Framework;
using trains.services;

namespace trains.test
{
    [TestFixture]
    public class TrainServiceTests
    {
        [TestCase(null, null)]
        [TestCase("", "")]
        [TestCase("", null)]
        [TestCase(null, "")]
        public void GetTrainsTo_NullOrEmptyCrs_ShouldThrowArgumentException(string crsFrom, string crsTo)
        {
            var service = new TrainService();

            Assert.Throws<ArgumentException>(() => service.GetTrainsTo(crsFrom, crsTo));
        }

        [Ignore("Re-enable this once LDB API is stubbed")]
        [TestCase("NOT", "BHM")]
        [TestCase("BHM", "NOT")]
        public void GetTrainsTo_ValidCrs_ShouldReturnTrains(string crsFrom, string crsTo)
        {
            var service = new TrainService();

            var trains = service.GetTrainsTo(crsFrom, crsTo);

            Assert.NotNull(trains);
            Assert.IsNotEmpty(trains);
        }
    }
}