using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XuezhijiaWebsite.Train
{
    public partial class Train : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((MasterPage)Master).CurrentMenu = "train";
        }
    }
}