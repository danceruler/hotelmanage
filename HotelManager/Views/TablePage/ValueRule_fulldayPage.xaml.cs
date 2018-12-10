using HotelManager.ViewModels.TablePage;
using HotelManager.Views.TablePage.Function;
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

namespace HotelManager.Views.TablePage
{
    /// <summary>
    /// ValueRule_fullday.xaml 的交互逻辑
    /// </summary>
    public partial class ValueRule_fulldayPage : Page
    {
        Window thiswindow;
        public Frame thisframe;
        public ValueRule_fulldayPage(Frame frame,out ValueRule_fullday_ViewModel viewModel)
        {
            InitializeComponent();
            viewModel = new ValueRule_fullday_ViewModel(this);
            this.DataContext = viewModel;
            this.thisframe = frame;
            this.Height = frame.Height;
            this.Width = frame.Width;
        }

        private void Change(object sender, MouseButtonEventArgs e)
        {
            Label label = sender as Label;
            //MessageBox.Show(label.Tag.GetType().ToString());
            new ValueRule_fulldayinfo_Window(this, (Guid)label.Tag).ShowDialog();
        }
    }
}
