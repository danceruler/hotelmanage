using NewHM.Help;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewHM.Model
{
    /// <summary>
    /// 顾客
    /// </summary>
    public class Customer:BaseEntity
    {
        public string Name { get; set; }
        public string Sex { get; set; }
        public string Identification { get; set; }
        public string Image { get; set; }
        public string State { get; set; }
        public string VipId { get; set; }
        public string Remarks { get; set; }
        public string Password { get; set; }
    }
    /// <summary>
    /// 会员信息
    /// </summary>
    public class VipInfo : BaseEntity
    {
        public string TypeId { get; set; }
        public string TypeName { get; set; }
        public DateTime EndTime { get; set; }
        public decimal FirstMoney { get; set; }
        public decimal RemainMoney { get; set; }
    }
    /// <summary>
    /// 会员类型
    /// </summary>
    public class VipType : BaseEntity
    {
        public string Name { get; set; }
        public decimal Money { get; set; }
        public DateTime Time { get; set; }
        public string ValueRuleId { get; set; }
        public string ValueRuleName { get; set; }
        public int CanInvest { get; set; }
        public int CanOverdraw { get; set; }
        public int IsUse { get; set; }
        public string Remark { get; set; }
    }

}
