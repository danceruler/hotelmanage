using Caliburn.Micro;
using HotelManager.Helper;
using HotelManager.Models;
using HotelManager.ViewModels.MainMenu;
using HotelManager.ViewModels.TablePage;
using HotelManager.ViewModels.MainMenu.Pages.BsManager;
using HotelManager.ViewModels.MainMenu.Pages.BsManager.Pages;
using HotelManager.Views.MainMenu.Pages.BsManage;
using HotelManager.Views.MainMenu.Pages.BsManage.Pages;
using HotelManager.Views.MainMenu.Pages.RoomState;
using Panuon.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using HotelManager.Views.TablePage;

namespace HotelManager.Views.MainMenu
{
    /// <summary>
    /// MainMenuWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainMenuWindow : Window
    {
        public Window fatherwindow;
        public Window sonwindow;
        

        private int isclosetrans;

        public List<Button> mmbuttons = new List<Button>();
        public List<Page> sonpages = new List<Page>();
		public List<DockPanel> DomainTitleDocPanels = new List<DockPanel>();


		public BsManagerPage containerpage;
		public Page sonpage;
		//各个报表或信息页面,用来放在PUTabController里
		public Frame fatherframe = new Frame();

		public MainMenuWindow()
        {
            InitializeComponent(); isclosetrans = 0;
            mmbuttons.Add(ToBsManagerButton);
            mmbuttons.Add(ToRoomState);
            double x = SystemParameters.WorkArea.Width;//得到屏幕工作区域宽度
            double y = SystemParameters.WorkArea.Height;//得到屏幕工作区域高度
        }

        public MainMenuWindow(Window window,out MainMenuViewModel viewmodel)
        {
            InitializeComponent();
            isclosetrans = 0;
            this.fatherwindow = window;
           
            mmbuttons.Add(ToBsManagerButton);
            mmbuttons.Add(ToRoomState);
			DomainTitleDocPanels.Add(BsManagerMenu);
			DomainTitleDocPanels.Add(RoomStateMenu);

			double x = SystemParameters.WorkArea.Width;//得到屏幕工作区域宽度
            double y = SystemParameters.WorkArea.Height;//得到屏幕工作区域高度
            //this.ShowInTaskbar = false;
            this.Height = y;
			this.Width = x;

			//获取当前用户并分配权限
			Person nowPerson = XmlHelper.SelectNowPerson();
			string domains_string = "";
			using (RetailContext context = new RetailContext())
			{
				domains_string = context.PersonTypes.Where(t => t.Name == nowPerson.Type).SingleOrDefault().Domains;
			}
			string[] domains_strings = domains_string.Split(',');
			int cnd = 1;
			if(domains_string == "all")
			{
				for (int i = 0; i < mmbuttons.Count(); i++)
				{
					mmbuttons[i].Visibility = Visibility.Visible;
					mmbuttons[i].SetValue(Grid.RowProperty, cnd++);
				}
			}
			else
			{
				for (int i = 0; i < mmbuttons.Count(); i++)
				{
					if (domains_strings.Contains((i+1).ToString()))
					{
						mmbuttons[i].Visibility = Visibility.Visible;
						mmbuttons[i].SetValue(Grid.RowProperty, cnd++);
					}
					else
					{
						mmbuttons[i].Visibility = Visibility.Hidden;
					}
					
				}
			}

			//设置存在containerpage中的tancontroller的frame
			fatherframe.Width = x - 80;
			fatherframe.Height = y - 70;

			viewmodel = new MainMenuViewModel(this);
			this.DataContext = viewmodel;
		}

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            // 获取鼠标相对位置 
            Point positionToTite = e.GetPosition(titlebar);
            Point positionToCloseIcon = e.GetPosition(closeicon);

            
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                // 如果鼠标位置在标题栏内，允许拖动 
                if (positionToTite.X >= 0 && positionToTite.X < titlebar.ActualWidth && positionToTite.Y >= 0 && positionToTite.Y < titlebar.ActualHeight)
                {
                    this.DragMove();
                }
            }
            if (e.LeftButton == MouseButtonState.Released)
            {
                if (fatherwindow != null)
                {
                    if (positionToCloseIcon.X >= 0 && positionToCloseIcon.X < closeicon.ActualWidth && positionToCloseIcon.Y >= 0 && positionToCloseIcon.Y < closeicon.ActualHeight)
                    {
                        this.Close();
                    }
                }
                else
                {
                    if (positionToCloseIcon.X >= 0 && positionToCloseIcon.X < closeicon.ActualWidth && positionToCloseIcon.Y >= 0 && positionToCloseIcon.Y < closeicon.ActualHeight)
                    {
                        this.Close();
                    }
                }

            }


        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            WhileMouseMoveTrans(closeicongrid, closeicon, e, 1.5, 90, ref isclosetrans);

        }

        //当鼠标移动到Image上时旋转控件,旋转时间默认0.3秒
        //flag 默认0为未旋转，1为已旋转
        public void WhileMouseMoveTrans(Grid border, Image control, MouseEventArgs e, double speed, int angle, ref int flag)
        {
            Point position = e.GetPosition(border);
            Point position2 = e.GetPosition(control);
            if (position2.X >= 0 && position2.X < control.ActualWidth && position2.Y >= 0 && position2.Y < control.ActualHeight)
            {
                if (flag == 0)
                {
                    Storyboard storyboard = new Storyboard();//创建故事板
                    DoubleAnimation doubleAnimation = new DoubleAnimation();//实例化一个Double类型的动画
                    RotateTransform rotate = new RotateTransform();//旋转转换实例
                    control.RenderTransform = rotate;//给图片空间一个转换的实例
                    //storyboard.RepeatBehavior = RepeatBehavior.Forever;//设置重复为 一直重复
                    storyboard.SpeedRatio = speed;//播放的数度
                                                  //设置从0 旋转360度
                    doubleAnimation.From = 0;
                    doubleAnimation.To = angle;
                    doubleAnimation.Duration = new Duration(new TimeSpan(0, 0, 0, 0, 300));//播放时间长度为2秒
                    Storyboard.SetTarget(doubleAnimation, control);//给动画指定对象
                    Storyboard.SetTargetProperty(doubleAnimation,
                        new PropertyPath("RenderTransform.Angle"));//给动画指定依赖的属性
                    storyboard.Children.Add(doubleAnimation);//将动画添加到动画板中
                    storyboard.Begin(control);//启动动画
                    flag = 1;
                }
            }
            if (position.X < 0 || position.X >= border.ActualWidth || position.Y < 0 || position.Y >= border.ActualHeight)
            {
                flag = 0;
            }
        }

		private void BsManagerMenuToPerInfoTable(object sender, RoutedEventArgs e)
		{
		
			
		}
	}
}
