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
            try
            {
                client.ParseRequest(args);
            }
            catch (Exception)
            {
                Console.WriteLine("There was an error.  Helpful message to follow...");
            }
        }
    }
}
