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
    public partial class frm_原材料编辑 : Form
    {
        public string deptname { get; set; }
        public int deptcode { get; set; }
        public bool addflag {get;set;}
        public 原始凭证 凭证 = new 原始凭证();


        public frm_原材料编辑()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void frm_原材料编辑_Load(object sender, EventArgs e)
        {
            MinimizeBox = false;
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.Fixed3D;

            txt_gonghao.set_title("工号");
            txt_money.set_title("金额");
            txt_weight.set_title("重量");

            txt_money.set_type(2);
            txt_weight.set_type(2);

            Text = "原材料编辑    部门：" + deptname + "  代码：" + deptcode;
            lab_pzh.Text = "凭证号：" + 凭证.凭证号;

            材质类别表DAL dal = new 材质类别表DAL();

            cmb_type.DataSource = dal.GetDataTable();        //GetDataTable
            cmb_type.DisplayMember = "材质名称";
            cmb_type.ValueMember = "材质类别";

            if (!addflag)
            {
                txt_gonghao.set_value(凭证.工作令号);
                txt_weight.set_value(凭证.重量.ToString());
                txt_money.set_value(凭证.金额.ToString());

                cmb_type.SelectedValue = 凭证.材质;
            }

        }

        private void btn_save_Click(object sender, EventArgs e)
        {

            if( txt_gonghao.get_value() =="")
            {
                MessageBox.Show("工号必须填写！");
                return;
            }
           
            凭证.工作令号 = txt_gonghao.get_value();
            凭证.材质 = cmb_type.SelectedValue.ToString();
            凭证.重量 = decimal.Parse(txt_weight.get_value());
            凭证.金额 = decimal.Parse(txt_money.get_value());

            工号表DAL dal1 = new 工号表DAL();

            if (!dal1.IsIn工号表(凭证.工作令号))
            {
                MessageBox.Show("工号错误 或者 不在工号表中 ！" + "\n" + "请检查！");
                return;
            }



            原始凭证DAL dal = new 原始凭证DAL();
            if (addflag) {
                凭证.Id = Guid.NewGuid();
                dal.Add(凭证);
                txt_weight.set_value("");
                txt_money.set_value("");
                txt_gonghao.set_value("");
            }
            else
            {
                dal.Update(凭证);

                this.Close();
            }

        }
    }
}
