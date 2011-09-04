using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace XuezhijiaWebsite
{
    public partial class UserManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
            }

        }

        private void Bind()
        {
            GridView_Users.DataSource = (new UserInfoWrapper()).getall();
            GridView_Users.DataKeyNames = new string[] { "UserID" };//主键
            GridView_Users.DataBind();
        }

    }
}