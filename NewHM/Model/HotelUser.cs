using MongoDB.Bson;
using NewHM.Help;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewHM.Model
{
    /// <summary>
    /// 用户
    /// </summary>
    public class HotelUser: BaseEntity
    {
        public string UserName { get; set; }
        public string Psw { get; set; }
        public int Sex { get; set; }
        public int Level { get; set; }
        public List<HotelMenuPower> MenuPowers { get; set; }
        public List<HotelTablePower> TablePowers { get; set; }
    }

    /// <summary>
    /// 用户菜单权限
    /// </summary>
    public class HotelMenuPower: BaseEntity
    {
        public string Name { get; set; }
        public int MenuId { get; set; }
    }

    /// <summary>
    /// 用户报表权限
    /// </summary>
    public class HotelTablePower : BaseEntity
    {
        public string Name { get; set; }
        public int TableId { get; set; }
    }

    /// <summary>
    /// 等级默认权限
    /// </summary>
    public class HotelUserLevelPowers: BaseEntity
    {
        public int Level { get; set; }
        public List<HotelMenuPower> MenuPowers { get; set; }
        public List<HotelTablePower> TablePowers { get; set; }
    }
}
