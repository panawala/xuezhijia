using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL.HotelOrderTableAdapters;
using DAL;

namespace BLL
{
    public class HotelOrderWrapper : HotelOrderTableAdapter
    {
        public DataTable getall()
        {
            return GetData();
        }

        public List<HOTELORDER> getAllFormatedResult()
        {
            return _transfer(getall());

        }

        private List<HOTELORDER> _transfer(DataTable table)
        {
            List<HOTELORDER> list = new List<HOTELORDER>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                HOTELORDER hotelorder = new HOTELORDER();

                hotelorder.OrderID = Convert.ToInt32(table.Rows[i]["OrderID"].ToString());
                hotelorder.CustomName = table.Rows[i]["CustomName"].ToString();
                hotelorder.ConnectionMethods = table.Rows[i]["ConnectionMethods"].ToString();
                hotelorder.Type = table.Rows[i]["Type"].ToString();
                hotelorder.EnterDateTime = Convert.ToDateTime(table.Rows[i]["EnterDateTime"].ToString());
                hotelorder.LeaveDateTime = Convert.ToDateTime(table.Rows[i]["LeaveDateTime"].ToString());
                hotelorder.Comment = table.Rows[i]["Comment"].ToString();
                hotelorder.Gender = table.Rows[i]["Gender"].ToString();
                hotelorder.SumPrice = Convert.ToDouble(table.Rows[i]["SumPrice"].ToString());
                hotelorder.RoomCount = Convert.ToInt32(table.Rows[i]["RoomCount"].ToString());
                hotelorder.HotelID = Convert.ToInt32(table.Rows[i]["HotelID"].ToString());

                list.Add(hotelorder);
            }
            return list;
        }

        public void addARecord(HotelOrder.HotelOrderRow row)
        {
            Insert(row.CustomName, row.ConnectionMethods, row.Type, row.EnterDateTime, row.LeaveDateTime , row.Gender, row.RoomCount, row.Comment, row.SumPrice, row.HotelID);
        }

        public void addAClassRecord(HOTELORDER row)
        {
            Insert(row.CustomName, row.ConnectionMethods, row.Type, row.EnterDateTime, row.LeaveDateTime, row.Gender, row.RoomCount, row.Comment, row.SumPrice, row.HotelID);
        }

        public void deleteARecordByID(int id)
        {
            string sql = "delete from HotelOrder where OrderID = " + id.ToString();
            CommenHelper helper = CommenHelper.GetInstance();
            helper.initOle();
            helper.delete(sql);
        }

        public HOTELORDER getResultByID(int id)
        {
            string sql = "select * from HotelOrder where OrderID = " + id.ToString();
            DataTable table = new DataTable();
            CommenHelper helper = CommenHelper.GetInstance();
            helper.initOle();
            table = helper.getResultBySql(sql);
            return _transfer(table).First();
        }
    }
}
