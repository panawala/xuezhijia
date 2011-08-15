using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.TeacherTableAdapters;
using System.Data;
using DAL;
using BLL;

namespace BLL
{
    public class TeacherWrapper : TeacherTableAdapter
    {
        public DataTable getall()
        {
            return GetData();
        }

        public List<TEACHER> getAllFormatedResult()
        {
            return _transfer(getall());

        }

        private List<TEACHER> _transfer(DataTable table)
        {
            List<TEACHER> list = new List<TEACHER>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                TEACHER teacher = new TEACHER();
                teacher.TID = Convert.ToInt32(table.Rows[i]["TID"].ToString());
                teacher.ConnectionInformation = table.Rows[i]["ConnectionInformation"].ToString();
                teacher.TName = table.Rows[i]["TName"].ToString();
                teacher.AdvantageSubjects = table.Rows[i]["AdvantageSubjects"].ToString();
                teacher.Comment = table.Rows[i]["Comment"].ToString();
                list.Add(teacher);
            }
            return list;
        }

        public void addARecord(Teacher.TeacherRow row)
        {
            Insert(row.ConnectionInformation, row.TName, row.AdvantageSubjects, row.Comment);
        }

        public void addAClassRecord(TEACHER row)
        {
            Insert(row.ConnectionInformation, row.TName, row.AdvantageSubjects, row.Comment);
        }

        public void deleteARecordByID(int id)
        {
            string sql = "delete from Teacher where TID = " + id.ToString();
            CommenHelper helper = CommenHelper.GetInstance();
            helper.initOle();
            helper.delete(sql);
        }

        public TEACHER getResultByID(int id)
        {
            string sql = "select * from Teacher where TID = " + id.ToString();
            DataTable table = new DataTable();
            CommenHelper helper = CommenHelper.GetInstance();
            helper.initOle();
            table = helper.getResultBySql(sql);
            return _transfer(table).First();
        }

        public void updateARecord(TEACHER teacher)
        {
            Teacher.TeacherDataTable table = new Teacher.TeacherDataTable();
            table = GetData();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (Convert.ToInt32(table.Rows[i]["TID"].ToString()) == teacher.TID)
                {
                    table.Rows[i]["ConnectionInformation"] = teacher.ConnectionInformation;
                    table.Rows[i]["TName"] = teacher.TName;
                    table.Rows[i]["AdvantageSubjects"] = teacher.AdvantageSubjects;
                    table.Rows[i]["Comment"] = teacher.Comment;
                    break;
                }
            }
            Update(table);
        }
    }
}
