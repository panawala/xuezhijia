using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;

namespace XuezhijiaWebsite.Index
{
    public partial class ImageManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
            }
        }

        private void Bind()
        {
            GridView_Image.DataSource = (new IndexImageWrapper()).getall();
            GridView_Image.DataKeyNames = new string[] { "ID" };//主键
            GridView_Image.DataBind();
        }
        protected void GridView_Image_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            (new IndexImageWrapper()).deleteARecordByID(Convert.ToInt32(GridView_Image.DataKeys[e.RowIndex].Value.ToString()));
            Bind();
        }

        protected void GridView_Image_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView_Image.EditIndex = e.NewEditIndex;
            Bind();
        }

        protected void GridView_Image_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
         
            INDEXIMAGE indeximage = new INDEXIMAGE();
            indeximage.ID = Convert.ToInt32(GridView_Image.DataKeys[e.RowIndex].Value.ToString());
            indeximage.ImageHref = ((TextBox)(GridView_Image.Rows[e.RowIndex].Cells[0].Controls[0])).Text.ToString().Trim();
            indeximage.ImageSrc = ((TextBox)(GridView_Image.Rows[e.RowIndex].Cells[1].Controls[0])).Text.ToString().Trim();
            indeximage.ImageTitle = ((TextBox)(GridView_Image.Rows[e.RowIndex].Cells[2].Controls[0])).Text.ToString().Trim();
            indeximage.ImageAlt = ((TextBox)(GridView_Image.Rows[e.RowIndex].Cells[3].Controls[0])).Text.ToString().Trim();
            (new IndexImageWrapper()).updateARecord(indeximage);
            GridView_Image.EditIndex = -1;
            Bind();
        }

        protected void GridView_Image_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView_Image.EditIndex = -1;
            Bind();
        }

        protected void CommitClick(object sender, EventArgs e)
        {
            INDEXIMAGE image = new INDEXIMAGE();
            image.ImageHref = TextBox1.Text;
            image.ImageSrc = TextBox2.Text;
            image.ImageTitle = TextBox3.Text;
            image.ImageAlt = TextBox4.Text;
            (new IndexImageWrapper()).addAClassRecord(image);
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            Bind();
        }
    }
}