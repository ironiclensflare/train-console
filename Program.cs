using System;
using static LDBWS.LDBServiceSoapClient;

namespace trains
{
    class Program
    {
        static void Main(string[] args)
        {
            var token = Environment.GetEnvironmentVariable("LDBWS_TOKEN");
            var client = new LDBWS.LDBServiceSoapClient(EndpointConfiguration.LDBServiceSoap);
            var task = client.GetArrBoardWithDetailsAsync(new LDBWS.AccessToken{TokenValue = token}, 10, "NOT", null, LDBWS.FilterType.to, 0, 10);
            task.Wait();
        }
    }
}
