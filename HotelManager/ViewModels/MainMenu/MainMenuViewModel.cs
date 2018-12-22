using HotelManager.ViewModels.Function;
using HotelManager.ViewModels.MainMenu.Pages.BsManager;
using HotelManager.ViewModels.MainMenu.Pages.BsManager.Pages;
using HotelManager.ViewModels.MainMenu.Pages.RoomState;
using HotelManager.ViewModels.TablePage;
using HotelManager.Views.FunctionWindow;
using HotelManager.Views.MainMenu;
using HotelManager.Views.MainMenu.Pages.BsManage;
using HotelManager.Views.MainMenu.Pages.BsManage.Pages;
using HotelManager.Views.MainMenu.Pages.RoomState;
using HotelManager.Views.TablePage;
using Panuon.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace HotelManager.ViewModels.MainMenu
{
    public class MainMenuViewModel
    {
        MainMenuWindow thiswindow;

        Color mainmenucolor = Color.FromRgb(237, 237, 239);

     

		public MainMenuViewModel(MainMenuWindow window)
        {
            thiswindow = window;
			thiswindow.containerpage = new BsManagerPage(thiswindow, out Pg_BsManagerViewModel sonviewmodel1);
			thiswindow.mainframe.Content = thiswindow.containerpage;
		}
		#region 后台管理菜单点击事件
		
		public ICommand ToBsManagerCommand
        {
            get { return new QueryCommand(ToBsManager); }
        }
        public void ToBsManager()
        {
			//if (thiswindow.sonpage == null)
			//{ 
			//    thiswindow.sonpage = new BsManagerPage(thiswindow, out Pg_BsManagerViewModel sonviewmodel1);
			//    thiswindow.sonpages.Add(thiswindow.sonpage1);
			//}
			//thiswindow.mainframe.Content = thiswindow.sonpage;
			//thiswindow.sonpage = new BsManagerPage(thiswindow, out Pg_BsManagerViewModel sonviewmodel1,thiswindow.mainframe);
			//thiswindow.sonpages.Add(thiswindow.sonpage1);
			thiswindow.fatherframe = new Frame();
			thiswindow.fatherframe.Width = thiswindow.Width - 80;
			thiswindow.fatherframe.Height = thiswindow.Height - 70;
			thiswindow.fatherframe.Content = new RoomInfoPage(thiswindow, out Pg_RoomInfoViewModel viewmodel);
			thiswindow.containerpage = new BsManagerPage(thiswindow, out Pg_BsManagerViewModel sonviewmodel1, thiswindow.fatherframe);
			thiswindow.mainframe.Content = thiswindow.containerpage;
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

			for (int i = 0; i < thiswindow.DomainTitleDocPanels.Count(); i++)
			{
				if (i == 0)
				{
					thiswindow.DomainTitleDocPanels[i].Width = double.NaN;
					thiswindow.DomainTitleDocPanels[i].Visibility = System.Windows.Visibility.Visible;
				}
				else
				{
					thiswindow.DomainTitleDocPanels[i].Width = 0;
				}
			}
		}

		public ICommand OpenAddRoomWindowCommand
		{
			get { return new QueryCommand(OpenAddRoomWindow); }
		}
		public void OpenAddRoomWindow()
		{
			new AddRoomWindow(thiswindow, out AddRoomViewModel viewmodel).ShowDialog();
		}

		public ICommand OpenEditRoomTypeCommand
		{
			get { return new QueryCommand(OpenEditRoomType); }
		}
		public void OpenEditRoomType()
		{
			new EditRoomTypeWindow(thiswindow, out EditRoomTypeViewModel viewmodel).ShowDialog();
		}

		public ICommand OpenEditRoomStateColorCommand
		{
			get { return new QueryCommand(OpenEditRoomStateColor); }
		}
		public void OpenEditRoomStateColor()
		{
			new EditRoomStateWindow(thiswindow, out EditRoomStateViewModel viewmodel).ShowDialog();
		}

		public  ICommand ToPersonInfoCommand
		{
			get { return new QueryCommand(ToPersonInfo); }
		}
		public void ToPersonInfo()
		{
			thiswindow.fatherframe = new Frame();
			thiswindow.fatherframe.Width = thiswindow.Width - 80;
			thiswindow.fatherframe.Height = thiswindow.Height - 70;
			thiswindow.fatherframe.Content = new PersonInfoTablePage(thiswindow.fatherframe, out PersonInfoTable_ViewModel viewmodel);
			thiswindow.containerpage = new BsManagerPage(thiswindow, out Pg_BsManagerViewModel sonviewmodel1, thiswindow.fatherframe);
			thiswindow.mainframe.Content = thiswindow.containerpage;
			
		}

		public ICommand BsManagerMenuToVR_FulldayCommand
		{
			get { return new QueryCommand(BsManagerMenuToVR_Fullday); }
		}
		public void BsManagerMenuToVR_Fullday()
		{
			//if (thiswindow.sonpage == null)
			//{ 
			//    thiswindow.sonpage = new BsManagerPage(thiswindow, out Pg_BsManagerViewModel sonviewmodel1);
			//    thiswindow.sonpages.Add(thiswindow.sonpage1);
			//}
			thiswindow.fatherframe = new Frame();
			thiswindow.fatherframe.Width = thiswindow.Width - 80;
			thiswindow.fatherframe.Height = thiswindow.Height - 70;
			thiswindow.fatherframe.Content = new ValueRule_fulldayPage(thiswindow.fatherframe, out ValueRule_fullday_ViewModel viewmodel);
			thiswindow.containerpage = new BsManagerPage(thiswindow, out Pg_BsManagerViewModel sonviewmodel1, thiswindow.fatherframe);
			thiswindow.mainframe.Content = thiswindow.containerpage;
			//thiswindow.mainframe.Content = thiswindow.sonpage;
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

			for (int i = 0; i < thiswindow.DomainTitleDocPanels.Count(); i++)
			{
				if (i == 0)
				{
					thiswindow.DomainTitleDocPanels[i].Width = double.NaN;
					thiswindow.DomainTitleDocPanels[i].Visibility = System.Windows.Visibility.Visible;
				}
				else
				{
					thiswindow.DomainTitleDocPanels[i].Width = 0;
				}
			}
		}
		#endregion

		public ICommand ToRoomStateCommand
        {
            get { return new QueryCommand(ToRoomState); }
        }
        public void ToRoomState()
        {
			//if (thiswindow.sonpage2 == null)
			//{
			//    thiswindow.sonpage2 = new RoomStatePage(thiswindow, out Pg_RoomStateViewModel sonviewmodel2);
			//    thiswindow.sonpages.Add(thiswindow.sonpage2);
			//}
			//thiswindow.mainframe.Content = thiswindow.sonpage2;
			thiswindow.fatherframe = new Frame();
			thiswindow.fatherframe.Width = thiswindow.Width - 80;
			thiswindow.fatherframe.Height = thiswindow.Height - 70;
			thiswindow.fatherframe.Content = new RoomStatePage(thiswindow, out Pg_RoomStateViewModel viewmodel);
			thiswindow.containerpage = new BsManagerPage(thiswindow, out Pg_BsManagerViewModel sonviewmodel1, thiswindow.fatherframe);
			thiswindow.mainframe.Content = thiswindow.containerpage;
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
			
			for(int i = 0; i < thiswindow.DomainTitleDocPanels.Count(); i++)
			{
				if(i == 1)
				{
					thiswindow.DomainTitleDocPanels[i].Width = double.NaN;
					thiswindow.DomainTitleDocPanels[i].Visibility = System.Windows.Visibility.Visible;
				}
				else
				{
					thiswindow.DomainTitleDocPanels[i].Width = 0;
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
