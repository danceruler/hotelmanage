using HotelManager.ViewModels.MainMenu.Pages.BsManager;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Caliburn.Micro;
using Panuon.UI;
using HotelManager.Views.MainMenu.Pages.BsManage.Pages;
using HotelManager.ViewModels.MainMenu.Pages.BsManager.Pages;
using HotelManager.ViewModels.TablePage;
using HotelManager.Views.TablePage;

namespace HotelManager.Views.MainMenu.Pages.BsManage
{
    /// <summary>
    /// BsManagerPage.xaml 的交互逻辑
    /// </summary>
    public partial class BsManagerPage : Page
    {
        public Window fatherwindow;
		public Page sonpage;
		public List<PUTabItemModel> bsmanageritems = new List<PUTabItemModel>();
        
        public BsManagerPage()
        {
            InitializeComponent();
        }

        public BsManagerPage(Window window,out Pg_BsManagerViewModel viewmodel)
        {
            InitializeComponent();
            fatherwindow = window;
			bsmanageritems.Add(new PUTabItemModel()
            {
                Header = "房间信息",
                Icon = null,
                CanDelete = false,
                Content = "1",
            });
			viewmodel = new Pg_BsManagerViewModel(this);
            this.DataContext = viewmodel;
        }

		public BsManagerPage(Window window, out Pg_BsManagerViewModel viewmodel,Frame frame)
		{
			InitializeComponent();
			fatherwindow = window;
			bsmanageritems.Add(new PUTabItemModel()
			{
				Header = "房间信息",
				Icon = null,
				CanDelete = false,
				Content = frame,
			});
			viewmodel = new Pg_BsManagerViewModel(this);
			this.DataContext = viewmodel;
		}

	}
}
