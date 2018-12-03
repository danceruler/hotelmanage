using HotelManager.Views.FunctionWindow;
using Panuon.UI;
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
            SelectTime = DateTime.Now;
            DatePickerMode = DatePickerModes.DateTime;
            //thiswindow.timeString.Text = ((DateTime)SelectTime).ToString("yyyy-MM-dd HH:mm:ss");
        }

        public DataPickerViewModel(DataPickerWindow window,DatePickerModes datePickerModes)
        {
            this.thiswindow = window;
            DatePickerMode = datePickerModes;
            SelectTime = DateTime.Now;
            MinDateTime = DateTime.Now;
            
            //thiswindow.timeString.Text = ((DateTime)SelectTime).ToString("yyyy-MM-dd HH:mm:ss");
        }
        public DateTime _selectTime =  DateTime.Now.Date;
        public DateTime SelectTime {
            get { return _selectTime; }
            set {
                _selectTime = value;
                if(DatePickerMode == DatePickerModes.DateOnly)
                {
                    thiswindow.timeString.Text = ((DateTime)SelectTime).ToString("yyyy-MM-dd");
                }else if (DatePickerMode == DatePickerModes.DateTime)
                {
                    thiswindow.timeString.Text = ((DateTime)SelectTime).ToString("yyyy-MM-dd HH:mm:ss");
                }
                
                RaisePropertyChanged("SelectTime");
            }
        }
        public DateTime? MinDateTime
        {
            get { return _minDateTime; }
            set { _minDateTime = value;RaisePropertyChanged("MinDateTime"); }
        }
        private DateTime? _minDateTime;
        public DatePickerModes DatePickerMode
        {
            get { return _datePickerMode; }
            set { _datePickerMode = value;RaisePropertyChanged("DatePickerMode"); }
        }
        private DatePickerModes _datePickerMode = DatePickerModes.DateTime;

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
