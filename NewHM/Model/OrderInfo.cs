using NewHM.Help;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewHM.Model
{
    /// <summary>
    /// 订单信息
    /// </summary>
    public class Trans : BaseEntity
    {
        public string transtime { get; set; }
        public List<string> roomIDs { get; set; }
        public string startime { get; set; }
        public string endtime { get; set; }
        public List<string> customIDs { get; set; }
        public string balance { get; set; }
        public string remarks { get; set; }
        public string paytype { get; set; }
        public string opentype { get; set; }
        public string money { get; set; }
        public string expectendtime { get; set; }
        public bool IsDoing { get; set; }
        public string bookID { get; set; }
        public List<Bills> Bills { get; set; }
    }
    

    /// <summary>
    /// 账单信息
    /// </summary>
    public class Bills : BaseEntity
    {
        public string createtime { get; set; }
        public string bussinesstype { get; set; }
        public string paytype { get; set; }
        public string endtime { get; set; }
        public string specinfo { get; set; }
        public int paystate { get; set; }
        public int count { get; set; }
        public decimal money { get; set; }
        public string roomid { get; set; }
        public string remark { get; set; }
        public string optionUserid { get; set; }
        public HotelUser hotelUser { get; set; }
    }


    /// <summary>
    /// 预定订单
    /// </summary>
    public class BookTrans : BaseEntity
    {
        public string transtime { get; set; }
        public DateTime createtime { get; set; }
        public DateTime expectStartime { get; set; }
        public int IsPlan { get; set; }
        public int IsMovein { get; set; }

        public List<string> roomIDs { get; set; }
        public List<string> customIDs { get; set; }
        public string type { get; set; }
        public string remarks { get; set; }
    }

    /// <summary>
    /// 全天房入住标准
    /// </summary>
    public class ValueRule_fullday:BaseEntity
    {
        public string name { get; set; }
        public string describe { get; set; }
        public int exitroom_type { get; set; }
        public string exitroom_time { get; set; }
        public string starthalfprice_time { get; set; }
        public string startprice_time { get; set; }
        public string confirm_fulldayprice_time_type { get; set; }
        public string confirm_fulldayprice_time { get; set; }
        public string after_exitroom_charge_time { get; set; }
        public string after_exitroom_charge_type { get; set; }
        public string addprice_fullday_type { get; set; }
        public string add_fullday_time { get; set; }
        public string confirm_addprice_fullday_type { get; set; }
        public string confirm_add_fullday_time { get; set; }
        public bool IsSeal { get; set; }
        public string _24rotate_startprice_validtime { get; set; }
        public string _24rorate_fullprice_time { get; set; }
        public bool IsUse { get; set; }
    }
    /// <summary>
    /// 钟点房入住标准
    /// </summary>
    public class ValueRule_hour:BaseEntity
    {
        public string name { get; set; }
        public string describe { get; set; }
        public string duration { get; set; }
        public string breakfastvoucher { get; set; }
        public bool IsAllowTime { get; set; }
        public string startime { get; set; }
        public string endtime { get; set; }
        public string start_charge_halfprice_time { get; set; }
        public string start_charge_fullprice_time { get; set; }
        public string after_exitroom_charge_time { get; set; }
        public bool IsSeal { get; set; }
        public string after_exitroom_transtonormal_time { get; set; }
        public string roompriceID { get; set; }
        public bool IsUse { get; set; }
    }
    /// <summary>
    /// 特殊房入住标准
    /// </summary>
    public class ValueRule_special : BaseEntity
    {
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
        public string roompriceID { get; set; }
        public bool IsUse { get; set; }
    }
}
