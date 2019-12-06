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
    public partial class frm_调整费用分配 : Form
    {
        public string deptname { get; set; }
        public int deptcode { get; set; }
        public bool addflag { get; set; }
        public 调整费用分配表 mod = new 调整费用分配表();


        public frm_调整费用分配()
        {
            InitializeComponent();
        }

        private void frm_调整费用分配_Load(object sender, EventArgs e)
        {

            Text = "调整费用分配" + "        部门："+ deptname;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;

            MinimizeBox = false;
            MaximizeBox = false;

            txt_gz.set_title("工资福利：");
            txt_rldl.set_title("燃料动力：");
            txt_zzfy.set_title("制造费用：");

            txt_gz.set_type(2);
            txt_rldl.set_type(2);
            txt_zzfy.set_type(2);

            txt_zzfy.Enabled = false;
            txt_rldl.Enabled = false;
            txt_gz.Enabled = false;

            cmb_gonghao.Enabled = false;
            btn_save.Enabled = false;
            btn_exit.Enabled = false;



            fill();
          
          
        }


        private void fill( )
        {

            调整费用分配表DAL dal = new 调整费用分配表DAL();
            费用分配表DAL dal1 = new 费用分配表DAL();
            grd_data.set_date(dal.getDateByDept( mydate.Value,   deptcode));
            grd_data.set_hide(0);

            cmb_gonghao.DataSource = dal1.getWorkNoPerMonth(mydate.Value, deptcode);
            cmb_gonghao.DisplayMember = "工号";
            cmb_gonghao.DisplayMember = "工号";

        }

        private void mydate_ValueChanged(object sender, EventArgs e)
        {
            fill();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            txt_gz.Enabled = true;
            txt_rldl.Enabled = true;
            txt_zzfy.Enabled = true;
            cmb_gonghao.Enabled = true;

            btn_exit.Enabled = true;
            btn_save.Enabled = true;

            addflag = true;

        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if(addflag)
            {
                mod.Id = Guid.NewGuid();
                mod.工号 = cmb_gonghao.Text;
                mod.年月 = mydate.Value;
                mod.燃料调整 = decimal.Parse (txt_rldl.get_value());
                mod.薪酬调整 = decimal.Parse (txt_gz.get_value());
                mod.制造调整 = decimal.Parse (txt_zzfy.get_value());
                mod.部门 = (short)deptcode;

                调整费用分配表DAL dal = new 调整费用分配表DAL();

                dal.Add(mod);
                fill();

                btn_add.Enabled = false;
                txt_gz.Enabled = false;
                txt_rldl.Enabled = false;
                txt_zzfy.Enabled = false;
                cmb_gonghao.Enabled = false;
            }
        }

        private void btn_dele_Click(object sender, EventArgs e)
        {
            if ( grd_data.get_selectrow_index() == -1)
            {
                MessageBox.Show("请先选择一条记录 ！");
                return;
            }

            if ( MessageBox.Show( "你真的要删除这条记录吗？", "警 告", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            Guid myid = Guid.Parse(grd_data.get_value(0).ToString());

            调整费用分配表DAL dal = new 调整费用分配表DAL();
            dal.DeleteById(myid);
            fill();
        }
    }
}
