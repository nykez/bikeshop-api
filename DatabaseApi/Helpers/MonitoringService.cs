using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Net.Http.Formatting;

namespace DatabaseApi.Helpers
{
    /// <summary>
    /// This allows for a post request to be created and sent to a monitoring api
    /// </summary>
    public class MonitoringService
    {
        HttpClient httpLib;
        /// <summary>
        /// Pass in name to set the address of a monitoring api
        /// </summary>
        /// <param name="address">monitoring address</param>
        public MonitoringService(string address) 
        {
            httpLib = new HttpClient();
            httpLib.BaseAddress = new Uri(address);
   
        }
        /// <summary>
        /// Creates a POST request and sends to the correct address.
        /// </summary>
        /// <param name="path">pathing for the POST request</param>
        /// <param name="obj">Pass the correct object for the Post request</param>
        /// <returns></returns>
        public async Task<bool> SendUpdateAsync(string path, Object obj) 
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
