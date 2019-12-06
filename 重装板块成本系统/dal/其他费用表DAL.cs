using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using 重装板块成本系统.model;

namespace 重装板块成本系统.dal
{
	public partial class 其他费用表DAL
	{
        // 以  部门得到 费用信息
        public DataTable getDateBydeptcode(int deptcode)
        {
            string sql = @"select id, 年月, 燃料动力,薪酬, 制造费用 from 其他费用表 where 部门={0} order by 年月 desc";

            sql = string.Format(sql, deptcode);

            return SqlHelper.ExecuteDataTable(sql);
        }


        // 以上是手工增加的功能
        public 其他费用表 Add(其他费用表 其他费用表)
		{
				string sql ="INSERT INTO 其他费用表 (id, 年月, 薪酬, 燃料动力, 制造费用, 部门)  VALUES (@id, @年月, @薪酬, @燃料动力, @制造费用, @部门)";
				SqlParameter[] para = new SqlParameter[]
					{
						new SqlParameter("@id", ToDBValue(其他费用表.Id)),
						new SqlParameter("@年月", ToDBValue(其他费用表.年月)),
						new SqlParameter("@薪酬", ToDBValue(其他费用表.薪酬)),
						new SqlParameter("@燃料动力", ToDBValue(其他费用表.燃料动力)),
						new SqlParameter("@制造费用", ToDBValue(其他费用表.制造费用)),
						new SqlParameter("@部门", ToDBValue(其他费用表.部门)),
					};
				SqlHelper.ExecuteNonQuery(sql, para);
				return 其他费用表;				
		}

        public int DeleteById(Guid id)
		{
            string sql = "DELETE 其他费用表 WHERE Id = @Id";

           SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@id", id)
			};
		
            return SqlHelper.ExecuteNonQuery(sql, para);
		}
		
				
        public int Update(其他费用表 其他费用表)
        {
            string sql =
                "UPDATE 其他费用表 " +
                "SET " +
			" 年月 = @年月" 
                +", 薪酬 = @薪酬" 
                +", 燃料动力 = @燃料动力" 
                +", 制造费用 = @制造费用" 
                +", 部门 = @部门" 
               
            +" WHERE id = @id";


			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@id", 其他费用表.Id)
					,new SqlParameter("@年月", ToDBValue(其他费用表.年月))
					,new SqlParameter("@薪酬", ToDBValue(其他费用表.薪酬))
					,new SqlParameter("@燃料动力", ToDBValue(其他费用表.燃料动力))
					,new SqlParameter("@制造费用", ToDBValue(其他费用表.制造费用))
					,new SqlParameter("@部门", ToDBValue(其他费用表.部门))
			};

			return SqlHelper.ExecuteNonQuery(sql, para);
        }		
		
        public 其他费用表 GetById(Guid id)
        {
            string sql = "SELECT * FROM 其他费用表 WHERE Id = @Id";
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
		
		public 其他费用表 ToModel(SqlDataReader reader)
		{
			其他费用表 其他费用表 = new 其他费用表();

			其他费用表.Id = (Guid)ToModelValue(reader,"id");
			其他费用表.年月 = (DateTime)ToModelValue(reader,"年月");
			其他费用表.薪酬 = (decimal)ToModelValue(reader,"薪酬");
			其他费用表.燃料动力 = (decimal)ToModelValue(reader,"燃料动力");
			其他费用表.制造费用 = (decimal)ToModelValue(reader,"制造费用");
			其他费用表.部门 = (short)ToModelValue(reader,"部门");
			return 其他费用表;
		}
		
		public int GetTotalCount()
		{
			string sql = "SELECT count(*) FROM 其他费用表";
			return (int)SqlHelper.ExecuteScalar(sql);
		}
		
		public List<其他费用表> GetPagedData(int minrownum,int maxrownum)
		{
			string sql = "SELECT * from(SELECT *,row_number() over(order by id) rownum FROM 其他费用表) t where rownum>=@minrownum and rownum<=@maxrownum";
			using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql,
				new SqlParameter("@minrownum",minrownum),
				new SqlParameter("@maxrownum",maxrownum)))
			{
				return ToModels(reader);					
			}
		}
        
        public DataTable GetPagedDataTable(int minrownum,int maxrownum)
		{
			string sql = "SELECT * from(SELECT *,row_number() over(order by id) rownum FROM 其他费用表) t where rownum>=@minrownum and rownum<=@maxrownum";
			using(DataTable dt = SqlHelper.ExecuteDataTable(sql,
				new SqlParameter("@minrownum",minrownum),
				new SqlParameter("@maxrownum",maxrownum)))
			{
				return dt;					
			}
		}
		
		public List<其他费用表> GetAll()
		{
			string sql = "SELECT * FROM 其他费用表";
			using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql))
			{
				return ToModels(reader);			
			}
		}
		
        public DataTable GetAllDataTable()
		{
			string sql = "SELECT * FROM 其他费用表";
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
SELECT row_number() OVER({0}) AS rownum, id,年月,薪酬,燃料动力,制造费用,部门 FROM 其他费用表 {1}) t WHERE rownum BETWEEN {2} AND {3}";

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
SELECT row_number() OVER({0}) AS rownum, id,年月,薪酬,燃料动力,制造费用,部门 FROM 其他费用表 {1}) t";
                string orderClause = String.IsNullOrEmpty(orderByColumn) ? String.Empty : "ORDER BY " + orderByColumn;
                string whereClause = String.IsNullOrEmpty(searchExpression) ? String.Empty : "WHERE " + searchExpression;
                sql = String.Format(sql, orderClause, whereClause);
                return (int)SqlHelper.ExecuteScalar(sql);
        }
        
		protected List<其他费用表> ToModels(SqlDataReader reader)
		{
			var list = new List<其他费用表>();
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