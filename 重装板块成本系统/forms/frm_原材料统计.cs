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
    public partial class frm_原材料统计 : Form
    {
        public string deptname { get; set; }
        public int deptcode { get; set; }


        public frm_原材料统计()
        {
            InitializeComponent();
        }

        private void frm_原材料统计_Load(object sender, EventArgs e)
        {
            MinimizeBox = false;
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.Fixed3D;

            label1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            原始凭证DAL dal = new 原始凭证DAL();

            data_grd.set_date(dal.getAccountPerMonth(deptcode, dateTimePicker1.Value));

            label1.Text = deptname + dateTimePicker1.Value.Year + "年" + dateTimePicker1.Value.Month + "月 原材料统计";

        }
    }
}
