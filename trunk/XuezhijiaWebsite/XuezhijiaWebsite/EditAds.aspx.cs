﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;
using DAL;
using DAL.ArticalTableAdapters;

namespace XuezhijiaWebsite
{
    public partial class EditAds : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ArticalWrapper wrapper = new ArticalWrapper();
                DataTable table = new DataTable();
                table = wrapper.getAll();
                DropDownList_Area.DataSource = table;
                DropDownList_Area.DataTextField = "ArticleArea";
                DropDownList_Area.DataValueField = "ArticleID";
                DropDownList_Area.DataBind();
            }
        }

        protected void Btn_Submit_Click(object sender, EventArgs e)
        {
            ArticalWrapper wrapper = new ArticalWrapper();
            Artical.ArticleRow row = (new Artical.ArticleDataTable()).NewArticleRow();
            row.ArticleID = Convert.ToInt32(DropDownList_Area.SelectedValue);
            row.ArticleArea=DropDownList_Area.Text;
            row.ArticleContent=CKEditor1.Text;
            wrapper.addARecord(row);
            //preCKEditorData.InnerText = CKEditor1.Text;
            //Response.Write(CKEditor1.Text);
        }
    }
}