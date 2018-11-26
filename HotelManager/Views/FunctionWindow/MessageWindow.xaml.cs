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

namespace HotelManager.Views.FunctionWindow
{
    /// <summary>
    /// MessageWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MessageWindow : Window
    {
        private bool isclose;
        public MessageWindow(string message)
        {
            InitializeComponent(); 
            Message.Text = message;
        }
        public MessageWindow(Window onwer,string message)
        {
            InitializeComponent();
            this.Owner = onwer;
            this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            Message.Text = message;
        }

        public MessageWindow(Window onwer, string message,bool isclose)
        {
            InitializeComponent();
            this.Owner = onwer;
            this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            this.isclose = isclose;
            Message.Text = message;
        }
        public MessageWindow(Window onwer, string message,string title)
        {
            InitializeComponent();
            this.Title = title;
            this.Owner = onwer;
            this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            Message.Text = message;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (isclose!=null&&isclose == true)
            {
                this.Owner.Close();
            }
            this.Close();
        }
    }
}
