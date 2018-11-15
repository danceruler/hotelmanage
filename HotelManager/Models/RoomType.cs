using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace HotelManager.Models
{
    [Table("RoomTypes")]
    public class RoomType
    {
        [Key]
        public Guid ID { get; set; }
        public string Name { get; set; }
        public int Cap { get; set; }
        public string Color { get; set; }
        public bool IsChecked { get; set; }
        public bool CanChange { get; set; }

    }
}
