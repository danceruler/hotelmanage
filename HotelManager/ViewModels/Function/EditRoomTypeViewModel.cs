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
            if (RoomTypes.Count() > 0)
            {
                if (RoomTypes[RoomTypes.Count() - 1].Name == null && RoomTypes[RoomTypes.Count() - 1].Color == null)
                {
                    new MessageWindow(thiswindow, "有空行还未填写").ShowDialog();
                    return;
                }
                else if (RoomTypes[RoomTypes.Count() - 1].Name == null)
                {
                    new MessageWindow(thiswindow, "房间状态不能为空").ShowDialog();
                    return;
                }
                
            }
            RoomType rt = new RoomType()
            {
                ID = Guid.NewGuid(),
                Color = "默认(灰色)"
            };
            RoomTypes.Add(rt);


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
            if (RoomTypes != null) RoomTypes.Clear();
            else RoomTypes = new ObservableCollection<RoomType>();
            foreach(RoomType rs in GetRoomTypes)
            {
                RoomTypes.Add(rs);
            }
            
        }

        public void UpdateData()
        {
            if (RoomTypes[RoomTypes.Count() - 1].Name == null && RoomTypes[RoomTypes.Count() - 1].Cap <= 0)
            {
                new MessageWindow(thiswindow, "有空行还未填写").ShowDialog();
                return;
            }
            else if (RoomTypes[RoomTypes.Count() - 1].Name == null)
            {
                new MessageWindow(thiswindow, "房间状态不能为空").ShowDialog();
                return;
            }
            Guid[] names = new Guid[GetRoomTypes.Count()];
            for(int i = 0; i < GetRoomTypes.Count(); i++)
            {
                names[i] = GetRoomTypes[i].ID;
            }
            using (RetailContext context = new RetailContext())
            {
                foreach (RoomType rs in RoomTypes)
                {
                    if (names.Contains(rs.ID))
                    {
                        string sql = string.Format("update RoomTypes set Name = '{0}',Cap = {1} where UPPER(HEX([ID]))='{2}'", rs.Name, rs.Cap, rs.ID.ConvertGuid());
                        context.Database.ExecuteSqlCommand(sql);
                    }
                    else
                    {
                        context.RoomTypes.Add(rs);
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
