using System;
using System.Collections.Generic;

namespace DatabaseApi
{
    public partial class Bicycle
    {
        public Bicycle()
        {
            Bicycletubeusage = new HashSet<Bicycletubeusage>();
            Bikeparts = new HashSet<Bikeparts>();
            Biketubes = new HashSet<Biketubes>();
        }

        public int Serialnumber { get; set; }
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

        public virtual Customer Customer { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Letterstyle Letterstyle { get; set; }
        public virtual Modeltype ModeltypeNavigation { get; set; }
        public virtual Paint Paint { get; set; }
        public virtual Retailstore Store { get; set; }
        public virtual ICollection<Bicycletubeusage> Bicycletubeusage { get; set; }
        public virtual ICollection<Bikeparts> Bikeparts { get; set; }
        public virtual ICollection<Biketubes> Biketubes { get; set; }
    }
}
