using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using BLL;

namespace XuezhijiaWebsite.News
{
    public partial class NewsAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Add("type", 1);
        }

        protected void DropDownList_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["type"] = DropDownList_Type.SelectedIndex;
        }


        protected void Btn_Submit_Click(object sender, EventArgs e)
        {
            NEWS news = new NEWS();
            news.NewsPublishTime = DateTime.Now.ToString();
            news.NewsTitle = TextBox_Title.Text;
            news.NewsContent = CKEditor1.Text;
            news.NewsClickCount = 0;
            news.NewsType = Convert.ToInt32(Session["type"].ToString());
        }
    }
}