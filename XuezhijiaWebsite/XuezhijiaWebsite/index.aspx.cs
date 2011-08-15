using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using BLL;

namespace XuezhijiaWebsite
{
    public partial class index : System.Web.UI.Page
    {
        protected List<INDEXIMAGE> imgList=null;
        protected void Page_Load(object sender, EventArgs e)
        {
            ((MasterPage)Master).CurrentMenu = "index";
            imgList = (new IndexImageWrapper()).getAllFormatedResult();
        }
    }
}