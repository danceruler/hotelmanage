using NewHM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewHM.ParamModel
{

    /// <summary>
    /// 新增工作人员
    /// </summary>
    public class CreateHotelUserModel
    {
        public string UserName { get; set; }
        public string Psw { get; set; }
        public int Sex { get; set; }
        public int Level { get; set; }
    }

    /// <summary>
    /// 入住信息模型
    /// </summary>
    public class MoveInModel
    {
        //1.全天房 2.钟点房 3.特殊房
        public int OpenType { get; set; }
        //使用的会员信息
        public int CustomerId { get; set; }
        public int ValueRuelId { get; set; }
        public RoomPrice RoomPrice { get; set; }
    }

    /// <summary>
    /// 创建订单模型
    /// </summary>
    public class CreateOrderModel
    {
        public int RoomId { get; set; }
        public string CustomerIds { get; set; }
        //是否有为一起入住的多间房之一 1，主房 2.次房 0.单开
        public int IsCon { get; set; }
        

    }


}
