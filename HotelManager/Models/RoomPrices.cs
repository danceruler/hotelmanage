using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace HotelManager.Models
{
    [Table("RoomPrices")]
    public class RoomPrice
    {
        [Key]
        public Guid ID { get; set; }
        public string roomtypeID { get;set;}
        public string roomtypename { get; set; }
        public string fullprice { get; set; }
        public string startprice { get; set; }
        public string priceforunitime { get; set; }
        public string sealsum { get; set; }
        public string adviceprice { get; set; }
        public string breakfastvoucher { get; set; }
        public string other { get; set; }
    }
}
