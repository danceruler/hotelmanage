using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Models
{
    [Table("Customers")]
    public class Customer
    {
        public string Name { get; set; }
        public string sex { get; set; }
        [Key]
        public string identification { get; set; }
        public string image { get; set; }
        public string state { get; set; }
        public string vipid { get; set; }
        public string foodcoupon1 { get; set; }
        public string remarks { get; set; }
        public string viptypeID { get; set; }
        public string viptypename { get; set; }
        public string password { get; set; }

    }
}
