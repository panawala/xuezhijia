using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;
using DAL;

namespace XuezhijiaWebsite
{
    public partial class CarManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            InitPage();
        }

        private void InitPage()
        {
            CarWrapper wrapper = new CarWrapper();
            DataTable table = new DataTable();
            table = wrapper.getall();
            Cars.DataSource = table;
            Cars.DataBind();
        }

        protected void RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(Cars.DataKeys[e.RowIndex].Value);
            CarWrapper wrapper = new CarWrapper();
            wrapper.deleteARecordByID(id);

        }

        protected void RowUpdate(object sender, GridViewCommandEventArgs e)
        {
            //string cmd = e.CommandName; //获得name
            //int Id = Convert.ToInt32(e.CommandArgument);
            //Car.CarDataTable table = new Car.CarDataTable();
            //Car.CarRow row = table.NewCarRow();
            //row = 
        }
    }
}