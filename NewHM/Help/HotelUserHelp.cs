using NewHM.db;
using NewHM.Model;
using NewHM.ParamModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewHM.Help
{
    class HotelUserHelp
    {
        private static DatabaseContext db = new DatabaseContext();

        public static void AddHotelUser(CreateHotelUserModel createModel)
        {
            var levelPowers = db.HotelUserLevelPowers.SingleOrDefault(t => t.Level == createModel.Level);
            HotelUser hotelUser = new HotelUser();
            hotelUser.UserName = createModel.UserName;
            hotelUser.Psw = createModel.Psw;
            hotelUser.Sex = createModel.Sex;
            hotelUser.Level = createModel.Level;
            hotelUser.MenuPowers = levelPowers.MenuPowers;
            hotelUser.TablePowers = levelPowers.TablePowers;
            db.HotelUser.Add(hotelUser);
            db.SaveChanges();
        }
    }
}
