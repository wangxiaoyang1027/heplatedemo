using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using 重装板块成本系统.model;

namespace 重装板块成本系统.dal
{
	public partial class 部门表DAL
	{
        public DataTable getOtherDept()
        {
            string sql = @"SELECT id, RTRIM(部门名称) 部门名称 FROM 部门表 where 禁用 = 0 and id not in (1,21,33)";

            return SqlHelper.ExecuteDataTable(sql);
        }

        public DataTable get行业类别()
        {
            string sql = @"select id， rtrim(行业类别) 行业类别 from 行业类别  ";

            return SqlHelper.ExecuteDataTable(sql);
        }




        // 以上是手工增加的功能 
        public 部门表 Add(部门表 部门表)
		{
				string sql ="INSERT INTO 部门表 (id, 部门名称, 禁用)  VALUES (@id, @部门名称, @禁用)";
				SqlParameter[] para = new SqlParameter[]
					{
						new SqlParameter("@id", ToDBValue(部门表.Id)),
						new SqlParameter("@部门名称", ToDBValue(部门表.部门名称)),
						new SqlParameter("@禁用", ToDBValue(部门表.禁用)),
					};
				SqlHelper.ExecuteNonQuery(sql, para);
				return 部门表;				
		}

        public int DeleteById(short id)
		{
            string sql = "DELETE 部门表 WHERE Id = @Id";

           SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@id", id)
			};
		
            return SqlHelper.ExecuteNonQuery(sql, para);
		}
		
				
        public int Update(部门表 部门表)
        {
            string sql =
                "UPDATE 部门表 " +
                "SET " +
			" 部门名称 = @部门名称" 
                +", 禁用 = @禁用" 
               
            +" WHERE id = @id";


			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@id", 部门表.Id)
					,new SqlParameter("@部门名称", ToDBValue(部门表.部门名称))
					,new SqlParameter("@禁用", ToDBValue(部门表.禁用))
			};

			return SqlHelper.ExecuteNonQuery(sql, para);
        }		
		
        public 部门表 GetById(short id)
        {
            string sql = "SELECT * FROM 部门表 WHERE Id = @Id";
            using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql, new SqlParameter("@Id", id)))
			{
				if (reader.Read())
				{
					return ToModel(reader);
				}
				else
				{
					return null;
				}
       		}
        }
		
		public 部门表 ToModel(SqlDataReader reader)
		{
			部门表 部门表 = new 部门表();

			部门表.Id = (short)ToModelValue(reader,"id");
			部门表.部门名称 = (string)ToModelValue(reader,"部门名称");
			部门表.禁用 = (bool)ToModelValue(reader,"禁用");
			return 部门表;
		}
		
		public int GetTotalCount()
		{
			string sql = "SELECT count(*) FROM 部门表";
			return (int)SqlHelper.ExecuteScalar(sql);
		}
		
		public List<部门表> GetPagedData(int minrownum,int maxrownum)
		{
			string sql = "SELECT * from(SELECT *,row_number() over(order by id) rownum FROM 部门表) t where rownum>=@minrownum and rownum<=@maxrownum";
			using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql,
				new SqlParameter("@minrownum",minrownum),
				new SqlParameter("@maxrownum",maxrownum)))
			{
				return ToModels(reader);					
			}
		}
        
        public DataTable GetPagedDataTable(int minrownum,int maxrownum)
		{
			string sql = "SELECT * from(SELECT *,row_number() over(order by id) rownum FROM 部门表) t where rownum>=@minrownum and rownum<=@maxrownum";
			using(DataTable dt = SqlHelper.ExecuteDataTable(sql,
				new SqlParameter("@minrownum",minrownum),
				new SqlParameter("@maxrownum",maxrownum)))
			{
				return dt;					
			}
		}
		
		public List<部门表> GetAll()
		{
			string sql = "SELECT * FROM 部门表";
			using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql))
			{
				return ToModels(reader);			
			}
		}
		
        public DataTable GetAllDataTable()
		{
			string sql = "SELECT * FROM 部门表 ";
			using(DataTable dt = SqlHelper.ExecuteDataTable(sql))
			{
				return dt;			
			}
		}

        public DataTable GetUsedDataTable()
        {
            string sql = "SELECT id, rtrim(部门名称) 部门名称  FROM 部门表 where 禁用=0";
            using (DataTable dt = SqlHelper.ExecuteDataTable(sql))
            {
                return dt;
            }
        }

        public DataTable GetUsedDataTableNoadmin()
        {
            string sql = "SELECT id, rtrim(部门名称) 部门名称  FROM 部门表 where 禁用=0 and id<>1";
            using (DataTable dt = SqlHelper.ExecuteDataTable(sql))
            {
                return dt;
            }
        }


        protected List<部门表> ToModels(SqlDataReader reader)
		{
			var list = new List<部门表>();
			while(reader.Read())
			{
				list.Add(ToModel(reader));
			}	
			return list;
		}		
		
		protected object ToDBValue(object value)
		{
			if(value==null)
			{
				return DBNull.Value;
			}
			else
			{
				return value;
			}
		}
		
		protected object ToModelValue(SqlDataReader reader,string columnName)
		{
			if(reader.IsDBNull(reader.GetOrdinal(columnName)))
			{
				return null;
			}
			else
			{
				return reader[columnName];
			}
		}
	}
}