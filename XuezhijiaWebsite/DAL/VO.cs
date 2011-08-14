using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.IO;

namespace DAL
{
    public class VO
    {
    }
    public class CAR
    {
        public int CarID;
        public int PID;
        public string Type;
        public int SeatsCounts;
        public double Price;
        public double HirePrice;
        public double AdditionalPerKM;
        public double AdditionalPerHour;
        public string Comment;
    }

    public class HOTEL
    {
        public int HotelID;
        public string HotelName;
        public string Location;
        public string ContactWay;
        public string Type;
        public string Price;
        public List<int> PIDList = new List<int>();
        public string Comment;
        public int PID;
    }

    public class COMMODITY
    {
        public int ComID;
        public string ComName;
        public string Type;
        public double Price;
        public string Detail;
        public string Comment;
        public int PhotoID;
    }

    public class COURSE
    {
        public int CourseID;
        public int TID;
        public string CourseName;
        public int Lessons;
        public string Location;
        public string Time;
        public int MaxNumber;
        public int PID;
        public string Comment;
    }

    public class DISH
    {
        public int DishId;
        public string DishName;
        public int DishOwnerId;
        public float DishScore;
        public int DishUpCount;
        public int DishDownCount;
        public string DishCatalog;
        public int DishClickedCount;
    }

    public class FILERECORDS
    {
        public int RecordID;
        public int UserID;
        public string Size;
        public string FileName;
        public int PageCount;
        public Guid Pseudonym;
        public string DateTime;
        public string state;
        public string Comment;
    }

    public class PHOTO
    {
        public int PID;
        public string PName;
        public byte[] Data;
        public string Comment;
    }

    public class RENTHOURSE
    {
        public int HourseID;
        public double Price;
        public string RentType;
        public string HourseType;
        public string HourseName;
        public double Area;
        public string Configuration;
        public int ClickCount;
        public DateTime DistributeTime;
    }

    public class ROOM
    {
       public  int RoomID;
       public  string Location;
       public  double Price;
       public  string Type;
       public  string DistanceFromTongji;
       public  string LinkURL;
       public  string Comment; 
    }

    public class SECONDHANDMARKET
    {
        public int SID;
        public string Tipical;
        public string Type;
        public string Comment;
        public int LookCount;
        public double Price;
        public string PublishDate;
        public string Brand;
        public string Location;
        public string ContactInformation;
        public bool HasImage;
        public List<int> PIDList;
    }

    public class SHOP
    {
        public int ShopId;
        public string ShopName;
        public string ShopContactWay;
        public string ShopAddress;
        public double ShopScore;
        public string ShopDistrictId;
        public int ShopClickedCount;
        public int PID;
        public string Comment;
    }

    public class STUDENT
    {
        public int SID;
        public string SName;
        public string Address;
        public int Grade;
        public string Requirment;
        public string Comment; 
    }

    public class TEACHER
    {
        public int TID;
        public string ConnectionInformation;
        public string TName;
        public string AdvantageSujects;
        public string Comment; 
    }

    public class TICKET
    {
        public int TicketID;
        public string TicketName;
        public string DurationOfService;
        public double Price;
        public string WayToPay;
        public string LinkURL;
        public int PID;
        public string Comment;
    }

    public class ARTICLE
    {
        public int ArticleID;
        public string ArticleArea;
        public string ArticleContent;
    }
}
