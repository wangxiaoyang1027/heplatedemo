using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using 重装板块成本系统.dal;
using 重装板块成本系统.model;
using System.Data.OleDb;

namespace 重装板块成本系统.forms
{
    public partial class frm_收入导入 : Form
    {
        public string deptname;
        public int deptcode;
        string mytype;
        bool addflag;

        每月收入 mycls = new 每月收入();
        每月收入DAL dal = new 每月收入DAL();


        public frm_收入导入()
        {
            InitializeComponent();
        }

        private void frm_收入导入_Load(object sender, EventArgs e)
        {
            MinimizeBox = false;
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.Fixed3D;

            btn_import.Text = "导 入";


            Text = "收入导入   部门：" + deptname;

            mytype = "内部交易";

            if ( deptcode == 40)
                mytype = "外贸";
            if (deptcode == 41)
                mytype = "内贸";
            label2.Text = "导入部门：" + deptname + " 类型："+ mytype;
            btn_add.Text = "增 加";
            btn_edit.Text = "编 辑";
            groupBox1.Enabled = false;
            txt_searchworkno.set_title("工号：");
            txt_weight.set_title("重量");
            txt_taifen.set_title("台份");
            txt_income.set_title("收入");

            cmb_type.Items.Add("内贸");
            cmb_type.Items.Add("外贸");
            cmb_type.Items.Add("内部交易");
            txt_workno.set_title("工号");

            txt_weight.set_type(2);
            txt_income.set_type(2);

            btn_dele.Text = "删 除";

            btn_save.Text = "保 存";
            btn_cancle.Text = "取 消";

            fill(txt_searchworkno.get_value());
        }

        private void btn_import_Click(object sender, EventArgs e)
        {
            if ( txt_filename.Text=="")
            {
                MessageBox.Show("请输入文件名");
                return;
            }

            import_file(txt_filename.Text);
            fill(txt_searchworkno.get_value());

            MessageBox.Show("导入成功 ！");

            return;


        }


        private  void  import_file(string filename)
        {
            List<每月收入> mylist = new List<每月收入>();
            string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + filename + ";" + "Extended Properties=Excel 8.0;";
            OleDbConnection conn = new OleDbConnection(strConn);
            conn.Open();
            string strExcel = "";

            OleDbDataReader dr;
            OleDbCommand myCommand = new OleDbCommand();
            strExcel = @"select rtrim(工号), rtrim(台份), 
iif(isnull(吨位), 0, 吨位),iif(isnull(收入),0, 收入), iif(isnull(欧元),0,欧元), iif(isnull(美元),0,美元)  from [工号信息$]";

            myCommand.Connection = conn;
            myCommand.CommandText = strExcel;
            dr = myCommand.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    mycls = new 每月收入();

                    mycls.Id = Guid.NewGuid();
                    mycls.工号 = dr.GetString(0).Trim();
                    //mycls.台份 = dr.GetString(1);
                    mycls.台份 = "1";
                    mycls.主机厂 = "";
                    mycls.收入 = double.Parse(dr.GetValue(3).ToString());
                    mycls.重量 = double.Parse(dr.GetValue(2).ToString());
                    mycls.类型 = mytype;
                    mycls.美元 = double.Parse(dr.GetValue(5).ToString());
                    mycls.欧元 = double.Parse(dr.GetValue(4).ToString());
                    mycls.日期 = mydate.Value;

                    mylist.Add(mycls);

                }
            }
            dr.Close();


            // 以下为检查导入数据
            工号表DAL ghdal = new 工号表DAL();
            每月收入DAL dal = new 每月收入DAL();
            bool wrongflag = false;
            string wrongworkno ="";

            foreach (每月收入 mycls1 in mylist)
            {
                if (!ghdal.IsIn工号表(mycls1.工号))
                {
                    //MessageBox.Show("工号 ：" + mycls1.工号 + "  不存在 ！");
                    wrongflag = true;
                    wrongworkno += mycls1.工号 + "\r\n"; 
                }
            }

            if ( wrongflag )
            {
                MessageBox.Show(wrongworkno, "错误工号");

                System.IO.FileStream fs = new System.IO.FileStream( "E:/WRONG.TXT", System.IO.FileMode.OpenOrCreate);
                byte[] data = System.Text.Encoding.Default.GetBytes(wrongworkno);

                fs.Write(data, 0, data.Length);
                fs.Close();
                return;

            }

            foreach (每月收入 mycls1 in mylist)
            {
                dal.Add(mycls1);
            }


            return;




        }



        private void fill( string workno)
        {
            if ( workno =="")
            {
                data_grd.set_date(dal.GetAllDataTable(mydate.Value, deptcode));
            }
            else 
                data_grd.set_date(dal.GetAllDataTable( mydate.Value, deptcode, workno));

            data_grd.set_hide(0);
            data_grd.set_width(2, 60);
            //data_grd.set_hide(7);
            
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog()== DialogResult.OK)
            {
                txt_filename.Text = openFileDialog1.FileName;
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            addflag = true;

            cmb_type.SelectedItem = mytype;
            cmb_type.Enabled = false;

            txt_workno.set_value("");
            txt_income.set_value("0");
            txt_taifen.set_value("");
            txt_weight.set_value("0");




            txt_income.Focus();



        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            int selectedindex = data_grd.get_selectrow_index();
            if (  selectedindex == -1)
            {
                MessageBox.Show("请先选中一条记录");
                return;
            }

            string id = data_grd.get_value(0).ToString();
            addflag = false;
            

            mycls = dal.GetById(Guid.Parse(id));

            txt_income.set_value(mycls.收入.ToString());
            txt_taifen.set_value(mycls.台份);
            cmb_type.SelectedItem = mycls.类型.Trim();
            txt_weight.set_value(mycls.重量.ToString());
            txt_workno.set_value(mycls.工号);



            groupBox1.Enabled = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {

            mycls.工号 = txt_workno.get_value();
            mycls.收入 = double.Parse(txt_income.get_value().ToString());
            mycls.日期 = mydate.Value;
            mycls.类型 = cmb_type.SelectedItem.ToString();
            mycls.重量 = double.Parse(txt_weight.get_value());
            mycls.台份 = txt_taifen.get_value();
            mycls.主机厂 = "";
            if (addflag)
            {
                mycls.Id = Guid.NewGuid();
                dal.Add(mycls);
            }
            else
            {
                dal.Update(mycls);
            }

            groupBox1.Enabled = false;

            fill(txt_searchworkno.get_value());


        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
        }

        private void btn_dele_Click(object sender, EventArgs e)
        {
            int selectedindex = data_grd.get_selectrow_index();
            if (selectedindex == -1)
            {
                MessageBox.Show("请先选中一条记录");
                return;
            }

            if (MessageBox.Show("你真的要删除这条记录吗？", "警 告", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            dal.DeleteById(Guid.Parse(data_grd.get_value(0).ToString()));

            fill(txt_searchworkno.get_value());



        }

        private void btn_serarch_Click(object sender, EventArgs e)
        {
            fill(txt_searchworkno.get_value());
        }

        private void mydate_ValueChanged(object sender, EventArgs e)
        {
            fill(txt_searchworkno.get_value());
        }
    }
}
