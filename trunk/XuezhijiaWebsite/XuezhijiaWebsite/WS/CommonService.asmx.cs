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
        public List<CAR> getAllCourseList()
        {
            CarWrapper wrapper = new CarWrapper();
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
    }
}
