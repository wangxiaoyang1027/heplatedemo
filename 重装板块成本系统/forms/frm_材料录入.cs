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
    public partial class frm_材料录入 : Form
    {
        public string _deptname { get; set; }
        public int _deptcode { get; set; }


        public frm_材料录入()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void frm_材料录入_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            MinimizeBox = false;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            
            if ( _deptcode >=40)
                Text = "库存录入窗口   部门：" + _deptname + "  代码：" + _deptcode;
            else
                Text = "材料录入窗口   部门：" + _deptname + "  代码：" + _deptcode;

            txt_pzh.set_title("凭证号：");

            fill();
        }


        private void fill()
        {
            string searchstr;
            DateTime mydate;

            mydate = start_date.Value;

            searchstr = " and year(日期)={0} and month(日期)={1} and 单位={2}";
            if (txt_pzh.get_value() != "")
            {
                if (checkBox1.Checked)
                    searchstr += " and 工作令号='{3}'";
                else
                    searchstr += " and 凭证号='{3}'";
                searchstr = string.Format(searchstr, mydate.Year, mydate.Month, _deptcode, txt_pzh.get_value());
            }
            else
            {
                searchstr = string.Format(searchstr, mydate.Year, mydate.Month, _deptcode);

            }

            原始凭证DAL dal = new 原始凭证DAL();

            grd_date.set_date(dal.getDataPerMonth(searchstr));
            grd_date.set_hide(0);
            grd_date.set_width(1, 130);
            grd_date.set_width(2, 80);
            grd_date.set_width(3, 100);
            grd_date.set_width(4, 150);

        }



        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                txt_pzh.set_title("工号：");
            else
                txt_pzh.set_title("凭证号：");
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            fill();
        }

        private void start_date_ValueChanged(object sender, EventArgs e)
        {
            //btn_search_Click( sender,e);
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            forms.frm_原材料编辑 frm = new frm_原材料编辑();

            if (checkBox1.Checked)
            {
                MessageBox.Show("不能以工号输入！ 请转成 凭证号 ");
                return;
            }

            if ( txt_pzh.get_value() == "")
            {
                MessageBox.Show("凭证号不能为空！");
                return;
            }

            frm.deptcode = this._deptcode;
            frm.deptname = this._deptname;
            frm.addflag = true;

            frm.凭证.Id = Guid.NewGuid();
            frm.凭证.凭证号 = txt_pzh.get_value();
            frm.凭证.单位 = (short)frm.deptcode;
            frm.凭证.工作令号 = "";
            frm.凭证.日期 = start_date.Value;
            frm.凭证.材质 = "";
            frm.凭证.重量 = 0;
            frm.凭证.金额 = 0;

            frm.ShowDialog();

            fill();
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if( grd_date.get_selectrow_index() == -1)
            {
                MessageBox.Show("请先选中一条记录， 然后再编辑");
                return;
            }


            forms.frm_原材料编辑 frm = new frm_原材料编辑();
            frm.deptcode = this._deptcode;
            frm.deptname = this._deptname;
            frm.addflag = false;

            原始凭证DAL dal = new 原始凭证DAL();


            frm.凭证.Id =  new Guid(grd_date.get_value(0).ToString());

            frm.凭证 = dal.GetById(frm.凭证.Id);

            frm.ShowDialog();




        }

        private void btn_dele_Click(object sender, EventArgs e)
        {
            if (grd_date.get_selectrow_index() == -1)
            {
                MessageBox.Show("请先选中一条记录， 然后再操作！");
                return;
            }

            if ( MessageBox.Show("你真的要删除这条记录吗？","警 告", MessageBoxButtons.YesNo ) == DialogResult.Yes)
            {
                原始凭证DAL dal = new 原始凭证DAL();
                Guid id = new Guid(grd_date.get_value(0).ToString());

                dal.DeleteById(id);
            }
            fill();

        }

        private void btn_calc_Click(object sender, EventArgs e)
        {
             if (checkBox1.Checked)
            {
                MessageBox.Show("本功能只能核对同一凭证号的数据！" + "\n" + "请取消 工号勾选");
                return;
            }
            string phz;
            phz = txt_pzh.get_value();
             if(  phz == "")
            {
                MessageBox.Show("必须输入 凭证号");
                return;
            }

            forms.frm_统计凭证号 frm = new frm_统计凭证号();

            frm.deptcode = _deptcode;
            frm.pzh = txt_pzh.get_value();
            frm.deptname = _deptname;
            frm.mydate = start_date.Value;

            frm.ShowDialog();
        }
    }
}
