using HotelManager.Views.FunctionWindow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace HotelManager.ViewModels.Function
{
    public class DataPickerViewModel
    {
        DataPickerWindow thiswindow;
        public DataPickerViewModel(DataPickerWindow window)
        {
            this.thiswindow = window;
            thiswindow.timeString.Text = ((DateTime)SelectTime).ToString("yyyy-MM-dd HH:mm:ss");
        }
        public DateTime _selectTime =  DateTime.Now.Date;
        public DateTime SelectTime {
            get { return _selectTime; }
            set {
                _selectTime = value;
                thiswindow.timeString.Text = ((DateTime)SelectTime).ToString("yyyy-MM-dd HH:mm:ss");
                RaisePropertyChanged("SelectTime");
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
