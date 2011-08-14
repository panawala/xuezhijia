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
    public partial class TicketManage : System.Web.UI.Page
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
            TicketWrapper wrapper = new TicketWrapper();
            DataTable table = new DataTable();
            table = wrapper.getall();
            Tickets.DataSource = table;
            Tickets.DataBind();
        }

        protected void RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(Tickets.DataKeys[e.RowIndex].Value);
            TicketWrapper wrapper = new TicketWrapper();
            wrapper.deleteARecordByID(id);

        }

        protected void DeleteClick(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Tickets.DataKeys[Tickets.SelectedIndex + 1].Value);
            TicketWrapper wrapper = new TicketWrapper();
            TICKET ticket = new TICKET();
            ticket = wrapper.getResultByID(id);
            PhotoWrapper photowrpper = new PhotoWrapper();
            photowrpper.deleteARecord(ticket.PID);
            wrapper.deleteARecordByID(id);
            InitPage();
            PostInit();
        }

        protected void RowUpdate(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandArgument.ToString().Length < 1)
            {
                return;
            }
            string cmd = e.CommandName; //获得name
            int Id = Convert.ToInt32(e.CommandArgument);
            TICKET ticket = new TICKET();
            TicketWrapper wrapper = new TicketWrapper();
            ticket = wrapper.getResultByID(Id);
            Label2.Visible = true;
            Label3.Visible = true;
            Label4.Visible = true;
            Label5.Visible = true;
            Label6.Visible = true;
            Label8.Visible = true;
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

            TextBox1.Text = ticket.TicketName;
            TextBox2.Text = ticket.DurationOfService.ToString();
            TextBox3.Text = ticket.Price.ToString();
            TextBox4.Text = ticket.WayToPay.ToString();
            TextBox5.Text = ticket.LinkURL.ToString();
            TextBox7.Text = ticket.Comment;

            Image1.ImageUrl = "/Common/ShowPhoto.ashx?id=" + ticket.PID.ToString();
            Image1.Visible = true;
            Session.Add("TicketID", Id);
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
            if (Session["TicketID"] != null && Session["TicketID"].ToString() != "")
            {
               
                int id = Convert.ToInt32(Session["TicketID"].ToString());
                TICKET tmp = new TICKET();
                TicketWrapper wrapper  = new TicketWrapper();
                tmp = wrapper.getResultByID(id);
                TICKET ticket = new TICKET();
                ticket.TicketName = TextBox1.Text ;
                ticket.DurationOfService =TextBox2.Text;
                ticket.Price = Convert.ToDouble(TextBox3.Text);
                ticket.WayToPay = TextBox4.Text;
                ticket.LinkURL = TextBox5.Text;
                ticket.Comment = TextBox7.Text;
                ticket.TicketID = id;
                ticket.PID = tmp.PID;
                if (Upload.FileName.Length > 0)
                {
                    PhotoWrapper photowrapper = new PhotoWrapper();
                    photowrapper.deleteARecord(tmp.PID);
                    addAPhoto();
                    if (ticket.PID.ToString().Length > 0)
                    {
                        photowrapper.deleteARecord(ticket.PID);
                    }
                    CommenHelper helper = CommenHelper.GetInstance();
                    ticket.PID = helper.getIdent("Photo");
                }
                
                wrapper.updateARecord(ticket);
                Session.Remove("TicketID");
            }

            else
            {
                TICKET tmp = new TICKET();
                TicketWrapper wrapper = new TicketWrapper();
                TICKET ticket = new TICKET();
                addAPhoto();
                CommenHelper helper = CommenHelper.GetInstance();
                ticket.PID = helper.getIdent("Photo");
                ticket.TicketName = TextBox1.Text ;
                ticket.DurationOfService =TextBox2.Text;
                ticket.Price = Convert.ToDouble(TextBox3.Text);
                ticket.WayToPay = TextBox4.Text;
                ticket.LinkURL = TextBox5.Text;
                ticket.Comment = TextBox7.Text;
                wrapper.addAClassRecord(ticket);
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

            Upload.Visible = true;
            LabelComment.Visible = true;
            Comment.Visible = true;
            Button1.Visible = true;
        }
    }
}