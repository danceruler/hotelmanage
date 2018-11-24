using HotelManager.Views.FunctionWindow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace HotelManager.ViewModels.Function
{
    public class OpenRoomViewModel
    {
        OpenRoomWindow thiswindow;

        public OpenRoomViewModel(OpenRoomWindow window)
        {
            this.thiswindow = window;
        }

        public ICommand OpenRoomCommand
        {
            get { return new QueryCommand(OpenRoom); }
        }

        public void OpenRoom()
        {
            var check = checkedout();
            if(check == "ok")
            {

            }
            else
            {
                new MessageWindow(this.thiswindow, check).ShowDialog();
            }
        }

        public string checkedout()
        {
            if(this.thiswindow.customname.Text == null|| this.thiswindow.customname.Text == "")
            {
                return "顾客姓名不能为空";
            }else if(this.thiswindow.customsex.Text == null || this.thiswindow.customsex.Text == "")
            {
                return "顾客性别不能为空";
            }else if (this.thiswindow.customIdentify.Text == null || this.thiswindow.customIdentify.Text == "")
            {
                return "顾客身份证号不能为空";
            }else if (this.thiswindow.normaltype.IsChecked == false&& this.thiswindow.hourtype.IsChecked == false && this.thiswindow.morningtype.IsChecked == false && this.thiswindow.halfdaytype.IsChecked == false)
            {
                return "请选择开房类型";
            }else if (this.thiswindow.InTime.Text == null || this.thiswindow.InTime.Text == "")
            {
                return "请填写入住时间";
            }
            else if (this.thiswindow.OutTime.Text == null || this.thiswindow.OutTime.Text == "")
            {
                return "请填写离店时间";
            }
            else if (this.thiswindow.money.Text == null || this.thiswindow.money.Text == "")
            {
                return "请填写预付金额";
            }
            else if (this.thiswindow.alipay.IsChecked == false && this.thiswindow.wechat.IsChecked == false && this.thiswindow.chash.IsChecked == false && this.thiswindow.other.IsChecked == false)
            {
                return "请选择支付方式";
            }
            return "ok";
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
