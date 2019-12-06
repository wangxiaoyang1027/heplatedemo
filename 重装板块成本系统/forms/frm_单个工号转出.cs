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
    public partial class frm_单个工号转出 : Form
    {
        public string workno { get; set; }
        public string deptname;
        public int deptcode;
        public DateTime mydate { get; set; }
        public bool addflag;
        public bool saveflag; 

        public 转出类 mycls = new 转出类();

        public frm_单个工号转出()
        {
            InitializeComponent();
        }

        private void frm_单个工号转出_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = true;
            txt_factor.set_title("比例系数：");
            txt_factor.set_type(2);
            txt_ztsl.set_title("铸铁数量：");
            txt_ztsl.set_type(2);
            txt_ztje.set_title("铸铁金额：");
            txt_ztje.set_type(2);
            txt_blje.set_title("备件金额：");
            txt_blje.set_type(2);
            txt_bzje.set_title("标准件：");
            txt_bzje.set_type(2);
            txt_djje.set_title("锻件金额");
            txt_djje.set_type(2);
            txt_djsl.set_title("锻件数量");
            txt_djsl.set_type(2);
            txt_mhje.set_title("铆焊金额");
            txt_mhje.set_type(2);
            txt_ptje.set_title("配套金额");
            txt_ptje.set_type(2);
            txt_clxje.set_title("齿轮配套");
            txt_clxje.set_type(2);
            txt_syje.set_title("水压金额");
            txt_syje.set_type(2);
            txt_sysl.set_title("水压数量");
            txt_sysl.set_type(2);
            txt_wgje.set_title("外购金额");
            txt_wgje.set_type(2);
            txt_ysje.set_title("有色金额");
            txt_ysje.set_type(2);
            txt_yssl.set_title("有色数量");
            txt_yssl.set_type(2);
            txt_zgje.set_title("铸钢金额");
            txt_zgje.set_type(2);
            txt_zgsl.set_title("铸钢数量");
            txt_zgsl.set_type(2);
            txt_sjf.set_title("设计费");
            txt_sjf.set_type(2);
            txt_ysf.set_title("运输费");
            txt_ysf.set_type(2);
            txt_xsptj.set_title("销售配套件");
            txt_xsptj.set_type(2);


            txt_rldl.set_title("燃料动力");
            txt_rldl.set_type(2);
            txt_gzfl.set_title("工资福利");
            txt_gzfl.set_type(2);
            txt_gs.set_title("工时");
            txt_gs.set_type(2);
            txt_zhgs.set_title("折合工时");
            txt_zhgs.set_type(2);
            txt_zzfy.set_title("制造费用");
            txt_zzfy.set_type(2);
            txt_zxfy.set_title("专项费用");
            txt_zxfy.set_type(2);
            txt_wjgf.set_title("外加工费");
            txt_wjgf.set_type(2);
            txt_rclf.set_title("热处理费");
            txt_rclf.set_type(2);
            txt_bzf.set_title("包装费");
            txt_bzf.set_type(2);

            label3.Text = workno;
            Text = " 完工工号转出    部门：" + deptname;


            
            转出类DAL dal = new 转出类DAL();
            if (addflag)
            {
                mycls = dal.getOutInfoByWorkno(workno, mydate, deptcode);
                button1.Text = "转出";
            }
            else
            {
                mycls = dal.getUpdateInfoByWorkno(workno, mydate, deptcode);
                button1.Text = "修改";
            }

            groupBox3.Enabled = false;
            set_txtbox(mycls);

            set_txt_enabled(false);

            saveflag = false;
        }


        private void set_txtbox(转出类 mycls)
        {
            txt_blje.set_value(mycls._bjje.ToString());
            txt_bzf.set_value(mycls._bzf.ToString());
            txt_bzje.set_value(mycls._bzj.ToString());  // 标准件
            txt_clxje.set_value(mycls._clxje.ToString());
            txt_djje.set_value(mycls._djje.ToString());
            txt_djsl.set_value(mycls._djsl.ToString());
            txt_gs.set_value(mycls._gs.ToString());
            txt_gzfl.set_value(mycls._gzfl.ToString());
            txt_mhje.set_value(mycls._mhje.ToString());
            txt_ptje.set_value(mycls._ptje.ToString());
            txt_ptje.set_value(mycls._ptje.ToString());
            txt_rclf.set_value(mycls._rclf.ToString());
            txt_rldl.set_value(mycls._rldl.ToString());
            txt_sjf.set_value(mycls._sjf.ToString());
            txt_syje.set_value(mycls._syje.ToString());
            txt_sysl.set_value(mycls._sysl.ToString());
            txt_wgje.set_value(mycls._wgje.ToString());
            txt_wjgf.set_value(mycls._wjgf.ToString());
            txt_xsptj.set_value(mycls._xsptj.ToString());
            txt_ysf.set_value(mycls._ysf.ToString());
            txt_ysje.set_value(mycls._ysje.ToString());
            txt_yssl.set_value(mycls._yssl.ToString());
            txt_zgje.set_value(mycls._zgje.ToString());
            txt_zgsl.set_value(mycls._zgsl.ToString());
            txt_zhgs.set_value(mycls._zhgs.ToString());
            txt_ztje.set_value(mycls._ztje.ToString());
            txt_ztsl.set_value(mycls._ztsl.ToString());
            txt_zxfy.set_value(mycls._zxfy.ToString()); // 专项费用
            txt_zzfy.set_value(mycls._zzfy.ToString());
            


        }


        public void set_txt_enabled(bool enabled)
        {
            foreach (Control mycont in this.Controls)
            {
                if (mycont.GetType().Name == "ctrl_text")
                    mycont.Enabled = enabled;
            }

            foreach (Control mycont in this.groupBox2.Controls)
            {
                if (mycont.GetType().Name == "ctrl_text")
                    mycont.Enabled = enabled;
            }
        }

        private void rad_auto_CheckedChanged(object sender, EventArgs e)
        {
            groupBox3.Enabled = !rad_auto.Checked;
            if (rad_auto.Checked)
                set_txt_enabled(false);
            else
            {
                if (!checkBox1.Checked)
                {
                    txt_factor.Enabled = false;
                    btn_factor.Enabled = false;
                }
                set_txt_enabled(true);
                txt_ztsl.Focus();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txt_factor.Enabled = checkBox1.Checked;
            btn_factor.Enabled = checkBox1.Checked;
        }


        // 按比例转出
        private void btn_factor_Click(object sender, EventArgs e)
        {
            decimal myfact;

            if (txt_factor.get_value() == "")
            {
                MessageBox.Show("系数不能为空 ！");
                txt_factor.Focus();
                return;
            }



            myfact = decimal.Parse(txt_factor.get_value());
            myfact /= (decimal)100.0;
            if (myfact == 0)
            {
                MessageBox.Show("比例系数不能为 0 ");
                txt_factor.Focus();
                return;
            }

            txt_ztsl.set_value((mycls._ztsl * myfact).ToString("f"));
            txt_ztje.set_value((mycls._ztje * myfact).ToString("f"));
            txt_yssl.set_value((mycls._yssl * myfact).ToString("f"));
            txt_ysje.set_value((mycls._ysje * myfact).ToString("f"));
            txt_zgsl.set_value((mycls._zgsl * myfact).ToString("f"));
            txt_zgje.set_value((mycls._zgje * myfact).ToString("f"));
            txt_sysl.set_value((mycls._sysl * myfact).ToString("f"));
            txt_syje.set_value((mycls._syje * myfact).ToString("f"));
            txt_djsl.set_value((mycls._djsl * myfact).ToString("f"));
            txt_djje.set_value((mycls._djje * myfact).ToString("f"));
            txt_mhje.set_value((mycls._mhje * myfact).ToString("f"));
            txt_blje.set_value((mycls._bjje * myfact).ToString("f"));
            txt_bzje.set_value((mycls._bzj * myfact).ToString("f"));
            txt_wgje.set_value((mycls._wgje * myfact).ToString("f"));
            txt_ptje.set_value((mycls._ptje * myfact).ToString("f"));
            txt_clxje.set_value((mycls._clxje * myfact).ToString("f"));
            txt_sjf.set_value((mycls._sjf * myfact).ToString("f"));
            txt_ysf.set_value((mycls._ysf * myfact).ToString("f"));
            txt_xsptj.set_value((mycls._xsptj * myfact).ToString("f"));

            txt_rldl.set_value((mycls._rldl * myfact).ToString("f"));
            txt_gs.set_value((mycls._gs * myfact).ToString("f"));
            txt_zhgs.set_value((mycls._zhgs * myfact).ToString("f"));
            txt_gzfl.set_value((mycls._gzfl * myfact).ToString("f"));
            txt_zzfy.set_value((mycls._zzfy * myfact).ToString("f"));

            txt_bzf.set_value((mycls._bzf * myfact).ToString("f"));
            txt_rclf.set_value((mycls._rclf * myfact).ToString("f"));
            txt_zxfy.set_value((mycls._zxfy * myfact).ToString("f"));
            txt_wjgf.set_value((mycls._wjgf * myfact).ToString("f"));


        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (addflag)
                set_data(workno, mydate, deptcode);
            else
            {
                dele_date(workno, mydate, deptcode);
                set_data(workno, mydate, deptcode);
            }
            saveflag = true;
            MessageBox.Show("转出完成！");
        }


        private void dele_date(string workno, DateTime mydate, int deptcode)
        {

            转出类DAL dal = new 转出类DAL();

            dal.del_data(workno, mydate, deptcode);
        }

        private void set_data(string workno, DateTime mydate, int deptcode)
        {
            原始凭证 mod = new 原始凭证();
            原始凭证DAL dal = new 原始凭证DAL();
            decimal summoney;

            summoney = 0;
            if (txt_blje.get_value() != "0.00")
            {
                mod.Id = Guid.NewGuid();
                mod.日期 = mydate;
                mod.凭证号 = "";
                mod.单位 = (short)deptcode;
                mod.工作令号 = workno;
                mod.材质 = "B";
                mod.重量 = 0;
                mod.金额 = decimal.Parse(txt_blje.get_value());
                dal.Add(mod);
                dal.add原始凭证转出(mod.Id.ToString());
                mycls._bjje = decimal.Parse(txt_blje.get_value());
            }
            if (txt_bzf.get_value() != "0.00")
            {
                mod.Id = Guid.NewGuid();
                mod.日期 = mydate;
                mod.凭证号 = "";
                mod.单位 = (short)deptcode;
                mod.工作令号 = workno;
                mod.材质 = "A";
                mod.重量 = 0;
                mod.金额 = decimal.Parse(txt_bzf.get_value());
                dal.Add(mod);
                dal.add原始凭证转出(mod.Id.ToString());
                mycls._bzf = decimal.Parse(txt_bzf.get_value());
            }

            if (txt_bzje.get_value() != "0.00")
            {
                mod.Id = Guid.NewGuid();
                mod.日期 = mydate;
                mod.凭证号 = "";
                mod.单位 = (short)deptcode;
                mod.工作令号 = workno;
                mod.材质 = "Z";
                mod.重量 = 0;
                mod.金额 = decimal.Parse(txt_bzje.get_value());
                dal.Add(mod);
                dal.add原始凭证转出(mod.Id.ToString());
                mycls._bzj = mod.金额;
            }

            if (txt_clxje.get_value() != "0.00")
            {
                mod.Id = Guid.NewGuid();
                mod.日期 = mydate;
                mod.凭证号 = "";
                mod.单位 = (short)deptcode;
                mod.工作令号 = workno;
                mod.材质 = "C";       // 齿轮箱
                mod.重量 = 0;
                mod.金额 = decimal.Parse(txt_clxje.get_value());
                dal.Add(mod);
                dal.add原始凭证转出(mod.Id.ToString());
                mycls._clxje = mod.金额;
            }

            if (txt_djje.get_value() != "0.00")
            {
                mod.Id = Guid.NewGuid();
                mod.日期 = mydate;
                mod.凭证号 = "";
                mod.单位 = (short)deptcode;
                mod.工作令号 = workno;
                mod.材质 = "D";       // 铸锻件
                mod.重量 = decimal.Parse(txt_djsl.get_value());
                mod.金额 = decimal.Parse(txt_djje.get_value());
                dal.Add(mod);
                dal.add原始凭证转出(mod.Id.ToString());
                mycls._djje = mod.金额;
            }

            if (txt_mhje.get_value() != "0.00")
            {
                mod.Id = Guid.NewGuid();
                mod.日期 = mydate;
                mod.凭证号 = "";
                mod.单位 = (short)deptcode;
                mod.工作令号 = workno;
                ////if (mod.单位 == 23)
                    mod.材质 = "H";
                ////else
                    //mod.材质 = "M";
                mod.重量 = 0;
                mod.金额 = decimal.Parse(txt_mhje.get_value());
                dal.Add(mod);
                dal.add原始凭证转出(mod.Id.ToString());
                mycls._mhje = mod.金额; ;
            }

            if (txt_ptje.get_value() != "0.00")
            {
                mod.Id = Guid.NewGuid();
                mod.日期 = mydate;
                mod.凭证号 = "";
                mod.单位 = (short)deptcode;
                mod.工作令号 = workno;
                mod.材质 = "P";
                mod.重量 = 0;
                mod.金额 = decimal.Parse(txt_ptje.get_value());
                dal.Add(mod);
                dal.add原始凭证转出(mod.Id.ToString());
                mycls._ptje = mod.金额;
            }

            if (txt_rclf.get_value() != "0.00")
            {
                mod.Id = Guid.NewGuid();
                mod.日期 = mydate;
                mod.凭证号 = "";
                mod.单位 = (short)deptcode;
                mod.工作令号 = workno;
                mod.材质 = "R";
                mod.重量 = 0;
                mod.金额 = decimal.Parse(txt_rclf.get_value());
                dal.Add(mod);
                dal.add原始凭证转出(mod.Id.ToString());
                mycls._rclf = mod.金额;
            }

            if (txt_sjf.get_value() != "0.00")
            {
                mod.Id = Guid.NewGuid();
                mod.日期 = mydate;
                mod.凭证号 = "";
                mod.单位 = (short)deptcode;
                mod.工作令号 = workno;
                mod.材质 = "E";
                mod.重量 = 0;
                mod.金额 = decimal.Parse(txt_sjf.get_value());
                dal.Add(mod);
                dal.add原始凭证转出(mod.Id.ToString());
                mycls._sjf = mod.金额;
            }


            if (txt_syje.get_value() != "0.00")
            {
                mod.Id = Guid.NewGuid();
                mod.日期 = mydate;
                mod.凭证号 = "";
                mod.单位 = (short)deptcode;
                mod.工作令号 = workno;
                mod.材质 = "S";
                mod.重量 = decimal.Parse(txt_sysl.get_value());
                mod.金额 = decimal.Parse(txt_syje.get_value());
                dal.Add(mod);
                dal.add原始凭证转出(mod.Id.ToString());
                mycls._syje = mod.金额;
            }

            if (txt_wgje.get_value() != "0.00")
            {
                mod.Id = Guid.NewGuid();
                mod.日期 = mydate;
                mod.凭证号 = "";
                mod.单位 = (short)deptcode;
                mod.工作令号 = workno;
                mod.材质 = "W";
                mod.重量 = 0;
                mod.金额 = decimal.Parse(txt_wgje.get_value());
                dal.Add(mod);
                dal.add原始凭证转出(mod.Id.ToString());
                mycls._wgje = mod.金额;
            }

            if (txt_wjgf.get_value() != "0.00")
            {
                mod.Id = Guid.NewGuid();
                mod.日期 = mydate;
                mod.凭证号 = "";
                mod.单位 = (short)deptcode;
                mod.工作令号 = workno;
                mod.材质 = "J";
                mod.重量 = 0;
                mod.金额 = decimal.Parse(txt_wjgf.get_value());
                dal.Add(mod);
                dal.add原始凭证转出(mod.Id.ToString());
                mycls._wjgf = mod.金额;
            }

            if (txt_xsptj.get_value() != "0.00")
            {
                mod.Id = Guid.NewGuid();
                mod.日期 = mydate;
                mod.凭证号 = "";
                mod.单位 = (short)deptcode;
                mod.工作令号 = workno;
                mod.材质 = "V";
                mod.重量 = 0;
                mod.金额 = decimal.Parse(txt_xsptj.get_value());
                dal.Add(mod);
                dal.add原始凭证转出(mod.Id.ToString());
                mycls._xsptj = mod.金额;
            }

            if (txt_ysf.get_value() != "0.00")
            {
                mod.Id = Guid.NewGuid();
                mod.日期 = mydate;
                mod.凭证号 = "";
                mod.单位 = (short)deptcode;
                mod.工作令号 = workno;
                mod.材质 = "F";
                mod.重量 = 0;
                mod.金额 = decimal.Parse(txt_ysf.get_value());
                dal.Add(mod);
                dal.add原始凭证转出(mod.Id.ToString());
                mycls._ysf = mod.金额;
            }

            if (txt_ysje.get_value() != "0.00")
            {
                mod.Id = Guid.NewGuid();
                mod.日期 = mydate;
                mod.凭证号 = "";
                mod.单位 = (short)deptcode;
                mod.工作令号 = workno;
                mod.材质 = "Y";
                mod.重量 = decimal.Parse(txt_yssl.get_value());
                mod.金额 = decimal.Parse(txt_ysje.get_value());
                dal.Add(mod);
                dal.add原始凭证转出(mod.Id.ToString());
                mycls._ysje = mod.金额;
            }

            if (txt_zgje.get_value() != "0.00")
            {
                mod.Id = Guid.NewGuid();
                mod.日期 = mydate;
                mod.凭证号 = "";
                mod.单位 = (short)deptcode;
                mod.工作令号 = workno;
                mod.材质 = "G";
                mod.重量 = decimal.Parse(txt_zgsl.get_value());
                mod.金额 = decimal.Parse(txt_zgje.get_value());
                dal.Add(mod);
                dal.add原始凭证转出(mod.Id.ToString());
                mycls._zgje = mod.金额;
            }

            if (txt_ztje.get_value() != "0.00")
            {
                mod.Id = Guid.NewGuid();
                mod.日期 = mydate;
                mod.凭证号 = "";
                mod.单位 = (short)deptcode;
                mod.工作令号 = workno;
                mod.材质 = "T";
                mod.重量 = decimal.Parse(txt_ztsl.get_value());
                mod.金额 = decimal.Parse(txt_ztje.get_value());
                dal.Add(mod);
                dal.add原始凭证转出(mod.Id.ToString());
                mycls._ztje = mod.金额;
            }

            if (txt_zxfy.get_value() != "0.00")
            {
                mod.Id = Guid.NewGuid();
                mod.日期 = mydate;
                mod.凭证号 = "";
                mod.单位 = (short)deptcode;
                mod.工作令号 = workno;
                mod.材质 = "X";
                mod.重量 = 0;
                mod.金额 = decimal.Parse(txt_zxfy.get_value());
                dal.Add(mod);
                dal.add原始凭证转出(mod.Id.ToString());
                mycls._zxfy = mod.金额;
            }


            费用分配表 mod1 = new 费用分配表();
            费用分配表DAL dal1 = new 费用分配表DAL();

            if (txt_zzfy.get_value() != "0.00")
            {
                mod1.ID = Guid.NewGuid();
                mod1.制造费用 = decimal.Parse(txt_zzfy.get_value());
                mod1.工号 = workno;
                mod1.工时 = decimal.Parse(txt_gs.get_value());
                mod1.折合工时 = decimal.Parse(txt_zhgs.get_value());
                mod1.时间 = mydate;
                mod1.燃料动力 = decimal.Parse(txt_rldl.get_value());
                mod1.薪酬 = decimal.Parse(txt_gzfl.get_value());
                mod1.部门 = (short)deptcode;
                dal1.Add(mod1);
                mycls._rldl = mod1.燃料动力;
                mycls._gs = mod1.工时;
                mycls._zhgs = mod1.折合工时;
                mycls._gzfl = mod1.薪酬;
                mycls._zzfy = mod1.制造费用;
                dal1.set费用分配转出(mod1.ID.ToString());

            }

            decimal ycl = mycls._ztje + mycls._ysje + mycls._zgje + mycls._syje + mycls._djje + mycls._bjje + mycls._mhje + mycls._wgje +
                mycls._bzj + mycls._ptje + mycls._clxje + mycls._xsptj;

            decimal addfy = mycls._rldl + mycls._gzfl + mycls._zzfy + mycls._zxfy + mycls._rclf + mycls._bzf + mycls._sjf + mycls._ysf + mycls._wjgf;

            summoney = ycl + addfy;

            成品库房DAL dal2 = new 成品库房DAL();

            dal2.insert成品库房表(workno, mydate, summoney);



        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_calc_Click(object sender, EventArgs e)
        {
            原始凭证 mod = new 原始凭证();
            原始凭证DAL dal = new 原始凭证DAL();

            if (txt_blje.get_value() != "0.00")
            {

                mycls._bjje = decimal.Parse(txt_blje.get_value());
            }
            if (txt_bzf.get_value() != "0.00")
            {

                mycls._bzf = decimal.Parse(txt_bzf.get_value());
            }

            if (txt_bzje.get_value() != "0.00")
            {

                mycls._bzj = decimal.Parse(txt_bzje.get_value());
            }

            if (txt_clxje.get_value() != "0.00")
            {

                mycls._clxje = decimal.Parse(txt_clxje.get_value());
            }

            if (txt_djje.get_value() != "0.00")
            {

                mycls._djje = decimal.Parse(txt_djje.get_value());
            }

            if (txt_mhje.get_value() != "0.00")
            {

                mycls._mhje = decimal.Parse(txt_mhje.get_value());
            }

            if (txt_ptje.get_value() != "0.00")
            {

                mycls._ptje = decimal.Parse(txt_ptje.get_value());
            }

            if (txt_rclf.get_value() != "0.00")
            {

                mycls._rclf = decimal.Parse(txt_rclf.get_value());
            }

            if (txt_sjf.get_value() != "0.00")
            {

                mycls._sjf = decimal.Parse(txt_sjf.get_value());
            }


            if (txt_syje.get_value() != "0.00")
            {

                mycls._syje = decimal.Parse(txt_syje.get_value()); 
            }

            if (txt_wgje.get_value() != "0.00")
            {

                mycls._wgje = decimal.Parse(txt_wgje.get_value()); ;
            }

            if (txt_wjgf.get_value() != "0.00")
            {

                mycls._wjgf = decimal.Parse(txt_wjgf.get_value());
            }

            if (txt_xsptj.get_value() != "0.00")
            {

                mycls._xsptj = decimal.Parse(txt_xsptj.get_value());
            }

            if (txt_ysf.get_value() != "0.00")
            {

                mycls._ysf = decimal.Parse(txt_ysf.get_value());
            }

            if (txt_ysje.get_value() != "0.00")
            {

                mycls._ysje = decimal.Parse(txt_ysje.get_value());
            }

            if (txt_zgje.get_value() != "0.00")
            {

                mycls._zgje = decimal.Parse(txt_zgje.get_value());
            }

            if (txt_ztje.get_value() != "0.00")
            {

                mycls._ztje = decimal.Parse(txt_ztje.get_value());
            }

            if (txt_zxfy.get_value() != "0.00")
            {

                mycls._zxfy = decimal.Parse(txt_zxfy.get_value());
            }


            费用分配表 mod1 = new 费用分配表();
            费用分配表DAL dal1 = new 费用分配表DAL();

            if (txt_zzfy.get_value() != "0.00")
            {

                mycls._rldl = decimal.Parse(txt_rldl.get_value());
                mycls._gs = mod1.工时;
                mycls._zhgs = mod1.折合工时;
                mycls._gzfl = decimal.Parse(txt_gzfl.get_value());
                mycls._zzfy = decimal.Parse(txt_zzfy.get_value());
            }


            decimal ycl = mycls._ztje + mycls._ysje + mycls._zgje + mycls._syje + mycls._djje + mycls._bjje + mycls._mhje + mycls._wgje +
                mycls._bzj + mycls._ptje + mycls._clxje + mycls._xsptj;

            decimal addfy = mycls._rldl + mycls._gzfl + mycls._zzfy + mycls._zxfy + mycls._rclf + mycls._bzf + mycls._sjf + mycls._ysf+ mycls._wjgf;

            label1.Text = "总金额：" + (ycl + addfy) + "    其中： 原材料：" + ycl + "  其它："+addfy ;

        }
    }
}
