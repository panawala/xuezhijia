using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;
using DAL;
using DAL.CarTableAdapters;

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

        protected void DeleteClick(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Cars.DataKeys[Cars.SelectedIndex + 1].Value);
            CarWrapper wrapper = new CarWrapper();
            CAR car = new CAR();
            car = wrapper.getResultByID(id);
            PhotoWrapper photowrpper = new PhotoWrapper();
            photowrpper.deleteARecord(car.PID);
            wrapper.deleteARecordByID(id);
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
            Label9.Visible = true;
            Label10.Visible = true;

            TextBox1.Visible = true;
            TextBox2.Visible = true;
            TextBox3.Visible = true;
            TextBox4.Visible = true;
            TextBox5.Visible = true;
            TextBox6.Visible = true;
            TextBox7.Visible = true;

            Upload.Visible = true;
            LabelComment.Visible = true;
            Comment.Visible = true;
            Button1.Visible = true;

            TextBox1.Text = car.Type;
            TextBox2.Text = car.SeatsCounts.ToString();
            TextBox3.Text = car.Price.ToString();
            TextBox4.Text = car.HirePrice.ToString();
            TextBox5.Text = car.AdditionalPerKM.ToString();
            TextBox6.Text = car.AdditionalPerHour.ToString();
            TextBox7.Text = car.Comment;

            Image1.ImageUrl = "/Common/ShowPhoto.ashx?id=" + car.PID.ToString();
            Image1.Visible = true;
            Session.Add("CarID", Id);
        }

        protected void UploadClicked(object sender, EventArgs e)
        {
            string filename = Upload.FileName;
            byte[] data = Upload.FileBytes;
            string comment = Comment.Text;
            Photo.PhotoDataTable table = new Photo.PhotoDataTable();
            Photo.PhotoRow row = table.NewPhotoRow();
            row.Data = data;
            row.Comment = comment;
            row.PName = filename;
            PhotoWrapper wrapper = new PhotoWrapper();
            wrapper.addARecord(row);
        }

        protected void CommitClick(object sender, EventArgs e)
        {
            if (Session["CarID"] != null && Session["CarID"].ToString() != "")
            {
               
                int id = Convert.ToInt32(Session["CarID"].ToString());
                CAR tmp = new CAR();
                CarWrapper wrapper  = new CarWrapper();
                tmp = wrapper.getResultByID(id);
                CAR car = new CAR();
                car.Type = TextBox1.Text ;
                car.SeatsCounts = Convert.ToInt32(TextBox2.Text);
                car.Price = Convert.ToDouble(TextBox3.Text);
                car.HirePrice = Convert.ToDouble(TextBox4.Text);
                car.AdditionalPerKM = Convert.ToDouble(TextBox5.Text);
                car.AdditionalPerHour = Convert.ToDouble(TextBox6.Text);
                car.Comment = TextBox7.Text;
                car.CarID = id;
                car.PID = tmp.PID;
                if (Upload.FileName.Length > 0)
                {
                    PhotoWrapper photowrapper = new PhotoWrapper();
                    photowrapper.deleteARecord(tmp.PID);
                    addAPhoto();
                    CommenHelper helper = CommenHelper.GetInstance();
                    car.PID = helper.getIdent("Photo");
                }
                
                wrapper.updateARecord(car);
                Session.Remove("CarID");
            }

            else
            {
                CAR tmp = new CAR();
                CarWrapper wrapper = new CarWrapper();
                CAR car = new CAR();
                addAPhoto();
                CommenHelper helper = CommenHelper.GetInstance();
                car.PID = helper.getIdent("Photo");
                car.Type = TextBox1.Text;
                car.SeatsCounts = Convert.ToInt32(TextBox2.Text);
                car.Price = Convert.ToDouble(TextBox3.Text);
                car.HirePrice = Convert.ToDouble(TextBox4.Text);
                car.AdditionalPerKM = Convert.ToDouble(TextBox5.Text);
                car.AdditionalPerHour = Convert.ToDouble(TextBox6.Text);
                car.Comment = TextBox7.Text;
                wrapper.addAClassRecord(car);
            }
            PostInit();
            InitPage();
        }

        public void addAPhoto()
        {
            PhotoWrapper photowrapper = new PhotoWrapper();
            Photo.PhotoRow row = new Photo.PhotoDataTable().NewPhotoRow(); ;
            row.Comment = Comment.Text;
            row.Data = Upload.FileBytes;
            row.PName = Upload.FileName;
            photowrapper.addARecord(row);
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
            Label10.Visible = false;

            TextBox1.Visible = false;
            TextBox2.Visible = false;
            TextBox3.Visible = false;
            TextBox4.Visible = false;
            TextBox5.Visible = false;
            TextBox6.Visible = false;
            TextBox7.Visible = false;

            Image1.Visible = false;
            Upload.Visible = false;
            LabelComment.Visible = false;
            Comment.Visible = false;
            Button1.Visible = false;

            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            TextBox7.Text = "";
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
            Label10.Visible = true;

            TextBox1.Visible = true;
            TextBox2.Visible = true;
            TextBox3.Visible = true;
            TextBox4.Visible = true;
            TextBox5.Visible = true;
            TextBox6.Visible = true;
            TextBox7.Visible = true;

            Upload.Visible = true;
            LabelComment.Visible = true;
            Comment.Visible = true;
            Button1.Visible = true;

        }

    }
}