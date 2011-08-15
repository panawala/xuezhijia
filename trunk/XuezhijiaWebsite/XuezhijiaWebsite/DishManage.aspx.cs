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
    public partial class DishManage : System.Web.UI.Page
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
            int ownerid = Convert.ToInt32(Request.QueryString["OwnerId"].ToString());
            Session.Add("OwnerId", ownerid.ToString());
            Label9.Text = new ShopWrapper().getResultByID(ownerid).ShopName;
            DishWrapper wrapper = new DishWrapper();
            DataTable table = new DataTable();
            table = wrapper.getResultByOwnerID(ownerid);
            Dishs.DataSource = table;
            Dishs.DataBind();
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

            TextBox1.Visible = true;
            TextBox2.Visible = true;
            TextBox3.Visible = true;
            TextBox4.Visible = true;
            TextBox5.Visible = true;
            TextBox6.Visible = true;


            Button1.Visible = true;
        }

        protected void RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
        }

        protected void DeleteClick(int id)
        {
            DishWrapper wrapper = new DishWrapper();
            wrapper.deleteARecordByID(id);
            InitPage();
        }

        protected void RowUpdate(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandArgument.ToString().Length < 1)
            {
                return;
            }
            string cmd = e.CommandName;
            int Id = Convert.ToInt32(e.CommandArgument);
            if (cmd == "Delete")
            {
                DeleteClick(Id);
                return;
            }
            DISH dish = new DISH();
            DishWrapper wrapper = new DishWrapper();
            dish = wrapper.getResultByID(Id);
            Label2.Visible = true;
            Label3.Visible = true;
            Label4.Visible = true;
            Label5.Visible = true;
            Label6.Visible = true;
            Label7.Visible = true;
            Label8.Visible = true;
            Label9.Visible = true;

            TextBox1.Visible = true;
            TextBox2.Visible = true;
            TextBox3.Visible = true;
            TextBox4.Visible = true;
            TextBox5.Visible = true;
            TextBox6.Visible = true;

            Button1.Visible = true;
            TextBox1.Text = dish.DishName;
            TextBox2.Text = dish.DishScore.ToString();
            TextBox3.Text = dish.Price.ToString();
            TextBox4.Text = dish.DishCatalog.ToString();
            TextBox5.Text = dish.DishDownCount.ToString();
            TextBox6.Text = dish.DishUpCount.ToString();
        }

        protected void CommitClick(object sender, EventArgs e)
        {


            if (Session["DishId"] != null && Session["DishId"].ToString() != "")
            {

                DishWrapper wrapper = new DishWrapper();
                DISH dish = new DISH();
                dish.DishId = Convert.ToInt32(Session["DishId"].ToString());
                dish.DishOwnerId = Convert.ToInt32(Session["OwnerId"]);
                dish.DishName = TextBox1.Text;
                dish.DishScore = Convert.ToDouble(TextBox2.Text);
                dish.Price = Convert.ToDouble(TextBox3.Text);
                dish.DishCatalog = TextBox4.Text;
                dish.DishDownCount = Convert.ToInt32(TextBox5.Text);
                dish.DishUpCount = Convert.ToInt32(TextBox6.Text);
                wrapper.updateARecord(dish);
                Session.Remove("DishId");
            }

            else
            {
                DishWrapper wrapper = new DishWrapper();
                DISH dish = new DISH();
                dish.DishOwnerId = Convert.ToInt32(Session["OwnerId"]);
                dish.DishName = TextBox1.Text;
                dish.DishScore = Convert.ToDouble(TextBox2.Text);
                dish.Price = Convert.ToDouble(TextBox3.Text);
                dish.DishCatalog = TextBox4.Text;
                dish.DishDownCount = Convert.ToInt32(TextBox5.Text);
                dish.DishUpCount = Convert.ToInt32(TextBox6.Text);
                wrapper.addAClassRecord(dish);
            }
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
            Label7.Visible = false;

            TextBox1.Visible = false;
            TextBox2.Visible = false;
            TextBox3.Visible = false;
            TextBox4.Visible = false;
            TextBox5.Visible = false;
            TextBox6.Visible = false;

            Button1.Visible = false;

            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
        }
    }
}