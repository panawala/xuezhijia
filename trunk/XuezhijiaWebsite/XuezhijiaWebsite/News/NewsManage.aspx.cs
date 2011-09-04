using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace XuezhijiaWebsite.News
{
    public partial class NewsManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
            }

        }

        protected void GridView_News_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int new_id = Convert.ToInt32(GridView_News.DataKeys[e.RowIndex].Value);
            (new NewsWrapper()).deleteARecordByID(new_id);
            Bind();
        }


        protected void Check_Command(object sender, CommandEventArgs e)
        {
            int news_id = Convert.ToInt32(e.CommandArgument);
            //int new_id = Convert.ToInt32(GridView_News.DataKeys[rowIndex].Value);
            Response.Redirect("/News/News.aspx?id=" + news_id);

        }

        private void Bind()
        {
            GridView_News.DataSource = (new NewsWrapper()).getall();
            GridView_News.DataKeyNames = new string[] { "NewsID" };//主键
            GridView_News.DataBind();
        }

    }
}