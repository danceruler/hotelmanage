using Helper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelManager.Helper
{
    public static class FileHelper
    {
        //将本地sqlite数据库文件上传到服务器
        public static void UploadLocalDB()
        {
            string testdbPath = "C:\\db\\test.db";
            byte[] byte_testdb = MyFileHelper.File2Bytes(testdbPath);
            string hexstring_file = MyByteStringHelper.ByteToHexStr(byte_testdb);
            string data = JsonConvert.SerializeObject(hexstring_file);
            httpRequestHelper.PostRequest("http://47.107.69.129:1996/api/ClientToServer//UploadDatabase", data, "application/json");
        }

        //将本地数据库的数据同步到服务器的sqlserver



    }
}
