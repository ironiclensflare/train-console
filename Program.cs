using System;
using System.Linq;
using trains.services;
using static LDBWS.LDBServiceSoapClient;

namespace trains
{
    class Program
    {
        static void Main(string[] args)
        {
            switch(args[0])
            {
                case "arriving": case "arr":
                    // TODO: Add arrivals functionality
                    break;
                case "departing": case "dep":
                    GetDepartures(args);
                    break;
                default:
                    GetDepartures(args);
                    break;
            }
        }

        static void GetDepartures(string[] args)
        {   
            string crsFrom, crsTo;
            if (args[0] == "departing" || args[0] == "dep")
            {
                crsFrom = args[1];
                crsTo = args[2];
            }
            else 
            {
                crsFrom = args[0];
                crsTo = args[1];
            }

            var service = new TrainService();
            var departures = service.GetTrainsTo(crsFrom, crsTo);
            Console.WriteLine($"There are {departures.Count()} total departures.");
            var times = departures.Select(d => $"{d.std} ({d.etd}) - Platform {d.platform}");
            Console.WriteLine(string.Join(Environment.NewLine, times));
        }
    }
}
