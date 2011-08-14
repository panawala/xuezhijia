using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.SecondHandMarketTableAdapters;
using System.Data;
using DAL;

namespace BLL
{
    public class SecondHMWrapper : SecondHandMarketTableAdapter
    {
        public DataTable getAll()
        {
            return GetData();
        }

        public void deleteARecordByID(int id)
        {
            string sql = "delete from SecondHandMarket where SID = " + id.ToString();
            CommenHelper helper = CommenHelper.GetInstance();
            helper.initOle();
            helper.delete(sql);
        }


        public SECONDHANDMARKET getResultByID(int id)
        {
            string sql = "select * from SecondHandMarket where SID = " + id.ToString();
            DataTable table = new DataTable();
            CommenHelper helper = CommenHelper.GetInstance();
            helper.initOle();
            table = helper.getResultBySql(sql);
            return _transfer(table).First();
        }

        public DataTable getAllType()
        {
            string sql = "select Type from SecondHandMarket";
            return CommenHelper.GetInstance().getResultBySql(sql);
        }
        public List<SECONDHANDMARKET> getAllFormatedResult()
        {
            return _transfer(getAll());
        }

        private  List<SECONDHANDMARKET> _transfer(DataTable table)
        {
            List<SECONDHANDMARKET> list = new List<SECONDHANDMARKET>();
            for (int i = 0; i < table.Rows.Count; i++)
            { 
                SECONDHANDMARKET seconhandmarket = new SECONDHANDMARKET();
                seconhandmarket.SID = Convert.ToInt32(table.Rows[i]["SID"].ToString());
                seconhandmarket.Tipical = table.Rows[i]["Tipical"].ToString();
                seconhandmarket.Type = table.Rows[i]["Type"].ToString();
                seconhandmarket.Comment = table.Rows[i]["Comment"].ToString();
                seconhandmarket.LookCount = Convert.ToInt32(table.Rows[i]["LookCount"].ToString());
                seconhandmarket.Price = Convert.ToDouble(table.Rows[i]["Price"].ToString());
                seconhandmarket.PublishDate = table.Rows[i]["PublishDate"].ToString();
                seconhandmarket.Brand = table.Rows[i]["Brand"].ToString();
                seconhandmarket.Location = table.Rows[i]["Location"].ToString();
                seconhandmarket.ContactInformation = table.Rows[i]["ContactInformation"].ToString();
                seconhandmarket.HasImage = Convert.ToBoolean(table.Rows[i]["HasImage"].ToString());
                string PhotoList = table.Rows[i]["PhotoList"].ToString();
                List<int> plist = new List<int>();
                string[] sArray = PhotoList.Split(new char[1] { ',' });
                foreach (string id in sArray)
                {
                    if (id.Length > 0)
                    {
                        plist.Add(Convert.ToInt32(id.ToString()));
                    }
                }
                seconhandmarket.PIDList = plist;
                list.Add(seconhandmarket);
            }
            return list;
        }

        public SECONDHANDMARKET getRecordByID(int id)
        {
            SECONDHANDMARKET secondhandmarket = new SECONDHANDMARKET();
            CommenHelper helper = CommenHelper.GetInstance();
            DataTable table = new DataTable();
            string sql = "select * from SecondHandMarket where SID = " + id.ToString();
            table = helper.getResultBySql(sql);
            if (table.Rows.Count > 0)
            {
                secondhandmarket = _transfer(table).First();
            }
            return secondhandmarket;       
        }

        public void addARecord(SecondHandMarket.SecondHandMarketRow row)
        {
            Insert(row.Tipical, row.Type, row.Comment, row.LookCount, row.Price, row.PublishDate, row.Brand, row.Location, row.ContactInformation, row.HasImage, row.PhotoList);
        }

        public void addAClassRecord(SECONDHANDMARKET row)
        {
            string idLit = "";
            for (int i = 0; i < row.PIDList.Count; i++)
            {
                idLit = idLit + (row.PIDList[i]).ToString() + ",";
            }
            Insert(row.Tipical, row.Type, row.Comment, row.LookCount, row.Price, Convert.ToDateTime(row.PublishDate), row.Brand, row.Location, row.ContactInformation, row.HasImage, idLit);
        }

        public void addAClick(int id)
        {
            string sql = "update SecondHandMarket set LookCount = LookCount + 1 where SID =  " + id.ToString();
            CommenHelper.GetInstance().update(sql);
        }

        public void updateARecord(SECONDHANDMARKET secondhandmarket)
        {
            string idLit = "";
            for (int i = 0; i < secondhandmarket.PIDList.Count; i++)
            {
                idLit = idLit + (secondhandmarket.PIDList[i]).ToString() + ",";
            }
            SecondHandMarket.SecondHandMarketDataTable table = new SecondHandMarket.SecondHandMarketDataTable();
            table = GetData();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (Convert.ToInt32(table.Rows[i]["SID"].ToString()) == secondhandmarket.SID)
                {
                    table.Rows[i]["Tipical"] = secondhandmarket.Tipical;
                    table.Rows[i]["Type"] = secondhandmarket.Type;
                    table.Rows[i]["Comment"] = secondhandmarket.Comment;
                    table.Rows[i]["LookCount"] = secondhandmarket.LookCount;
                    table.Rows[i]["Price"] = secondhandmarket.Price;
                    table.Rows[i]["Brand"] = secondhandmarket.Brand;
                    table.Rows[i]["Location"] = secondhandmarket.Location;
                    table.Rows[i]["ContactInformation"] = secondhandmarket.ContactInformation;
                    table.Rows[i]["HasImage"] = secondhandmarket.HasImage;
                    table.Rows[i]["Location"] = secondhandmarket.Location;
                    table.Rows[i]["PhotoList"] = idLit;
                    break;
                }
            }
            Update(table);
        }
    }
}
