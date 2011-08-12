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
                seconhandmarket.PublishDate = Convert.ToDateTime(table.Rows[i]["PublishDate"].ToString());
                seconhandmarket.Brand = table.Rows[i]["Brand"].ToString();
                seconhandmarket.Location = table.Rows[i]["Location"].ToString();
                seconhandmarket.ContactInformation = table.Rows[i]["ContactInformation"].ToString();
                seconhandmarket.HasImage = Convert.ToBoolean(table.Rows[i]["HasImage"].ToString());
                string PhotoList = table.Rows[i]["PhotoList"].ToString();
                List<int> plist = new List<int>();
                string[] sArray = PhotoList.Split(new char[1] { ',' });
                foreach (string id in sArray)
                {
                    plist.Add(Convert.ToInt32(id.ToString()));
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
    }
}
