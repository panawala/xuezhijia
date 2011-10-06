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
            /*List<string> types = new List<string>();
            types.Add("单人间");
            types.Add("双人间");
            DropDownList_RoomTypes.DataSource = types;
            DropDownList_RoomTypes.DataBind();*/
        }
    }
}