using MyControl;
using NewHM.db;
using NewHM.Help;
using NewHM.Model;
using NewHM.ParamModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NewHM
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        

            //var db = new DatabaseContext();

            //入住生成订单


            //添加钟点房计费标准
            //ValueRule_hour valueRule_Hour = new ValueRule_hour();
            //valueRule_Hour.name = "散客钟点房";
            //valueRule_Hour.describe = "测试";
            //valueRule_Hour.duration = "10800";
            //valueRule_Hour.breakfastvoucher = 0;
            //valueRule_Hour.IsLimitTime = 1;
            //valueRule_Hour.startime = "12:00";
            //valueRule_Hour.endtime = "20:00";
            //valueRule_Hour.start_charge_halfprice_time = "60";
            //valueRule_Hour.start_charge_fullprice_time = "60";
            //valueRule_Hour.after_exitroom_charge_time = "0";
            //valueRule_Hour.after_exitroom_transtonormal_time = "10800";
            //valueRule_Hour.IsSeal = 0;
            //RoomPrice roomPrice = new RoomPrice();
            //db.RoomPrice.Add(roomPrice);
            //db.SaveChanges();
            //var roomtypes = db.RoomType.ToList();
            //string ids = "";
            //for (int i = 0; i < roomtypes.Count(); i++)
            //{
            //    RoomPriceInfo roompriceinfo = new RoomPriceInfo();
            //    roompriceinfo.RoomTypeId = roomtypes[i].id;
            //    roompriceinfo.RoomPriceId = roomPrice.id;
            //    //全价
            //    roompriceinfo.DayPrice = roomtypes[i].DayPrice * 0.5m;
            //    roompriceinfo.AddPriceForUnitime = roomtypes[i].AddPriceForUnitime;
            //    roompriceinfo.AdvicePrice = roomtypes[i].AdvicePrice * 0.5m;
            //    roompriceinfo.MaxAddPrice = roomtypes[i].MaxAddPrice;
            //    roompriceinfo.BreakfastVoucher = roomtypes[i].BreakfastVoucher;
            //    roompriceinfo.StartPrice = roomtypes[i].StartPrice * 0.5m;
            //    db.RoomPriceInfo.Add(roompriceinfo);
            //    db.SaveChanges();
            //    ids += i == (roomtypes.Count() - 1) ? roompriceinfo.id.ToString() : (roompriceinfo.id + ",");
            //}
            //roomPrice.RoomPriceInfos = ids;
            //valueRule_Hour.roompriceID = roomPrice.id;
            //valueRule_Hour.IsSeal = 1;
            //valueRule_Hour.IsUse = 1;
            //db.ValueRule_hour.Add(valueRule_Hour);

            //添加会员类别
            //VipType vipType = new VipType();
            //vipType.Name = "黄金会员";
            //vipType.Money = 100;
            //vipType.Remark = "测试";
            //vipType.ValueRuleId = 1;
            //vipType.CanInvest = 1;
            //vipType.CanOverdraw = 0;
            ////添加该类会员房价
            //var roomtypes = db.RoomType.ToList();
            //RoomPrice roomPrice = new RoomPrice();
            //db.RoomPrice.Add(roomPrice);
            //db.SaveChanges();
            //string ids = "";
            //for(int i = 0; i < roomtypes.Count(); i++)
            //{
            //    RoomPriceInfo roomPriceInfo = new RoomPriceInfo();
            //    roomPriceInfo.RoomTypeId = roomtypes[i].id;
            //    roomPriceInfo.RoomPriceId = roomPrice.id;
            //    roomPriceInfo.DayPrice = roomtypes[i].DayPrice* 0.95M;
            //    roomPriceInfo.AddPriceForUnitime = roomtypes[i].AddPriceForUnitime * 0.95M;
            //    roomPriceInfo.AdvicePrice = roomtypes[i].AdvicePrice * 0.95M;
            //    roomPriceInfo.MaxAddPrice = roomtypes[i].MaxAddPrice * 0.95M;
            //    roomPriceInfo.BreakfastVoucher = roomtypes[i].BreakfastVoucher;
            //    roomPriceInfo.StartPrice = roomtypes[i].StartPrice * 0.95M;
            //    db.RoomPriceInfo.Add(roomPriceInfo);
            //    db.SaveChanges();
            //    ids += i == (roomtypes.Count() - 1) ? roomPriceInfo.id.ToString() : (roomPriceInfo.id + ",");
            //}
            //roomPrice.RoomPriceInfos = ids;
            //vipType.RoomPriceId = roomPrice.id;
            //vipType.IsUse = 1;
            //db.VipType.Add(vipType);

            //添加全天房计费标准
            //ValueRule_fullday valueRule_Fullday = new ValueRule_fullday();
            //valueRule_Fullday.name = "散客入住标准";
            //valueRule_Fullday.describe = "测试";
            ////0 固定时间，1 24小时，2 24小时轮转计费
            //valueRule_Fullday.exitroom_type = 0;
            //valueRule_Fullday.exitroom_time = "14:00";
            //valueRule_Fullday.starthalfprice_time = "60";
            //valueRule_Fullday.startprice_time = "60";
            ////0 固定时间 1 入住后
            //valueRule_Fullday.confirm_fulldayprice_time_type = 1;
            //valueRule_Fullday.confirm_fulldayprice_time = "60";
            ////0 按小时 1 半日租
            //valueRule_Fullday.after_exitroom_charge_type = 0;
            //valueRule_Fullday.after_exitroom_charge_time = "600";
            ////0 固定时间 1超过退房时间
            //valueRule_Fullday.addprice_fullday_type = 1;
            //valueRule_Fullday.add_fullday_time = "7200";
            ////0 固定时间 1超过退房时间
            //valueRule_Fullday.confirm_addprice_fullday_type = 1;
            //valueRule_Fullday.add_fullday_time = "7200";

            //valueRule_Fullday.IsSeal = 1;
            //valueRule_Fullday.IsUse = 1;
            //db.ValueRule_fullday.Add(valueRule_Fullday);


            //新增用户
            //CreateHotelUserModel createModel = new CreateHotelUserModel();
            //createModel.UserName = "前台";
            //createModel.Psw = "123456";
            //createModel.Sex = 0;
            //createModel.Level = 3;
            //HotelUserHelp.AddHotelUser(createModel);

            //CreateHotelUserModel createModel2 = new CreateHotelUserModel();
            //createModel2.UserName = "管理员";
            //createModel2.Psw = "123456";
            //createModel2.Sex = 1;
            //createModel2.Level = 10;
            //HotelUserHelp.AddHotelUser(createModel2);

            //新增等级权限
            //HotelUserLevelPowers hotelUserLevelPowers1 = new HotelUserLevelPowers();
            //hotelUserLevelPowers1.Level = 3;
            //hotelUserLevelPowers1.MenuPowers = "2,3";
            //hotelUserLevelPowers1.TablePowers = "4";
            //HotelUserLevelPowers hotelUserLevelPowers2 = new HotelUserLevelPowers();
            //hotelUserLevelPowers2.Level = 10;
            //hotelUserLevelPowers2.MenuPowers = "1,2,3";
            //hotelUserLevelPowers2.TablePowers = "1,2,3,4";
            //db.HotelUserLevelPowers.Add(hotelUserLevelPowers1);
            //db.HotelUserLevelPowers.Add(hotelUserLevelPowers2);

            //新增报表
            //HotelTablePower hotelTablePower1 = new HotelTablePower();
            //hotelTablePower1.Name = "订单报表";
            //HotelTablePower hotelTablePower2 = new HotelTablePower();
            //hotelTablePower2.Name = "财务日报";
            //HotelTablePower hotelTablePower3 = new HotelTablePower();
            //hotelTablePower3.Name = "财务周报";
            //HotelTablePower hotelTablePower4 = new HotelTablePower();
            //hotelTablePower4.Name = "财务月报";
            //db.HotelTablePower.Add(hotelTablePower2);
            //db.HotelTablePower.Add(hotelTablePower3);
            //db.HotelTablePower.Add(hotelTablePower4);
            //db.HotelTablePower.Add(hotelTablePower1);


            //新增菜单
            //HotelMenuPower hotelMenuPower1 = new HotelMenuPower();
            //hotelMenuPower1.Name = "后台管理";
            //HotelMenuPower hotelMenuPower2 = new HotelMenuPower();
            //hotelMenuPower2.Name = "前台营业";
            //HotelMenuPower hotelMenuPower3 = new HotelMenuPower();
            //hotelMenuPower3.Name = "报表中心";
            //db.HotelMenuPower.Add(hotelMenuPower1);
            //db.HotelMenuPower.Add(hotelMenuPower2);
            //db.HotelMenuPower.Add(hotelMenuPower3);

            //新增房间
            //Room room1 = new Room();
            //room1.BlockId = 2;
            //room1.TypeId = 3;
            //room1.Name = "101";
            //room1.CanUse = 1;
            //room1.OpenType = 0;
            //room1.State = 0;
            //room1.Floor = 1;
            //room1.Column = 1;
            //room1.TransId = 0;
            //db.Room.Add(room1);

            //Room room2 = new Room();
            //room2.BlockId = 2;
            //room2.TypeId = 4;
            //room2.Name = "102";
            //room2.CanUse = 1;
            //room2.OpenType = 0;
            //room2.State = 0;
            //room2.Floor = 1;
            //room2.Column = 2;
            //room2.TransId = 0;
            //db.Room.Add(room2);

            //新增房间类型
            //RoomType roomType1 = new RoomType();
            //roomType1.Name = "单人间";
            //roomType1.Cap = 1;
            //db.RoomType.Add(roomType1);
            //RoomType roomType2 = new RoomType();
            //roomType2.Name = "双人间";
            //roomType2.Cap = 2;
            //db.RoomType.Add(roomType2);

            //新增楼信息
            //var new_block = new HMBlock();
            //new_block.code = "001";
            //new_block.Name = "A幢";
            //new_block.address = "Earth";
            //db.HMBlock.Add(new_block);
            //db.SaveChanges();

            //db.SaveChanges();
        }

     
    }
}
