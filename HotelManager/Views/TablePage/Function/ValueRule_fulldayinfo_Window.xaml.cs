using HotelManager.Helper;
using HotelManager.Models;
using HotelManager.ViewModels.TablePage;
using HotelManager.Views.FunctionWindow;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
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
        private int type;
        private Guid id; 
        //public List<ComboBoxItem> confirm_fulldayprice_time_type_list = new List<ComboBoxItem>();

        public ValueRule_fulldayinfo_Window()
        {
            InitializeComponent();
            this.Title = "添加正常入住标准";
            type = 0;
            setDefaultValue();
            InitData();
            
        }

        public ValueRule_fulldayinfo_Window(Window window)
        {
            InitializeComponent();
            this.Title = "添加正常入住标准";
            this.thiswindow = window;
            this.Owner = window;
            this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            type = 0;
            setDefaultValue();
            InitData();

        }

        public ValueRule_fulldayinfo_Window(Page page)
        {
            InitializeComponent();
            this.Title = "添加正常入住标准";
            this.thispage = page;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            type = 0;
            setDefaultValue();
            InitData();
        }

        public ValueRule_fulldayinfo_Window(Page page,Guid ID)
        {
            InitializeComponent();
            this.Title = "添加正常入住标准";
            this.thispage = page;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            type = 1;
            id = ID;
            setDefaultValue();
            InitData();
        }

        public void setDefaultValue()
        {
            
            for (int i = 0; i < 24; i++)
            {
                if (i < 10)
                {
                    exitroom_time_hour.Items.Add("0" + i);
                    add_fullday_time_hour_cb.Items.Add("0" + i);
                    confirm_add_fullday_time_hour_cb.Items.Add("0" + i);
                    confirm_fulldayprice_time_hour_cb.Items.Add("0" + i);
                }
                else
                {
                    exitroom_time_hour.Items.Add(i+"");
                    add_fullday_time_hour_cb.Items.Add("" + i);
                    confirm_add_fullday_time_hour_cb.Items.Add("" + i);
                    confirm_fulldayprice_time_hour_cb.Items.Add("" + i);
                }
            }
           
            for (int i = 0; i < 60; i++)
            {
                if (i < 10)
                {
                    exitroom_time_minute.Items.Add("0" + i);
                    add_fullday_time_minute_cb.Items.Add("0" + i);
                    confirm_add_fullday_time_minute_cb.Items.Add("0" + i);
                    confirm_fulldayprice_time_minute_cb.Items.Add("0" + i);
                }
                else
                {
                    exitroom_time_minute.Items.Add("" + i);
                    add_fullday_time_minute_cb.Items.Add("" + i);
                    confirm_add_fullday_time_minute_cb.Items.Add("" + i);
                    confirm_fulldayprice_time_minute_cb.Items.Add("" + i);
                }
            }
           

            confirm_fulldayprice_time_type_cb.Items.Add("入住后");
            confirm_fulldayprice_time_type_cb.Items.Add("固定时间");
            confirm_fulldayprice_time_type_cb.SelectionChanged += confirm_fulldayprice_time_type_cb_change;

            after_exitroom_charge_type_cb.Items.Add("半日租");
            after_exitroom_charge_type_cb.Items.Add("每小时");
            after_exitroom_charge_type_cb.SelectionChanged += after_exitroom_charge_type_cb_change;

            addprice_fullday_type_cb.Items.Add("超过退房时间");
            addprice_fullday_type_cb.Items.Add("固定时间");
            addprice_fullday_type_cb.SelectionChanged += addprice_fullday_type_cb_change;

            confirm_addprice_fullday_type_cb.Items.Add("超过退房时间");
            confirm_addprice_fullday_type_cb.Items.Add("固定时间");
            confirm_addprice_fullday_type_cb.SelectionChanged += confirm_addprice_fullday_type_cb_change;

        }

        public void InitData()
        {
            if(type == 0)
            {
                radiobutton1.IsChecked = true;
                exitroom_time_hour.Text = "14";
                add_fullday_time_hour_cb.Text = "00";
                confirm_add_fullday_time_hour_cb.Text = "00";
                confirm_fulldayprice_time_hour_cb.Text = "00";

                exitroom_time_minute.Text = "00";
                add_fullday_time_minute_cb.Text = "00";
                confirm_add_fullday_time_minute_cb.Text = "00";
                confirm_fulldayprice_time_minute_cb.Text = "00";

                confirm_fulldayprice_time_type_cb.Text = "入住后";
                after_exitroom_charge_type_cb.Text = "半日租";
                addprice_fullday_type_cb.Text = "超过退房时间";
                confirm_addprice_fullday_type_cb.Text = "超过退房时间";
            }if(type == 1)
            {
                using (RetailContext context = new RetailContext())
                {
                    string sql = string.Format("select * from ValueRule_fulldays where UPPER(HEX([ID])) = '{0}'", id.ConvertGuid());
                    ValueRule_fullday valueRule_Fullday = context.Database.SqlQuery<ValueRule_fullday>(sql).ToList()[0];
                    if(valueRule_Fullday.exitroom_type == 1||valueRule_Fullday.exitroom_type == 2)
                    {
                        if (valueRule_Fullday.exitroom_type == 1)
                        {
                            radiobutton1.IsChecked = true;
                        }
                        else
                        {
                            radiobutton2.IsChecked = true;
                        }

                        if(valueRule_Fullday.IsSeal == true)
                        {
                            IsSeal_ckb.IsChecked = true;
                        }
                        exitroom_time_hour.Text = valueRule_Fullday.exitroom_time.Split(':')[0];
                        exitroom_time_minute.Text = valueRule_Fullday.exitroom_time.Split(':')[1];
                        if(valueRule_Fullday.confirm_fulldayprice_time_type == "入住后")
                        {
                            add_fullday_time_tb.Text = valueRule_Fullday.add_fullday_time;
                        }
                        else if (valueRule_Fullday.confirm_fulldayprice_time_type == "固定时间")
                        {
                            confirm_fulldayprice_time_hour_cb.Text = valueRule_Fullday.confirm_fulldayprice_time.Split(':')[0];
                            confirm_fulldayprice_time_minute_cb.Text = valueRule_Fullday.confirm_fulldayprice_time.Split(':')[1];
                        }

                        if(valueRule_Fullday.after_exitroom_charge_type == "半日租")
                        {
                            IsSeal_ckb.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            IsSeal_ckb.Visibility = Visibility.Hidden;
                        }

                        if(valueRule_Fullday.addprice_fullday_type == "超过退房时间")
                        {
                            add_fullday_time_tb.Text = valueRule_Fullday.add_fullday_time;
                        }else if (valueRule_Fullday.addprice_fullday_type == "固定时间")
                        {
                            add_fullday_time_hour_cb.Text = valueRule_Fullday.add_fullday_time.Split(':')[0];
                            add_fullday_time_minute_cb.Text = valueRule_Fullday.add_fullday_time.Split(':')[1];
                        }

                        if (valueRule_Fullday.confirm_addprice_fullday_type == "超过退房时间")
                        {
                            confirm_add_fullday_time_tb.Text = valueRule_Fullday.confirm_add_fullday_time;
                        }
                        else if (valueRule_Fullday.confirm_addprice_fullday_type == "固定时间")
                        {
                            confirm_add_fullday_time_hour_cb.Text = valueRule_Fullday.confirm_add_fullday_time.Split(':')[0];
                            confirm_add_fullday_time_minute_cb.Text = valueRule_Fullday.confirm_add_fullday_time.Split(':')[1];
                        }
                    }
                    else
                    {
                        radiobutton3.IsChecked = true;
                        if (valueRule_Fullday.IsSeal == true)
                        {
                            IsSeal_ckb2.IsChecked = true;
                        }
                        _24rotate_startprice_validtime_tb.Text = valueRule_Fullday._24rotate_startprice_validtime;
                        _24rorate_fullprice_time_tb.Text = valueRule_Fullday._24rorate_fullprice_time;
                    }
                    
                    confirm_fulldayprice_time_type_cb.Text = valueRule_Fullday.confirm_fulldayprice_time_type;
                    after_exitroom_charge_type_cb.Text = valueRule_Fullday.after_exitroom_charge_type;
                    addprice_fullday_type_cb.Text = valueRule_Fullday.addprice_fullday_type;
                    confirm_addprice_fullday_type_cb.Text = valueRule_Fullday.confirm_addprice_fullday_type;

                    starthalfprice_time_tb.Text = valueRule_Fullday.starthalfprice_time;
                    startprice_time_tb.Text = valueRule_Fullday.startprice_time;
                    confirm_fulldayprice_time_tb.Text = valueRule_Fullday.confirm_fulldayprice_time;
                    after_exitroom_charge_time_tb.Text = valueRule_Fullday.after_exitroom_charge_time;

                    name.Text = valueRule_Fullday.name;
                    describe.Text = valueRule_Fullday.describe;
                }
                
            }
        }

        private void PURadioButton_Checked(object sender, RoutedEventArgs e)
        {
            valuerule1.Height = 160;
            valuerule2.Height = 0;
            exitroom_time_hour.IsEnabled = true;
            exitroom_time_minute.IsEnabled = true;
        }
        private void PURadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            valuerule1.Height = 0;
            valuerule2.Height = 160;
            exitroom_time_hour.IsEnabled = false;
            exitroom_time_minute.IsEnabled = false;
        }
        private void PURadioButton_Checked2(object sender, RoutedEventArgs e)
        {
            valuerule1.Height = 160;
            valuerule2.Height = 0;
            exitroom_time_hour.IsEnabled = false;
            exitroom_time_minute.IsEnabled = false;
        }
        private void confirm_fulldayprice_time_type_cb_change(object sender, RoutedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            var value = comboBox.Items[comboBox.SelectedIndex].ToString();
            if(value == "入住后")
            {
                son_stackpanel_101.Width = 130;
                son_stackpanel_102.Width = 0;
            }
            else
            {
                son_stackpanel_101.Width = 0;
                son_stackpanel_102.Width = 140;
            }
        }
        private void after_exitroom_charge_type_cb_change(object sender, RoutedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            var value = comboBox.Items[comboBox.SelectedIndex].ToString();
            if (value == "半日租")
            {
                IsSeal_ckb.Visibility = Visibility.Hidden;
            }
            else
            {
                IsSeal_ckb.Visibility = Visibility.Visible;
            }
        }
        private void addprice_fullday_type_cb_change(object sender, RoutedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            var value = comboBox.Items[comboBox.SelectedIndex].ToString();
            if (value == "超过退房时间")
            {
                son_stackpanel_201.Width = 130;
                son_stackpanel_202.Width = 0;
            }
            else
            {
                son_stackpanel_201.Width = 0;
                son_stackpanel_202.Width = 140;
            }
        }
        private void confirm_addprice_fullday_type_cb_change(object sender, RoutedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            var value = comboBox.Items[comboBox.SelectedIndex].ToString();
            if (value == "超过退房时间")
            {
                son_stackpanel_301.Width = 130;
                son_stackpanel_302.Width = 0;
            }
            else
            {
                son_stackpanel_301.Width = 0;
                son_stackpanel_302.Width = 140;
            }
        }

        private void number_textbox(object sender, TextCompositionEventArgs e)
        {
            Regex re = new Regex("[^0-9.-]+");
            e.Handled = re.IsMatch(e.Text);
        }

        private void Confirm(object sender, RoutedEventArgs e)
        {
            if(type == 0)
            {
                int exitroom_type_text = 0;
                string exitroom_time_text = "";
                bool IsSealText = false;
                    
                if (radiobutton1.IsChecked == true)
                {
                    exitroom_type_text = 1;
                    exitroom_time_text = exitroom_time_hour.Text + ":" + exitroom_time_minute.Text;
                    if (IsSeal_ckb.IsChecked == true)
                    {
                        IsSealText = true;
                    }
                }
                if (radiobutton2.IsChecked == true)
                {
                    exitroom_type_text = 2;
                    exitroom_time_text = exitroom_time_hour.Text + ":" + exitroom_time_minute.Text;
                    if (IsSeal_ckb.IsChecked == true)
                    {
                        IsSealText = true;
                    }
                }
                if (radiobutton3.IsChecked == true)
                {
                    exitroom_type_text = 3;
                    if (IsSeal_ckb2.IsChecked == true)
                    {
                        IsSealText = true;
                    }

                }

                string confirm_fulldayprice_time_text = "";
                if(confirm_fulldayprice_time_type_cb.Text == "入住后")
                {
                    confirm_fulldayprice_time_text = confirm_fulldayprice_time_tb.Text;
                }
                else
                {
                    confirm_fulldayprice_time_text = confirm_fulldayprice_time_hour_cb.Text + ":" + confirm_fulldayprice_time_minute_cb.Text;
                }
                
                string add_fullday_time_text = "";
                if (addprice_fullday_type_cb.Text == "超过退房时间")
                {
                    add_fullday_time_text = add_fullday_time_tb.Text;
                }
                else
                {
                    add_fullday_time_text = add_fullday_time_hour_cb.Text + ":" + add_fullday_time_minute_cb.Text;
                }

                string confirm_add_fullday_time_text = "";
                if (confirm_addprice_fullday_type_cb.Text == "超过退房时间")
                {
                    confirm_add_fullday_time_text = confirm_add_fullday_time_tb.Text;
                }
                else
                {
                    confirm_add_fullday_time_text = confirm_add_fullday_time_hour_cb.Text + ":" + confirm_add_fullday_time_minute_cb.Text;
                }
                
                if(radiobutton3.IsChecked == true)
                {
                    starthalfprice_time_tb.Text = _24rotate_startprice_validtime_tb.Text;
                    startprice_time_tb.Text = _24rorate_fullprice_time_tb.Text;
                }

                ValueRule_fullday valueRule_Fullday = new ValueRule_fullday()
                {
                    ID = Guid.NewGuid(),
                    name = name.Text,
                    describe = describe.Text,
                    exitroom_type = exitroom_type_text,
                    exitroom_time = exitroom_time_text,
                    starthalfprice_time = starthalfprice_time_tb.Text,
                    startprice_time = startprice_time_tb.Text,
                    confirm_fulldayprice_time_type = confirm_fulldayprice_time_type_cb.Text,
                    confirm_fulldayprice_time = confirm_fulldayprice_time_text,
                    after_exitroom_charge_time = after_exitroom_charge_time_tb.Text,
                    after_exitroom_charge_type = after_exitroom_charge_type_cb.Text,
                    IsSeal = IsSealText,
                    addprice_fullday_type = addprice_fullday_type_cb.Text,
                    add_fullday_time = add_fullday_time_text,
                    confirm_addprice_fullday_type = confirm_addprice_fullday_type_cb.Text,
                    confirm_add_fullday_time = confirm_add_fullday_time_text,
                    _24rotate_startprice_validtime = _24rotate_startprice_validtime_tb.Text,
                    _24rorate_fullprice_time = _24rorate_fullprice_time_tb.Text,
                    IsUse = true,
                };

                using (RetailContext context = new RetailContext())
                {
                    context.ValueRule_fulldays.Add(valueRule_Fullday);
                    context.SaveChanges();
                }
                (thispage.DataContext as ValueRule_fullday_ViewModel).ReFlashTable();
                new MessageWindow("添加成功", "添加成功", "确定", 200, 220, Cancel).ShowDialog();
            }
            else if(type == 1)
            {
                int exitroom_type_text = 0;
                string exitroom_time_text = "";
                bool IsSealText = false;

                if (radiobutton1.IsChecked == true)
                {
                    exitroom_type_text = 1;
                    exitroom_time_text = exitroom_time_hour.Text + ":" + exitroom_time_minute.Text;
                    if (IsSeal_ckb.IsChecked == true)
                    {
                        IsSealText = true;
                    }
                }
                if (radiobutton2.IsChecked == true)
                {
                    exitroom_type_text = 2;
                    exitroom_time_text = exitroom_time_hour.Text + ":" + exitroom_time_minute.Text;
                    if (IsSeal_ckb.IsChecked == true)
                    {
                        IsSealText = true;
                    }
                }
                if (radiobutton3.IsChecked == true)
                {
                    exitroom_type_text = 3;
                    if (IsSeal_ckb2.IsChecked == true)
                    {
                        IsSealText = true;
                    }
                }

                string confirm_fulldayprice_time_text = "";
                if (confirm_fulldayprice_time_type_cb.Text == "入住后")
                {
                    confirm_fulldayprice_time_text = confirm_fulldayprice_time_tb.Text;
                }
                else
                {
                    confirm_fulldayprice_time_text = confirm_fulldayprice_time_hour_cb.Text + ":" + confirm_fulldayprice_time_minute_cb.Text;
                }

                string add_fullday_time_text = "";
                if (addprice_fullday_type_cb.Text == "超过退房时间")
                {
                    add_fullday_time_text = add_fullday_time_tb.Text;
                }
                else
                {
                    add_fullday_time_text = add_fullday_time_hour_cb.Text + ":" + add_fullday_time_minute_cb.Text;
                }

                string confirm_add_fullday_time_text = "";
                if (confirm_addprice_fullday_type_cb.Text == "超过退房时间")
                {
                    confirm_add_fullday_time_text = confirm_add_fullday_time_tb.Text;
                }
                else
                {
                    confirm_add_fullday_time_text = confirm_add_fullday_time_hour_cb.Text + ":" + confirm_add_fullday_time_minute_cb.Text;
                }

                using (RetailContext context = new RetailContext())
                {
                    
                    string sql = string.Format("update ValueRule_fulldays set " +
                        "name = '{0}',describe = '{1}',exitroom_type = {2},exitroom_time = '{3}'," +
                        "starthalfprice_time = '{4}',startprice_time = '{5}',confirm_fulldayprice_time_type = '{6}',confirm_fulldayprice_time = '{7}'," +
                        "after_exitroom_charge_time = '{8}',after_exitroom_charge_type = '{9}',IsSeal = {10},addprice_fullday_type = '{11}'," +
                        "add_fullday_time = '{12}',confirm_addprice_fullday_type = '{13}',confirm_add_fullday_time = '{14}',_24rotate_startprice_validtime = '{15}'," +
                        "_24rorate_fullprice_time = '{16}',IsUse = {17} where UPPER(HEX([ID])) = '{18}'",
                        name.Text,describe.Text, exitroom_type_text, exitroom_time_text, starthalfprice_time_tb.Text, startprice_time_tb.Text,
                        confirm_fulldayprice_time_type_cb.Text, confirm_fulldayprice_time_text, after_exitroom_charge_time_tb.Text, after_exitroom_charge_type_cb.Text,
                        IsSealText, addprice_fullday_type_cb.Text, add_fullday_time_text, confirm_addprice_fullday_type_cb.Text,
                        confirm_add_fullday_time_text, _24rotate_startprice_validtime_tb.Text, _24rorate_fullprice_time_tb.Text,true,
                        id.ConvertGuid());
                    context.Database.ExecuteSqlCommand(sql);
                    context.SaveChanges();
                }
                (thispage.DataContext as ValueRule_fullday_ViewModel).ReFlashTable();
                new MessageWindow("修改成功", "修改成功", "确定", 200, 220, Cancel).ShowDialog();
            }
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
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
