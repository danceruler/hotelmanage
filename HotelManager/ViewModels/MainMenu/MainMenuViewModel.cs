using HotelManager.ViewModels.MainMenu.Pages.BsManager;
using HotelManager.ViewModels.MainMenu.Pages.RoomState;
using HotelManager.Views.MainMenu;
using HotelManager.Views.MainMenu.Pages.BsManage;
using HotelManager.Views.MainMenu.Pages.RoomState;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows.Media;

namespace HotelManager.ViewModels.MainMenu
{
    public class MainMenuViewModel
    {
        MainMenuWindow thiswindow;

        Color mainmenucolor = Color.FromRgb(237, 237, 239);

        public MainMenuViewModel()
        {

        }

        public MainMenuViewModel(MainMenuWindow window)
        {
            thiswindow = window;
        }

        public ICommand ToBsManagerCommand
        {
            get { return new QueryCommand(ToBsManager); }
        }


        public void ToBsManager()
        {
            if (thiswindow.sonpage1 == null)
            { 
                thiswindow.sonpage1 = new BsManagerPage(thiswindow, out Pg_BsManagerViewModel sonviewmodel1);
                thiswindow.sonpages.Add(thiswindow.sonpage1);
            }
            thiswindow.mainframe.Content = thiswindow.sonpage1;
            for (int i = 0; i < thiswindow.mmbuttons.Count(); i++)
            {
                if (i == 0)
                {
                    thiswindow.mmbuttons[i].Background = new SolidColorBrush(mainmenucolor);
                    thiswindow.mmbuttons[i].Opacity = 0.7;
                }
                else
                {
                    thiswindow.mmbuttons[i].Background = Brushes.Transparent;
                }
            }
        }

        public ICommand ToRoomStateCommand
        {
            get { return new QueryCommand(ToRoomState); }
        }
        public void ToRoomState()
        {
            if (thiswindow.sonpage2 == null)
            {
                thiswindow.sonpage2 = new RoomStatePage(thiswindow, out Pg_RoomStateViewModel sonviewmodel2);
                thiswindow.sonpages.Add(thiswindow.sonpage2);
            }
            thiswindow.mainframe.Content = thiswindow.sonpage2;
            for (int i = 0; i < thiswindow.mmbuttons.Count(); i++)
            {
                if (i == 1)
                {
                    thiswindow.mmbuttons[i].Background = new SolidColorBrush(mainmenucolor);
                    thiswindow.mmbuttons[i].Opacity = 0.7;
                }
                else
                {
                    thiswindow.mmbuttons[i].Background = Brushes.Transparent;
                }
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Methods
        private void RaisePropertyChanged(string propertyName)
        {
            // take a copy to prevent thread issues
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
