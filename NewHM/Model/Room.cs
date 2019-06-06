using NewHM.Help;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewHM.Model
{
    /// <summary>
    /// 房间
    /// </summary>
    public class HMBlock : BaseEntity
    {
        public string Name { get; set; }
        public string code { get; set; }
        public string address { get; set; }
    }

    /// <summary>
    /// 房间
    /// </summary>
    public class Room:BaseEntity
    {
        public string Name { get; set; }
        //空洁房，空脏房，维修房，在住洁房，在住脏房，自用房
        public int State { get; set; }
        public int CanUse { get; set; }
        public int Floor { get; set; }
        public int Column { get; set; }
        //空房，预定中，在住
        public int OpenType { get; set; }
        public string TransId { get; set; }

        public RoomType Type { get; set; }
        public HMBlock block { get; set; }
    }
    /// <summary>
    /// 房间类型默认对应数据
    /// </summary>
    public class RoomType : BaseEntity
    {
        public string Name { get; set; }
        public int Cap { get; set; }
        public decimal DayPrice { get; set; }
        public int BreakfastVoucher { get; set; }
        public string Other { get; set; }
    }
    
}
