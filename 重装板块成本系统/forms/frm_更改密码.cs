using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Security.Cryptography;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 重装板块成本系统.dal;
using 重装板块成本系统.model;



namespace 重装板块成本系统.forms
{
    public partial class frm_更改密码 : Form
    {
        public int deptcode { get; set; }
        public string deptname { get; set; }
        public string usercard { get; set; }

        public frm_更改密码()
        {
            InitializeComponent();
        }

        private void frm_更改密码_Load(object sender, EventArgs e)
        {
            MinimizeBox = false;
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.Fixed3D;

            txt_old.set_Pwdtype();
            txt_new1.set_Pwdtype();
            txt_new2.set_Pwdtype();

            txt_old.set_title("老密码：");
            txt_new1.set_title("新密码：");
            txt_new2.set_title("重复一次");




        }

        private void btn_change_Click(object sender, EventArgs e)
        {
            string new1, new2, old;

            old = txt_old.get_value();
            new1 = txt_new1.get_value();
            new2 = txt_new2.get_value();

            if (( old =="") ||(new1=="") || (new2==""))
            {
                label1.Text = "密码不能为空";
                return;
            }

            if ( new1 != new2)
            {
                label1.Text = "新密码不一致！";
                return;
            }

            var md5 = new MD5CryptoServiceProvider();
            string t2 = BitConverter.ToString(md5.ComputeHash(Encoding.Default.GetBytes(old)), 4, 8);

            用户表DAL dal = new 用户表DAL();

            string mypwd = dal.getPwd(deptcode.ToString(), usercard);
            if (mypwd == "NoPwd")
            {
                label1.Text = "老密码错误！";
                return;
            }
            if (t2 == mypwd)
            {
                //var md5 = new MD5CryptoServiceProvider();
                用户表 mod = new 用户表();

                mod.Cardno = usercard;
                mod.Departid = (short)deptcode;
                mod.Pwd = BitConverter.ToString(md5.ComputeHash(Encoding.Default.GetBytes(new1)), 4, 8);


                dal.changPwd(mod);

                label1.Text = "密码修改完成！";
            }

        }
    }
}
