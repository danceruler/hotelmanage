using Caliburn.Micro;
using HotelManager.Helper;
using HotelManager.Models;
using HotelManager.Views.MainMenu.Pages.RoomState;
using Panuon.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace HotelManager.ViewModels.MainMenu.Pages.RoomState
{
    public class Pg_RoomStateViewModel
    {
        RoomStatePage thispage;
        string ranktype = "row";
        string rule1 = "0";
        string rule2 = "";
        string rule3 = "";
        string rule4 = "0";
        public Pg_RoomStateViewModel(RoomStatePage page)
        {
            thispage = page;
            InitPageData();
            thispage.rankrule.SelectionChanged += rank_change;
            thispage.filterule_row.SelectionChanged += filter_row_change;
            thispage.filterule_type.SelectionChanged += filter_type_change;
            thispage.filterule_state.SelectionChanged += filter_state_change;
            
            RoomHelper.LoadRoomInfoByWhat(thispage,thispage.roomcardgrid, 3, ranktype, rule1, rule2, rule3);
        }
        public BindableCollection<PUComboBoxItemModel> RankRuleItemsList
        {
            get { return _RankRuleItemsList; }
            set { _RankRuleItemsList = value; RaisePropertyChanged("RankRuleItemsList"); }
        }
        private BindableCollection<PUComboBoxItemModel> _RankRuleItemsList;


        public BindableCollection<PUComboBoxItemModel> RowsItemsList
        {
            get { return _RowsItemsList; }
            set { _RowsItemsList = value; RaisePropertyChanged("RowsItemsList"); }
        }
        private BindableCollection<PUComboBoxItemModel> _RowsItemsList;

        public BindableCollection<PUComboBoxItemModel> TypesItemsList
        {
            get { return _TypesItemsList; }
            set { _TypesItemsList = value; RaisePropertyChanged("TypesItemsList"); }
        }
        private BindableCollection<PUComboBoxItemModel> _TypesItemsList;

        public BindableCollection<PUComboBoxItemModel> StatesItemsList
        {
            get { return _StatesItemsList; }
            set { _StatesItemsList = value; RaisePropertyChanged("StatesItemsList"); }
        }
        private BindableCollection<PUComboBoxItemModel> _StatesItemsList;
        public BindableCollection<PUComboBoxItemModel> HourItemsList
        {
            get { return _HourItemsList; }
            set { _HourItemsList = value; RaisePropertyChanged("RankRuleItemsList"); }
        }
        private BindableCollection<PUComboBoxItemModel> _HourItemsList;

        public void InitPageData()
        {
            List<PUComboBoxItemModel> rankrulelist = new List<PUComboBoxItemModel>();
            rankrulelist.Add(new PUComboBoxItemModel()
            {
                Header = "按层数",
                CanDelete = false,
                Value = "按层数",
            });
            rankrulelist.Add(new PUComboBoxItemModel()
            {
                Header = "按房间类型",
                CanDelete = false,
                Value = "按房间类型",
            });
            rankrulelist.Add(new PUComboBoxItemModel()
            {
                Header = "按房间状态",
                CanDelete = false,
                Value = "按房间状态",
            });
            RankRuleItemsList = new BindableCollection<PUComboBoxItemModel>(rankrulelist);


            List<int> rowlist = new List<int>();
            List<string> typelist = new List<string>();
            List<int> statelist = new List<int>();
            List<RoomStateModel> roomstatelist = new List<RoomStateModel>();
            using (var context = new RetailContext())
            {
                rowlist = context.Database.SqlQuery<int>("SELECT distinct row FROM rooms order by row").ToList();
                typelist = context.Database.SqlQuery<string>("SELECT name FROM roomtypes").ToList();
                statelist = context.Database.SqlQuery<int>("SELECT distinct roomstate FROM rooms").ToList();
                roomstatelist = context.RoomStates.ToList();
            }
            List<PUComboBoxItemModel> rowslist = new List<PUComboBoxItemModel>();
            rowslist.Add(new PUComboBoxItemModel()
            {
                Header = "所有层数",
                CanDelete = false,
                Value = "所有层数",
            });
            for (int i = 0; i < rowlist.Count(); i++)
            {
                rowslist.Add(new PUComboBoxItemModel()
                {
                    Header = rowlist[i] + "",
                    CanDelete = false,
                    Value = rowlist[i],
                });
            }
            RowsItemsList = new BindableCollection<PUComboBoxItemModel>(rowslist);

            List<PUComboBoxItemModel> typeslist = new List<PUComboBoxItemModel>();
            typeslist.Add(new PUComboBoxItemModel()
            {
                Header = "所有类型",
                CanDelete = false,
                Value = "所有类型",
            });
            for (int i = 0; i < typelist.Count(); i++)
            {
                typeslist.Add(new PUComboBoxItemModel()
                {
                    Header = typelist[i],
                    CanDelete = false,
                    Value = typelist[i],
                });
            }
            TypesItemsList = new BindableCollection<PUComboBoxItemModel>(typeslist);

            List<PUComboBoxItemModel> stateslist = new List<PUComboBoxItemModel>();
            stateslist.Add(new PUComboBoxItemModel()
            {
                Header = "所有房态",
                CanDelete = false,
                Value = "所有房态",
            });
            for (int i = 0; i < statelist.Count(); i++)
            {
                stateslist.Add(new PUComboBoxItemModel()
                {
                    Header = statelist[i] + "",
                    CanDelete = false,
                    Value = statelist[i] + "",
                });
            }
            StatesItemsList = new BindableCollection<PUComboBoxItemModel>(stateslist);
            ShowStatesColors(thispage.StateColors, roomstatelist);
        }
        private void ShowStatesColors(StackPanel stackPanel, List<RoomStateModel> roomStates)
        {
            stackPanel.Children.Clear();
            int row = roomStates.Count() % 2 + roomStates.Count() / 2;
            for (int i = 0; i < row; i++)
            {
                DockPanel dockPanel = new DockPanel();
                dockPanel.Width = 160;
                dockPanel.Height = 60;
                Label label1 = new Label();
                label1.Width = 70;
                label1.Height = 50;
                label1.Margin = new Thickness(5, 5, 5, 5);
                label1.Content = roomStates[2 * i].Name;
                label1.HorizontalContentAlignment = HorizontalAlignment.Center;
                label1.VerticalContentAlignment = VerticalAlignment.Center;
                label1.Background = RoomHelper.ColorsConfig[roomStates[2 * i].Color];
                if (roomStates[2 * i].Color == "黑色" || roomStates[2 * i].Color == "紫色" || roomStates[2 * i].Color == "棕色" || roomStates[2 * i].Color == "蓝色")
                {
                    label1.Foreground = Brushes.White;
                }
                dockPanel.Children.Add(label1);
                if (2 * i + 1 < roomStates.Count())
                {
                    Label label2 = new Label();
                    label2.Width = 70;
                    label2.Height = 50;
                    label2.Margin = new Thickness(5, 5, 5, 5);
                    label2.Content = roomStates[2 * i + 1].Name;
                    label2.HorizontalContentAlignment = HorizontalAlignment.Center;
                    label2.VerticalContentAlignment = VerticalAlignment.Center;
                    label2.Background = RoomHelper.ColorsConfig[roomStates[2 * i + 1].Color];
                    if (roomStates[2 * i+1].Color == "黑色" || roomStates[2 * i + 1].Color == "紫色" || roomStates[2 * i + 1].Color == "棕色" || roomStates[2 * i + 1].Color == "蓝色")
                    {
                        label2.Foreground = Brushes.White;
                    }
                    dockPanel.Children.Add(label2);
                }
                stackPanel.Children.Add(dockPanel);
            }
        }
        public ICommand ReFlashRoomInfoCommand
        {
            get { return new QueryCommand(ReFlashRoomInfo); }
        }
        public ICommand FilterCommand
        {
            get { return new QueryCommand(Filter); }
        }
        public void ReFlashRoomInfo()
        {
            rule1 = "0";
            rule2 = "";
            rule3 = "";
            rule4 = "0";
            thispage.filterule_row.SelectedIndex = 0;
            thispage.filterule_type.SelectedIndex = 0;
            thispage.filterule_state.SelectedIndex = 0;
            RoomHelper.LoadRoomInfoByWhat(thispage,thispage.roomcardgrid, 3, ranktype, rule1, rule2, rule3);
        }
        public void Filter()
        {
            RoomHelper.LoadRoomInfoByWhat(thispage,thispage.roomcardgrid, 3, ranktype, rule1, rule2, rule3);
        }

        private void rank_change(object sender, SelectionChangedEventArgs e)
        {
            PUComboBox pucb = sender as PUComboBox;
            switch (pucb.SelectedValue.ToString())
            {
                case "按层数":
                    ranktype = "row";
                    break;
                case "按房间类型":
                    ranktype = "roomtype";
                    break;
                case "按房间状态":
                    ranktype = "roomstate";
                    break;
                default:
                    break;
            }
        }
        private void filter_row_change(object sender, SelectionChangedEventArgs e)
        {
            PUComboBox pucb = sender as PUComboBox;
            if (pucb.SelectedValue.ToString() == "所有层数")
            {
                rule1 = "0";
            }
            else
            {
                rule1 = pucb.SelectedValue.ToString();
            }
        }
        private void filter_type_change(object sender, SelectionChangedEventArgs e)
        {
            PUComboBox pucb = sender as PUComboBox;
            if (pucb.SelectedValue.ToString() == "所有类型")
            {
                rule2 = "";
            }
            else
            {
                rule2 = pucb.SelectedValue.ToString();
            }
        }
        private void filter_state_change(object sender, SelectionChangedEventArgs e)
        {
            PUComboBox pucb = sender as PUComboBox;
            if (pucb.SelectedValue.ToString() == "所有房态")
            {
                rule3 = "";
            }
            else
            {
                rule3 = pucb.SelectedValue.ToString();
            }
        }
        private void filter_hour_change(object sender, SelectionChangedEventArgs e)
        {
            PUComboBox pucb = sender as PUComboBox;
            if (pucb.SelectedValue.ToString() == "所有房态")
            {
                rule4 = "0";
            }
            else
            {
                rule4 = pucb.SelectedValue.ToString();
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
