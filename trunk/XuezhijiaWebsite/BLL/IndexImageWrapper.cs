using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.IndexImageTableAdapters;
using BLL;
using DAL;
using System.Data;

namespace BLL
{
    public class IndexImageWrapper : IndexImageTableAdapter
    {
        public DataTable getall()
        {
            return GetData();
        }

        public List<INDEXIMAGE> getAllFormatedResult()
        {
            return _transfer(getall());
        }

        private List<INDEXIMAGE> _transfer(DataTable table)
        {
            List<INDEXIMAGE> list = new List<INDEXIMAGE>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                INDEXIMAGE indeximage = new INDEXIMAGE();
                indeximage.ID = Convert.ToInt32(table.Rows[i]["ID"].ToString());
                indeximage.ImageHref = table.Rows[i]["ImageHref"].ToString();
                indeximage.ImageSrc = table.Rows[i]["ImageSrc"].ToString();
                indeximage.ImageTitle = table.Rows[i]["ImageTitle"].ToString();
                indeximage.ImageAlt = table.Rows[i]["ImageAlt"].ToString();
                list.Add(indeximage);
            }
            return list;
        }

        public void addARecord(IndexImage.IndexImageRow row)
        {
            Insert(row.ImageHref, row.ImageSrc, row.ImageTitle, row.ImageAlt);
        }

        public void addAClassRecord(INDEXIMAGE row)
        {
            Insert(row.ImageHref, row.ImageSrc, row.ImageTitle, row.ImageAlt);
        }

        public void deleteARecordByID(int id)
        {
            string sql = "delete from IndexImage where ID = " + id.ToString();
            CommenHelper helper = CommenHelper.GetInstance();
            helper.initOle();
            helper.delete(sql);
        }

        public INDEXIMAGE getResultByID(int id)
        {
            string sql = "select * from IndexImage where ID = " + id.ToString();
            DataTable table = new DataTable();
            CommenHelper helper = CommenHelper.GetInstance();
            helper.initOle();
            table = helper.getResultBySql(sql);
            return _transfer(table).First();
        }

        public void updateARecord(INDEXIMAGE indeximage)
        {
            IndexImage.IndexImageDataTable table = new IndexImage.IndexImageDataTable();
            table = GetData();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (Convert.ToInt32(table.Rows[i]["ID"].ToString()) == indeximage.ID)
                {
                    table.Rows[i]["ImageHref"] = indeximage.ImageHref;
                    table.Rows[i]["ImageSrc"] = indeximage.ImageSrc;
                    table.Rows[i]["ImageTitle"] = indeximage.ImageTitle;
                    table.Rows[i]["ImageAlt"] = indeximage.ImageAlt;
                    break;
                }
            }
            Update(table);
        }
    }
}
