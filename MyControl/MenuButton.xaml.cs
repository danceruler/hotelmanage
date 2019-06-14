using Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyControl
{
    /// <summary>
    /// Interaction logic for MenuButton.xaml
    /// </summary>
    public partial class MenuButton : UserControl
    {
        
        public MenuButton()
        {
            InitializeComponent();
        }

        public string Text { set { this.Button.Content = value; } }
        public bool CanClose { set { if (value == false) { this.Image.Visibility = Visibility.Hidden; } else { this.Image.Visibility = Visibility.Visible; } } }

        public void Click(RoutedEventHandler e)
        {
            this.Button.Click += e;
        }

        public void Close(MouseButtonEventHandler e)
        {
            this.Image.MouseUp += e;
        }

        private void Image_MouseMove(object sender, MouseEventArgs e)
        {
            Action action = new Action(() =>
            {
                var bs = ColorHelper.GetARGByStr("FF1B71B1");
                this.Button.Background = new SolidColorBrush(Color.FromArgb(bs[0], bs[1], bs[2], bs[3]));
            });
            this.Button.Dispatcher.Invoke(action);
            Thread.Sleep(20);
            var bs2 = ColorHelper.GetARGByStr("FF1B71B1");
            this.Button.Background = new SolidColorBrush(Color.FromArgb(bs2[0], bs2[1], bs2[2], bs2[3]));

        }

        private void Image_MouseLeave(object sender, MouseEventArgs e)
        {
            Action action = new Action(() =>
            {
                var bs = ColorHelper.GetARGByStr("FF505050");
                Button.Background = new SolidColorBrush(Color.FromArgb(bs[0], bs[1], bs[2], bs[3]));
            });
            this.Button.Dispatcher.Invoke(action);
            Thread.Sleep(20);
        }
    }
}
