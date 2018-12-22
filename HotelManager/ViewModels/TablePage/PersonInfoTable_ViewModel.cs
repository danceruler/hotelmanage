using HotelManager.Models;
using HotelManager.Views.TablePage;
using HotelManager.Views.TablePage.Function;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;

namespace HotelManager.ViewModels.TablePage
{
	public class PersonInfoTable_ViewModel
	{
		private PersonInfoTablePage thispage;
		#region 分页参数
		private const int everypagenumber = 20;
		private int pagesum;//总页数
		private int pagenumber;//当前页数
		#endregion

		public PersonInfoTable_ViewModel(PersonInfoTablePage page)
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
				var list = context.Persons.ToList();
				pagesum = list.Count();
				//string sql = string.Format("select * from ValueRule_fulldays limit {0},{1}", everypagenumber * (pagenumber-1), everypagenumber * pagenumber);
				string sql = string.Format("select * from Persons");
				var needlist = context.Database.SqlQuery<Person>(sql).ToList();
				ItemsList = new ObservableCollection<Person>(needlist);
				thispage.datagrid.ItemsSource = ItemsList;
			}
		}

		#region Binding
		public ObservableCollection<Person> ItemsList
		{
			get { return _itemsList; }
			set
			{ _itemsList = value; RaisePropertyChanged("ItemsList"); }
		}
		private ObservableCollection<Person> _itemsList;
		#endregion

		#region event
		public ICommand OpenAddPersonWindowCommand
		{
			get { return new QueryCommand(OpenAddPersonWindow); }
		}

		public void OpenAddPersonWindow()
		{
			new AddPersonWindow(thispage).ShowDialog();
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
