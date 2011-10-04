using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XuezhijiaWebsite.Proxy
{
    public partial class Proxy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((MasterPage)Master).CurrentMenu = "proxy";
            int type = Convert.ToInt32(Request.QueryString["type"]);
            string StrType;
            if(type==1)
            {
                StrType="考研";
            }
            else
            {
                StrType="驾校";
            }
            Session.Add("Type", StrType);
        }
    }
}