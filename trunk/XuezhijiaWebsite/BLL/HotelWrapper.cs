using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.HotelTableAdapters;
using DAL;
using System.Data;

namespace BLL
{
    public class HotelWrapper : HotelTableAdapter
    {
        
        public void addARecord(Hotel.HotelRow row)
        {
            Insert(row.HotelName, row.Location, row.ContactWay, row.Type, row.Price, row.PIDList, row.Comment, row.PID,row.OrderId);
        }

        public DataTable getAll()
        {
            return GetDataByOrder();
        }

        public List<HOTEL> getAllFormatedResult()
        {
            return _transfer(getAll());

        }

        private List<string>_getStringList(string str)
        {
            List<string> list = new List<string>();
            string[] lt = str.Split('、');
            for (int i = 0; i < lt.Length; i++)
            {
                if (lt[i].Length > 0)
                {
                    list.Add(lt[i]);
                }
            }
            return list;
        }

        public DataTable getDicByID(int id)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            HOTEL hotel = new HOTEL();
            hotel = getResultByID(id);
            //for (int i = 0; i < hotel.Type.Count; i++)
            //{
            //    dict.Add(hotel.Price[i], hotel.Type[i]);
            //}

            DataTable dataTable = new DataTable();
            dataTable.TableName = "dataTable";
            DataColumn strPhoneNum = dataTable.Columns.Add("Price", typeof(string));
            DataColumn dtCallDate = dataTable.Columns.Add("Type", typeof(string));
            DataRow row;
            // Create new DataRow objects and add to DataTable.  
            for (int i = 0; i < hotel.Type.Count; i++)
            {
                row = dataTable.NewRow();
                row["Price"] = hotel.Price[i];
                row["Type"] = hotel.Type[i];
                dataTable.Rows.Add(row);
            }


            return dataTable; 
        }

        private List<HOTEL> _transfer(DataTable table)
        {
            List<HOTEL> list = new List<HOTEL>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                HOTEL hotel = new HOTEL();
                hotel.HotelID = Convert.ToInt32(table.Rows[i]["HotelID"].ToString());
                hotel.HotelName = table.Rows[i]["HotelName"].ToString();
                hotel.ContactWay = table.Rows[i]["ContactWay"].ToString();
                hotel.Type = _getStringList(table.Rows[i]["Type"].ToString());
                hotel.Location = table.Rows[i]["Location"].ToString();
                hotel.Price = _getStringList(table.Rows[i]["Price"].ToString());
                hotel.Comment = table.Rows[i]["Comment"].ToString();
                hotel.PID = Convert.ToInt32(table.Rows[i]["PID"].ToString());
                hotel.OrderID = Convert.ToInt32(table.Rows[i]["OrderId"].ToString());
                string pidlist = table.Rows[i]["PIDList"].ToString();
                string[] sArray = pidlist.Split(',');
                List<int> photolist = new List<int>();
                for (int j = 0; j < sArray.Length; j++)
                {
                    if (sArray[j].ToString().Length > 0)
                    {
                        photolist.Add(Convert.ToInt32(sArray[j].ToString()));
                    }
                }
                hotel.PIDList = photolist;
                list.Add(hotel);
            }
            return list;
        }
       
        public void addAClassRecord(HOTEL row)
        {
            string idLit = "";
            for (int i = 0; i < row.PIDList.Count; i++)
            {
                idLit = idLit + (row.PIDList[i]).ToString() + "、";
            }

            string typelist = "";
            for (int i = 0; i < row.Type.Count; i++)
            {
                typelist = typelist + (row.Type[i]).ToString() + "、";
            }

            string pricelist = "";
            for (int i = 0; i < row.Price.Count; i++)
            {
                pricelist = pricelist + (row.Price[i]).ToString() + "、";
            }

            Insert(row.HotelName, row.Location, row.ContactWay, typelist, pricelist, idLit, row.Comment, row.PID, row.OrderID);
        }

        public double getPriceByTypeAndID(int id, string type)
        {
            double price = 0.0;
            HOTEL hotel = getResultByID(id);
            for (int i = 0; i < hotel.Type.Count; i++)
            {
                if (type == hotel.Type[i])
                {
                    price = Convert.ToDouble(hotel.Price[i]);
                    break;
                }
            }
            return price; 
        }

        public void deleteARecordByID(int id)
        {
            string sql = "delete from Hotel where HotelID = " + id.ToString();
            CommenHelper helper = CommenHelper.GetInstance();
            helper.initOle();
            helper.delete(sql);
        }

        public HOTEL getResultByID(int id)
        {
            string sql = "select * from Hotel where HotelID = " + id.ToString();
            DataTable table = new DataTable();
            CommenHelper helper = CommenHelper.GetInstance();
            helper.initOle();
            table = helper.getResultBySql(sql);
            return _transfer(table).First();
        }

        public void updateARecord(HOTEL hotel)
        {
            Hotel.HotelDataTable table = new Hotel.HotelDataTable();
            table = GetData();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (Convert.ToInt32(table.Rows[i]["HotelID"].ToString()) == hotel.HotelID)
                {
                    table.Rows[i]["HotelName"] = hotel.HotelName;
                    table.Rows[i]["ContactWay"] = hotel.ContactWay;
                    table.Rows[i]["Type"] = hotel.Type;
                    table.Rows[i]["Location"] = hotel.Location;
                    table.Rows[i]["Price"] = hotel.Price;
                    table.Rows[i]["PID"] = hotel.PID;
                    table.Rows[i]["Comment"] = hotel.Comment;
                    string photolist = "";
                    foreach (int item in hotel.PIDList)
                    {
                        photolist = photolist + item.ToString() + ",";
                    }
                    table.Rows[i]["PIDList"] =photolist;
                    break;
                }
            }
            Update(table);
        }
    }
}
