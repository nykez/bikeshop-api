using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Net.Http.Formatting;

namespace DatabaseApi.Helpers
{
    public class MonitoringService
    {
        HttpClient httpLib;

        public MonitoringService(string address) 
        {
            httpLib = new HttpClient();
            httpLib.BaseAddress = new Uri(address);
   
        }

        public async Task SendUpdateAsync(string path, Object obj) 
        {
            var status = new HttpResponseMessage();
            try
            {
                status = await httpLib.PostAsJsonAsync(path, obj);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            return status.IsSuccessStatusCode;

        }
    }
}
