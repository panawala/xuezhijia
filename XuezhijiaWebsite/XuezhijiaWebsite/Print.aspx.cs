using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;
using System.Data;
using System.IO;

namespace XuezhijiaWebsite
{
    public partial class Print : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                return;
            }
            InitPage();
        }

        public void InitPage()
        {
            FileRecordWrapper wrapper = new FileRecordWrapper();
            DataTable table = new DataTable();
            if (Session["UserID"] != null && Session["UserID"] != "")
            {
                string uid = Session["UserID"].ToString();
                table = wrapper.getResultByUserID(Convert.ToInt16(uid));
                History.DataSource = table;
                History.DataBind();
            }
        }

        protected void CommitLoad(object sender, EventArgs e)
        {
            UserInfoWrapper wrapper = new UserInfoWrapper();
            string username = UserName.Text;
            string password = Password.Text;
            bool isvalidite = wrapper.IsValidite(username, password);
            if (isvalidite)
            {
                UserInfo.UserInfoRow row;
                UserInfo.UserInfoDataTable table = new UserInfo.UserInfoDataTable();
                row = table.NewUserInfoRow();
                row = wrapper.getRecordByUserNameAndPassWord(username, password);
                Session.Add("Username", username);
                Session.Add("UserID", row.UserID.ToString());
                Session.Add("PassWord", password);
                InitPage();
            }
        }

        protected void CommitRegister(object sender, EventArgs e)
        {
            UserInfoWrapper wrapper = new UserInfoWrapper();
            string username = UserName.Text;
            string password = Password.Text;
            bool isvalidite = wrapper.IsValidite(username, password);
            if (isvalidite)
            {
                UserInfo.UserInfoRow row;
                UserInfo.UserInfoDataTable table = new UserInfo.UserInfoDataTable();
                row = table.NewUserInfoRow();
                row = wrapper.getRecordByUserNameAndPassWord(username, password);
                Session.Add("Username", username);
                Session.Add("UserID", row.UserID.ToString());
                Session.Add("PassWord", password);
                InitPage();
            }
        }

        protected void CommitPrint(object sender, EventArgs e)
        {
            string filename = LoadFile.FileName;
            string comment = PrintComment.Text;
            int uid = Convert.ToInt16(Session["UserID"].ToString());
            CommenHelper helper = CommenHelper.GetInstance();
            DateTime time = DateTime.Now;
            int state = 0;
            FileRecords.FileRecordsRow row;
            FileRecords.FileRecordsDataTable table = new FileRecords.FileRecordsDataTable();
            row = table.NewFileRecordsRow();
            row.Comment = comment;
            row.UserID = uid;
            row.DateTimee = time;
            row.State = state;
            row.FileName = filename;
            row.Size = "";
            row.PageCount = 6;
            row.Pseudonym = new Guid();
            FileRecordWrapper wrapper = new FileRecordWrapper();
            int Rid = helper.getIdent("FileRecords");
            filename = Server.MapPath("UploadFile") + "\\" + Session["Username"].ToString() + Rid.ToString() + LoadFile.FileName;
            LoadFile.SaveAs(filename);
            wrapper.addARecord(row);
            InitPage();
        }

        protected void RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(History.DataKeys[e.RowIndex].Value);
            FileRecordWrapper wrapper = new FileRecordWrapper();
            wrapper.deleteARecord(id);
            InitPage();
        }

        protected void RowUpdate(object sender, GridViewCommandEventArgs e)
        {
        }
    }
}