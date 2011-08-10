using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;

public partial class Load : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void CommitClick(object sender, EventArgs e)
    {
        UserInfoWrapper wrapper = new UserInfoWrapper();
        string username = TextBox1.Text;
        string password = TextBox2.Text;
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
        }
    }

    protected void ClearClick(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
    }
}