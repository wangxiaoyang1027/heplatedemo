using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 重装板块成本系统.dal;
using System.Data.SqlClient;


namespace 重装板块成本系统.forms
{
    public partial class frm_otherCost : Form
    {
        public int deptcode { get; set; }
        public string deptname { get; set; }
        private cls_import_cailiao mycls = new cls_import_cailiao();
        

        public frm_otherCost()
        {
            InitializeComponent();
        }

        private void frm_otherCost_Load(object sender, EventArgs e)
        {
            this.Text = "其它费用导入";

            dal.材质类别表DAL dal = new 材质类别表DAL();
            System.Data.DataTable tb = dal.GetDataTableForSale();

            clsItem mycls1;
            foreach (DataRow myrow in tb.Rows)
            {
                mycls1 = new clsItem();
                mycls1.name = myrow["材质名称"].ToString();
                mycls1.value = myrow["材质类别"].ToString();
                cmb_type.Items.Add(mycls1);
            }

            cmb_type.ValueMember = "value";
            cmb_type.DisplayMember = "name";

            Text = "销售部门数据导入";


            //dal.OtherCostDal dal = new OtherCostDal();

            //this.FormBorderStyle = FormBorderStyle.Fixed3D;

            //SqlDataReader dr = dal.getOtherCostName();

            //while (dr.Read())
            //{
            //    cmb_type.Items.Add(dr.GetString(0));
            //}
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            openFileDialog1.DefaultExt = "xls;xlsx";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txt_filename.Text = openFileDialog1.FileName;



                mycls.init();
                foreach (string item in mycls.get_sheets_name(txt_filename.Text))
                {
                    cmb_sheetname.Items.Add(item);
                }

            }
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

            typecode = cmb_type.Text ;
            mycls._mydate = dateTimePicker1.Value;
            mycls.importOtherDate(typecode, cmb_sheetname.Text);

            cmb_sheetname.Items.RemoveAt(cmb_sheetname.SelectedIndex);
            cmb_type.Items.RemoveAt(cmb_type.SelectedIndex);

            cmb_type.SelectedIndex = -1;
            cmb_sheetname.SelectedIndex = -1;
        }

        private void frm_otherCost_FormClosed(object sender, FormClosedEventArgs e)
        {
            mycls.app.Quit();
        }
    }
}
