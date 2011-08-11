using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;
using DAL;

namespace XuezhijiaWebsite
{
    public partial class CarManage : System.Web.UI.Page
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
            CarWrapper wrapper = new CarWrapper();
            DataTable table = new DataTable();
            table = wrapper.getall();
            Cars.DataSource = table;
            Cars.DataBind();
        }

        protected void RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(Cars.DataKeys[e.RowIndex].Value);
            CarWrapper wrapper = new CarWrapper();
            wrapper.deleteARecordByID(id);

        }

        protected void RowUpdate(object sender, GridViewCommandEventArgs e)
        {
            string cmd = e.CommandName; //获得name
            int Id = Convert.ToInt32(e.CommandArgument);
            CAR car = new CAR();
            CarWrapper wrapper = new CarWrapper();
            car = wrapper.getResultByID(Id);
            Label2.Visible = true;
            Label3.Visible = true;
            Label4.Visible = true;
            Label5.Visible = true;
            Label6.Visible = true;
            Label7.Visible = true;
            Label8.Visible = true;

            TextBox1.Visible = true;
            TextBox2.Visible = true;
            TextBox3.Visible = true;
            TextBox4.Visible = true;
            TextBox5.Visible = true;
            TextBox6.Visible = true;
            TextBox7.Visible = true;

            TextBox1.Text = car.Type;
            TextBox2.Text = car.SeatsCounts.ToString();
            TextBox3.Text = car.Price.ToString();
            TextBox4.Text = car.HirePrice.ToString();
            TextBox5.Text = car.AdditionalPerKM.ToString();
            TextBox6.Text = car.AdditionalPerHour.ToString();
            TextBox7.Text = car.Comment;

            Session.Add("CarID", Id);
            //string cmd = e.CommandName; //获得name
            //int Id = Convert.ToInt32(e.CommandArgument);
            //Car.CarDataTable table = new Car.CarDataTable();
            //Car.CarRow row = table.NewCarRow();
            //row = 
        }

        protected void CommitClick(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Session["CarID"].ToString());
            CAR car = new CAR();
            car.Type = TextBox1.Text ;
            car.SeatsCounts = Convert.ToInt32(TextBox2.Text);
            car.Price = Convert.ToDouble(TextBox3.Text);
            car.HirePrice = Convert.ToDouble(TextBox4.Text);
            car.AdditionalPerKM = Convert.ToDouble(TextBox5.Text);
            car.AdditionalPerHour = Convert.ToDouble(TextBox6.Text);
            TextBox7.Text = car.Comment;


        }

    }
}