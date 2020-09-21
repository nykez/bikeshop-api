using System;
using System.ComponentModel.DataAnnotations;

namespace DatabaseApi.Dtos {
	public class ManufacturerToCreate {
        [Required]
        public int Manufacturerid { get; set; }
        public string Manufacturername { get; set; }
        public string Contactname { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Zipcode { get; set; }
        public int? Cityid { get; set; }
        public int? Balancedue { get; set; }
    }
}
