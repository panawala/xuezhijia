using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL.CarTableAdapters;
using DAL;

namespace BLL
{
    public class CarWrapper : CarTableAdapter
    {
        public DataTable getall()
        {
            return GetData();
        }

        public List<CAR> getAllFormatedResult()
        {
            return _transfer(getall());
 
        }

        private  List<CAR> _transfer(DataTable table)
        {
            List<CAR> list = new List<CAR>();
            for (int i = 0; i < table.Rows.Count; i++)
            { 
                CAR car = new CAR();
                car.CarID = Convert.ToInt32(table.Rows[i]["CarID"].ToString());
                car.Comment = table.Rows[i]["Comment"].ToString();
                car.SeatsCounts = Convert.ToInt16(table.Rows[i]["SeatsCounts"].ToString());
                car.Price = Convert.ToDouble(table.Rows[i]["Price"].ToString());
                car.HirePrice = Convert.ToDouble(table.Rows[i]["HirePrice"].ToString());
                car.AdditionalPerKM = Convert.ToDouble(table.Rows[i]["AdditionalPerKM"].ToString());
                car.AdditionalPerHour = Convert.ToDouble(table.Rows[i]["AdditionalPerHour"].ToString());
                car.Comment = table.Rows[i]["Comment"].ToString();
                car.Type = table.Rows[i]["Type"].ToString();
                car.PID = Convert.ToInt32(table.Rows[i]["PID"].ToString());
                list.Add(car);
            }
            return list;
        }

        public void addARecord(Car.CarRow row)
        {
            Insert(row.Type, row.SeatsCounts, row.Price, row.HirePrice, row.AdditionalPerKM, row.AdditionalPerHour, row.Comment, row.PID);
        }

        public void deleteARecordByID(int id)
        {
            string sql = "delete from Car where CarID = " + id.ToString();
            CommenHelper helper = CommenHelper.GetInstance();
            helper.initOle();
            helper.delete(sql);
        }

        public CAR getResultByID(int id)
        {
            string sql = "select * from Car where CarID = " + id.ToString();
            DataTable table = new DataTable();
            CommenHelper helper = CommenHelper.GetInstance();
            helper.initOle();
            table = helper.getResultBySql(sql);
            return _transfer(table).First();
        }

        public void updateARecord(CAR car)
        {
            Car.CarDataTable table = new Car.CarDataTable();
            table = GetData();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (Convert.ToInt32(table.Rows[i]["CarID"].ToString()) == car.CarID)
                {
                    table.Rows[i]["Type"] = car.Type;
                    table.Rows[i]["SeatsCounts"] = car.SeatsCounts;
                    table.Rows[i]["Price"] = car.Price;
                    table.Rows[i]["HirePrice"] = car.HirePrice;
                    table.Rows[i]["AdditionalPerKM"] = car.AdditionalPerKM;
                    table.Rows[i]["AdditionalPerHour"] = car.AdditionalPerHour;
                    table.Rows[i]["Comment"] = car.Comment;
                    table.Rows[i]["PID"] = car.PID;
                    break;
                }
            }
            Update(table);
        }
    }
}
