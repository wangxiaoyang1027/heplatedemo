using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 重装板块成本系统.dal;



namespace 重装板块成本系统.forms
{
    public partial class frm_统计凭证号 : Form
    {
        public string deptname { get; set; }
        public int deptcode { get; set; }
        public DateTime mydate { get; set; }
        public string pzh { get; set; }


        public frm_统计凭证号()
        {
            InitializeComponent();
        }

        private void frm_统计凭证号_Load(object sender, EventArgs e)
        {
            Text = " 凭证号统计 ";
            MinimizeBox = false;
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            label1.Text = deptname + mydate.Year + "年" + mydate.Month + "月";
            fill();

        }

        private void fill()
        {
            原始凭证DAL dal = new 原始凭证DAL();

            grd_data.set_date(dal.getAccountPerMonth_Pzh(deptcode, pzh, mydate));


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
