using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 重装板块成本系统.dal;
using System.Data;


namespace 重装板块成本系统.forms
{
    public partial class frm_工时工号检查 : Form
    {
        public DateTime mydate { get; set; }
        public string deptname { get; set; }
        public int deptcode { get; set; }



        public frm_工时工号检查()
        {
            InitializeComponent();
        }

        private void frm_工时工号检查_Load(object sender, EventArgs e)
        {
            工时帐DAL dal = new 工时帐DAL();

            DataTable dt =  dal.getNousedWorkno(mydate);

            if (dt.Rows.Count > 0)
            {
                msg.Text = "以下工号已被禁用， 请确认！";
                grd_date.set_date(dt);
                return;
            }

            dt = dal.getWrongWorkno(mydate);
            if ( dt.Rows.Count > 0)
            {
                msg.Text = "以下工号在工号表中不存在， 请检查！";
                grd_date.set_date(dt);
                return;
            }

        }
    }
}
