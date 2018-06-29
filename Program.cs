using System;
using System.Linq;
using trains.services;

namespace trains
{
    class Program
    {
        static void Main(string[] args)
        {
            switch(args[0])
            {
                case "arriving": case "arr":
                    GetArrivals(args);
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
            if (departures == null)
            {
                Console.WriteLine("No trains were found.");
                return;
            }
            Console.WriteLine($"There are {departures.Count()} total departures from {crsFrom.ToUpper()} to {crsTo.ToUpper()}.");
            var times = departures.Select(d => $"{d.std} ({d.etd}) - Platform {d.platform ?? "Unknown"}");
            Console.WriteLine(string.Join(Environment.NewLine, times));
        }

        static void GetArrivals(string[] args)
        {
            string crsTo, crsFrom;
            crsTo = args[1];
            crsFrom = args.Length == 3 ? args[2] : null;
            var service = new TrainService();
            var arrivals = service.GetTrainsFrom(crsTo, crsFrom);
            var times = arrivals.Select(a => $"{a.sta} {a.origin[0].locationName} ({a.eta}) - Platform {a.platform ?? "Unknown"}");
            Console.WriteLine($"Showing arrivals into {crsTo} from {crsFrom ?? "everywhere"}.");
            Console.WriteLine(string.Join(Environment.NewLine, times));
        }
    }
}
