using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;

namespace XuezhijiaWebsite
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        public string CurrentMenu;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CommitLoad(object sender, EventArgs e)
        {
            UserInfoWrapper wrapper = new UserInfoWrapper();
            string username = UserName.Text;
            string password = Password.Text;
            bool isvalidite = wrapper.IsValidite(username, password);
            if (isvalidite)
            {
                UserInfo.UserInfoRow row;
                UserInfo.UserInfoDataTable table = new UserInfo.UserInfoDataTable();
                row = table.NewUserInfoRow();
                row = wrapper.getRecordByUserNameAndPassWord(username, password);
                Session["Username"] = username;
                Session["UserID"] = row.UserID.ToString();
                Session["PassWord"] = password;
                Response.Redirect("~/Default.aspx");
            }
        }

        protected void CommitRegister(object sender, EventArgs e)
        {
            UserInfoWrapper wrapper = new UserInfoWrapper();
            string username = UserName.Text;
            string password = Password.Text;
            bool isvalidite = wrapper.IsValidite(username, password);
            if (isvalidite)
            {
                UserInfo.UserInfoRow row;
                UserInfo.UserInfoDataTable table = new UserInfo.UserInfoDataTable();
                row = table.NewUserInfoRow();
                row = wrapper.getRecordByUserNameAndPassWord(username, password);
                Session["Username"] = username;
                Session["UserID"] = row.UserID.ToString();
                Session["PassWord"] = password;
                Response.Redirect("~/Default.aspx");
            }
        }
    }
}