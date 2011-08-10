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
        public string Type;
        public int SeatsCounts;
        public double Price;
        public double HirePrice;
        public double AdditionalPerKM;
        public double AdditionalPerHour;
        public string Comment;
    }

    public class COMMODITY
    {
        public int ComID;
        public string ComNae;
        public string Type;
        public float Price;
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
        public string ImgURL;
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
        public DateTime DateTime;
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
}
