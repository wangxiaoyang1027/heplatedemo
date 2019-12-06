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
using System.Security.Cryptography;



namespace 重装板块成本系统.forms
{
    public partial class frm_maintain_user : Form
    {
        bool add_flag;
        public frm_maintain_user()
        {
            InitializeComponent();
        }

        private void frm_maintain_user_Load(object sender, EventArgs e)
        {
            部门表DAL dal = new 部门表DAL();


            chk_admin.Text = "管理组";
            cmb_dept.DataSource = dal.GetUsedDataTableNoadmin();
            cmb_dept.ValueMember = "id";
            cmb_dept.DisplayMember = "部门名称";

            


            用户表DAL dal1 = new 用户表DAL();

            usergrid.set_date(dal1.GetAllDataTable());
            usergrid.set_head_title(1, "工作证号");
            usergrid.set_head_title(2, "姓名");
            usergrid.set_head_title(3, "部门");
            usergrid.set_head_title(4, "禁用");

            usergrid.set_width(0, 0);
            usergrid.set_width(4, 40);

            usergrid.set_hide(0);

            groupBox1.Enabled = false;

            cmb_noused.Items.Add("启用");
            cmb_noused.Items.Add("禁用");

            txt_pwd.set_title("密码：");
            txt_pwd1.set_title("确认：");

            txt_username.set_title("姓名");
            txt_cardno.set_title("工作证：");

            txt_pwd.set_Pwdtype();
            txt_pwd1.set_Pwdtype();
           

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            add_flag = true;

            groupBox1.Enabled = true;
            txt_username.set_value("");

            groupBox1.Text = "增加用户";

            


        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btn_save_Click(object sender, EventArgs e)
        {

            if (add_flag == true)
            {
                add_user();

            }
            else
            {
               

            }
            groupBox1.Enabled = false;
            用户表DAL dal1 = new 用户表DAL();
            usergrid.set_date(dal1.GetAllDataTable());
        }

        private void add_user()
        {
            用户表 mod = new 用户表();

            mod.Id = Guid.NewGuid();
            mod.Name = txt_username.get_value();
            mod.Cardno = txt_cardno.get_value();

            if (txt_pwd.get_value() != txt_pwd1.get_value())
            {
                MessageBox.Show("两次输入的密码不一致");
                return;
            }


            var md5 = new MD5CryptoServiceProvider();
            mod.Pwd = BitConverter.ToString(md5.ComputeHash(Encoding.Default.GetBytes(txt_pwd.get_value())), 4, 8);

            if (cmb_dept.Text == "")
            {
                MessageBox.Show("所属部门下拉框必须选择！");
                return;
            }
            else
            {
                mod.Departid = short.Parse(cmb_dept.SelectedValue.ToString());
            }


            mod.Noused = (cmb_noused.SelectedIndex == 1);

            用户表DAL dal = new 用户表DAL();
            dal.Add(mod);


            if (chk_admin.Checked)
            {
                mod.Departid = 1;
                mod.Id = Guid.NewGuid();
                dal.Add(mod);
            }

        }

        private void edit_user()
        {
            用户表 mod = new 用户表();

            usergrid.get_select_index();

            mod.Id = Guid.NewGuid();
            mod.Name = txt_username.get_value();
            mod.Cardno = txt_cardno.get_value();

            if (txt_pwd.get_value() != txt_pwd1.get_value())
            {
                MessageBox.Show("两次输入的密码不一致");
                return;
            }


            var md5 = new MD5CryptoServiceProvider();
            mod.Pwd = BitConverter.ToString(md5.ComputeHash(Encoding.Default.GetBytes(txt_pwd.get_value())), 4, 8);

            if (cmb_dept.Text == "")
            {
                MessageBox.Show("所属部门下拉框必须选择！");
                return;
            }
            else
            {
                mod.Departid = short.Parse(cmb_dept.SelectedValue.ToString());
            }


            mod.Noused = (cmb_noused.SelectedIndex == 1);

            用户表DAL dal = new 用户表DAL();
            dal.Add(mod);


            if (chk_admin.Checked)
            {
                mod.Departid = 1;
                mod.Id = Guid.NewGuid();
                dal.Add(mod);
            }

        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (usergrid.get_selectrow_index() >= 0)
            {
                txt_cardno.set_value(usergrid.get_value(1).ToString());
                txt_username.set_value(usergrid.get_value(2).ToString());




            }
                
            else
            {
                MessageBox.Show("请先选择一条记录！");
                return;
            }
        }
    }
}
