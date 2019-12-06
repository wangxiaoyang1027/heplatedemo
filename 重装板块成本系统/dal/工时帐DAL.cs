using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using 重装板块成本系统.model;

namespace 重装板块成本系统.dal
{
   


	public partial class 工时帐DAL
	{
        // 检查是否给定月份已有工时数据。
        public bool hasData(DateTime mydate)
        {
            string sql = @"select id from 工时帐 where year(日期) = {0} and month(日期) = {1}";
            bool result;

            sql = string.Format(sql, mydate.Year, mydate.Month);
            SqlDataReader dr = SqlHelper.ExecuteDataReader(sql);

            result = dr.HasRows;
            dr.Close();
            return result;
        }


        // 删除指定月份的工时数据
        public void removedate(DateTime mydate)
        {
            string sql = @"delete 工时帐 where year(日期)={0} and month(日期)={1}";
            sql = string.Format( sql , mydate.Year, mydate.Month);

            SqlHelper.ExecuteNonQuery(sql);
        }

        // 得到指定月份导入工时数据中的已被禁用工号
        public DataTable getNousedWorkno( DateTime mydate)
        {
            string sql = @"select distinct(计算工号)  from (select 计算工号, 日期 from 工时帐 where 计算工号 in (select 工作令号 from 工号表 where noused=1 ) and YEAR(日期) = {0} and MONTH(日期)={1})t";
            sql = string.Format(sql, mydate.Year, mydate.Month);
            return SqlHelper.ExecuteDataTable(sql);
        }

        // 得到指定月份导入工时数据中不存在的工号
        public DataTable getWrongWorkno(DateTime mydate)
        {
            string sql = @"select distinct(计算工号)  from (select 计算工号, 日期 from 工时帐 where 计算工号 not in (select 工作令号 from 工号表 where noused=0 ) and YEAR(日期) = {0} and MONTH(日期)={1})t";
            sql = string.Format(sql, mydate.Year, mydate.Month);
            return SqlHelper.ExecuteDataTable(sql);
        }


        // 得到一个月份的工号工时信息
        public DataTable getDatePerMonth( DateTime mydate , int deptcode)
        {
            string sql = @"select rtrim(计算工号) 工号, rtrim(图号) 图号, rtrim(名称) 名称, 工序号, rtrim(设备) 设备, rtrim(操作人) 操作人, 件数, 准结, 单件  FROM 工时帐 where year(日期)={0} and month(日期)={1}";
            sql = string.Format(sql, mydate.Year, mydate.Month);

            return SqlHelper.ExecuteDataTable(sql);

        }


        public void updateWorkno(string oldworkno, string newworkno, DateTime mydate)
        {
            string sql = @"Update 工时帐 set 计算工号='{1}' where 计算工号='{0}' and year(日期) ={2} 
                and month(日期) ={3} ";

            sql = string.Format(sql, oldworkno, newworkno, mydate.Year, mydate.Month);

            SqlHelper.ExecuteNonQuery(sql);
        }


        // 从 MES 数据库中得到指定月份的工时数据
        public SqlDataReader getMesInfo(string startdate, string enddate)
        {
            string sql = @"select WORKCARDNUMBER, workordernumber , drawingnumber, isnull(itemnumber, ' ') itemnumber ,
                isnull(PROCESSMACHINETOOL, ' ') PROCESSMACHINETOOL, FINISHED, READYGOWORKTIME, SINGLEWORKTIME, 
                workingtimetype , reportperson 
                from openquery(MES, 'Select created_on, WORKCARDNUMBER , 
                workordernumber , drawingnumber , nvl(itemnumber,'' '')  itemnumber , NVL(SUBSTR( PROCESSMACHINETOOL , 0, INSTR( PROCESSMACHINETOOL,'' '' )-1),'' '') PROCESSMACHINETOOL, 
                CEIL(FINISHED) FINISHED , NVL(READYGOWORKTIME,0) READYGOWORKTIME , NVL(SINGLEWORKTIME, 0) SINGLEWORKTIME, TRIM(workingtimetype) workingtimetype, 
                trim(reportperson)  reportperson from Completiondetailview 
                where TO_CHAR(created_on,''YYYY-MM-DD'') BETWEEN ''{0}'' AND ''{1}'' and workcardnumber !=''lj'' and orgcode !=''外协组'' and workingtimetype not like ''%临时%'' ')";

            sql = string.Format(sql, startdate, enddate);

            return SqlHelper.ExecuteDataReader(sql);

        }

        // 由 操作者 得到 设备代码
        public string getMachineCode (string Cardno)
        {
            string code ;
            string sql = @"select * from openquery (MES , 'select code from TECHNICALOBJECT where id in (select related_id from teamequip where source_id in 
                (select id from team where id in (select source_id from TEAMMEMBER where related_id in 
                (select id from person where personid = ''{0}''))))')";

            sql = string.Format(sql, Cardno);

            SqlDataReader dr = SqlHelper.ExecuteDataReader(sql);


            if (dr.HasRows)
            {
                dr.Read();
                code = dr.GetString(0);
            }
            else
                code = null;
            dr.Close();
            return code;

        }


        // 将 在 zz_workno 中的新工号， 加入 工号表中 
        public void addWorkno()
        {
            string sql = @"insert into 工号表( 工作令号, 合同号, 名称, 购货单位, 工号类型) select 工作令号, 合同号, 产品名称, 订货单位,'正常'  
                from wfcdb.dbo.ZZ_WorkNo where 主机厂 ='重装厂' and 工作令号 not in (select 工作令号 from 工号表)";

            SqlHelper.ExecuteNonQuery(sql);



        }






        // 以上是 手工增加的 功能





        public 工时帐 Add(工时帐 工时帐)
		{
				string sql ="INSERT INTO 工时帐 (ID, 日期, 工号, 图号, 名称, 工序号, 设备, 操作人, 件数, 准结, 单件, 计算工号, 备注, 工艺机床)  VALUES (@ID, @日期, @工号, @图号, @名称, @工序号, @设备, @操作人, @件数, @准结, @单件,  @计算工号, @备注, @工艺机床)";
				SqlParameter[] para = new SqlParameter[]
					{
						new SqlParameter("@ID", ToDBValue(工时帐.ID)),
						new SqlParameter("@日期", ToDBValue(工时帐.日期)),
						new SqlParameter("@工号", ToDBValue(工时帐.工号)),
						new SqlParameter("@图号", ToDBValue(工时帐.图号)),
						new SqlParameter("@名称", ToDBValue(工时帐.名称)),
						new SqlParameter("@工序号", ToDBValue(工时帐.工序号)),
						new SqlParameter("@设备", ToDBValue(工时帐.设备)),
						new SqlParameter("@操作人", ToDBValue(工时帐.操作人)),
						new SqlParameter("@件数", ToDBValue(工时帐.件数)),
						new SqlParameter("@准结", ToDBValue(工时帐.准结)),
						new SqlParameter("@单件", ToDBValue(工时帐.单件)),
						new SqlParameter("@计算工号", ToDBValue(工时帐.计算工号)),
						new SqlParameter("@备注", ToDBValue(工时帐.备注)),
						new SqlParameter("@工艺机床", ToDBValue(工时帐.工艺机床)),
					};
				SqlHelper.ExecuteNonQuery(sql, para);
				return 工时帐;				
		}

        public int DeleteByID(Guid iD)
		{
            string sql = "DELETE 工时帐 WHERE ID = @ID";

           SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@ID", iD)
			};
		
            return SqlHelper.ExecuteNonQuery(sql, para);
		}
		
				
        public int Update(工时帐 工时帐)
        {
            string sql =
                "UPDATE 工时帐 " +
                "SET " +
			" 日期 = @日期" 
                +", 工号 = @工号" 
                +", 图号 = @图号" 
                +", 名称 = @名称" 
                +", 工序号 = @工序号" 
                +", 设备 = @设备" 
                +", 操作人 = @操作人" 
                +", 件数 = @件数" 
                +", 准结 = @准结" 
                +", 单件 = @单件" 
                +", time = @time" 
                +", 计算工号 = @计算工号" 
                +", 备注 = @备注" 
                +", 工艺机床 = @工艺机床" 
               
            +" WHERE ID = @ID";


			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@ID", 工时帐.ID)
					,new SqlParameter("@日期", ToDBValue(工时帐.日期))
					,new SqlParameter("@工号", ToDBValue(工时帐.工号))
					,new SqlParameter("@图号", ToDBValue(工时帐.图号))
					,new SqlParameter("@名称", ToDBValue(工时帐.名称))
					,new SqlParameter("@工序号", ToDBValue(工时帐.工序号))
					,new SqlParameter("@设备", ToDBValue(工时帐.设备))
					,new SqlParameter("@操作人", ToDBValue(工时帐.操作人))
					,new SqlParameter("@件数", ToDBValue(工时帐.件数))
					,new SqlParameter("@准结", ToDBValue(工时帐.准结))
					,new SqlParameter("@单件", ToDBValue(工时帐.单件))
					,new SqlParameter("@time", ToDBValue(工时帐.Time))
					,new SqlParameter("@计算工号", ToDBValue(工时帐.计算工号))
					,new SqlParameter("@备注", ToDBValue(工时帐.备注))
					,new SqlParameter("@工艺机床", ToDBValue(工时帐.工艺机床))
			};

			return SqlHelper.ExecuteNonQuery(sql, para);
        }		
		
        public 工时帐 GetByID(Guid iD)
        {
            string sql = "SELECT * FROM 工时帐 WHERE ID = @ID";
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
		
		public 工时帐 ToModel(SqlDataReader reader)
		{
			工时帐 工时帐 = new 工时帐();

			工时帐.ID = (Guid)ToModelValue(reader,"ID");
			工时帐.日期 = (DateTime)ToModelValue(reader,"日期");
			工时帐.工号 = (string)ToModelValue(reader,"工号");
			工时帐.图号 = (string)ToModelValue(reader,"图号");
			工时帐.名称 = (string)ToModelValue(reader,"名称");
			工时帐.工序号 = (decimal?)ToModelValue(reader,"工序号");
			工时帐.设备 = (string)ToModelValue(reader,"设备");
			工时帐.操作人 = (string)ToModelValue(reader,"操作人");
			工时帐.件数 = (int)ToModelValue(reader,"件数");
			工时帐.准结 = (decimal)ToModelValue(reader,"准结");
			工时帐.单件 = (decimal)ToModelValue(reader,"单件");
			工时帐.Time = (byte[])ToModelValue(reader,"time");
			工时帐.计算工号 = (string)ToModelValue(reader,"计算工号");
			工时帐.备注 = (string)ToModelValue(reader,"备注");
			工时帐.工艺机床 = (string)ToModelValue(reader,"工艺机床");
			return 工时帐;
		}
		
		public int GetTotalCount()
		{
			string sql = "SELECT count(*) FROM 工时帐";
			return (int)SqlHelper.ExecuteScalar(sql);
		}
		
		public List<工时帐> GetPagedData(int minrownum,int maxrownum)
		{
			string sql = "SELECT * from(SELECT *,row_number() over(order by ID) rownum FROM 工时帐) t where rownum>=@minrownum and rownum<=@maxrownum";
			using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql,
				new SqlParameter("@minrownum",minrownum),
				new SqlParameter("@maxrownum",maxrownum)))
			{
				return ToModels(reader);					
			}
		}
        
        public DataTable GetPagedDataTable(int minrownum,int maxrownum)
		{
			string sql = "SELECT * from(SELECT *,row_number() over(order by ID) rownum FROM 工时帐) t where rownum>=@minrownum and rownum<=@maxrownum";
			using(DataTable dt = SqlHelper.ExecuteDataTable(sql,
				new SqlParameter("@minrownum",minrownum),
				new SqlParameter("@maxrownum",maxrownum)))
			{
				return dt;					
			}
		}
		
		public List<工时帐> GetAll()
		{
			string sql = "SELECT * FROM 工时帐";
			using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql))
			{
				return ToModels(reader);			
			}
		}
		
        public DataTable GetAllDataTable()
		{
			string sql = "SELECT * FROM 工时帐";
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
SELECT row_number() OVER({0}) AS rownum, ID,日期,工号,图号,名称,工序号,设备,操作人,件数,准结,单件,time,计算工号,备注,工艺机床 FROM 工时帐 {1}) t WHERE rownum BETWEEN {2} AND {3}";

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
SELECT row_number() OVER({0}) AS rownum, ID,日期,工号,图号,名称,工序号,设备,操作人,件数,准结,单件,time,计算工号,备注,工艺机床 FROM 工时帐 {1}) t";
                string orderClause = String.IsNullOrEmpty(orderByColumn) ? String.Empty : "ORDER BY " + orderByColumn;
                string whereClause = String.IsNullOrEmpty(searchExpression) ? String.Empty : "WHERE " + searchExpression;
                sql = String.Format(sql, orderClause, whereClause);
                return (int)SqlHelper.ExecuteScalar(sql);
        }
        
		protected List<工时帐> ToModels(SqlDataReader reader)
		{
			var list = new List<工时帐>();
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