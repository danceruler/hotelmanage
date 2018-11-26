using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace HotelManager.Models
{
    [Table("RoomStates")]
    public class RoomStateModel
    {
        [Key]
        public Guid StateID { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
    }
}
