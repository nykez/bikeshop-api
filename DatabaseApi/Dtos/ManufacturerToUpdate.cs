using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseApi.Dtos {
	public class ManufacturerToUpdate {
        public string Manufacturername { get; set; }
        public string Contactname { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Zipcode { get; set; }
        public int? Cityid { get; set; }
        public int? Balancedue { get; set; }
    }
}
