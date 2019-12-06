using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using 重装板块成本系统.model;

namespace 重装板块成本系统.dal
{
	public partial class 费用分配表DAL
	{

        // 得到 指定部门， 指定时间的 参与费用分配的工号
        public List<string>  getWorkNoPerMonth( DateTime mydate , int deptcode)
        {
            List<string> retval = new List<string>();
            string sql = @"select distinct(工号) 工号 from 费用分配表 where year(时间)={0} and month(时间)={1} and 部门={2}";

            sql = string.Format(sql, mydate.Year, mydate.Month, deptcode);


            SqlDataReader dr = SqlHelper.ExecuteDataReader(sql);
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    retval.Add(dr.GetString(0).Trim());
                }
            }
            dr.Close();
            return retval;
        }

        // 得到一个单位的 指定月份的费用分配 数据
        public DataTable getInfoPerMonthBydeptcode( DateTime mydate, int deptcode )
        {
            string sql = @"select * from (
select rtrim(工号) 工号, convert(nchar(12), 时间,111) 时间, 燃料动力, 工时, 折合工时,
                薪酬, 制造费用 from 费用分配表 where year(时间)={0} and 
                month(时间)={1} and 部门={2}
union
select '总计', '' , sum(燃料动力), sum(工时), sum(折合工时),
                sum(薪酬), sum(制造费用) from 费用分配表 where year(时间)={0} and 
                month(时间)={1} and 部门={2} ) t order by 工号";

            sql = string.Format(sql, mydate.Year, mydate.Month, deptcode);
            return  SqlHelper.ExecuteDataTable(sql);
        }

        // 得到一个单位的 指定月份的费用分配 数据
        public SqlDataReader getInfoPerMonthBydeptcodeReader(DateTime mydate, int deptcode)
        {
            string sql = @"select * from (
            select rtrim(工号) 工号,  sum(燃料动力) 燃料动力,sum(工时) 工时, sum(折合工时) 折合工时, 
                            sum(薪酬) 薪酬, sum(制造费用) 制造费用, sum(isnull(燃料动力+薪酬+制造费用,0)) 合计 from 费用分配表 where year(时间)={0} and 
                            month(时间)={1} and 部门={2} and id not in (select id from 费用分配转出表) group by 工号
            union
            select '总计', sum(燃料动力),sum(工时), sum(折合工时),
                            sum(薪酬), sum(制造费用), isnull( sum(燃料动力)+ sum(薪酬)+  sum(制造费用) ,0 ) 合计 from 费用分配表 where year(时间)={0} and 
                            month(时间)={1} and 部门={2} and id not in (select id from 费用分配转出表)) t order by 工号";

            //string sql = @"select 工号, sum(燃料动力) 燃料动力, sum(工时) 工时, sum(折合工时) 折合工时, 
            //    sum(薪酬) 薪酬 , sum(制造费用) 制造费用 , sum(isnull(燃料动力+薪酬+制造费用,0)) 合计 from view_费用分配表 where year(时间)={0} and 
            //    month(时间)={1} and 部门={2} and id not in (select id from 费用分配转出表) group by 工号";



            sql = string.Format(sql, mydate.Year, mydate.Month, deptcode);
            return SqlHelper.ExecuteDataReader(sql);
        }


        // 得到一个月份总的费用分配
        public SqlDataReader getInfo(DateTime mydate)
        {
            string sql = @"select * from (
select rtrim(工号) 工号,  燃料动力, 工时, 折合工时,
                薪酬, 制造费用 from 费用分配表 where year(时间)={0} and 
                month(时间)={1} and ID not in (select ID from 费用分配转出表)
union
select '总计', sum(燃料动力), sum(工时), sum(折合工时),
                sum(薪酬), sum(制造费用) from 费用分配表 where year(时间)={0} and 
                month(时间)={1} and ID not in (select ID from 费用分配转出表)) t order by 工号";

            sql = string.Format(sql, mydate.Year, mydate.Month);
            return SqlHelper.ExecuteDataReader(sql);
        }





        // 执行 一个工号的费用分配 转出
        public void set费用分配转出(string id)
        {
            string sql = @"insert into 费用分配转出表 values('{0}') ";

            sql = string.Format(sql, id);
            SqlHelper.ExecuteScalar(sql);
        }





        public void 计算费用分配( DateTime mydate , int deptcode )
        {
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@year", mydate.Year),
                new SqlParameter("@month", mydate.Month)
            };

            if ( deptcode == 33)
            {
                SqlHelper.SqlExecProc("重装厂费用分配",  para);

            }
            if ( deptcode == 21)
            {
                SqlHelper.SqlExecProc("矿山厂费用分配", para);
            }

        }




        // 以上是手工增加的功能

        public 费用分配表 Add(费用分配表 费用分配表)
		{
				string sql ="INSERT INTO 费用分配表 (ID, 工号, 时间, 燃料动力, 薪酬, 制造费用, 工时, 折合工时, 部门)  VALUES (@ID, @工号, @时间, @燃料动力, @薪酬, @制造费用, @工时, @折合工时, @部门)";
				SqlParameter[] para = new SqlParameter[]
					{
						new SqlParameter("@ID", ToDBValue(费用分配表.ID)),
						new SqlParameter("@工号", ToDBValue(费用分配表.工号)),
						new SqlParameter("@时间", ToDBValue(费用分配表.时间)),
						new SqlParameter("@燃料动力", ToDBValue(费用分配表.燃料动力)),
						new SqlParameter("@薪酬", ToDBValue(费用分配表.薪酬)),
						new SqlParameter("@制造费用", ToDBValue(费用分配表.制造费用)),
						new SqlParameter("@工时", ToDBValue(费用分配表.工时)),
						new SqlParameter("@折合工时", ToDBValue(费用分配表.折合工时)),
						new SqlParameter("@部门", ToDBValue(费用分配表.部门)),
					};
				SqlHelper.ExecuteNonQuery(sql, para);
				return 费用分配表;				
		}

        public int DeleteByID(Guid iD)
		{
            string sql = "DELETE 费用分配表 WHERE ID = @ID";

           SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@ID", iD)
			};
		
            return SqlHelper.ExecuteNonQuery(sql, para);
		}
		
				
        public int Update(费用分配表 费用分配表)
        {
            string sql =
                "UPDATE 费用分配表 " +
                "SET " +
			" 工号 = @工号" 
                +", 时间 = @时间" 
                +", 燃料动力 = @燃料动力" 
                +", 薪酬 = @薪酬" 
                +", 制造费用 = @制造费用" 
                +", 工时 = @工时" 
                +", 折合工时 = @折合工时" 
                +", 部门 = @部门" 
               
            +" WHERE ID = @ID";


			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@ID", 费用分配表.ID)
					,new SqlParameter("@工号", ToDBValue(费用分配表.工号))
					,new SqlParameter("@时间", ToDBValue(费用分配表.时间))
					,new SqlParameter("@燃料动力", ToDBValue(费用分配表.燃料动力))
					,new SqlParameter("@薪酬", ToDBValue(费用分配表.薪酬))
					,new SqlParameter("@制造费用", ToDBValue(费用分配表.制造费用))
					,new SqlParameter("@工时", ToDBValue(费用分配表.工时))
					,new SqlParameter("@折合工时", ToDBValue(费用分配表.折合工时))
					,new SqlParameter("@部门", ToDBValue(费用分配表.部门))
			};

			return SqlHelper.ExecuteNonQuery(sql, para);
        }		
		
        public 费用分配表 GetByID(Guid iD)
        {
            string sql = "SELECT * FROM 费用分配表 WHERE ID = @ID";
            using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql, new SqlParameter("@ID", iD)))
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
		
		public 费用分配表 ToModel(SqlDataReader reader)
		{
			费用分配表 费用分配表 = new 费用分配表();

			费用分配表.ID = (Guid)ToModelValue(reader,"ID");
			费用分配表.工号 = (string)ToModelValue(reader,"工号");
			费用分配表.时间 = (DateTime)ToModelValue(reader,"时间");
			费用分配表.燃料动力 = (decimal)ToModelValue(reader,"燃料动力");
			费用分配表.薪酬 = (decimal)ToModelValue(reader,"薪酬");
			费用分配表.制造费用 = (decimal)ToModelValue(reader,"制造费用");
			费用分配表.工时 = (decimal)ToModelValue(reader,"工时");
			费用分配表.折合工时 = (decimal)ToModelValue(reader,"折合工时");
			费用分配表.部门 = (short)ToModelValue(reader,"部门");
			return 费用分配表;
		}
		
		public int GetTotalCount()
		{
			string sql = "SELECT count(*) FROM 费用分配表";
			return (int)SqlHelper.ExecuteScalar(sql);
		}
		
		public List<费用分配表> GetPagedData(int minrownum,int maxrownum)
		{
			string sql = "SELECT * from(SELECT *,row_number() over(order by ID) rownum FROM 费用分配表) t where rownum>=@minrownum and rownum<=@maxrownum";
			using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql,
				new SqlParameter("@minrownum",minrownum),
				new SqlParameter("@maxrownum",maxrownum)))
			{
				return ToModels(reader);					
			}
		}
        
        public DataTable GetPagedDataTable(int minrownum,int maxrownum)
		{
			string sql = "SELECT * from(SELECT *,row_number() over(order by ID) rownum FROM 费用分配表) t where rownum>=@minrownum and rownum<=@maxrownum";
			using(DataTable dt = SqlHelper.ExecuteDataTable(sql,
				new SqlParameter("@minrownum",minrownum),
				new SqlParameter("@maxrownum",maxrownum)))
			{
				return dt;					
			}
		}
		
		public List<费用分配表> GetAll()
		{
			string sql = "SELECT * FROM 费用分配表";
			using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql))
			{
				return ToModels(reader);			
			}
		}
		
        public DataTable GetAllDataTable()
		{
			string sql = "SELECT * FROM 费用分配表";
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
SELECT row_number() OVER({0}) AS rownum, ID,工号,时间,燃料动力,薪酬,制造费用,工时,折合工时,部门 FROM 费用分配表 {1}) t WHERE rownum BETWEEN {2} AND {3}";

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
SELECT row_number() OVER({0}) AS rownum, ID,工号,时间,燃料动力,薪酬,制造费用,工时,折合工时,部门 FROM 费用分配表 {1}) t";
                string orderClause = String.IsNullOrEmpty(orderByColumn) ? String.Empty : "ORDER BY " + orderByColumn;
                string whereClause = String.IsNullOrEmpty(searchExpression) ? String.Empty : "WHERE " + searchExpression;
                sql = String.Format(sql, orderClause, whereClause);
                return (int)SqlHelper.ExecuteScalar(sql);
        }
        
		protected List<费用分配表> ToModels(SqlDataReader reader)
		{
			var list = new List<费用分配表>();
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