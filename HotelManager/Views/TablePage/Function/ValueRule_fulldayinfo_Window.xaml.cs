using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HotelManager.Views.TablePage.Function
{
    /// <summary>
    /// ValueRule_fulldayinfo_Window.xaml 的交互逻辑
    /// </summary>
    public partial class ValueRule_fulldayinfo_Window : Window
    {
        private Window thiswindow;

        private Page thispage;

        public ValueRule_fulldayinfo_Window()
        {
            InitializeComponent();
            this.Title = "添加正常入住标准";
        }

        public ValueRule_fulldayinfo_Window(Window window)
        {
            InitializeComponent();
            this.Title = "添加正常入住标准";
            this.thiswindow = window;
            this.Owner = window;
            this.WindowStartupLocation = WindowStartupLocation.CenterOwner;

        }

        public ValueRule_fulldayinfo_Window(Page page)
        {
            InitializeComponent();
            this.Title = "添加正常入住标准";
            this.thispage = page;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

        }

        private void PURadioButton_Checked(object sender, RoutedEventArgs e)
        {
            valuerule1.Visibility = Visibility.Visible;
            valuerule2.Visibility = Visibility.Hidden;
        }

        private void PURadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            valuerule1.Visibility = Visibility.Hidden;
            valuerule2.Visibility = Visibility.Visible;
        }
        //public static T DepthClone<T>(T t)
        //{
        //    T clone = default(T);
        //    using (Stream stream = new MemoryStream())
        //    {
        //        IFormatter formatter = new BinaryFormatter();
        //        try
        //        {
        //            formatter.Serialize(stream, t);
        //            stream.Seek(0, SeekOrigin.Begin);
        //            clone = (T)formatter.Deserialize(stream);
        //        }
        //        catch (SerializationException e)
        //        {
        //            Console.WriteLine("Failed to serialize. Reason: " + e.Message);
        //            throw;
        //        }
        //    }
        //    return clone;
        //}
    }
}
