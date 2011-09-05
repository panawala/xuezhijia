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
    public partial class StudentMarketManage : System.Web.UI.Page
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
            CommodityWrapper wrapper = new CommodityWrapper();
            DataTable table = new DataTable();
            table = wrapper.getall();
            Commodities.DataSource = table;
            Commodities.DataBind();
        }

        protected void RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
  
        }

        protected void DeleteClick(int id)
        {
            CommodityWrapper wrapper = new CommodityWrapper();
            COMMODITY commodity = new COMMODITY();
            commodity = wrapper.getResultByID(id);
            PhotoWrapper photowrpper = new PhotoWrapper();
            photowrpper.deleteARecord(commodity.PhotoID);
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
            if (cmd == "Delete")
            {
                DeleteClick(Id);
                return;
            }

            COMMODITY commodity = new COMMODITY();
            CommodityWrapper wrapper = new CommodityWrapper();
            commodity = wrapper.getResultByID(Id);
            Label2.Visible = true;
            Label3.Visible = true;
            Label4.Visible = true;
            Label5.Visible = true;
            Label8.Visible = true;
            Label9.Visible = true;
            Label10.Visible = true;

            TextBox1.Visible = true;
            TextBox2.Visible = true;
            TextBox3.Visible = true;
            TextBox4.Visible = true;
            TextBox7.Visible = true;

            Upload.Visible = true;
            LabelComment.Visible = true;
            Comment.Visible = true;
            Button1.Visible = true;

            TextBox1.Text = commodity.ComName;
            TextBox2.Text = commodity.Type.ToString();
            TextBox3.Text = commodity.Price.ToString();
            TextBox4.Text = commodity.Detail.ToString();
            TextBox7.Text = commodity.Comment.ToString();

            TextBox7.Text = commodity.Comment;

            Image1.ImageUrl = "/Common/ShowPhoto.ashx?id=" + commodity.PhotoID.ToString();
            Image1.Visible = true;
            Session.Add("CommodityID", Id);
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
            if (Session["CommodityID"] != null && Session["CommodityID"].ToString() != "")
            {

                int id = Convert.ToInt32(Session["CommodityID"].ToString());
                COMMODITY tmp = new COMMODITY();
                CommodityWrapper wrapper = new CommodityWrapper();
                tmp = wrapper.getResultByID(id);
                COMMODITY commodity = new COMMODITY();
                commodity.ComName = TextBox1.Text;
                commodity.Type = TextBox2.Text;
                commodity.Price = TextBox3.Text;
                commodity.Detail = TextBox4.Text;
                commodity.Comment = TextBox7.Text;
                commodity.ComID = id;
                commodity.PhotoID = tmp.PhotoID;

                if (Upload.FileName.Length > 0)
                {
                    PhotoWrapper photowrapper = new PhotoWrapper();
                    photowrapper.deleteARecord(tmp.PhotoID);
                    if (commodity.PhotoID.ToString().Length > 0)
                    {
                        photowrapper.deleteARecord(commodity.PhotoID);
                    }
                    addAPhoto();
                    CommenHelper helper = CommenHelper.GetInstance();
                    commodity.PhotoID = helper.getIdent("Photo");
                }

                wrapper.updateARecord(commodity);
                Session.Remove("CommodityID");
            }

            else
            {
                CommodityWrapper wrapper = new CommodityWrapper();
                COMMODITY commodity = new COMMODITY();
                addAPhoto();
                CommenHelper helper = CommenHelper.GetInstance();
                COMMODITY commoditynew = new COMMODITY();
                commoditynew.ComName = TextBox1.Text;
                commoditynew.Type = TextBox2.Text;
                commoditynew.Price = TextBox3.Text;
                commoditynew.Detail = TextBox4.Text;
                commoditynew.Comment = TextBox7.Text;
                commoditynew.PhotoID = helper.getIdent("Photo");
                wrapper.addAClassRecord(commoditynew);
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
            Label8.Visible = false;
            Label9.Visible = false;
            Label10.Visible = false;

            TextBox1.Visible = false;
            TextBox2.Visible = false;
            TextBox3.Visible = false;
            TextBox4.Visible = false;
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
            TextBox7.Text = "";
        }

        protected void AddClick(object sender, EventArgs e)
        {
            Label2.Visible = true;
            Label3.Visible = true;
            Label4.Visible = true;
            Label5.Visible = true;
            Label8.Visible = true;
            Label10.Visible = true;

            TextBox1.Visible = true;
            TextBox2.Visible = true;
            TextBox3.Visible = true;
            TextBox4.Visible = true;
            TextBox7.Visible = true;

            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox7.Text = "";

            Upload.Visible = true;
            LabelComment.Visible = true;
            Comment.Visible = true;
            Button1.Visible = true;
        }
    }
}