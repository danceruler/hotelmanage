using NewHM.Model;
using NewHM.ParamModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace NewHM.Help
{
    class RoomHelp
    {
        /// <summary>
        /// 新增房间类型
        /// </summary>
        /// <param name="createModel"></param>
        public static void CreateRoomType(CreateRoomTypeModel createModel)
        {
            var db = new MongoDbHelper<RoomType>();
            var roomtye = new RoomType();
            roomtye.Name = createModel.Name;
            roomtye.Cap = createModel.Cap;
            roomtye.DayPrice = createModel.DayPrice;
            roomtye.BreakfastVoucher = createModel.BreakfastVoucher;
            roomtye.Other = "";
            db.Insert(roomtye);
        }
        /// <summary>
        /// 新增房间
        /// </summary>
        /// <param name="createModel"></param>
        public static void CreateRoom(CreateRoomModel createModel)
        {
            var db = new MongoDbHelper<Room>();
            var room = new Room();
            room.Name = createModel.Name;
            room.CanUse = createModel.CanUse;
            room.Floor = createModel.Floor;
            room.Column = createModel.Column;
            room.Type = createModel.Type;
            room.block = createModel.block;
            db.Insert(room);
        }
    }

    public static class BlockHelp
    {
        /// <summary>
        /// 新增楼
        /// </summary>
        /// <param name="name"></param>
        /// <param name="code"></param>
        public static void CreateBlock(string name,string code)
        {
            var db = new MongoDbHelper<HMBlock>();
            var block = new HMBlock();
            block.Name = name;
            block.code = code;
            block.address = "";
            db.Insert(block);
        }
    }
}
