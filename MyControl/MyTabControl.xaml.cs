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
    /// Interaction logic for MyTabControl.xaml
    /// </summary>
    public partial class MyTabControl : UserControl
    {
        public Dictionary<string, MyTabControlItem> ItemDics = new Dictionary<string, MyTabControlItem>();


        public MyTabControl()
        {
            InitializeComponent();
           
        }



        public void ShowItem(string title,UIElement content)
        {
            bool IsExist = false;
            foreach(string key in ItemDics.Keys)
            {
                if(key == title)
                {
                    //聚焦该title显示该content
                    FocusOnTitle(title);
                    IsExist = true;
                    break;
                }
            }

            if (!IsExist)
            {
                MyTabControlItem item = new MyTabControlItem();
                item.Title = title;
                item.Content = content;
                MenuButton menuButton = new MenuButton();
                menuButton.NewHeight = 30;
                menuButton.NewWidth = 120;
                menuButton.Text = title;
                menuButton.Close((s, e) =>
                {
                    DeleteItem(title);
                });
                menuButton.Click((s, e) =>
                {
                    FocusOnTitle(title);
                });
                item.Button = menuButton;
                ItemDics.Add(title, item);
                //添加选择按钮和对应的content到页面

            }
        }

        public void DeleteItem(string title)
        {

        }

        public void FocusOnTitle(string title)
        {

        }

    }

    public class MyTabControlItem
    {
        public string Title { get; set; }
        public MenuButton Button { get; set; }
        public UIElement Content { get; set; }
    }
}
