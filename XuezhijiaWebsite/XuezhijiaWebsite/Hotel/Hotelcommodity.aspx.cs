using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XuezhijiaWebsite.Hotel
{
    public partial class Hotelcommodity : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((MasterPage)Master).CurrentMenu = "hotel";
        }
    }
}