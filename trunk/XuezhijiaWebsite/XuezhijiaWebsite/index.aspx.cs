using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

namespace XuezhijiaWebsite
{
    public partial class index : System.Web.UI.Page
    {
        protected List<IndexImage> imgList = new List<IndexImage>();
        protected void Page_Load(object sender, EventArgs e)
        {
            ((MasterPage)Master).CurrentMenu = "index";
            for (int i = 1; i < 6; i++)
            {
                imgList.Add(new IndexImage("hello", "hello", "hello", "hello") { });
            }
        }
    }
}