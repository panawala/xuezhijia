using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.ArticalTableAdapters;
using DAL;
using System.Data;

namespace BLL
{
   public class ArticalWrapper : ArticleTableAdapter
    {

       public DataTable getAll()
       {
           return GetData();
       }

       public void addARecord(Artical.ArticleRow row)
       {
           Insert(row.ArticleID, row.AritcleArea, row.ArticleContent); 
       }

       public void deleteARecord(int id)
       {
           CommenHelper helper = CommenHelper.GetInstance();
           string sql = "delete from Article where ArticleID = " + id.ToString();
           helper.initOle();
           helper.delete(sql);
       }

       private bool Judge(int id)
       {
           string sql = "select ArticleID from Article where ArticleID = " + id.ToString();
           DataTable table = new DataTable();
           CommenHelper helper = CommenHelper.GetInstance();
           table = helper.getResultBySql(sql);
           return table.Rows.Count > 0 ? true : false;
       }

       public void updateARecord(Artical.ArticleRow row)
       {
           if (!Judge(row.ArticleID))
           {
               addARecord(row);
           }
           Artical.ArticleDataTable table = new  Artical.ArticleDataTable();
           table = GetData();
           for (int i = 0; i < table.Rows.Count; i++)
           {
               if (row.ArticleID == Convert.ToInt32(table.Rows[i]["ArticleID"]))
               {
                   table.Rows[i]["ArticleContent"] = row.ArticleContent;
                   table.Rows[i]["AritcleArea"] = row.AritcleArea;
                   break;
               }
           }
           Update(table);
       }

       public ARTICLE getRecordByID(int id)
       {

           string sql = "select * from Article where ArticleID = " + id.ToString();
           DataTable table = new DataTable();
           CommenHelper helper = CommenHelper.GetInstance();
           table = helper.getResultBySql(sql);
           return _transfer(table).First();
       }

       private List<ARTICLE> _transfer(DataTable table)
       { 
            List<ARTICLE> list = new List<ARTICLE>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                ARTICLE article = new ARTICLE();
                article.ArticleID = Convert.ToInt32(table.Rows[i]["ArticleID"].ToString());
                article.ArticleContent = table.Rows[i]["ArticleContent"].ToString();
                article.ArticleArea = table.Rows[i]["ArticleArea"].ToString();
                list.Add(article);
            }
            return list;
       }
    }
}
