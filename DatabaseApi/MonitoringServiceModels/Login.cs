using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseApi.MonitoringServiceModels
{
    public class Login
    {
        public DateTime time_Stamp { get; set; }
        public string accountName { get; set; }
        public string accountType { get; set; }
    }
}
