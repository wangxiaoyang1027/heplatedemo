using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace 重装板块成本系统.dal
{
    class 销售成本结算DAL
    {

        public SqlDataReader get销售成本结算表(DateTime mydate)
        {

            string sql = @"select ROW_NUMBER() over (order by gh) , rtrim(gh), rtrim(name), je, sjf, ysf , xs , comment from calc_销售成本结算({0}, {1}) order by gh";

            sql = string.Format(sql, mydate.Year, mydate.Month);
            return SqlHelper.ExecuteDataReader(sql);

        }


        public SqlDataReader get铆焊齿轮结算表(DateTime mydate)
        {
            string sql = @"select ROW_NUMBER() over (order by gh) , rtrim(gh), rtrim(name), maohan,clx  from calc_铆焊齿轮成本结算({0}, {1}) order by gh";

            sql = string.Format(sql, mydate.Year, mydate.Month);
            return SqlHelper.ExecuteDataReader(sql);

        }


        public SqlDataReader get内贸利润表(DateTime mydate)
        {
            string sql = @"select  rtrim(f.行业名称) 行业名称, RTRIM(h.产品类别) 产品类别, RTRIM(g.订货单位) 订货单位, a.工号,  e.合同号, RTRIM(e.购货单位) 购货单位, rtrim(e.名称) 名称, a.台份, a.累计重量 ,  isnull(b.当月收入,0),isnull(a.总收入,0) , isnull(d.当月成本,0) 当月成本, isnull(c.总成本,0) 总成本, 
                isnull(b.当月收入,0) - isnull(d.当月成本,0) 当月利润 , isnull(a.总收入,0)- isnull(c.总成本,0) 总利润 , 
    case a.总收入 when  0 then 0 else (isnull(a.总收入,0)-isnull(c.总成本,0))/a.总收入 end    from (select 工号, 台份, 类型, SUM(收入) 总收入 , sum(重量) 累计重量 from 每月收入 where 类型='内贸' AND YEAR(日期) = {0} group by 工号, 台份,类型) a left join 
	(select 工号, 台份, 类型, SUM(收入) 当月收入 from 每月收入 where year(日期) = {0} and month(日期) = {1} and 类型='内贸' group by 工号, 台份, 类型) b on a.工号 = b.工号 left join
	(select 工作令号, SUM(总成本) 总成本 from (
select  工作令号, SUM(金额)*(-1) 总成本 from 成品库房表 where id in ( select id from 成品库房转出表 ) AND YEAR(日期) = {0}  group by 工作令号 
union
select 工作令号, SUM(金额)*(-1) 总成本 from 原始凭证 where 材质 in ('I','K','1','2','N','L','O','U') AND id in (select id from 原始凭证转出表) AND YEAR(日期) = {0} group by 工作令号) k  group by 工作令号 ) c on a.工号 = c.工作令号 left join 
	(select 工作令号, SUM(当月成本) 当月成本 from (
select  工作令号, SUM(金额)*(-1) 当月成本 from 成品库房表 where id in ( select id from 成品库房转出表 ) and year(日期) = {0} and month(日期) = {1} group by 工作令号
union
select  工作令号, SUM(金额)*(-1) 当月成本 from 原始凭证 where id in ( select id from 原始凭证转出表 ) and year(日期) = {0} and month(日期) = {1} and 材质 in ('I','K','1','2','N','L','O','U') group by 工作令号) k group by 工作令号 ) d  on a.工号 = d.工作令号 left join 
	工号表 e on a.工号 = e.工作令号 left join 
	行业类别 f on e.行业类别 = f.id left join 
	订货单位 g on e.订货单位 = g.id left join 
    产品类别 h on e.产品类别 = h.id
	where a.类型='内贸' order by 行业名称, 工号";

            sql = string.Format(sql, mydate.Year, mydate.Month);

            return SqlHelper.ExecuteDataReader(sql);
        }


        public SqlDataReader get外贸利润表(DateTime mydate)
        {
            string sql = @" 	select  rtrim(f.行业名称) 行业名称, RTRIM(h.产品类别) 产品类别,  RTRIM(g.订货单位) 订货单位, a.工号,  e.合同号, RTRIM(e.购货单位) 购货单位, rtrim(e.名称) 名称, a.台份, a.累计重量 ,  
                isnull(b.当月收入,0),isnull(a.总收入,0) , isnull(d.当月成本,0) 当月成本, isnull(c.总成本,0) 总成本, (isnull(b.当月收入,0) - isnull(d.当月成本,0)) 当月利润 , (isnull(a.总收入,0)-isnull(c.总成本,0)) 总利润, 
                0,0,0,0,0,0,0,0,0,0,0,0,0,
                case a.总收入 when  0 then 0 else (isnull(a.总收入,0)-isnull(c.总成本,0))/a.总收入 end from (select 工号, 台份, 类型, SUM(收入) 总收入, sum(重量) 累计重量 from 每月收入 where 类型='外贸' AND YEAR(日期) = {0} group by 工号, 台份,类型) a left join 
	(select 工号, 台份, 类型, SUM(收入) 当月收入 from 每月收入 where year(日期) = {0} and month(日期) = {1} and 类型='外贸' group by 工号, 台份, 类型) b on a.工号 = b.工号 left join
(select 工作令号, SUM(总成本) 总成本 from (
select  工作令号, SUM(金额)*(-1) 总成本 from 成品库房表 where id in ( select id from 成品库房转出表 ) AND YEAR(日期) = {0}  group by 工作令号 
union
select 工作令号, SUM(金额)*(-1) 总成本 from 原始凭证 where 材质 in ('I','K','1','2','N','L','O','U') AND id in (select id from 原始凭证转出表) AND YEAR(日期) = {0} group by 工作令号) k  group by 工作令号 ) c on a.工号 = c.工作令号 left join 
	(select 工作令号, SUM(当月成本) 当月成本 from (
select  工作令号, SUM(金额)*(-1) 当月成本 from 成品库房表 where id in ( select id from 成品库房转出表 ) and year(日期) = {0} and month(日期) = {1} group by 工作令号
union
select  工作令号, SUM(金额)*(-1) 当月成本 from 原始凭证 where id in ( select id from 原始凭证转出表 ) and year(日期) = {0} and month(日期) = {1} and 材质 in ('I','K','1','2','N','L','O','U') group by 工作令号) k group by 工作令号 ) d  on a.工号 = d.工作令号 left join 
	工号表 e on a.工号 = e.工作令号 left join 
	行业类别 f on e.行业类别 = f.id left join 
	订货单位 g on e.订货单位 = g.id left join 
    产品类别 h on e.产品类别 = h.id 
	where a.类型='外贸' order by 行业名称, 工号";

            sql = string.Format(sql, mydate.Year, mydate.Month);

            return SqlHelper.ExecuteDataReader(sql);



        }

        public SqlDataReader get内部交易利润表(DateTime mydate)
        {
            string sql = @" 	select  rtrim(f.行业名称) 行业名称, RTRIM(h.产品类别) 产品类别,  RTRIM(g.订货单位) 订货单位, a.工号,  e.合同号, RTRIM(e.购货单位) 购货单位, rtrim(e.名称) 名称, a.台份, a.累计重量 ,  isnull(b.当月收入,0),isnull(a.总收入,0) , 
    isnull(d.当月成本,0) 当月成本, isnull(c.总成本,0) 总成本, isnull(b.当月收入,0) - isnull(d.当月成本,0) 当月利润 , isnull(a.总收入,0) - isnull(c.总成本,0) 总利润 , 
    case a.总收入 when  0 then 0 else (isnull(a.总收入,0)-isnull(c.总成本,0))/a.总收入 end  from (select 工号, 台份, 类型, SUM(收入) 总收入, sum(重量) 累计重量  from 每月收入 where 类型='内部交易' AND YEAR(日期) = {0} group by 工号, 台份,类型) a left join 
	(select 工号, 台份, 类型, SUM(收入) 当月收入 from 每月收入 where year(日期) = {0} and month(日期) = {1} and 类型='内部交易' group by 工号, 台份, 类型) b on a.工号 = b.工号 left join
	(select  工作令号, SUM(金额)*(-1) 总成本 from 成品库房表 where id in ( select id from 成品库房转出表 ) AND YEAR(日期) = {0} group by 工作令号 ) c on a.工号 = c.工作令号 left join 
	(select  工作令号, SUM(金额)*(-1) 当月成本 from 成品库房表 where id in ( select id from 成品库房转出表 ) and year(日期) = {0} and month(日期) = {1} group by 工作令号 ) d  on a.工号 = d.工作令号 left join 
	工号表 e on a.工号 = e.工作令号 left join 
	行业类别 f on e.行业类别 = f.id left join 
	订货单位 g on e.订货单位 = g.id left join 
    产品类别 h on e.产品类别 = h.id 
	where a.类型='内部交易' order by 行业名称, 工号";

            sql = string.Format(sql, mydate.Year, mydate.Month);

            return SqlHelper.ExecuteDataReader(sql);



        }

        public void removedate(string id)
        {
            string sql = @"delete 成品库房表 where id='{0}'";

            sql = string.Format(sql, id);
            SqlHelper.ExecuteNonQuery(sql);

            sql = @"delete 成品库房转出表 where id='{0}'";
            sql = string.Format(sql, id);
            SqlHelper.ExecuteNonQuery(sql);

        }

        public SqlDataReader get库房明细报表( DateTime mydate)
        {
            string sql = @"select row_number() over ( order by t.工号, t.时间),rtrim(t.工号),rtrim(t1.工号类型) 工号类型, t.时间, t.主机厂, 铁业配套, 自动化配套, 设计费, 运输费, 安装费, 其它, 销售结余, 国际结余 
                        from ( SELECT a.id, rtrim(a.工作令号) 工号, rtrim(str(year(a.日期), 4) + '年' + 
                        str(MONTH(a.日期), 2) + '月' + CASE WHEN b.id IS NOT NULL THEN '转出' ELSE '' END) 时间, 
                        a.金额 主机厂 , a.铁业配套, a.自动化配套, a.设计费, a.运输费, a.安装费, a.其它, a.销售结余, a.国际结余 FROM  成品库房表 a LEFT JOIN   成品库房转出表 b ON a.id = b.id where YEAR(日期)<{0} or (YEAR(日期)={0} and MONTH(日期)<={1})
                        UNION
                        SELECT     newid(), rtrim(工作令号) 工号, '小计', SUM(金额), sum(铁业配套), sum(自动化配套), sum(设计费), sum(运输费), sum(安装费), SUM(其它), SUM(销售结余), sum(国际结余)
                        FROM         成品库房表 where  YEAR(日期)<{0} or ( YEAR(日期)={0} and MONTH(日期)<={1}) GROUP BY 工作令号
                        union
                        SELECT     newid(), '合计', '', SUM(金额), sum(铁业配套), sum(自动化配套), sum(设计费), sum(运输费), sum(安装费), SUM(其它), SUM(销售结余), sum(国际结余)
                        FROM         成品库房表 where  YEAR(日期)<{0} or ( YEAR(日期)={0} and MONTH(日期)<={1})
                        ) t left join 工号表 t1 on t.工号 = t1.工作令号  ";
            sql = string.Format(sql, mydate.Year, mydate.Month);
            return SqlHelper.ExecuteDataReader(sql);
        }


    }
}
