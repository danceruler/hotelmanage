using HotelManager.Models;
using HotelManager.Views.FunctionWindow;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows.Media;

namespace HotelManager.ViewModels.Function
{
    public class EditRoomTypeViewModel : INotifyPropertyChanged
    {
        EditRoomTypeWindow thiswindow;
        
        private ObservableCollection<RoomType> _roomtypes;
        public ObservableCollection<RoomType> GetRoomTypes { get; private set; }

        public static List<string> colors = new List<string>() { "默认(灰色)","黑色", "白色", "蓝色", "红色","黄色", "绿色", "紫色", "天蓝色", "棕色", "草绿色", "橘黄色", "橘红色", "粉色" };
        //                                                         gray        black    white  blue     red   yellow green  purple  skyblue    brown  LawnGreen  Orange  OrangeRed   Pink 
        public EditRoomTypeViewModel(EditRoomTypeWindow window)
        {
            thiswindow = window;
            LoadData();
        }

        public ObservableCollection<RoomType> RoomTypes
        {
            get { return _roomtypes; }
            set
            {
                _roomtypes = value;
                RaisePropertyChanged("RoomTypes");
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
            if (RoomTypes[RoomTypes.Count() - 1].Name == null && RoomTypes[RoomTypes.Count() - 1].Cap == 0 && RoomTypes[RoomTypes.Count() - 1].Color == null)
            {
                new MessageWindow(thiswindow, "有空行还未填写").ShowDialog();
            }
            else if(RoomTypes[RoomTypes.Count() - 1].Name == null)
            {
                new MessageWindow(thiswindow, "房间类型不能为空").ShowDialog();
            }
            else if (RoomTypes[RoomTypes.Count() - 1].Cap <= 0)
            {
                new MessageWindow(thiswindow, "容量不能小于1").ShowDialog();
            }
            else
            {
                RoomType rt = new RoomType() { Color="默认(灰色)"};
                RoomTypes.Add(rt);
            }
        }

        public void LoadData()
        {
            GetRoomTypes = new ObservableCollection<RoomType>();
            using (RetailContext context = new RetailContext())
            {
                var rmtypes = context.RoomTypes.ToList();
                foreach (RoomType rt in rmtypes)
                {
                    GetRoomTypes.Add(rt);
                }
            }
            RoomTypes = GetRoomTypes;
        }

        public void UpdateData()
        {
            if (RoomTypes[RoomTypes.Count() - 1].Name == null && RoomTypes[RoomTypes.Count() - 1].Cap == 0 && RoomTypes[RoomTypes.Count() - 1].Color == null)
            {
                new MessageWindow(thiswindow, "有空行还未填写").ShowDialog();
                return;
            }
            else if (RoomTypes[RoomTypes.Count() - 1].Name == null)
            {
                new MessageWindow(thiswindow, "房间类型不能为空").ShowDialog();
                return;
            }
            else if (RoomTypes[RoomTypes.Count() - 1].Cap <= 0)
            {
                new MessageWindow(thiswindow, "容量不能小于1").ShowDialog();
                return;
            }

            bool canupate = true;
            bool isrepeatname = false;
            List<RoomType> updates = new List<RoomType>();
            string[] names = new string[RoomTypes.Count()];
            int cnd = 0;
            foreach(RoomType rt in RoomTypes)
            {
                names[cnd++] = rt.Name;
                if (rt.ID == new RoomType().ID)
                {
                    updates.Add(rt);
                }
                else
                {
                    foreach (RoomType rt2 in GetRoomTypes)
                    {
                        if (rt.ID == rt2.ID)
                        {
                            updates.Add(rt);
                            if (rt.Name != rt2.Name)
                            {
                                canupate = false;
                            }
                        }
                    }
                }

                
            }
            for(int i = 0; i < names.Length; i++)
            {
                for(int j = 0; j < names.Length; j++)
                {
                    if(i!=j&&names[i] == names[j])
                    {
                        isrepeatname = true;
                    }
                    if (isrepeatname) break;
                }
            }
            if (isrepeatname)
            {
                new MessageWindow(thiswindow, "房间名不能重复").ShowDialog();
                return;
            }
            if (!canupate)
            {
                new MessageWindow(thiswindow, "之前已有的房间类型名称无法修改").ShowDialog();
                return;
            }

            using (RetailContext context = new RetailContext())
            {
                var list = context.RoomTypes.ToList();
                foreach(RoomType rt in list)
                {
                    context.RoomTypes.Remove(rt);
                }

                foreach (RoomType rt in updates)
                {
                    if (rt.ID != new RoomType().ID)
                    {
                        context.RoomTypes.Add(rt);
                    }
                    else
                    {
                        rt.ID = Guid.NewGuid();
                        rt.IsChecked = false;
                        rt.CanChange = false;
                        context.RoomTypes.Add(rt);
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
