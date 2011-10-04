using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using BLL;
using System.Data;

namespace XuezhijiaWebsite
{
    public partial class MemberManage : System.Web.UI.Page
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
            MemberWrapper wrapper = new MemberWrapper();
            DataTable table = new DataTable();
            table = wrapper.getall();
            Member.DataSource = table;
            Member.DataBind();
        }

        protected void DeleteClick(int id)
        {
            MemberWrapper wrapper = new MemberWrapper();
            MEMBER member = new MEMBER();
            member = wrapper.getResultByID(id);
            PhotoWrapper photowrpper = new PhotoWrapper();
            wrapper.deleteARecordByID(id);
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
            MEMBER member = new MEMBER();
            MemberWrapper wrapper = new MemberWrapper();
            member = wrapper.getResultByID(Id);
        }
        protected void Shops_SelectedIndexChanged(object sender, EventArgs e)
        {
            Member.SelectedIndex = Member.PageIndex;
        }
    }
}