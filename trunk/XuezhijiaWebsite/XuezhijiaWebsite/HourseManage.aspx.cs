using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;

namespace XuezhijiaWebsite
{
    public partial class HourseManage : System.Web.UI.Page
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
            RentHourseWrapper wrapper = new RentHourseWrapper();
            DataTable table = new DataTable();
            table = wrapper.getall();
            RentHourses.DataSource = table;
            RentHourses.DataBind();
        }

        protected void RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void DeleteClick(int id)
        {
            RentHourseWrapper wrapper = new RentHourseWrapper();
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

            RENTHOURSE renthourse = new RENTHOURSE();
            RentHourseWrapper wrapper = new RentHourseWrapper();
            renthourse = wrapper.getRentHouseByID(Id);
            Label2.Visible = true;
            Label3.Visible = true;
            Label4.Visible = true;
            Label5.Visible = true;
            Label6.Visible = true;
            Label7.Visible = true;
            Label8.Visible = true;
            Label9.Visible = true;

            TextBox1.Visible = true;
            TextBox2.Visible = true;
            TextBox3.Visible = true;
            TextBox4.Visible = true;
            TextBox5.Visible = true;
            TextBox6.Visible = true;
            TextBox7.Visible = true;
            TextBox8.Visible = true;

            Button1.Visible = true;
            TextBox1.Text = renthourse.Price.ToString();
            TextBox2.Text = renthourse.RentType.ToString();
            TextBox3.Text = renthourse.HourseType.ToString();
            TextBox4.Text = renthourse.HourseName.ToString();
            TextBox5.Text = renthourse.Area.ToString();
            TextBox6.Text = renthourse.Configuration.ToString();
            TextBox7.Text = renthourse.ClickCount.ToString();
            TextBox8.Text = renthourse.DistributeTime.ToString();
            Session.Add("RentHourseID", Id);
        }

        protected void CommitClick(object sender, EventArgs e)
        {
            if (Session["RentHourseID"] != null && Session["RentHourseID"].ToString() != "")
            {

                int id = Convert.ToInt32(Session["RentHourseID"].ToString());
                RENTHOURSE tmp = new RENTHOURSE();
                RentHourseWrapper wrapper = new RentHourseWrapper();
                tmp = wrapper.getRentHouseByID(id);
                RENTHOURSE renthourse = new RENTHOURSE();
                renthourse.Price = Convert.ToDouble(TextBox1.Text);
                renthourse.RentType = TextBox2.Text;
                renthourse.HourseType = TextBox3.Text;
                renthourse.HourseName = TextBox4.Text;
                renthourse.Area = Convert.ToDouble(TextBox5.Text);
                renthourse.Configuration = TextBox6.Text;
                renthourse.ClickCount = Convert.ToInt32(TextBox7.Text);
                renthourse.DistributeTime = TextBox7.Text;
                renthourse.HourseID = id;
                wrapper.updateARecord(renthourse);
                Session.Remove("RentHourseID");
            }

            else
            {
                RentHourseWrapper wrapper = new RentHourseWrapper();
                RENTHOURSE renthourse = new RENTHOURSE();
                renthourse.Price = Convert.ToDouble(TextBox1.Text);
                renthourse.RentType = TextBox2.Text;
                renthourse.HourseType = TextBox3.Text;
                renthourse.HourseName = TextBox4.Text;
                renthourse.Area = Convert.ToDouble(TextBox5.Text);
                renthourse.Configuration = TextBox6.Text;
                renthourse.ClickCount = Convert.ToInt32(TextBox7.Text);
                renthourse.DistributeTime = TextBox7.Text;
                wrapper.addAClassRecord(renthourse);
            }
            PostInit();
            InitPage();
        }

        protected void PostInit()
        {
            Label2.Visible = false;
            Label3.Visible = false;
            Label4.Visible = false;
            Label5.Visible = false;
            Label6.Visible = false;
            Label7.Visible = false;
            Label8.Visible = false;
            Label9.Visible = false;

            TextBox1.Visible = false;
            TextBox2.Visible = false;
            TextBox3.Visible = false;
            TextBox4.Visible = false;
            TextBox5.Visible = false;
            TextBox6.Visible = false;
            TextBox7.Visible = false;
            TextBox8.Visible = false;

            Button1.Visible = false;
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            TextBox7.Text = "";
            TextBox8.Text = "";
        }

        protected void AddClick(object sender, EventArgs e)
        {
            Label2.Visible = true;
            Label3.Visible = true;
            Label4.Visible = true;
            Label5.Visible = true;
            Label6.Visible = true;
            Label7.Visible = true;
            Label8.Visible = true;
            Label9.Visible = true;

            TextBox1.Visible = true;
            TextBox2.Visible = true;
            TextBox3.Visible = true;
            TextBox4.Visible = true;
            TextBox5.Visible = true;
            TextBox6.Visible = true;
            TextBox7.Visible = true;
            TextBox8.Visible = true;
            Button1.Visible = true;

        }
    }
}