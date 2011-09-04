using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace XuezhijiaWebsite.House
{
    public partial class HouseCheck : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((MasterPage)Master).CurrentMenu = "house";
            (new RentHourseWrapper()).CheckARecordByID(Convert.ToInt32(Request.QueryString["id"]));

        }
    }
}