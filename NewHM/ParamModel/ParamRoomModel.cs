using NewHM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewHM.ParamModel
{
    /// <summary>
    /// 创建房间类型模型类
    /// </summary>
    public class CreateRoomTypeModel
    {
        public string Name { get; set; }
        public int Cap { get; set; }
        public decimal DayPrice { get; set; }
        public int BreakfastVoucher { get; set; }
        public string Other { get; set; }
    }

    /// <summary>
    /// 创建房间模型类
    /// </summary>
    public class CreateRoomModel
    {
        public string Name { get; set; }
        public int CanUse { get; set; }
        public int Floor { get; set; }
        public int Column { get; set; }
        public RoomType Type { get; set; }
        public HMBlock block { get; set; }
    }

    public class CreateHotelUserModel
    {
        public string UserName { get; set; }
        public string Psw { get; set; }
        public int Sex { get; set; }
        public int Level { get; set; }
    }
}
