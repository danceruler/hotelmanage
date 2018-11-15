using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Models
{
    [Table("Vipinfos")]
    public class Vipinfo
    {
        [Key]
        public string customID { get; set; }
        public string balance { get; set; }

    }
}
