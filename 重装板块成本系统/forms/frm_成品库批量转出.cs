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

namespace 重装板块成本系统.forms
{


    public partial class frm_成品库批量转出 : Form
    {
        Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
        Microsoft.Office.Interop.Excel.Workbook wb;


        public DataTable _mytable;
        public frm_成品库批量转出()
        {
            InitializeComponent();
        }

        private void frm_成品库批量转出_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            FormBorderStyle = FormBorderStyle.Fixed3D;

            _mytable = new DataTable();

            _mytable.Columns.Add("转出", Type.GetType("System.Boolean"));
            _mytable.Columns.Add("工号", Type.GetType("System.String"));
            _mytable.Columns.Add("主机厂", Type.GetType("System.Decimal"));
            _mytable.Columns.Add("铁业配套", Type.GetType("System.Decimal"));
            _mytable.Columns.Add("自动化配套", Type.GetType("System.Decimal"));
            _mytable.Columns.Add("设计费", Type.GetType("System.Decimal"));
            _mytable.Columns.Add("运输费", Type.GetType("System.Decimal"));
            _mytable.Columns.Add("安装费", Type.GetType("System.Decimal"));
            _mytable.Columns.Add("其它", Type.GetType("System.Decimal"));
            _mytable.Columns.Add("销售结余", Type.GetType("System.Decimal"));
            _mytable.Columns.Add("国际结余", Type.GetType("System.Decimal"));

            btn_export.Enabled = false;

            fill();
        }

        private void fill()
        {
            DataTable tb = new 成品库房DAL().getSumCost(mydate.Value);

            DataRow newrow;

            _mytable.Rows.Clear();
            foreach ( DataRow myrow in tb.Rows)
            {
                newrow = _mytable.NewRow();

                newrow[0] = false;
                newrow[1] = myrow[0];
                newrow[2] = myrow[1];
                newrow[3] = myrow[2];
                newrow[4] = myrow[3];
                newrow[5] = myrow[4];
                newrow[6] = myrow[5];
                newrow[7] = myrow[6];
                newrow[8] = myrow[7];
                newrow[9] = myrow[8];
                newrow[10] = myrow[9];


                _mytable.Rows.Add(newrow);
            }
            mygrid.set_date(_mytable);

            mygrid.set_col_editable(0, true);
        }

        private void mydate_ValueChanged(object sender, EventArgs e)
        {
            fill();
        }

        private void mygrid_MouseClick(object sender, MouseEventArgs e)
        {
            

        }

        private void mygrid_UserMouseClick(object sender, EventArgs e)
        {
            DataGridViewCell tempcell = mygrid.get_select_cell();

            if (tempcell != null)
            {
                if (tempcell.ColumnIndex == 0)
                {
                    tempcell.Value = !bool.Parse(tempcell.Value.ToString());
                }
            }
        }


        // 批量转出
        private void btn_export_Click(object sender, EventArgs e)
        {
            int rowcount = mygrid.get_row_number();
            decimal mycost;
            成品库房DAL dal = new 成品库房DAL();
            成品库房表 mod = new 成品库房表();

            //foreach ( DataGridViewRow  myrow in mygri)
            for (int i = 0; i < rowcount; i++)
            {
                if ( bool.Parse (mygrid.get_value(i, 0).ToString()))
                {

                    mod = dal.getCostByWorkno(mygrid.get_value(i, 1).ToString());
                    mod.id = Guid.NewGuid().ToString();
                    mod.日期 = mydate.Value;


                    mod.金额 *= (-1);
                    mod.ty *= (-1);
                    mod.zdh *= (-1);
                    mod.sj *= (-1);
                    mod.ys *= (-1);
                    mod.az *= (-1);
                    mod.qt *= (-1);
                    mod.xsjy *= (-1);
                    mod.gjjy *= (-1);

                    dal.insert成品库房表_转出(mod);
                }
            }

            MessageBox.Show("转出完成！");
            fill();

            btn_export.Enabled = false;

        }

        private void mygrid_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void mygrid_UserControlBtnClicked(object sender, EventArgs e)
        {
            int irow, icol; ;

            icol = mygrid.get_select_cell().ColumnIndex;
            irow = mygrid.get_select_cell().RowIndex;

            if ( icol == 4)
            {
                bool exportflag;

                exportflag = bool.Parse(mygrid.get_value(irow, 3).ToString());

                if ( exportflag)
                {
                    mygrid.set_edit(irow, icol);
                }


            }
            else
                mygrid.set_ReadOnly(true);
        }

        private void btn_all_Click(object sender, EventArgs e)
        {

        }

        private void chk_all_CheckedChanged(object sender, EventArgs e)
        {
            int irow;
            decimal mycost;

            irow = mygrid.get_row_number();

            if ( chk_all.Checked)
            {
                for (int i = 0; i < irow; i++)
                {
                    mygrid.set_a_date(i, 0, chk_all.Checked);
                }
            }
            else
            {
                for (int i = 0; i < irow; i++)
                {
                    mygrid.set_a_date(i, 0, chk_all.Checked);
                }
            }
        }

        private void btn_file_Click(object sender, EventArgs e)
        {
            string filename; 
            if ( openFileDialog1.ShowDialog() == DialogResult.OK )
            {
                filename = openFileDialog1.FileName;

               

                wb = app.Workbooks.Open(filename);

                foreach ( Microsoft.Office.Interop.Excel.Worksheet sh  in wb.Worksheets)
                {
                    cmb_sheets.Items.Add(sh.Name);
                }
            }

        }

        private void btn_check_Click(object sender, EventArgs e)
        {
            if ( cmb_sheets.Text == "")
            {
                MessageBox.Show("请选择页表");
                
            }
            else
            {
                Microsoft.Office.Interop.Excel.Worksheet ws = wb.Worksheets[cmb_sheets.Text];
                Microsoft.Office.Interop.Excel.Range rng;
                bool isfind = false;

                List<string> myworkno = new List<string>();
                try
                {
                    int myrow = 2;
                    rng = ws.Range[ws.Cells[myrow, 1], ws.Cells[myrow, 1]];
                    while (   !string.IsNullOrEmpty(rng.Value2))
                    {
                        myworkno.Add(rng.Value2);
                        myrow++;
                        rng = ws.Range[ws.Cells[myrow, 1], ws.Cells[myrow, 1]];
                    }

                    int mylength = mygrid.get_row_number();
                    foreach ( string s_name in myworkno)
                    {
                        isfind = false;
                        for ( int tempi = 0; tempi< mylength; tempi++)
                        {
                            if ( s_name.Trim() == mygrid.get_value(tempi, 1).ToString().Trim())
                            {
                                mygrid.set_a_date(tempi, 0, true);
                                isfind = true;
                            }
                        }

                        if ( !isfind)
                        {
                            MessageBox.Show("工号：" + s_name + "没有库存， 不能转出 ！ ");
                            break;
                        }


                    }
                    btn_export.Enabled = isfind;

                    MessageBox.Show("检查完成！");

                }
                catch ( Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    wb.Close();
                    app.Quit();
                }


            }

        }
    }
}
