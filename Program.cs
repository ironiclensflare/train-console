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
            var crsFrom = args[0];
            var crsTo = args[1];
            var service = new TrainService();
            var departures = service.GetTrainsTo(crsFrom, crsTo);
            Console.WriteLine($"There are {departures.Count()} total departures.");
            var times = departures.Select(d => $"{d.std} ({d.etd}) - Platform {d.platform}");
            Console.WriteLine(string.Join(Environment.NewLine, times));
        }
    }
}
