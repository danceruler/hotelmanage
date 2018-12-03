using Caliburn.Micro;
using HotelManager.Helper;
using HotelManager.Models;
using HotelManager.ViewModels.MainMenu.Pages.RoomState;
using HotelManager.Views.MainMenu.Pages.RoomState;
using Panuon.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HotelManager.Views.FunctionWindow
{
    /// <summary>
    /// ChangeRoomStateWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ChangeRoomStateWindow : Window
    {
        //这个窗口不用viewmodel了
        private int isclosetrans;
        private Room thisroom;
        private RoomStatePage thispage;
        public BindableCollection<PUComboBoxItemModel> StateList = new BindableCollection<PUComboBoxItemModel>();

        public ChangeRoomStateWindow(Room room, RoomStatePage page)
        {
            InitializeComponent();
            isclosetrans = 0;
            thisroom = room;
            thispage = page;
            PUComboBoxItemModel selecteditem = new PUComboBoxItemModel();
            using (RetailContext context = new RetailContext())
            {
                List<RoomStateModel> roomstates = context.RoomStates.ToList();
                List<int> afterstates = RoomHelper.NowState_AfterState[room.roomstate];
                List<string> afterstates_string = new List<string>();
                foreach(int i in afterstates)
                {
                    afterstates_string.Add(RoomHelper.StateConfig[i]);
                }
                foreach (RoomStateModel rsm in roomstates)
                {
                    if (afterstates_string.Contains(rsm.Name))
                    {
                        PUComboBoxItemModel pUComboBoxItemModel = new PUComboBoxItemModel()
                        {
                            Header = rsm.Name,
                            Value = rsm.Name,
                            CanDelete = false,
                        };
                        StateList.Add(pUComboBoxItemModel);
                        if (rsm.Name == RoomHelper.StateConfig[thisroom.roomstate]) selecteditem = pUComboBoxItemModel;
                    }
                    
                }
            }
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            StateCombobox.BindingItems = StateList;
            StateCombobox.Text = selecteditem.Header;
        }
        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            int beforestate = thisroom.roomstate;
            int afterstate = RoomHelper.StateConfig2[StateCombobox.Text];
            if(beforestate != afterstate)
            {
                if((beforestate == 1|| beforestate == 2 || beforestate == 3)&& (afterstate == 5 || afterstate == 6))
                {
                    MessageBoxResult dr = MessageBox.Show("该修改将会自动将该房进行退房操作，确认修改吗？", "提示", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                    if (dr == MessageBoxResult.OK)
                    {
                        
                        RoomHelper.exitRoom2(thisroom.roomID,afterstate);
                        this.Close();
                    }

                }
                else
                {
                    changeState(thisroom.roomID, afterstate);
                    this.Close();
                }
            }
        }
        private void changeState(Guid roomid,int state)
        {
            
            string changeroom_sql = string.Format("update rooms set roomstate = {1} where  UPPER(HEX([roomID]))='{0}'", roomid.ConvertGuid(), state);
            using (RetailContext context = new RetailContext())
            {
                context.Database.ExecuteSqlCommand(changeroom_sql);
                context.SaveChanges();
            }
            Pg_RoomStateViewModel infoViewModel = thispage.DataContext as Pg_RoomStateViewModel;
            infoViewModel.ReFlashRoomInfo();
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            // 获取鼠标相对位置 
            Point positionToTite = e.GetPosition(titlebar);
            Point positionToCloseIcon = e.GetPosition(closeicon);

            if (e.LeftButton == MouseButtonState.Pressed)
            {
                // 如果鼠标位置在标题栏内，允许拖动 
                if (positionToTite.X >= 0 && positionToTite.X < titlebar.ActualWidth && positionToTite.Y >= 0 && positionToTite.Y < titlebar.ActualHeight)
                {
                    this.DragMove();
                }
            }

            if (e.LeftButton == MouseButtonState.Released)
            {
                if (positionToCloseIcon.X >= 0 && positionToCloseIcon.X < closeicon.ActualWidth && positionToCloseIcon.Y >= 0 && positionToCloseIcon.Y < closeicon.ActualHeight)
                {
                    this.Close();
                }
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            WhileMouseMoveTrans(closeicongrid, closeicon, e, 1.5, 90, ref isclosetrans);

        }

        //当鼠标移动到Image上时旋转控件,旋转时间默认0.3秒
        //flag 默认0为未旋转，1为已旋转
        public void WhileMouseMoveTrans(Grid border, Image control, MouseEventArgs e, double speed, int angle, ref int flag)
        {
            Point position = e.GetPosition(border);
            Point position2 = e.GetPosition(control);
            if (position2.X >= 0 && position2.X < control.ActualWidth && position2.Y >= 0 && position2.Y < control.ActualHeight)
            {
                if (flag == 0)
                {
                    Storyboard storyboard = new Storyboard();//创建故事板
                    DoubleAnimation doubleAnimation = new DoubleAnimation();//实例化一个Double类型的动画
                    RotateTransform rotate = new RotateTransform();//旋转转换实例
                    control.RenderTransform = rotate;//给图片空间一个转换的实例
                    //storyboard.RepeatBehavior = RepeatBehavior.Forever;//设置重复为 一直重复
                    storyboard.SpeedRatio = speed;//播放的数度
                                                  //设置从0 旋转360度
                    doubleAnimation.From = 0;
                    doubleAnimation.To = angle;
                    doubleAnimation.Duration = new Duration(new TimeSpan(0, 0, 0, 0, 300));//播放时间长度为2秒
                    Storyboard.SetTarget(doubleAnimation, control);//给动画指定对象
                    Storyboard.SetTargetProperty(doubleAnimation,
                        new PropertyPath("RenderTransform.Angle"));//给动画指定依赖的属性
                    storyboard.Children.Add(doubleAnimation);//将动画添加到动画板中
                    storyboard.Begin(control);//启动动画
                    flag = 1;
                }
            }
            if (position.X < 0 || position.X >= border.ActualWidth || position.Y < 0 || position.Y >= border.ActualHeight)
            {
                flag = 0;
            }
        }

        
    }
}
