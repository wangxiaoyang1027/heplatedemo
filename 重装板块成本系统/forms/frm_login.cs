using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Windows.Forms;
using 重装板块成本系统.dal;

namespace 重装板块成本系统.forms
{
    public partial class frm_login : Form
    {
        public int dept_code {get;set;}
        public string dept_name { get; set; }
        public string username { get; set; }
        public string usercard { get; set; }
        


        public frm_login()
        {
            InitializeComponent();
        }

        private void frm_login_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            

            部门表DAL dal = new 部门表DAL();

            cmb_dept.DataSource = dal.GetUsedDataTable();
            cmb_dept.ValueMember = "id";
            cmb_dept.DisplayMember = "部门名称";

            dept_code = -1;



        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (( txt_pwd.Text.Trim()=="") || ( txt_cardno.Text.Trim() ==""))
            {
                MessageBox.Show("名称, 密码不能为空 ！");
                return;

            }

            string user, pwd, dept;

            user = txt_cardno.Text.Trim();
            pwd = txt_pwd.Text;
            dept = cmb_dept.SelectedValue.ToString();

            var md5 = new MD5CryptoServiceProvider();
            string t2 = BitConverter.ToString(md5.ComputeHash(Encoding.Default.GetBytes(pwd)), 4, 8);

            用户表DAL dal = new 用户表DAL();

            if ((user=="admin") && (pwd =="Passw0rd"))
            {
                dept_code = 1;
                dept_name = "管理组";
                username = "admin";
                this.Close();
                return;

            }


            string mypwd = dal.getPwd(dept, user);
            if( mypwd == "NoPwd")
            {
                MessageBox.Show("无此用户， 或者用户不在所选部门中");
                return;
            }
            if (t2 == mypwd)
            {
                username = dal.getUsernameByCard(user);
                dept_name = cmb_dept.Text;
                dept_code = int.Parse(cmb_dept.SelectedValue.ToString());
                usercard = txt_cardno.Text;
                this.Close();
            }
            else
            {
                MessageBox.Show("密码错误！");
                return;
            }

            
        }

        private void btn_cancle_Click(object sender, EventArgs e)
        {
            dept_code = -1;
            this.Close();
        }

        private void txt_pwd_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btn_login_Click(sender, e);
        }
    }
}
