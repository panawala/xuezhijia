using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.ShopTableAdapters;
using System.Data;
using DAL;
namespace BLL
{
    public class ShopWrapper : ShopTableAdapter
    {
        public void addARecord(Shop.ShopRow row)
        {
            Insert(row.ShopName, row.ShopContactWay, row.ShopAddress, row.ShopScore, row.ShopDistrictId, row.ShopClickedCount, row.PID,row.Comment);
        }

        public DataTable getAll()
        {
            return GetData();
        }

        public void addAClassRecord(SHOP row)
        {
            Insert(row.ShopName, row.ShopContactWay, row.ShopAddress, row.ShopScore, row.ShopDistrictId, row.ShopClickedCount, row.PID,row.Comment);
        }

        public List<SHOP> getAllFormatedResult()
        {
            return _transfer(getAll());

        }

        private List<SHOP> _transfer(DataTable table)
        {
            List<SHOP> list = new List<SHOP>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                SHOP shop = new SHOP();
                shop.ShopId = Convert.ToInt32(table.Rows[i]["ShopId"].ToString());
                shop.ShopName = table.Rows[i]["ShopName"].ToString();
                shop.ShopContactWay = table.Rows[i]["ShopContactWay"].ToString();
                shop.ShopAddress = table.Rows[i]["ShopAddress"].ToString();
                shop.ShopScore = Convert.ToDouble(table.Rows[i]["ShopScore"].ToString());
                shop.ShopDistrictId = table.Rows[i]["ShopDistrictId"].ToString();
                shop.ShopClickedCount = Convert.ToInt32(table.Rows[i]["ShopClickedCount"].ToString());
                shop.Comment = table.Rows[i]["Comment"].ToString();
                shop.PID = Convert.ToInt32(table.Rows[i]["PID"].ToString());
                list.Add(shop);
            }
            return list;
        }

        public void deleteARecordByID(int id)
        {
            string sql = "delete from Shop where ShopID = " + id.ToString();
            CommenHelper helper = CommenHelper.GetInstance();
            helper.initOle();
            helper.delete(sql);
        }

        public SHOP getResultByID(int id)
        {
            string sql = "select * from Shop where ShopID = " + id.ToString();
            DataTable table = new DataTable();
            CommenHelper helper = CommenHelper.GetInstance();
            helper.initOle();
            table = helper.getResultBySql(sql);
            return _transfer(table).First();
        }

        public void updateARecord(SHOP shop)
        {
            string sql = "update Shop set ShopName = '" + shop.ShopName + "', ShopContactWay = '" + shop.ShopContactWay + "', ShopAddress = '" +
                         shop.ShopAddress + "', ShopScore = " +  shop.ShopScore.ToString() + ", ShopDistrictId = '" + shop.ShopDistrictId + "', ShopClickedCount = " + shop.ShopClickedCount.ToString() +
                         ", Comment = '" + shop.Comment + "', PID = " + shop.PID.ToString() + " where ShopId = " + shop.ShopId.ToString();
            CommenHelper.GetInstance().update(sql);
        }
    }
}
