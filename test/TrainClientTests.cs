using System;
using System.Collections.Generic;
using LDBWS;
using Moq;
using NUnit.Framework;
using trains;
using trains.services;

namespace trains.test
{

    [TestFixture]
    public class TrainClientTests
    {
        private TrainClient _client;
        private Mock<ITrainService> _mockService;

        [SetUp]
        public void SetUp()
        {
            _mockService = new Mock<ITrainService>();
            _mockService.Setup(mock => mock.GetTrainsFrom(It.IsAny<string>(), It.IsAny<string>()))
                .Returns((IEnumerable<ServiceItem2>)null);
            _mockService.Setup(mock => mock.GetTrainsTo(It.IsAny<string>(), It.IsAny<string>()))
                .Returns((IEnumerable<ServiceItem2>)null);

            _client = new TrainClient(_mockService.Object);
        }

        [TestCase]
        public void ParseRequest_NullArgs_ShouldThrowException()
        {
            var e = Assert.Throws<ArgumentException>(() => _client.ParseRequest(null));
            Assert.AreEqual("args cannot be null or empty", e.Message);
        }

        [TestCase]
        public void ParseRequest_EmptyArgs_ShouldThrowException()
        {
            var empty = new string[0];
            var e = Assert.Throws<ArgumentException>(() => _client.ParseRequest(empty));
            Assert.AreEqual("args cannot be null or empty", e.Message);
        }

        [TestCase]
        public void ParseRequest_DeparturesShorthand_ShouldRouteCorrectly()
        {
            _client.ParseRequest(new[] { "NOT", "BHM" });
            _mockService.Verify(s => s.GetTrainsTo("NOT", "BHM"), Times.Once);
        }

        [TestCase("dep")]
        [TestCase("departing")]
        public void ParseRequest_Departures_ShouldRouteCorrectly(string arg)
        {
            _client.ParseRequest(new[] { arg, "NOT", "BHM" });
            _mockService.Verify(s => s.GetTrainsTo("NOT", "BHM"), Times.Once);
        }

        [TestCase("arr")]
        [TestCase("arriving")]
        public void ParseRequest_Arrivals_ShouldRouteCorrectly(string arg)
        {
            _client.ParseRequest(new[] { arg, "BHM", "NOT" });
            _mockService.Verify(s => s.GetTrainsFrom("BHM", "NOT"), Times.Once);
        }
    }
}