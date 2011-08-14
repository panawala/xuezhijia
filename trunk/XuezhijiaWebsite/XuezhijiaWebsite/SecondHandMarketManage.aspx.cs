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
    public partial class SecondHandMarketManage : System.Web.UI.Page
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
            SecondHMWrapper wrapper = new SecondHMWrapper();
            DataTable table = new DataTable();
            table = wrapper.getAll();
            SecondHandMarkets.DataSource = table;
            SecondHandMarkets.DataBind();
        }

        protected void RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(SecondHandMarkets.DataKeys[e.RowIndex].Value);
            SecondHMWrapper wrapper = new SecondHMWrapper();
            wrapper.deleteARecordByID(id);

        }

        protected void DeleteClick(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(SecondHandMarkets.DataKeys[SecondHandMarkets.SelectedIndex + 1].Value);
            SecondHMWrapper wrapper = new SecondHMWrapper();
            SECONDHANDMARKET secondhandmarket = new SECONDHANDMARKET();
            secondhandmarket = wrapper.getResultByID(id);
            deletePhoto(secondhandmarket);
            wrapper.deleteARecordByID(id);
            InitPage();
        }

        private void deletePhoto(SECONDHANDMARKET secondhandmarket)
        {
            PhotoWrapper photowrpper = new PhotoWrapper();
            for (int i = 0; i < secondhandmarket.PIDList.Count; i++)
            {
                photowrpper.deleteARecord(secondhandmarket.PIDList[i]);

            }
        }

        protected void RowUpdate(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandArgument.ToString().Length < 1)
            {
                return;
            }
            string cmd = e.CommandName; //获得name
            int Id = Convert.ToInt32(e.CommandArgument);
            SECONDHANDMARKET secondhandmarket = new SECONDHANDMARKET();
            SecondHMWrapper wrapper = new SecondHMWrapper();
            secondhandmarket = wrapper.getResultByID(Id);
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

            Button1.Visible = true;

            TextBox1.Text = secondhandmarket.Tipical;
            TextBox2.Text = secondhandmarket.Type.ToString();
            TextBox3.Text = secondhandmarket.LookCount.ToString();
            TextBox4.Text = secondhandmarket.Price.ToString();
            TextBox5.Text = secondhandmarket.PublishDate.ToString();
            TextBox8.Text = secondhandmarket.Location.ToString();
            TextBox9.Text = secondhandmarket.ContactInformation;
            TextBox7.Text = secondhandmarket.Comment;
            Session.Add("SID", Id);
        }

        protected void CommitClick(object sender, EventArgs e)
        {
            SecondHMWrapper wrapper = new SecondHMWrapper();
            SECONDHANDMARKET secondhandmarket = new SECONDHANDMARKET();
            secondhandmarket.SID = Convert.ToInt32(Session["SID"].ToString());
            secondhandmarket.Tipical = TextBox1.Text;
            secondhandmarket.Type = TextBox2.Text;
            secondhandmarket.LookCount = Convert.ToInt32(TextBox3.Text);
            secondhandmarket.Price = Convert.ToDouble(TextBox4.Text);
            secondhandmarket.PublishDate = TextBox5.Text;
            secondhandmarket.Comment = TextBox7.Text;
            secondhandmarket.Location = TextBox8.Text;
            secondhandmarket.ContactInformation = TextBox9.Text;
            wrapper.updateARecord(secondhandmarket);
            PostInit();
            InitPage();
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
            TextBox8.Visible = false;
            TextBox9.Visible = false;

            Button1.Visible = false;

            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox7.Text = "";
            TextBox8.Text = "";
            TextBox9.Text = "";
        }
    }
}