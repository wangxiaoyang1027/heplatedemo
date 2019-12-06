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
    public partial class frm_成品库房查询 : Form
    {
        public frm_成品库房查询()
        {
            InitializeComponent();
        }

        private void frm_成品库房查询_Load(object sender, EventArgs e)
        {
            txt_workno.set_title("工号：");
            MinimizeBox = false;
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.Fixed3D;

            grd.set_date(new 成品库房DAL().getinfo(""));

        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            string tempstr = txt_workno.get_value();

            grd.set_date(new 成品库房DAL().getinfo(tempstr));
        }
    }
}
