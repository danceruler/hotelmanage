using HotelManager.ViewModels.TablePage;
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

namespace HotelManager.Views.TablePage
{
    /// <summary>
    /// TestableWindow.xaml 的交互逻辑
    /// </summary>
    public partial class TestableWindow : Window
    {
        public TestableWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            double x = SystemParameters.WorkArea.Width;//得到屏幕工作区域宽度
            double y = SystemParameters.WorkArea.Height;//得到屏幕工作区域高度
            this.Height = y;
            this.Width = x;
            this.ShowInTaskbar = false;
            //this.Topmost = true;
            ValueRule_fulldayPage page = new ValueRule_fulldayPage(this.tableframe, out ValueRule_fullday_ViewModel viewModel);
            this.tableframe.Content = page;
            
        }
    }
}
