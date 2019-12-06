using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 重装板块成本系统.dal;
using 重装板块成本系统.model;

namespace 重装板块成本系统.forms
{
    public partial class frm_成品库房转出 : Form
    {
        bool addflag;
        Guid myid;
        成品库房表 成品库房 = new 成品库房表();

        public frm_成品库房转出()
        {
            InitializeComponent();
        }

        private void frm_成品库房转出_Load(object sender, EventArgs e)
        {
            MinimizeBox = false;
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            txt_workno.set_title("工号：");
            txt_workno1.set_title("工号：");
            txt_je.set_title("主制厂:");
            txt_ty.set_title("铁业配套");
            txt_zdh.set_title("自动化配套");
            txt_sj.set_title("设计费");
            txt_ys.set_title("运输费");
            txt_az.set_title("安装费");
            txt_qt.set_title("其它");
            txt_xsjy.set_title("销售结余");
            txt_gjjy.set_title("国际结余");




            groupBox1.Enabled = false;

            fill(txt_workno.get_value(), chk_type.Checked);
            grd.set_width(1, 140);
            grd.set_width(2, 160);

        }
        private void fill( string workno, bool chk = false)
        {
            grd.set_date(new 成品库房DAL().get成品库房List(txt_workno.get_value(), chk));
            //grd.set_hide(0);
        }

        private void grd_Click(object sender, EventArgs e)
        {
            string val = grd.get_value(grd.get_select_index(), 2).ToString();

            if ( val.IndexOf("转出")> 0)
            {
                btn_out.Text = "修改";
            }
            else
            {
                btn_out.Text = "转出";
            }

        }

        private void btn_out_Click(object sender, EventArgs e)
        {
            int index;
            //decimal cost;
            string workno;


            index = grd.get_selectrow_index();
            if ( index == -1)
            {
                MessageBox.Show("请选择一条记录 ！");
                return;
            }

            btn_out.Enabled = false;
            btn_edit.Enabled = false;
            chk_type.Enabled = false;
            btn_search.Enabled = false;
            btn_del.Enabled = false;

            addflag = true;
            groupBox1.Enabled = true;

            workno = grd.get_value(index, 0).ToString();
            txt_workno1.set_value(workno);


            //cost = dal.getCostbyWorkno(workno)*(-1);
            //txt_je.set_value( cost.ToString());
            成品库房DAL dal = new 成品库房DAL();

            成品库房 = dal.getCostByWorkno(workno);
            成品库房.日期 = mydate.Value;

            set_txt_out(成品库房);


        }


        private void set_txt( 成品库房表  mod)
        {

            txt_je.set_value(mod.金额.ToString());
            txt_ty.set_value(mod.ty.ToString());
            txt_zdh.set_value(mod.zdh.ToString());
            txt_sj.set_value(mod.sj.ToString());
            txt_ys.set_value(mod.ys.ToString());
            txt_az.set_value(mod.az.ToString());
            txt_qt.set_value(mod.qt.ToString());
            txt_xsjy.set_value(mod.xsjy.ToString());
            txt_gjjy.set_value(mod.gjjy.ToString());

        }


        private void set_txt_out(成品库房表 mod)
        {

            txt_je.set_value((mod.金额*(-1)).ToString());
            txt_ty.set_value((mod.ty*(-1)).ToString());
            txt_zdh.set_value((mod.zdh*(-1)).ToString());
            txt_sj.set_value((mod.sj*(-1)).ToString());
            txt_ys.set_value((mod.ys*(-1)).ToString());
            txt_az.set_value((mod.az*(-1)).ToString());
            txt_qt.set_value((mod.qt*(-1)).ToString());
            txt_xsjy.set_value((mod.xsjy*(-1)).ToString());
            txt_gjjy.set_value((mod.gjjy*(-1)).ToString());

        }


        // 




        // 将输入框中的信息放入 成品库房表类 中
        private void get_txt(成品库房表 mod)
        {
            mod.金额 = decimal.Parse(txt_je.get_value());
            mod.ty = decimal.Parse(txt_ty.get_value());
            mod.zdh = decimal.Parse(txt_zdh.get_value());
            mod.sj = decimal.Parse(txt_sj.get_value());
            mod.ys = decimal.Parse(txt_ys.get_value());
            mod.az = decimal.Parse(txt_az.get_value());
            mod.qt = decimal.Parse(txt_qt.get_value());
            mod.xsjy = decimal.Parse(txt_xsjy.get_value());
            mod.gjjy = decimal.Parse(txt_gjjy.get_value());
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            //DateTime outdate = mydate.Value;
            //string gh = txt_workno1.get_value();
            //decimal cost = decimal.Parse(txt_je.get_value());

            get_txt(成品库房);

            Guid id = Guid.NewGuid(); 

            成品库房DAL dal = new 成品库房DAL();
            if (addflag)
            {
                成品库房.id = Guid.NewGuid().ToString();
                dal.insert成品库房表_转出( 成品库房);
            }
            else
            {
                成品库房.id = Guid.NewGuid().ToString();
                dal.update成品库房表_转出(成品库房);
            }

            fill(txt_workno.get_value(), chk_type.Checked);

            txt_je.set_value("");
            txt_workno1.set_value("");

            groupBox1.Enabled = false;
            btn_out.Enabled = true;
            btn_edit.Enabled = true;
            chk_type.Enabled = true;
            btn_search.Enabled = true;
            btn_del.Enabled = true;


        }

        private void grd_UserMouseClick(object sender, EventArgs e)
        {
           
        }

        private void btn_cancle_Click(object sender, EventArgs e)
        {
            txt_je.set_value("");
            txt_workno1.set_value("");

            groupBox1.Enabled = false;
            btn_out.Enabled = true;
            btn_edit.Enabled = true;
            chk_type.Enabled = true;
            btn_search.Enabled = true;
            btn_del.Enabled = true;

        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            int index;
            DateTime tmpdate;
            string workno;
            string tempstr;

            index = grd.get_selectrow_index();
            if (index == -1)
            {
                MessageBox.Show("请选择一条记录 ！");
                return;
            }

            tempstr = grd.get_value(index, 1).ToString();
            if(tempstr.IndexOf("转出")<0)
            {
                MessageBox.Show(" 只能对‘转出项’ 进行修改 ！ ");
                return;
            }

            btn_out.Enabled = false;
            btn_edit.Enabled = false;
            chk_type.Enabled = false;
            btn_search.Enabled = false;
            btn_del.Enabled = false;

            addflag = false;
            groupBox1.Enabled = true;

            workno = grd.get_value(index, 0).ToString().Trim() ;
            tmpdate = new DateTime(int.Parse (tempstr.Substring(0, 4)), int.Parse( tempstr.Substring( 5,2)) ,15) ;

            成品库房DAL dal = new 成品库房DAL();

            成品库房 = dal.getInfoByWorkno(workno,tmpdate);
            set_txt(成品库房);

            //workno = grd.get_value(index, 1).ToString();
            //txt_workno1.set_value(workno);

            //myid = Guid.Parse(grd.get_value(index, 0).ToString());

            //txt_je.set_value(grd.get_value(index, 3).ToString());




        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            fill(txt_workno.get_value(), chk_type.Checked);
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            string workno;
            DateTime tmpdate;
            int rowindex;

            rowindex = grd.get_selectrow_index();

            if ( rowindex == -1)
            {
                MessageBox.Show(" 请选择一条转出记录 ！");
                return;
            }

            string value = grd.get_value(rowindex, 1).ToString();
            if ( value.IndexOf( "转出")<0)
            {
                MessageBox.Show(" 请选择一条转出记录 ！");
                return;
            }

            if (MessageBox.Show("你真的要删除这个记录吗？", "警 告", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            成品库房DAL dal = new 成品库房DAL();

            workno = grd.get_value(rowindex, 0).ToString().Trim();
            tmpdate = new DateTime(int.Parse(value.Substring(0, 4)), int.Parse(value.Substring(5, 2)), 15);


            dal.del成品库房表_转出( workno, tmpdate);

            //id = grd.get_value(rowindex, 0).ToString();

            //销售成本结算DAL dal = new 销售成本结算DAL();

            //dal.removedate(id);

            fill(txt_workno.get_value(), chk_type.Checked);


        }

        private void chk_type_CheckedChanged(object sender, EventArgs e)
        {
            fill( txt_workno.get_value(), chk_type.Checked);
        }
    }

}
