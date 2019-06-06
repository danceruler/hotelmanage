using NewHM.Model;
using NewHM.ParamModel;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewHM.Help
{
    class HotelUserHelp
    {
        /// <summary>
        /// 新增酒店工作人员
        /// </summary>
        /// <param name="createModel"></param>
        public static void CreateHotelUser(CreateHotelUserModel createModel)
        {
            var db = new MongoDbHelper<HotelUser>();
            var levelToPowerdb = new MongoDbHelper<HotelUserLevelPowers>();
            var hoteluser = new HotelUser();
            hoteluser.UserName = createModel.UserName;
            hoteluser.Psw = createModel.Psw;
            hoteluser.Sex = createModel.Sex;
            hoteluser.Level = createModel.Level;

            var levelpower = levelToPowerdb.Collection().Find(t => t.Level == createModel.Level).SingleOrDefault();
            hoteluser.MenuPowers = levelpower.MenuPowers;
            hoteluser.TablePowers = levelpower.TablePowers;
            db.Insert(hoteluser);
        }

        public static void CreateMenuPowers(string name,int id)
        {
            var db = new MongoDbHelper<HotelMenuPower>();
            var menupower = new HotelMenuPower();
            menupower.Name = name;
            menupower.MenuId = id;
            db.Insert(menupower);
        }

        public static void CreateTablePowers(string name, int id)
        {
            var db = new MongoDbHelper<HotelTablePower>();
            var tablepower = new HotelTablePower();
            tablepower.Name = name;
            tablepower.TableId = id;
            db.Insert(tablepower);
        }

        public static void CreateLevelPowers(int level, List<string> menupowerids)
        {
            var db = new MongoDbHelper<HotelUserLevelPowers>();
        }
    }
}
