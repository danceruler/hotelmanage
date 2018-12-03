using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace HotelManager.Models
{
    [Table("ValueRule_fulldays")]
    public class ValueRule_fullday
    {
        [Key]
        public Guid ID { get; set; }
        public string name { get; set; }
        public string describe { get; set; }
        public int exitroom_type { get; set; }
        public string exitroom_time { get; set; }
        public string starthalfprice_time { get; set; }
        public string startprice_time { get; set; }
        public string confirm_fulldayprice_time_type { get; set; }
        public string confirm_fulldayprice_time { get; set; }
        public string after_exitroom_charge_time { get; set; }
        public string after_exitroom_charge_type { get; set; }
        public string addprice_fullday_type { get; set; }
        public string add_fullday_time { get; set; }
        public string confirm_addprice_fullday_type { get; set; }
        public string confirm_add_fullday_time { get; set; }
        public bool IsSeal { get; set; }
        public string _24rotate_startprice_validtime { get; set; }
        public string _24rorate_fullprice_time { get; set; }
        public bool IsUse { get; set; }
    }
}
