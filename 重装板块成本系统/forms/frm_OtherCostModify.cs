using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using 重装板块成本系统.dal;


namespace 重装板块成本系统.forms
{
    public partial class frm_OtherCostModify : Form
    {
        public string workno { get; set; }
        public string type { get; set; }
        public string typename { get; set; }

        public frm_OtherCostModify()
        {
            InitializeComponent();
        }

        private void frm_OtherCostModify_Load(object sender, EventArgs e)
        {
            材质类别表DAL dal = new 材质类别表DAL();

            

            label1.Text = workno;

            typename = dal.getMaterialType(workno);
            label2.Text = typename;
        }
    }
}
