using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Interaction logic for LevelMenuFrame.xaml
    /// </summary>
    public partial class LevelMenuButtonGroup : UserControl
    {
        public List<LevelMenuButtonMainItem> MainButtonGroup {
            set {
                CraeteMainButton(value);
            }
        }

        public List<LevelMenuButton> SonButtons1 { get; set; }
        public List<LevelMenuButton> SonButtons2 { get; set; }

        public LevelMenuButtonGroup()
        {
            InitializeComponent();
            SonButtons1 = new List<LevelMenuButton>();
            SonButtons2 = new List<LevelMenuButton>();
        }

        public void CraeteMainButton(List<LevelMenuButtonMainItem> items)
        {
            if(CheckItemsValidation(items,1) == 0)
            {
                MessageBox.Show("items不合法");
                return;
            }
            for(int i = 0; i < items.Count(); i++)
            {
                LevelMenuButton button = new LevelMenuButton(this);
                button.MainItem = items[i];
                ButtonGroup.Children.Add(button);
                SonButtons1.Add(button);
            }
        }

        private int CheckItemsValidation(List<LevelMenuButtonMainItem> items,int cnd)
        {
            foreach(var item in items)
            {
                if (cnd == 1 & item.placementMode != PlacementMode.Bottom)
                {
                    return 0;
                }else if (cnd > 1 & item.placementMode != PlacementMode.Right)
                {
                    return 0;
                }
                else if (item.SonItems != null)
                {
                    return CheckItemsValidation(item.SonItems, (cnd + 1));
                }
            }
            return 1;
        }

    }

    public class LevelMenuButtonMainItem
    {
        public string name { get; set; }
        public PlacementMode placementMode { get; set; }
        public RoutedEventHandler OnClick { get; set; }
        public List<LevelMenuButtonMainItem> SonItems { get; set; }
    }
}
