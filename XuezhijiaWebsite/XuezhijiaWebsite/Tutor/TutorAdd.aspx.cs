using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using BLL;

namespace XuezhijiaWebsite.Tutor
{
    public partial class TutorAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((MasterPage)Master).CurrentMenu = "tutor";
        }

        protected void Btn_Submit_Click(object sender, EventArgs e)
        {
            ((MasterPage)Master).CurrentMenu = "tutor";
            TEACHER teacher = new TEACHER();
            TeacherWrapper wrapper = new TeacherWrapper();
            teacher.TName = TextBox_Name.Text;
            teacher.ConnectionInformation = TextBox_Contact.Text;
            teacher.AdvantageSubjects = TextBox_Subject.Text;
            teacher.Comment = TextBox_Comment.Text;
            wrapper.addAClassRecord(teacher);
            
           
        }
    }
}