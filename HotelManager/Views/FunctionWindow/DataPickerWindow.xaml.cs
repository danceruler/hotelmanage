using HotelManager.ViewModels.Function;
using Panuon.UI;
using System;
using System.Collections.Generic;
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

namespace HotelManager.Views.FunctionWindow
{
    /// <summary>
    /// DataPickerWindow.xaml 的交互逻辑
    /// </summary>
    public partial class DataPickerWindow : Window
    {
        private int isclosetrans;
        private TextBox fathertextbox;
        public DataPickerWindow(Window window,out DataPickerViewModel viewModel)
        {
            InitializeComponent();
            isclosetrans = 0;
            this.Owner = window;
            this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            viewModel = new DataPickerViewModel(this);
            this.DataContext = viewModel;
            
        }

        public DataPickerWindow(Window window, TextBox textbox,out DataPickerViewModel viewModel, DatePickerModes datePickerModes)
        {
            InitializeComponent();
            isclosetrans = 0;
            this.Owner = window;
            this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            viewModel = new DataPickerViewModel(this, datePickerModes);
            this.DataContext = viewModel;
            this.fathertextbox = textbox;
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
                if (positionToCloseIcon.X >= 0 && positionToCloseIcon.X < closeicon.ActualWidth && positionToCloseIcon.Y >= 0 && positionToCloseIcon.Y < closeicon.ActualHeight)
                {
                    this.Close();
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

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            this.fathertextbox.Text = this.timeString.Text;
            this.Close();
        }
    }




}
