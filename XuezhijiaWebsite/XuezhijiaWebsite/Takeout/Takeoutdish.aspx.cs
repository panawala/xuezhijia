using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace XuezhijiaWebsite.Takeout
{
    public partial class Takeoutdish : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((MasterPage)Master).CurrentMenu = "sell";
            if (!IsPostBack)
            {
                //点击次数增加
                (new ShopWrapper()).AddClickCountByID(Convert.ToInt32(Request.QueryString["id"]));
            }
        }
    }
}