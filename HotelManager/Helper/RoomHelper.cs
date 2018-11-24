 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using HotelManager.Models;
using System.Windows;
using System.Windows.Media;
using Panuon.UI;
using Caliburn.Micro;
using System.Windows.Input;
using HotelManager.ViewModels;
using System.Windows.Interactivity;
using EventTrigger = System.Windows.Interactivity.EventTrigger;
using System.Windows.Controls.Primitives;
using HotelManager.Views.FunctionWindow;
using System.Windows.Media.Imaging;
using System.Threading.Tasks;

namespace HotelManager.Helper
{
    public class RoomHelper
    {
        static Dictionary<string, SolidColorBrush> ColorsConfig = new Dictionary<string, SolidColorBrush>()
        {
            {"默认(灰色)",Brushes.Gray},
            {"黑色",Brushes.Black},//
            {"白色",Brushes.White},
            {"蓝色",Brushes.Blue},//
            {"红色",Brushes.Red},
            {"黄色",Brushes.Yellow},
            {"绿色",Brushes.Green},
            {"紫色",Brushes.Purple},//
            {"天蓝色",Brushes.SkyBlue},
            {"棕色",Brushes.Brown},//
            {"草绿色",Brushes.SeaGreen},
            {"橘黄色",Brushes.Orange},
            {"橘红色",Brushes.OrangeRed},
            {"粉色",Brushes.HotPink},
        };
        List<Room> rooms = null;
        List<RoomType> roomtypes = null;

        public RoomHelper()
        {
            rooms = new List<Room>();
            roomtypes = new List<RoomType>();
        }

        public void LoadRoomInfoByWhat(Grid grid, int edittype,string what, string row, string type, string state)
        {
            grid.RowDefinitions.Clear();
            grid.ColumnDefinitions.Clear();
            grid.Children.Clear();
            using (RetailContext context = new RetailContext())
            {
                int rows = 0;
                int columns = 0;
                
                //List<Room> rooms = context.Rooms.OrderBy(p => p.row).ToList();
                if(edittype>=0)
                {
                    if (row != "0")
                    {
                        string sql = string.Format("select * from rooms where roomtype like '%{0}%' and roomstate = {1} and row = {2} order by {3}", type, state, row, what);
                        rooms = context.Database.SqlQuery<Room>(sql).ToList();
                    }
                    else
                    {
                        string sql = string.Format("select * from rooms where roomtype like '%{0}%' and roomstate = {1}  order by {3}", type, state, row, what);
                        rooms = context.Database.SqlQuery<Room>(sql).ToList();
                    }
                }
                


                Dictionary<int, List<Room>> roomsbywhat = new Dictionary<int, List<Room>>();
                int cnd = 0;
                for (int i = 0; i < rooms.Count(); i++)
                {
                    if (i == 0)
                    {
                        cnd++;
                        roomsbywhat.Add(cnd, new List<Room>());
                        roomsbywhat[cnd].Add(rooms[i]);
                    }
                    else
                    {
                        switch (what)
                        {
                            case "row":
                                if (rooms[i].row != rooms[i - 1].row)
                                {
                                    cnd++;
                                    roomsbywhat.Add(cnd, new List<Room>());
                                    roomsbywhat[cnd].Add(rooms[i]);
                                }
                                else
                                {
                                    roomsbywhat[cnd].Add(rooms[i]);
                                }
                                break;
                            case "roomtype":
                                if (rooms[i].roomtype != rooms[i - 1].roomtype)
                                {
                                    cnd++;
                                    roomsbywhat.Add(cnd, new List<Room>());
                                    roomsbywhat[cnd].Add(rooms[i]);
                                }
                                else
                                {
                                    roomsbywhat[cnd].Add(rooms[i]);
                                }
                                break;
                            case "roomstate":
                                if (rooms[i].roomstate != rooms[i - 1].roomstate)
                                {
                                    cnd++;
                                    roomsbywhat.Add(cnd, new List<Room>());
                                    roomsbywhat[cnd].Add(rooms[i]);
                                }
                                else
                                {
                                    roomsbywhat[cnd].Add(rooms[i]);
                                }
                                break;
                            default:
                                break;

                        }
                        
                    }
                }
                rows = cnd;
                cnd = 0;
                foreach (int key in roomsbywhat.Keys)
                {
                    if (roomsbywhat[key].Count() >= cnd)
                    {
                        cnd = roomsbywhat[key].Count();
                    }
                }
                columns = cnd;
                for (int i = 0; i < rows; i++)
                {
                    RowDefinition rowDefinition = new RowDefinition();
                    rowDefinition.Height = new GridLength(200);
                    grid.RowDefinitions.Add(rowDefinition); //添加行
                }
                for (int i = 0; i < columns; i++)
                {
                    ColumnDefinition columnDefinition = new ColumnDefinition();
                    columnDefinition.Width = new GridLength(150);
                    grid.ColumnDefinitions.Add(new ColumnDefinition());
                }
                for (int i = 1; i <= rows; i++)
                {
                    roomsbywhat[i].Sort(new IcpColumn());
                    for (int j = 0; j < roomsbywhat[i].Count(); j++)
                    {
                        roomtypes = context.RoomTypes.ToList();
                        if (edittype == 0)
                        {
                            FrameworkElement roominfogrid = MakeRoomInfoBasicCard(roomsbywhat[i][j], i - 1, j,roomtypes);
                            grid.Children.Add(roominfogrid);
                        }
                        else if(edittype == 1)
                        {
                            
                            FrameworkElement roominfogrid = MakeRoomInfoEditCard(roomsbywhat[i][j], i - 1, j, roomtypes);
                            grid.Children.Add(roominfogrid);
                        }else if(edittype == 3)
                        {
                            FrameworkElement roominfogrid = MakeRoomInfoMainCard(roomsbywhat[i][j], i - 1, j,roomtypes);
                            grid.Children.Add(roominfogrid);
                        }
                    }
                }
            }
        }

        public class IcpColumn : IComparer<Room>
        {
            //按价格排序
            public int Compare(Room x, Room y)
            {
                return x.column.CompareTo(y.column);
            }
        }


        public FrameworkElement MakeRoomInfoMainCard(Room room, int row, int column,List<RoomType> roomTypes)
        {
            Border border = new Border();
            border.CornerRadius = new CornerRadius(5, 5, 5, 5);
            border.Margin = new Thickness(10, 10, 10, 10);
            border.Background = new SolidColorBrush(Color.FromRgb(220, 220, 220));
            border.Width = 130;
            border.Height = 180;
            border.SetValue(Grid.RowProperty, row); //设置按钮所在Grid控件的行
            border.SetValue(Grid.ColumnProperty, column); //设置按钮所在Grid控件的列
            DockPanel dockPanel = new DockPanel();

            //主要信息界面
            Grid grid = new Grid();
            for (int i = 0; i < 5; i++)
            {
                RowDefinition rowDefinition = new RowDefinition();
                rowDefinition.Height = new GridLength(36);
                grid.RowDefinitions.Add(rowDefinition); //添加行
            }

            //房间号
            Label roomnamelabel = new Label();
            roomnamelabel.SetValue(Grid.RowProperty, 0);
            roomnamelabel.FontSize = 14;
            roomnamelabel.VerticalAlignment = VerticalAlignment.Center;
            roomnamelabel.HorizontalAlignment = HorizontalAlignment.Center;
            roomnamelabel.Content = room.roomname;
            grid.Children.Add(roomnamelabel);

            //房间类型
            Label roomtypelabel = new Label();
            roomtypelabel.SetValue(Grid.RowProperty, 1);
            roomtypelabel.FontFamily = new FontFamily("楷书");
            roomtypelabel.FontSize = 15;
            roomtypelabel.Height = 36;
            roomtypelabel.Width = 135;
            roomtypelabel.VerticalAlignment = VerticalAlignment.Center;
            roomtypelabel.HorizontalAlignment = HorizontalAlignment.Center;
            roomtypelabel.HorizontalContentAlignment = HorizontalAlignment.Center;
            roomtypelabel.VerticalContentAlignment = VerticalAlignment.Center;
            roomtypelabel.Content = room.roomtype;
            roomtypelabel.BorderThickness = new Thickness(2);
            string color = "";
            foreach (RoomType rt in roomTypes)
            {
                if (rt.Name == room.roomtype)
                {
                    color = rt.Color;
                    break;
                }
            }
            roomtypelabel.Background = ColorsConfig[color];
            //roomtypelabel.BorderBrush = ColorsConfig[color];
            //roomtypelabel.Foreground = ColorsConfig[color];
            if (color == "黑色" || color == "紫色" || color == "棕色" || color == "蓝色")
            {
                roomtypelabel.Foreground = Brushes.White;
            }
            grid.Children.Add(roomtypelabel);

            //房态
            Label roomstatelabel = new Label();
            roomstatelabel.SetValue(Grid.RowProperty, 2);
            roomstatelabel.FontSize = 14;
            roomstatelabel.VerticalAlignment = VerticalAlignment.Center;
            roomstatelabel.HorizontalAlignment = HorizontalAlignment.Center;
            switch (room.roomstate)
            {
                case 0:
                    roomstatelabel.Content = "空房";
                    break;
                default:
                    break;
            }
            grid.Children.Add(roomstatelabel);

            //如果为空房
            if(room.roomstate == 0)
            {
                //日房价
                Label daypricelabel = new Label();
                daypricelabel.SetValue(Grid.RowProperty, 3);
                daypricelabel.Margin = new Thickness(0, -15, 0, 0);
                daypricelabel.FontSize = 10;
                daypricelabel.Content = "日单价";
                grid.Children.Add(daypricelabel);


                Label daypricetextbox = new Label();
                daypricetextbox.SetValue(Grid.RowProperty, 3);
                daypricetextbox.FontSize = 12;
                daypricetextbox.Width = 60;
                daypricetextbox.Height = 25;
                daypricetextbox.HorizontalAlignment = HorizontalAlignment.Left;
                daypricetextbox.Content = room.roomdayprice;
                grid.Children.Add(daypricetextbox);

                //每小时房价
                Label hourpricelabel = new Label();
                hourpricelabel.SetValue(Grid.RowProperty, 3);
                hourpricelabel.Margin = new Thickness(90, -15, 0, 0);
                hourpricelabel.FontSize = 10;
                hourpricelabel.Content = "时单价";
                grid.Children.Add(hourpricelabel);

                Label hourpricetextbox = new Label();
                hourpricetextbox.SetValue(Grid.RowProperty, 3);
                hourpricetextbox.FontSize = 12;
                hourpricetextbox.Width = 60;
                hourpricetextbox.Height = 25;
                hourpricetextbox.HorizontalAlignment = HorizontalAlignment.Right;
                hourpricetextbox.Content = room.roomhourprice;
                hourpricetextbox.HorizontalContentAlignment = HorizontalAlignment.Right;
                grid.Children.Add(hourpricetextbox);

                PUButton openroombutton = new PUButton();
                openroombutton.SetValue(Grid.RowProperty, 4);
                openroombutton.Width = 80;
                openroombutton.Height = 25;
                openroombutton.BorderCornerRadius = new CornerRadius(5, 5, 5, 5);
                openroombutton.Background = Brushes.Gray;
                openroombutton.Margin = new Thickness(0, 0, 0, 10);
                openroombutton.VerticalContentAlignment = VerticalAlignment.Center;
                openroombutton.HorizontalContentAlignment = HorizontalAlignment.Center;
                openroombutton.Content = "Open";
                openroombutton.Click += ToOpenRoom;
                grid.Children.Add(openroombutton);
                

            }

            dockPanel.Children.Add(grid);
            border.Child = dockPanel;
            grid.DataContext = room;
            return border;
        }
        public FrameworkElement MakeRoomInfoBasicCard(Room room,int row,int column, List<RoomType> roomTypes)
        {
            Border border = new Border();
            border.CornerRadius = new CornerRadius(5, 5, 5, 5);
            border.Margin = new Thickness(10, 10, 10, 10);
            border.Background = new SolidColorBrush(Color.FromRgb(220, 220, 220));
            border.Width = 130;
            border.Height = 180;
            border.SetValue(Grid.RowProperty, row); //设置按钮所在Grid控件的行
            border.SetValue(Grid.ColumnProperty, column); //设置按钮所在Grid控件的列
            DockPanel dockPanel = new DockPanel();

            //主要信息界面
            Grid grid = new Grid();
            for(int i = 0; i < 5; i++)
            {
                RowDefinition rowDefinition = new RowDefinition();
                rowDefinition.Height = new GridLength(36);
                grid.RowDefinitions.Add(rowDefinition); //添加行
            }

            //房间号
            Label roomnamelabel = new Label();
            roomnamelabel.SetValue(Grid.RowProperty, 0);
            roomnamelabel.FontSize = 14;
            roomnamelabel.VerticalAlignment = VerticalAlignment.Center;
            roomnamelabel.HorizontalAlignment = HorizontalAlignment.Center;
            roomnamelabel.Content = room.roomname;
            grid.Children.Add(roomnamelabel);

            //房间类型
            Label roomtypelabel = new Label();
            roomtypelabel.SetValue(Grid.RowProperty, 1);
            roomtypelabel.FontFamily = new FontFamily("楷书");
            roomtypelabel.FontSize = 15;
            roomtypelabel.Height = 36;
            roomtypelabel.Width = 135;
            roomtypelabel.VerticalAlignment = VerticalAlignment.Center;
            roomtypelabel.HorizontalAlignment = HorizontalAlignment.Center;
            roomtypelabel.HorizontalContentAlignment = HorizontalAlignment.Center;
            roomtypelabel.VerticalContentAlignment = VerticalAlignment.Center;
            roomtypelabel.Content = room.roomtype;
            roomtypelabel.BorderThickness = new Thickness(2);
            string color = "";
            foreach (RoomType rt in roomTypes)
            {
                if (rt.Name == room.roomtype)
                {
                    color = rt.Color;
                    break;
                }
            }
            roomtypelabel.Background = ColorsConfig[color];
            if (color == "黑色" || color == "紫色" || color == "棕色" || color == "蓝色")
            {
                roomtypelabel.Foreground = Brushes.White;
            }
            grid.Children.Add(roomtypelabel);

            //房态
            Label roomstatelabel = new Label();
            roomstatelabel.SetValue(Grid.RowProperty, 2);
            roomstatelabel.FontSize = 14;
            roomstatelabel.VerticalAlignment = VerticalAlignment.Center;
            roomstatelabel.HorizontalAlignment = HorizontalAlignment.Center;
            switch (room.roomstate)
            {
                case 0:
                    roomstatelabel.Content = "空房";
                    break;
                default:
                    break;
            }
            grid.Children.Add(roomstatelabel);

            dockPanel.Children.Add(grid);
            border.Child = dockPanel;
            grid.DataContext = room;
            return border;
        }
        public FrameworkElement MakeRoomInfoEditCard(Room room, int row, int column, List<RoomType> RoomTypes)
        {
            Border border = new Border();
            border.CornerRadius = new CornerRadius(5, 5, 5, 5);
            border.Margin = new Thickness(10, 10, 10, 10);
            border.Background = new SolidColorBrush(Color.FromRgb(220, 220, 220));
            border.Width = 130;
            border.Height = 180;
            border.SetValue(Grid.RowProperty, row); //设置按钮所在Grid控件的行
            border.SetValue(Grid.ColumnProperty, column); //设置按钮所在Grid控件的列
            DockPanel dockPanel = new DockPanel();

            //主要信息界面
            Grid grid = new Grid();
            for (int i = 0; i < 5; i++)
            {
                RowDefinition rowDefinition = new RowDefinition();
                rowDefinition.Height = new GridLength(36);
                grid.RowDefinitions.Add(rowDefinition); //添加行
            }

            //房间号
            TextBox roomnametextbox = new TextBox();
            roomnametextbox.SetValue(Grid.RowProperty, 0);
            roomnametextbox.FontSize = 12;
            roomnametextbox.Width = 90;
            roomnametextbox.Height = 25;
            roomnametextbox.VerticalAlignment = VerticalAlignment.Center;
            roomnametextbox.HorizontalAlignment = HorizontalAlignment.Center;
            roomnametextbox.Text = room.roomname;
            roomnametextbox.TextChanged += namechange;
            grid.Children.Add(roomnametextbox);


            //删除
            Image closethis = new Image();
            closethis.MouseDown += CloseThis;
            closethis.SetValue(Grid.RowProperty, 0);
            closethis.Margin= new Thickness(110, -10, 0, 0);
            closethis.Width = 20;
            closethis.Height = 20;
            closethis.Source = new BitmapImage(new Uri("/AppData/icon/black_exit_favicon.ico", UriKind.RelativeOrAbsolute));
            grid.Children.Add(closethis);

            //房间类型

            ComboBox roomtypecombotext = new ComboBox();
            roomtypecombotext.SetValue(Grid.RowProperty, 1);
            roomtypecombotext.FontSize = 14;
            roomtypecombotext.FontFamily = new FontFamily("楷书");
            int selectposition = 0;
            for (int i = 0; i < RoomTypes.Count(); i++)
            {
                ComboBoxItem comboBoxItem = new ComboBoxItem();
                TextBlock textBlock = new TextBlock();
                textBlock.Text = RoomTypes[i].Name;
                //comboBoxItem.Background = ColorsConfig[RoomTypes[i].Color];
                comboBoxItem.Content = textBlock;
                roomtypecombotext.Items.Add(comboBoxItem);
                //if (RoomTypes[i].Color == "黑色" || RoomTypes[i].Color == "紫色" || RoomTypes[i].Color == "棕色" || RoomTypes[i].Color == "蓝色")
                //{
                //    comboBoxItem.Foreground = Brushes.White;
                //}
                if (RoomTypes[i].Name.ToString() == room.roomtype)
                {
                    selectposition = i;
                }
            }
            roomtypecombotext.Text = room.roomtype;
            roomtypecombotext.SelectionChanged += typechange;
            grid.Children.Add(roomtypecombotext);


            //房态
            Label roomstatelabel = new Label();
            roomstatelabel.SetValue(Grid.RowProperty, 2);
            roomstatelabel.FontSize = 14;
            roomstatelabel.VerticalAlignment = VerticalAlignment.Center;
            roomstatelabel.HorizontalAlignment = HorizontalAlignment.Center;
            switch (room.roomstate)
            {
                case 0:
                    roomstatelabel.Content = "空房";
                    break;
                default:
                    break;
            }
            grid.Children.Add(roomstatelabel);

            //日房价
            Label daypricelabel = new Label();
            daypricelabel.SetValue(Grid.RowProperty, 3);
            daypricelabel.Margin = new Thickness(0, -15, 0, 0);
            daypricelabel.FontSize = 10;
            daypricelabel.Content = "日单价";
            grid.Children.Add(daypricelabel);

            TextBox daypricetextbox = new TextBox();
            daypricetextbox.SetValue(Grid.RowProperty, 3);
            daypricetextbox.FontSize = 12;
            daypricetextbox.Width = 60;
            daypricetextbox.Height = 25;
            daypricetextbox.HorizontalAlignment = HorizontalAlignment.Left;
            daypricetextbox.Text = room.roomdayprice;
            daypricetextbox.TextChanged += daypricechange;
            daypricetextbox.PreviewTextInput += numbertextbox;
            grid.Children.Add(daypricetextbox);

            //每小时房价
            Label hourpricelabel = new Label();
            hourpricelabel.SetValue(Grid.RowProperty, 3);
            hourpricelabel.Margin = new Thickness(90, -15, 0, 0);
            hourpricelabel.FontSize = 10;
            hourpricelabel.Content = "时单价";
            grid.Children.Add(hourpricelabel);


            TextBox hourpricetextbox = new TextBox();
            hourpricetextbox.SetValue(Grid.RowProperty, 3);
            hourpricetextbox.FontSize = 12;
            hourpricetextbox.Width = 60;
            hourpricetextbox.Height = 25;
            hourpricetextbox.HorizontalAlignment = HorizontalAlignment.Right;
            hourpricetextbox.Text = room.roomhourprice;
            hourpricetextbox.TextChanged += hourpricechange;
            hourpricetextbox.PreviewTextInput += numbertextbox;
            grid.Children.Add(hourpricetextbox);
            dockPanel.Children.Add(grid);
            border.Child = dockPanel;

            grid.DataContext = room;
            return border;
        }


        private void namechange(object sender, TextChangedEventArgs e)
        {
            TextBox nmtb = sender as TextBox;
            Grid gd = nmtb.Parent as Grid;
            ((Room)gd.DataContext).roomname = nmtb.Text;
            //new MessageWindow(((Room)gd.DataContext).roomname).Show();
        }
        private void daypricechange(object sender, TextChangedEventArgs e)
        {
            TextBox dptb = sender as TextBox;
            Grid gd = dptb.Parent as Grid;
            ((Room)gd.DataContext).roomdayprice = dptb.Text;
            //new MessageWindow(((Room)gd.DataContext).roomname).Show();
        }
        private void hourpricechange(object sender, TextChangedEventArgs e)
        {
            TextBox hptb = sender as TextBox;
            Grid gd = hptb.Parent as Grid;
            ((Room)gd.DataContext).roomhourprice = hptb.Text;
            //new MessageWindow(((Room)gd.DataContext).roomname).Show();
        }
        private void numbertextbox(object sender, TextCompositionEventArgs e)
        {
            Regex re = new Regex("[^0-9.-]+");
            e.Handled = re.IsMatch(e.Text);
        }
        private void typechange(object sender, SelectionChangedEventArgs e)
        {
            
            ComboBox tpcb = sender as ComboBox;
            Grid gd = tpcb.Parent as Grid;
            ComboBoxItem cbbi = tpcb.Items[tpcb.SelectedIndex] as ComboBoxItem;
            TextBlock TB = cbbi.Content as TextBlock;
            ((Room)gd.DataContext).roomtype = TB.Text;
            //foreach (RoomType rt in roomtypes)
            //{
            //    if (rt.Name == (gd.DataContext as Room).roomtype)
            //    {
            //        tpcb.Background = ColorsConfig[rt.Color];
            //        if (rt.Color == "黑色" || rt.Color == "紫色" || rt.Color == "棕色" || rt.Color == "蓝色")
            //        {
            //            tpcb.Foreground = Brushes.White;
            //        }
            //        else
            //        {
            //            tpcb.Foreground = Brushes.Black;
            //        }
            //        break;
            //    }

            //}
            //new MessageWindow(((Room)gd.DataContext).roomtype).Show();
        }
        private void CloseThis(object sender, RoutedEventArgs e)
        {
            Image bt = sender as Image;
            Grid gd = bt.Parent as Grid;
            DockPanel dp = gd.Parent as DockPanel;
            Border bd = dp.Parent as Border;
            Grid max = bd.Parent as Grid;
            max.Children.Remove(bd);
            e.Handled = true;
            //new MessageWindow((gd.DataContext as Room).roomtype).Show(); 
        }

        private void ToOpenRoom(object sender, RoutedEventArgs e)
        {
            PUButton pUButton = sender as PUButton;
            Grid gd = pUButton.Parent as Grid;
            new OpenRoomWindow((gd.DataContext as Room).roomID).ShowDialog();
        }

        public void SaveChanges(Grid grid)
        {
            using (RetailContext context = new RetailContext())
            {
                rooms = context.Rooms.ToList();
                foreach (Room r in rooms)
                {
                    context.Rooms.Remove(r);
                }
                foreach (Border bd in grid.Children)
                {
                    DockPanel dp = bd.Child as DockPanel;
                    Grid needgrid = dp.Children[0] as Grid;
                    //(needgrid.DataContext as Room).roomID = Guid.NewGuid();
                    context.Rooms.Add((needgrid.DataContext as Room));
                }
                context.SaveChanges();
            }
        }
        
    }
}
