using System;
using System.Collections.Generic;

namespace DatabaseApi
{
    public partial class Paint
    {

        public int Paintid { get; set; }
        public string Colorname { get; set; }
        public string Colorstyle { get; set; }
        public string Colorlist { get; set; }
        public DateTime? Dateintroduced { get; set; }
        public DateTime? Datediscontinued { get; set; }

    }
}
