﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XuezhijiaWebsite.House
{
    public partial class HouseAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((Uploadfile)Master).CurrentMenu = "house";
        }

        protected void Btn_Submit_Click(object sender, EventArgs e)
        {
 
        }

    }
}