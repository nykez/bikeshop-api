using System;
using System.Collections.Generic;

namespace DatabaseApi.Models
{
    public partial class Bicycle
    {
        public decimal? Serialnumber { get; set; }
        public decimal? Customerid { get; set; }
        public string Modeltype { get; set; }
        public decimal? Paintid { get; set; }
        public decimal? Framesize { get; set; }
        public DateTime? Orderdate { get; set; }
        public DateTime? Startdate { get; set; }
        public DateTime? Shipdate { get; set; }
        public decimal? Shipemployee { get; set; }
        public decimal? Frameassembler { get; set; }
        public decimal? Painter { get; set; }
        public string Construction { get; set; }
        public decimal? Waterbottlebrazeons { get; set; }
        public string Customname { get; set; }
        public string Letterstyleid { get; set; }
        public decimal? Storeid { get; set; }
        public decimal? Employeeid { get; set; }
        public decimal? Toptube { get; set; }
        public decimal? Chainstay { get; set; }
        public decimal? Headtubeangle { get; set; }
        public decimal? Seattubeangle { get; set; }
        public decimal? Listprice { get; set; }
        public decimal? Saleprice { get; set; }
        public decimal? Salestax { get; set; }
        public string Salestate { get; set; }
        public decimal? Shipprice { get; set; }
        public decimal? Frameprice { get; set; }
        public decimal? Componentlist { get; set; }
    }
}
