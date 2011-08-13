using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.TeacherTableAdapters;
using System.Data;
using DAL;

namespace BLL
{
    public class TeacherWrapper : TeacherTableAdapter
    {
        public DataTable getAll()
        {
            return GetData();
        }
    }
}
