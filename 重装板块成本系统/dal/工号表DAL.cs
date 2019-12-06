using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using 重装板块成本系统.model;

namespace 重装板块成本系统.dal
{
	public partial class 工号表DAL
	{
        // 自增加过程
        public bool IsIn工号表(string workno)
        {
            string sql = @"select 工作令号 from 工号表 where 工作令号='{0}' and noused=0";
            sql = string.Format(sql, workno);
            SqlDataReader dr = SqlHelper.ExecuteDataReader(sql);

            bool retval;

            retval = dr.HasRows;
            dr.Close();
            return retval;
        }

        // 得到可用工号
        public DataTable GetDataTable()
        {
            string sql = "SELECT rtrim(工作令号) 工作令号, rtrim(名称) 名称  FROM 工号表 where noused = 0 ";
            using (DataTable dt = SqlHelper.ExecuteDataTable(sql))
            {
                return dt;
            }
        }

        public DataTable get行业类别()
        {
            string sql = @"select id, rtrim(行业名称) 行业名称 from 行业类别";
            return SqlHelper.ExecuteDataTable(sql);
        }






        public DataTable get产品类别()
        {
            string sql = @"select id, rtrim(产品类别) 产品类别 from 产品类别";
            return SqlHelper.ExecuteDataTable(sql);
        }

        public DataTable get订货单位()
        {
            string sql = @"select id, rtrim(订货单位) 订货单位 from 订货单位";
            return SqlHelper.ExecuteDataTable(sql);

        }

        public DataTable get工号类型()
        {
            string sql = @"select rtrim(工号类型) 工号类型 from 工号类型";

            return SqlHelper.ExecuteDataTable(sql);
        }


        public SqlDataReader get完工工号表(DateTime mydate)
        {
            string sql = @"select rtrim(a.工作令号), rtrim(a.名称),  case when b.月份 is not null then 1 else 0 end 完工 
        from 工号表 a left join (select 工号, 月份 from 每月完工工号表 where year(月份)={0} and year(月份)={1} ) b on a.工作令号 = b.工号 ";

            sql = string.Format(sql, mydate.Year, mydate.Month);

            return SqlHelper.ExecuteDataReader(sql);


        }


        



        // 以上是手工增加的功能


        public 工号表 Add(工号表 工号表)
		{
				string sql = "INSERT INTO 工号表 (工作令号,名称, noused, nocalc,行业类别,产品类别,合同号,订货单位,购货单位,工号类型)  " +
                    "VALUES (@工作令号,@名称, @noused,@nocalc,@行业类别,@产品类别,@合同号,@订货单位,@购货单位, @工号类型)";
				SqlParameter[] para = new SqlParameter[]
					{
						new SqlParameter("@工作令号", ToDBValue(工号表.工作令号)),
						new SqlParameter("@名称", ToDBValue(工号表.名称)),
						new SqlParameter("@noused", ToDBValue(工号表.Noused)),
                        new SqlParameter("@nocalc", ToDBValue(工号表.Nocalc))
                         ,new SqlParameter("@行业类别", ToDBValue(工号表.行业类别))
                    ,new SqlParameter("@产品类别", ToDBValue(工号表.产品类别))
                    ,new SqlParameter("@合同号", ToDBValue(工号表.合同号))
                    ,new SqlParameter("@订货单位", ToDBValue(工号表.订货单位))
                     ,new SqlParameter("@购货单位", ToDBValue(工号表.购货单位))
                     ,new SqlParameter("@工号类型", ToDBValue(工号表.工号类型))
                    };
				SqlHelper.ExecuteNonQuery(sql, para);
				return 工号表;				
		}

        public int DeleteBy工作令号(string 工作令号)
		{
            string sql = "DELETE 工号表 WHERE 工作令号 = @工作令号";

           SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@工作令号", 工作令号)
			};
		
            return SqlHelper.ExecuteNonQuery(sql, para);
		}
		
				
        public int Update(工号表 工号表 , string old_workno)
        {
            string sql =
                "UPDATE 工号表 " +
                "SET " +
                " 工作令号 = @工作令号"+
                " ,名称 = @名称" 
                +", noused = @noused" 
                +", nocalc =@nocalc"
                +", 行业类别 = @行业类别"
              + ", 产品类别 = @产品类别"
              + ", 合同号 = @合同号"
              + ", 订货单位 = @订货单位"
              + ", 购货单位 = @购货单位"
              + ", 工号类型 = @工号类型"
            + " WHERE 工作令号 = @old_workno";


			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@工作令号", 工号表.工作令号)
					,new SqlParameter("@名称", ToDBValue(工号表.名称))
					,new SqlParameter("@noused", ToDBValue(工号表.Noused))
                    ,new SqlParameter("@nocalc", ToDBValue(工号表.Nocalc))
                    ,new SqlParameter("@行业类别", ToDBValue(工号表.行业类别))
                    ,new SqlParameter("@产品类别", ToDBValue(工号表.产品类别))
                    ,new SqlParameter("@合同号", ToDBValue(工号表.合同号))
                    ,new SqlParameter("@订货单位", ToDBValue(工号表.订货单位))
                     ,new SqlParameter("@购货单位", ToDBValue(工号表.购货单位))
                      ,new SqlParameter("@工号类型", ToDBValue(工号表.工号类型))
                      ,new SqlParameter("@old_workno", ToDBValue(old_workno))
            };

			return SqlHelper.ExecuteNonQuery(sql, para);
        }

        public 工号表 GetBy工作令号(string 工作令号)
        {
            string sql = "SELECT 工作令号, 名称, noused, nocalc, isnull(行业类别,0) 行业类别, isnull(产品类别,0) 产品类别 , 合同号, 购货单位, isnull(订货单位,0) 订货单位, 工号类型 FROM 工号表 WHERE 工作令号 = @工作令号";
            using (SqlDataReader reader = SqlHelper.ExecuteDataReader(sql, new SqlParameter("@工作令号", 工作令号)))
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

        public 工号表 ToModel(SqlDataReader reader)
        {
            工号表 工号表 = new 工号表();

            工号表.工作令号 = (string)ToModelValue(reader, "工作令号");
            工号表.名称 = (string)ToModelValue(reader, "名称");
            工号表.Noused = (bool)ToModelValue(reader, "noused");
            工号表.Nocalc = (bool)ToModelValue(reader, "nocalc");
            工号表.行业类别 = (short)ToModelValue(reader, "行业类别");
            工号表.产品类别 = (short)ToModelValue(reader, "产品类别");
            工号表.合同号 = (string)ToModelValue(reader, "合同号");
            工号表.购货单位 = (string)ToModelValue(reader, "购货单位");
            工号表.订货单位 = (short)ToModelValue(reader, "订货单位");
            工号表.工号类型 = (string)ToModelValue(reader, "工号类型");

            return 工号表;
        }

        public int GetTotalCount()
		{
			string sql = "SELECT count(*) FROM 工号表";
			return (int)SqlHelper.ExecuteScalar(sql);
		}
		
		public List<工号表> GetPagedData(int minrownum,int maxrownum)
		{
			string sql = "SELECT * from(SELECT *,row_number() over(order by 工作令号) rownum FROM 工号表) t where rownum>=@minrownum and rownum<=@maxrownum";
			using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql,
				new SqlParameter("@minrownum",minrownum),
				new SqlParameter("@maxrownum",maxrownum)))
			{
				return ToModels(reader);					
			}
		}
        
        public DataTable GetPagedDataTable(int minrownum,int maxrownum)
		{
			string sql = "SELECT * from(SELECT *,row_number() over(order by 工作令号) rownum FROM 工号表) t where rownum>=@minrownum and rownum<=@maxrownum";
			using(DataTable dt = SqlHelper.ExecuteDataTable(sql,
				new SqlParameter("@minrownum",minrownum),
				new SqlParameter("@maxrownum",maxrownum)))
			{
				return dt;					
			}
		}
		
		public List<工号表> GetAll()
		{
			string sql = "SELECT * FROM 工号表";
			using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql))
			{
				return ToModels(reader);			
			}
		}
		
        public DataTable GetAllDataTable()
		{
			string sql = @"SELECT rtrim(工作令号), rtrim(名称), noused, nocalc , rtrim(isnull(合同号,'')) 合同号, rtrim(isnull(b.行业名称,'')) 行业名称, rtrim(isnull(c.产品类别,'')) 产品列表, 
                                rtrim(isnull(d.订货单位,'')) 订货单位, rtrim(isnull(购货单位,'')) 购货单位 , rtrim(工号类型) 工号类型
                            FROM 工号表 a left join 行业类别 b on a.行业类别=b.id left join 产品类别 c on a.产品类别= c.id left join 订货单位 d on a.订货单位= d.id ";
			using(DataTable dt = SqlHelper.ExecuteDataTable(sql))
			{
				return dt;			
			}
		}

        public DataTable GetDataTableByWorkno( string workno)
        {
            string sql = @"SELECT rtrim(工作令号), rtrim(名称), noused, nocalc , rtrim(isnull(合同号,'')) 合同号, rtrim(isnull(b.行业名称,'')) 行业名称, rtrim(isnull(c.产品类别,'')) 产品类别, 
                                rtrim(isnull(d.订货单位, '')) 订货单位, rtrim(isnull(购货单位, '')) 购货单位, rtrim(工号类型) 工号类型
                              FROM 工号表 a left join 行业类别 b on a.行业类别 = b.id left join 产品类别 c on a.产品类别 = c.id left join 订货单位 d on a.订货单位= d.id where 工作令号 like '%{0}%'";
            sql = string.Format(sql, workno);
            using (DataTable dt = SqlHelper.ExecuteDataTable(sql))
            {
                return dt;
            }
        }

        protected List<工号表> ToModels(SqlDataReader reader)
		{
			var list = new List<工号表>();
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