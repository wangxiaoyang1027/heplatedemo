using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using 重装板块成本系统.model;

namespace 重装板块成本系统.dal
{
	public partial class 材质类别表DAL
	{
        public 材质类别表 Add(材质类别表 材质类别表)
		{
				string sql ="INSERT INTO 材质类别表 (材质类别, 材质名称, noused)  VALUES (@材质类别, @材质名称, @noused)";
				SqlParameter[] para = new SqlParameter[]
					{
						new SqlParameter("@材质类别", ToDBValue(材质类别表.材质类别)),
						new SqlParameter("@材质名称", ToDBValue(材质类别表.材质名称)),
						new SqlParameter("@noused", ToDBValue(材质类别表.Noused)),
					};
				SqlHelper.ExecuteNonQuery(sql, para);
				return 材质类别表;				
		}

        public int DeleteBy材质类别(string 材质类别)
		{
            string sql = "DELETE 材质类别表 WHERE 材质类别 = @材质类别";

           SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@材质类别", 材质类别)
			};
		
            return SqlHelper.ExecuteNonQuery(sql, para);
		}
		
				
        public int Update(材质类别表 材质类别表)
        {
            string sql =
                "UPDATE 材质类别表 " +
                "SET " +
			" 材质名称 = @材质名称" 
                +", noused = @noused" 
               
            +" WHERE 材质类别 = @材质类别";


			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@材质类别", 材质类别表.材质类别)
					,new SqlParameter("@材质名称", ToDBValue(材质类别表.材质名称))
					,new SqlParameter("@noused", ToDBValue(材质类别表.Noused))
			};

			return SqlHelper.ExecuteNonQuery(sql, para);
        }		
		
        public 材质类别表 GetBy材质类别(string 材质类别)
        {
            string sql = "SELECT * FROM 材质类别表 WHERE 材质类别 = @材质类别";
            using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql, new SqlParameter("@材质类别", 材质类别)))
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
		
		public 材质类别表 ToModel(SqlDataReader reader)
		{
			材质类别表 材质类别表 = new 材质类别表();

			材质类别表.材质类别 = (string)ToModelValue(reader,"材质类别");
			材质类别表.材质名称 = (string)ToModelValue(reader,"材质名称");
			材质类别表.Noused = (bool)ToModelValue(reader,"noused");
			return 材质类别表;
		}
		
		public int GetTotalCount()
		{
			string sql = "SELECT count(*) FROM 材质类别表";
			return (int)SqlHelper.ExecuteScalar(sql);
		}
		
		public List<材质类别表> GetPagedData(int minrownum,int maxrownum)
		{
			string sql = "SELECT * from(SELECT *,row_number() over(order by 材质类别) rownum FROM 材质类别表) t where rownum>=@minrownum and rownum<=@maxrownum";
			using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql,
				new SqlParameter("@minrownum",minrownum),
				new SqlParameter("@maxrownum",maxrownum)))
			{
				return ToModels(reader);					
			}
		}
        
        public DataTable GetPagedDataTable(int minrownum,int maxrownum)
		{
			string sql = "SELECT * from(SELECT *,row_number() over(order by 材质类别) rownum FROM 材质类别表) t where rownum>=@minrownum and rownum<=@maxrownum";
			using(DataTable dt = SqlHelper.ExecuteDataTable(sql,
				new SqlParameter("@minrownum",minrownum),
				new SqlParameter("@maxrownum",maxrownum)))
			{
				return dt;					
			}
		}
		
		public List<材质类别表> GetAll()
		{
			string sql = "SELECT * FROM 材质类别表";
			using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql))
			{
				return ToModels(reader);			
			}
		}
		
        public DataTable GetAllDataTable()
		{
			string sql = "SELECT rtrim(材质类别), 材质名称, noused  FROM 材质类别表";
			using(DataTable dt = SqlHelper.ExecuteDataTable(sql))
			{
				return dt;			
			}
		}


        public DataTable GetDataTable()
        {
            //string sql = "SELECT rtrim(材质类别) 材质类别, rtrim(材质名称) 材质名称, noused  FROM 材质类别表 where noused = 0 AND dept='分厂'";
            string sql = "SELECT rtrim(材质类别) 材质类别, rtrim(材质名称) 材质名称, noused  FROM 材质类别表 where noused = 0 AND dept='分厂'";
            using (DataTable dt = SqlHelper.ExecuteDataTable(sql))
            {
                return dt;
            }
        }


        // 销售部门用 
        public DataTable GetDataTableForSale()
        {
            string sql = "SELECT rtrim(材质类别) 材质类别, rtrim(材质名称) 材质名称, noused  FROM 材质类别表 where noused = 0 AND dept='销售'";
            using (DataTable dt = SqlHelper.ExecuteDataTable(sql))
            {
                return dt;
            }

        }


        // 由 材质类别 得到 材质类别名称
        public string getMaterialType( string typestring)
        {
            string sql = @"select 材质名称 from 材质类别表 where 材质类别='{0}'";

            sql = string.Format(sql, typestring);

            return SqlHelper.ExecuteScalar(sql).ToString();
        }




        /// <summary>
        /// 取得jqgrid 分页数据
        /// </summary>
        public DataTable GetJqgridList(int pageSize, int startIndex, string orderByColumn, string searchExpression)
        {
                string sql = @"SELECT * FROM (
SELECT row_number() OVER({0}) AS rownum, 材质类别,材质名称,noused FROM 材质类别表 {1}) t WHERE rownum BETWEEN {2} AND {3}";

                string orderClause = String.IsNullOrEmpty(orderByColumn) ? String.Empty : "ORDER BY " + orderByColumn;
                string whereClause = String.IsNullOrEmpty(searchExpression) ? String.Empty : "WHERE " + searchExpression;
                sql = String.Format(sql, orderClause, whereClause, startIndex + 1, startIndex + pageSize);
               using(DataTable dt = SqlHelper.ExecuteDataTable(sql))
			   {
				return dt;			
			   }
        }
              /// <summary>
      /// 取得jqgrid 分页数据行count
      /// </summary>
      public int GetJqgridCount(string orderByColumn, string searchExpression)
        {
                string sql = @"SELECT COUNT(*) FROM (
SELECT row_number() OVER({0}) AS rownum, 材质类别,材质名称,noused FROM 材质类别表 {1}) t";
                string orderClause = String.IsNullOrEmpty(orderByColumn) ? String.Empty : "ORDER BY " + orderByColumn;
                string whereClause = String.IsNullOrEmpty(searchExpression) ? String.Empty : "WHERE " + searchExpression;
                sql = String.Format(sql, orderClause, whereClause);
                return (int)SqlHelper.ExecuteScalar(sql);
        }
        
		protected List<材质类别表> ToModels(SqlDataReader reader)
		{
			var list = new List<材质类别表>();
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