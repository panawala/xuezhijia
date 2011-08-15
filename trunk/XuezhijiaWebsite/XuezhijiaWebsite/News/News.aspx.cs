using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
namespace XuezhijiaWebsite.News
{
    public partial class News : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((MasterPage)Master).CurrentMenu = "index";
            int id = Convert.ToInt32(Request.QueryString["id"].ToString());
            (new NewsWrapper()).addLookCountByID(id);
        }
    }
}