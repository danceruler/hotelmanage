using Caliburn.Micro;
using HotelManager.Helper;
using HotelManager.Models;
using HotelManager.Views.FunctionWindow;
using Panuon.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace HotelManager.ViewModels.Function
{
    public class AddRoomViewModel
    {
        AddRoomWindow thiswindow;

        List<PUComboBoxItemModel> rtypeitems = new List<PUComboBoxItemModel>();

        public AddRoomViewModel(AddRoomWindow window)
        {
            thiswindow = window;
            LoadRoomtypes();
        }
        public BindableCollection<PUComboBoxItemModel> ComboBoxItemsList
        {
            get { return _comboBoxItemsList; }
            set { _comboBoxItemsList = value; RaisePropertyChanged("ComboBoxItemsList"); }
        }
        private BindableCollection<PUComboBoxItemModel> _comboBoxItemsList;

        private void LoadRoomtypes()
        {
            using (RetailContext context = new RetailContext())
            {
                var roomtypes = context.RoomTypes.ToList();
                foreach(RoomType rt in roomtypes)
                {
                    PUComboBoxItemModel item = new PUComboBoxItemModel()
                    {
                        Header = rt.Name,
                        CanDelete = false,
                        Value = rt.Name,
                    };
                    rtypeitems.Add(item);
                }
                ComboBoxItemsList = new BindableCollection<PUComboBoxItemModel>(rtypeitems);
            }
        }

        public ICommand AddRoomCommand
        {
            get { return new QueryCommand(AddRoom); }
        }

        public void AddRoom()
        {
            string roomtype = thiswindow.roomtype.Text;
            if (thiswindow.roomnrow.Text == "")
            {
                new MessageWindow(thiswindow, "房间楼层不能为空！").ShowDialog();
            }
            else if (thiswindow.dayprice.Text == "")
            {
                new MessageWindow(thiswindow, "房间日单价不能为空！").ShowDialog();
            }
            else if (thiswindow.hourprice.Text == "")
            {
                new MessageWindow(thiswindow, "房间小时单价不能为空！").ShowDialog();
            }
            else if(thiswindow.roomname1.Text == "")
            {
                new MessageWindow(thiswindow, "起始房号不能为空！").ShowDialog();
            }
            else
            {
                int roomrow = int.Parse(thiswindow.roomnrow.Text);
                string roomname1 = thiswindow.roomname1.Text;
                string roomname2 = thiswindow.roomname2.Text;
                string dayprice = thiswindow.dayprice.Text;
                string hourprice = thiswindow.hourprice.Text;
                Regex re = new Regex("[0-9]+");
                using (RetailContext context = new RetailContext())
                {
                    if (roomname2 != "")
                    {
                        if (!re.IsMatch(roomname1) || !re.IsMatch(roomname2))
                        {
                            new MessageWindow(thiswindow, "起始房号和结束房号必须均为数字！").ShowDialog();
                        }
                        else if (int.Parse(roomname1) > int.Parse(roomname2))
                        {
                            new MessageWindow(thiswindow, "起始房号不能大于结束房号！").ShowDialog();
                        }
                        else
                        {
                            for (int i = int.Parse(roomname1); i <= int.Parse(roomname2); i++)
                            {
                                Room room = new Room()
                                {
                                    roomID = Guid.NewGuid(),
                                    roomname = i + "",
                                    roomtype = roomtype,
                                    roomdayprice = dayprice,
                                    roomhourprice = hourprice,
                                    roomstate = 0,
                                    row = roomrow,
                                    column = i,
                                    CanUse = true,
                                };
                                context.Rooms.Add(room);
                               
                            }
                            new MessageWindow(thiswindow, "添加成功").ShowDialog();
                        }
                    }
                    else
                    {
                        if (re.IsMatch(roomname1))
                        {
                            Room room = new Room()
                            {
                                roomID = Guid.NewGuid(),
                                roomname = roomname1,
                                roomtype = roomtype,
                                roomdayprice = dayprice,
                                roomhourprice = hourprice,
                                row = roomrow,
                                column = int.Parse(roomname1),
                                roomstate = 0,
                                CanUse = true,
                            };
                            context.Rooms.Add(room);
                        }
                        else
                        {
                            Room room = new Room()
                            {
                                roomID = Guid.NewGuid(),
                                roomname = roomname1,
                                roomtype = roomtype,
                                roomdayprice = dayprice,
                                roomhourprice = hourprice,
                                row = roomrow,
                                column = int.MaxValue,
                                roomstate = 0,
                                CanUse = true,
                            };
                            context.Rooms.Add(room);
                        }
                        new MessageWindow(thiswindow, "添加成功").ShowDialog();
                    }
                    context.SaveChanges();
                    
                }
                    
            }

        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Methods
        private void RaisePropertyChanged(string propertyName)
        {
            // take a copy to prevent thread issues
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

    }






}
