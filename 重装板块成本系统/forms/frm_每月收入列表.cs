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
    public partial class frm_每月收入列表 : Form
    {
        public frm_每月收入列表()
        {
            InitializeComponent();
        }

        private void frm_每月收入列表_Load(object sender, EventArgs e)
        {
            MinimizeBox = false;
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            fill(mydate.Value);
        }

        private void fill( DateTime mydate)
        {
            每月收入DAL dal = new 每月收入DAL();


            data_grd.set_date(dal.GetAllDataTable(mydate));
            data_grd.set_hide(0);
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            fill(mydate.Value);
        }
    }
}
