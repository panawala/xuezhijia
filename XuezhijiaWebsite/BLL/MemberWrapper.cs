using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;
using BLL;
using DAL.MemberTableAdapters;

namespace BLL
{
    public class MemberWrapper : MemberTableAdapter
    {
        public DataTable getall()
        {
            return GetData();
        }

        public List<MEMBER> getAllFormatedResult()
        {
            return _transfer(getall());

        }

        private List<MEMBER> _transfer(DataTable table)
        {
            List<MEMBER> list = new List<MEMBER>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                MEMBER member = new MEMBER();
                member.MemberID = Convert.ToInt32(table.Rows[i]["MemberID"].ToString());
                member.Name = table.Rows[i]["Name"].ToString();
                member.IsNative = table.Rows[i]["IsNative"].ToString();
                member.Address = table.Rows[i]["Address"].ToString();
                member.ContactInformation = table.Rows[i]["ContactInformation"].ToString();
                member.Type = table.Rows[i]["Type"].ToString();
                member.Comment = table.Rows[i]["Comment"].ToString();
                list.Add(member);
            }
            return list;
        }

        public void addARecord(Member.MemberRow row)
        {
            Insert(row.Name, row.IsNative, row.Address, row.ContactInformation, row.Type, row.Comment);
        }

        public void addAClassRecord(MEMBER row)
        {
            Insert(row.Name, row.IsNative, row.Address, row.ContactInformation, row.Type, row.Comment);
        }

        public void deleteARecordByID(int id)
        {
            string sql = "delete from Member where MemberID = " + id.ToString();
            CommenHelper helper = CommenHelper.GetInstance();
            helper.initOle();
            helper.delete(sql);
        }

        public MEMBER getResultByID(int id)
        {
            string sql = "select * from Member where MemberID = " + id.ToString();
            DataTable table = new DataTable();
            CommenHelper helper = CommenHelper.GetInstance();
            helper.initOle();
            table = helper.getResultBySql(sql);
            return _transfer(table).First();
        }

        public void updateARecord(MEMBER member)
        {
            Member.MemberDataTable table = new Member.MemberDataTable();
            table = GetData();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (Convert.ToInt32(table.Rows[i]["MemberID"].ToString()) == member.MemberID)
                {
                    table.Rows[i]["Name"] = member.Name;
                    table.Rows[i]["Type"] = member.Type;
                    table.Rows[i]["IsNative"] = member.IsNative;
                    table.Rows[i]["Comment"] = member.Comment;
                    table.Rows[i]["Address"] = member.Address;
                    table.Rows[i]["ContactInformation"] = member.ContactInformation;
                    break;
                }
            }
            Update(table);
        }
    }
}
