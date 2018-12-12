using HotelManager.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelManager.Helper
{
    public static class ToServerDataHelper
    {
        /// <summary>
        /// 同步房间信息
        /// </summary>
        public static void SynchronizeRoomInfo()
        {
            using (RetailContext context = new RetailContext())
            {
                Room[] rooms = context.Rooms.ToArray();
                string data = JsonConvert.SerializeObject(rooms);
                string result = httpRequestHelper.PostRequest("http://47.107.69.129:1996/api/ClientToServer/SynchronizeRoomInfo", data, "application/json");
                //当房间信息同步失败时的操作
                if (result != "ok")
                {

                }
            }
        }

        /// <summary>
        /// 同步房间状态信息
        /// </summary>
        public static void SynchronizeRoomStateInfo()
        {
            using (RetailContext context = new RetailContext())
            {
                RoomStateModel[] roomStateModels = context.RoomStates.ToArray();
                string data = JsonConvert.SerializeObject(roomStateModels);
                string result = httpRequestHelper.PostRequest("http://47.107.69.129:1996/api/ClientToServer/SynchronizeRoomStateInfo", data, "application/json");
                //当房间信息同步失败时的操作
                if (result != "ok")
                {

                }
            }
        }

        /// <summary>
        /// 同步房间类型信息
        /// </summary>
        public static void SynchronizeRoomTypeInfo()
        {
            using (RetailContext context = new RetailContext())
            {
                RoomType[] roomTypes = context.RoomTypes.ToArray();
                string data = JsonConvert.SerializeObject(roomTypes);
                string result = httpRequestHelper.PostRequest("http://47.107.69.129:1996/api/ClientToServer/SynchronizeRoomTypeInfo", data, "application/json");
                //当房间信息同步失败时的操作
                if (result != "ok")
                {

                }
            }
        }

        /// <summary>
        /// 同步人员信息
        /// </summary>
        public static void SynchronizePersonInfo()
        {
            using (RetailContext context = new RetailContext())
            {
                Person[] people = context.Persons.ToArray();
                string data = JsonConvert.SerializeObject(people);
                string result = httpRequestHelper.PostRequest("http://47.107.69.129:1996/api/ClientToServer/SynchronizePersonInfo", data, "application/json");
                //当房间信息同步失败时的操作
                if (result != "ok")
                {

                }
            }
        }

        /// <summary>
        /// 同步订单信息
        /// </summary>
        public static void SynchronizeTransInfo()
        {
            using (RetailContext context = new RetailContext())
            {
                Finishtrans[] finishtrans = context.Finishtranses.ToArray();
                string data = JsonConvert.SerializeObject(finishtrans);
                string result = httpRequestHelper.PostRequest("http://47.107.69.129:1996/api/ClientToServer/SynchronizeTransInfo", data, "application/json");
                //当房间信息同步失败时的操作
                if (result != "ok")
                {

                }
            }
        }
    }
}
