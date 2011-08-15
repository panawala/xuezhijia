using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;
using DAL;

namespace XuezhijiaWebsite
{
    public partial class TakeOutManage : System.Web.UI.Page
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
            ShopWrapper wrapper = new ShopWrapper();
            DataTable table = new DataTable();
            table = wrapper.getAll();
            Shops.DataSource = table;
            Shops.DataBind();
        }


        protected void RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void DeleteClick(int id)
        {
            ShopWrapper wrapper = new ShopWrapper();
            SHOP shop = new SHOP();
            shop = wrapper.getResultByID(id);
            PhotoWrapper photowrpper = new PhotoWrapper();
            photowrpper.deleteARecord(shop.PID);
            wrapper.deleteARecordByID(id);
            InitPage(); 
        }

        protected void DishCheck(int id)
        {
            Response.Redirect("/DishManage.aspx?OwnerId=" + id.ToString());
        }

        protected void RowUpdate(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandArgument.ToString().Length < 1)
            {
                return;
            }
            string cmd = e.CommandName;
            int Id = Convert.ToInt32(e.CommandArgument);
            switch (cmd)
            {
                case "Delete": DeleteClick(Id);
                    return;
                case "Check": DishCheck(Id);
                    return;
            }
            SHOP shop = new SHOP();
            ShopWrapper wrapper = new ShopWrapper();
            shop = wrapper.getResultByID(Id);
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

            TextBox1.Text = shop.ShopName;
            TextBox2.Text = shop.ShopContactWay.ToString();
            TextBox3.Text = shop.ShopAddress.ToString();
            TextBox4.Text = shop.ShopScore.ToString();
            TextBox5.Text = shop.ShopDistrictId.ToString();
            TextBox6.Text = shop.ShopClickedCount.ToString();
            TextBox7.Text = shop.Comment;

            Image1.ImageUrl = "/Common/ShowPhoto.ashx?id=" + shop.PID.ToString();
            Image1.Visible = true;
            Session.Add("ShopID", Id);
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
            if (Session["ShopID"] != null && Session["ShopID"].ToString() != "")
            {
               
                int id = Convert.ToInt32(Session["ShopID"].ToString());
                SHOP tmp = new SHOP();
                ShopWrapper wrapper  = new ShopWrapper();
                tmp = wrapper.getResultByID(id);
                SHOP shop = new SHOP();
                shop.ShopName = TextBox1.Text ;
                shop.ShopContactWay = TextBox2.Text;
                shop.ShopAddress = TextBox3.Text;
                shop.ShopScore = Convert.ToDouble(TextBox4.Text);
                shop.ShopDistrictId = TextBox5.Text;
                shop.ShopClickedCount = Convert.ToInt32(TextBox6.Text);
                shop.Comment = TextBox7.Text;
                shop.ShopId = id;
                shop.PID = tmp.PID;
                if (Upload.FileName.Length > 0)
                {
                    PhotoWrapper photowrapper = new PhotoWrapper();
                    photowrapper.deleteARecord(tmp.PID);
                    addAPhoto();
                    if (shop.PID.ToString().Length > 0)
                    {
                        photowrapper.deleteARecord(shop.PID);
                    }
                    CommenHelper helper = CommenHelper.GetInstance();
                    shop.PID = helper.getIdent("Photo");
                }
                
                wrapper.updateARecord(shop);
                Session.Remove("ShopID");
            }

            else
            {
                SHOP tmp = new SHOP();
                ShopWrapper wrapper = new ShopWrapper();
                SHOP shop = new SHOP();
                addAPhoto();
                CommenHelper helper = CommenHelper.GetInstance();
                shop.PID = helper.getIdent("Photo");
                shop.ShopName = TextBox1.Text;
                shop.ShopContactWay = TextBox2.Text;
                shop.ShopAddress = TextBox3.Text;
                shop.ShopScore = Convert.ToDouble(TextBox4.Text);
                shop.ShopDistrictId = TextBox5.Text;
                shop.ShopClickedCount = Convert.ToInt32(TextBox6.Text);
                shop.Comment = TextBox7.Text;
                wrapper.addAClassRecord(shop);
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

        protected void Shops_SelectedIndexChanged(object sender, EventArgs e)
        {
            Shops.SelectedIndex = Shops.PageIndex;
        }
    }
}