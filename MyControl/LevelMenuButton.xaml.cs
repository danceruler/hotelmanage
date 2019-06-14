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
    /// Interaction logic for LevelMenuButton.xaml
    /// </summary>
    public partial class LevelMenuButton : UserControl
    {
        public LevelMenuButtonMainItem MainItem { set { CreateMainButton(value); } }

        public LevelMenuButton()
        {
            InitializeComponent();
        }

        private void CreateMainButton(LevelMenuButtonMainItem item)
        {
            Button button = new Button();
            button.Background = Brushes.White;
            button.Width = 100;
            button.Height = 30;
            button.Content = item.name;
            button.Click += (s,e) => {
                SonPopup.IsOpen = SonPopup.IsOpen == true ? false : true;
            };
            this.Panel.Children.Add(button);
            foreach(LevelMenuButtonItem sonitem in item.SonItems)
            {
                Button button2 = new Button();
                button2.Background = Brushes.White;
                button2.Width = 100;
                button2.Height = 30;
                button2.Content = sonitem.name;
                this.SonPanel.Children.Add(button2);
            }
        }
    }

    public class LevelMenuButtonMainItem
    {
        public string name { get; set; }
        public List<LevelMenuButtonItem> SonItems { get; set; }
    }

    public class LevelMenuButtonItem
    {
        public string name { get; set; }
        //public List<LevelMenuButtonItem> SonItems { get; set; }
    }
}
