using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;
using System.Data;

namespace XuezhijiaWebsite
{
    public partial class TeacherInformation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }

            InitPage();
        }

        private void InitPage()
        {
            TeacherWrapper wrapper = new TeacherWrapper();
            DataTable table = new DataTable();
            table = wrapper.getall();
            Teachers.DataSource = table;
            Teachers.DataBind();
        }

        protected void RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void DeleteClick(int id)
        {
            TeacherWrapper wrapper = new TeacherWrapper();
            wrapper.deleteARecordByID(id);
            PostInit();
            InitPage();
        }

        protected void RowUpdate(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandArgument.ToString().Length < 1)
            {
                return;
            }
            string cmd = e.CommandName; //获得name
            int Id = Convert.ToInt32(e.CommandArgument);
            if (cmd == "Delete")
            {
                DeleteClick(Id);
                return;
            }

            TEACHER teacher = new TEACHER();
            TeacherWrapper wrapper = new TeacherWrapper();
            teacher = wrapper.getResultByID(Id);
            Label2.Visible = true;
            Label3.Visible = true;
            Label4.Visible = true;
            Label8.Visible = true;

            TextBox1.Visible = true;
            TextBox2.Visible = true;
            TextBox3.Visible = true;
            TextBox7.Visible = true;
            Button1.Visible = true;

            TextBox1.Text = teacher.TName;
            TextBox2.Text = teacher.ConnectionInformation.ToString();
            TextBox3.Text = teacher.AdvantageSubjects.ToString();
            TextBox7.Text = teacher.Comment;
            Session.Add("TID", Id);
        }

        protected void CommitClick(object sender, EventArgs e)
        {
            if (Session["TID"] != null && Session["TID"].ToString() != "")
            {

                int id = Convert.ToInt32(Session["TID"].ToString());
                TEACHER tmp = new TEACHER();
                TeacherWrapper wrapper = new TeacherWrapper();
                tmp = wrapper.getResultByID(id);
                TEACHER teacher = new TEACHER();
                teacher.TID = id;
                teacher.TName = TextBox1.Text;
                teacher.ConnectionInformation = TextBox2.Text;
                teacher.AdvantageSubjects = TextBox3.Text;
                teacher.Comment = TextBox7.Text;
                wrapper.updateARecord(teacher);
                Session.Remove("TID");
            }

            else
            {
                TeacherWrapper wrapper = new TeacherWrapper();
                TEACHER teacher = new TEACHER();
                CommenHelper helper = CommenHelper.GetInstance();
                teacher.TName = TextBox1.Text;
                teacher.ConnectionInformation = TextBox2.Text;
                teacher.AdvantageSubjects = TextBox3.Text;
                teacher.Comment = TextBox7.Text;
                wrapper.addAClassRecord(teacher);
            }
            PostInit();
            InitPage();
        }

        protected void PostInit()
        {
            Label2.Visible = false;
            Label3.Visible = false;
            Label4.Visible = false;
            Label8.Visible = false;


            TextBox1.Visible = false;
            TextBox2.Visible = false;
            TextBox3.Visible = false;
            TextBox7.Visible = false;

            Button1.Visible = false;

            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox7.Text = "";
        }

        protected void AddClick(object sender, EventArgs e)
        {
            Label2.Visible = true;
            Label3.Visible = true;
            Label4.Visible = true;
            Label8.Visible = true;
    

            TextBox1.Visible = true;
            TextBox2.Visible = true;
            TextBox3.Visible = true;
            TextBox7.Visible = true;
            Button1.Visible = true;
        }
    }
}