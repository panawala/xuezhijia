using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL.ProxyTableAdapters;
using DAL;

namespace BLL
{
    public class ProxyWrapper : ProxyTableAdapter
    {
        public DataTable getall()
        {
            string sql = "select * from Proxy left join Photo on Proxy.ImageID = Photo.PID";
            CommenHelper helper = CommenHelper.GetInstance();
            helper.initOle();
            return helper.getResultBySql(sql);
        }

        public List<PROXY> getAllFormatedResult()
        {
            return _transfer(getall());
        }

        private List<PROXY> _transfer(DataTable table)
        {
            List<PROXY> list = new List<PROXY>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                PROXY proxy = new PROXY();
                proxy.ProID = Convert.ToInt32(table.Rows[i]["ProID"].ToString());
                proxy.Comment = table.Rows[i]["Comment"].ToString();
                proxy.Name = table.Rows[i]["Name"].ToString();
                proxy.Type = table.Rows[i]["Type"].ToString();
                proxy.ImageID = Convert.ToInt32(table.Rows[i]["ImageID"].ToString());
                list.Add(proxy);
            }
            return list;
        }

        public void addARecord(Proxy.ProxyRow row)
        {
            Insert(row.Name, row.Type, row.ImageID, row.Comment);
        }

        public void addAClassRecord(PROXY row)
        {
            Insert(row.Name, row.Type, row.ImageID, row.Comment);
        }

        public void deleteARecordByID(int id)
        {
            string sql = "delete from Proxy where ProID = " + id.ToString();
            CommenHelper helper = CommenHelper.GetInstance();
            helper.initOle();
            helper.delete(sql);
        }

        public PROXY getResultByID(int id)
        {
            string sql = "select * from Proxy where ProID = " + id.ToString();
            DataTable table = new DataTable();
            CommenHelper helper = CommenHelper.GetInstance();
            helper.initOle();
            table = helper.getResultBySql(sql);
            return _transfer(table).First();
        }

        public void updateARecord(PROXY proxy)
        {
            Proxy.ProxyDataTable table = new Proxy.ProxyDataTable();
            table = GetData();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (Convert.ToInt32(table.Rows[i]["ProID"].ToString()) == proxy.ProID)
                {
                    table.Rows[i]["Name"] = proxy.Name;
                    table.Rows[i]["Type"] = proxy.Type;
                    table.Rows[i]["ImageID"] = proxy.ImageID;
                    table.Rows[i]["Comment"] = proxy.Comment;
                    break;
                }
            }
            Update(table);
        }

        public List<PROXY> GetFormatedResultByType(string type)
        {
            string sql = "select * from Proxy where Type = '" + type + "'";
            DataTable table = new DataTable();
            CommenHelper helper = CommenHelper.GetInstance();
            helper.initOle();
            table = helper.getResultBySql(sql);
            return _transfer(table); 
        }
    }
}
