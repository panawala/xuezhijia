using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.CarTableAdapters;
using System.Data;

namespace BLL
{
    class CarWrapper : CarTableAdapter
    {
        public DataTable getall()
        {
            return GetData();
        }

    }
}
