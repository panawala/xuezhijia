using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XuezhijiaWebsite.Hotel
{
    public partial class InsertOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string HotelId = Request.QueryString["HotelId"];
            string RoomType = Request.QueryString["RoomType"];
            string RoomCount = Request.QueryString["RoomCount"];
            string StartDate = Request.QueryString["StartDate"];
            string EndDate = Request.QueryString["EndDate"];
            string SumPrice = Request.QueryString["EndDate"];
            string CusName = Request.QueryString["CusName"];
            string Gender = Request.QueryString["Gender"];
            string Conact = Request.QueryString["Conact"];
            string Remark = Request.QueryString["Remark"];
            

           

        }
    }
}