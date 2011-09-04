using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.UserInfoTableAdapters;
using DAL;
using System.Data;

namespace BLL
{
   public  class UserInfoWrapper : UserInfoTableAdapter
    {
        public void addARecord(UserInfo.UserInfoRow row)
        {
            Insert(row.UserName, row.Tel_NO, row.Comment, row.PassWord, row.Grade);
        }

        public bool IsValidite(string username, string password)
        {
            string sql = "select * from UserInfo where UserName = '" + username + "' and PassWord = '" + password + "'";
            CommenHelper helper = CommenHelper.GetInstance();
            DataTable table = new DataTable();
            table = helper.getResultBySql(sql);
            if (table.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        public UserInfo.UserInfoRow getRecordByUserNameAndPassWord(string username, string password)
        {
            UserInfo.UserInfoRow row;
            UserInfo.UserInfoDataTable userinfotable = new UserInfo.UserInfoDataTable();
            row = userinfotable.NewUserInfoRow();
            string sql = "select * from UserInfo where UserName = '" + username + "' and PassWord = '" + password + "'";
            CommenHelper helper = CommenHelper.GetInstance();
            DataTable table = new DataTable();
            table = helper.getResultBySql(sql);
            if (table.Rows.Count > 0)
            {
                row.UserID = Convert.ToInt16(table.Rows[0]["UserID"].ToString());
                row.UserName = table.Rows[0]["UserName"].ToString();
                row.PassWord = table.Rows[0]["PassWord"].ToString();
                row.Tel_NO = table.Rows[0]["Tel_NO"].ToString();
            }
            return row; 
        }


        public DataTable getall()
        {
            return GetData();
        }

    }
}
