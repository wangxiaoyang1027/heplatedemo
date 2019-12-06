using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using 重装板块成本系统.model;

namespace 重装板块成本系统.dal
{
	public partial class 每月收入DAL
	{

        public DataTable GetAllDataTable( DateTime mydate , int deptcode )
        {
            string mytype;

            mytype = "内部交易";

            if (deptcode == 40)
                mytype = "外贸";
            if (deptcode == 41)
                mytype = "内贸";
        

            string sql = "SELECT id, rtrim(工号) 工号, rtrim(台份) 台份,convert(nchar(10),日期,111) 日期, " +
                "   rtrim(类型) 类型,重量, 收入, 欧元, 美元  FROM 每月收入 where year(日期)={0} and month(日期)={1} and 类型 ='{2}'" +
                " union select null ,'总计','','',类型,sum(重量),sum(收入),sum(欧元), sum(美元) from 每月收入 where year(日期)={0} and month(日期)={1} and 类型 ='{2}' group by 类型";

            sql = string.Format(sql, mydate.Year, mydate.Month, mytype);
            using (DataTable dt = SqlHelper.ExecuteDataTable(sql))
            {
                return dt;
            }
        }


        public DataTable GetAllDataTable(DateTime mydate, int deptcode, string workno)
        {
            string mytype;

            mytype = "内部交易";

            if (deptcode == 40)
                mytype = "外贸";
            if (deptcode == 41)
                mytype = "内贸";


            string sql = "SELECT id, rtrim(工号) 工号, rtrim(台份) 台份,convert(nchar(10),日期,111) 日期, " +
                "   rtrim(类型) 类型,重量, 收入, 欧元, 美元  FROM 每月收入 where year(日期)={0} and month(日期)={1} and 类型 ='{2}' and 工号 like '%{3}%'" +
                " union select null ,'总计','','',类型,sum(重量),sum(收入),sum(欧元), sum(美元) from 每月收入 where year(日期)={0} and month(日期)={1} and 类型 ='{2}' and 工号 like '%{3}%' group by 类型";

            sql = string.Format(sql, mydate.Year, mydate.Month, mytype, workno);
            using (DataTable dt = SqlHelper.ExecuteDataTable(sql))
            {
                return dt;
            }
        }





        public DataTable GetAllDataTable(DateTime mydate)
        {
            string sql = "select * from (SELECT id, rtrim(工号) 工号, rtrim(台份) 台份,convert(nchar(10),日期,111) 日期, " +
                "   rtrim(类型) 类型,重量, 收入 FROM 每月收入 where year(日期)={0} and month(日期)={1} " +
                "union select null,'总计','','',类型, SUM(重量), SUM(收入) from 每月收入 where year(日期)={0} and month(日期)={1} group  by 类型) t order by 工号,类型";

            sql = string.Format(sql, mydate.Year, mydate.Month);
            using (DataTable dt = SqlHelper.ExecuteDataTable(sql))
            {
                return dt;
            }

        }




        //  
        public 每月收入 Add(每月收入 每月收入)
		{
				string sql ="INSERT INTO 每月收入 (id, 工号, 台份, 日期, 类型, 重量, 收入, 主机厂, 欧元, 美元)  VALUES (@id, @工号, @台份, @日期, @类型, @重量, @收入, @主机厂,@欧元,@美元)";
				SqlParameter[] para = new SqlParameter[]
					{
						new SqlParameter("@id", ToDBValue(每月收入.Id)),
						new SqlParameter("@工号", ToDBValue(每月收入.工号)),
						new SqlParameter("@台份", ToDBValue(每月收入.台份)),
						new SqlParameter("@日期", ToDBValue(每月收入.日期)),
						new SqlParameter("@类型", ToDBValue(每月收入.类型)),
						new SqlParameter("@重量", ToDBValue(每月收入.重量)),
						new SqlParameter("@收入", ToDBValue(每月收入.收入)),
						new SqlParameter("@主机厂", ToDBValue(每月收入.主机厂)),
                        new SqlParameter("@欧元", ToDBValue(每月收入.欧元)),
                        new SqlParameter("@美元", ToDBValue(每月收入.美元)),
                    };
				SqlHelper.ExecuteNonQuery(sql, para);
				return 每月收入;				
		}

        public int DeleteById(Guid id)
		{
            string sql = "DELETE 每月收入 WHERE Id = @Id";

           SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@id", id)
			};
		
            return SqlHelper.ExecuteNonQuery(sql, para);
		}
		
				
        public int Update(每月收入 每月收入)
        {
            string sql =
                "UPDATE 每月收入 " +
                "SET " +
			" 工号 = @工号" 
                +", 台份 = @台份" 
                +", 日期 = @日期" 
                +", 类型 = @类型" 
                +", 重量 = @重量" 
                +", 收入 = @收入" 
                +", 主机厂 = @主机厂"
                 + ", 欧元 = @欧元"
                  + ", 美元 = @美元"

            + " WHERE id = @id";


			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@id", 每月收入.Id)
					,new SqlParameter("@工号", ToDBValue(每月收入.工号))
					,new SqlParameter("@台份", ToDBValue(每月收入.台份))
					,new SqlParameter("@日期", ToDBValue(每月收入.日期))
					,new SqlParameter("@类型", ToDBValue(每月收入.类型))
					,new SqlParameter("@重量", ToDBValue(每月收入.重量))
					,new SqlParameter("@收入", ToDBValue(每月收入.收入))
					,new SqlParameter("@主机厂", ToDBValue(每月收入.主机厂))
                    ,new SqlParameter("@欧元", ToDBValue(每月收入.欧元))
                    ,new SqlParameter("@美元", ToDBValue(每月收入.美元))
			};

			return SqlHelper.ExecuteNonQuery(sql, para);
        }		
		
        public 每月收入 GetById(Guid id)
        {
            string sql = "SELECT * FROM 每月收入 WHERE Id = @Id";
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
		
		public 每月收入 ToModel(SqlDataReader reader)
		{
			每月收入 每月收入 = new 每月收入();

			每月收入.Id = (Guid)ToModelValue(reader,"id");
			每月收入.工号 = (string)ToModelValue(reader,"工号");
			每月收入.台份 = (string)ToModelValue(reader,"台份");
			每月收入.日期 = (DateTime)ToModelValue(reader,"日期");
			每月收入.类型 = (string)ToModelValue(reader,"类型");
			每月收入.重量 = double.Parse(ToModelValue(reader,"重量").ToString());
			每月收入.收入 = double.Parse(ToModelValue(reader,"收入").ToString());
            每月收入.欧元 = double.Parse(ToModelValue(reader, "欧元").ToString());
            每月收入.美元 = double.Parse(ToModelValue(reader, "美元").ToString());
            每月收入.主机厂 = (string)ToModelValue(reader,"主机厂");
			return 每月收入;
		}
		
		public int GetTotalCount()
		{
			string sql = "SELECT count(*) FROM 每月收入";
			return (int)SqlHelper.ExecuteScalar(sql);
		}
		
		public List<每月收入> GetPagedData(int minrownum,int maxrownum)
		{
			string sql = "SELECT * from(SELECT *,row_number() over(order by id) rownum FROM 每月收入) t where rownum>=@minrownum and rownum<=@maxrownum";
			using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql,
				new SqlParameter("@minrownum",minrownum),
				new SqlParameter("@maxrownum",maxrownum)))
			{
				return ToModels(reader);					
			}
		}
        
        public DataTable GetPagedDataTable(int minrownum,int maxrownum)
		{
			string sql = "SELECT * from(SELECT *,row_number() over(order by id) rownum FROM 每月收入) t where rownum>=@minrownum and rownum<=@maxrownum";
			using(DataTable dt = SqlHelper.ExecuteDataTable(sql,
				new SqlParameter("@minrownum",minrownum),
				new SqlParameter("@maxrownum",maxrownum)))
			{
				return dt;					
			}
		}
		
		public List<每月收入> GetAll()
		{
			string sql = "SELECT * FROM 每月收入";
			using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql))
			{
				return ToModels(reader);			
			}
		}
		
        public DataTable GetAllDataTable()
		{
			string sql = "SELECT id, rtrim(工号) 工号, rtrim(台份) 台份,convert(nchar(10),日期,111) 日期," +
                    " rtrim(类型) 类型,重量, 收入 , 欧元, 美元 FROM 每月收入 ";

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
SELECT row_number() OVER({0}) AS rownum, id,工号,台份,日期,类型,重量,收入,主机厂 FROM 每月收入 {1}) t WHERE rownum BETWEEN {2} AND {3}";

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
SELECT row_number() OVER({0}) AS rownum, id,工号,台份,日期,类型,重量,收入,主机厂 FROM 每月收入 {1}) t";
                string orderClause = String.IsNullOrEmpty(orderByColumn) ? String.Empty : "ORDER BY " + orderByColumn;
                string whereClause = String.IsNullOrEmpty(searchExpression) ? String.Empty : "WHERE " + searchExpression;
                sql = String.Format(sql, orderClause, whereClause);
                return (int)SqlHelper.ExecuteScalar(sql);
        }
        
		protected List<每月收入> ToModels(SqlDataReader reader)
		{
			var list = new List<每月收入>();
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