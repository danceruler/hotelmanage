using HotelManager.ViewModels.Login;
using HotelManager.ViewModels.MainMenu;
using HotelManager.Views;
using HotelManager.Views.Login;
using HotelManager.Views.MainMenu;
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
using HotelManager.Models;
using HotelManager.Views.FunctionWindow;
using HotelManager.ViewModels.Function;
using HotelManager.Helper;

namespace HotelManager
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Version ver = System.Environment.OSVersion.Version;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //new RoomHelper().LoadRoomInfoByRow(new Grid());
            //RetailContext context = new RetailContext();
            //var list = context.RoomTypes.ToList();
            //context.RoomTypes.Remove(list[0]);
            //context.RoomTypes.Add(new RoomType() { Cap = 1, Name = "单人间",ID=Guid.NewGuid(), CanChange=false, IsChecked=false });
            //context.RoomTypes.Add(new RoomType() { Cap = 2, Name = "双人间", ID = Guid.NewGuid(), CanChange = false, IsChecked = false });
            //context.RoomTypes.Add(new RoomType() { Cap = 3, Name = "三人间", ID = Guid.NewGuid(), CanChange = false, IsChecked = false });
            //context.RoomTypes.Add(new RoomType() { Cap = 1, Name = "大床间", ID = Guid.NewGuid(), CanChange = false, IsChecked = false });
            //context.RoomTypes.Add(new RoomType() { Cap = 1, Name = "套间", ID = Guid.NewGuid(), CanChange = false, IsChecked = false });
            //context.RoomTypes.Add(new RoomType() { Cap = 1, Name = "豪华间", ID = Guid.NewGuid(), CanChange = false, IsChecked = false });
            //context.SaveChanges();


        }

        private void ToLogin(object sender, RoutedEventArgs e)
        {
            LoginViewModel viewmodel;
            LoginWindow window = new LoginWindow(this,out viewmodel);
            window.Owner = this;
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.ShowDialog();
        }

        private void ToMainMenu(object sender, RoutedEventArgs e)
        {
            MainMenuViewModel viewmodel;
            MainMenuWindow window = new MainMenuWindow(this, out viewmodel);
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.ShowDialog();
        }

        private void ToAddRoom(object sender, RoutedEventArgs e)
        {
            new AddRoomWindow(this, out AddRoomViewModel viewModel).ShowDialog();
        }

        private void ToEditRoomType(object sender, RoutedEventArgs e)
        {
            new EditRoomTypeWindow(this, out EditRoomTypeViewModel viewModel).ShowDialog();
        }
    }
}
