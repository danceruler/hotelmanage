using NewHM.Help;
using NewHM.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace NewHM
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            VM_WindowMain vm = new VM_WindowMain();
            Application.Current.MainWindow = vm.UIElement as Window;
            vm.Show();
            base.OnStartup(e);
        }
    }
}
