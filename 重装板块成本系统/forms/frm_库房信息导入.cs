using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 重装板块成本系统.dal;
using System.Data.OleDb;



namespace 重装板块成本系统.forms
{
    public partial class frm_库房信息导入 : Form
    {
        public frm_库房信息导入()
        {
            InitializeComponent();
        }

        private void frm_库房信息导入_Load(object sender, EventArgs e)
        {
            MinimizeBox = false;
            MaximizeBox = false;

        }

        private void btn_filename_Click(object sender, EventArgs e)
        {
            if( openFileDialog1.ShowDialog ( ) != DialogResult.OK)
            {
                return;
            }

            txt_filename.set_value(openFileDialog1.FileName);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_filename.get_value() == "")
            {
                MessageBox.Show("文件名不能为空 ！ ");
                return;
            }

            DateTime mydate = import_date.Value;

            成品库房DAL dal = new 成品库房DAL();

            if (dal.getInfoByDate(mydate).Rows.Count > 0)
            {
                if (MessageBox.Show("选择的月份已有数据， 真的要继续导入吗 ？ ", "警 告", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;
            }

            string filename = txt_filename.get_value();
            string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + filename + ";" + "Extended Properties=Excel 8.0;";
            OleDbConnection conn = new OleDbConnection(strConn);
            conn.Open();
            string strExcel = "";

            OleDbDataReader dr;
            OleDbCommand myCommand = new OleDbCommand();
            strExcel = @"select rtrim(工号), 金额 from [库存信息$]";

            myCommand.Connection = conn;
            myCommand.CommandText = strExcel;
            dr = myCommand.ExecuteReader();
            库房信息 mycls;
            List<库房信息> mylist = new List<库房信息>();


            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    mycls = new 库房信息();

                    mycls.workno = dr.GetString(0);
                    mycls.income = decimal.Parse(dr.GetValue(1).ToString());
                    mycls.mydate = import_date.Value;

                    mylist.Add(mycls);

                }
            }
            dr.Close();

            工号表DAL ghdal = new 工号表DAL();
            bool wrongflag = false;
            string wrongworkno = "";

            foreach (库房信息 mycls1 in mylist)
            {
                if (!ghdal.IsIn工号表(mycls1.workno))
                {
                    //MessageBox.Show("工号 ：" + mycls1.工号 + "  不存在 ！");
                    wrongflag = true;
                    wrongworkno += mycls1.workno + "\r\n";
                }
            }
            if (wrongflag)
            {
                MessageBox.Show(wrongworkno, "错误工号");

                System.IO.FileStream fs = new System.IO.FileStream("E:/错误工号.TXT", System.IO.FileMode.OpenOrCreate);
                byte[] data = System.Text.Encoding.Default.GetBytes(wrongworkno);

                fs.Write(data, 0, data.Length);
                fs.Close();
                return;
            }

            成品库房DAL dal1 = new 成品库房DAL();
            foreach (库房信息 mycls1 in mylist)
            {
                //DataGridViewRow myrow = new DataGridViewRow();

                //myrow.Cells[0].Value = mycls1.workno;
                //myrow.Cells[1].Value = mycls1.mydate;
                //myrow.Cells[2].Value = mycls1.income;

                dal1.insert成品库房表(mycls1.workno, mycls1.mydate, mycls1.income*(-1));
            }


            
            



        }
          
    }

    public class 库房信息
    {
        public string id { get; set; }
        public string workno { get; set; }
        public DateTime mydate { get; set; }
        public decimal income { get; set; }
    }

}
