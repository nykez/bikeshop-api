using System;


namespace DatabaseApi.Dtos {
	public class BicycleToUpdate {
        public int? Customerid { get; set; }
        public string Modeltype { get; set; }
        public int? Paintid { get; set; }
        public int? Framesize { get; set; }
        public DateTime? Orderdate { get; set; }
        public DateTime? Startdate { get; set; }
        public DateTime? Shipdate { get; set; }
        public int? Shipemployee { get; set; }
        public int? Frameassembler { get; set; }
        public int? Painter { get; set; }
        public string Construction { get; set; }
        public int? Waterbottlebrazeons { get; set; }
        public string Customname { get; set; }
        public string Letterstyleid { get; set; }
        public int? Storeid { get; set; }
        public int? Employeeid { get; set; }
        public int? Toptube { get; set; }
        public int? Chainstay { get; set; }
        public int? Headtubeangle { get; set; }
        public int? Seattubeangle { get; set; }
        public int? Listprice { get; set; }
        public int? Saleprice { get; set; }
        public int? Salestax { get; set; }
        public string Salestate { get; set; }
        public int? Shipprice { get; set; }
        public int? Frameprice { get; set; }
        public int? Componentlist { get; set; }
    }
}
