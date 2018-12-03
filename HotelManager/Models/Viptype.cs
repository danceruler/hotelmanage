using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace HotelManager.Models
{
    [Table("Viptypes")]
    public class Viptype
    {
        [Key]
        public Guid ID { get; set; }
        public int level { get; set; }
        public bool IsRecharge { get; set; }
        public string balance { get; set; }
        public string other { get; set; }
        public string roompriceID { get; set; }
        public string valueruleID { get; set; }
    }
}
