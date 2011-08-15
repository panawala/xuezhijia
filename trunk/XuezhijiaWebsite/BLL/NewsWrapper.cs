using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;
using DAL.NewsTableAdapters;

namespace BLL
{
    public class NewsWrapper : NewsTableAdapter
    {

        public DataTable getall()
        {
            return GetData();
        }

        public List<NEWS> getAllFormatedResult()
        {
            return _transfer(getall());

        }

        private List<NEWS> _transfer(DataTable table)
        {
            List<NEWS> list = new List<NEWS>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                NEWS news = new NEWS();
                news.NewsID = Convert.ToInt32(table.Rows[i]["NewsID"].ToString());
                news.NewsTitle = table.Rows[i]["NewsTitle"].ToString();
                news.NewsContent = table.Rows[i]["NewsContent"].ToString();
                news.NewsPublishTime = table.Rows[i]["NewsPublishTime"].ToString();
                news.NewsClickCount = Convert.ToInt32(table.Rows[i]["NewsClickCount"].ToString());
                news.NewsType = Convert.ToInt32(table.Rows[i]["NewsType"].ToString());
                list.Add(news);
            }
            return list;
        }

        public void addARecord(News.NewsRow row)
        {
            Insert(row.NewsTitle, row.NewsContent, row.NewsPublishTime, row.NewsClickCount, row.NewsType);
        }

        public void addAClassRecord(NEWS row)
        {
            Insert(row.NewsTitle, row.NewsContent, Convert.ToDateTime(row.NewsPublishTime.ToString()), row.NewsClickCount, row.NewsType);
        }

        public void deleteARecordByID(int id)
        {
            string sql = "delete from News where NewsID = " + id.ToString();
            CommenHelper helper = CommenHelper.GetInstance();
            helper.initOle();
            helper.delete(sql);
        }

        public NEWS getResultByID(int id)
        {
            string sql = "select * from News where NewsID = " + id.ToString();
            DataTable table = new DataTable();
            CommenHelper helper = CommenHelper.GetInstance();
            helper.initOle();
            table = helper.getResultBySql(sql);
            return _transfer(table).First();
        }

        public void updateARecord(NEWS news)
        {
            News.NewsDataTable table = new News.NewsDataTable();
            table = GetData();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (Convert.ToInt32(table.Rows[i]["NewsID"].ToString()) == news.NewsID)
                {
                    table.Rows[i]["NewsTitle"] = news.NewsTitle;
                    table.Rows[i]["NewsContent"] = news.NewsContent;
                    table.Rows[i]["NewsPublishTime"] = news.NewsPublishTime;
                    table.Rows[i]["NewsClickCount"] = news.NewsClickCount;
                    table.Rows[i]["NewsType"] = news.NewsType;
                    break;
                }
            }
            Update(table);
        }

        public List<NEWS> getAllFormatedResultByType(int type)
        {
            return _transfer(CommenHelper.GetInstance().getResultBySql("select * from News where NewsType = " + type.ToString()));
            
        }

        public List<NEWS> getTopSixFormatedResultByType(int type)
        {
            return _transfer(CommenHelper.GetInstance().getResultBySql("select top 6 * from News where NewsType = " + type.ToString()));
        }
    }
}
