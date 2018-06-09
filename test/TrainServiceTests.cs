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
        [TestCase(null)]
        [TestCase("")]
        public void GetTrainsTo_NullOrEmptyCrs_ShouldThrowArgumentException(string crs)
        {
            var service = new TrainService();

            Assert.Throws<ArgumentException>(() => service.GetTrainsTo(crs));
        }

        [TestCase("NOT")]
        [TestCase("BHM")]
        public void GetTrainsTo_ValidCrs_ShouldReturnTrains(string crs)
        {
            var service = new TrainService();

            var trains = service.GetTrainsTo(crs);

            Assert.NotNull(trains);
            Assert.IsNotEmpty(trains);
        }
    }
}