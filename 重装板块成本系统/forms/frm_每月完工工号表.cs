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
    public partial class frm_每月完工工号表 : Form
    {
        DataTable tb = new DataTable();
        public frm_每月完工工号表()
        {
            InitializeComponent();
        }

        private void ctl_grid1_Load(object sender, EventArgs e)
        {

        }

        private void frm_每月完工工号表_Load(object sender, EventArgs e)
        {
            Text = "每月完工工号指定";
            MinimizeBox = false;
            MaximizeBox = false;
            


            tb = new DataTable();
            tb.Columns.Add("工号", System.Type.GetType("System.String"));
            tb.Columns.Add("名称", System.Type.GetType("System.String"));
            tb.Columns.Add("完工", System.Type.GetType("System.Boolean"));

            radio_all.Checked = true;
            fill_date(mydate.Value);

            

        }

        private void fill_date( DateTime mydate)
        {
            工号表DAL dal = new 工号表DAL();
            object[] obj;
            SqlDataReader dr = dal.get完工工号表(mydate);
            tb.Rows.Clear();
            try
            {
                DataRow myrow;
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        obj = new object[3];
                        myrow = tb.NewRow();
                        dr.GetValues(obj);
                        myrow.ItemArray = obj;
                        tb.Rows.Add(myrow);
                    }
                }
                dr.Close();
                data_grid.set_date(tb);
                data_grid.set_width(0, 200);
                data_grid.set_width(1, 400);
                data_grid.set_width(2, 50);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void mydate_ValueChanged(object sender, EventArgs e)
        {
            fill_date(mydate.Value);
        }

        private void data_grid_UserMouseClick(object sender, EventArgs e)
        {
            bool myflag;
            DataGridViewCell mycell;
            //每月完工工号表 mycls = new 每月完工工号表();

            mycell = data_grid.get_select_cell();
            if (mycell != null)
            {
                if (data_grid.get_select_cell().ColumnIndex == 2)
                {
                    myflag = bool.Parse(data_grid.get_value(mycell.RowIndex, mycell.ColumnIndex).ToString());
                    myflag = !myflag;

                    data_grid.set_a_date(mycell, myflag);

                    //每月完工工号表DAL 



                    //mycls.set_date(grd_date.get_value(mycell.RowIndex, 0).ToString(), mydate.Value, myflag);
                    //mycls.write_date();

                }
            }
        }
    }
}
