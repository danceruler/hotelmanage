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
            //double x = SystemParameters.WorkArea.Width;//得到屏幕工作区域宽度
            //double y = SystemParameters.WorkArea.Height;//得到屏幕工作区域高度
            RetailContext context = new RetailContext();
            List<Room> list = context.Rooms.ToList();
            Guid test = list[0].roomID;
            string t = ConvertGuid(test);
            Room room = context.Rooms.Where(r => ConvertGuid(r.roomID) == t).ToList()[0];

            MessageBox.Show(room.roomname);
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

        private void testcombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            var test = comboBox.Items[0];
            MessageBox.Show(test.GetType().ToString());
            //ComboBoxItem textBlock = comboBox.SelectedItem as ComboBoxItem;
            //TextBlock textBlock2 = textBlock.Content as TextBlock;
            //MessageBox.Show(textBlock2.Text.ToString());
        }

        private void ToOpenRoom(object sender, RoutedEventArgs e)
        {
            new OpenRoomWindow(this).ShowDialog();
        }

        private string ConvertGuid(Guid gd)
        {
            string sgd = gd.ToString().ToUpper();
            string sVar = "";
            int i;

            foreach (string sv in new string[] {
        sgd.Substring(0, 8), sgd.Substring(9, 4), sgd.Substring(14, 4) })
            {
                for (i = sv.Length - 2; i >= 0; i -= 2)
                {
                    sVar += sv.Substring(i, 2);
                }
            }

            sgd = sgd.Substring(19).Replace("-", "");
            for (i = 0; i < 8; i++)
            {
                sVar += sgd.Substring(2 * i, 2);
            }

            return sVar;
        }
    }
}
