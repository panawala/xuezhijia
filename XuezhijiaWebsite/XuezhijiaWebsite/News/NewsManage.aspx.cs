using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XuezhijiaWebsite.News
{
    public partial class NewsManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView_News_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }


        protected void Check_Command(object sender, CommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            int new_id = Convert.ToInt32(GridView_News.DataKeys[rowIndex].Value);
            Response.Redirect("/News/News.aspx?id="+new_id);
        }

    }
}