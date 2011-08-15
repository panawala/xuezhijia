using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XuezhijiaWebsite
{
    public partial class TutorManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack)
            {
                return;
            }
        }

        protected void GotoStudent(Object sender, EventArgs e)
        {
            Response.Redirect("~/StudentInformation.aspx");
        }

        protected void GotoTeacher(Object sender, EventArgs e)
        {
            Response.Redirect("~/TeacherInformation.aspx");
        }
    }
}