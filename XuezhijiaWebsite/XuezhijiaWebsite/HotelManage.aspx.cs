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
    public partial class HotelManage : System.Web.UI.Page
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
            HotelWrapper wrapper = new HotelWrapper();
            DataTable table = new DataTable();
            table = wrapper.getAll();
            HotelGridview.DataSource = table;
            HotelGridview.DataBind();
        }

        protected void RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void DeleteClick(int id)
        {
            HotelWrapper wrapper = new HotelWrapper();
            HOTEL hotel = new HOTEL();
            hotel = wrapper.getResultByID(id);
            PhotoWrapper photowrpper = new PhotoWrapper();
            for (int i = 0; i < hotel.PIDList.Count; i++)
            {
                photowrpper.deleteARecord(hotel.PIDList[i]);
            }
            wrapper.deleteARecordByID(id);
            InitPage(); 
        }

        protected void RowUpdate(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandArgument.ToString().Length < 1)
            {
                return;
            }
            string cmd = e.CommandName;
            int Id = Convert.ToInt32(e.CommandArgument);
            if (cmd == "Delete")
            {
                DeleteClick(Id);
                return;
            }
          
            HOTEL hotel = new HOTEL();
            HotelWrapper wrapper = new HotelWrapper();
            hotel = wrapper.getResultByID(Id);
            Label2.Visible = true;
            Label3.Visible = true;
            Label4.Visible = true;
            Label5.Visible = true;
            Label6.Visible = true;
            Label9.Visible = true;
            Label10.Visible = true;

            TextBox1.Visible = true;
            TextBox2.Visible = true;
            TextBox3.Visible = true;
            TextBox4.Visible = true;
            TextBox5.Visible = true;
            TextBox7.Visible = true;

            Upload.Visible = true;
            LabelComment.Visible = true;
            Comment.Visible = true;
            Button1.Visible = true;

            TextBox1.Text = hotel.HotelName;
            TextBox2.Text = hotel.Location.ToString();
            TextBox3.Text = hotel.ContactWay.ToString();
            TextBox4.Text = hotel.Type.ToString();
            TextBox5.Text = hotel.Price.ToString();
            TextBox7.Text = hotel.Comment;

            Image1.ImageUrl = "/Common/ShowPhoto.ashx?id=" + hotel.PID.ToString();
            Image1.Visible = true;
            Session.Add("HotelID", Id);
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

        private  List<string>_getStringList(string str)
        {
            List<string> list = new List<string>();
            string[] lt = str.Split('、');
            for (int i = 0; i < lt.Length; i++)
            {
                if (lt[i].Length > 0)
                {
                    list.Add(lt[i]);
                }
            }
            return list;
        }

        protected void CommitClick(object sender, EventArgs e)
        {
            if (Session["HotelID"] != null && Session["HotelID"].ToString() != "")
            {

                int id = Convert.ToInt32(Session["HotelID"].ToString());
                HOTEL tmp = new HOTEL();
                HotelWrapper wrapper  = new HotelWrapper();
                tmp = wrapper.getResultByID(id);
                HOTEL hotel = new HOTEL();
                hotel.HotelName = TextBox1.Text ;
                hotel.Location = TextBox2.Text; 
                hotel.ContactWay = TextBox3.Text;
                hotel.Type = TextBox4.Text;
                hotel.Price = TextBox5.Text;
                hotel.Comment = TextBox7.Text;
                hotel.HotelID = id;
                hotel.PID = tmp.PID;
                hotel.PIDList = tmp.PIDList;
                if (Upload.FileName.Length > 0)
                {
                    PhotoWrapper photowrapper = new PhotoWrapper();
                    photowrapper.deleteARecord(tmp.PID);
                    addAPhoto();
                    if (hotel.PID.ToString().Length > 0)
                    {
                        photowrapper.deleteARecord(hotel.PID);
                    }
                    CommenHelper helper = CommenHelper.GetInstance();
                    hotel.PID = helper.getIdent("Photo");
                    hotel.PIDList.Add(hotel.PID);
                }
                
                wrapper.updateARecord(hotel);
                Session.Remove("HotelID");
            }

            else
            {
                HotelWrapper wrapper = new HotelWrapper();
                HOTEL hotel = new HOTEL();
                addAPhoto();
                CommenHelper helper = CommenHelper.GetInstance();
                hotel.PID = helper.getIdent("Photo");
                hotel.HotelName = TextBox1.Text;
                hotel.Location = TextBox2.Text;
                hotel.ContactWay = TextBox3.Text;
                hotel.Type = TextBox4.Text;
                hotel.Price = TextBox5.Text;
                hotel.PIDList.Add( hotel.PID);
                hotel.Comment = TextBox7.Text;
                wrapper.addAClassRecord(hotel);
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
            Label8.Visible = false;
            Label9.Visible = false;
            Label10.Visible = false;

            TextBox1.Visible = false;
            TextBox2.Visible = false;
            TextBox3.Visible = false;
            TextBox4.Visible = false;
            TextBox5.Visible = false;
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
            TextBox7.Text = "";
        }

        protected void AddClick(object sender, EventArgs e)
        { 
            HOTEL tmp = new HOTEL();
            Label2.Visible = true;
            Label3.Visible = true;
            Label4.Visible = true;
            Label5.Visible = true;
            Label6.Visible = true;
            Label8.Visible = true;
            Label10.Visible = true;

            TextBox1.Visible = true;
            TextBox2.Visible = true;
            TextBox3.Visible = true;
            TextBox4.Visible = true;
            TextBox5.Visible = true;
            TextBox7.Visible = true;
            Label9.Visible = false;
            Image1.Visible = false;

            Upload.Visible = true;
            LabelComment.Visible = true;
            Comment.Visible = true;
            Button1.Visible = true;
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox7.Text = "";
        }
    }
}