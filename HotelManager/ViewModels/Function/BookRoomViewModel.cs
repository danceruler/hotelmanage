﻿using Caliburn.Micro;
using HotelManager.Helper;
using HotelManager.Models;
using HotelManager.ViewModels.MainMenu.Pages.RoomState;
using HotelManager.Views.FunctionWindow;
using Panuon.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace HotelManager.ViewModels.Function
{
    public class BookRoomViewModel
    {
        BookRoomWindow thiswindow;

        public BookRoomViewModel(BookRoomWindow window)
        {
            this.thiswindow = window;
            var comboList = new List<PUComboBoxItemModel>();
            comboList.Add(new PUComboBoxItemModel()
            {
                Header = "男",
                CanDelete = false,
                Value = "男",
            });
            comboList.Add(new PUComboBoxItemModel()
            {
                Header = "女",
                CanDelete = false,
                Value = "女",
            });
            ComboBoxItemsList = new BindableCollection<PUComboBoxItemModel>(comboList);
        }
        public BindableCollection<PUComboBoxItemModel> ComboBoxItemsList
        {
            get { return _comboBoxItemsList; }
            set { _comboBoxItemsList = value; RaisePropertyChanged("ComboBoxItemsList"); }
        }
        private BindableCollection<PUComboBoxItemModel> _comboBoxItemsList;

        public ICommand BookRoomCommand
        {
            get { return new QueryCommand(BookRoom); }
        }

        public void BookRoom()
        {
            
            var check = checkedout();
            if (check == "ok")
            {
                using (RetailContext context = new RetailContext())
                {
                    string getcustomer_sql1 = string.Format("select * from customers where identification in (select customID from finishtranses where IsDoing = true and customID = '{0}' union select customID from finishbooks where IsBook = true and customID = '{0}')", this.thiswindow.customIdentify.Text);
                    List<Customer> customers_exists1 = context.Database.SqlQuery<Customer>(getcustomer_sql1).ToList();
                    bool isexists1 = false;
                    if (customers_exists1.Count() > 0)
                    {
                        isexists1 = true;
                    }
                    if (isexists1)
                    {
                        new MessageWindow(this.thiswindow, "该客户还在本店有未完成订单", true).ShowDialog();
                    }

                    string getcustomer_sql2 = string.Format("select * from customers where identification = '{0}'", this.thiswindow.customIdentify.Text);
                    List<Customer> customers_exists2 = context.Database.SqlQuery<Customer>(getcustomer_sql2).ToList();
                    bool isexists2 = false;
                    foreach (Customer ct in customers_exists2)
                    {
                        if (ct.identification == this.thiswindow.customIdentify.Text)
                        {
                            isexists2 = true;
                            break;
                        }
                    }
                    if (!isexists2)
                    {
                        Customer customer = new Customer()
                        {
                            identification = this.thiswindow.customIdentify.Text,
                            Name = this.thiswindow.customname.Text,
                            sex = this.thiswindow.customsex.Text,
                        };
                        context.Customers.Add(customer);
                    }
                    string openType = "";
                    if (thiswindow.normaltype.IsChecked == true) openType = "普通房";
                    if (thiswindow.hourtype.IsChecked == true) openType = "钟点房";
                    if (thiswindow.morningtype.IsChecked == true) openType = "凌晨房";
                    if (thiswindow.halfdaytype.IsChecked == true) openType = "半天房";
                    string payType = "";
                    if (thiswindow.alipay.IsChecked == true) payType = "支付宝";
                    if (thiswindow.wechat.IsChecked == true) payType = "微信";
                    if (thiswindow.chash.IsChecked == true) payType = "现金";
                    if (thiswindow.other.IsChecked == true) payType = "其他";
                    Finishbook finishbook = new Finishbook()
                    {
                        transID = Guid.NewGuid(),
                        roomID = thiswindow.thisroom.roomID.ConvertGuid(),
                        customID = thiswindow.customIdentify.Text,
                        opentype = openType,
                        balance = thiswindow.money.Text,
                        expectstartime = thiswindow.InTime.Text,
                        expectendtime = thiswindow.OutTime.Text,
                        money = thiswindow.money.Text,
                        transtime =DateTime.Now.ToString("yy-MM-dd HH:mm:ss"),
                        paytype = payType,
                        IsBook = true,
                    };
                    context.Finishbooks.Add(finishbook);
                    //string sql = string.Format("update Rooms  set roomstate = {1} where UPPER(HEX([roomID]))='{0}' ", thiswindow.thisroom.roomID.ConvertGuid(), "1");
                    //context.Database.ExecuteSqlCommand(sql);
                    context.SaveChanges();
                }
                Pg_RoomStateViewModel infoViewModel = thiswindow.fatherpage.DataContext as Pg_RoomStateViewModel;
                infoViewModel.ReFlashRoomInfo();
                new MessageWindow(this.thiswindow, "预定成功", true).ShowDialog();

            }
            else
            {
                new MessageWindow(this.thiswindow, check).ShowDialog();
            }
        }

        public string checkedout()
        {
            if (this.thiswindow.customname.Text == null || this.thiswindow.customname.Text == "")
            {
                return "顾客姓名不能为空";
            }
            else if (this.thiswindow.customsex.Text == null || this.thiswindow.customsex.Text == "")
            {
                return "顾客性别不能为空";
            }
            else if (this.thiswindow.customIdentify.Text == null || this.thiswindow.customIdentify.Text == "")
            {
                return "顾客身份证号不能为空";
            }
            else if (this.thiswindow.normaltype.IsChecked == false && this.thiswindow.hourtype.IsChecked == false && this.thiswindow.morningtype.IsChecked == false && this.thiswindow.halfdaytype.IsChecked == false)
            {
                return "请选择开房类型";
            }
            else if (this.thiswindow.InTime.Text == null || this.thiswindow.InTime.Text == "")
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
