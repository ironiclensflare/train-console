using System;
using LDBWS;
using Moq;
using NUnit.Framework;
using trains.services;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

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

        [TestCase("NOT", "BHM")]
        [TestCase("BHM", "NOT")]
        public void GetTrainsTo_ValidCrs_ShouldReturnTrains(string crsFrom, string crsTo)
        {
            var service = new TrainService(GetMockLdbService());

            var trains = service.GetTrainsTo(crsFrom, crsTo);

            Assert.NotNull(trains);
            Assert.IsNotEmpty(trains);
        }

        private LDBServiceSoap GetMockLdbService()
        {
            var service = new Mock<LDBServiceSoap>();

            var fakeArrivals = new GetArrivalBoardResponse
            {
                GetStationBoardResult = new StationBoard1
                {
                    trainServices = GetFakeArrivals()
                }
            };

            var fakeDepartures = new GetDepartureBoardResponse
            {
                GetStationBoardResult = new StationBoard1
                {
                    trainServices = GetFakeDepartures()
                }
            };

            service.Setup(s => s.GetArrivalBoardAsync(It.IsAny<GetArrivalBoardRequest>())).Returns(Task.FromResult(fakeArrivals));
            service.Setup(s => s.GetDepartureBoardAsync(It.IsAny<GetDepartureBoardRequest>())).Returns(Task.FromResult(fakeDepartures));

            return service.Object;
        }

        private ServiceItem2[] GetFakeArrivals()
        {
            using (var reader = new StreamReader("test/arrivals.json"))
            {
                var json = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<ServiceItem2[]>(json);
            }
        }

        private ServiceItem2[] GetFakeDepartures()
        {
            using (var reader = new StreamReader("test/departures.json"))
            {
                var json = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<ServiceItem2[]>(json);
            }
        }
    }
}