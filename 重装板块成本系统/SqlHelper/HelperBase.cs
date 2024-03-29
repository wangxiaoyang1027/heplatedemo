﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data;

namespace SqlHelper
{
    /// <summary>
    /// Any database operations base class.
    /// </summary>
    public abstract class HelperBase:IDisposable
    {
        internal bool isOpen = false;
        DbConnection conn;
        DbCommand cmd;

        public virtual DbConnection Connection { get { return conn; } set { conn = value; } }
        public DbCommand Command { get { return cmd; } set { cmd = value; } }

        string connection_str;

        public string ConnectionString
        {
            get
            {
                return connection_str;
            }
            set
            {
                connection_str = value;
            }
        }


        public int ExecuteStoredProcedure(string StoredProcedureName)
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = StoredProcedureName;
            return cmd.ExecuteNonQuery();
        }

        public int ExecuteNoneQuery()
        {
            return cmd.ExecuteNonQuery();
        }

        public string ExecuteScalarString()
        {
            object obj = cmd.ExecuteScalar();
            if (obj != null)
                return obj.ToString();
            else return "空";
        }

        public int ExecuteScalarInt()
        {
            object obj = cmd.ExecuteScalar();
            if (obj != DBNull.Value)
                return Convert.ToInt32(obj);
            else return 0;
        }
        public decimal ExecuteScalarDecimal()
        {
            object obj = cmd.ExecuteScalar();
            if (obj != DBNull.Value)
                return Convert.ToDecimal(obj);
            else return 0;
        }
        public static DataTable ReadTable(DbCommand cmd)
        {
            DataTable dt = new DataTable();
            DbDataReader reader = null;
            try
            {
                reader = cmd.ExecuteReader();
                int fieldc = reader.FieldCount;
                for (int i = 0; i < fieldc; i++)
                {
                    DataColumn dc = new DataColumn(reader.GetName(i), reader.GetFieldType(i));
                    dt.Columns.Add(dc);
                }
                while (reader.Read())
                {
                    DataRow dr = dt.NewRow();
                    for (int i = 0; i < fieldc; i++)
                    {
                        dr[i] = reader[i];
                    }
                    dt.Rows.Add(dr);
                }
                return dt;
            }
            finally
            {
                if (reader != null) reader.Close();
            }
        }

        public DataTable ReadTable()
        {
            return HelperBase.ReadTable(cmd);
            /*
                DataTable dt=new DataTable();
            DbDataReader reader = null;
            try
            {
                reader = cmd.ExecuteReader();
                int fieldc=reader.FieldCount;
                for (int i = 0; i < fieldc; i++)
                {
                    DataColumn dc = new DataColumn(reader.GetName(i), reader.GetFieldType(i));
                    dt.Columns.Add(dc);
                }
                while (reader.Read())
                {
                    DataRow dr = dt.NewRow();
                    for (int i = 0; i < fieldc; i++)
                    {
                        dr[i] = reader[i];
                    }
                    dt.Rows.Add(dr);
                }
                return dt;
            }
            finally
            {
                if (reader != null) reader.Close();
            }*/
        }

        public virtual void Open()
        {
            conn.ConnectionString = ConnectionString;
            conn.Open();
            isOpen = true;
        }

        public virtual void Close()
        {
            if (isOpen && conn != null)
            {
                conn.Close();
            }
        }

        public void Dispose()
        {
            Close();
        }


        
    }
}