using HotelManager.ViewModels.MainMenu.Pages.BsManager.Pages;
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

namespace HotelManager.Views.MainMenu.Pages.BsManage.Pages
{
    /// <summary>
    /// RoomInfoPage.xaml 的交互逻辑
    /// </summary>
    public partial class RoomInfoPage : Page
    {
        public BsManagerPage fatherpage;
		public Window fatherwindow;
        public RoomInfoPage()
        {
            InitializeComponent();
        }

        //public RoomInfoPage(BsManagerPage page,out Pg_RoomInfoViewModel viewmodel)
        //{
        //    InitializeComponent();
        //    fatherpage = page;
            
        //    scrollview.Width = fatherpage.RoomInfoFrame.Width - 200;
        //    scrollview.Height = fatherpage.RoomInfoFrame.Height - 30;
        //    viewmodel = new Pg_RoomInfoViewModel(this);
        //    var t = this.Height;
        //    this.DataContext = viewmodel;
        //}

		public RoomInfoPage(Window window, out Pg_RoomInfoViewModel viewmodel)
		{
			InitializeComponent();
			fatherwindow = window;

			scrollview.Width = fatherwindow.Width - 280;
			scrollview.Height = fatherwindow.Height - 70;
			viewmodel = new Pg_RoomInfoViewModel(this);
			var t = this.Height;
			this.DataContext = viewmodel;
		}

		protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            Point positionToRoomCard = e.GetPosition(scrollview);
            Point positionToBtGrid = e.GetPosition(roominfobtgrid);
            if (positionToRoomCard.X >= 0 && positionToRoomCard.X < scrollview.ActualWidth && positionToRoomCard.Y >= 0 && positionToRoomCard.Y < scrollview.ActualHeight)
            {
                scrollview.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
                scrollview.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
            }
            if (positionToBtGrid.X >= 0 && positionToBtGrid.X < roominfobtgrid.ActualWidth && positionToBtGrid.Y >= 0 && positionToBtGrid.Y < roominfobtgrid.ActualHeight)
            {
                scrollview.HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden;
                scrollview.VerticalScrollBarVisibility = ScrollBarVisibility.Hidden;
            }
        }
    }
}
