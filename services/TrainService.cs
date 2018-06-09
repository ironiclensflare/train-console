using System;

namespace trains.services
{
    public class TrainService
    {
        public object GetTrainsTo(string crs)
        {
            if (string.IsNullOrEmpty(crs)) throw new ArgumentException ("CRS cannot be null or empty.");
            return "";
        }
    }
}