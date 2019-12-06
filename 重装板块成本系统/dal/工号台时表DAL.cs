using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using 重装板块成本系统.model;
using System.Windows.Forms;

namespace 重装板块成本系统.dal
{
	public partial class 工号台时表DAL
	{
        public DataTable getDatePerMonth( DateTime mydate)
        {
            string sql = @"Select id, 日期, 工时, 折合工时, 工号 from 工号台时表 where year(日期)={0} and month(日期)={1}";
            sql = string.Format(sql, mydate.Year, mydate.Month);

            return SqlHelper.ExecuteDataTable(sql);
                        
        }

        // 更改一个月份的 工号
        public void updateWorkno( string oldworkno, string newworkno, DateTime mydate,int deptcode)
        {
            string sql = @"Update 工号台时表 set 工号='{1}' where 工号='{0}' and year(日期) ={2} 
                and month(日期) ={3} and 部门={4}";

            sql = string.Format(sql, oldworkno, newworkno, mydate.Year, mydate.Month, deptcode);

            SqlHelper.ExecuteNonQuery(sql);
        }

        


        // 检查是否已有这个月份的工号工时数据
        public bool isHasRecord ( DateTime mydate, int deptcode)
        {
            string sql = @"select count(*) from 工号台时表 where year(日期)={0} and month(日期)={1} and 部门={2}";
            sql = string.Format(sql, mydate.Year, mydate.Month, deptcode);

            if ( (int)SqlHelper.ExecuteScalar(sql) > 0)
            {
                if (MessageBox.Show("数据库里已有这个月的工号台时 数据，真的要再次导入吗", "警  告", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    sql = "delete 工号台时表 where  year(日期) = {0} and month(日期) = {1} and 部门={2}";
                    sql = string.Format(sql, mydate.Year, mydate.Month, deptcode);
                    SqlHelper.ExecuteNonQuery(sql);
                    return true;
                }
                else
                    return false;
            }

            return true;
        }


        // 以上是手工增加的 功能

        public 工号台时表 Add(工号台时表 工号台时表)
		{
				string sql ="INSERT INTO 工号台时表 (id, 日期, 工时, 折合工时, 工号, 部门)  VALUES (@id, @日期, @工时, @折合工时, @工号, @部门)";
				SqlParameter[] para = new SqlParameter[]
					{
						new SqlParameter("@id", ToDBValue(工号台时表.Id)),
						new SqlParameter("@日期", ToDBValue(工号台时表.日期)),
						new SqlParameter("@工时", ToDBValue(工号台时表.工时)),
						new SqlParameter("@折合工时", ToDBValue(工号台时表.折合工时)),
						new SqlParameter("@工号", ToDBValue(工号台时表.工号)),
						new SqlParameter("@部门", ToDBValue(工号台时表.部门)),
					};
				SqlHelper.ExecuteNonQuery(sql, para);
				return 工号台时表;				
		}

        public int DeleteById(Guid id)
		{
            string sql = "DELETE 工号台时表 WHERE Id = @Id";

           SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@id", id)
			};
		
            return SqlHelper.ExecuteNonQuery(sql, para);
		}
		
				
        public int Update(工号台时表 工号台时表)
        {
            string sql =
                "UPDATE 工号台时表 " +
                "SET " +
			" 日期 = @日期" 
                +", 工时 = @工时" 
                +", 折合工时 = @折合工时" 
                +", 工号 = @工号" 
                +", 部门 = @部门" 
               
            +" WHERE id = @id";


			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@id", 工号台时表.Id)
					,new SqlParameter("@日期", ToDBValue(工号台时表.日期))
					,new SqlParameter("@工时", ToDBValue(工号台时表.工时))
					,new SqlParameter("@折合工时", ToDBValue(工号台时表.折合工时))
					,new SqlParameter("@工号", ToDBValue(工号台时表.工号))
					,new SqlParameter("@部门", ToDBValue(工号台时表.部门))
			};

			return SqlHelper.ExecuteNonQuery(sql, para);
        }		
		
        public 工号台时表 GetById(Guid id)
        {
            string sql = "SELECT * FROM 工号台时表 WHERE Id = @Id";
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
		
		public 工号台时表 ToModel(SqlDataReader reader)
		{
			工号台时表 工号台时表 = new 工号台时表();

			工号台时表.Id = (Guid)ToModelValue(reader,"id");
			工号台时表.日期 = (DateTime)ToModelValue(reader,"日期");
			工号台时表.工时 = (decimal)ToModelValue(reader,"工时");
			工号台时表.折合工时 = (decimal)ToModelValue(reader,"折合工时");
			工号台时表.工号 = (string)ToModelValue(reader,"工号");
			工号台时表.部门 = (short)ToModelValue(reader,"部门");
			return 工号台时表;
		}
		
		public int GetTotalCount()
		{
			string sql = "SELECT count(*) FROM 工号台时表";
			return (int)SqlHelper.ExecuteScalar(sql);
		}
		
		public List<工号台时表> GetPagedData(int minrownum,int maxrownum)
		{
			string sql = "SELECT * from(SELECT *,row_number() over(order by id) rownum FROM 工号台时表) t where rownum>=@minrownum and rownum<=@maxrownum";
			using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql,
				new SqlParameter("@minrownum",minrownum),
				new SqlParameter("@maxrownum",maxrownum)))
			{
				return ToModels(reader);					
			}
		}
        
        public DataTable GetPagedDataTable(int minrownum,int maxrownum)
		{
			string sql = "SELECT * from(SELECT *,row_number() over(order by id) rownum FROM 工号台时表) t where rownum>=@minrownum and rownum<=@maxrownum";
			using(DataTable dt = SqlHelper.ExecuteDataTable(sql,
				new SqlParameter("@minrownum",minrownum),
				new SqlParameter("@maxrownum",maxrownum)))
			{
				return dt;					
			}
		}
		
		public List<工号台时表> GetAll()
		{
			string sql = "SELECT * FROM 工号台时表";
			using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql))
			{
				return ToModels(reader);			
			}
		}
		
        public DataTable GetAllDataTable()
		{
			string sql = "SELECT * FROM 工号台时表";
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
SELECT row_number() OVER({0}) AS rownum, id,日期,工时,折合工时,工号,部门 FROM 工号台时表 {1}) t WHERE rownum BETWEEN {2} AND {3}";

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
SELECT row_number() OVER({0}) AS rownum, id,日期,工时,折合工时,工号,部门 FROM 工号台时表 {1}) t";
                string orderClause = String.IsNullOrEmpty(orderByColumn) ? String.Empty : "ORDER BY " + orderByColumn;
                string whereClause = String.IsNullOrEmpty(searchExpression) ? String.Empty : "WHERE " + searchExpression;
                sql = String.Format(sql, orderClause, whereClause);
                return (int)SqlHelper.ExecuteScalar(sql);
        }
        
		protected List<工号台时表> ToModels(SqlDataReader reader)
		{
			var list = new List<工号台时表>();
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