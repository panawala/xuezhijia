using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Security.Cryptography;
using System.Net;
using System.IO;

namespace BLL
{
    public class SmsWrapper
    {
        private static string GetMD5(string myString)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = System.Text.Encoding.Unicode.GetBytes(myString);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x");
            }

            return byte2String;
        } 
        #region 短信发送
        public static string SendSms(List<string> mobiles,string strContent,string uid,string Pwd)
        {
            string mobile = string.Empty;// "18651691978";  //联系电话
            foreach (var mb in mobiles)
            {
                mobile += mb;
                mobile += ",";
            }
            
            StringBuilder sbTemp = new StringBuilder();
            //string Pwd = GetMD5(pwd); //密码进行MD5加密
            //string Pass = FormsAuthentication.HashPasswordForStoringInConfigFile(pwd, "MD5");
            //POST 传值
            sbTemp.Append("uid=" + uid + "&pwd=" + Pwd + "&mobile=" + mobile + "&content=" + strContent);
            byte[] bTemp = System.Text.Encoding.GetEncoding("GBK").GetBytes(sbTemp.ToString());
            string postReturn = doPostRequest("http://http.chinasms.com.cn/tx/", bTemp);
            return postReturn;  //测试返回结果
        }
        //POST方式发送得结果
        private static string doPostRequest(string url, byte[] bData)
        {
            System.Net.HttpWebRequest hwRequest;
            System.Net.HttpWebResponse hwResponse;

            string strResult = string.Empty;

            hwRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
            hwRequest.Timeout = 5000;
            hwRequest.Method = "POST";
            hwRequest.ContentType = "application/x-www-form-urlencoded";
            hwRequest.ContentLength = bData.Length;

            System.IO.Stream smWrite = hwRequest.GetRequestStream();
            smWrite.Write(bData, 0, bData.Length);
            smWrite.Close();


            //get response
            hwResponse = (HttpWebResponse)hwRequest.GetResponse();
            StreamReader srReader = new StreamReader(hwResponse.GetResponseStream(), Encoding.ASCII);
            strResult = srReader.ReadToEnd();
            srReader.Close();
            hwResponse.Close();


            return strResult;
        }

        #endregion
    }
}
