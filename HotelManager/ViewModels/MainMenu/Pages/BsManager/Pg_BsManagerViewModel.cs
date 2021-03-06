﻿using Caliburn.Micro;
using HotelManager.Views.MainMenu.Pages.BsManage;
using Panuon.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace HotelManager.ViewModels.MainMenu.Pages.BsManager
{
    public class Pg_BsManagerViewModel
    {
        BsManagerPage thispage;
        public BindableCollection<PUTabItemModel> _thisputabitems;
        public BindableCollection<PUTabItemModel> thisputabitems
        {
            get { return _thisputabitems; }
            set
            {
                _thisputabitems = value;
                RaisePropertyChanged("thisputabitems");
            }
        }


        public Pg_BsManagerViewModel(BsManagerPage page)
        {
            thispage = page;
            thisputabitems = new BindableCollection<PUTabItemModel>(thispage.bsmanageritems);
        }


		public ICommand addCommand
		{
			get { return new QueryCommand(addItems); }
		}

		public void addItems()
		{
			thisputabitems.Add(new PUTabItemModel()
			{
				Header = "2",
				Content = "2",
				CanDelete = false,
				Icon = null,
			});
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
