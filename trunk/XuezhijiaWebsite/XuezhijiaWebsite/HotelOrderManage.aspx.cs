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
    public partial class HotelOrderManage : System.Web.UI.Page
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
            HotelOrderWrapper wrapper = new HotelOrderWrapper();
            DataTable table = new DataTable();
            table = wrapper.getall();
            Order.DataSource = table;
            Order.DataBind();
        }

        protected void DeleteClick(int id)
        {
            HotelOrderWrapper wrapper = new HotelOrderWrapper();
            HOTELORDER hotelorder = new HOTELORDER();
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
            HOTELORDER hotelorder = new HOTELORDER();
            HotelOrderWrapper wrapper = new HotelOrderWrapper();
            hotelorder = wrapper.getResultByID(Id);
        }
        protected void Shops_SelectedIndexChanged(object sender, EventArgs e)
        {
            Order.SelectedIndex = Order.PageIndex;
        }
    }
}