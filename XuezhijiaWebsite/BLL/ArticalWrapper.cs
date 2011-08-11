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

       public void updateARecord(Artical.ArticleRow row)
       {
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
    }
}
