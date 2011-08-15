using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using BLL;
using DAL;

namespace XuezhijiaWebsite.WS
{
    /// <summary>
    /// Summary description for CommonService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class CommonService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<CAR> getAllCarList()
        {
            CarWrapper wrapper = new CarWrapper();
            return wrapper.getAllFormatedResult();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<COURSE> getAllCourseList()
        {
            CourseWrapper wrapper = new CourseWrapper();
            return wrapper.getAllFormatedResult();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<SECONDHANDMARKET> getAllSecondHandMarketList()
        {
            SecondHMWrapper wrapper = new SecondHMWrapper();
            return wrapper.getAllFormatedResult();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public SECONDHANDMARKET getSecondHandMarketByID(int id)
        {
            SecondHMWrapper wrapper = new SecondHMWrapper();
            return wrapper.getRecordByID(id);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public ARTICLE getArticleByID(int id)
        {
            ArticalWrapper wrapper = new  ArticalWrapper();
            return wrapper.getRecordByID(id);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<HOTEL> getALLFormatedHotels()
        {
            HotelWrapper wrapper = new HotelWrapper();
            return wrapper.getAllFormatedResult();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<SHOP> getALLFormatedShop()
        {
            ShopWrapper wrapper = new ShopWrapper();
            return wrapper.getAllFormatedResult();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<COMMODITY> getALLFormatedCommodity()
        {
            CommodityWrapper wrapper = new CommodityWrapper();
            return wrapper.getAllFormatedResult();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<TICKET> getALLFormatedTicket()
        {
            TicketWrapper wrapper = new TicketWrapper();
            return wrapper.getAllFormatedResult();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<RENTHOURSE> getALLFormatedHourse()
        {
            RentHourseWrapper wrapper = new RentHourseWrapper();
            return wrapper.getAllFormatedResult();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public RENTHOURSE getResultById(int id)
        {
            RentHourseWrapper wrapper = new RentHourseWrapper();
            return wrapper.getResultByID(id);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public HOTEL getFormatedHotelById(int id)
        {
            return (new HotelWrapper()).getResultByID(id);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<STUDENT> getFormatedStudent()
        {
            return (new StudentWrapper()).getAllFormatedResult();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<DISH> getFormatedDishByOwnerId(int id)
        {
            return (new DishWrapper()).getFormatedResultByOwnerID(id);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<NEWS> getNewsByType(int type)
        {
            return (new NewsWrapper()).getAllFormatedResultByType(type);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<NEWS> getTopSixNewsByType(int type)
        {
            return (new NewsWrapper()).getTopSixFormatedResultByType(type);

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public NEWS getResultByID(int id)
        {
            return (new NewsWrapper()).getResultByID(id);
        }
    }
}
