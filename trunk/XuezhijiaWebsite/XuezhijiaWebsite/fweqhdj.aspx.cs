using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XuezhijiaWebsite
{
    public partial class fweqhdj : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void PrintClick(object sender, EventArgs e)
        {
            Response.Redirect("PrintManage.aspx");
        }

        protected void CarClick(object sender, EventArgs e)
        {
            Response.Redirect("CarManage.aspx");
        }

        protected void HotelClick(object sender, EventArgs e)
        {
            Response.Redirect("HotelManage.aspx");
        }

        protected void TakeOutClick(object sender, EventArgs e)
        {
            Response.Redirect("TakeOutManage.aspx");
        }

        protected void GREClick(object sender, EventArgs e)
        {
            Response.Redirect("GREManage.aspx");
        }

        protected void StudentMarketClick(object sender, EventArgs e)
        {
            Response.Redirect("StudentMarketManage.aspx");
        }

        protected void TicketClick(object sender, EventArgs e)
        {
            Response.Redirect("TicketManage.aspx");
        }

        protected void TutorClick(object sender, EventArgs e)
        {
            Response.Redirect("TutorManage.aspx");
        }

        protected void HourseClick(object sender, EventArgs e)
        {
            Response.Redirect("HourseManage.aspx");
        }

        protected void SecondHandMarktClick(object sender, EventArgs e)
        {
            Response.Redirect("SecondHandMarketManage.aspx");
        }

        protected void RightEditClick(object sender, EventArgs e)
        {
            Response.Redirect("EditAds.aspx");
        }

        protected void PicturesClick(object sender, EventArgs e)
        {
            Response.Redirect("/Index/ImageManage.aspx");
        }

        protected void UsersClick(object sender, EventArgs e)
        {
            Response.Redirect("UserManage.aspx");
        }

        protected void NewsClick(object sender, EventArgs e)
        {
            Response.Redirect("/News/NewsManage.aspx");
        }

        protected void NewsAddClick(object sender, EventArgs e)
        {
            Response.Redirect("/News/NewsAdd.aspx");
        }
    }
}