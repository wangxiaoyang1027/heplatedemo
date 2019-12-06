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
    public partial class frm_每月费用录入 : Form
    {
        public string deptname { get; set; }
        public int deptcode { get; set; }
        public bool addflag { get; set; }
        private 其他费用表 mod = new 其他费用表();


        public frm_每月费用录入()
        {
            InitializeComponent();
           


        }

        private void frm_每月费用录入_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            MinimizeBox = false;
            MaximizeBox = false;

            btn_save.Text = " 保 存 ";
            btn_cancle.Text = " 取 消 ";
            Text = "其他费用录入窗口";

            txt_rldl.set_title("燃料动力：");
            txt_gzfl.set_title("薪酬：");
            txt_zzfy.set_title("制造费用");

            lab_title.Text = deptname + "其他费用输入表";

            groupBox1.Enabled = false;

            

            fill_date( deptcode);
        }


        public void fill_date(int deptcode)
        {
            其他费用表DAL dal = new 其他费用表DAL();

            grd_data.set_date(dal.getDateBydeptcode(deptcode));
            grd_data.set_hide(0);

            grd_data.set_width(1, 130);
            grd_data.set_width(2, 150);
            grd_data.set_width(3, 150);
            grd_data.set_width(4, 150);

            txt_gzfl.set_type(2);
            txt_rldl.set_type(2);
            txt_zzfy.set_type(2);
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            addflag = true;

            




        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            
            if (addflag)
            {
                //mod = new 其他费用表();
                mod.Id = Guid.NewGuid();
                mod.制造费用 = decimal.Parse (txt_zzfy.get_value());
                mod.燃料动力 = decimal.Parse(txt_rldl.get_value());
                mod.薪酬 = decimal.Parse(txt_gzfl.get_value());
                mod.年月 = mydate.Value;
                mod.部门 = (short) deptcode;

                其他费用表DAL dal = new 其他费用表DAL();

                dal.Add(mod);
            }
            else
            {
                int selectedrow;

                selectedrow = grd_data.get_selectrow_index();
                //mod.Id = Guid.Parse(grd_data.get_value(0).ToString());
                mod.制造费用 = decimal.Parse(txt_zzfy.get_value());
                mod.燃料动力 = decimal.Parse(txt_rldl.get_value());
                mod.薪酬 = decimal.Parse(txt_gzfl.get_value());
                mod.年月 = mydate.Value;
                mod.部门 = (short)deptcode;

                其他费用表DAL dal = new 其他费用表DAL();

                dal.Update(mod);
            }
            fill_date(deptcode);

        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (grd_data.get_selectrow_index() == -1)
            {
                MessageBox.Show("请选择一条记录！");
                return;
            }

            groupBox1.Enabled = true;
            int selectedrow;

            addflag = false;

            selectedrow = grd_data.get_selectrow_index();
            mod.Id = Guid.Parse (grd_data.get_value(0).ToString());
            其他费用表DAL dal = new 其他费用表DAL();

            mod = dal.GetById(mod.Id);

            txt_gzfl.set_value(mod.薪酬.ToString());
            txt_rldl.set_value(mod.燃料动力.ToString());
            txt_zzfy.set_value(mod.制造费用.ToString());

        }
    }


   
}
