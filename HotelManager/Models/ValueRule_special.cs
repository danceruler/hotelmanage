using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace HotelManager.Models
{
    [Table("ValueRule_specials")]
    public class ValueRule_special
    {
        [Key]
        public Guid ID { get; set; }
        public string name { get; set; }
        public string exitroom_time { get; set; }
        public string duration_warn_advice { get; set; }
        public string breakfastvoucher { get; set; }
        public string describe { get; set; }
        public string IsAllowTime { get; set; }
        public string startime { get; set; }
        public string endtime { get; set; }
        public string start_charge_halfprice_time { get; set; }
        public string start_charge_fullprice_time { get; set; }
        public string after_exitroom_charge_time { get; set; }
        public string after_exitroom_charge_type { get; set; }
        public string after_exitroom_transtonormal_time { get; set; }
        public string roompriceID { get; set; }
        public bool IsUse { get; set; }
    }
}
