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


namespace 重装板块成本系统.forms
{
    public partial class frm_导入工号台时 : Form
    {
        public string deptname { get; set; }
        public int deptcode { get; set; }

        public frm_导入工号台时()
        {
            InitializeComponent();
        }

        private void ctl_grid1_Load(object sender, EventArgs e)
        {

        }

        private void frm_导入工号台时_Load(object sender, EventArgs e)
        {
            MinimizeBox = false;
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.Fixed3D;


            txt_old_gh.set_title("老工号：");
            txt_new_gh.set_title("新工号：");
            txt_filename.set_title("文件：");

            fill();

        }

        private void fill()
        {
            工号台时表DAL dal = new 工号台时表DAL();


            mygrid.set_date(dal.getDatePerMonth(mydate.Value));
            mygrid.set_hide(0);
        }

        private void mydate_ValueChanged(object sender, EventArgs e)
        {
            fill();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "EXCEL 文件(*.xls,*.xlsx)|*.xls;*.xlsx";

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txt_filename.set_value(openFileDialog1.FileName);

            }
        }

        private void btn_import_Click(object sender, EventArgs e)
        {
            if (txt_filename.get_value() == "")
            {
                MessageBox.Show("请指定文件名称");
                return;
            }
            工号表DAL ghdal = new 工号表DAL();

            工号台时表DAL dal = new 工号台时表DAL();
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();

            if ( app == null)
            {
                MessageBox.Show("Excel 启动错误， 程序将返回 ！");
                return;
            }

            Microsoft.Office.Interop.Excel.Workbook wk;
            Microsoft.Office.Interop.Excel.Worksheet sh;
            string filename = txt_filename.get_value();



            if (dal.isHasRecord(mydate.Value, deptcode))
            {
                wk = app.Workbooks.Open(filename);
                sh = null;

                foreach (Worksheet mysheet in wk.Worksheets)
                {
                    if (mysheet.Name.Trim() != "成表")
                        continue;
                    else
                    {
                        sh = mysheet;
                        break;
                    }
                }

                if (sh == null)
                {
                    MessageBox.Show("没有找到 成表 页 ！");
                    app.Quit();
                    return;
                }

                model.工号台时表 mycls;

                List<工号台时表> mylist = new List<工号台时表>();

                int myrow = 2;





                while (sh.Cells[myrow, 1].value != null)
                {
                    mycls = new 工号台时表();

                    mycls.Id = Guid.NewGuid();
                    mycls.工号 = sh.Cells[myrow, 1].value.ToString().Trim();
                    mycls.部门 = 21;
                    mycls.日期 = new DateTime(mydate.Value.Year, mydate.Value.Month, 15);
                    if (sh.Cells[myrow, 2].Value == null)
                        mycls.工时 = 0;
                    else
                        mycls.工时 = (decimal)sh.Cells[myrow, 2].Value;

                    if (sh.Cells[myrow, 3].Value == null)
                        mycls.折合工时 = 0;
                    else
                        mycls.折合工时 = (decimal)sh.Cells[myrow, 3].Value;

                    mylist.Add(mycls);
                    myrow++;
                }
                app.Quit();

                工号表DAL dal2 = new 工号表DAL();
                string wrongworkno = "";
                bool wrongflag = true;


                foreach (工号台时表 工号台时 in mylist)
                {
                    if ( !dal2.IsIn工号表( 工号台时.工号))
                    {
                        wrongworkno += 工号台时.工号 + ", ";
                        wrongflag = false;
                    }
                }
                if ( !wrongflag)
                {
                    MessageBox.Show( wrongworkno ,"错误工号" );
                    return;
                }


                工号台时表DAL da1l = new 工号台时表DAL();
                foreach (工号台时表 工号台时 in mylist)
                {
                    da1l.Add(工号台时);
                }


            }
            fill();
        }

        private void btn_chg_gh_Click(object sender, EventArgs e)
        {
            string old_workno, new_workno;

            old_workno = txt_old_gh.get_value();
            new_workno = txt_new_gh.get_value();

            if (( old_workno =="") || (new_workno == ""))
            {
                MessageBox.Show("新、旧工号不能为空 ！");
                return;
            }

            工号表DAL 工号表 = new 工号表DAL();

            if (!工号表.IsIn工号表(new_workno))
            {
                MessageBox.Show("工号错误 或者 不在工号表中 \n 请检查！");
                return;
            }


            工号台时表DAL dal = new 工号台时表DAL();
            dal.updateWorkno(old_workno, new_workno, mydate.Value, deptcode);

            MessageBox.Show("更改结束");

            fill();
        }

        private void btn_dele_Click(object sender, EventArgs e)
        {

        }
    }
}
