﻿using System;
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
        public string UserExist(string user)
        {
            UserInfoWrapper wrapper = new UserInfoWrapper();
            if (wrapper.IsExists(user))
            {
                return "success";
            }
            return "fail";
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
        public COURSE getCourseById(int id)
        {
            CourseWrapper wrapper = new CourseWrapper();
            return wrapper.getResultByID(id);
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
        public RENTHOURSE getRentHouseById(int id)
        {
            RentHourseWrapper wrapper = new RentHourseWrapper();
            return wrapper.getRentHouseByID(id);
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
            return (new DishWrapper()).getFormatedResultsByOwnerID(id);
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

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void dishDownByID(int id)
        {
            (new DishWrapper()).donwById(id);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void dishUpByID(int id)
        {
            (new DishWrapper()).upById(id);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<PROXY> getProxyByType(int type)
        {
            if (type == 1)
            {
                return (new ProxyWrapper()).GetFormatedResultByType("考研");
            }
            else if (type == 2)
            {
                return (new ProxyWrapper()).GetFormatedResultByType("驾校");
            }
            else 
            {
                return null;
            }

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public PROXY getProxyByID(int id)
        {
            return (new ProxyWrapper()).getResultByID(id);
        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void addMember(MEMBER member)
        {
            (new MemberWrapper()).addAClassRecord(member);
        }



    }
}
