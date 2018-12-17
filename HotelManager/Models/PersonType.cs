using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace HotelManager.Models
{
    [Table("PersonTypes")]
    public class PersonType
    {
        [Key]
        public Guid ID { get; set; }
        public string Name { set; get; }
        public string Domains { get; set; }
    }
}
