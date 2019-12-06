using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;


namespace 重装板块成本系统.dal
{
    class import_excel
    {
    }

    // 导入类
    public class cls_import
    {
        public Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
        public SqlCommand _cmd = new SqlCommand();
        public Workbook wk;
        //public System.Windows.Forms.SaveFileDialog mydialog = new SaveFileDialog();
        public int factoryid { get; set; }


        public bool init()
        {
            if (app == null)
            {
                MessageBox.Show("EXCEL文件启动错误！");
                app.DisplayAlerts = false;
                return false;
            }

            return true;
        }

        virtual public void cls_import_file()
        {


        }
    }


    // 导入材料
    public class cls_import_cailiao : cls_import
    {
        public DateTime _mydate = DateTime.Now;

        public void cls_import_file()
        {

        }

        public List<string> get_sheets_name(string filename)
        {
            List<string> sheets_name = new List<string>();


            wk = app.Workbooks.Open(filename);
            foreach (Worksheet sh in wk.Worksheets)
            {
                sheets_name.Add(sh.Name);
            }
            return sheets_name;
        }

        // 将 文件中的原始凭证数据导入数据库
        public void import_date(string mycode, string shname, int deptcode)
        {
            Worksheet sh;
            int myrow;
            SqlTransaction st;   //共享锁
            bool hasnewproject;
            SqlConnection conn ;


            conn = new SqlConnection();

            conn.ConnectionString = SqlHelper.connstr;
            try
            {
                conn.Open();
                _cmd.Connection = conn;

            }   
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return ;
            }

            myrow = 5;
            
            sh = wk.Worksheets[shname];
            hasnewproject = false;

            _cmd.Parameters.Clear();
            _cmd.CommandText = "select count(*) from 工号表 where 工作令号=@p3 and noused=0";
            _cmd.Parameters.Add("p3", SqlDbType.NChar, 20);

            while (sh.Cells[myrow, 1].value != null)
            {
                _cmd.Parameters["p3"].Value = sh.Cells[myrow, 1].value;
                if (int.Parse(_cmd.ExecuteScalar().ToString()) == 0)
                {
                    MessageBox.Show("工号" + sh.Cells[myrow, 1].value + "不存在！" + "\r\n" + "请在 工号表 里添加！");
                    hasnewproject = true;
                }
                myrow++;
            }

            if (hasnewproject)
            {
                return;
            }
            st = _cmd.Connection.BeginTransaction(IsolationLevel.ReadCommitted);   //共享锁
            try
            {
                _cmd.Parameters.Clear();
                _cmd.CommandText = "insert into 原始凭证(日期,材质,工作令号,重量,金额,凭证号,单位) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7)";

                _cmd.Transaction = st;  //事务 
                _cmd.Parameters.Add("p1", System.Data.SqlDbType.SmallDateTime);
                _cmd.Parameters["p1"].Value = _mydate;
                _cmd.Parameters.Add("p2", System.Data.SqlDbType.Char, 1);
                _cmd.Parameters["p2"].Value = mycode;
                _cmd.Parameters.Add("p3", System.Data.SqlDbType.NChar, 20);
                _cmd.Parameters.Add("p4", System.Data.SqlDbType.Decimal);
                _cmd.Parameters.Add("p5", System.Data.SqlDbType.Decimal);
                _cmd.Parameters.Add("p6", System.Data.SqlDbType.Char, 10);
                _cmd.Parameters.Add("p7", System.Data.SqlDbType.SmallInt);

                myrow = 5;
                while (sh.Cells[myrow, 1].value != null)
                {
                    _cmd.Parameters["p3"].Value = sh.Cells[myrow, 1].value;
                    _cmd.Parameters["p4"].Value = sh.Cells[myrow, 2].value;
                    if (_cmd.Parameters["p4"].Value == null)
                    {
                        _cmd.Parameters["p4"].Value = 0;
                    }
                    if (_cmd.Parameters["p4"].Value.ToString().Trim() == "")
                    {
                        _cmd.Parameters["p4"].Value = 0;
                    }

                    _cmd.Parameters["p5"].Value = sh.Cells[myrow, 3].value;
                    _cmd.Parameters["p6"].Value = sh.Cells[myrow, 4].value;
                    if (_cmd.Parameters["p6"].Value == null)
                    {
                        _cmd.Parameters["p6"].Value = "";
                    }
                    _cmd.Parameters["p7"].Value = deptcode;
                    _cmd.ExecuteNonQuery();
                    myrow++;
                }
                st.Commit();        // 事务完成
                MessageBox.Show("这个类型的材料已导入， 请选择下一类型");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                st.Rollback();
                MessageBox.Show("第" + myrow.ToString() + "行有错，请检查");
            }
            finally
            {

            }
        }


        // 将 设计费， 铁业配套，自动化配套，运输费， 安装费导入 成品库存表
        public void importOtherDate( string mycode , string shname)
        {

            Worksheet sh;
            int myrow;
            SqlTransaction st;   //共享锁
            bool hasnewproject;
            SqlConnection conn;

            conn = new SqlConnection();

            conn.ConnectionString = SqlHelper.connstr;
            try
            {
                conn.Open();
                _cmd.Connection = conn;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            myrow = 5;
            sh = wk.Worksheets[shname];
            hasnewproject = false;
            _cmd.Parameters.Clear();
            _cmd.CommandText = "select count(*) from 工号表 where 工作令号=@p3 and noused=0";
            _cmd.Parameters.Add("p3", SqlDbType.NChar, 20);

            while (sh.Cells[myrow, 1].value != null)
            {
                _cmd.Parameters["p3"].Value = sh.Cells[myrow, 1].value;
                if (int.Parse(_cmd.ExecuteScalar().ToString()) == 0)
                {
                    MessageBox.Show("工号" + sh.Cells[myrow, 1].value + "不存在！" + "\r\n" + "请在 工号表 里添加！");
                    hasnewproject = true;
                }
                myrow++;
            }

            if (hasnewproject)
            {
                return;
            }
            st = _cmd.Connection.BeginTransaction(IsolationLevel.ReadCommitted);   //共享锁

            try
            {
                _cmd.Transaction = st;

                _cmd.Parameters.Clear();
                string sql = @"insert into 成品库房表( 工作令号, 日期, {0}) values ( @p1, @p2,@p3)";

                sql = string.Format(sql, mycode);
                _cmd.Parameters.Add("p1", SqlDbType.NChar,20);
                _cmd.Parameters.Add("p2", SqlDbType.DateTime);      // 日期
                _cmd.Parameters.Add("p3", SqlDbType.Decimal);
                //_cmd.Parameters.Add("p4", SqlDbType.NChar, 20);

                _cmd.Parameters["p2"].Value = _mydate;
                //_cmd.Parameters["p4"].Value = mycode;


                myrow = 5;
                while (sh.Cells[myrow, 1].value != null)
                {
                    _cmd.Parameters["p1"].Value = sh.Cells[myrow, 1].value;     // 工号
                    _cmd.Parameters["p3"].Value = sh.Cells[myrow, 2].value;     // 费用
                    if (_cmd.Parameters["p3"].Value == null)
                    {
                        _cmd.Parameters["p3"].Value = 0;
                    }
                    if (_cmd.Parameters["p3"].Value.ToString().Trim() == "")
                    {
                        _cmd.Parameters["p3"].Value = 0;
                    }

                    _cmd.CommandText = sql;
                    _cmd.ExecuteNonQuery();
                    myrow++;

                }
                st.Commit();        // 事务完成
                MessageBox.Show("这个类型的材料已导入， 请选择下一类型");

            }
            catch ( Exception ex)
            {
                MessageBox.Show(ex.Message);
                st.Rollback();
                MessageBox.Show("第" + myrow.ToString() + "行有错，请检查");
            }


        }

    }



    


}
