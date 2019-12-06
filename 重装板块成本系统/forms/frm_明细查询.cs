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
    public partial class frm_明细查询 : Form
    {
        DataTable tb = new DataTable();
        public frm_明细查询()
        {

            InitializeComponent();
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
            tb.Columns.Add("销售配套件", System.Type.GetType("System.Decimal"));


           



        }

        private void frm_明细查询_Load(object sender, EventArgs e)
        {
            MinimizeBox = true;
            MaximizeBox = true;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            txt_gonghao.set_title("工号");

            在制品DAL dal = new 在制品DAL();
            DataRow myrow;
            object[] myobj = new object[15];

            SqlDataReader dr = dal.get成本明细();

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

        private void btn_search_Click(object sender, EventArgs e)
        {
            string tempstr;

            if (txt_gonghao.get_value() == "")
            {
                grd_data.set_date(tb);
            }
            else
            {
                tempstr = string.Format("工号 LIKE '{0}%'", txt_gonghao.get_value());
                DataRow[] drArr = tb.Select(tempstr);//模糊查询（如果的多条件筛选，可以加 and 或 or ）

                DataTable dtNew2 = tb.Clone();
                for (int i = 0; i < drArr.Length; i++)
                {
                    dtNew2.ImportRow(drArr[i]);//ImportRow 是复制
                }
                grd_data.set_date(dtNew2);

            }


        }

        private void btn_xq_Click(object sender, EventArgs e)
        {
            forms.frm_原材料明细 frm = new frm_原材料明细();

            if( !grd_data.has_selectrow())
            {
                MessageBox.Show("请选择一条记录");
                return;
            }


            string workno = grd_data.get_value(0).ToString();
            string ny = grd_data.get_value(1).ToString();


            frm.workno = workno;
            frm.myyear = int.Parse(ny.Substring(0, 4));
            frm.mymonth = int.Parse(ny.Substring(5, 2));

            frm.ShowDialog();
        }
    }
}
