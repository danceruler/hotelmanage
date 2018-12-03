using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace HotelManager.Models
{
    [Table("ValueRule_hours")]
    public class ValueRule_hour
    {
        [Key]
        public Guid ID { get; set; }
        public string name { get; set; }
        public string describe { get; set; }
        public string duration { get; set; }
        public string breakfastvoucher { get; set; }
        public bool IsAllowTime { get; set; }
        public string startime { get; set; }
        public string endtime { get; set; }
        public string start_charge_halfprice_time { get; set; }
        public string start_charge_fullprice_time { get; set; }
        public string after_exitroom_charge_time { get; set; }
        public bool IsSeal { get; set; }
        public string after_exitroom_transtonormal_time { get; set; }
        public string roompriceID { get; set; }
        public bool IsUse { get; set; }
    }
}
