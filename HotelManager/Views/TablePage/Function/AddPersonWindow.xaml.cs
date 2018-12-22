using HotelManager.Helper;
using HotelManager.Models;
using Panuon.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HotelManager.Views.TablePage.Function
{
	/// <summary>
	/// AddPersonWindow.xaml 的交互逻辑
	/// </summary>
	public partial class AddPersonWindow : Window
	{
		public Page thispage;

		public AddPersonWindow()
		{
			InitializeComponent();
		}

		public AddPersonWindow(Page page)
		{
			InitializeComponent();
			this.Title = "添加用户";
			this.thispage = page;
			this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
			setDefaultValue();
		}

		public AddPersonWindow(Page page,Guid personID)
		{
			InitializeComponent();
			this.Title = "修改";
			this.thispage = page;
			this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
			setDefaultValue();
			Initdata(personID);
		}

		//设置页面基本功能及信息
		public void setDefaultValue()
		{
			using (RetailContext context = new RetailContext())
			{
				List<PersonType> personTypes = context.PersonTypes.ToList();
				List<PUComboBoxItemModel> items = new List<PUComboBoxItemModel>();
				for(int i = 0; i < personTypes.Count(); i++)
				{
					items.Add(new PUComboBoxItemModel()
					{
						Header = personTypes[i].Name,
						CanDelete = false,
						Value = personTypes[i].Name,
					});
				}
				this.UserTypeCB.BindingItems = items;
			}
		    
		}

		//动态加载的信息
		public void Initdata(Guid ID)
		{
			using (RetailContext context = new RetailContext())
			{
				string sql = string.Format("select * from persons where UPPER(HEX([personID])) = '{0}'",ID.ConvertGuid());
				Person person = context.Database.SqlQuery<Person>(sql).SingleOrDefault();
				NameTB.Text = person.Name;
				SexCB.Text = person.sex;
				UserTypeCB.Text = person.Type;
			}
		}
	}
}
