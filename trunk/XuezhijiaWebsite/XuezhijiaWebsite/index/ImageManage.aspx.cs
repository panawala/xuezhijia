using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XuezhijiaWebsite.Index
{
    public partial class ImageManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView_Image_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string sqlstr = "delete from 表 where id='" + GridView_Image.DataKeys[e.RowIndex].Value.ToString() + "'";

        }

        protected void GridView_Image_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView_Image.EditIndex = e.NewEditIndex;

        }

        protected void GridView_Image_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string sqlstr = "update 表 set 字段1='"
            + ((TextBox)(GridView_Image.Rows[e.RowIndex].Cells[1].Controls[0])).Text.ToString().Trim() + "',字段2='"
            + ((TextBox)(GridView_Image.Rows[e.RowIndex].Cells[2].Controls[0])).Text.ToString().Trim() + "',字段3='"
            + ((TextBox)(GridView_Image.Rows[e.RowIndex].Cells[3].Controls[0])).Text.ToString().Trim() + "' where id='"
            + GridView_Image.DataKeys[e.RowIndex].Value.ToString() + "'";

        }

        protected void GridView_Image_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView_Image.EditIndex = -1;
        }
    }
}