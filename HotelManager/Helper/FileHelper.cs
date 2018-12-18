using Helper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace HotelManager.Helper
{
    public static class FileHelper
    {
        public static Dictionary<int, string> DomainConfig = new Dictionary<int, string>()
        {
            { 1,"后台管理"},
            { 2,"房态管理"},
            { 3,"3"},
            { 4,"4"},
            { 5,"5"},
            { 6,"6"},
        };

        //将本地sqlite数据库文件上传到服务器
        public static void UploadLocalDB()
        {
            string testdbPath = "C:\\db\\test.db";
            byte[] byte_testdb = MyFileHelper.File2Bytes(testdbPath);
            string hexstring_file = MyByteStringHelper.ByteToHexStr(byte_testdb);
            string data = JsonConvert.SerializeObject(hexstring_file);
            httpRequestHelper.PostRequest("http://mzhdemo.xyz:1996/api/ClientToServer//UploadDatabase", data, "application/json");
        }

        //将本地数据库的数据同步到服务器的sqlserver



        

    }
}
