using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Interaction logic for MainPageMenuButton.xaml
    /// </summary>
    public partial class MainPageMenuButton : UserControl
    {
        public MainPageMenuButton()
        {
            InitializeComponent();
        }

        public string Text { set { this.Label.Content = value; } }

        public Brush BackGround { set { this.Panel.Background = value; } }

        public string Src { set { this.Ico.Source = new BitmapImage(new Uri(value, UriKind.Relative)); } }

        public void Click(MouseButtonEventHandler e)
        {
            this.Panel.MouseUp += e;
        }

        private void Panel_MouseEnter(object sender, MouseEventArgs e)
        {
            Label.Foreground = Brushes.Black;
        }

        private void Panel_MouseLeave(object sender, MouseEventArgs e)
        {
            Label.Foreground = Brushes.White;
        }
    }
}
