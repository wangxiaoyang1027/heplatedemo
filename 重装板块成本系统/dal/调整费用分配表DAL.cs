using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using 重装板块成本系统.model;

namespace 重装板块成本系统.dal
{
	public partial class 调整费用分配表DAL
	{

        // 已部门得到 费用调整信息
        public DataTable getDateByDept( DateTime mydate  ,int deptcode)
        {
            string sql = @"select id, convert(nchar(10),年月,111) 年月 , rtrim(工号) 工号, 薪酬调整, 燃料调整, 制造调整 from 调整费用分配表 
                where 部门='{0}' and year(年月)={1} and month(年月)={2}";

            sql = string.Format(sql, deptcode, mydate.Year,mydate.Month);
            return SqlHelper.ExecuteDataTable(sql);


        }

        // 得到 指定年月， 指定部门的




        // 以上是手工增加的功能
        public 调整费用分配表 Add(调整费用分配表 调整费用分配表)
		{
				string sql ="INSERT INTO 调整费用分配表 (id, 年月, 工号, 薪酬调整, 燃料调整, 制造调整, 部门)  VALUES (@id, @年月, @工号, @薪酬调整, @燃料调整, @制造调整, @部门)";
				SqlParameter[] para = new SqlParameter[]
					{
						new SqlParameter("@id", ToDBValue(调整费用分配表.Id)),
						new SqlParameter("@年月", ToDBValue(调整费用分配表.年月)),
						new SqlParameter("@工号", ToDBValue(调整费用分配表.工号)),
						new SqlParameter("@薪酬调整", ToDBValue(调整费用分配表.薪酬调整)),
						new SqlParameter("@燃料调整", ToDBValue(调整费用分配表.燃料调整)),
						new SqlParameter("@制造调整", ToDBValue(调整费用分配表.制造调整)),
						new SqlParameter("@部门", ToDBValue(调整费用分配表.部门)),
					};
				SqlHelper.ExecuteNonQuery(sql, para);
				return 调整费用分配表;				
		}

        public int DeleteById(Guid id)
		{
            string sql = "DELETE 调整费用分配表 WHERE Id = @Id";

           SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@id", id)
			};
		
            return SqlHelper.ExecuteNonQuery(sql, para);
		}
		
				
        public int Update(调整费用分配表 调整费用分配表)
        {
            string sql =
                "UPDATE 调整费用分配表 " +
                "SET " +
			" 年月 = @年月" 
                +", 工号 = @工号" 
                +", 薪酬调整 = @薪酬调整" 
                +", 燃料调整 = @燃料调整" 
                +", 制造调整 = @制造调整" 
                +", 部门 = @部门" 
               
            +" WHERE id = @id";


			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@id", 调整费用分配表.Id)
					,new SqlParameter("@年月", ToDBValue(调整费用分配表.年月))
					,new SqlParameter("@工号", ToDBValue(调整费用分配表.工号))
					,new SqlParameter("@薪酬调整", ToDBValue(调整费用分配表.薪酬调整))
					,new SqlParameter("@燃料调整", ToDBValue(调整费用分配表.燃料调整))
					,new SqlParameter("@制造调整", ToDBValue(调整费用分配表.制造调整))
					,new SqlParameter("@部门", ToDBValue(调整费用分配表.部门))
			};

			return SqlHelper.ExecuteNonQuery(sql, para);
        }		
		
        public 调整费用分配表 GetById(Guid id)
        {
            string sql = "SELECT * FROM 调整费用分配表 WHERE Id = @Id";
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
		
		public 调整费用分配表 ToModel(SqlDataReader reader)
		{
			调整费用分配表 调整费用分配表 = new 调整费用分配表();

			调整费用分配表.Id = (Guid)ToModelValue(reader,"id");
			调整费用分配表.年月 = (DateTime)ToModelValue(reader,"年月");
			调整费用分配表.工号 = (string)ToModelValue(reader,"工号");
			调整费用分配表.薪酬调整 = (decimal)ToModelValue(reader,"薪酬调整");
			调整费用分配表.燃料调整 = (decimal)ToModelValue(reader,"燃料调整");
			调整费用分配表.制造调整 = (decimal)ToModelValue(reader,"制造调整");
			调整费用分配表.部门 = (short)ToModelValue(reader,"部门");
			return 调整费用分配表;
		}
		
		public int GetTotalCount()
		{
			string sql = "SELECT count(*) FROM 调整费用分配表";
			return (int)SqlHelper.ExecuteScalar(sql);
		}
		
		public List<调整费用分配表> GetPagedData(int minrownum,int maxrownum)
		{
			string sql = "SELECT * from(SELECT *,row_number() over(order by id) rownum FROM 调整费用分配表) t where rownum>=@minrownum and rownum<=@maxrownum";
			using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql,
				new SqlParameter("@minrownum",minrownum),
				new SqlParameter("@maxrownum",maxrownum)))
			{
				return ToModels(reader);					
			}
		}
        
        public DataTable GetPagedDataTable(int minrownum,int maxrownum)
		{
			string sql = "SELECT * from(SELECT *,row_number() over(order by id) rownum FROM 调整费用分配表) t where rownum>=@minrownum and rownum<=@maxrownum";
			using(DataTable dt = SqlHelper.ExecuteDataTable(sql,
				new SqlParameter("@minrownum",minrownum),
				new SqlParameter("@maxrownum",maxrownum)))
			{
				return dt;					
			}
		}
		
		public List<调整费用分配表> GetAll()
		{
			string sql = "SELECT * FROM 调整费用分配表";
			using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql))
			{
				return ToModels(reader);			
			}
		}
		
        public DataTable GetAllDataTable()
		{
			string sql = "SELECT * FROM 调整费用分配表";
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
SELECT row_number() OVER({0}) AS rownum, id,年月,工号,薪酬调整,燃料调整,制造调整,部门 FROM 调整费用分配表 {1}) t WHERE rownum BETWEEN {2} AND {3}";

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
SELECT row_number() OVER({0}) AS rownum, id,年月,工号,薪酬调整,燃料调整,制造调整,部门 FROM 调整费用分配表 {1}) t";
                string orderClause = String.IsNullOrEmpty(orderByColumn) ? String.Empty : "ORDER BY " + orderByColumn;
                string whereClause = String.IsNullOrEmpty(searchExpression) ? String.Empty : "WHERE " + searchExpression;
                sql = String.Format(sql, orderClause, whereClause);
                return (int)SqlHelper.ExecuteScalar(sql);
        }
        
		protected List<调整费用分配表> ToModels(SqlDataReader reader)
		{
			var list = new List<调整费用分配表>();
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