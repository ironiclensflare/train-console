using System;
using trains.services;
using static LDBWS.LDBServiceSoapClient;

namespace trains
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new TrainService();
            var departures = service.GetTrainsTo("NOT", "BHM");
        }
    }
}
