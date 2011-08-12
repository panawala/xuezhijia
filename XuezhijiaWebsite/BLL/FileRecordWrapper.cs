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
            return GetData();
        }

        public void addARecord(FileRecords.FileRecordsRow row)
        {
            Insert(row.UserID, row.Size, row.FileName, row.PageCount, row.Pseudonym, row.DateTime, row.State, row.Comment);
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
                    table.Rows[i]["RowState"] = row.RowState;
                    table.Rows[i]["PageCount"] = row.PageCount;
                    table.Rows[i]["State"] = row.State;
                    table.Rows[i]["Size"] = row.Size;
                    table.Rows[i]["FileName"] = row.FileName;
                    table.Rows[i]["DateTimee"] = row;
                    table.Rows[i]["Comment"] = row.Comment;
                    break;
                }
            }
            Update(table);
        }
    }
}
