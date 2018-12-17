using HotelManager.Helper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace HotelManager
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            // 定义应用程序启动时要处理的内容 
            if (FileHelper.IsExistFile(XmlHelper.PersonXmlPath))
            {
                FileHelper.ClearFile(XmlHelper.PersonXmlPath);
            }
            else
            {
                FileHelper.CreateFileContent(XmlHelper.PersonXmlPath, "");
            }
        }
    }
}
