namespace DatabaseApi.Dtos
{
    public class RetailstoreToUpdate
    {
        /// <summary>
        /// Customer DTO (Data transfer object)
        /// </summary>
        /// 
        
        public string Storename { get; set; }
        public string Phone { get; set; }
        public string Contactfirstname { get; set; }
        public string Contactlastname { get; set; }
        public string Address { get; set; }
        public string Zipcode { get; set; }
        public int? Cityid { get; set; }
    }
}
