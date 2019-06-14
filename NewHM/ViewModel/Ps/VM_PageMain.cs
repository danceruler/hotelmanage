using MyControl;
using NewHM.db;
using NewHM.Help;
using NewHM.Model;
using NewHM.View;
using NewHM.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace NewHM.ViewModel.Ps
{
    public class VM_PageMain : BaseViewModel
    {
        private VM_WindowMain VM_FatherWindow;

        public VM_PageMain(VM_WindowMain VM_WindowMain)
        {

            VM_FatherWindow = VM_WindowMain;
            //获取当前用户和权限
            var user = db.HotelUser.OrderByDescending(t =>t.id).FirstOrDefault();
            var levelPowers = db.HotelUserLevelPowers.SingleOrDefault(t => t.Level == user.Level);
            string[] s_menups = levelPowers.MenuPowers.Split(',');
            var menuPowers = TSqlHelp<HotelMenuPower>.SelectByModel(s_menups, "id");
            string[] s_tableps = levelPowers.TablePowers.Split(',');
            var tablePowers = TSqlHelp<HotelTablePower>.SelectByModel(s_tableps, "id");
            
            //根据menuPowers生成主页菜单
            for (int i = 0; i < menuPowers.Count(); i++)
            {
                CreateMainPageMenu(menuPowers[i], i);
            }

        }

        public void CreateMainPageMenu(HotelMenuPower hotelMenu,int index)
        {
            PageMain page = this.UIElement as PageMain;
            MainPageMenuButton button = new MainPageMenuButton();
            button.Text = hotelMenu.Name;
            var color_argb = ColorHelp.GetARGByStr(hotelMenu.color);
            button.BackGround = new SolidColorBrush(Color.FromArgb(color_argb[0], color_argb[1], color_argb[2], color_argb[3]));
            button.Src = hotelMenu.img;
            switch (hotelMenu.id)
            {
                case 1:
                    button.Click((s, e) =>
                    {
                        VM_PageTest vM_PageTest = new VM_PageTest();
                        VM_FatherWindow.CreateMenu(hotelMenu.Name, (vM_PageTest.UIElement as Page), true);
                    });
                    break;
                case 2:
                    button.Click((s, e) =>
                    {
                        VM_PageTest2 vM_PageTest2 = new VM_PageTest2();
                        VM_FatherWindow.CreateMenu(hotelMenu.Name, (vM_PageTest2.UIElement as Page), true);
                    });
                    break;
                case 3:
                    button.Click((s, e) =>
                    {
                        VM_PageTest vM_PageTest1 = new VM_PageTest();
                        VM_FatherWindow.CreateMenu(hotelMenu.Name, (vM_PageTest1.UIElement as Page), true);
                    });
                    break;
                default:
                    break;
            }
            if(index >= 4)
            {
                page.MainPage_MenuPanel2.Children.Add(button);
            }
            else
            {
                page.MainPage_MenuPanel.Children.Add(button);
            }
            
        }



    }
}
