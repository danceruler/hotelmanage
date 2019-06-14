using MyControl;
using NewHM.View;
using NewHM.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewHM.ViewModel.Ps
{
    public class VM_PageTest: BaseViewModel
    {
        public VM_PageTest()
        {
            LevelMenuButton button = new LevelMenuButton();
            button.MainItem = new LevelMenuButtonMainItem()
            {
                name = "test1",
                SonItems = new List<LevelMenuButtonItem>()
                {
                    new LevelMenuButtonItem()
                    {
                        name = "son1"
                    },new LevelMenuButtonItem()
                    {
                        name = "son2"
                    },new LevelMenuButtonItem()
                    {
                        name = "son3"
                    },
                }
            };
            (this.UIElement as PageTest).MenuPanel.Children.Add(button);
        }
    }
}
