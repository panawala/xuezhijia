using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using BLL;
using System.Data;

namespace XuezhijiaWebsite
{
    public partial class StudentInformation : System.Web.UI.Page
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
            StudentWrapper wrapper = new StudentWrapper();
            DataTable table = new DataTable();
            table = wrapper.getall();
            Students.DataSource = table;
            Students.DataBind();
        }

        protected void RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void DeleteClick(int id)
        {
            StudentWrapper wrapper = new StudentWrapper();
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

            STUDENT student = new STUDENT();
            StudentWrapper wrapper = new StudentWrapper();
            student = wrapper.getResultByID(Id);
            Label2.Visible = true;
            Label3.Visible = true;
            Label4.Visible = true;
            Label8.Visible = true;
            Label9.Visible = true;

            TextBox1.Visible = true;
            TextBox2.Visible = true;
            TextBox3.Visible = true;
            TextBox7.Visible = true;
            TextBox8.Visible = true;
            Button1.Visible = true;

            TextBox1.Text = student.SName;
            TextBox2.Text = student.Address.ToString();
            TextBox3.Text = student.Grade.ToString();
            TextBox8.Text = student.Requirement;
            TextBox7.Text = student.Comment;
            Session.Add("SID", Id);
        }

        protected void CommitClick(object sender, EventArgs e)
        {
            if (Session["SID"] != null && Session["SID"].ToString() != "")
            {

                int id = Convert.ToInt32(Session["SID"].ToString());
                STUDENT tmp = new STUDENT();
                StudentWrapper wrapper = new StudentWrapper();
                tmp = wrapper.getResultByID(id);
                STUDENT student = new STUDENT();
                student.SID = id;
                student.SName = TextBox1.Text;
                student.Address = TextBox2.Text;
                student.Grade = TextBox3.Text;
                student.Requirement = TextBox8.Text;
                student.Comment = TextBox7.Text;
                wrapper.updateARecord(student);
                Session.Remove("SID");
            }

            else
            {
                StudentWrapper wrapper = new StudentWrapper();
                STUDENT student = new STUDENT();
                student.SName = TextBox1.Text;
                student.Address = TextBox2.Text;
                student.Grade = TextBox3.Text;
                student.Requirement = TextBox8.Text;
                student.Comment = TextBox7.Text;
                wrapper.addAClassRecord(student);
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
            Label9.Visible = false;


            TextBox1.Visible = false;
            TextBox2.Visible = false;
            TextBox3.Visible = false;
            TextBox7.Visible = false;
            TextBox8.Visible = false;

            Button1.Visible = false;

            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox7.Text = "";
            TextBox8.Text = "";
        }

        protected void AddClick(object sender, EventArgs e)
        {
            Label2.Visible = true;
            Label3.Visible = true;
            Label4.Visible = true;
            Label8.Visible = true;
            Label9.Visible = true;

            TextBox1.Visible = true;
            TextBox2.Visible = true;
            TextBox3.Visible = true;
            TextBox7.Visible = true;
            TextBox8.Visible = true;
            Button1.Visible = true;
        }
    }
}