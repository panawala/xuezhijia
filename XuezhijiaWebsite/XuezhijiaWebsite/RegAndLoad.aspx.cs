using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using BLL;

public partial class RegAndLoad : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void CommitClick(object sender, EventArgs e)
    {
        UserInfo.UserInfoDataTable table = new UserInfo.UserInfoDataTable();
        UserInfo.UserInfoRow row = table.NewUserInfoRow();
        row.PassWord = TextBox3.Text;
        row.UserName = TextBox1.Text;
        row.Comment = TextBox5.Text;
        row.Tel_NO = TextBox2.Text;
        UserInfoWrapper wrapper = new UserInfoWrapper();
        wrapper.addARecord(row);     
    }

    protected void ClearClick(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox5.Text = "";
    }
}