using HotelManager.Helper;
using HotelManager.Models;
using HotelManager.Views.FunctionWindow;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace HotelManager.ViewModels.Function
{
    public class EditRoomStateViewModel : INotifyPropertyChanged
    {
        EditRoomStateWindow thiswindow;

        private ObservableCollection<RoomStateModel> _roomstates;
        public ObservableCollection<RoomStateModel> GetRoomStates { get; private set; }

        public static List<string> colors = new List<string>() { "默认(灰色)", "黑色", "白色", "蓝色", "红色", "黄色", "绿色", "紫色", "天蓝色", "棕色", "草绿色", "橘黄色", "橘红色", "粉色" };
        //                                                         gray        black    white  blue     red   yellow green  purple  skyblue    brown  LawnGreen  Orange  OrangeRed   Pink 
        public EditRoomStateViewModel(EditRoomStateWindow window)
        {
            thiswindow = window;
            LoadData();
        }

        public ObservableCollection<RoomStateModel> RoomStates
        {
            get { return _roomstates; }
            set
            {
                _roomstates = value;
                RaisePropertyChanged("RoomStates");
            }
        }

        public ICommand AddRowCommand
        {
            get { return new QueryCommand(AddRow); }
        }
        public ICommand UpdateDataCommand
        {
            get { return new QueryCommand(UpdateData); }
        }

        public void AddRow()
        {
            if (RoomStates.Count() > 0)
            {
                if (RoomStates[RoomStates.Count() - 1].Name == null && RoomStates[RoomStates.Count() - 1].Color == null)
                {
                    new MessageWindow(thiswindow, "有空行还未填写").ShowDialog();
                    return;
                }
                else if (RoomStates[RoomStates.Count() - 1].Name == null)
                {
                    new MessageWindow(thiswindow, "房间状态不能为空").ShowDialog();
                    return;
                }

            }
            RoomStateModel rt = new RoomStateModel()
            {
                StateID = Guid.NewGuid(),
                Color = "默认(灰色)"
            };
            RoomStates.Add(rt);


        }

        public void LoadData()
        {
            GetRoomStates = new ObservableCollection<RoomStateModel>();
            using (RetailContext context = new RetailContext())
            {
                var rmtypes = context.RoomStates.ToList();
                foreach (RoomStateModel rt in rmtypes)
                {
                    GetRoomStates.Add(rt);
                }
            }
            if (RoomStates != null) RoomStates.Clear();
            else RoomStates = new ObservableCollection<RoomStateModel>();
            foreach (RoomStateModel rs in GetRoomStates)
            {
                RoomStates.Add(rs);
            }

        }

        public void UpdateData()
        {
            if (RoomStates[RoomStates.Count() - 1].Name == null && RoomStates[RoomStates.Count() - 1].Color == null)
            {
                new MessageWindow(thiswindow, "有空行还未填写").ShowDialog();
                return;
            }
            else if (RoomStates[RoomStates.Count() - 1].Name == null)
            {
                new MessageWindow(thiswindow, "房间状态不能为空").ShowDialog();
                return;
            }
            Guid[] names = new Guid[GetRoomStates.Count()];
            for (int i = 0; i < GetRoomStates.Count(); i++)
            {
                names[i] = GetRoomStates[i].StateID;
            }
            using (RetailContext context = new RetailContext())
            {
                foreach (RoomStateModel rs in RoomStates)
                {
                    if (names.Contains(rs.StateID))
                    {
                        string sql = string.Format("update RoomStates set Name = '{0}',Color = '{1}' where UPPER(HEX([StateID]))='{2}'", rs.Name, rs.Color, rs.StateID.ConvertGuid());
                        context.Database.ExecuteSqlCommand(sql);
                    }
                    else
                    {
                        context.RoomStates.Add(rs);
                    }


                }
                context.SaveChanges();
            }


            LoadData();

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
