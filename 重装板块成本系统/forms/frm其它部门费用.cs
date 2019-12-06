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
    public partial class frm其它部门费用 : Form
    {
        public string deptname { get; set; }
        public int deptcode { get; set; }

        public frm其它部门费用()
        {
            InitializeComponent();
        }

        private void frm其它部门费用_Load(object sender, EventArgs e)
        {
            部门表DAL dal = new 部门表DAL();

            cmb_dept.DataSource = dal.getOtherDept();
            cmb_dept.DisplayMember = "部门名称";
            cmb_dept.ValueMember = "id";
            cmb_dept.SelectedIndex = 0;

            fill();
        }

        private void fill()
        {
            string searchstr = " where year(日期)={0} and month(日期)={1} and 单位={2}";

            searchstr = string.Format(searchstr, mydate.Value.Year, mydate.Value.Month, cmb_dept.SelectedValue);
            原始凭证DAL dal = new 原始凭证DAL();

            grid_data.set_date(dal.getDataPerMonth(searchstr));
        }
    }
}
