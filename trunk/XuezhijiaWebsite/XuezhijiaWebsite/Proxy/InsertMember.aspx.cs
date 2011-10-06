using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using BLL;
using System.Web.Security;

namespace XuezhijiaWebsite.Proxy
{
    public partial class InsertMember : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string Name = Request.QueryString["Name"];
            string IsNative = Request.QueryString["IsNative"];
            string Address = Request.QueryString["Address"];
            string ContactInformation = Request.QueryString["ContactInformation"];
            int Type = Convert.ToInt32(Request.QueryString["TypeId"]);
            string StrType=string.Empty;
            if (Type == 1)
            {
                StrType = "考研";
            }
            else
            {
                StrType = "驾校";
            }
            string Comment = Request.QueryString["Comment"];


            MemberWrapper wrapper = new MemberWrapper();
            MEMBER member = new MEMBER();
            member.Address = Address;
            member.ContactInformation = ContactInformation;
            member.Comment = Comment;
            member.IsNative = IsNative;
            member.Type = StrType;
            member.Name = Name;
            wrapper.addAClassRecord(member);


            //List<string> mobiles = new List<string>();
            //mobiles.Add("18801796521");
            //mobiles.Add("18651691978");
            //string Pwd = FormsAuthentication.HashPasswordForStoringInConfigFile("123123", "MD5"); //密码进行MD5加密
            //Response.Write(SmsWrapper.SendSms(mobiles, "hello", "521641", Pwd));


            Response.Redirect("/Success.htm");
        }
    }
}