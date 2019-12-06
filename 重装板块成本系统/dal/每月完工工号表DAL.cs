using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using 重装板块成本系统.model;

namespace 重装板块成本系统.dal
{
	public partial class 每月完工工号表DAL
	{
        public 每月完工工号表 Add(每月完工工号表 每月完工工号表)
		{
				string sql ="INSERT INTO 每月完工工号表 (工号, 月份, 收入, 类型, 台数, 重量)  VALUES (@工号, @月份, @收入, @类型, @台数, @重量)";
				SqlParameter[] para = new SqlParameter[]
					{
						new SqlParameter("@工号", ToDBValue(每月完工工号表.工号)),
						new SqlParameter("@月份", ToDBValue(每月完工工号表.月份)),
						new SqlParameter("@收入", ToDBValue(每月完工工号表.收入)),
						new SqlParameter("@类型", ToDBValue(每月完工工号表.类型)),
						new SqlParameter("@台数", ToDBValue(每月完工工号表.台数)),
						new SqlParameter("@重量", ToDBValue(每月完工工号表.重量)),
					};
				SqlHelper.ExecuteNonQuery(sql, para);
				return 每月完工工号表;				
		}

		
				
   //     public int Update(每月完工工号表 每月完工工号表)
   //     {
   //         string sql =
   //             "UPDATE 每月完工工号表 " +
   //             "SET " +
			//" 工号 = @工号" 
   //             +", 月份 = @月份" 
   //             +", 收入 = @收入" 
   //             +", 类型 = @类型" 
   //             +", 台数 = @台数" 
   //             +", 重量 = @重量" 
               
   //         +" WHERE liht = @liht";


			//SqlParameter[] para = new SqlParameter[]
			//{
			//	new SqlParameter("@liht", 每月完工工号表.Liht)
			//		,new SqlParameter("@工号", ToDBValue(每月完工工号表.工号))
			//		,new SqlParameter("@月份", ToDBValue(每月完工工号表.月份))
			//		,new SqlParameter("@收入", ToDBValue(每月完工工号表.收入))
			//		,new SqlParameter("@类型", ToDBValue(每月完工工号表.类型))
			//		,new SqlParameter("@台数", ToDBValue(每月完工工号表.台数))
			//		,new SqlParameter("@重量", ToDBValue(每月完工工号表.重量))
			//};

			//return SqlHelper.ExecuteNonQuery(sql, para);
   //     }		
		
	
		public 每月完工工号表 ToModel(SqlDataReader reader)
		{
			每月完工工号表 每月完工工号表 = new 每月完工工号表();

			每月完工工号表.工号 = (string)ToModelValue(reader,"工号");
			每月完工工号表.月份 = (DateTime)ToModelValue(reader,"月份");
			每月完工工号表.收入 = (decimal)ToModelValue(reader,"收入");
			每月完工工号表.类型 = (string)ToModelValue(reader,"类型");
			每月完工工号表.台数 = (short)ToModelValue(reader,"台数");
			每月完工工号表.重量 = (decimal)ToModelValue(reader,"重量");
			return 每月完工工号表;
		}
		
		public int GetTotalCount()
		{
			string sql = "SELECT count(*) FROM 每月完工工号表";
			return (int)SqlHelper.ExecuteScalar(sql);
		}
		
		//public List<每月完工工号表> GetPagedData(int minrownum,int maxrownum)
		//{
		//	string sql = "SELECT * from(SELECT *,row_number() over(order by liht) rownum FROM 每月完工工号表) t where rownum>=@minrownum and rownum<=@maxrownum";
		//	using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql,
		//		new SqlParameter("@minrownum",minrownum),
		//		new SqlParameter("@maxrownum",maxrownum)))
		//	{
		//		return ToModels(reader);					
		//	}
		//}
		
         public DataTable GetPagedData(int minrownum,int maxrownum)
		{
			string sql = "SELECT * from(SELECT *,row_number() over(order by liht) rownum FROM 每月完工工号表) t where rownum>=@minrownum and rownum<=@maxrownum";
			using(DataTable dt = SqlHelper.ExecuteDataTable(sql,
				new SqlParameter("@minrownum",minrownum),
				new SqlParameter("@maxrownum",maxrownum)))
			{
				return dt;					
			}
		}
        
		//public List<每月完工工号表> GetAll()
		//{
		//	string sql = "SELECT * FROM 每月完工工号表";
		//	using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql))
		//	{
		//		return ToModels(reader);			
		//	}
		//}
		
        public DataTable GetAll()
		{
			string sql = "SELECT * FROM 每月完工工号表";
			using(DataTable dt = SqlHelper.ExecuteDataTable(sql))
			{
				return dt;			
			}
		}
        
        /// <summary>
        /// 取得jqgrid 分页数据
        /// </summary>
      public DataTable GetJqgridList(int pageSize, int startIndex, string orderByColumn, string searchExpression)
        {
                string sql = @"SELECT * FROM (
SELECT row_number() OVER({0}) AS rownum, 工号,月份,收入,类型,台数,重量 FROM 每月完工工号表 {1}) WHERE num BETWEEN {2} AND {3}";

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
                //注意：在 row_number()语句中 sqlserver 使用as rownum ,但是oracle 使用as num 后面还不能跟as A
                string sql = @"SELECT COUNT(*) FROM (
SELECT row_number() OVER({0}) AS rownum, 工号,月份,收入,类型,台数,重量 FROM 每月完工工号表 {1})";
                string orderClause = String.IsNullOrEmpty(orderByColumn) ? String.Empty : "ORDER BY " + orderByColumn;
                string whereClause = String.IsNullOrEmpty(searchExpression) ? String.Empty : "WHERE " + searchExpression;
                sql = String.Format(sql, orderClause, whereClause);
                return (int)SqlHelper.ExecuteScalar(sql);
        }
        
		protected List<每月完工工号表> ToModels(SqlDataReader reader)
		{
			var list = new List<每月完工工号表>();
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