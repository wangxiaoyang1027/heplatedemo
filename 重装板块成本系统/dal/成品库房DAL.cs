using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using 重装板块成本系统.model;

namespace 重装板块成本系统.dal
{
    class 成品库房DAL
    {

        public DataTable getinfo(string workno)
        {
            DataTable dt = new DataTable();
            string sql;

            if (workno == "")
            {
                sql = @"select * from 成品库房表";
            }
            else
            {
                sql = @"select * from 成品库房表 where 工作令号='{0}'";
                sql = string.Format(sql, workno);
            }

            dt = SqlHelper.ExecuteDataTable(sql);
            return dt;

            

        }


        public void update成品库房表(Guid id , decimal cost)
        {
            string sql = @"update 成品库房表 set 金额={1} where id ='{0}'";

            sql = string.Format(sql, id, cost);
            SqlHelper.ExecuteNonQuery(sql);
        }

        public void update成品库房表(成品库房表 成品库房)
        {


            del成品库房表_转出(成品库房.工作令号, 成品库房.日期);

            


        }

        public void update成品库房表(string id, string gh, DateTime mydate ,  decimal cost)
        {
            string sql = @"update 成品库房表 set 工作令号='{1}',日期={2},金额={3} where id ='{0}'";

            sql = string.Format(sql, id, gh, mydate, cost);

            SqlHelper.ExecuteNonQuery(sql);
        }

        public void del成品库房表ById(string id)
        {
            string sql = @"delete 成品库房表 where id='{0}'";

            sql = string.Format(sql, id);
            SqlHelper.ExecuteNonQuery(sql);
        }


        public void del成品库房表_转出(string workno, DateTime mydate)
        {
            // 转出 “本厂成本”
            string sql = @"delete 成品库房表 where 工作令号='{0}' and id in (select id from 成品库房转出表 ) and year(日期)= {1} and month(日期)={2}";

            sql = string.Format(sql, workno, mydate.Year, mydate.Month);

            SqlHelper.ExecuteNonQuery(sql);

            sql = @"delete 成品库房转出表 where id not in (select id from 成品库房表  )";
            SqlHelper.ExecuteNonQuery(sql);


            // 转出 “销售成本”
            sql = @"delete  原始凭证 where 工作令号='{0}' and 材质 in ('I','K','1','2','N','L','O','U') 
                    and id in (select id from 原始凭证转出表 ) and year(日期)= {1} and month(日期)={2}";
            sql = string.Format(sql, workno, mydate.Year, mydate.Month);
            SqlHelper.ExecuteNonQuery(sql);

            sql = "delete 原始凭证转出表 where id not in (select id from 原始凭证)";
            SqlHelper.ExecuteNonQuery(sql);



        }

        public void insert成品库房表 (成品库房表 成品库房)
        {
            string sql = @"insert into 成品库房表(id, 工作令号, 日期, 金额 ) values( @p0,@p1,@p2,@p3)";

            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("p0", 成品库房.id),
                new SqlParameter ("p1",成品库房.工作令号),
                new SqlParameter("p2", 成品库房.日期),
                new SqlParameter("p3", 成品库房.金额),
                //new SqlParameter("p4", 成品库房.ty),
                //new SqlParameter("p5", 成品库房.zdh),
                //new SqlParameter("p6", 成品库房.sj),
                //new SqlParameter ("p7", 成品库房.ys),
                //new SqlParameter ("p8", 成品库房.az )

            };

            SqlHelper.ExecuteNonQuery(sql, para);


        }


        // 插入 转出数据
        public void insert成品库房表_转出(成品库房表 成品库房)
        {

            // 首先插入 成品库房表中的 金额
          
            string sql = @"insert into 成品库房表(id, 工作令号, 日期, 金额 ) values( @p0,@p1,@p2,@p3)";

            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("p0", 成品库房.id),
                new SqlParameter ("p1",成品库房.工作令号),
                new SqlParameter("p2", 成品库房.日期),
                new SqlParameter("p3", 成品库房.金额),
            };
            SqlHelper.ExecuteNonQuery(sql, para);
            sql = @"insert into 成品库房转出表 values ('{0}')";
            sql = string.Format(sql, 成品库房.id);
            SqlHelper.ExecuteNonQuery(sql);


            原始凭证 mod = new 原始凭证();
            原始凭证DAL dal = new 原始凭证DAL();
            
            mod.日期 = 成品库房.日期;
            mod.工作令号 = 成品库房.工作令号;
            if (成品库房.ty != 0)
            {
                mod.Id = Guid.NewGuid();
                mod.材质 = "I";
                mod.金额 = 成品库房.ty;
                mod.单位 = short.Parse(dal.getSaleDeptForWorkno(成品库房.工作令号, mod.材质));
                dal.addOut(mod);
            }

            if( 成品库房.zdh != 0)
            {
                mod.Id = Guid.NewGuid();
                mod.材质 = "K";
                mod.金额 = 成品库房.zdh;
                mod.单位 = short.Parse (dal.getSaleDeptForWorkno(成品库房.工作令号, mod.材质));
                dal.addOut(mod);
            }

            if( 成品库房.sj != 0 )
            {
                mod.Id = Guid.NewGuid();
                mod.材质 = "1";
                mod.金额 = 成品库房.sj;
                mod.单位 = short.Parse(dal.getSaleDeptForWorkno(成品库房.工作令号, mod.材质));
                dal.addOut(mod);
            }

            if (成品库房.ys != 0)
            {
                mod.Id = Guid.NewGuid();
                mod.材质 = "2";
                mod.金额 = 成品库房.ys;
                mod.单位 = short.Parse(dal.getSaleDeptForWorkno(成品库房.工作令号, mod.材质));
                dal.addOut(mod);
            }

            if (成品库房.az != 0)
            {
                mod.Id = Guid.NewGuid();
                mod.材质 = "N";
                mod.金额 = 成品库房.az;
                mod.单位 = short.Parse(dal.getSaleDeptForWorkno(成品库房.工作令号, mod.材质));
                dal.addOut(mod);
            }

            if (成品库房.qt != 0)
            {
                mod.Id = Guid.NewGuid();
                mod.材质 = "L";
                mod.金额 = 成品库房.qt;
                mod.单位 = short.Parse(dal.getSaleDeptForWorkno(成品库房.工作令号, mod.材质));
                dal.addOut(mod);
            }

            if (成品库房.xsjy != 0)
            {
                mod.Id = Guid.NewGuid();
                mod.材质 = "O";
                mod.金额 = 成品库房.xsjy;
                mod.单位 = short.Parse(dal.getSaleDeptForWorkno(成品库房.工作令号, mod.材质));
                dal.addOut(mod);
            }

            if (成品库房.gjjy != 0)
            {
                mod.Id = Guid.NewGuid();
                mod.材质 = "U";
                mod.金额 = 成品库房.gjjy;
                mod.单位 = short.Parse(dal.getSaleDeptForWorkno(成品库房.工作令号, mod.材质));
                dal.addOut(mod);
            }

        }


        public void update成品库房表_转出( 成品库房表 成品库房 )
        {
            //string sql = @"update 成品库房表 set 工作令号=@p1, 日期=@p2, 金额=@p3 where id='{0}'";

            //sql = string.Format(sql, 成品库房.id);

            //SqlParameter[] parms = new SqlParameter[]
            //{
            //    new SqlParameter ("p1",成品库房.工作令号),
            //    new SqlParameter("p2", 成品库房.日期),
            //    new SqlParameter("p3", 成品库房.金额),
            //    //new SqlParameter("p4", 成品库房.ty),
            //    //new SqlParameter("p5", 成品库房.zdh),
            //    //new SqlParameter("p6", 成品库房.sj),
            //    //new SqlParameter ("p7", 成品库房.ys),
            //    //new SqlParameter ("p8", 成品库房.az ),
            //    //new SqlParameter ("p9" , 成品库房.qt),
            //    //new SqlParameter ("p10" , 成品库房.xsjy),
            //    //new SqlParameter ("p11" , 成品库房.gjjy)


            //};
            //SqlHelper.ExecuteNonQuery(sql,parms);

            del成品库房表_转出(成品库房.工作令号, 成品库房.日期);

            insert成品库房表_转出(成品库房);


        }



        // 成品库转出时使用。
        public void insert成品库房表( Guid id , string workno, DateTime mydate , decimal cost)
        {
            string sql = @"insert into 成品库房表( id, 工作令号, 日期, 金额) values (@p0, @p1,@p2,@p3)";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("p0", id),
                new SqlParameter("p1", workno),
                new SqlParameter("p2", mydate),
                new SqlParameter("p3", cost)
            };

            SqlHelper.ExecuteNonQuery(sql, para);

            sql = "insert into  成品库房转出表(id) values ('{0}')";
            sql = string.Format(sql, id.ToString());

            SqlHelper.ExecuteNonQuery(sql);


        }



        public void insert成品库房表( string workno, DateTime mydate , decimal cost)
        {
            string sql = @"insert into 成品库房表( 工作令号, 日期, 金额) values (@p1,@p2,@p3)";
            SqlParameter[] para= new SqlParameter[]
            {
                new SqlParameter("p1", workno), 
                new SqlParameter("p2", mydate),
                new SqlParameter("p3", cost*(-1))
            };

            SqlHelper.ExecuteNonQuery(sql, para);

        }


        public DataTable get成品库房表NEW( string workno)
        {
            string searchExpress;

            searchExpress = string.IsNullOrEmpty(workno) ? string.Empty: string.Format(" where 工作令号='{0}'", workno);
            string sql = @"select id, 工作令号 , 日期, 金额 from 成品库房表 {0} order by 工作令号, 日期 ";

            sql = string.Format(sql, searchExpress);

            return SqlHelper.ExecuteDataTable(sql);
        }

        public SqlDataReader get成品库房()
        {
            string sql;


            //            sql = @"select * from (select  '' id , t8.工作令号, t9.工号类型,  t8.时间, 分厂成本, t8.铁业配套件, t8.自动化配套件, t8.设计费, t8.运输费, t8.安装费, t8.销售其它, t8.销售结余, t8.国际结余
            //                      from (                    
            //                            select rtrim(工作令号) 工作令号, 时间, 分厂成本, 铁业配套件, 自动化配套件, 设计费, 运输费, 安装费, 销售其它, 销售结余, 国际结余 from                       
            //                            (select 工作令号, str(year(日期),4)+'年'+str(month(日期),2)+'月'+类型 时间, 
            //                            SUM( case 材质 when '' then  je else 0 end) 分厂成本,
            //                            SUM( case 材质 when 'I' then  je else 0 end) 铁业配套件,
            //                            SUM( case 材质 when 'K' then  je else 0 end) 自动化配套件,
            //                            SUM( case 材质 when '1' then  je else 0 end) 设计费,
            //                            SUM( case 材质 when '2' then  je else 0 end) 运输费,
            //                            SUM( case 材质 when 'N' then  je else 0 end) 安装费,
            //                            SUM( case 材质 when 'L' then  je else 0 end) 销售其它,
            //                            SUM( case 材质 when 'O' then  je else 0 end) 销售结余,
            //                            SUM( case 材质 when 'U' then  je else 0 end) 国际结余 
            //                            from (
            //                            select id, 工作令号, 日期, 材质 , 金额 je, 类型   from (                      
            //                            select t1.id, 工作令号, 日期 , '' 材质, 金额, case when t2.id IS null then '' else '转出' end 类型  from 成品库房表 t1 left join 成品库房转出表 t2 on t1.id=t2.id
            //                            union
            //                            select t3.id, 工作令号, 日期,     材质, 金额, case when t4.id IS null then '' else '转出' end 类型  from 原始凭证 t3 left join 原始凭证转出表 t4  on t3.id = t4.id where 材质 in (select 材质类别 from 材质类别表 where dept ='销售')
            //                            ) t) t1 group by 工作令号, str(year(日期),4)+'年'+str(month(日期),2)+'月'+类型 
            //                            union 
            //                            select 工作令号, '小计',
            //                            SUM( case 材质 when '' then  je else 0 end) 分厂成本,
            //                            SUM( case 材质 when 'I' then  je else 0 end) 铁业配套件,
            //                            SUM( case 材质 when 'K' then  je else 0 end) 自动化配套件,
            //                            SUM( case 材质 when '1' then  je else 0 end) 设计费,
            //                            SUM( case 材质 when '2' then  je else 0 end) 运输费,
            //                            SUM( case 材质 when 'N' then  je else 0 end) 安装费,
            //                            SUM( case 材质 when 'L' then  je else 0 end) 销售其它,
            //                            SUM( case 材质 when 'O' then  je else 0 end) 销售结余,
            //                            SUM( case 材质 when 'U' then  je else 0 end) 国际结余 
            //                            from (
            //                            select id, 工作令号, 材质 , 金额 je   from (                      
            //                            select t1.id, 工作令号 , '' 材质, 金额 from 成品库房表 t1 
            //                            union
            //                            select t3.id, 工作令号,     材质, 金额 from 原始凭证 t3  where 材质 in (select 材质类别 from 材质类别表 where dept ='销售')
            //                            ) t3 ) t4 group by 工作令号
            //                            union 
            //                            select '总计','' ,
            //                            SUM( case 材质 when '' then  je else 0 end) 分厂成本,
            //                            SUM( case 材质 when 'I' then  je else 0 end) 铁业配套件,
            //                            SUM( case 材质 when 'K' then  je else 0 end) 自动化配套件,
            //                            SUM( case 材质 when '1' then  je else 0 end) 设计费,
            //                            SUM( case 材质 when '2' then  je else 0 end) 运输费,
            //                            SUM( case 材质 when 'N' then  je else 0 end) 安装费,
            //                            SUM( case 材质 when 'L' then  je else 0 end) 销售其它,
            //                            SUM( case 材质 when 'O' then  je else 0 end) 销售结余,
            //                            SUM( case 材质 when 'U' then  je else 0 end) 国际结余 
            //                            from (
            //                            select id, 工作令号, 材质 , 金额 je   from (                      
            //                            select t1.id, 工作令号 , '' 材质, 金额 from 成品库房表 t1 
            //                            union
            //                            select t3.id, 工作令号,     材质, 金额 from 原始凭证 t3  where 材质 in (select 材质类别 from 材质类别表 where dept ='销售')
            //                            ) t5 ) t6 ) t7   )t8 left join 工号表 t9 on t8.工作令号=t9.工作令号 
            //                             ) t20  WHERE 工作令号 not in ( select 工作令号 from (
            //select 工作令号,  金额 je   from (                      
            //                            select t30.id, 工作令号 , '' 材质, 金额 from 成品库房表 t30 
            //                            union
            //                            select t31.id, 工作令号,     材质, 金额 from 原始凭证 t31  where 材质 in (select 材质类别 from 材质类别表 where dept ='销售')
            //                            ) t3 ) t4 group by 工作令号 having SUM(je) = 0 ) order by 工作令号, 时间";

            sql = @"select  '' id , t8.工作令号, t9.工号类型,  t8.时间, 分厂成本, t8.铁业配套件, t8.自动化配套件, t8.设计费, t8.运输费, t8.安装费, t8.销售其它, t8.销售结余, t8.国际结余
                      from (                    
                            select rtrim(工作令号) 工作令号, 时间, 分厂成本, 铁业配套件, 自动化配套件, 设计费, 运输费, 安装费, 销售其它, 销售结余, 国际结余 from                       
                            (select 工作令号, str(year(日期),4)+'年'+str(month(日期),2)+'月'+类型 时间, 
                            SUM( case 材质 when '' then  je else 0 end) 分厂成本,
                            SUM( case 材质 when 'I' then  je else 0 end) 铁业配套件,
                            SUM( case 材质 when 'K' then  je else 0 end) 自动化配套件,
                            SUM( case 材质 when '1' then  je else 0 end) 设计费,
                            SUM( case 材质 when '2' then  je else 0 end) 运输费,
                            SUM( case 材质 when 'N' then  je else 0 end) 安装费,
                            SUM( case 材质 when 'L' then  je else 0 end) 销售其它,
                            SUM( case 材质 when 'O' then  je else 0 end) 销售结余,
                            SUM( case 材质 when 'U' then  je else 0 end) 国际结余 
                            from (
                            select id, 工作令号, 日期, 材质 , 金额 je, 类型   from (                      
                            select t1.id, 工作令号, 日期 , '' 材质, 金额, case when t2.id IS null then '' else '转出' end 类型  from 成品库房表 t1 left join 成品库房转出表 t2 on t1.id=t2.id
                            union
                            select t3.id, 工作令号, 日期,     材质, 金额, case when t4.id IS null then '' else '转出' end 类型  from 原始凭证 t3 left join 原始凭证转出表 t4  on t3.id = t4.id where 材质 in (select 材质类别 from 材质类别表 where dept ='销售')
                            ) t) t1 group by 工作令号, str(year(日期),4)+'年'+str(month(日期),2)+'月'+类型 
                            union 
                            select 工作令号, '小计',
                            SUM( case 材质 when '' then  je else 0 end) 分厂成本,
                            SUM( case 材质 when 'I' then  je else 0 end) 铁业配套件,
                            SUM( case 材质 when 'K' then  je else 0 end) 自动化配套件,
                            SUM( case 材质 when '1' then  je else 0 end) 设计费,
                            SUM( case 材质 when '2' then  je else 0 end) 运输费,
                            SUM( case 材质 when 'N' then  je else 0 end) 安装费,
                            SUM( case 材质 when 'L' then  je else 0 end) 销售其它,
                            SUM( case 材质 when 'O' then  je else 0 end) 销售结余,
                            SUM( case 材质 when 'U' then  je else 0 end) 国际结余 
                            from (
                            select id, 工作令号, 材质 , 金额 je   from (                      
                            select t1.id, 工作令号 , '' 材质, 金额 from 成品库房表 t1 
                            union
                            select t3.id, 工作令号,     材质, 金额 from 原始凭证 t3  where 材质 in (select 材质类别 from 材质类别表 where dept ='销售')
                            ) t3 ) t4 group by 工作令号
                            union 
                            select '总计','' ,
                            SUM( case 材质 when '' then  je else 0 end) 分厂成本,
                            SUM( case 材质 when 'I' then  je else 0 end) 铁业配套件,
                            SUM( case 材质 when 'K' then  je else 0 end) 自动化配套件,
                            SUM( case 材质 when '1' then  je else 0 end) 设计费,
                            SUM( case 材质 when '2' then  je else 0 end) 运输费,
                            SUM( case 材质 when 'N' then  je else 0 end) 安装费,
                            SUM( case 材质 when 'L' then  je else 0 end) 销售其它,
                            SUM( case 材质 when 'O' then  je else 0 end) 销售结余,
                            SUM( case 材质 when 'U' then  je else 0 end) 国际结余 
                            from (
                            select id, 工作令号, 材质 , 金额 je   from (                      
                            select t1.id, 工作令号 , '' 材质, 金额 from 成品库房表 t1 
                            union
                            select t3.id, 工作令号,     材质, 金额 from 原始凭证 t3  where 材质 in (select 材质类别 from 材质类别表 where dept ='销售')
                            ) t5 ) t6 ) t7   )t8 left join 工号表 t9 on t8.工作令号=t9.工作令号 
                             order by 工作令号, 时间";






            sql = string.Format(sql);

            return SqlHelper.ExecuteDataReader(sql);




        }


        public SqlDataReader get成品库房表()
        {
            string sql;


            //sql = @"select  '' , rtrim(t8.工作令号) 工作令号, rtrim(t9.合同号) 合同号, rtrim(t9.名称) 产品名称, t8.时间 年月,  (分厂成本+t8.铁业配套件+t8.自动化配套件+t8.设计费+ t8.运输费+t8.安装费+t8.销售其它+t8.销售结余+ t8.国际结余) 总成本,  分厂成本, t8.铁业配套件, t8.自动化配套件, t8.设计费, t8.运输费, t8.安装费, t8.销售其它, t8.销售结余, t8.国际结余, RTRIM(工号类型) 工号类型
            //          from (                    
            //                select rtrim(工作令号) 工作令号, 时间, 分厂成本, 铁业配套件, 自动化配套件, 设计费, 运输费, 安装费, 销售其它, 销售结余, 国际结余 from                       
            //                (
            //                select 工作令号, '小计' 时间,
            //                SUM( case 材质 when '' then  je else 0 end) 分厂成本,
            //                SUM( case 材质 when 'I' then  je else 0 end) 铁业配套件,
            //                SUM( case 材质 when 'K' then  je else 0 end) 自动化配套件,
            //                SUM( case 材质 when '1' then  je else 0 end) 设计费,
            //                SUM( case 材质 when '2' then  je else 0 end) 运输费,
            //                SUM( case 材质 when 'N' then  je else 0 end) 安装费,
            //                SUM( case 材质 when 'L' then  je else 0 end) 销售其它,
            //                SUM( case 材质 when 'O' then  je else 0 end) 销售结余,
            //                SUM( case 材质 when 'U' then  je else 0 end) 国际结余 
            //                from (
            //                select id, 工作令号, 材质 , 金额 je   from (                      
            //                select t1.id, 工作令号 , '' 材质, 金额 from 成品库房表 t1 
            //                union
            //                select t3.id, 工作令号,     材质, 金额 from 原始凭证 t3  where 材质 in (select 材质类别 from 材质类别表 where dept ='销售')
            //                ) t3 ) t4 group by 工作令号
            //                union 
            //                select '总计','' 时间,
            //                SUM( case 材质 when '' then  je else 0 end) 分厂成本,
            //                SUM( case 材质 when 'I' then  je else 0 end) 铁业配套件,
            //                SUM( case 材质 when 'K' then  je else 0 end) 自动化配套件,
            //                SUM( case 材质 when '1' then  je else 0 end) 设计费,
            //                SUM( case 材质 when '2' then  je else 0 end) 运输费,
            //                SUM( case 材质 when 'N' then  je else 0 end) 安装费,
            //                SUM( case 材质 when 'L' then  je else 0 end) 销售其它,
            //                SUM( case 材质 when 'O' then  je else 0 end) 销售结余,
            //                SUM( case 材质 when 'U' then  je else 0 end) 国际结余 
            //                from (
            //                select id, 工作令号, 材质 , 金额 je   from (                      
            //                select t1.id, 工作令号 , '' 材质, 金额 from 成品库房表 t1 
            //                union
            //                select t3.id, 工作令号,     材质, 金额 from 原始凭证 t3  where 材质 in (select 材质类别 from 材质类别表 where dept ='销售')
            //                ) t5 ) t6 ) t7   )t8 left join 工号表 t9 on t8.工作令号=t9.工作令号 where (分厂成本+t8.铁业配套件+t8.自动化配套件+t8.设计费+ 
            //                t8.运输费+t8.安装费+t8.销售其它+t8.销售结余+ t8.国际结余) <>0    order by 工作令号, 时间";

            sql = @"select  '' , rtrim(t8.工作令号) 工作令号, rtrim(t9.合同号) 合同号, rtrim(t9.名称) 产品名称, t8.时间 年月,  (分厂成本+t8.铁业配套件+t8.自动化配套件+t8.设计费+ t8.运输费+t8.安装费+t8.销售其它+t8.销售结余+ t8.国际结余) 总成本,  分厂成本, t8.铁业配套件, t8.自动化配套件, t8.设计费, t8.运输费, t8.安装费, t8.销售其它, t8.销售结余, t8.国际结余, RTRIM(工号类型) 工号类型
                      from (                    
                            select rtrim(工作令号) 工作令号, 时间, 分厂成本, 铁业配套件, 自动化配套件, 设计费, 运输费, 安装费, 销售其它, 销售结余, 国际结余 from                       
                            (
                            select 工作令号, '小计' 时间,
                            SUM( case 材质 when '' then  je else 0 end) 分厂成本,
                            SUM( case 材质 when 'I' then  je else 0 end) 铁业配套件,
                            SUM( case 材质 when 'K' then  je else 0 end) 自动化配套件,
                            SUM( case 材质 when '1' then  je else 0 end) 设计费,
                            SUM( case 材质 when '2' then  je else 0 end) 运输费,
                            SUM( case 材质 when 'N' then  je else 0 end) 安装费,
                            SUM( case 材质 when 'L' then  je else 0 end) 销售其它,
                            SUM( case 材质 when 'O' then  je else 0 end) 销售结余,
                            SUM( case 材质 when 'U' then  je else 0 end) 国际结余 
                            from (
                            select id, 工作令号, 材质 , 金额 je   from (                      
                            select t1.id, 工作令号 , '' 材质, 金额 from 成品库房表 t1 
                            union
                            select t3.id, 工作令号,     材质, 金额 from 原始凭证 t3  where 材质 in (select 材质类别 from 材质类别表 where dept ='销售')
                            ) t3 ) t4 group by 工作令号
                            union 
                            select '总计','' 时间,
                            SUM( case 材质 when '' then  je else 0 end) 分厂成本,
                            SUM( case 材质 when 'I' then  je else 0 end) 铁业配套件,
                            SUM( case 材质 when 'K' then  je else 0 end) 自动化配套件,
                            SUM( case 材质 when '1' then  je else 0 end) 设计费,
                            SUM( case 材质 when '2' then  je else 0 end) 运输费,
                            SUM( case 材质 when 'N' then  je else 0 end) 安装费,
                            SUM( case 材质 when 'L' then  je else 0 end) 销售其它,
                            SUM( case 材质 when 'O' then  je else 0 end) 销售结余,
                            SUM( case 材质 when 'U' then  je else 0 end) 国际结余 
                            from (
                            select id, 工作令号, 材质 , 金额 je   from (                      
                            select t1.id, 工作令号 , '' 材质, 金额 from 成品库房表 t1 
                            union
                            select t3.id, 工作令号,     材质, 金额 from 原始凭证 t3  where 材质 in (select 材质类别 from 材质类别表 where dept ='销售')
                            ) t5 ) t6 ) t7   )t8 left join 工号表 t9 on t8.工作令号=t9.工作令号 where (分厂成本+t8.铁业配套件+t8.自动化配套件+t8.设计费+ 
                            t8.运输费+t8.安装费+t8.销售其它+t8.销售结余+ t8.国际结余) <>0  and 分厂成本>=0   order by 工作令号, 时间";

            return SqlHelper.ExecuteDataReader(sql);









        }


        public DataTable get成品库房List(string workno, bool chk=false)
        {
            string sql;

            string searchexpress;

            searchexpress = string.IsNullOrEmpty(workno) ? string.Empty : string.Format(" where 工作令号='{0}'", workno);

            searchexpress =   chk ? (string.IsNullOrEmpty(searchexpress) ? " where 分厂成本+铁业配套件+自动化配套件+设计费+运输费+安装费+销售其它+销售结余+国际结余>0 and 时间='小计'" : searchexpress+ " and 分厂成本 + 铁业配套件 + 自动化配套件 + 设计费 + 运输费 + 安装费 + 销售其它 + 销售结余 + 国际结余 > 0 and 时间='小计'") : searchexpress ;

            sql = @"select rtrim(工作令号) 工作令号, 时间, 分厂成本, 铁业配套件, 自动化配套件, 设计费, 运输费, 安装费, 销售其它, 销售结余, 国际结余 from                       
(select 工作令号, str(year(日期),4)+'年'+str(month(日期),2)+'月'+类型 时间, 
SUM( case 材质 when '' then  je else 0 end) 分厂成本,
SUM( case 材质 when 'I' then  je else 0 end) 铁业配套件,
SUM( case 材质 when 'K' then  je else 0 end) 自动化配套件,
SUM( case 材质 when '1' then  je else 0 end) 设计费,
SUM( case 材质 when '2' then  je else 0 end) 运输费,
SUM( case 材质 when 'N' then  je else 0 end) 安装费,
SUM( case 材质 when 'L' then  je else 0 end) 销售其它,
SUM( case 材质 when 'O' then  je else 0 end) 销售结余,
SUM( case 材质 when 'U' then  je else 0 end) 国际结余 
from (
select id, 工作令号, 日期, 材质 , 金额 je, 类型   from (                      
select t1.id, 工作令号, 日期 , '' 材质, 金额, case when t2.id IS null then '' else '转出' end 类型  from 成品库房表 t1 left join 成品库房转出表 t2 on t1.id=t2.id
union
select t3.id, 工作令号, 日期,     材质, 金额, case when t4.id IS null then '' else '转出' end 类型  from 原始凭证 t3 left join 原始凭证转出表 t4  on t3.id = t4.id where 材质 in (select 材质类别 from 材质类别表 where dept ='销售')
) t) t1 group by 工作令号, str(year(日期),4)+'年'+str(month(日期),2)+'月'+类型 
union 
select 工作令号, '小计',
SUM( case 材质 when '' then  je else 0 end) 分厂成本,
SUM( case 材质 when 'I' then  je else 0 end) 铁业配套件,
SUM( case 材质 when 'K' then  je else 0 end) 自动化配套件,
SUM( case 材质 when '1' then  je else 0 end) 设计费,
SUM( case 材质 when '2' then  je else 0 end) 运输费,
SUM( case 材质 when 'N' then  je else 0 end) 安装费,
SUM( case 材质 when 'L' then  je else 0 end) 销售其它,
SUM( case 材质 when 'O' then  je else 0 end) 销售结余,
SUM( case 材质 when 'U' then  je else 0 end) 国际结余 
from (
select id, 工作令号, 材质 , 金额 je   from (                      
select t1.id, 工作令号 , '' 材质, 金额 from 成品库房表 t1 
union
select t3.id, 工作令号,     材质, 金额 from 原始凭证 t3  where 材质 in (select 材质类别 from 材质类别表 where dept ='销售')
) t3 ) t4 group by 工作令号
union 
select '总计','' ,
SUM( case 材质 when '' then  je else 0 end) 分厂成本,
SUM( case 材质 when 'I' then  je else 0 end) 铁业配套件,
SUM( case 材质 when 'K' then  je else 0 end) 自动化配套件,
SUM( case 材质 when '1' then  je else 0 end) 设计费,
SUM( case 材质 when '2' then  je else 0 end) 运输费,
SUM( case 材质 when 'N' then  je else 0 end) 安装费,
SUM( case 材质 when 'L' then  je else 0 end) 销售其它,
SUM( case 材质 when 'O' then  je else 0 end) 销售结余,
SUM( case 材质 when 'U' then  je else 0 end) 国际结余 
from (
select id, 工作令号, 材质 , 金额 je   from (                      
select t1.id, 工作令号 , '' 材质, 金额 from 成品库房表 t1 
union
select t3.id, 工作令号,     材质, 金额 from 原始凭证 t3  where 材质 in (select 材质类别 from 材质类别表 where dept ='销售')
) t5 ) t6 ) t7  {0} order by 工作令号, 时间";

            sql = string.Format(sql, searchexpress);



//            if ( workno == "")
//            {
//                sql = @"select rtrim(工作令号) 工作令号, 时间, 分厂成本, 铁业配套件, 自动化配套件, 设计费, 运输费, 安装费, 销售其它, 销售结余, 国际结余 from                       
//(select 工作令号, str(year(日期),4)+'年'+str(month(日期),2)+'月'+类型 时间, 
//SUM( case 材质 when '' then  je else 0 end) 分厂成本,
//SUM( case 材质 when 'I' then  je else 0 end) 铁业配套件,
//SUM( case 材质 when 'K' then  je else 0 end) 自动化配套件,
//SUM( case 材质 when '1' then  je else 0 end) 设计费,
//SUM( case 材质 when '2' then  je else 0 end) 运输费,
//SUM( case 材质 when 'N' then  je else 0 end) 安装费,
//SUM( case 材质 when 'L' then  je else 0 end) 销售其它,
//SUM( case 材质 when 'O' then  je else 0 end) 销售结余,
//SUM( case 材质 when 'U' then  je else 0 end) 国际结余 
//from (
//select id, 工作令号, 日期, 材质 , 金额 je, 类型   from (                      
//select t1.id, 工作令号, 日期 , '' 材质, 金额, case when t2.id IS null then '' else '转出' end 类型  from 成品库房表 t1 left join 成品库房转出表 t2 on t1.id=t2.id
//union
//select t3.id, 工作令号, 日期,     材质, 金额, case when t4.id IS null then '' else '转出' end 类型  from 原始凭证 t3 left join 原始凭证转出表 t4  on t3.id = t4.id where 材质 in (select 材质类别 from 材质类别表 where dept ='销售')
//) t) t1 group by 工作令号, str(year(日期),4)+'年'+str(month(日期),2)+'月'+类型 
//union 
//select 工作令号, '小计',
//SUM( case 材质 when '' then  je else 0 end) 分厂成本,
//SUM( case 材质 when 'I' then  je else 0 end) 铁业配套件,
//SUM( case 材质 when 'K' then  je else 0 end) 自动化配套件,
//SUM( case 材质 when '1' then  je else 0 end) 设计费,
//SUM( case 材质 when '2' then  je else 0 end) 运输费,
//SUM( case 材质 when 'N' then  je else 0 end) 安装费,
//SUM( case 材质 when 'L' then  je else 0 end) 销售其它,
//SUM( case 材质 when 'O' then  je else 0 end) 销售结余,
//SUM( case 材质 when 'U' then  je else 0 end) 国际结余 
//from (
//select id, 工作令号, 材质 , 金额 je   from (                      
//select t1.id, 工作令号 , '' 材质, 金额 from 成品库房表 t1 
//union
//select t3.id, 工作令号,     材质, 金额 from 原始凭证 t3  where 材质 in (select 材质类别 from 材质类别表 where dept ='销售')
//) t3 ) t4 group by 工作令号
//union 
//select '总计','' ,
//SUM( case 材质 when '' then  je else 0 end) 分厂成本,
//SUM( case 材质 when 'I' then  je else 0 end) 铁业配套件,
//SUM( case 材质 when 'K' then  je else 0 end) 自动化配套件,
//SUM( case 材质 when '1' then  je else 0 end) 设计费,
//SUM( case 材质 when '2' then  je else 0 end) 运输费,
//SUM( case 材质 when 'N' then  je else 0 end) 安装费,
//SUM( case 材质 when 'L' then  je else 0 end) 销售其它,
//SUM( case 材质 when 'O' then  je else 0 end) 销售结余,
//SUM( case 材质 when 'U' then  je else 0 end) 国际结余 
//from (
//select id, 工作令号, 材质 , 金额 je   from (                      
//select t1.id, 工作令号 , '' 材质, 金额 from 成品库房表 t1 
//union
//select t3.id, 工作令号,     材质, 金额 from 原始凭证 t3  where 材质 in (select 材质类别 from 材质类别表 where dept ='销售')
//) t5 ) t6 ) t7  order by 工作令号, 时间";

//            }
//            else
//            {
//                sql = @"select rtrim(工作令号) 工作令号, 时间, 分厂成本, 铁业配套件, 自动化配套件, 设计费, 运输费, 安装费, 销售其它, 销售结余, 国际结余 from                       
//                    (select 工作令号, str(year(日期),4)+'年'+str(month(日期),2)+'月'+类型 时间, 
//                    SUM( case 材质 when '' then  je else 0 end) 分厂成本,
//                    SUM( case 材质 when 'I' then  je else 0 end) 铁业配套件,
//                    SUM( case 材质 when 'K' then  je else 0 end) 自动化配套件,
//                    SUM( case 材质 when '1' then  je else 0 end) 设计费,
//                    SUM( case 材质 when '2' then  je else 0 end) 运输费,
//                    SUM( case 材质 when 'N' then  je else 0 end) 安装费,
//                    SUM( case 材质 when 'L' then  je else 0 end) 销售其它,
//                    SUM( case 材质 when 'O' then  je else 0 end) 销售结余,
//                    SUM( case 材质 when 'U' then  je else 0 end) 国际结余 
//                    from (
//                    select id, 工作令号, 日期, 材质 , 金额 je, 类型   from (                      
//                    select t1.id, 工作令号, 日期 , '' 材质, 金额, case when t2.id IS null then '' else '转出' end 类型  from 成品库房表 t1 left join 成品库房转出表 t2 on t1.id=t2.id
//                    union
//                    select t3.id, 工作令号, 日期,     材质, 金额, case when t4.id IS null then '' else '转出' end 类型  from 原始凭证 t3 left join 原始凭证转出表 t4  on t3.id = t4.id where 材质 in (select 材质类别 from 材质类别表 where dept ='销售')
//                    ) t) t1 group by 工作令号, str(year(日期),4)+'年'+str(month(日期),2)+'月'+类型 
//                    union 
//                    select 工作令号, '小计',
//                    SUM( case 材质 when '' then  je else 0 end) 分厂成本,
//                    SUM( case 材质 when 'I' then  je else 0 end) 铁业配套件,
//                    SUM( case 材质 when 'K' then  je else 0 end) 自动化配套件,
//                    SUM( case 材质 when '1' then  je else 0 end) 设计费,
//                    SUM( case 材质 when '2' then  je else 0 end) 运输费,
//                    SUM( case 材质 when 'N' then  je else 0 end) 安装费,
//                    SUM( case 材质 when 'L' then  je else 0 end) 销售其它,
//                    SUM( case 材质 when 'O' then  je else 0 end) 销售结余,
//                    SUM( case 材质 when 'U' then  je else 0 end) 国际结余 
//                    from (
//                    select id, 工作令号, 材质 , 金额 je   from (                      
//                    select t1.id, 工作令号 , '' 材质, 金额 from 成品库房表 t1 
//                    union
//                    select t3.id, 工作令号,     材质, 金额 from 原始凭证 t3  where 材质 in (select 材质类别 from 材质类别表 where dept ='销售')
//                    ) t3 ) t4 group by 工作令号
//                    union 
//                    select '总计','' ,
//                    SUM( case 材质 when '' then  je else 0 end) 分厂成本,
//                    SUM( case 材质 when 'I' then  je else 0 end) 铁业配套件,
//                    SUM( case 材质 when 'K' then  je else 0 end) 自动化配套件,
//                    SUM( case 材质 when '1' then  je else 0 end) 设计费,
//                    SUM( case 材质 when '2' then  je else 0 end) 运输费,
//                    SUM( case 材质 when 'N' then  je else 0 end) 安装费,
//                    SUM( case 材质 when 'L' then  je else 0 end) 销售其它,
//                    SUM( case 材质 when 'O' then  je else 0 end) 销售结余,
//                    SUM( case 材质 when 'U' then  je else 0 end) 国际结余 
//                    from (
//                    select id, 工作令号, 材质 , 金额 je   from (                      
//                    select t1.id, 工作令号 , '' 材质, 金额 from 成品库房表 t1 
//                    union
//                    select t3.id, 工作令号,     材质, 金额 from 原始凭证 t3  where 材质 in (select 材质类别 from 材质类别表 where dept ='销售')
//                    ) t5 ) t6 ) t7  where 工作令号='{0}' order by 工作令号, 时间";

//                sql = string.Format(sql, workno);

//            }
            return SqlHelper.ExecuteDataTable(sql);
        }


        public DataTable dispplay成品库房批量转出()
        {
            string sql = @"select rtrim(工号) 工号, 金额 , 0 , 0 from view_成品库房表 where 金额!=0   and 时间='小计' order by 工号 ";

            return SqlHelper.ExecuteDataTable(sql);

        }


        // 得到指定工号可以转出的所有值
        public 成品库房表  getCostByWorkno(string workno)
        {
            成品库房表 mod = new 成品库房表();

            //         string sql = @"SELECT  SUM(金额) je,sum(铁业配套) ty,sum(自动化配套) zdh,sum(设计费) sj,sum(运输费) ys,sum(安装费) az,
            //sum(其它) qt, sum(销售结余) xsjy, sum(国际结余) gjjy FROM 成品库房表 where 工作令号='{0}'";


            string sql = @"select 
                SUM( case 材质 when '' then  je else 0 end) 分厂成本,
                SUM( case 材质 when 'I' then  je else 0 end) 铁业配套件,
                SUM( case 材质 when 'K' then  je else 0 end) 自动化配套件,
                SUM( case 材质 when '1' then  je else 0 end) 设计费,
                SUM( case 材质 when '2' then  je else 0 end) 运输费,
                SUM( case 材质 when 'N' then  je else 0 end) 安装费,
                SUM( case 材质 when 'L' then  je else 0 end) 销售其它,
                SUM( case 材质 when 'O' then  je else 0 end) 销售结余,
                SUM( case 材质 when 'U' then  je else 0 end) 国际结余 
                from (
                select id, 工作令号, 材质 , 金额 je   from (                      
                select t1.id, 工作令号 , '' 材质, 金额 from 成品库房表 t1 
                union
                select t3.id, 工作令号,     材质, 金额 from 原始凭证 t3  where 材质 in (select 材质类别 from 材质类别表 where dept ='销售')
                ) t3 ) t4 where 工作令号='{0}'";  
            sql = string.Format(sql, workno);


            SqlDataReader dr =  SqlHelper.ExecuteDataReader(sql);
            if ( dr.HasRows)
            {
                dr.Read();
                {
                    mod.工作令号 = workno;
                    mod.金额 = decimal.Parse(dr.GetValue(0).ToString());
                    mod.ty = decimal.Parse(dr.GetValue(1).ToString());
                    mod.zdh = decimal.Parse(dr.GetValue(2).ToString());
                    mod.sj = decimal.Parse(dr.GetValue(3).ToString());
                    mod.ys = decimal.Parse(dr.GetValue(4).ToString());
                    mod.az = decimal.Parse(dr.GetValue(5).ToString());
                    mod.qt = decimal.Parse(dr.GetValue(6).ToString());
                    mod.xsjy = decimal.Parse(dr.GetValue(7).ToString());
                    mod.gjjy = decimal.Parse(dr.GetValue(8).ToString());
                }
            }

            dr.Close();
            return mod;




        }

        // 得到指定工号, 日期的转出信息
        public 成品库房表 getInfoByWorkno(string workno, DateTime mydate)
        {
            成品库房表 mod = new 成品库房表();

            string sql = @"select 
SUM( case 材质 when '' then  je else 0 end) 分厂成本,
SUM( case 材质 when 'I' then  je else 0 end) 铁业配套件,
SUM( case 材质 when 'K' then  je else 0 end) 自动化配套件,
SUM( case 材质 when '1' then  je else 0 end) 设计费,
SUM( case 材质 when '2' then  je else 0 end) 运输费,
SUM( case 材质 when 'N' then  je else 0 end) 安装费,
SUM( case 材质 when 'L' then  je else 0 end) 销售其它,
SUM( case 材质 when 'O' then  je else 0 end) 销售结余,
SUM( case 材质 when 'U' then  je else 0 end) 国际结余 
from (
select id, 工作令号, 材质 , 金额 je   from (                      
select t1.id, 工作令号 , '' 材质, 金额 from 成品库房表 t1 
where 工作令号='{0}' and year(日期)={1} and month(日期)={2} and id in (select id from 成品库房转出表)
union
select t3.id, 工作令号,     材质, 金额 from 原始凭证 t3  where 工作令号='{0}' and 材质 in (select 材质类别 from 材质类别表 
where dept ='销售') and year(日期)={1} and month(日期)={2} and id in (select id from 原始凭证转出表)) t3 ) t4 group by 工作令号";

            sql = string.Format(sql, workno, mydate.Year, mydate.Month);
            SqlDataReader dr = SqlHelper.ExecuteDataReader(sql);

            if ( dr.HasRows)
            {
                while (dr.Read())
                {
                    mod.金额 = decimal.Parse(dr.GetValue(0).ToString());
                    mod.工作令号 = workno;
                    mod.日期 = mydate;
                    mod.ty = decimal.Parse(dr.GetValue(1).ToString());
                    mod.zdh = decimal.Parse(dr.GetValue(2).ToString());
                    mod.sj = decimal.Parse(dr.GetValue(3).ToString());
                    mod.ys  = decimal.Parse(dr.GetValue(4).ToString());
                    mod.az = decimal.Parse(dr.GetValue(5).ToString());
                    mod.qt = decimal.Parse(dr.GetValue(6).ToString());
                    mod.xsjy = decimal.Parse(dr.GetValue(7).ToString());
                    mod.gjjy = decimal.Parse(dr.GetValue(8).ToString());
                }

            }

            return mod;



        } 


        // 由 指定ID 得到 成品库房表中的值 。 
        public 成品库房表  getInfoByID(string id)
        {

            成品库房表 mod = new 成品库房表();

            string sql = @"SELECT  金额 je,铁业配套 ty,自动化配套 zdh,设计费 sj,运输费 ys,安装费 az,
			其它 qt, 销售结余 xsjy, 国际结余 gjjy , rtrim(工作令号) , 日期 FROM 成品库房表 where id='{0}'";

            sql = string.Format(sql, id);


            SqlDataReader dr = SqlHelper.ExecuteDataReader(sql);
            if (dr.HasRows)
            {
                dr.Read();
                {
                    mod.id = id;
                    mod.金额 = decimal.Parse(dr.GetValue(0).ToString());
                    mod.ty = decimal.Parse(dr.GetValue(1).ToString());
                    mod.zdh = decimal.Parse(dr.GetValue(2).ToString());
                    mod.sj = decimal.Parse(dr.GetValue(3).ToString());
                    mod.ys = decimal.Parse(dr.GetValue(4).ToString());
                    mod.az = decimal.Parse(dr.GetValue(5).ToString());
                    mod.qt = decimal.Parse(dr.GetValue(6).ToString());
                    mod.xsjy = decimal.Parse(dr.GetValue(7).ToString());
                    mod.gjjy = decimal.Parse(dr.GetValue(8).ToString());
                    mod.工作令号 = dr.GetString(9);
                    mod.日期 = dr.GetDateTime(10);
                }
            }

            dr.Close();
            return mod;


        }



        public decimal getCostbyWorkno(string workno)
        {
            string sql = @"select sum(金额) from 成品库房表 where 工作令号='{0}'";

            sql = string.Format(sql, workno);

            return decimal.Parse(SqlHelper.ExecuteScalar(sql).ToString());
        }

        public DateTime getDateById(string id)
        {
            string sql = @"select 日期 from 成品库房表 where id='{0}'";
            sql = string.Format(sql, id);

            return DateTime.Parse(SqlHelper.ExecuteScalar(sql).ToString());

        }

        public DataTable getInfoByDate( DateTime mydate)
        {
            string sql = @"select RTRIM(工作令号), CAST(  日期 AS smalldatetime ) , 金额 from 成品库房表 where YEAR(日期) = {0} and MONTH(日期) = {1} ";

            sql = string.Format(sql, mydate.Year, mydate.Month);

            return SqlHelper.ExecuteDataTable(sql);

        }

        public DataTable getSumCost( DateTime mydate)
        {
           
            string sql = @" select * from (select 工作令号, 
                            SUM( case 材质 when '' then  je else 0 end) 分厂成本,
                            SUM( case 材质 when 'I' then  je else 0 end) 铁业配套件,
                            SUM( case 材质 when 'K' then  je else 0 end) 自动化配套件,
                            SUM( case 材质 when '1' then  je else 0 end) 设计费,
                            SUM( case 材质 when '2' then  je else 0 end) 运输费,
                            SUM( case 材质 when 'N' then  je else 0 end) 安装费,
                            SUM( case 材质 when 'L' then  je else 0 end) 销售其它,
                            SUM( case 材质 when 'O' then  je else 0 end) 销售结余,
                            SUM( case 材质 when 'U' then  je else 0 end) 国际结余 
                            from (
                            select id, 工作令号, 材质 , 金额 je   from (                      
                            select t1.id, 工作令号 , '' 材质, 金额 from 成品库房表 t1 
                            union
                            select t3.id, 工作令号,     材质, 金额 from 原始凭证 t3  where 材质 in (select 材质类别 from 材质类别表 where dept ='销售')
                            ) t3 ) t4   group by 工作令号) t5 where  分厂成本 + 铁业配套件 + 自动化配套件 +设计费+ 运输费
                            + 安装费 + 销售其它 + 销售结余 + 国际结余 <>0 ";


            sql = string.Format(sql, mydate.Year, mydate.Month);

            return SqlHelper.ExecuteDataTable(sql );



        }



    }
}
