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
    public partial class frm_工时工号修改 : Form
    {
        public frm_工时工号修改()
        {
            InitializeComponent();
        }

        private void frm_工时工号修改_Load(object sender, EventArgs e)
        {
            txt_new.set_title("新工号");
            txt_old.set_title("老工号");
            MinimizeBox = false;
            MaximizeBox = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string old_workno, new_workno;
            DateTime mydate;

            old_workno = txt_old.get_value();
            new_workno = txt_new.get_value();



            Msg.Text = "";
            if (( old_workno =="") || (new_workno ==""))
            {
                Msg.Text = "工号不能为空";
                return;
            }

            工时帐DAL dal = new 工时帐DAL();

            dal.updateWorkno(old_workno, new_workno, input_date.Value);

            Msg.Text = "成功！";

        }
    }
}
