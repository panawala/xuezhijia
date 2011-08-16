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
    public partial class PrintManage : System.Web.UI.Page
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
            FileRecordWrapper wrapper = new FileRecordWrapper();
            DataTable table = new DataTable();
            table = wrapper.getAll();
            File.DataSource = table;
            File.DataBind();
        }

        protected void RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void DeleteClick(int id)
        {
            FileRecordWrapper wrapper = new FileRecordWrapper();
            FILERECORDS filerecord = new FILERECORDS();
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

            FILERECORDS file = new FILERECORDS();
            FileRecordWrapper wrapper = new FileRecordWrapper();
            file = wrapper.getResultByID(Id);
            Label2.Visible = true;
            TextBox1.Visible = true;
            Button1.Visible = true;
            TextBox1.Text = file.State;
            Session.Add("RecordID", Id);
        }

        protected void CommitClick(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Session["RecordID"].ToString());
            FILERECORDS tmp = new FILERECORDS();
            FileRecordWrapper wrapper = new FileRecordWrapper();
            tmp = wrapper.getResultByID(id);
            tmp.State = TextBox1.Text;
            wrapper.updateARecord(tmp);
            Session.Remove("RecordID");
            PostInit();
            InitPage();
        }

        protected void PostInit()
        {
            Label2.Visible = false;
            TextBox1.Visible = false;
            Button1.Visible = false;
            TextBox1.Text = "";
        }
    }
}