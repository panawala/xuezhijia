using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Data.OleDb;

namespace DAL
{
    public class CommenHelper
    {
            private static CommenHelper instance = null;
            private CommenHelper() { }
            public static CommenHelper GetInstance()
            {
                return (instance != null) ? instance : new CommenHelper();
            }

            private string _connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            public string ConnectionString
            {
                get { return _connectionString; }
                set { _connectionString = value; }
            }

            private SqlConnection myConn;

            public object ExecuteScalarDB(string sql, SqlParameter[] pars)
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    SqlCommand comm = new SqlCommand(sql, conn);
                    if (pars != null) comm.Parameters.AddRange(pars);
                    return comm.ExecuteScalar();
                }
            }


            public DataTable getResultBySql(string sql)
            {
                myConn = new SqlConnection(_connectionString);
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand(sql, myConn);
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                myConn.Open();
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "table");
                DataTable table = dataSet.Tables[0];
                myConn.Close();
                return table;
            }

            public void initOle()
            {
                string strCon = _connectionString;
                myConn = new SqlConnection(strCon);
                myConn.Open();
            }

            public void delete(string sql)
            {

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.DeleteCommand = new SqlCommand(sql, myConn);
                adapter.DeleteCommand.ExecuteNonQuery();
                myConn.Close();
            }

          

            public void update(string sql)
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.UpdateCommand = new SqlCommand(sql, myConn);
                adapter.UpdateCommand.ExecuteNonQuery();
                myConn.Close();
            }

            public void insert(string sql)
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.InsertCommand = new SqlCommand(sql, myConn);
                adapter.InsertCommand.ExecuteNonQuery();
                myConn.Close();
            }

            public DataTable getResultBySqlAndProcedure(string procname, string sql, IDataParameter[] parameters)
            {
                initOle();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = myConn;
                cmd.CommandText = procname;
                cmd.CommandType = CommandType.StoredProcedure;
                for (int i = 0; i < parameters.Length; i++)
                {
                    cmd.Parameters.Add(parameters[i]);
                }
                SqlDataAdapter dp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                // 填充dataset
                dp.Fill(ds);
                myConn.Close();
                return ds.Tables[0];
            }

            public int getIdent(string tablename)
            {
                myConn = new SqlConnection(_connectionString);
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand("SELECT IDENT_CURRENT('" + tablename + "');", myConn);
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                myConn.Open();
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "table");
                DataTable table = dataSet.Tables[0];
                myConn.Close();
                return Convert.ToInt32(table.Rows[0][0].ToString());
            }

            public int getIdentByTable(string tablename)
            {
                myConn = new SqlConnection(_connectionString);
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand("SELECT IDENT_CURRENT('" + tablename + "');", myConn);
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                myConn.Open();
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "table");
                DataTable table = dataSet.Tables[0];
                myConn.Close();
                return Convert.ToInt32(table.Rows[0][0].ToString()); 
            }
      }
}
