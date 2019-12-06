using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using 重装板块成本系统.model;
using System.Data.SqlClient;

namespace 重装板块成本系统.dal
{
    public class 转出类DAL
    {
        // 得到需要转出的数据  add 用
        public 转出类 getOutInfoByWorkno(string workno , DateTime mydate, int deptcode )
        {
            转出类 mycls = new 转出类();
            int tempfactor = -1;
            string type;
            Decimal weight, cost;

            //            string sql = @"SELECT  a.材质,  isnull(SUM(a.重量),0) AS 重量, isnull(SUM(a.金额),0) AS 金额
            //FROM         dbo.原始凭证 AS a  where (工作令号= '{0}') 
            //and ((year(a.日期) = {1} and month(a.日期)<={2}) or (year(a.日期) < {1}) ) 
            //and 单位 = {3} GROUP BY a.材质";
            // 
            //  sql = string.Format(sql, workno, mydate.Year, mydate.Month, deptcode);


            string sql = @"SELECT  a.材质,  isnull(SUM(a.重量),0) AS 重量, isnull(SUM(a.金额),0) AS 金额
FROM         dbo.原始凭证 AS a  where (工作令号= '{0}') 
and ((year(a.日期) = {1} and month(a.日期)<={2}) or (year(a.日期) < {1}) ) 
 GROUP BY a.材质";


            sql = string.Format(sql, workno, mydate.Year, mydate.Month);

            SqlDataReader dr = SqlHelper.ExecuteDataReader(sql);
            mycls._workno = workno; 
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    type = dr.GetString(0).Trim();
                    weight  = decimal.Parse(dr.GetValue(1).ToString());
                    cost = decimal.Parse(dr.GetValue(2).ToString());

                    switch (type)
                    {
                        case "A":
                            mycls._bzf = cost* tempfactor;
                            break;
                        case "B":
                            mycls._bjje = cost * tempfactor;
                            break;
                        case "C":
                            mycls._clxje = cost * tempfactor;
                            break;
                        case "D":
                            mycls._djsl = weight * tempfactor;
                            mycls._djje = cost * tempfactor;
                            break;
                        case "E":
                            mycls._sjf = cost * tempfactor;
                            break;
                        case "F":
                            mycls._ysf = cost * tempfactor;
                            break;
                        case "G":
                            mycls._zgsl = weight * tempfactor;
                            mycls._zgje = cost * tempfactor;
                            break;
                        case "J":
                            mycls._wjgf = cost * tempfactor;
                            break;
                        case "M":
                        case "H":
                            mycls._mhje += cost * tempfactor;
                            break;
                        case "P":
                            mycls._ptje = cost * tempfactor;
                            break;
                        case "R":
                            mycls._rclf = cost * tempfactor;
                            break;
                        case "S":
                            mycls._sysl = weight * tempfactor;
                            mycls._syje = cost * tempfactor; ;
                            break;
                        case "T":
                            mycls._ztsl = weight * tempfactor;
                            mycls._ztje = cost * tempfactor;
                            break;
                        case "V":
                            mycls._xsptj = cost * tempfactor;
                            break;
                        case "W":
                            mycls._wgje = cost * tempfactor;
                            break;
                        case "X":
                            mycls._zxfy = cost * tempfactor;
                            break;
                        case "Y":
                            mycls._yssl = weight * tempfactor;
                            mycls._ysje = cost * tempfactor;
                            break;
                        case "Z":
                            mycls._bzj = cost * tempfactor;
                            break;
                    }




                }
            }

            dr.Close();


            sql = @"select isnull(sum(燃料动力),0),isnull(sum(工时),0),isnull(sum(折合工时),0),
    isnull(sum(薪酬),0),isnull(sum(制造费用),0) from (
        select 工号,燃料动力 ,工时,折合工时, 薪酬,制造费用, 部门  from 费用分配表 where 工号='{0}'  and ((year(时间) = {1} and month(时间)<={2}) or (year(时间) < {1}) )
        union all
        select 工号 , 燃料调整, 0,0, 薪酬调整, 制造调整, 部门 from 调整费用分配表 where 工号='{0}'  and ((year(年月) = {1} and month(年月)<={2}) or (year(年月) < {1}))) a ";
            sql = string.Format(sql, workno,  mydate.Year, mydate.Month);


            dr = SqlHelper.ExecuteDataReader(sql);

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    mycls._rldl = decimal.Parse(dr.GetValue(0).ToString())* tempfactor;
                    mycls._gs= decimal.Parse(dr.GetValue(1).ToString()) * tempfactor;
                    mycls._zhgs= decimal.Parse(dr.GetValue(2).ToString()) * tempfactor;
                    mycls._gzfl= decimal.Parse(dr.GetValue(3).ToString()) * tempfactor;
                    mycls._zzfy = decimal.Parse(dr.GetValue(4).ToString()) * tempfactor;
                }
            }
            dr.Close();
            return mycls;

        }

        // 得到已转出的数据， Update 用 
        public 转出类 getUpdateInfoByWorkno(string workno, DateTime mydate, int deptcode)
        {
            转出类 mycls = new 转出类();
            int tempfactor = -1;
            string type;
            Decimal weight, cost;

          


            string sql = @"SELECT  a.材质,  isnull(SUM(a.重量),0) AS 重量, isnull(SUM(a.金额),0) AS 金额
FROM         dbo.原始凭证 AS a  where 工作令号= '{0}' and year(a.日期) = {1} and month(a.日期)={2} and id in (select id from 原始凭证转出表 )
 GROUP BY a.材质";


            sql = string.Format(sql, workno, mydate.Year, mydate.Month);

            SqlDataReader dr = SqlHelper.ExecuteDataReader(sql);
            mycls._workno = workno;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    type = dr.GetString(0).Trim();
                    weight = decimal.Parse(dr.GetValue(1).ToString());
                    cost = decimal.Parse(dr.GetValue(2).ToString());

                    switch (type)
                    {
                        case "A":
                            mycls._bzf = cost * tempfactor;
                            break;
                        case "B":
                            mycls._bjje = cost * tempfactor;
                            break;
                        case "C":
                            mycls._clxje = cost * tempfactor;
                            break;
                        case "D":
                            mycls._djsl = weight * tempfactor;
                            mycls._djje = cost * tempfactor;
                            break;
                        case "E":
                            mycls._sjf = cost * tempfactor;
                            break;
                        case "F":
                            mycls._ysf = cost * tempfactor;
                            break;
                        case "G":
                            mycls._zgsl = weight * tempfactor;
                            mycls._zgje = cost * tempfactor;
                            break;
                        case "J":
                            mycls._wjgf = cost * tempfactor;
                            break;
                        case "M":
                            mycls._mhje = cost * tempfactor;
                            break;
                        case "P":
                            mycls._ptje = cost * tempfactor;
                            break;
                        case "R":
                            mycls._rclf = cost * tempfactor;
                            break;
                        case "S":
                            mycls._sysl = weight * tempfactor;
                            mycls._syje = cost * tempfactor; ;
                            break;
                        case "T":
                            mycls._ztsl = weight * tempfactor;
                            mycls._ztje = cost * tempfactor;
                            break;
                        case "V":
                            mycls._xsptj = cost * tempfactor;
                            break;
                        case "W":
                            mycls._wgje = cost * tempfactor;
                            break;
                        case "X":
                            mycls._zxfy = cost * tempfactor;
                            break;
                        case "Y":
                            mycls._yssl = weight * tempfactor;
                            mycls._ysje = cost * tempfactor;
                            break;
                        case "Z":
                            mycls._bzj = cost * tempfactor;
                            break;
                    }




                }
            }

            dr.Close();


            sql = @"select isnull(sum(燃料动力),0),isnull(sum(工时), 0),isnull(sum(折合工时), 0),
    isnull(sum(薪酬), 0),isnull(sum(制造费用), 0) from(
          select 工号, 燃料动力, 工时, 折合工时, 薪酬, 制造费用, 部门  from 费用分配表 where 工号 = '{0}'  and year(时间) = {1} and month(时间) = {2} and ID in (select ID from 费用分配转出表)) t";

                     sql = string.Format(sql, workno, mydate.Year, mydate.Month);


            dr = SqlHelper.ExecuteDataReader(sql);

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    mycls._rldl = decimal.Parse(dr.GetValue(0).ToString()) * tempfactor;
                    mycls._gs = decimal.Parse(dr.GetValue(1).ToString()) * tempfactor;
                    mycls._zhgs = decimal.Parse(dr.GetValue(2).ToString()) * tempfactor;
                    mycls._gzfl = decimal.Parse(dr.GetValue(3).ToString()) * tempfactor;
                    mycls._zzfy = decimal.Parse(dr.GetValue(4).ToString()) * tempfactor;
                }
            }
            dr.Close();
            return mycls;

        }






        public void del_data( string workno, DateTime mydate, int deptcode)
        {
            string sql = @"select id from 原始凭证 where year(日期) = {0} and month(日期)={1} and 工作令号 ='{2}' and 单位={3} and  id in (select id from 原始凭证转出表)";
            List<string> mylist = new List<string>();

            sql = string.Format(sql, mydate.Year, mydate.Month, workno, deptcode);
            SqlDataReader dr = SqlHelper.ExecuteDataReader(sql);

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    mylist.Add(dr.GetGuid(0).ToString());
                }
            }
            dr.Close();

            foreach ( string id in mylist)
            {
                sql = "delete 原始凭证 where id ='{0}'";
                sql = string.Format(sql, id);
                SqlHelper.ExecuteNonQuery(sql);
                sql = "delete 原始凭证转出表 where id='{0}'";
                sql = string.Format(sql, id);
                SqlHelper.ExecuteNonQuery(sql);

            }

            mylist.Clear();
            sql = @"select id from 费用分配表 where year(时间) = {0} and month(时间)={1} and 工号 ='{2}' and 部门 = {3} and  id in (select id from 费用分配转出表)";
            sql = string.Format(sql, mydate.Year, mydate.Month, workno, deptcode);

            dr = SqlHelper.ExecuteDataReader(sql);
            if( dr.HasRows)
            {
                while (dr.Read())
                {
                    mylist.Add(dr.GetGuid(0).ToString());
                }
            }
            dr.Close();

            foreach ( string myid in mylist)
            {
                sql = "delete 费用分配表 where id='{0}'";
                sql = string.Format(sql, myid);
                SqlHelper.ExecuteNonQuery(sql);

                sql = "delete 费用分配转出表 where id='{0}'";
                sql = string.Format(sql, myid);
                SqlHelper.ExecuteNonQuery(sql);
            }

            sql = @"delete 成品库房表 where 工作令号='{0}' and year(日期) = {1} and month(日期) ={2}";
            sql = string.Format(sql , workno, mydate.Year, mydate.Month);

            SqlHelper.ExecuteNonQuery(sql);



        }


        //public void 
    }
}
