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
    public partial class frm_worknoMaintain : Form
    {
        private bool addflag;
        private string old_workno ; 
        public frm_worknoMaintain()
        {
            InitializeComponent();
        }

        private void frm_worknoMaintain_Load(object sender, EventArgs e)
        {
            Text = "工号维护";
            MinimizeBox = false;
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.Fixed3D;

            button1.Text = "增加";
            button2.Text = "编辑";
            button3.Text = "退出";

            groupBox1.Enabled = false;
            

            txt_search.set_title("工号：");
            txt_workno.set_title("工号：");
            txt_name.set_title("名称：");
            txt_hth.set_title("合同号");
            //txt_dhdw.set_title("订货单位");
            txt_ghdw.set_title("购货单位");

            cmb_hylb.DataSource = (new 工号表DAL()).get行业类别();
            cmb_hylb.ValueMember = "id";
            cmb_hylb.DisplayMember = "行业名称";

            cmb_cplb.DataSource = (new 工号表DAL()).get产品类别();
            cmb_cplb.ValueMember = "id";
            cmb_cplb.DisplayMember = "产品类别";

            cmb_dhdw.DataSource = (new 工号表DAL()).get订货单位();
            cmb_dhdw.ValueMember = "id";
            cmb_dhdw.DisplayMember = "订货单位";


            工号表DAL dal = new 工号表DAL();

            cmb_worknotype.DataSource = dal.get工号类型();
            cmb_worknotype.DisplayMember = "工号类型";
            cmb_worknotype.ValueMember = "工号类型";



            fill();
        }

        private void fill()
        {
            工号表DAL dal = new 工号表DAL();

            grd.set_date(dal.GetAllDataTable());
            grd.set_width(0, 160);
            grd.set_head_title(0, "工号");

            grd.set_width(1, 250);
            grd.set_head_title(1, "名称");

            grd.set_width(2, 40);
            grd.set_head_title(2, "禁用");

            grd.set_width(3, 40);
            grd.set_head_title(3, "不计算"); 




        }

        private void fill(string workno)
        {
            工号表DAL dal = new 工号表DAL();

            grd.set_date(dal.GetDataTableByWorkno(workno));

        }

        private void button1_Click(object sender, EventArgs e)
        {
            addflag = true;

            groupBox1.Enabled = true;
            cmb_worknotype.SelectedValue = "正常";
            txt_workno.Focus();
            
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            
            fill(txt_search.get_value());
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (addflag)
                insertWorkno();
            else
            {
                updateWorkno( old_workno);

            }

            txt_workno.set_value("");
            txt_name.set_value("");
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            groupBox1.Enabled = false;

            fill(txt_search.get_value());

        }

        private void insertWorkno()
        {
            工号表DAL dal = new 工号表DAL();
            工号表 mod = new 工号表();

            mod.工作令号 = txt_workno.get_value();
            mod.名称 = txt_name.get_value();
            mod.Noused = radioButton2.Checked;
            mod.Nocalc = chk_calc.Checked;
            mod.产品类别 = short.Parse (cmb_cplb.SelectedValue.ToString());
            mod.行业类别 = short.Parse(cmb_hylb.SelectedValue.ToString());
            mod.合同号 = txt_hth.get_value();
            mod.订货单位 = short.Parse(cmb_dhdw.SelectedValue.ToString());
            mod.购货单位 = txt_ghdw.get_value();
            mod.工号类型 = cmb_worknotype.SelectedValue.ToString();

            dal.Add(mod);

            


        }

        private void updateWorkno( string old_workno)
        {
            工号表DAL dal = new 工号表DAL();
            工号表 mod = new 工号表();

            mod.工作令号 = txt_workno.get_value();
            mod.名称 = txt_name.get_value();
            mod.Noused = radioButton2.Checked;
            mod.Nocalc = chk_calc.Checked;
            mod.产品类别 = short.Parse(cmb_cplb.SelectedValue.ToString());
            mod.行业类别 = short.Parse(cmb_hylb.SelectedValue.ToString());
            mod.合同号 = txt_hth.get_value();
            mod.订货单位 = short.Parse (cmb_dhdw.SelectedValue.ToString());
            mod.购货单位 = txt_ghdw.get_value();
            mod.工号类型 = cmb_worknotype.SelectedValue.ToString();



            dal.Update(mod , old_workno);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (!grd.has_selectrow())
            {
                MessageBox.Show("请先选中一个工号！");
                return;

            }

            addflag = false;

            工号表DAL dal = new 工号表DAL();
            工号表 mod = new 工号表();


            groupBox1.Enabled = true;
            string workno = grd.get_value(grd.get_selectrow_index(), 0).ToString();
            txt_workno.set_value(workno);

            mod = dal.GetBy工作令号(workno);

            old_workno = workno;

            txt_name.set_value(mod.名称);
            radioButton1.Checked = !mod.Noused;
            radioButton2.Checked = mod.Noused;
            chk_calc.Checked = mod.Nocalc;
            txt_hth.set_value(mod.合同号);
            txt_ghdw.set_value(mod.购货单位);

            cmb_cplb.SelectedValue = mod.产品类别;
            cmb_dhdw.SelectedValue = mod.订货单位;
            cmb_hylb.SelectedValue = mod.行业类别;
            cmb_worknotype.SelectedValue = mod.工号类型;


            
            //cmb_dhdw.set_value(grd.get_value(grd.get_selectrow_index(), 7).ToString());
            //txt_ghdw.set_value(grd.get_value(grd.get_selectrow_index(), 8).ToString());


        }

        private void txt_workno_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txt_name_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
