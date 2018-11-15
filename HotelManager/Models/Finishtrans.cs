using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Models
{
    [Table("Finishtranses")]
    public class Finishtrans
    {
        [Key]
        public Guid transID { get; set; }
        public string transtime { get; set; }
        public string roomID { get; set; }
        public string startime { get; set; }
        public string endtime { get; set; }
        public string customID { get; set; }
        public string isVIP { get; set; }
        public string balance { get; set; }
        public string remarks { get; set; }
        public string paytype { get; set; }
    }
}
