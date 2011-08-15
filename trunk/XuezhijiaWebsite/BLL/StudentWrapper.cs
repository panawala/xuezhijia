using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.StudentTableAdapters;
using DAL;
using BLL;
using System.Data;

namespace BLL
{
    public class StudentWrapper : StudentTableAdapter
    {
        public DataTable getall()
        {
            return GetData();
        }

        public List<STUDENT> getAllFormatedResult()
        {
            return _transfer(getall());

        }

        private List<STUDENT> _transfer(DataTable table)
        {
            List<STUDENT> list = new List<STUDENT>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                STUDENT student = new STUDENT();
                student.SID = Convert.ToInt32(table.Rows[i]["SID"].ToString());
                student.SName = table.Rows[i]["SName"].ToString();
                student.Address = table.Rows[i]["Address"].ToString();
                student.Grade = table.Rows[i]["Grade"].ToString();
                student.Requirement = table.Rows[i]["Requirement"].ToString();
                student.Comment = table.Rows[i]["Comment"].ToString();
                list.Add(student);
            }
            return list;
        }

        public void addARecord(Student.StudentRow row)
        {
            Insert(row.SName, row.Address, row.Grade, row.Requirement, row.Comment);
        }

        public void addAClassRecord(STUDENT row)
        {
            Insert(row.SName, row.Address, row.Grade, row.Requirement, row.Comment);
        }

        public void deleteARecordByID(int id)
        {
            string sql = "delete from Student where SID = " + id.ToString();
            CommenHelper helper = CommenHelper.GetInstance();
            helper.initOle();
            helper.delete(sql);
        }

        public STUDENT getResultByID(int id)
        {
            string sql = "select * from Student where SID = " + id.ToString();
            DataTable table = new DataTable();
            CommenHelper helper = CommenHelper.GetInstance();
            helper.initOle();
            table = helper.getResultBySql(sql);
            return _transfer(table).First();
        }

        public void updateARecord(STUDENT student)
        {
            Student.StudentDataTable table = new Student.StudentDataTable();
            table = GetData();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (Convert.ToInt32(table.Rows[i]["SID"].ToString()) == student.SID)
                {
                    table.Rows[i]["SName"] = student.SName;
                    table.Rows[i]["Address"] = student.Address;
                    table.Rows[i]["Grade"] = student.Grade;
                    table.Rows[i]["Requirement"] = student.Requirement;
                    table.Rows[i]["Comment"] = student.Comment;
                    break;
                }
            }
            Update(table);
        }
    }
}
