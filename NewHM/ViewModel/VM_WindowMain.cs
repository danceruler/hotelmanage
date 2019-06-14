using MyControl;
using NewHM.Help;
using NewHM.Model;
using NewHM.View;
using NewHM.ViewModel.Base;
using NewHM.ViewModel.Ps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace NewHM.ViewModel
{
    public class VM_WindowMain:BaseViewModel
    {
        private VM_PageMain mainPage;
        private Dictionary<string,Page> menuPages = new Dictionary<string, Page>();
        private Dictionary<string, MenuButton> menuButtons = new Dictionary<string, MenuButton>();

        public VM_WindowMain()
        {
            mainPage = new VM_PageMain(this);
            CreateMenu("首页", (mainPage.UIElement as Page), false);
            //VM_PageTest vM_PageTest = new VM_PageTest();
            //CreateMenu("首页", (vM_PageTest.UIElement as Page), true);
            //VM_PageTest2 vM_PageTest2 = new VM_PageTest2();
            //CreateMenu("首页", (vM_PageTest2.UIElement as Page), true);
        }

        #region createfunc
        public void CreateMenu(string title,Page page,bool canClose)
        {
            FocusButton(title);
            if (menuPages.Keys.Contains(title))
            {
                (UIElement as WindowMain).PageFrame.Content = menuPages[title];
            }
            else
            {
                (UIElement as WindowMain).PageFrame.Content = page;
                MenuButton button = new MenuButton();
                button.CanClose = canClose;
                button.Text = title;
                button.Close((s, e) => {
                    menuPages.Remove(title);
                    menuButtons.Remove(title);
                    (UIElement as WindowMain).MenuPanel.Children.Remove(button);
                    if((UIElement as WindowMain).MenuPanel.Children.Count == 1)
                    {
                        (UIElement as WindowMain).PageFrame.Content = (mainPage.UIElement as Page);
                    }
                });
                button.Click((s, e) => {
                    (UIElement as WindowMain).PageFrame.Content = page;
                    FocusButton(title);
                });
                var bs2 = ColorHelp.GetARGByStr(MyColors.MainWindow_Blue);
                button.Background = new SolidColorBrush(Color.FromArgb(bs2[0], bs2[1], bs2[2], bs2[3]));
                (UIElement as WindowMain).MenuPanel.Children.Add(button);
                menuPages.Add(title, page);
                menuButtons.Add(title, button);
            }
        }

        public void FocusButton(string title)
        {
            foreach (string key in menuButtons.Keys)
            {
                if (key == title)
                {
                    var bs = ColorHelp.GetARGByStr(MyColors.MainWindow_Blue);
                    menuButtons[key].Background = new SolidColorBrush(Color.FromArgb(bs[0], bs[1], bs[2], bs[3]));
                }
                else
                {
                    var bs = ColorHelp.GetARGByStr(MyColors.MainWindow_Gray);
                    menuButtons[key].Background = new SolidColorBrush(Color.FromArgb(bs[0], bs[1], bs[2], bs[3]));
                }
            }
        }
        #endregion
        
    }
}
