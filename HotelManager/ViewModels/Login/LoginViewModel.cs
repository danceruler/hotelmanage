using HotelManager.Views;
using HotelManager.Views.Login;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using HotelManager.Models;
using HotelManager.Views.FunctionWindow;

namespace HotelManager.ViewModels.Login
{
    public class LoginViewModel
    {
        private LoginWindow thiswindow;
        public LoginViewModel()
        {
        }
        public LoginViewModel(LoginWindow window)
        {
            thiswindow = window;
        }

        public ICommand LoginCommand
        {
            get { return new QueryCommand(Login); }
        }

        public void Login()
        {
            using (RetailContext context = new RetailContext())
            {
                var list = context.Persons.Where(p => p.Name == thiswindow.UserName.Text && p.password == thiswindow.Password.Password).ToList();
                if (list.Count() > 0)
                {
                    Person p = list[0];
                    new MessageWindow(thiswindow, "登陆成功").ShowDialog();
                }
                else
                {
                    new MessageWindow(thiswindow, "用户名或者密码错误").ShowDialog();
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
