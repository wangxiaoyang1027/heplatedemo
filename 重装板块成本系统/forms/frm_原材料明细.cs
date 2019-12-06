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
    public partial class frm_原材料明细 : Form
    {

        
        public string deptname { get; set; }
        SqlDataReader dr;
        DataTable tb = new DataTable();
        public string workno;
        public int myyear { get; set; }
        public int mymonth { get; set; }
        public frm_原材料明细()
        {
            InitializeComponent();

            tb.Columns.Add(new DataColumn("工号", System.Type.GetType("System.String")));
            tb.Columns.Add(new DataColumn("日期", System.Type.GetType("System.String")));
            tb.Columns.Add(new DataColumn("凭证号", System.Type.GetType("System.String")));
            //铸铁
            tb.Columns.Add(new DataColumn("铸铁数量", System.Type.GetType("System.Decimal")));
            tb.Columns.Add(new DataColumn("铸铁金额", System.Type.GetType("System.Decimal")));
            //有色
            tb.Columns.Add(new DataColumn("有色件数量", System.Type.GetType("System.Decimal")));
            tb.Columns.Add(new DataColumn("有色件金额", System.Type.GetType("System.Decimal")));
            // 铸钢
            tb.Columns.Add(new DataColumn("铸钢数量", System.Type.GetType("System.Decimal")));
            tb.Columns.Add(new DataColumn("铸钢金额", System.Type.GetType("System.Decimal")));
            // 水压机
            tb.Columns.Add(new DataColumn("水压件数量", System.Type.GetType("System.Decimal")));
            tb.Columns.Add(new DataColumn("水压件金额", System.Type.GetType("System.Decimal")));
            // 锻件
            tb.Columns.Add(new DataColumn("锻件数量", System.Type.GetType("System.Decimal")));
            tb.Columns.Add(new DataColumn("锻件金额", System.Type.GetType("System.Decimal")));
            // 铆焊
            tb.Columns.Add(new DataColumn("铆焊金额", System.Type.GetType("System.Decimal")));
            // 备料
            tb.Columns.Add(new DataColumn("备料件金额", System.Type.GetType("System.Decimal")));
            // 标准
            tb.Columns.Add(new DataColumn("标准件金额", System.Type.GetType("System.Decimal")));
            // 外购
            tb.Columns.Add(new DataColumn("外购件金额", System.Type.GetType("System.Decimal")));
            // 配套
            tb.Columns.Add(new DataColumn("配套件金额", System.Type.GetType("System.Decimal")));
            // 其它
            tb.Columns.Add(new DataColumn("其它金额", System.Type.GetType("System.Decimal")));
            // 专项费用
            tb.Columns.Add(new DataColumn("专项费用", System.Type.GetType("System.Decimal")));
            // 热处理费
            tb.Columns.Add(new DataColumn("热处理费", System.Type.GetType("System.Decimal")));
            // 外加工费
            tb.Columns.Add(new DataColumn("外加工费", System.Type.GetType("System.Decimal")));
            // 包装费
            tb.Columns.Add(new DataColumn("包装费", System.Type.GetType("System.Decimal")));


            // 设计费
            tb.Columns.Add(new DataColumn("设计费", System.Type.GetType("System.Decimal")));
            // 运输费
            tb.Columns.Add(new DataColumn("运输费", System.Type.GetType("System.Decimal")));

            tb.Columns.Add(new DataColumn("总计", System.Type.GetType("System.Decimal")));

        }

        private void frm_原材料明细_Load(object sender, EventArgs e)
        {
            MinimizeBox = false;
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.Fixed3D;


            原始凭证DAL dal = new 原始凭证DAL();

            DataTable tb = dal.get原材料明细(myyear, mymonth, workno);

            grd_data.set_date(tb);
            



            

                

        }
    }
}
