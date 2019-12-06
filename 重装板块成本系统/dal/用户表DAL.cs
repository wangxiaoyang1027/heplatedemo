using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using 重装板块成本系统.model;

namespace 重装板块成本系统.dal
{
	public partial class 用户表DAL
	{
        // 由 部门 ， 工作证号为条件， 更改 密码
        public void changPwd(  用户表 mod)
        {
            string sql = @"update 用户表 set pwd = '{2}' where departid={0} and cardno='{1}'";
            sql = string.Format(sql, mod.Departid, mod.Cardno, mod.Pwd);

            SqlHelper.ExecuteNonQuery(sql);
        }




        public 用户表 Add(用户表 用户表)
		{
				string sql ="INSERT INTO 用户表 (id, cardno, pwd, name, departid, noused)  VALUES (@id, @cardno, @pwd, @name, @departid, @noused)";
				SqlParameter[] para = new SqlParameter[]
					{
						new SqlParameter("@id", ToDBValue(用户表.Id)),
						new SqlParameter("@cardno", ToDBValue(用户表.Cardno)),
						new SqlParameter("@pwd", ToDBValue(用户表.Pwd)),
						new SqlParameter("@name", ToDBValue(用户表.Name)),
						new SqlParameter("@departid", ToDBValue(用户表.Departid)),
						new SqlParameter("@noused", ToDBValue(用户表.Noused)),
					};
				SqlHelper.ExecuteNonQuery(sql, para);
				return 用户表;				
		}

        public int DeleteById(Guid id)
		{
            string sql = "DELETE 用户表 WHERE Id = @Id";

           SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@id", id)
			};
		
            return SqlHelper.ExecuteNonQuery(sql, para);
		}
		
				
        public int Update(用户表 用户表)
        {
            string sql =
                "UPDATE 用户表 " +
                "SET " +
			" cardno = @cardno" 
                +", pwd = @pwd" 
                +", name = @name" 
                +", departid = @departid" 
                +", noused = @noused" 
               
            +" WHERE id = @id";


			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@id", 用户表.Id)
					,new SqlParameter("@cardno", ToDBValue(用户表.Cardno))
					,new SqlParameter("@pwd", ToDBValue(用户表.Pwd))
					,new SqlParameter("@name", ToDBValue(用户表.Name))
					,new SqlParameter("@departid", ToDBValue(用户表.Departid))
					,new SqlParameter("@noused", ToDBValue(用户表.Noused))
			};

			return SqlHelper.ExecuteNonQuery(sql, para);
        }		
		
        public 用户表 GetById(Guid id)
        {
            string sql = "SELECT * FROM 用户表 WHERE Id = @Id";
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
		
		public 用户表 ToModel(SqlDataReader reader)
		{
			用户表 用户表 = new 用户表();

			用户表.Id = (Guid)ToModelValue(reader,"id");
			用户表.Cardno = (string)ToModelValue(reader,"cardno");
			用户表.Pwd = (string)ToModelValue(reader,"pwd");
			用户表.Name = (string)ToModelValue(reader,"name");
			用户表.Departid = (short)ToModelValue(reader,"departid");
			用户表.Noused = (bool)ToModelValue(reader,"noused");
			return 用户表;
		}
		
		public int GetTotalCount()
		{
			string sql = "SELECT count(*) FROM 用户表";
			return (int)SqlHelper.ExecuteScalar(sql);
		}
		
		public List<用户表> GetPagedData(int minrownum,int maxrownum)
		{
			string sql = "SELECT * from(SELECT *,row_number() over(order by id) rownum FROM 用户表) t where rownum>=@minrownum and rownum<=@maxrownum";
			using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql,
				new SqlParameter("@minrownum",minrownum),
				new SqlParameter("@maxrownum",maxrownum)))
			{
				return ToModels(reader);					
			}
		}
        

		
		public List<用户表> GetAll()
		{
			string sql = "SELECT * FROM 用户表";
			using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql))
			{
				return ToModels(reader);			
			}
		}
		
        public DataTable GetAllDataTable()
		{
			string sql = "SELECT a.id, rtrim(cardno) cardno , rtrim(name) , rtrim(b.部门名称), noused FROM 用户表 a left join 部门表 b on a.departid= b.id" ;
			using(DataTable dt = SqlHelper.ExecuteDataTable(sql))
			{
				return dt;			
			}
		}

        public string getPwd(string dept, string usercard)
        {
            string retval="NoPwd";
            string sql = @"select pwd from 用户表 where cardno='{0}' and departid={1}";
            sql = string.Format(sql, usercard, dept);

            SqlDataReader dr = SqlHelper.ExecuteDataReader(sql);

            if (dr.HasRows)
            {
                dr.Read();
                retval = dr.GetString(0).Trim();
            }
            dr.Close();
            return retval;
        }
        
        public string getUsernameByCard( string usercard)
        {
            string sql = @"select rtrim(name) from 用户表 where cardno = '" + usercard + "'";
            return SqlHelper.ExecuteScalar(sql).ToString();
        }
        
		protected List<用户表> ToModels(SqlDataReader reader)
		{
			var list = new List<用户表>();
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