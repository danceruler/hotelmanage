using HotelManager.Models;
using HotelManager.Views.TablePage;
using HotelManager.Views.TablePage.Function;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HotelManager.ViewModels.TablePage
{
    public class ValueRule_fullday_ViewModel
    {
        private ValueRule_fulldayPage thispage;
        #region 分页参数
        private const int everypagenumber = 20;
        private int pagesum;//总页数
        private int pagenumber;//当前页数
        #endregion

        public ValueRule_fullday_ViewModel(ValueRule_fulldayPage page)
        {
            thispage = page;
            ReFlashTable();
        }

        public void ReFlashTable()
        {
            pagenumber = 1;
            using (RetailContext context = new RetailContext())
            {
                //初始化总页数
                var list = context.ValueRule_fulldays.ToList();
                pagesum = list.Count();
                //string sql = string.Format("select * from ValueRule_fulldays limit {0},{1}", everypagenumber * (pagenumber-1), everypagenumber * pagenumber);
                string sql = string.Format("select * from ValueRule_fulldays");
                var needlist = context.Database.SqlQuery<ValueRule_fullday>(sql).ToList();
                ItemsList = new ObservableCollection<ValueRule_fullday>(needlist);
                thispage.datagrid.ItemsSource = ItemsList;
            }
        }

        #region Binding
        public ObservableCollection<ValueRule_fullday> ItemsList
        {
            get { return _itemsList; }
            set
            { _itemsList = value; RaisePropertyChanged("ItemsList"); }
        }
        private ObservableCollection<ValueRule_fullday> _itemsList;
        #endregion

        #region event
        public ICommand ToValueRulefulldayWindowCommand
        {
            get { return new QueryCommand(ToValueRule_fulldayWindow); }
        }
    
        public void ToValueRule_fulldayWindow()
        {
            new ValueRule_fulldayinfo_Window(thispage).ShowDialog();
        }
        
        #endregion

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