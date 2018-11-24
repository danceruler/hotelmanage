using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Windows;

namespace HotelManager.Helper
{
    public  class Configs
    {
        public static string GetConnectionStringsConfig(string connectionName)
        {
            string connectionString =
        ConfigurationManager.ConnectionStrings[connectionName].ConnectionString.ToString();
            return connectionString;
        }

        public static void UpdateConnectionStringsConfig(string newName,
    string newConString,
    string newProviderName)
        {
            bool isModified = false;    //记录该连接串是否已经存在
                                        //如果要更改的连接串已经存在
            if (ConfigurationManager.ConnectionStrings[newName] != null)
            {
                isModified = true;
            }
            //新建一个连接字符串实例
            ConnectionStringSettings mySettings =
                new ConnectionStringSettings(newName, newConString, newProviderName);
            // 打开可执行的配置文件*.exe.config
            Configuration config =
                ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            // 如果连接串已存在，首先删除它
            if (isModified)
            {
                config.ConnectionStrings.ConnectionStrings.Remove(newName);
            }
            // 将新的连接串添加到配置文件中.
            config.ConnectionStrings.ConnectionStrings.Add(mySettings);
            // 保存对配置文件所作的更改
            config.Save(ConfigurationSaveMode.Modified);
            // 强制重新载入配置文件的ConnectionStrings配置节
            ConfigurationManager.RefreshSection("ConnectionStrings");
        }

        public static void InitConnection()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string rootpath = path.Substring(0, path.LastIndexOf("bin"));
            rootpath = "Data Source=" + rootpath + "AppData\\db\\test.db;Pooling=True";
            Configs.UpdateConnectionStringsConfig("myDatabase", rootpath, "System.Data.SQLite.EF6");
        }
    }
}
