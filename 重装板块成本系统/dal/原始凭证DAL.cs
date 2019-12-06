using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using 重装板块成本系统.model;


namespace 重装板块成本系统.dal
{
	public partial class 原始凭证DAL
	{
        public DataTable getDataPerMonth( string searchstr)
        {
            string sql = @"select id, convert(nchar(10),日期,111) 日期 , rtrim(凭证号) 凭证号, b.材质名称, rtrim(工作令号) 工作令号, 重量, 金额 
                from 原始凭证 a left join 材质类别表 b on a.材质=b.材质类别 where id not in (select id from 原始凭证转出表) " + searchstr + " order by 凭证号" ;

            return SqlHelper.ExecuteDataTable(sql);
        }

        // 按月统计一个单位的 原材料数据
        public DataTable getAccountPerMonth( int deptcode , DateTime mydate)
        {
            string sql = @"select b.材质名称, sum(a.重量) 重量 , sum(a.金额) 金额 from 原始凭证 a 
                left join 材质类别表 b on a.材质=b.材质类别  where a.id not in (select id from 原始凭证转出表) 
                and year(a.日期) = {0} and month(a.日期)={1} and 单位 = {2} group by b.材质名称";

            sql = string.Format(sql, mydate.Year, mydate.Month, deptcode);

            return SqlHelper.ExecuteDataTable(sql);
        }

        // 统计一个 凭证号 的数据
        public DataTable getAccountPerMonth_Pzh( int deptcode , string pz, DateTime mydate)
        {
            string sql = @"select b.材质名称, sum(a.重量) 重量 , sum(a.金额) 金额 from 原始凭证 a 
                left join 材质类别表 b on a.材质=b.材质类别  where a.id not in (select id from 原始凭证转出表) 
                and year(a.日期) = {0} and month(a.日期)={1} and 单位 = {2} and 凭证号='{3}' group by b.材质名称";


            sql = string.Format(sql, mydate.Year, mydate.Month, deptcode, pz);
            return SqlHelper.ExecuteDataTable(sql);


        }

        public void addOut( 原始凭证 mod)
        {
            Add(mod);

            add原始凭证转出(mod.Id.ToString());

        }



        public void add原始凭证转出(string id)
        {
            string sql = @"insert into 原始凭证转出表 values('{0}')";
            sql = string.Format(sql, id);
            SqlHelper.ExecuteNonQuery(sql);

        }


        public SqlDataReader get原始凭证报表(DateTime mydate)
        {
            string sql = @"select rtrim(gh) gh , rtrim(ny) ny, ztsl,ztje,yssl,ysje,zgsl,zgje,sysl,syje,djsl,djje,mhje, 
blje,bzje,wgje,ptje,clxje,xsptj , mhptj ,zj   from funget_yspz_report({0},{1}) WHERE ZJ <> 0 order by gh,ny  ";

            sql = string.Format(sql, mydate.Year, mydate.Month);

            return SqlHelper.ExecuteDataReader(sql);

        }


        public SqlDataReader get原始凭证成本报表(DateTime mydate)
        {
            string sql = @"select ROW_NUMBER() over(order by gh,ny) , gh, ztsl,ztje,yssl,ysje,zgsl,zgje,sysl,syje,djsl,djje,mhje, 
blje,bzje,wgje,ptje,clxje,xsptj ,zj	from funget_yspz_report({0},{1}) where ny ='小计' and zj <> 0 order by gh,ny  ";

            sql = string.Format(sql, mydate.Year, mydate.Month);

            return SqlHelper.ExecuteDataReader(sql);

        }




        public SqlDataReader get本厂原始凭证报表(DateTime mydate, int deptcode)
        {
            string sql = @"select * from funget_fc_yspz_report({0},{1},{2}) order by gh,ny   ";

            sql = string.Format(sql, mydate.Year, mydate.Month, deptcode);

            return SqlHelper.ExecuteDataReader(sql);

        }





        public DataTable get原材料明细( int myyear, int mymonth , string workno)
        {
            string sql = @"select  rtrim(工作令号) 工作令号, rtrim(ny) 年月, rtrim(凭证号) 凭证号, 
SUM( case 材质名称 when '铸铁件' then 重量 else 0 end) 铸铁重量,
SUM( case 材质名称 when '铸铁件' then 金额 else 0 end) 铸铁金额,
SUM( case 材质名称 when '有色件' then 重量 else 0 end) 有色重量,
SUM( case 材质名称 when '有色件' then 金额 else 0 end) 有色金额,
SUM( case 材质名称 when '铸钢件' then 重量 else 0 end) 铸钢重量,
SUM( case 材质名称 when '铸钢件' then 金额 else 0 end) 铸钢金额,
SUM( case 材质名称 when '水压机' then 重量 else 0 end) 水压件重量,
SUM( case 材质名称 when '水压机' then 金额 else 0 end) 水压件金额,
SUM( case 材质名称 when '铸锻件' then 重量 else 0 end) 锻件重量,
SUM( case 材质名称 when '铸锻件' then 金额 else 0 end) 锻件金额,
SUM( case 材质名称 when '铆焊件' then 金额 else 0 end) 铆焊金额,
SUM( case 材质名称 when '备料件' then 金额 else 0 end) 备料金额,
SUM( case 材质名称 when '标准件' then 金额 else 0 end) 标准件金额,
SUM( case 材质名称 when '外购件' then 金额 else 0 end) 外购件金额,
SUM( case 材质名称 when '配套件' then 金额 else 0 end) 配套件金额,
SUM( case 材质名称 when '齿轮箱配套' then 金额 else 0 end) 齿轮箱配套,
SUM( case 材质名称 when '专项费用' then 金额 else 0 end) 专项费用,
SUM( case 材质名称 when '热处理费' then 金额 else 0 end) 热处理费,
SUM( case 材质名称 when '外加工费' then 金额 else 0 end) 外加工费,
SUM( case 材质名称 when '包装费' then 金额 else 0 end) 包装费,
SUM( case 材质名称 when '设计费' then 金额 else 0 end) 设计费,
SUM( case 材质名称 when '运输费' then 金额 else 0 end) 运输费,
SUM( case 材质名称 when '销售配套件' then 金额 else 0 end) 销售配套件
from ( 
select 工作令号, 操作,材质名称, 凭证号,ny ,sum(重量) 重量, sum(金额) 金额 from View_原始凭证ALL where YEAR(日期)={0} and MONTH(日期)={1} and 工作令号='{2}' group by 工作令号, 操作,材质名称,凭证号,ny ) a
group by  工作令号, ny, 凭证号 ";

            sql = string.Format(sql, myyear, mymonth, workno);
            return SqlHelper.ExecuteDataTable(sql);
        }





        public DataTable get本厂原材料明细(int myyear, int mymonth, string workno)
        {
            string sql = @"select  rtrim(工作令号) 工作令号, rtrim(ny) 年月, rtrim(凭证号) 凭证号, 
SUM( case 材质名称 when '铸铁件' then 重量 else 0 end) 铸铁重量,
SUM( case 材质名称 when '铸铁件' then 金额 else 0 end) 铸铁金额,
SUM( case 材质名称 when '有色件' then 重量 else 0 end) 有色重量,
SUM( case 材质名称 when '有色件' then 金额 else 0 end) 有色金额,
SUM( case 材质名称 when '铸钢件' then 重量 else 0 end) 铸钢重量,
SUM( case 材质名称 when '铸钢件' then 金额 else 0 end) 铸钢金额,
SUM( case 材质名称 when '水压机' then 重量 else 0 end) 水压件重量,
SUM( case 材质名称 when '水压机' then 金额 else 0 end) 水压件金额,
SUM( case 材质名称 when '铸锻件' then 重量 else 0 end) 锻件重量,
SUM( case 材质名称 when '铸锻件' then 金额 else 0 end) 锻件金额,
SUM( case 材质名称 when '铆焊件' then 金额 else 0 end) 铆焊金额,
SUM( case 材质名称 when '备料件' then 金额 else 0 end) 备料金额,
SUM( case 材质名称 when '标准件' then 金额 else 0 end) 标准件金额,
SUM( case 材质名称 when '外购件' then 金额 else 0 end) 外购件金额,
SUM( case 材质名称 when '配套件' then 金额 else 0 end) 配套件金额,
SUM( case 材质名称 when '专项费用' then 金额 else 0 end) 专项费用,
SUM( case 材质名称 when '热处理费' then 金额 else 0 end) 热处理费,
SUM( case 材质名称 when '外加工费' then 金额 else 0 end) 外加工费,
SUM( case 材质名称 when '包装费' then 金额 else 0 end) 包装费,
SUM( case 材质名称 when '销售配套件' then 金额 else 0 end) 销售配套件
from ( 
select 工作令号, 操作,材质名称, 凭证号,ny ,sum(重量) 重量, sum(金额) 金额 from View_本厂原始凭证ALL where YEAR(日期)={0} and MONTH(日期)={1} and 工作令号='{2}' group by 工作令号, 操作,材质名称,凭证号,ny ) a
group by  工作令号, ny, 凭证号 ";

            sql = string.Format(sql, myyear, mymonth, workno);
            return SqlHelper.ExecuteDataTable(sql);
        }



        // 由材质 ， 工号得到 一个原始凭证的所属单位， 这个主要是为 销售公司， 国际公司做。 
        public string getSaleDeptForWorkno( string workno, string caizhi)
        {
            string sql = @"select 单位 from 原始凭证 where 工作令号='{0}' and 材质='{1}'";

            sql = string.Format(sql, workno, caizhi);
            return SqlHelper.ExecuteScalar(sql).ToString();



        }

        //  以上是 手动增加的功能

        public 原始凭证 Add(原始凭证 原始凭证)
		{
				string sql ="INSERT INTO 原始凭证 (id, 日期, 凭证号, 材质, 工作令号, 重量, 金额, 单位)  VALUES (@id, @日期, @凭证号, @材质, @工作令号, @重量, @金额, @单位)";
				SqlParameter[] para = new SqlParameter[]
					{
						new SqlParameter("@id", ToDBValue(原始凭证.Id)),
						new SqlParameter("@日期", ToDBValue(原始凭证.日期)),
						new SqlParameter("@凭证号", ToDBValue(原始凭证.凭证号)),
						new SqlParameter("@材质", ToDBValue(原始凭证.材质)),
						new SqlParameter("@工作令号", ToDBValue(原始凭证.工作令号)),
						new SqlParameter("@重量", ToDBValue(原始凭证.重量)),
						new SqlParameter("@金额", ToDBValue(原始凭证.金额)),
						new SqlParameter("@单位", ToDBValue(原始凭证.单位)),
					};
				SqlHelper.ExecuteNonQuery(sql, para);
				return 原始凭证;				
		}

        public int DeleteById(Guid id)
		{
            string sql = "DELETE 原始凭证 WHERE Id = @Id";

           SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@id", id)
			};
		
            return SqlHelper.ExecuteNonQuery(sql, para);
		}
		
				
        public int Update(原始凭证 原始凭证)
        {
            string sql =
                "UPDATE 原始凭证 " +
                "SET " +
			" 日期 = @日期" 
                +", 凭证号 = @凭证号" 
                +", 材质 = @材质" 
                +", 工作令号 = @工作令号" 
                +", 重量 = @重量" 
                +", 金额 = @金额" 
                +", 单位 = @单位" 
               
            +" WHERE id = @id";


			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@id", 原始凭证.Id)
					,new SqlParameter("@日期", ToDBValue(原始凭证.日期))
					,new SqlParameter("@凭证号", ToDBValue(原始凭证.凭证号))
					,new SqlParameter("@材质", ToDBValue(原始凭证.材质))
					,new SqlParameter("@工作令号", ToDBValue(原始凭证.工作令号))
					,new SqlParameter("@重量", ToDBValue(原始凭证.重量))
					,new SqlParameter("@金额", ToDBValue(原始凭证.金额))
					,new SqlParameter("@单位", ToDBValue(原始凭证.单位))
			};

			return SqlHelper.ExecuteNonQuery(sql, para);
        }		
		
        public 原始凭证 GetById(Guid id)
        {
            string sql = "SELECT * FROM 原始凭证 WHERE Id = @Id";
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
		
		public 原始凭证 ToModel(SqlDataReader reader)
		{
			原始凭证 原始凭证 = new 原始凭证();

			原始凭证.Id = (Guid)ToModelValue(reader,"id");
			原始凭证.日期 = (DateTime)ToModelValue(reader,"日期");
			原始凭证.凭证号 = (string)ToModelValue(reader,"凭证号");
			原始凭证.材质 = (string)ToModelValue(reader,"材质");
			原始凭证.工作令号 = (string)ToModelValue(reader,"工作令号");
			原始凭证.重量 = (decimal?)ToModelValue(reader,"重量");
			原始凭证.金额 = (decimal)ToModelValue(reader,"金额");
			原始凭证.单位 = (short)ToModelValue(reader,"单位");
			return 原始凭证;
		}
		
		public int GetTotalCount()
		{
			string sql = "SELECT count(*) FROM 原始凭证";
			return (int)SqlHelper.ExecuteScalar(sql);
		}
		
		public List<原始凭证> GetPagedData(int minrownum,int maxrownum)
		{
			string sql = "SELECT * from(SELECT *,row_number() over(order by id) rownum FROM 原始凭证) t where rownum>=@minrownum and rownum<=@maxrownum";
			using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql,
				new SqlParameter("@minrownum",minrownum),
				new SqlParameter("@maxrownum",maxrownum)))
			{
				return ToModels(reader);					
			}
		}
        
        public DataTable GetPagedDataTable(int minrownum,int maxrownum)
		{
			string sql = "SELECT * from(SELECT *,row_number() over(order by id) rownum FROM 原始凭证) t where rownum>=@minrownum and rownum<=@maxrownum";
			using(DataTable dt = SqlHelper.ExecuteDataTable(sql,
				new SqlParameter("@minrownum",minrownum),
				new SqlParameter("@maxrownum",maxrownum)))
			{
				return dt;					
			}
		}
		
		public List<原始凭证> GetAll()
		{
			string sql = "SELECT * FROM 原始凭证";
			using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql))
			{
				return ToModels(reader);			
			}
		}
		
        public DataTable GetAllDataTable()
		{
			string sql = "SELECT * FROM 原始凭证";
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
SELECT row_number() OVER({0}) AS rownum, id,日期,凭证号,材质,工作令号,重量,金额,单位 FROM 原始凭证 {1}) t WHERE rownum BETWEEN {2} AND {3}";

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
SELECT row_number() OVER({0}) AS rownum, id,日期,凭证号,材质,工作令号,重量,金额,单位 FROM 原始凭证 {1}) t";
                string orderClause = String.IsNullOrEmpty(orderByColumn) ? String.Empty : "ORDER BY " + orderByColumn;
                string whereClause = String.IsNullOrEmpty(searchExpression) ? String.Empty : "WHERE " + searchExpression;
                sql = String.Format(sql, orderClause, whereClause);
                return (int)SqlHelper.ExecuteScalar(sql);
        }
        
		protected List<原始凭证> ToModels(SqlDataReader reader)
		{
			var list = new List<原始凭证>();
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