using System;
using System.Collections.Generic;
using LDBWS;
using static LDBWS.LDBServiceSoapClient;

namespace trains.services
{
    public class TrainService
    {
        private readonly LDBServiceSoap _service;

        public TrainService()
        {
            _service = new LDBServiceSoapClient(EndpointConfiguration.LDBServiceSoap);
        }

        public TrainService(LDBServiceSoap ldbService)
        {
            _service = ldbService;
        }

        public IEnumerable<ServiceItem2> GetTrainsTo(string crsFrom, string crsTo)
        {
            if (string.IsNullOrEmpty(crsFrom) || string.IsNullOrEmpty(crsTo)) throw new ArgumentException ("CRS cannot be null or empty.");
            var request = new GetDepartureBoardRequest
            (
                new AccessToken{TokenValue = Environment.GetEnvironmentVariable("LDBWS_TOKEN")},
                10,
                crsFrom.ToUpper(),
                crsTo.ToUpper(),
                FilterType.to,
                0,
                60
            );

            var trains = _service.GetDepartureBoardAsync(request);

            trains.Wait();
            return trains.Result.GetStationBoardResult.trainServices;
        }

        public IEnumerable<ServiceItem2> GetTrainsFrom(string crsTo, string crsFrom)
        {
            var request = new GetArrivalBoardRequest
            (
                new AccessToken{TokenValue = Environment.GetEnvironmentVariable("LDBWS_TOKEN")},
                10,
                crsTo.ToUpper(),
                crsFrom.ToUpper(),
                FilterType.from,
                0,
                60
            );

            var trains = _service.GetArrivalBoardAsync(request);

            trains.Wait();
            return trains.Result.GetStationBoardResult.trainServices;    
        }
    }
}