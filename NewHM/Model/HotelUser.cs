using MongoDB.Bson;
using NewHM.Help;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewHM.Model
{
    /// <summary>
    /// 用户
    /// </summary>
    [Table("HotelUser")]
    public class HotelUser
    {
        [Key]
        public int id { get; set; }
        public string UserName { get; set; }
        public string Psw { get; set; }
        public int Sex { get; set; }
        public int Level { get; set; }
        public string MenuPowers { get; set; }
        public string TablePowers { get; set; }
    }

    /// <summary>
    /// 用户菜单权限
    /// </summary>
    [Table("HotelMenuPower")]
    public class HotelMenuPower
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
        public string color { get; set; }
        public string img { get; set; }
    }

    /// <summary>
    /// 用户报表权限
    /// </summary>
    [Table("HotelTablePower")]
    public class HotelTablePower
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
    }

    /// <summary>
    /// 等级默认权限
    /// </summary>
    [Table("HotelUserLevelPowers")]
    public class HotelUserLevelPowers
    {
        [Key]
        public int Level { get; set; }
        public string MenuPowers { get; set; }
        public string TablePowers { get; set; }
    }
}
