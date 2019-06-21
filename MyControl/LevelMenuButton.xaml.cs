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
    /// Interaction logic for LevelMenuButton.xaml
    /// </summary>
    public partial class LevelMenuButton : UserControl
    {
        public LevelMenuButtonMainItem MainItem { set { CreateMainButton(this,value); } }

        public PlacementMode Placement {
            set {
                SonPopup.Placement = value;
            }
        }

        private LevelMenuButtonGroup Group { get; set; }

        public LevelMenuButton(LevelMenuButtonGroup group)
        {
            InitializeComponent();
            Group = group;
            //SonPopup.PlacementTarget = Panel;
        }

        private void CreateMainButton(LevelMenuButton mainButton,LevelMenuButtonMainItem item)
        {
            SonPopup.Placement = item.placementMode;
            Button.Content = item.name;
            if(item.SonItems.Count() == 0)
            {
                Arrow.Source = BlankSource;
                Button.Click += (s, e) =>
                {
                    foreach (var pp in Group.SonButtons1)
                    {
                        ChangePopupType(pp, false);
                    }
                    foreach (var pp in Group.SonButtons2)
                    {
                        ChangePopupType(pp, false);
                    }
                };
                if (item.OnClick != null & item.SonItems.Count() == 0)
                {
                    Button.Click += item.OnClick;
                }
            }
            else
            {
                Arrow.Source = OpenSource;
                Button.Click += (s, e) =>
                {
                    if (item.placementMode == PlacementMode.Bottom)
                    {
                        if (SonPopup.IsOpen == false)
                        {
                            foreach (var pp in Group.SonButtons1)
                            {
                                ChangePopupType(pp, false);
                            }
                            foreach (var pp in Group.SonButtons2)
                            {
                                ChangePopupType(pp, false);
                            }
                            Arrow.Source = CloseSource;
                        }
                        else
                        {
                            Arrow.Source = OpenSource;
                        }
                    }
                    else if (item.placementMode == PlacementMode.Right)
                    {
                        if (SonPopup.IsOpen == false)
                        {
                            foreach (var pp in Group.SonButtons2)
                            {
                                ChangePopupType(pp, false);
                            }
                            Arrow.Source = CloseSource;
                        }
                        else
                        {
                            Arrow.Source = OpenSource;
                        }
                    }
                    SonPopup.IsOpen = SonPopup.IsOpen == true ? false : true;
                };

                MainPanel.MouseUp += (s, e) =>
                {
                    if (item.placementMode == PlacementMode.Bottom)
                    {
                        if (SonPopup.IsOpen == false)
                        {
                            foreach (var pp in Group.SonButtons1)
                            {
                                ChangePopupType(pp, false);
                            }
                            foreach (var pp in Group.SonButtons2)
                            {
                                ChangePopupType(pp, false);
                            }
                            Arrow.Source = CloseSource;
                        }
                        else
                        {
                            Arrow.Source = OpenSource;
                        }
                    }
                    else if (item.placementMode == PlacementMode.Right)
                    {
                        if (SonPopup.IsOpen == false)
                        {
                            foreach (var pp in Group.SonButtons2)
                            {
                                ChangePopupType(pp, false);
                            }
                            Arrow.Source = CloseSource;
                        }
                        else
                        {
                            Arrow.Source = OpenSource;
                        }
                    }
                    SonPopup.IsOpen = SonPopup.IsOpen == true ? false : true;
                };
            }
            
            foreach (var sonitem in item.SonItems)
            {
                LevelMenuButton newButton = new LevelMenuButton(Group);
                newButton.MainItem = sonitem;
                SonPanel.Children.Add(newButton);
                if(sonitem.placementMode == PlacementMode.Right)
                {
                    Group.SonButtons2.Add(newButton);
                }
            }
            //设置button样式
            if(item.placementMode == PlacementMode.Bottom)
            {

            }
        }

        private void ChangePopupType(LevelMenuButton button,bool isShow)
        {
            button.SonPopup.IsOpen = isShow;
            if(button.SonPanel.Children.Count > 0)
            {
                button.Arrow.Source = isShow == false ? Arrow.Source = OpenSource : CloseSource;
            }
            else
            {
                button.Arrow.Source = BlankSource;
            }
        }

        private void SetButtonStyle(int type)
        {
            if(type == 0)
            {
                
            }else if(type == 1)
            {

            }else if(type == 2)
            {

            }
        }
        
        #region 静态常量
        //public static BitmapImage OpenSource = new BitmapImage(new Uri("/images/Ico/加.png", UriKind.Relative));
        //public static BitmapImage CloseSource = new BitmapImage(new Uri("/images/Ico/减.png", UriKind.Relative));
        public static BitmapImage OpenSource = new BitmapImage(new Uri("/images/Ico/Rec/md-square-outline.png", UriKind.Relative));
        public static BitmapImage CloseSource = new BitmapImage(new Uri("/images/Ico/Rec/md-square.png", UriKind.Relative));
        public static BitmapImage BlankSource = new BitmapImage(new Uri("", UriKind.Relative));
        #endregion
    }

}
