using System;
using System.Collections.Generic;
using LDBWS;
using static LDBWS.LDBServiceSoapClient;

namespace trains.services
{
    public class TrainService
    {
        // TODO: Need to mock this
        private readonly LDBServiceSoapClient _ldbService;

        public TrainService()
        {
            _ldbService = new LDBServiceSoapClient(EndpointConfiguration.LDBServiceSoap);
        }

        public TrainService(LDBServiceSoapClient ldbService)
        {
            _ldbService = ldbService;
        }

        public IEnumerable<object> GetTrainsTo(string crs)
        {
            if (string.IsNullOrEmpty(crs)) throw new ArgumentException ("CRS cannot be null or empty.");
            var trains = _ldbService.GetDepartureBoardAsync
            (
                new LDBWS.AccessToken{TokenValue = Environment.GetEnvironmentVariable("LDBWS_TOKEN")},
                10,
                crs.ToUpper(),
                null,
                LDBWS.FilterType.to,
                0,
                10
            );
            trains.Wait();
            return trains.Result.GetStationBoardResult.trainServices;
        }
    }
}