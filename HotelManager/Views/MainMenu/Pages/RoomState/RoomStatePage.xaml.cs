using HotelManager.ViewModels.MainMenu.Pages.RoomState;
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

namespace HotelManager.Views.MainMenu.Pages.RoomState
{
    /// <summary>
    /// RoomStatePage.xaml 的交互逻辑
    /// </summary>
    public partial class RoomStatePage : Page
    {
        public Window fatherwindow;
        public Page sonpage;
        public RoomStatePage()
        {
            InitializeComponent();
        }
        public RoomStatePage(Window window,out Pg_RoomStateViewModel viewmodel)
        {
            InitializeComponent();
            fatherwindow = window;
            viewmodel = new Pg_RoomStateViewModel(this);
            this.DataContext = viewmodel;
            this.Height = window.Height - 60;
            this.Width = window.Width - 100;
            this.scrollview.Height = window.Height - 60;
            this.scrollview.Width = window.Width - 350;
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
