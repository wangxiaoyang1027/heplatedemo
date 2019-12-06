using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 重装板块成本系统.dal;
using Microsoft.Office.Interop.Excel;


namespace 重装板块成本系统.forms
{
    public partial class frm_import_excel : Form
    {
        public int deptcode  { get; set; }
        public string deptname { get; set; }
        public bool _isSale { get; set; }

        private cls_import_cailiao mycls = new cls_import_cailiao();
        //public Microsoft.Office.Interop.Excel.Application app;
        //public Microsoft.Office.Interop.Excel.Workbook wk;
        public frm_import_excel()
        {
            InitializeComponent();

        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            openFileDialog1.DefaultExt = "xls;xlsx";
            if ( openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txt_filename.Text = openFileDialog1.FileName;

                

                mycls.init();
                foreach ( string item in mycls.get_sheets_name(txt_filename.Text) )
                {
                    cmb_sheetname.Items.Add(  item);
                }
                
            }
        }

        private void frm_import_excel_Load(object sender, EventArgs e)
        {
            System.Data.DataTable tb;
            材质类别表DAL dal = new 材质类别表DAL();

            if ( _isSale )
                tb = dal.GetDataTableForSale();
            else
                tb = dal.GetDataTable();

            clsItem mycls1 ;
            foreach (DataRow myrow in tb.Rows)
            {
                mycls1 = new clsItem();
                mycls1.name = myrow["材质名称"].ToString();
                mycls1.value = myrow["材质类别"].ToString();
                cmb_type.Items.Add(mycls1);
            }

            cmb_type.ValueMember = "value";
            cmb_type.DisplayMember = "name";

            Text = "数据导入   部门："+ deptname +"  部门代码：" + deptcode;
        }

        private void btn_import_Click(object sender, EventArgs e)
        {
            string typecode;


            if ((cmb_sheetname.SelectedIndex == -1) || (cmb_type.SelectedIndex == -1))
            {
                MessageBox.Show("请先选择类别及页表");
                return;
            }
            // 得到要导入的页表

            typecode = ((clsItem)cmb_type.SelectedItem).value;
            mycls._mydate = dateTimePicker1.Value; 
            mycls.import_date(typecode, cmb_sheetname.Text , deptcode);

            cmb_sheetname.Items.RemoveAt(cmb_sheetname.SelectedIndex);
            cmb_type.Items.RemoveAt(cmb_type.SelectedIndex);
           
            cmb_type.SelectedIndex = -1;
            cmb_sheetname.SelectedIndex = -1;
            MessageBox.Show("导入完成");

        }

        private void frm_import_excel_FormClosed(object sender, FormClosedEventArgs e)
        {
            mycls.app.Quit();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
        }
    }

    public class clsItem {
        public string name { get; set; }
        public string value { get; set; }


    }


}
