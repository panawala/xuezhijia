using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.CommodityTableAdapters;
using System.Data;
using DAL;
using BLL;

namespace BLL
{
    public class CommodityWrapper : CommodityTableAdapter
    {
        public DataTable getall()
        {
            return GetData();
        }

        public List<COMMODITY> getAllFormatedResult()
        {
            return _transfer(getall());

        }

        private List<COMMODITY> _transfer(DataTable table)
        {
            List<COMMODITY> list = new List<COMMODITY>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                COMMODITY commodity = new COMMODITY();
                commodity.ComID = Convert.ToInt32(table.Rows[i]["ComID"].ToString());
                commodity.ComName = table.Rows[i]["ComName"].ToString();
                commodity.Type = table.Rows[i]["Type"].ToString();
                commodity.Price = Convert.ToDouble(table.Rows[i]["Price"].ToString());
                commodity.Detail = table.Rows[i]["Detail"].ToString();
                commodity.Comment = table.Rows[i]["Comment"].ToString();
                commodity.PhotoID = Convert.ToInt32(table.Rows[i]["PhotoID"].ToString());
                list.Add(commodity);
            }
            return list;
        }

        public void addARecord(Commodity.CommodityRow row)
        {
            Insert(row.ComName, row.Type, row.Price, row.Detail, row.Comment, row.PhotoID);
        }

        public void addAClassRecord(COMMODITY row)
        {
            Insert(row.ComName, row.Type, row.Price, row.Detail, row.Comment, row.PhotoID);
        }

        public void deleteARecordByID(int id)
        {
            string sql = "delete from Commodity where ComID = " + id.ToString();
            CommenHelper helper = CommenHelper.GetInstance();
            helper.initOle();
            helper.delete(sql);
        }

        public COMMODITY getResultByID(int id)
        {
            string sql = "select * from Commodity where ComID = " + id.ToString();
            DataTable table = new DataTable();
            CommenHelper helper = CommenHelper.GetInstance();
            helper.initOle();
            table = helper.getResultBySql(sql);
            return _transfer(table).First();
        }

        public void updateARecord(COMMODITY commodity)
        {
            Commodity.CommodityDataTable table = new Commodity.CommodityDataTable();
            table = GetData();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (Convert.ToInt32(table.Rows[i]["ComID"].ToString()) == commodity.ComID)
                {
                    table.Rows[i]["ComName"] = commodity.ComName;
                    table.Rows[i]["Type"] = commodity.Type;
                    table.Rows[i]["Price"] = commodity.Price;
                    table.Rows[i]["Detail"] = commodity.Detail;
                    table.Rows[i]["Comment"] = commodity.Comment;
                    table.Rows[i]["PhotoID"] = commodity.PhotoID;
                    break;
                }
            }
            Update(table);
        }
    }
}
