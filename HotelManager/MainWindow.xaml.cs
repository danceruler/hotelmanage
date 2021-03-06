﻿using HotelManager.ViewModels.Login;
using HotelManager.ViewModels.MainMenu;
using HotelManager.Views;
using HotelManager.Views.Login;
using HotelManager.Views.MainMenu;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HotelManager.Models;
using HotelManager.Views.FunctionWindow;
using HotelManager.ViewModels.Function;
using HotelManager.Helper;
using HotelManager.Views.TablePage;
using Newtonsoft.Json;
using System.Diagnostics;

namespace HotelManager
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
			//Configs.InitConnection();
			//Version ver = System.Environment.OSVersion.Version;
			//关掉已运行的进程实例
			Process ps = GetRunningInstance();
			if (ps != null) this.Close();
		}

		//获取已运行的进程实例
		public static Process GetRunningInstance()
		{
			Process currentProcess = Process.GetCurrentProcess(); //获取当前进程 
																  //获取当前运行程序完全限定名 
			string currentFileName = currentProcess.MainModule.FileName;
			//获取进程名为ProcessName的Process数组。 
			Process[] processes = Process.GetProcessesByName(currentProcess.ProcessName);
			//遍历有相同进程名称正在运行的进程 
			foreach (Process process in processes)
			{
				if (process.MainModule.FileName == currentFileName)
				{
					if (process.Id != currentProcess.Id) //根据进程ID排除当前进程 
						return process;//返回已运行的进程实例 
				}
			}
			return null;
		}

		private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (RetailContext context = new RetailContext())
            {
                //List<Person> people = conetxt.Persons.ToList();
                //XmlHelper.WriteNowPerson(people[0]);
                PersonType personType = new PersonType()
                {
                    ID = Guid.NewGuid(),
                    Name = "超级管理员",
                    Domains = "all",
                };
                context.PersonTypes.Add(personType);
                context.SaveChanges();
            }
            //XmlHelper.SelectNowPerson();

            //ToServerDataHelper.SynchronizeRoomInfo();
            //string path = AppDomain.CurrentDomain.BaseDirectory;
            //string rootpath = path.Substring(0, path.LastIndexOf("bin"));
            //rootpath += "AppData\\xml\\XMLFile1.xml";
            //XmlHelper xmlHelper = new XmlHelper();
            //xmlHelper.SelectAttribute(rootpath);
            //double x = SystemParameters.WorkArea.Width;//得到屏幕工作区域宽度
            //double y = SystemParameters.WorkArea.Height;//得到屏幕工作区域高度
            //RetailContext context = new RetailContext();
            ////List<Room> list = context.Rooms.ToList();
            ////Guid test = list[0].roomID;
            ////string t = ConvertGuid(test);
            ////Room room = context.Database.SqlQuery<Room>(string.Format("SELECT * FROM Rooms WHERE UPPER(HEX([roomID]))='{0}'", "D606C4B8AA28DF4BA6D45E48750853A9")).ToList()[0];
            ////MessageBox.Show(room.roomname);
            ////string sql = string.Format("update Rooms  set roomstate = {1} where UPPER(HEX([roomID]))='{0}' ", "D606C4B8AA28DF4BA6D45E48750853A9", "1");
            ////context.Database.ExecuteSqlCommand(sql);
            ////context.SaveChanges();
            //for(int i = 2; i < 100; i++)
            //{
            //    ValueRule_fullday valueRule_Fullday = new ValueRule_fullday()
            //    {
            //        ID = Guid.NewGuid(),
            //        name = "test"+i,
            //        starthalfprice_time = i.ToString(),
            //        startprice_time = i.ToString(),
            //    };
            //    context.ValueRule_fulldays.Add(valueRule_Fullday);
            //}

            //context.SaveChanges();


            //context.RoomTypes.Add(new RoomType() { Cap = 1, Name = "单人间",ID=Guid.NewGuid(), CanChange=false, IsChecked=false });
            //context.RoomTypes.Add(new RoomType() { Cap = 2, Name = "双人间", ID = Guid.NewGuid(), CanChange = false, IsChecked = false });
            //context.RoomTypes.Add(new RoomType() { Cap = 3, Name = "三人间", ID = Guid.NewGuid(), CanChange = false, IsChecked = false });
            //context.RoomTypes.Add(new RoomType() { Cap = 1, Name = "大床间", ID = Guid.NewGuid(), CanChange = false, IsChecked = false });
            //context.RoomTypes.Add(new RoomType() { Cap = 1, Name = "套间", ID = Guid.NewGuid(), CanChange = false, IsChecked = false });
            //context.RoomTypes.Add(new RoomType() { Cap = 1, Name = "豪华间", ID = Guid.NewGuid(), CanChange = false, IsChecked = false });
            //context.SaveChanges();


        }
        private void PUButton_Click(object sender, RoutedEventArgs e)
        {
            using (RetailContext context = new RetailContext())
            {
                var need = context.RoomTypes.Add(new RoomType()
                {
                    Name = "test",
                    Cap = 2,
                    Color = "sd",
                    ID = Guid.NewGuid()
                });
                context.SaveChanges();
            }
        }
        private void ToLogin(object sender, RoutedEventArgs e)
        {
            LoginViewModel viewmodel;
            LoginWindow window = new LoginWindow(this,out viewmodel);
            window.Owner = this;
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.ShowDialog();
        }

        private void ToMainMenu(object sender, RoutedEventArgs e)
        {
            MainMenuViewModel viewmodel;
            MainMenuWindow window = new MainMenuWindow(this, out viewmodel);
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.ShowDialog();
        }

        private void ToAddRoom(object sender, RoutedEventArgs e)
        {
            new AddRoomWindow(this, out AddRoomViewModel viewModel).ShowDialog();
        }

        private void ToEditRoomType(object sender, RoutedEventArgs e)
        {
            new EditRoomTypeWindow(this, out EditRoomTypeViewModel viewModel).ShowDialog();
        }

        private void testcombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            var test = comboBox.Items[0];
            MessageBox.Show(test.GetType().ToString());
            //ComboBoxItem textBlock = comboBox.SelectedItem as ComboBoxItem;
            //TextBlock textBlock2 = textBlock.Content as TextBlock;
            //MessageBox.Show(textBlock2.Text.ToString());
        }

        private void ToOpenRoom(object sender, RoutedEventArgs e)
        {
            new OpenRoomWindow(this,Guid.NewGuid()).ShowDialog();
        }

        private string ConvertGuid(Guid gd)
        {
            string sgd = gd.ToString().ToUpper();
            string sVar = "";
            int i;

            foreach (string sv in new string[] {
        sgd.Substring(0, 8), sgd.Substring(9, 4), sgd.Substring(14, 4) })
            {
                for (i = sv.Length - 2; i >= 0; i -= 2)
                {
                    sVar += sv.Substring(i, 2);
                }
            }

            sgd = sgd.Substring(19).Replace("-", "");
            for (i = 0; i < 8; i++)
            {
                sVar += sgd.Substring(2 * i, 2);
            }

            return sVar;
        }

        private void ToDataPicker(object sender, RoutedEventArgs e)
        {
            DataPickerWindow window = new DataPickerWindow(this,out DataPickerViewModel viewModel);
            window.ShowDialog();
        }

        private void ToTableWindow(object sender, RoutedEventArgs e)
        {
            new TestableWindow().ShowDialog();
        }

        
    }
}
