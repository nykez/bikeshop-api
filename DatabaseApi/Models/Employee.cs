using System;
using System.Collections.Generic;

namespace DatabaseApi.Models
{
    public partial class Employee
    {
        public decimal? Employeeid { get; set; }
        public string Taxpayerid { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Homephone { get; set; }
        public string Address { get; set; }
        public string Zipcode { get; set; }
        public decimal? Cityid { get; set; }
        public DateTime? Datehired { get; set; }
        public DateTime? Datereleased { get; set; }
        public decimal? Currentmanager { get; set; }
        public decimal? Salarygrade { get; set; }
        public decimal? Salary { get; set; }
        public string Title { get; set; }
        public string Workarea { get; set; }
    }
}
