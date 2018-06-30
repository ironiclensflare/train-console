using System;
using System.Linq;
using trains.services;

namespace trains
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new TrainClient(new TrainService());
            client.ParseRequest(args);
        }
    }
}
