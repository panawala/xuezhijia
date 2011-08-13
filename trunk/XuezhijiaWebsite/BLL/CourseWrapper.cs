using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL.CourseTableAdapters;
using DAL;

namespace BLL
{
    public  class CourseWrapper : CourseTableAdapter
    {
        public DataTable getall()
        {
            return GetData();
        }

        public List<COURSE> getAllFormatedResult()
        {
            return _transfer(getall());

        }

        private List<COURSE> _transfer(DataTable table)
        {
            List<COURSE> list = new List<COURSE>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                COURSE Course = new COURSE();
                Course.CourseID = Convert.ToInt32(table.Rows[i]["CourseID"].ToString());
                Course.CourseName = table.Rows[i]["CourseName"].ToString();
                Course.Lessons = Convert.ToInt16(table.Rows[i]["Lessons"].ToString());
                Course.Location = table.Rows[i]["Location"].ToString();
                Course.Time = table.Rows[i]["Time"].ToString();
                Course.MaxNumber = Convert.ToInt32(table.Rows[i]["MaxNumber"].ToString());
                Course.PID = Convert.ToInt32(table.Rows[i]["PID"].ToString());
                Course.Comment = table.Rows[i]["Comment"].ToString();
                Course.TID = Convert.ToInt32(table.Rows[i]["TID"].ToString());
                list.Add(Course);
            }
            return list;
        }

        public void addARecord(Course.CourseRow row)
        {
            Insert(row.TID, row.CourseName, row.Lessons, row.Location, row.Time, row.MaxNumber, row.PID, row.Comment);
        }

        public void addAClassRecord(COURSE row)
        {
            Insert(row.TID, row.CourseName, row.Lessons, row.Location, row.Time, row.MaxNumber, row.PID, row.Comment);
        }

        public void deleteARecordByID(int id)
        {
            string sql = "delete from Course where CourseID = " + id.ToString();
            CommenHelper helper = CommenHelper.GetInstance();
            helper.initOle();
            helper.delete(sql);
        }

        public COURSE getResultByID(int id)
        {
            string sql = "select * from Course where CourseID = " + id.ToString();
            DataTable table = new DataTable();
            CommenHelper helper = CommenHelper.GetInstance();
            helper.initOle();
            table = helper.getResultBySql(sql);
            return _transfer(table).First();
        }

        public void updateARecord(COURSE Course)
        {
            Course.CourseDataTable table = new Course.CourseDataTable();
            table = GetData();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (Convert.ToInt32(table.Rows[i]["CourseID"].ToString()) == Course.CourseID)
                {
                    table.Rows[i]["CourseName"] = Course.CourseName;
                    table.Rows[i]["Lessons"] = Course.Lessons;
                    table.Rows[i]["Location"] = Course.Location;
                    table.Rows[i]["Time"] = Course.Time;
                    table.Rows[i]["MaxNumber"] = Course.MaxNumber;
                    table.Rows[i]["PID"] = Course.PID;
                    table.Rows[i]["Comment"] = Course.Comment;
                    table.Rows[i]["TID"] = Course.TID;
                    break;
                }
            }
            Update(table);
        }

        public DataTable getHoleInformation()
        {
            string sql = "select * from Course left join Teacher on Course.TID = Teacher.TID";
            return CommenHelper.GetInstance().getResultBySql(sql);
        }

        public string getTeacherNameByID(int id)
        {
            string sql = "select TName from Course left join Teacher on Course.TID = Teacher.TID  where Course.CourseID =  " + id.ToString();
            return CommenHelper.GetInstance().getResultBySql(sql).Rows[0][0].ToString();
        }
    }
}
