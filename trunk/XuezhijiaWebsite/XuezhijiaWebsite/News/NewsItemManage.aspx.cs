using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using BLL;
using System.Data;
using DAL.NewsTableAdapters;
using DAL.ArticalTableAdapters;

namespace XuezhijiaWebsite.News
{
    public partial class NewsItemManage : System.Web.UI.Page
    {
        private static int newsId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                newsId = Convert.ToInt32(Request.QueryString["id"]);
                Bind();
            }
        }
        private void Bind()
        {
            NEWS news = (new BLL.NewsWrapper()).getResultByID(newsId);
            TextBox_Title.Text = news.NewsTitle;
            CKEditor1.Text = news.NewsContent;
        }
        protected void Btn_Submit_Click(object sender, EventArgs e)
        {
            NewsWrapper newwrapper = new NewsWrapper();
            newwrapper.UpdateQuery(TextBox_Title.Text, CKEditor1.Text, newsId);
            Bind();
        }
    }
}