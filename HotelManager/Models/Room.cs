using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Models
{
    [Table("Rooms")]
    public class Room
    {
        [Key]
        public Guid roomID { get; set; }
        public string roomname { get; set; }
        public string roomtype { get; set; }
        public string roomdayprice { get; set; }
        public string roomhourprice { get; set; }
        public int roomstate { get; set; }
        public bool CanUse { get; set; }
        public int row { get; set; }
        public int column { get; set; }
        public Nullable<int> OpenType { get; set; }
        public string transid { get; set; }
    }
}
