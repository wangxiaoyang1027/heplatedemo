using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace 重装板块成本系统.dal
{
    class SqlHelper
    {
        public static readonly string connstr = getvalue("connString") + "user =user ; password = user";
        //public static readonly string default_connection_str = ConfigurationManager.ConnectionStrings["yafnet"].ConnectionString;

        public static int ExecuteNonQuery(string cmdText,
            params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = cmdText;
                    cmd.Parameters.AddRange(parameters);

                    return cmd.ExecuteNonQuery();
                }
            }
        }

        static string getvalue(string AppKey)
        {
            string strReturn;
            AppSettingsReader myread = new AppSettingsReader();

            try
            {
                strReturn = myread.GetValue(AppKey, Type.GetType("System.String")).ToString();
            }
            catch (Exception ex)
            {
                strReturn = ex.Message;
            }
            return strReturn;
        }


        public static object ExecuteScalar(string cmdText,
            params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = cmdText;
                    cmd.Parameters.AddRange(parameters);
                    cmd.CommandTimeout = 180;
                    return cmd.ExecuteScalar();
                }
            }
        }

        public static DataTable ExecuteDataTable(string cmdText,
            params SqlParameter[] parameters)
        {
            try { 
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = cmdText;
                    cmd.Parameters.AddRange(parameters);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
            }
            catch( Exception ex)
            {
                throw ex;
            }
        }

        public static SqlDataReader ExecuteDataReader(string cmdText,
            params SqlParameter[] parameters)
        {
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = cmdText;
                cmd.Parameters.AddRange(parameters);
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
        }


        public static void SqlExecProc( string procname , params SqlParameter[] parameters)
        {
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = procname;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(parameters);
                cmd.ExecuteNonQuery();
            }
        }


    }
}

