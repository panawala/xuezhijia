using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.DishTableAdapters;
using DAL;
using BLL;
using System.Data;

namespace BLL
{
    public class DishWrapper : DishTableAdapter
    {

        public DataTable getall()
        {
            return GetData();
        }

        public List<DISH> getAllFormatedResult()
        {
            return _transfer(getall());

        }

        private List<DISH> _transfer(DataTable table)
        {
            List<DISH> list = new List<DISH>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DISH dish = new DISH();
                dish.DishId = Convert.ToInt32(table.Rows[i]["DishId"].ToString());
                dish.DishName = table.Rows[i]["DishName"].ToString();
                dish.DishOwnerId = Convert.ToInt32(table.Rows[i]["DishOwnerId"].ToString());
                dish.Price = Convert.ToDouble(table.Rows[i]["Price"].ToString());
                dish.DishUpCount = Convert.ToInt32(table.Rows[i]["DishUpCount"].ToString());
                dish.DishDownCount = Convert.ToInt32(table.Rows[i]["DishDownCount"].ToString());
                dish.DishCatalog = table.Rows[i]["DishCatalog"].ToString();
                dish.DishScore = Convert.ToDouble(table.Rows[i]["DishScore"].ToString());
                list.Add(dish);
            }
            return list;
        }

        public void addARecord(Dish.DishRow row)
        {
            Insert(row.DishName, row.DishOwnerId, row.DishScore, row.DishUpCount, row.DishDownCount, row.DishCatalog, row.Price);
        }

        public void addAClassRecord(DISH row)
        {
            Insert(row.DishName, row.DishOwnerId, row.DishScore, row.DishUpCount, row.DishDownCount, row.DishCatalog, row.Price);
        }

        public void deleteARecordByID(int id)
        {
            string sql = "delete from Dish where DishId = " + id.ToString();
            CommenHelper helper = CommenHelper.GetInstance();
            helper.initOle();
            helper.delete(sql);
        }

        public void donwById(int id)
        {
            CommenHelper.GetInstance().update("update Dish set DishDownCount = DishDownCount + 1 where DishId = " + id.ToString());
        }

        public void upById(int id)
        {
            CommenHelper.GetInstance().update("update Dish set DishUpCount = DishUpCount + 1 where DishId = " + id.ToString());
        }

        public DISH getResultByID(int id)
        {
            string sql = "select * from Dish where DishId = " + id.ToString();
            DataTable table = new DataTable();
            CommenHelper helper = CommenHelper.GetInstance();
            helper.initOle();
            table = helper.getResultBySql(sql);
            return _transfer(table).First();
        }

        public DataTable getResultByOwnerID(int id)
        {
            string sql = "select * from Dish where DishOwnerId = " + id.ToString();
            return CommenHelper.GetInstance().getResultBySql(sql);
        }

        public List<DISH> getFormatedResultsByOwnerID(int id)
        {
            string sql = "select * from Dish where DishOwnerId = " + id.ToString();
            return _transfer(CommenHelper.GetInstance().getResultBySql(sql));
        }

        public void updateARecord(DISH dish)
        {
            Dish.DishDataTable table = new Dish.DishDataTable();
            table = GetData();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (Convert.ToInt32(table.Rows[i]["DishId"].ToString()) == dish.DishId)
                {
                    table.Rows[i]["DishName"] = dish.DishName;
                    table.Rows[i]["DishOwnerId"] = dish.DishOwnerId;
                    table.Rows[i]["Price"] = dish.Price;
                    table.Rows[i]["DishUpCount"] = dish.DishUpCount;
                    table.Rows[i]["DishDownCount"] = dish.DishDownCount;
                    table.Rows[i]["DishCatalog"] = dish.DishCatalog;
                    table.Rows[i]["DishScore"] = dish.DishScore;
                    break;
                }
            }
            Update(table);
        }
    }
}
