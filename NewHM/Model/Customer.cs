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
    /// 顾客
    /// </summary>
    [Table("Customer")]
    public class Customer
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
        public int Sex { get; set; }
        public string Identification { get; set; }
        public string Image { get; set; }
        public int State { get; set; }
        public int VipId { get; set; }
        public int RoomId { get; set; }
        public string Remarks { get; set; }
        public string Password { get; set; }
    }
    /// <summary>
    /// 会员信息
    /// </summary>
    [Table("VipInfo")]
    public class VipInfo
    {
        [Key]
        public int id { get; set; }
        public int TypeId { get; set; }
        public string TypeName { get; set; }
        public DateTime EndTime { get; set; }
        public decimal FirstMoney { get; set; }
        public decimal RemainMoney { get; set; }
    }
    /// <summary>
    /// 会员类型
    /// </summary>
    [Table("VipType")]
    public class VipType
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
        public decimal Money { get; set; }
        public DateTime Time { get; set; }
        public int ValueRuleId { get; set; }
        public int CanInvest { get; set; }
        public int CanOverdraw { get; set; }
        public int IsUse { get; set; }
        public string Remark { get; set; }
        public int RoomPriceId { get; set; }
    }

}
