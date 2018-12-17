using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HotelManager.Models
{
    [Table("Persons")]
    public class Person
    {
        [XmlAttribute]
        [Key]
        public Guid personID { set; get; }
        public string Name { set; get; }
        public string password { set; get; }
        public string sex { set; get; }
        public string level { set; get; }
        public string Type { get; set; }

    }
}
