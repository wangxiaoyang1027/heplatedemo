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
    public partial class frm_销售成本结算表 : Form
    {
        public frm_销售成本结算表()
        {
            InitializeComponent();
        }

        private void frm_销售成本结算表_Load(object sender, EventArgs e)
        {
            MinimizeBox = false;
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.Fixed3D;

        }

        private void btn_export_Click(object sender, EventArgs e)
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

            wk = app.Workbooks.Open(filedir + "销售成本结算模板.xls");
            //wk = app.Workbooks.Open(filedir + "成本结算模板.xls");

            if (wk == null)
            {
                MessageBox.Show("模板文件没找到！");
                return;
            }


            try
            {
                销售成本结算DAL dal1 = new 销售成本结算DAL();

                SqlDataReader dr = dal1.get销售成本结算表(mydate.Value);
                myobj = new object[8];

                mysheet = wk.Worksheets["在制品品余额表"];

                if (dr.HasRows)
                {
                    temprow = 4;
                    while (dr.Read())
                    {
                        dr.GetValues(myobj);
                        myrng = mysheet.Range[mysheet.Cells[temprow, 1], mysheet.Cells[temprow, 8]];
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
    }
}
