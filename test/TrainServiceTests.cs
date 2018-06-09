using System;
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
    }
}