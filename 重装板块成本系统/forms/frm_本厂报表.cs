using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.Configuration;
using 重装板块成本系统.dal;
using System.Data.SqlClient;


namespace 重装板块成本系统.forms
{
    public partial class frm_本厂报表 : Form
    {
        public string deptname { get; set; }
        public int deptcode;


        public frm_本厂报表()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook wk;
            Microsoft.Office.Interop.Excel.Worksheet mysheet;
            int temprow;
            List<string> mygonghaolist = new List<string>();
            Range myrng;
            object[] myobj;
            System.Data.DataTable mytb = new System.Data.DataTable();

            if (app == null)
            {
                MessageBox.Show("Excel 没有正常打开。 ");
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

            wk = app.Workbooks.Open(filedir + "本厂成本结算模板.xls");
            //wk = app.Workbooks.Open(filedir + "成本结算模板.xls");

            if (wk == null)
            {
                MessageBox.Show("模板文件没找到！");
                return;
            }

            try
            {
                // 原材料
                原始凭证DAL dal1 = new 原始凭证DAL();

                SqlDataReader dr = dal1.get本厂原始凭证报表(mydate.Value, deptcode);
                myobj = new object[18];

                //SqlDataReader dr = dal1.get原始凭证报表(mydate.Value);
                //myobj = new object[20];
                mysheet = wk.Worksheets["材料表"];

                if (dr.HasRows)
                {
                    temprow = 3;
                    while (dr.Read())
                    {
                        dr.GetValues(myobj);
                        myrng = mysheet.Range[mysheet.Cells[temprow, 1], mysheet.Cells[temprow, 18]];
                        myrng.NumberFormatLocal = "0.00";
                        myrng.Value2 = myobj;
                        temprow++;
                    }
                }
                dr.Close();

                费用分配表DAL dal2 = new 费用分配表DAL();
                dr = dal2.getInfoPerMonthBydeptcodeReader(mydate.Value, deptcode);
                myobj = new object[7];

                mysheet = wk.Worksheets["费用分配表"];
                if (dr.HasRows)
                {
                    temprow = 4;
                    while (dr.Read())
                    {
                        dr.GetValues(myobj);
                        myrng = mysheet.Range[mysheet.Cells[temprow, 1], mysheet.Cells[temprow, 7]];
                        myrng.NumberFormatLocal = "0.00";
                        myrng.Value2 = myobj;
                        temprow++;
                    }
                }
                dr.Close();

                在制品DAL dal3 = new 在制品DAL();

                dr = dal3.导出本厂在制品卡片(mydate.Value, deptcode);
                //dr = dal3.导出在制品卡片(mydate.Value);

                myobj = new object[15];

                mysheet = wk.Worksheets["在制品卡片"];
                if (dr.HasRows)
                {
                    temprow = 3;
                    while (dr.Read())
                    {
                        dr.GetValues(myobj);
                        myrng = mysheet.Range[mysheet.Cells[temprow, 1], mysheet.Cells[temprow, 15]];
                        myrng.NumberFormatLocal = "0.00";
                        myrng.Value2 = myobj;
                        temprow++;
                    }
                }
                dr.Close();


                dr = dal3.导出本厂新版在制品卡片(mydate.Value, deptcode);
                //dr = dal3.导出新版在制品卡片(mydate.Value, deptcode);
                myobj = new object[6];

                mysheet = wk.Worksheets["在制品卡片 (新版)"];
                if (dr.HasRows)
                {
                    temprow = 4;
                    while (dr.Read())
                    {
                        dr.GetValues(myobj);
                        myrng = mysheet.Range[mysheet.Cells[temprow, 1], mysheet.Cells[temprow, 6]];
                        myrng.NumberFormatLocal = "0.00";
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

        private void frm_本厂报表_Load(object sender, EventArgs e)
        {
            label1.Text = deptname + " 报表导出";
        }
    }
}
