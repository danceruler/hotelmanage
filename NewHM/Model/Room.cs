using NewHM.Help;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewHM.Model
{
    /// <summary>
    /// 楼
    /// </summary>
    [Table("HMBlock")]
    public class HMBlock
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
        public string code { get; set; }
        public string address { get; set; }
    }

    /// <summary>
    /// 房间
    /// </summary>
    [Table("Room")]
    public class Room
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
        //空洁房，空脏房，维修房，在住洁房，在住脏房，自用房
        public int State { get; set; }
        public int CanUse { get; set; }
        public int Floor { get; set; }
        public int Column { get; set; }
        //空房，预定中，在住
        public int OpenType { get; set; }
        public int TransId { get; set; }

        public int TypeId { get; set; }
        public int BlockId { get; set; }
    }
    /// <summary>
    /// 房间类型默认对应数据
    /// </summary>
    [Table("RoomType")]
    public class RoomType
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
        public int Cap { get; set; }
        public string Other { get; set; }
        public decimal StartPrice { get; set; }
        public decimal DayPrice { get; set; }
        public decimal AddPriceForUnitime { get; set; }
        public decimal MaxAddPrice { get; set; }
        public decimal AdvicePrice { get; set; }
        public int BreakfastVoucher { get; set; }
    }

    /// <summary>
    /// 房价信息
    /// </summary>
    [Table("RoomPrice")]
    public class RoomPrice
    {
        [Key]
        public int id { get; set; }
        public string RoomPriceInfos { get; set; }
    }

    /// <summary>
    /// 房价具体信息
    /// </summary>
    [Table("RoomPriceInfo")]
    public class RoomPriceInfo
    {
        [Key]
        public int id { get; set; }
        public int RoomPriceId { get; set; }
        public int RoomTypeId { get; set; }
        public decimal StartPrice { get; set; }
        public decimal DayPrice { get; set; }
        public decimal AddPriceForUnitime { get; set; }
        public decimal MaxAddPrice { get; set; }
        public decimal AdvicePrice { get; set; }
        public int BreakfastVoucher { get; set; }
    }
}
