using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Models
{
    [Table("Persons")]
    public class Person
    { 
        [Key]
        public Guid personID { set; get; }
        public string Name { set; get; }
        public string password { set; get; }
        public string sex { set; get; }
        public string level { set; get; }

    }
}
