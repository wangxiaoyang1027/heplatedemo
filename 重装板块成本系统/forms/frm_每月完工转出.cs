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


namespace 重装板块成本系统.forms
{
    public partial class frm_每月完工转出 : Form
    {
        public string deptname { get; set; }
        public int deptcode { get; set; }

        DataTable tb;
        DataTable dtNew2 ;

        public frm_每月完工转出()
        {
            InitializeComponent();
        }

        private void frm_每月完工转出_Load(object sender, EventArgs e)
        {
            MinimizeBox = false;
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.Fixed3D;


            tb = new DataTable();
            tb.Columns.Add("工号", System.Type.GetType("System.String"));
            tb.Columns.Add("年月", System.Type.GetType("System.String"));
            tb.Columns.Add("原材料", System.Type.GetType("System.Decimal"));
            tb.Columns.Add("燃料动力", System.Type.GetType("System.Decimal"));
            tb.Columns.Add("工时", System.Type.GetType("System.Decimal"));
            tb.Columns.Add("折合工时", System.Type.GetType("System.Decimal"));
            tb.Columns.Add("工资薪酬", System.Type.GetType("System.Decimal"));
            tb.Columns.Add("专项费用", System.Type.GetType("System.Decimal"));
            tb.Columns.Add("制造费用", System.Type.GetType("System.Decimal"));
            tb.Columns.Add("外加工费", System.Type.GetType("System.Decimal"));
            tb.Columns.Add("热处理费", System.Type.GetType("System.Decimal"));
            tb.Columns.Add("包装费", System.Type.GetType("System.Decimal"));
            tb.Columns.Add("设计费", System.Type.GetType("System.Decimal"));
            tb.Columns.Add("运输费", System.Type.GetType("System.Decimal"));

            txt_gonghao.set_title("工号：");

            checkBox1.Checked = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            fill();
        }


        private void fill()
        {
            在制品DAL dal = new 在制品DAL();
            Object[] myobj = new object[14];
            DataRow myrow;

            SqlDataReader dr;
            dr = dal.get在制品Reader(mydate.Value, deptcode);

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    dr.GetValues(myobj);
                    myrow = tb.NewRow();
                    myrow.ItemArray = myobj;
                    tb.Rows.Add(myrow);
                }
            }
            dr.Close();
            grd_data.set_date(tb);
        }


        private void btn_out_Click(object sender, EventArgs e)
        {
            if (!grd_data.has_selectrow())
            {
                MessageBox.Show("请选择一条记录");

                return;
            }

            forms.frm_单个工号转出 frm = new frm_单个工号转出();

            frm.deptcode = deptcode;
            frm.deptname = deptname;
            frm.mydate = mydate.Value;
            frm.addflag = true;
            

            frm.workno = grd_data.get_value(0).ToString();

            frm.ShowDialog();

            if (frm.saveflag)
            {

                DataRow myrow;

                myrow = tb.NewRow();

                myrow[0] = frm.mycls._workno;
                myrow[1] = mydate.Value.Year + "年" + mydate.Value.Month + "月   转出";
                myrow[2] = frm.mycls._ztje + frm.mycls._ysje + frm.mycls._zgje +
                        frm.mycls._syje + frm.mycls._djje + frm.mycls._mhje + frm.mycls._bjje + frm.mycls._bzj
                        + frm.mycls._wgje + frm.mycls._ptje + frm.mycls._clxje + frm.mycls._xsptj;
                myrow[3] = frm.mycls._rldl;
                myrow[4] = frm.mycls._gs;
                myrow[5] = frm.mycls._zhgs;
                myrow[6] = frm.mycls._gzfl;
                myrow[7] = frm.mycls._zxfy;
                myrow[8] = frm.mycls._zzfy;
                myrow[9] = frm.mycls._wjgf;
                myrow[10] = frm.mycls._rclf;
                myrow[11] = frm.mycls._bzf;
                myrow[12] = frm.mycls._sjf;
                myrow[13] = frm.mycls._ysf;



                int selectrowindex = grd_data.get_selectrow_index();
                if ( dtNew2 == null)
                {
                    // 如果 dtNew2 = null , 说明 没有选择工号
                    while (tb.Rows[selectrowindex][1].ToString() != "小计")
                        selectrowindex++;

                    // 修改 “小计”
                    for (int mycol = 2; mycol < 12; mycol++)
                    {
                        tb.Rows[selectrowindex][mycol] = decimal.Parse(tb.Rows[selectrowindex][mycol].ToString()) + decimal.Parse(myrow[mycol].ToString());
                    }

                    // 插入 转出的行
                    tb.Rows.InsertAt(myrow, selectrowindex);




                }
                else
                {
                    while (dtNew2.Rows[selectrowindex][1].ToString() != "小计")
                        selectrowindex++;
                    // 修改 “小计”
                    for (int mycol = 2; mycol < 12; mycol++)
                    {
                        dtNew2.Rows[selectrowindex][mycol] = decimal.Parse(dtNew2.Rows[selectrowindex][mycol].ToString()) + decimal.Parse(myrow[mycol].ToString());
                    }

                    // 插入 转出的行
                    dtNew2.Rows.InsertAt(myrow, selectrowindex);

                }
                // 查找 本工号 的小计 行


            }
          

        }

        private void btn_dele_Click(object sender, EventArgs e)
        {
            string workno;
            DateTime tempdate;

            if (!grd_data.has_selectrow())
            {
                MessageBox.Show("请先选择一条 转出 记录");
                return;
            }

            if (grd_data.get_value(1).ToString().IndexOf("转出") < 0)
            {
                MessageBox.Show("请先选择一条 转出 记录");
                return;
            }

            forms.frm_删除转出 frm = new frm_删除转出();
            转出类DAL mycls = new 转出类DAL();


            if (frm.show_window() == true)
            {
                string temp_date;

                temp_date = grd_data.get_value(1).ToString();
                //mycls.dele_date(grd_data.get_value(0).ToString(), new DateTime(int.Parse(temp_date.Substring(0, 4)), int.Parse(temp_date.Substring(5, 2)), 15), deptcode);

                tempdate = new DateTime(int.Parse(temp_date.Substring(0, 4)), int.Parse(temp_date.Substring(5, 2)), 15);
                workno = grd_data.get_value(0).ToString();
                
                转出类DAL dal = new 转出类DAL();



                dal.del_data(workno, tempdate, deptcode);




                //mycls.dele_date(grd_data.get_value(0).ToString(), new DateTime(int.Parse(tempdate.Substring(0, 4)), int.Parse(tempdate.Substring(5, 2)), 15));
                //button1_Click(sender, e);
            }

        }

        private void btn_gonghao_Click(object sender, EventArgs e)
        {
            if (txt_gonghao.get_value() == "")
            {
                grd_data.set_date(tb);
                dtNew2 = null;
            }
            else
            {
                string tempstr = string.Format("工号 LIKE '{0}%'", txt_gonghao.get_value());
                DataRow[] drArr = tb.Select(tempstr);//模糊查询（如果的多条件筛选，可以加 and 或 or ）

                DataTable dtNew2 = tb.Clone();
                for (int i = 0; i < drArr.Length; i++)
                {
                    dtNew2.ImportRow(drArr[i]);//ImportRow 是复制
                }
                grd_data.set_date(dtNew2);

            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            forms.frm_单个工号转出 frm = new frm_单个工号转出();

            if (!grd_data.has_selectrow())
            {
                MessageBox.Show("请先选择一条 转出 记录");
                return;
            }

            if (grd_data.get_value(1).ToString().IndexOf("转出") < 0)
            {
                MessageBox.Show("请先选择一条 转出 记录");
                return;
            }


            frm.deptcode = deptcode;
            frm.deptname = deptname;
            frm.mydate = mydate.Value;
            frm.addflag = false ;

            frm.ShowDialog();


            //for (int mycol = 2; mycol < 12; mycol++)
            //{
            //    tb.Rows[selectrowindex][mycol] = decimal.Parse(tb.Rows[selectrowindex][mycol].ToString()) + decimal.Parse(myrow[mycol].ToString());
            //}






        }
    }
}
