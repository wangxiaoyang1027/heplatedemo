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
    public partial class frm_计算费用分配 : Form
    {
        public int deptcode;
        public string deptname;

        public frm_计算费用分配()
        {
            InitializeComponent();
        }

        private void frm_计算费用分配_Load(object sender, EventArgs e)
        {
            MinimizeBox = false;
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.Fixed3D;

            Text = " 计算费用分配   部门：" + deptname;
            fill(mydate.Value, deptcode );

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ( grd_data.get_row_number() > 1)
            {
                if ( MessageBox.Show("这个月已有 费用分配 数据， 确定要重做吗 ？ " , " 警 告 ", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;
            }

            费用分配表DAL dal = new 费用分配表DAL();
            dal.计算费用分配(mydate.Value, deptcode);
            fill(mydate.Value, deptcode);
        }

        private void fill( DateTime mydate , int mydepart)
        {
            费用分配表DAL dal = new 费用分配表DAL();

            grd_data.set_date(dal.getInfoPerMonthBydeptcode(mydate, mydepart));
        }

        private void mydate_ValueChanged(object sender, EventArgs e)
        {
            fill(mydate.Value, deptcode);
        }
    }
}
