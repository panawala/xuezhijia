using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.PhotoTableAdapters;
using DAL;
using System.Data;

namespace BLL
{
   public class PhotoWrapper : PhotoTableAdapter
    {
        public DataTable getAll()
        {
            return GetData();
        }
        public void addARecord(Photo.PhotoRow row)
        {
            Insert(row.PName, row.Data, row.Comment);
        }

        public List<PHOTO> getAllFormatedResult()
        {
            return _transfer(getAll());
        }

        private List<PHOTO> _transfer(DataTable table)
        {
            List<PHOTO> list = new List<PHOTO>();
            for (int i = 0; i < table.Rows.Count; i++)
            { 
                PHOTO photo = new PHOTO();
                photo.PID = Convert.ToInt16(table.Rows[i]["PID"].ToString());
                photo.PName = table.Rows[i]["PName"].ToString();
                photo.Data = (byte[])table.Rows[i]["Data"];
                photo.Comment = table.Rows[i]["Comment"].ToString();
                list.Add(photo);
            }
            return list;
        }

       public byte[] getDataByID(int id)
       {
           CommenHelper helper = CommenHelper.GetInstance();
           string sql = "select Data from Photo where PID = " + id.ToString();
           DataTable table = new DataTable();
           table = helper.getResultBySql(sql);
           return (byte[]) table.Rows[0][0];
       }

       public void deleteARecord(int id)
       {
           string sql = "delete from Photo where PID = " + id.ToString();
           CommenHelper helper = CommenHelper.GetInstance();
           helper.delete(sql);
       }
    }
}
