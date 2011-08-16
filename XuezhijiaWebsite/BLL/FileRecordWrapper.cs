using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.FileRecordsTableAdapters;
using DAL;
using System.Data;

namespace BLL
{
    public class FileRecordWrapper : FileRecordsTableAdapter
    {
        public DataTable getAll()
        {
            return CommenHelper.GetInstance().getResultBySql("select * from FileRecords left join UserInfo on FileRecords.UserID = UserInfo.UserID");
        }



        public List<FILERECORDS> getAllFormatedResult()
        {
            return _transfer(getAll());

        }

        private List<FILERECORDS> _transfer(DataTable table)
        {
            List<FILERECORDS> list = new List<FILERECORDS>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                FILERECORDS file = new FILERECORDS();
                file.RecordID = Convert.ToInt32(table.Rows[i]["RecordID"].ToString());
                file.UserID = Convert.ToInt32(table.Rows[i]["UserID"].ToString());
                file.Size = table.Rows[i]["Size"].ToString();
                file.FileName = table.Rows[i]["FileName"].ToString();
                file.PageCount = Convert.ToInt32(table.Rows[i]["PageCount"].ToString());
                file.DateTime = table.Rows[i]["DateTime"].ToString();
                file.State = table.Rows[i]["state"].ToString();
                file.Comment = table.Rows[i]["Comment"].ToString();
                list.Add(file);
            }
            return list;
        }

        public void addARecord(FileRecords.FileRecordsRow row)
        {
            Insert(row.UserID, row.Size, row.FileName, row.PageCount, row.DateTime, row.State, row.Comment);
        }

        public void addAClassRecord(FILERECORDS row)
        {
            Insert(row.UserID, row.Size, row.FileName, row.PageCount, row.DateTime, row.State, row.Comment);
        }

        public void deleteARecordByID(int id)
        {
            string sql = "delete from FileRecords where RecordID = " + id.ToString();
            CommenHelper helper = CommenHelper.GetInstance();
            helper.initOle();
            helper.delete(sql);
        }

        public FILERECORDS getResultByID(int id)
        {
            string sql = "select * from FileRecords where RecordID = " + id.ToString();
            DataTable table = new DataTable();
            CommenHelper helper = CommenHelper.GetInstance();
            helper.initOle();
            table = helper.getResultBySql(sql);
            return _transfer(table).First();
        }



        public void deleteARecord(int id)
        {
            string sql = " delete from FileRecords where RecordID = " + id.ToString();
            CommenHelper helper = CommenHelper.GetInstance();
            helper.initOle();
            helper.delete(sql);
        }

        public DataTable getResultByUserID(int uid)
        {
            string sql = " select * from FileRecords where UserID = " + uid.ToString();
            CommenHelper helper = CommenHelper.GetInstance();
            return helper.getResultBySql(sql);
        }

        public void updateARecord(FileRecords.FileRecordsRow row)
        {

            FileRecords.FileRecordsDataTable table = GetData();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (Convert.ToInt32(table.Rows[i]["RecordID"].ToString()) == row.RecordID)
                {
                    table.Rows[i]["State"] = row.RowState;
                    table.Rows[i]["PageCount"] = row.PageCount;
                    table.Rows[i]["State"] = row.State;
                    table.Rows[i]["Size"] = row.Size;
                    table.Rows[i]["FileName"] = row.FileName;
                    table.Rows[i]["DateTime"] = row.DateTime;
                    table.Rows[i]["Comment"] = row.Comment;
                    table.Rows[i]["UserID"] = row.UserID;
                    break;
                }
            }
            Update(table);
        }

        public void updateARecord(FILERECORDS row)
        {

            FileRecords.FileRecordsDataTable table = new FileRecords.FileRecordsDataTable();
            table = GetData();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (Convert.ToInt32(table.Rows[i]["RecordID"].ToString()) == row.RecordID)
                {
                    table.Rows[i]["State"] = row.State;
                    table.Rows[i]["PageCount"] = row.PageCount;
                    table.Rows[i]["State"] = row.State;
                    table.Rows[i]["Size"] = row.Size;
                    table.Rows[i]["FileName"] = row.FileName;
                    table.Rows[i]["DateTime"] = row.DateTime;
                    table.Rows[i]["Comment"] = row.Comment;
                    table.Rows[i]["UserID"] = row.UserID;
                    break;
                }
            }
            Update(table);
        }
    }
}
