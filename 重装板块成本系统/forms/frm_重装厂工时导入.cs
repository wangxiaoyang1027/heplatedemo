using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 重装板块成本系统.dal;
using System.Data.SqlClient;
using 重装板块成本系统.model;


namespace 重装板块成本系统.forms
{
    public partial class frm_重装厂工时导入 : Form
    {
        public string deptname { get; set; }
        public int deptcode { get; set; }


        public frm_重装厂工时导入()
        {
            InitializeComponent();
        }

        private void 检查工号ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 更改工号ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                txt_filename.set_value(openFileDialog1.FileName);
        }

        private void frm_重装厂工时导入_Load(object sender, EventArgs e)
        {
            MinimizeBox = false;
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.Fixed3D;

            fill();
        }


        private void fill()
        {
            工时帐DAL dal = new 工时帐DAL();

            grd_gs.DataSource = dal.getDatePerMonth(mydate.Value, deptcode);





        }

        private void cmb_input_Click(object sender, EventArgs e)
        {

            工时帐DAL dal = new 工时帐DAL();

            if (dal.hasData( mydate.Value))
            {
                if ( MessageBox.Show ( " 已有 " + mydate.Value.Year + "年" + mydate.Value.Month+"月 的工时数据，你真的要重新导入吗？", "警 告", MessageBoxButtons.YesNo ) == DialogResult.No)
                {
                    return;
                }
                dal.removedate(mydate.Value);
            }

            btn_inport.Enabled = false;

            string mystart, myend;

            mystart = mydate.Value.Year + "-" + (mydate.Value.Month - 1).ToString("D2") + "-26";
            myend = mydate.Value.Year + "-" + mydate.Value.Month.ToString("D2") + "-26";
            SqlDataReader dr =    dal.getMesInfo(mystart, myend);

            工时帐 mod ;
            List<工时帐> mylist = new List<工时帐>();

            if ( dr.HasRows)
            {
                while (dr.Read())
                {
                    mod = new 工时帐();

                    mod.cardno = dr.GetString(0);
                    mod.工号 = dr.GetString(1);
                    mod.图号 = dr.GetString(2);
                    mod.名称 = dr.GetString(3);
                    mod.设备 = dr.GetString(4);
                    mod.件数 = int.Parse(dr.GetValue(5).ToString());
                    mod.准结 = decimal.Parse(dr.GetValue(6).ToString());
                    mod.单件 = decimal.Parse(dr.GetValue(7).ToString());
                    mod.备注 = dr.GetString(8);
                    mod.操作人 = dr.GetString(9);
                    mod.计算工号 = mod.工号;
                    mod.ID = Guid.NewGuid();
                    mod.日期 = new  DateTime(mydate.Value.Year, mydate.Value.Month, 15);

                    if (mod.件数 == 0 || ((mod.准结 == 0 )&& (mod.单件 == 0)))
                        continue;
                    if (mod.操作人 == "彭运坡" || mod.操作人 == "王峰" || mod.操作人 == "汪杰" || mod.操作人 == "赵军" || mod.操作人 == "宋根源" || mod.操作人 == "任江锋" || mod.操作人 == "白宝华" || mod.操作人 == "龚婷" || mod.操作人=="李东勋")
                        continue;
                    mylist.Add(mod);
                }
            }
            dr.Close();
            string tmpmachineno;
            foreach ( 工时帐 mod1 in mylist)
            {
                if ( mod1.设备 ==" ")
                {
                    tmpmachineno = dal.getMachineCode(mod1.cardno);
                    if( tmpmachineno == null)
                    {
                        MessageBox.Show(mod1.操作人 + " 没有指定设备，请通知MES管理员， 导入功能将退出");
                        btn_inport.Enabled = true;
                        return;
                    }
                    mod1.设备 = tmpmachineno; 
                }
            }

            foreach ( 工时帐 mod2 in mylist)
            {
                dal.Add(mod2);
            }

            dal.addWorkno();            // 增加新工号

            fill();
            btn_inport.Enabled = true;

        }

        private void 检查工号ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            forms.frm_工时工号检查 frm = new frm_工时工号检查();

            frm.mydate = this.mydate.Value;
            frm.deptcode = this.deptcode;
            frm.deptname = this.deptname;

            frm.ShowDialog();


        }

        private void 修改工号ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            forms.frm_工时工号修改 frm = new frm_工时工号修改();

            frm.ShowDialog();
        }
    }
}
