using NewHM.Help;
using NewHM.Model;
using NewHM.ParamModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

            //新增管理员

            //新增房间
            var roomtypedb = new MongoDbHelper<RoomType>();
            var roomtypes = roomtypedb.QueryAll();
            var blockdb = new MongoDbHelper<HMBlock>();
            var hmblocks = blockdb.QueryAll();

            CreateRoomModel createModel = new CreateRoomModel();
            createModel.Name = "101";
            createModel.CanUse = 1;
            createModel.Floor = 1;
            createModel.Column = 1;
            createModel.block = hmblocks[0];
            createModel.Type = roomtypes[0];
            RoomHelp.CreateRoom(createModel);

            //新增房间类型
            //CreateRoomTypeModel createModel = new CreateRoomTypeModel();
            //createModel.Name = "双人标间";
            //createModel.Cap = 2;
            //createModel.DayPrice = 150;
            //createModel.BreakfastVoucher = 2;
            //createModel.Other = "";
            //RoomHelp.CreateRoomType(createModel);

            //新增楼信息
            //BlockHelp.CreateBlock("A楼","001");
        }
    }
}
