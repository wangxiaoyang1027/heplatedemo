using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace 重装板块成本系统.dal
{
    public class 在制品DAL
    {

        public DataTable get在制品(DateTime mydate )
        {
            string sql = @"select * from calc_zzp({0},{1})";
            sql = string.Format(sql, mydate.Year, mydate.Month);

            return SqlHelper.ExecuteDataTable(sql);


        }

        public DataTable get在制品( DateTime mydate , int deptcode )
        {
            string sql = @"select rtrim(gh) 工号, rtrim(ny) 年月, c1 原材料, c2 燃料动力, c3 定额工时, c4 折合工时, c5 工资福利, c6 专项费用, 
    c7 制造费用, c8 外加工费, c9 热处理费, c10 包装费, c11 设计费, c12 运输费  from calc_zzp({0},{1}) where dept ={2} order by gh,ny";

            sql = string.Format(sql, mydate.Year ,mydate.Month , deptcode);

            return SqlHelper.ExecuteDataTable(sql);


        }


        public SqlDataReader  get在制品Reader(DateTime mydate, int deptcode)
        {
            //        string sql = @"select rtrim(gh) 工号, rtrim(ny) 年月, c1 原材料, c2 燃料动力, c3 定额工时, c4 折合工时, c5 工资福利, c6 专项费用, 
            //c7 制造费用, c8 外加工费, c9 热处理费, c10 包装费, c11 设计费, c12 运输费  from calc_union_zzp({0},{1}) where dept ={2} order by gh,ny";
            string sql = @"select rtrim(gh) 工号, rtrim(ny) 年月, c1 原材料, c2 燃料动力, c3 定额工时, c4 折合工时, c5 工资福利, c6 专项费用, 
    c7 制造费用, c8 外加工费, c9 热处理费, c10 包装费, c11 设计费, c12 运输费  from calc_union_zzp({0},{1})  order by gh,ny";

            sql = string.Format(sql, mydate.Year, mydate.Month, deptcode);

            return SqlHelper.ExecuteDataReader(sql);


        }


        public SqlDataReader get成本明细()
        {
            DateTime mydate = DateTime.Now;

            string sql = @"select rtrim(gh) 工号, rtrim(ny) 年月, c1 原材料, c2 燃料动力, c3 定额工时, c4 折合工时, c5 工资福利, c6 专项费用, 
    c7 制造费用, c8 外加工费, c9 热处理费, c10 包装费, c11 设计费, c12 运输费 ,c13 合计 from calc_union_zzp({0},{1})  order by gh,ny";

            sql = string.Format(sql, mydate.Year, mydate.Month);

            return SqlHelper.ExecuteDataReader(sql);
        }


        public SqlDataReader 导出成本(DateTime mydate)
        {
            string sql = @"select row_number() over (order by gh), rtrim(a.gh), rtrim(b.名称), c.台份,c.重量, c1,c2,c3,c4,c5,c6,c7,c8,c9,c10,c11,c12,c13   from calc_union_zzp ({0},{1}) a 
                left join 工号表 b on gh=工作令号 left join 每月收入 c on a.gh=c.工号 where ny ='小计' and c13 <> 0 order by gh";

            sql = string.Format(sql, mydate.Year, mydate.Month);

            return SqlHelper.ExecuteDataReader(sql);


        }


        public SqlDataReader 导出在制品卡片(DateTime mydate)
        {
            string sql = @"select *  from calc_union_zzp ({0},{1})  order by gh,ny ";

            sql = string.Format(sql, mydate.Year, mydate.Month);

            return SqlHelper.ExecuteDataReader(sql);


        }

        public SqlDataReader 导出新版在制品卡片(DateTime mydate, int deptcode)
        {
                string sql = @"select ROW_NUMBER() over(order by gh, ny) , rtrim(gh) 工号, rtrim(b.名称) ,  c13, c1 原材料, case when b.工号类型='正常' 
                    then '' else b.工号类型 end 工号类型  from calc_union_zzp({0},{1}) a left join 工号表  b on a.gh=b.工作令号  where  ny = '小计' and ( c1<>0 or c13 <> 0 )order by gh,ny";

                sql = string.Format(sql, mydate.Year, mydate.Month, deptcode);

            return SqlHelper.ExecuteDataReader(sql);


        }

        public SqlDataReader 导出本厂在制品卡片(DateTime mydate, int deptcode)
        {
            //        string sql = @"select rtrim(gh) 工号, rtrim(ny) 年月, c1 原材料, c2 燃料动力, c3 定额工时, c4 折合工时, c5 工资福利, c6 专项费用, 
            //c7 制造费用, c8 外加工费, c9 热处理费, c10 包装费, c13  from calc_zzp({0},{1})  where dept={2} and c13 !=0 order by gh,ny";

            string sql = @"select rtrim(gh) 工号, rtrim(ny) 年月, c1 原材料, c2 燃料动力, c3 定额工时, c4 折合工时, c5 工资福利, c6 专项费用, 
            c7 制造费用, c8 外加工费, c9 热处理费, c10 包装费, c13  from calc_zzp({0},{1})  where dept={2}  order by gh,ny";


            //        string sql = @"select rtrim(gh) 工号, rtrim(ny) 年月, c1 原材料, c2 燃料动力, c3 定额工时, c4 折合工时, c5 工资福利, c6 专项费用, 
            //c7 制造费用, c8 外加工费, c9 热处理费, c10 包装费, c13  from calc_zzp({0},{1})  where dept={2} 
            //and ( c1<>0 or c2<>0 or c3<>0 or c4<>0 or c5<>0 or c6 <> 0 or c7<>0 or c8<>0 or c9<>0 or c10 <> 0 or c13<> 0  )   order by gh,ny";

            sql = string.Format(sql, mydate.Year, mydate.Month, deptcode);

            return SqlHelper.ExecuteDataReader(sql);


        }







        public SqlDataReader 导出本厂新版在制品卡片(DateTime mydate, int deptcode)
        {
            string sql = @"select ROW_NUMBER() over(order by gh, ny) , rtrim(gh) 工号, rtrim(b.名称) ,  c13, c1 原材料, case when b.工号类型='正常' 
                    then '' else b.工号类型 end 工号类型  from calc_zzp({0},{1}) a left join 工号表  b on a.gh=b.工作令号 where dept ={2} and ny = '小计' and c13 !=0 order by gh,ny";

            sql = string.Format(sql, mydate.Year, mydate.Month, deptcode);

            return SqlHelper.ExecuteDataReader(sql);


        }


    }
}
