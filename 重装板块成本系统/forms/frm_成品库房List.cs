using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 重装板块成本系统.dal;
using 重装板块成本系统.model;
using Microsoft.Office.Interop.Excel;
using System.Configuration;
using System.Data.SqlClient;



namespace 重装板块成本系统.forms
{
    public partial class frm_成品库房List : Form
    {
        public bool addflag;
        public string _id, _gh , tempdate;
        public DateTime _inputdate;
        public decimal _je;
        成品库房表 成品库房 = new 成品库房表();

        public frm_成品库房List()
        {
            InitializeComponent();
        }

        private void frm_成品库房List_Load(object sender, EventArgs e)
        {
            MinimizeBox = false;
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.Fixed3D;

            txt_workno.set_title("工号");
            txt_gh.set_title("工号：");
            txt_je.set_title("主制厂：");

            txt_ty.set_title("铁业配套");
            txt_zdh.set_title("自动化配套");
            txt_sj.set_title("设计费");
            txt_ys.set_title("运输费");
            txt_az.set_title("安装费");
            txt_qt.set_title("其它");
            txt_xsjy.set_title("销售结余");
            txt_gjjy.set_title("国际结余");

            btn_add.Enabled = true;
            btn_edit.Enabled = true;
            btn_del.Enabled = true;

            groupBox1.Enabled = false;
            fill(txt_workno.get_value());



            //
            txt_ty.Enabled = false;
            txt_zdh.Enabled = false;
            txt_sj.Enabled = false;
            txt_ys.Enabled = false;
            txt_az.Enabled = false;
            txt_xsjy.Enabled = false;
            txt_gjjy.Enabled = false;





        }

        private void fill(string workno)
        {
            //grd.set_date(new 成品库房DAL().get成品库房List(workno));
            grd.set_date(new 成品库房DAL().get成品库房表NEW(workno));
            grd.set_hide(0);
        }

        private void grd_Load(object sender, EventArgs e)
        {

        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook wk;
            Microsoft.Office.Interop.Excel.Worksheet mysheet;
            Range myrng;
            object[] myobj;
            System.Data.DataTable mytb = new System.Data.DataTable();


            int temprow;

            if ( app == null)
            {
                MessageBox.Show("Excel 没有启动，退出");
                return;
            }

            app.DisplayAlerts = false;

            AppSettingsReader myread = new AppSettingsReader();
            string filedir;
            try
            {
                filedir = myread.GetValue("directory", Type.GetType("System.String")).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                app.Quit();
                return;
            }

            wk = app.Workbooks.Open(filedir + "库房明细报表.xls");

            if (wk == null)
            {
                MessageBox.Show("模板文件没找到！");
                return;
            }

            try
            {
                //销售成本结算DAL dal1 = new 销售成本结算DAL();

                成品库房DAL dal1 = new 成品库房DAL();



                DateTime tempdate = mydate.Value;

                //SqlDataReader dr = dal1.get库房明细报表( tempdate );
                SqlDataReader dr = dal1.get成品库房();
                myobj = new object[13];

                mysheet = wk.Worksheets["库房明细报表"];

                if (dr.HasRows)
                {
                    temprow = 3;
                    while (dr.Read())
                    {
                        dr.GetValues(myobj);
                        myrng = mysheet.Range[mysheet.Cells[temprow, 1], mysheet.Cells[temprow, 13]];
                        //myrng.NumberFormatLocal = "0.00";
                        myrng.Value2 = myobj;
                        temprow++;
                    }
                }
                dr.Close();

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string myfilename = saveFileDialog1.FileName;
                    wk.SaveAs(myfilename);
                }
                wk.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                app.Quit();
            }

        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            grd.set_date(new 成品库房DAL().get成品库房List(txt_workno.get_value()));
            //grd.set_hide(0);
        }

        private void btn_cancle_Click(object sender, EventArgs e)
        {
            txt_gh.set_value("");
            txt_je.set_value("0");

            groupBox1.Enabled = false;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if ( txt_workno.get_value() =="")
            {
                MessageBox.Show("工号不能为空！");
                return;
            }

            if (!decimal.TryParse(txt_je.get_value().ToString(), out _je))
            {
                MessageBox.Show("金额错误！");
                return;
            }

            set成品库房();
            dal.成品库房DAL dal = new 成品库房DAL();
            if (addflag)
            {
                成品库房.id = Guid.NewGuid().ToString();
                dal.insert成品库房表( 成品库房);
            }
            else
            {
                dal.update成品库房表( new Guid(成品库房.id), 成品库房.金额);
            }

            MessageBox.Show("已保存！");

            fill(txt_workno.get_value());
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            if (grd.get_selectrow_index() == -1)
            {
                MessageBox.Show("请选择一条记录！");
                return;
            }

            tempdate = grd.get_value(2).ToString();
            if (tempdate.IndexOf("转出") > 0)
            {
                MessageBox.Show("转出记录不能修改！");
                return;
            }


            if( MessageBox.Show("你真的要删除这条记录吗？", "警 告", MessageBoxButtons.YesNo,MessageBoxIcon.Information,MessageBoxDefaultButton.Button2)== DialogResult.Yes)
            {
                _id = grd.get_value(0).ToString();

                dal.成品库房DAL dal = new 成品库房DAL();

                dal.del成品库房表ById(_id);

                fill(txt_workno.get_value());

            }




        }

        private void button1_Click(object sender, EventArgs e)
        {

            frm_库房信息导入 frm = new frm_库房信息导入();

            frm.ShowDialog();

            MessageBox.Show("导入结束 ！", " 提 示 ");

            fill( txt_gh.get_value());



        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            addflag = true;


        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            addflag = false;

            if ( grd.get_selectrow_index() == -1) {
                MessageBox.Show("请选择一条记录！");
                return;
            }

            tempdate = grd.get_value(2).ToString();
            if(tempdate.IndexOf("转出") > 0)
            {
                MessageBox.Show("转出记录不能修改！");
                return;
            }

            //getGridData();
            getGridDataNEW();



        }

        private void grd_UserMousePressed(object sender, EventArgs e)
        {

        }

        private void grd_UserControlBtnClicked(object sender, EventArgs e)
        {
            int i = grd.get_select_cell().ColumnIndex;

            if ( i <3)
            {
                MessageBox.Show("本字段不能修改 ！");
                return ;
            }

            string type;

            switch ( i)
            {
                case 3:
                    type = "I";
                    break;
                case 4:
                    type = "K";
                    break;
                case 5:
                    type = "1";
                    break;
                case 6:
                    type = "2";
                    break;
                case 7:
                    type = "N";
                    break;
                case 8:
                    type = "L";
                    break;
                case 9:
                    type = "O";
                    break;
                case 10:
                    type = "U";
                    break;
                default:
                    type = "";
                    break;
            }



        }


        private void getGridDataNEW()
        {
            成品库房.id = grd.get_value(0).ToString();
            成品库房.工作令号 = grd.get_value(1).ToString();
            //tempdate = grd.get_value(1).ToString();
            //成品库房.日期 = new DateTime(int.Parse(tempdate.Substring(0, 4)), int.Parse(tempdate.Substring(7, 2)), int.Parse(tempdate.Substring(11, 2)));
            成品库房.金额 = decimal.Parse(grd.get_value(3).ToString());

            txt_gh.set_value(成品库房.工作令号);
            txt_je.set_value(成品库房.金额.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook wk;
            Microsoft.Office.Interop.Excel.Worksheet mysheet;
            Range myrng;
            object[] myobj;
            System.Data.DataTable mytb = new System.Data.DataTable();


            int temprow;

            if (app == null)
            {
                MessageBox.Show("Excel 没有启动，退出");
                return;
            }

            app.DisplayAlerts = false;

            AppSettingsReader myread = new AppSettingsReader();
            string filedir;
            try
            {
                filedir = myread.GetValue("directory", Type.GetType("System.String")).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                app.Quit();
                return;
            }

            wk = app.Workbooks.Open(filedir + "新版库房明细报表.xls");

            if (wk == null)
            {
                MessageBox.Show("模板文件没找到！");
                return;
            }

            try
            {
                //销售成本结算DAL dal1 = new 销售成本结算DAL();

                成品库房DAL dal1 = new 成品库房DAL();



                DateTime tempdate = mydate.Value;

                //SqlDataReader dr = dal1.get库房明细报表( tempdate );
                SqlDataReader dr = dal1.get成品库房表();
                myobj = new object[16];

                mysheet = wk.Worksheets["库房明细报表"];

                if (dr.HasRows)
                {
                    temprow = 4;
                    while (dr.Read())
                    {
                        dr.GetValues(myobj);
                        myrng = mysheet.Range[mysheet.Cells[temprow, 1], mysheet.Cells[temprow, 16]];
                        //myrng.NumberFormatLocal = "0.00";
                        myrng.Value2 = myobj;
                        temprow++;
                    }
                }


                dr.Close();

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string myfilename = saveFileDialog1.FileName;
                    wk.SaveAs(myfilename);
                }
                wk.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                MessageBox.Show("导出完成！");
                app.Quit();
            }

        }




        // 从 grid 中得到 数据， EDIT 模式时使用
        private void getGridData()
        {
            string tempdate;

            //成品库房.id = grd.get_value(0).ToString();
            成品库房.工作令号 = grd.get_value(0).ToString();
            tempdate = grd.get_value(1).ToString();
            成品库房.日期 = new DateTime(int.Parse (tempdate.Substring(0, 4)), int.Parse (tempdate.Substring(7, 2)), int.Parse (tempdate.Substring(11, 2))); 
            成品库房.金额 = decimal.Parse(grd.get_value(2).ToString());
            成品库房.ty = decimal.Parse(grd.get_value(3).ToString());
            成品库房.zdh = decimal.Parse(grd.get_value(4).ToString());
            成品库房.sj = decimal.Parse(grd.get_value(5).ToString());
            成品库房.ys = decimal.Parse(grd.get_value(6).ToString());
            成品库房.az = decimal.Parse(grd.get_value(7).ToString());
            成品库房.qt = decimal.Parse(grd.get_value(8).ToString());
            成品库房.xsjy = decimal.Parse(grd.get_value(9).ToString());
            成品库房.gjjy = decimal.Parse(grd.get_value(10).ToString());


            dal.成品库房DAL dal = new 成品库房DAL();
            dateTimePicker1.Value = dal.getDateById(成品库房.id);
            成品库房.日期 = dateTimePicker1.Value;


            txt_gh.set_value(成品库房.工作令号);
            txt_je.set_value(成品库房.金额.ToString());
            txt_ty.set_value(成品库房.ty.ToString());
            txt_zdh.set_value(成品库房.zdh.ToString());
            txt_sj.set_value(成品库房.sj.ToString());
            txt_ys.set_value(成品库房.ys.ToString());
            txt_az.set_value(成品库房.az.ToString());
            txt_qt.set_value(成品库房.qt.ToString());
            txt_xsjy.set_value(成品库房.xsjy.ToString());
            txt_gjjy.set_value(成品库房.gjjy.ToString());

        }

        private void set成品库房( )
        {

            成品库房.工作令号 = txt_gh.get_value();
            成品库房.日期 = dateTimePicker1.Value;
            成品库房.金额 = decimal.Parse (txt_je.get_value());
            //成品库房.ty = decimal.Parse(txt_ty.get_value());
            //成品库房.zdh = decimal.Parse(txt_zdh.get_value());
            //成品库房.sj = decimal.Parse(txt_sj.get_value());
            //成品库房.ys = decimal.Parse(txt_ys.get_value());
            //成品库房.az = decimal.Parse(txt_az.get_value());
            //成品库房.qt = decimal.Parse(txt_qt.get_value());
            //成品库房.xsjy = decimal.Parse(txt_xsjy.get_value());
            //成品库房.gjjy = decimal.Parse(txt_gjjy.get_value());

        }
    }
}
