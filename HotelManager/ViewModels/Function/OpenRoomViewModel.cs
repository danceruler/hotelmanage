using Caliburn.Micro;
using HotelManager.Helper;
using HotelManager.Models;
using HotelManager.ViewModels.MainMenu.Pages.BsManager.Pages;
using HotelManager.ViewModels.MainMenu.Pages.RoomState;
using HotelManager.Views.FunctionWindow;
using HotelManager.Views.MainMenu.Pages.BsManage.Pages;
using HotelManager.Views.MainMenu.Pages.RoomState;
using Panuon.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace HotelManager.ViewModels.Function
{
    public class OpenRoomViewModel
    {
        OpenRoomWindow thiswindow;
        List<Finishbook> Booktrans = new List<Finishbook>();
        public OpenRoomViewModel(OpenRoomWindow window)
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
            Booktrans = checkIsBook(thiswindow.thisroom.roomID);
            using (RetailContext context = new RetailContext())
            {
                if (Booktrans.Count() > 0)
                {
                    string sql = string.Format("select * from customers where identification = '{0}'", Booktrans[0].customID);
                    List<Customer> customers = context.Database.SqlQuery<Customer>(sql).ToList();
                    thiswindow.booktip.Margin = new Thickness(0, 10, 0, 0);
                    thiswindow.booktip.Content = "该房已被预定,信息如下";
                    thiswindow.booktip.HorizontalAlignment = HorizontalAlignment.Center;
                    thiswindow.booktip.Foreground = Brushes.Red;
                    thiswindow.customname.Text = customers[0].Name;
                    thiswindow.customname.IsReadOnly = true;
                    thiswindow.customsex.Text = customers[0].sex;
                    thiswindow.customsex.IsEnabled = false;
                    thiswindow.customIdentify.Text = customers[0].identification;
                    thiswindow.customIdentify.IsReadOnly = true;
                    switch (Booktrans[0].opentype)
                    {
                        case "普通房":
                            thiswindow.normaltype.IsChecked = true;
                            break;
                        case "钟点房":
                            thiswindow.hourtype.IsChecked = true;
                            break;
                        case "凌晨房":
                            thiswindow.morningtype.IsChecked = true;
                            break;
                        case "半天房":
                            thiswindow.halfdaytype.IsChecked = true;
                            break;
                        default:
                            break;
                    }
                    switch (Booktrans[0].paytype)
                    {
                        case "支付宝":
                            thiswindow.alipay.IsChecked = true;
                            break;
                        case "微信":
                            thiswindow.wechat.IsChecked = true;
                            break;
                        case "现金":
                            thiswindow.chash.IsChecked = true;
                            break;
                        case "其他":
                            thiswindow.other.IsChecked = true;
                            break;
                        default:
                            break;
                    }
                    thiswindow.InTime.Text = Booktrans[0].expectstartime;
                    thiswindow.OutTime.Text = Booktrans[0].expectendtime;
                    thiswindow.money.Text = Booktrans[0].money;
                }
            }
            
        }
        public BindableCollection<PUComboBoxItemModel> ComboBoxItemsList
        {
            get { return _comboBoxItemsList; }
            set { _comboBoxItemsList = value;RaisePropertyChanged("ComboBoxItemsList"); }
        }
        private BindableCollection<PUComboBoxItemModel> _comboBoxItemsList;

        public ICommand OpenRoomCommand
        {
            get { return new QueryCommand(OpenRoom); }
        }

        public void OpenRoom()
        {
           
            var check = checkedout();
            if(check == "ok")
            {
                using (RetailContext context = new RetailContext())
                {
                    string getcustomer_sql1 = string.Format("select * from customers where identification in (select customID from finishtranses where IsDoing = true and customID = '{0}') ", this.thiswindow.customIdentify.Text);
                    List<Customer> customers_exists1 = context.Database.SqlQuery<Customer>(getcustomer_sql1).ToList();
                    bool isexists1 = false;
                    if (customers_exists1.Count() > 0)
                    {
                        isexists1 = true;
                    }
                    if(isexists1)
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
                    Finishtrans finishtrans = new Finishtrans()
                    {

                        transID = Guid.NewGuid(),
                        roomID = thiswindow.thisroom.roomID.ConvertGuid(),
                        customID = thiswindow.customIdentify.Text,
                        opentype = openType,
                        balance = thiswindow.money.Text,
                        startime = thiswindow.InTime.Text,
                        expectendtime = thiswindow.OutTime.Text,
                        transtime = DateTime.Now.ToString("yy-MM-dd HH:mm:ss"),
                        money = thiswindow.money.Text,
                        paytype = payType,
                        IsDoing = true,
                    };
                    if (Booktrans.Count() > 0)
                    {
                        finishtrans.bookID = Booktrans[0].transID.ConvertGuid();
                        string changebooksql = "update finishbooks set IsBook = false,formalID = '"+finishtrans.transID.ConvertGuid()+"' where UPPER(HEX([transID]))='" + Booktrans[0].transID.ConvertGuid() + "'";
                        context.Database.ExecuteSqlCommand(changebooksql);
                    }
                    context.Finishtranses.Add(finishtrans);
                    string sql = string.Format("update Rooms  set roomstate = {1} where UPPER(HEX([roomID]))='{0}' ", thiswindow.thisroom.roomID.ConvertGuid(), "1");
                    context.Database.ExecuteSqlCommand(sql);

                    context.SaveChanges();
                    
                    
                }
                Pg_RoomStateViewModel infoViewModel = thiswindow.fatherpage.DataContext as Pg_RoomStateViewModel;
                infoViewModel.ReFlashRoomInfo();
                
                new MessageWindow(this.thiswindow, "开房成功",true).ShowDialog();
                
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
        public List<Finishbook> checkIsBook(Guid roomid)
        {
            using (RetailContext context = new RetailContext())
            {
                string sql = string.Format("select * from finishbooks where IsBook = true and roomid = '{0}'", roomid.ConvertGuid());
                List<Finishbook> finishbooks = context.Database.SqlQuery<Finishbook>(sql).ToList();
                return finishbooks;
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
