using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DAL;
using BLL;

namespace XuezhijiaWebsite
{
    public partial class ProxyManage : System.Web.UI.Page
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
            ProxyWrapper wrapper = new ProxyWrapper();
            DataTable table = new DataTable();
            table = wrapper.getall();
            Proxy.DataSource = table;
            Proxy.DataBind();
        }

        protected void DeleteClick(int id)
        {
            ProxyWrapper wrapper = new ProxyWrapper();
            PROXY proxy = new PROXY();
            proxy = wrapper.getResultByID(id);
            PhotoWrapper photowrpper = new PhotoWrapper();
            photowrpper.deleteARecord(proxy.ProID);
            DishWrapper dishwrapper = new DishWrapper();
            dishwrapper.deleResultByOwnerID(id);
            wrapper.deleteARecordByID(id);
            PostInit();
            InitPage();
        }

        protected void RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

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
            }
            PROXY proxy = new PROXY();
            ProxyWrapper wrapper = new ProxyWrapper();
            proxy = wrapper.getResultByID(Id);
            Label2.Visible = true;
            Label3.Visible = true;
            Label8.Visible = true;
            Label9.Visible = true;
            Label10.Visible = true;

            TextBox1.Visible = true;
            TextBox2.Visible = true;
            TextBox7.Visible = true;

            Upload.Visible = true;
            LabelComment.Visible = true;
            Comment.Visible = true;
            Button1.Visible = true;

            TextBox1.Text = proxy.Name;
            TextBox2.Text = proxy.Type.ToString();
            TextBox7.Text = proxy.Comment;

            Image1.ImageUrl = "/Common/ShowPhoto.ashx?id=" + proxy.ImageID.ToString();
            Image1.Visible = true;
            Session.Add("ProxyID", Id);
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
            if (Session["ProxyID"] != null && Session["ProxyID"].ToString() != "")
            {
                int id = Convert.ToInt32(Session["ProxyID"].ToString());
                PROXY tmp = new PROXY();
                ProxyWrapper wrapper = new ProxyWrapper();
                tmp = wrapper.getResultByID(id);
                PROXY proxy = new PROXY();
                proxy.ProID = tmp.ProID;
                proxy.Name = TextBox1.Text;
                proxy.Type = TextBox2.Text;
                proxy.Comment = TextBox7.Text;
                proxy.ImageID = tmp.ImageID;
                if (Upload.FileName.Length > 0)
                {
                    PhotoWrapper photowrapper = new PhotoWrapper();
                    photowrapper.deleteARecord(tmp.ImageID);
                    addAPhoto();
                    if (proxy.ImageID.ToString().Length > 0)
                    {
                        photowrapper.deleteARecord(proxy.ImageID);
                    }
                    CommenHelper helper = CommenHelper.GetInstance();
                    proxy.ImageID = helper.getIdent("Photo");
                }

                wrapper.updateARecord(proxy);
                Session.Remove("ProxyID");
            }

            else
            {
                PROXY tmp = new PROXY();
                ProxyWrapper wrapper = new ProxyWrapper();
                PROXY proxy = new PROXY();
                addAPhoto();
                CommenHelper helper = CommenHelper.GetInstance();
                proxy.ImageID = helper.getIdent("Photo");
                proxy.Name = TextBox1.Text;
                proxy.Type = TextBox2.Text;
                proxy.Comment = TextBox7.Text;
                wrapper.addAClassRecord(proxy);
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
            Label8.Visible = false;
            Label9.Visible = false;
            Label10.Visible = false;

            TextBox1.Visible = false;
            TextBox2.Visible = false;
            TextBox7.Visible = false;

            Image1.Visible = false;
            Upload.Visible = false;
            LabelComment.Visible = false;
            Comment.Visible = false;
            Button1.Visible = false;

            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox7.Text = "";
        }

        protected void AddClick(object sender, EventArgs e)
        {
            Label2.Visible = true;
            Label3.Visible = true;
            Label8.Visible = true;
            Label10.Visible = true;

            TextBox1.Visible = true;
            TextBox2.Visible = true;
            TextBox7.Visible = true;

            Upload.Visible = true;
            LabelComment.Visible = true;
            Comment.Visible = true;
            Button1.Visible = true;

            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox7.Text = "";
        }

        protected void Shops_SelectedIndexChanged(object sender, EventArgs e)
        {
            Proxy.SelectedIndex = Proxy.PageIndex;
        }
    }
}