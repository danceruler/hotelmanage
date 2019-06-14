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
    /// 订单信息
    /// </summary>
    [Table("Tran")]
    public class Tran
    {
        [Key]
        public int id { get; set; }
        public DateTime transtime { get; set; }
        public int roomId { get; set; }
        public DateTime startime { get; set; }
        public DateTime endtime { get; set; }
        public string customIDs { get; set; }
        public decimal balance { get; set; }
        public string remarks { get; set; }
        public string paytype { get; set; }
        public string opentype { get; set; }
        public decimal money { get; set; }
        public DateTime expectendtime { get; set; }
        public int IsDoing { get; set; }
        public int bookID { get; set; }
        public string BillIds { get; set; }
    }


    /// <summary>
    /// 账单信息
    /// </summary>
    [Table("Bill")]
    public class Bill
    {
        [Key]
        public int id { get; set; }
        public DateTime createtime { get; set; }
        public string bussinesstype { get; set; }
        public string paytype { get; set; }
        public DateTime endtime { get; set; }
        public string specinfo { get; set; }
        public int paystate { get; set; }
        public int count { get; set; }
        public decimal money { get; set; }
        public string roomids { get; set; }
        public string remark { get; set; }
        public int optionUserid { get; set; }
    }

    /// <summary>
    /// 总订单
    /// </summary>
    [Table("Order")]
    public class Order
    {
        [Key]
        public int id { get; set; }
        public string tranIds { get; set; }
    }


    /// <summary>
    /// 预定订单
    /// </summary>
    [Table("BookTran")]
    public class BookTran
    {
        [Key]
        public int id { get; set; }
        public DateTime transtime { get; set; }
        public DateTime createtime { get; set; }
        public DateTime expectStartime { get; set; }
        public int IsPlan { get; set; }
        public int IsMovein { get; set; }

        public string roomIDs { get; set; }
        public string customIDs { get; set; }
        public string type { get; set; }
        public string remarks { get; set; }
    }

    /// <summary>
    /// 全天房入住标准
    /// </summary>
    [Table("ValueRule_fullday")]
    public class ValueRule_fullday
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string describe { get; set; }
        public int exitroom_type { get; set; }
        public string exitroom_time { get; set; }
        public string starthalfprice_time { get; set; }
        public string startprice_time { get; set; }
        public int confirm_fulldayprice_time_type { get; set; }
        public string confirm_fulldayprice_time { get; set; }
        public string after_exitroom_charge_time { get; set; }
        public int after_exitroom_charge_type { get; set; }
        public int addprice_fullday_type { get; set; }
        public string add_fullday_time { get; set; }
        public int confirm_addprice_fullday_type { get; set; }
        public string confirm_add_fullday_time { get; set; }
        public int IsSeal { get; set; }
        public string _24rotate_startprice_validtime { get; set; }
        public string _24rorate_fullprice_time { get; set; }
        public int IsUse { get; set; }
    }
    /// <summary>
    /// 钟点房入住标准
    /// </summary>
    [Table("ValueRule_hour")]
    public class ValueRule_hour
    { 
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string describe { get; set; }
        public string duration { get; set; }
        public int breakfastvoucher { get; set; }
        public int IsLimitTime { get; set; }
        public string startime { get; set; }
        public string endtime { get; set; }
        public string start_charge_halfprice_time { get; set; }
        public string start_charge_fullprice_time { get; set; }
        public string after_exitroom_charge_time { get; set; }
        public int IsSeal { get; set; }
        public string after_exitroom_transtonormal_time { get; set; }
        public int roompriceID { get; set; }
        public int IsUse { get; set; }
    }
    /// <summary>
    /// 特殊房入住标准
    /// </summary>
    [Table("ValueRule_special")]
    public class ValueRule_special
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string exitroom_time { get; set; }
        public string duration_warn_advice { get; set; }
        public string breakfastvoucher { get; set; }
        public string describe { get; set; }
        public string IsAllowTime { get; set; }
        public string startime { get; set; }
        public string endtime { get; set; }
        public string start_charge_halfprice_time { get; set; }
        public string start_charge_fullprice_time { get; set; }
        public string after_exitroom_charge_time { get; set; }
        public string after_exitroom_charge_type { get; set; }
        public string after_exitroom_transtonormal_time { get; set; }
        public int roompriceID { get; set; }
        public int IsUse { get; set; }
    }
}
