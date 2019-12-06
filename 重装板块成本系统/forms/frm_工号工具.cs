using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using 重装板块成本系统.dal;
using 重装板块成本系统.model;
using System.Data.OleDb;


namespace 重装板块成本系统.forms
{
    public partial class frm_工号工具 : Form
    {
        public int deptcode;


        public frm_工号工具()
        {
            InitializeComponent();
        }

        private void frm_工号工具_Load(object sender, EventArgs e)
        {
            工号表DAL dal = new 工号表DAL();

            
            

            MinimizeBox = false;
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.Fixed3D;

            txt_filename.set_title("文件名：");
            
            if(( deptcode == 41)|| (deptcode == 40))
            {
                label1.Text = "销售、国际公司导入工号信息";
                btn_operation.Text = "导入";
            }
            else
            {
                label1.Text = " ";
                btn_operation.Enabled = false;
            }

            System.Data.DataTable tb1, tb2, tb3 ;

            tb1 = dal.get行业类别();
            cmb_hy.DataSource = tb1;
            cmb_hy.DisplayMember = "行业名称";
            cmb_hy.ValueMember = "id";

            tb2 = dal.get产品类别();
            cmb_cp.DataSource = tb2;
            cmb_cp.DisplayMember = "产品类别";
            cmb_cp.ValueMember = "id";


            tb3 = dal.get订货单位();
            cmb_dept.DataSource = tb3;
            cmb_dept.DisplayMember = "订货单位";
            cmb_dept.ValueMember = "id";




        }

        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void button2_Click(object sender, EventArgs e)
        {



            if( txt_filename.get_value() !="")
            {
                txt_filename.set_value( txt_filename.get_value());
                mydo(txt_filename.get_value());
            }
            else
            {
                MessageBox.Show("请选择文件名");
            }
        }


        private void mydo( string filename)
        {
            //string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + txt_filename.get_value() + ";" + "Extended Properties=Excel 8.0;";
            //OleDbConnection conn = new OleDbConnection(strConn);
            //conn.Open();
            //string strExcel = "";

            //OleDbDataReader dr;
            //OleDbCommand myCommand = new OleDbCommand();
            //// 外贸用
            ////          strExcel = @"select 行业类别, 产品类别,订货单位, 工作令号,iif(isnull(合同号) ,'', 合同号), iif(isnull(购货单位名称),'',购货单位名称), iif(isnull(产品名称),'', 产品名称)
            ////from [工号信息$] ";


            //strExcel = @"select 产品类别, iif(isnull(行业类别) ,'', 行业类别), 订货单位, 工作令号,iif(isnull(合同号) ,'', 合同号), iif(isnull(购货单位名称),'',购货单位名称), iif(isnull(产品名称),'', 产品名称) from [工号信息$] ";

            //myCommand.Connection = conn;
            //myCommand.CommandText = strExcel;
            //dr = myCommand.ExecuteReader();

            工号表DAL dal = new 工号表DAL();
            工号表 mycls = new 工号表();
            List<工号表> mylist = new List<工号表>();


            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application(); ;
            Microsoft.Office.Interop.Excel.Workbook wk  ;
            Microsoft.Office.Interop.Excel.Worksheet sh;
            int myrow;


            if (app == null)
                return;

           wk = app.Workbooks.Open(filename);


            sh = wk.Worksheets["工号信息"];
            myrow = 3;

            try
            {

                
                while (((Range)sh.Cells[myrow,4]).Text.ToString() != "")
                {
                    mycls = new 工号表();

                    cmb_cp.Text = ((Range)sh.Cells[myrow, 1]).Text;
                    mycls.产品类别 = (short)cmb_cp.SelectedIndex;

                    cmb_hy.Text = ((Range)sh.Cells[myrow, 2]).Text ;
                    mycls.行业类别 = (short)cmb_hy.SelectedIndex;

                    cmb_dept.Text = ((Range)sh.Cells[myrow, 3]).Text ;
                    mycls.订货单位 = (short)cmb_dept.SelectedIndex;

                    mycls.工作令号 = ((Range)sh.Cells[myrow, 4]).Text;
                    mycls.合同号 = ((Range)sh.Cells[myrow, 5]).Text;
                    mycls.购货单位 = ((Range)sh.Cells[myrow, 6]).Text;
                    mycls.名称 = ((Range)sh.Cells[myrow, 7]).Text;
                    mycls.工号类型 = "正常";
                    mycls.Nocalc = false;
                    mycls.Noused = false;

                    mylist.Add(mycls);
                    myrow++;
                }
                app.Quit();

            }
            catch ( Exception ex )
            {
                MessageBox.Show(ex.Message);
                app.Quit();
                return;
            }

            foreach (工号表 mycls1 in mylist)
            {
                if (dal.IsIn工号表(mycls1.工作令号))
                {
                    dal.Update(mycls1, mycls1.工作令号);
                }
                else
                    dal.Add(mycls1);

            }

            MessageBox.Show("完成");

        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txt_filename.set_value(openFileDialog1.FileName);
            }
        }
    }
}
