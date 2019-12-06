using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace 重装板块成本系统.dal
{
    class OtherCostDal
    {
        public SqlDataReader getOtherCostName()
        {
            string sql = @"select rtrim(name) name from 成品类别表";

            return SqlHelper.ExecuteDataReader(sql);



        }


    }
}
