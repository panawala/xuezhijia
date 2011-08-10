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
                car.CarID = Convert.ToInt16(table.Rows[i]["CarID"].ToString());
                car.Comment = table.Rows[i]["Comment"].ToString();
                car.SeatsCounts = Convert.ToInt16(table.Rows[i]["SeatsCounts"].ToString());
                car.Price = Convert.ToDouble(table.Rows[i]["Price"].ToString());
                car.HirePrice = Convert.ToDouble(table.Rows[i]["HirePrice"].ToString());
                car.AdditionalPerKM = Convert.ToDouble(table.Rows[i]["AdditionalPerKM"].ToString());
                car.AdditionalPerHour = Convert.ToDouble(table.Rows[i]["AdditionalPerHour"].ToString());
                car.Comment = table.Rows[i]["Comment"].ToString();
                list.Add(car);
            }
            return list;
        }

        public void addARecord(Car.CarRow row)
        {
            Insert(row.Type, row.SeatsCounts, row.Price, row.HirePrice, row.AdditionalPerKM, row.AdditionalPerHour, row.Comment, row.PID);
        }
    }
}
