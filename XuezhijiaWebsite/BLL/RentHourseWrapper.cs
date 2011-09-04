using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.RentHourseTableAdapters;
using DAL;
using BLL;
using System.Data;

namespace BLL
{
    public class RentHourseWrapper : RentHourseTableAdapter
    {
        public DataTable getall()
        {
            return GetData();
        }

        public List<RENTHOURSE> getAllFormatedResult()
        {
            return _transfer(getall());

        }

        private List<RENTHOURSE> _transfer(DataTable table)
        {
            List<RENTHOURSE> list = new List<RENTHOURSE>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                RENTHOURSE renthourse = new RENTHOURSE();
                renthourse.HourseID = Convert.ToInt32(table.Rows[i]["HourseID"].ToString());
                renthourse.Price = Convert.ToDouble(table.Rows[i]["Price"].ToString());
                renthourse.RentType = table.Rows[i]["RentType"].ToString();
                renthourse.HourseType = table.Rows[i]["HourseType"].ToString();
                renthourse.HourseName = table.Rows[i]["HourseName"].ToString();
                renthourse.Area = Convert.ToDouble(table.Rows[i]["Area"].ToString());
                renthourse.Configuration = table.Rows[i]["Configuration"].ToString();
                renthourse.ClickCount = Convert.ToInt16(table.Rows[i]["ClickCount"].ToString());
                renthourse.DistributeTime = table.Rows[i]["DistributeTime"].ToString();
                list.Add(renthourse);
            }
            return list;
        }

        public void addARecord(RentHourse.RentHourseRow row)
        {
            Insert(row.Price, row.RentType, row.HourseType, row.HourseName, row.Area, row.Configuration, row.ClickCount, row.DistributeTime);
        }

        public void addAClassRecord(RENTHOURSE row)
        {
            Insert(row.Price, row.RentType, row.HourseType, row.HourseName, row.Area, row.Configuration, row.ClickCount, row.DistributeTime);
        }

        public void deleteARecordByID(int id)
        {
            string sql = "delete from RentHourse where HourseID = " + id.ToString();
            CommenHelper helper = CommenHelper.GetInstance();
            helper.initOle();
            helper.delete(sql);
        }

        public RENTHOURSE getRentHouseByID(int id)
        {
            string sql = "select * from RentHourse where HourseID = " + id.ToString();
            DataTable table = new DataTable();
            CommenHelper helper = CommenHelper.GetInstance();
            helper.initOle();
            table = helper.getResultBySql(sql);
            return _transfer(table).First();
        }


        public void addAClick(int id)
        {
            string sql = "update RentHourse set ClickCount = ClickCount + 1 where HourseID =  " + id.ToString();
            CommenHelper.GetInstance().update(sql);
        }

        public void updateARecord(RENTHOURSE renthourse)
        {
            RentHourse.RentHourseDataTable table = new RentHourse.RentHourseDataTable();
            table = GetData();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (Convert.ToInt32(table.Rows[i]["HourseID"].ToString()) == renthourse.HourseID)
                {
                    table.Rows[i]["Price"] = renthourse.Price;
                    table.Rows[i]["RentType"] = renthourse.RentType;
                    table.Rows[i]["HourseType"] = renthourse.HourseType;
                    table.Rows[i]["HourseName"] = renthourse.HourseName;
                    table.Rows[i]["Area"] = renthourse.Area;
                    table.Rows[i]["Configuration"] = renthourse.Configuration;
                    table.Rows[i]["ClickCount"] = renthourse.ClickCount;
                    table.Rows[i]["DistributeTime"] = renthourse.DistributeTime;
                    break;
                }
            }
            Update(table);
        }
    }
}
