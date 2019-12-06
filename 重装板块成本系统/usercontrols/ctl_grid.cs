using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 新财务管理.usercontrols
{
    public partial class ctl_grid : UserControl
    {
        // 定义委托
        public delegate void cmbClickHandle(object sender, EventArgs e);
        public delegate void mouse_keypress(object sender, EventArgs e);
        public delegate void mouse_keyclick(object sender, EventArgs e);
        

        // 定义事件
        public event cmbClickHandle UserControlBtnClicked;
        public event mouse_keypress UserMousePressed;
        public event mouse_keyclick UserMouseClick;
        


        DataTable tb_copy = new DataTable ();


        public ctl_grid()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ctl_grid_Load(object sender, EventArgs e)
        {
            dataGridView1.Left = 0;
            dataGridView1.Top = 0;
            dataGridView1.Height = this.Height;
            dataGridView1.Width = this.Width;
        }


        // 设置数据源
        public void set_date(DataSet ds)
        {
            this.dataGridView1.DataSource = ds.Tables[0];

            tb_copy = ds.Tables[0].Clone();


            tb_copy = ds.Tables[0].Copy();

            

            //this.dataGridView1.Columns[0].Width = 60;
            //this.dataGridView1.Columns[2].Width = 80;
            //this.dataGridView1.Columns[3].Width = 80;
        }


        // 增加一行
        public void addrow( DataGridViewRow _myrow)
        {
            dataGridView1.Rows.Add(_myrow);
        }


        // 插入一行 
        public void  insertrow( int rowindex , DataGridViewRow myrow)
        {
            dataGridView1.Rows.Insert(rowindex, myrow);



        }


        // 设置 grid 列
        public void set_column( DataGridViewColumn _mycol)
        {
            dataGridView1.Columns.Add(_mycol);
        }

        // 把某一列设为 “隐藏”
        public void set_hide(int col_index)
        {

            this.dataGridView1.Columns[col_index].Visible = false;
        }


        // 设置数据源
        public void set_date(DataTable tb)
        {
          

            this.dataGridView1.DataSource = tb ;
            

            tb_copy = tb.Copy();

        }

        // 设置某一列的宽度
        public void set_width( int col_index , int col_width)
        {
            this.dataGridView1.Columns[col_index].Width = col_width;
        }


        // 设置某一列的标题
        public void set_head_title(int col_index, string title)
        {
            dataGridView1.Columns[col_index].HeaderText = title;
        }

        // 返回 选择 的列索引
        public int get_select_index()
        {
            if (dataGridView1.SelectedColumns.Count > 0)
                return dataGridView1.SelectedColumns[0].Index;
            else
                return -1;
        }

        // 返回选择的单元格
        public DataGridViewCell  get_select_cell()
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                return dataGridView1.SelectedCells[0];
            }
            else
                return null;
        }


        // 设置一个 cell 为 可编辑  ---- 无效 ？
        public void set_edit(int row, int col)
        {
            dataGridView1.CurrentCell = dataGridView1.Rows[row].Cells[col];

            dataGridView1.ReadOnly = false;
            dataGridView1.BeginEdit(true);

        }


        // 设置一列 为 是否“可编辑”
        public void set_col_editable( int colnum , bool editable)
        {
            dataGridView1.Columns[colnum].ReadOnly = !editable;


        }


        
        public void set_ReadOnly( int row_index , int col_index , bool flag)
        {
            dataGridView1[col_index , row_index].ReadOnly =false;
        }

        public void set_ReadOnly(int col_index, bool flag)
        {
            dataGridView1.Columns[col_index].ReadOnly = flag;
        }


        public void set_enter()
        {
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
        }

        public void set_ReadOnly(bool flag)
        {
            dataGridView1.ReadOnly = flag;
        }


        // 为一个 单元格设置 bool 值
        public void set_a_date( DataGridViewCell mycell,  bool myvalue)
        {
            dataGridView1.Rows[mycell.RowIndex].Cells[mycell.ColumnIndex].Value = myvalue;
        }


        // 为一个 单元格设置 bool 值
        public void set_a_date(int row_index, int col_index, bool myvalue)
        {
            dataGridView1.Rows[row_index].Cells[col_index].Value = myvalue;
        }



        // 为一个 单元格设置 decimal 值
        public void set_a_date(int row_index , int col_index , decimal myvalue)
        {
            dataGridView1.Rows[row_index ].Cells[col_index].Value = myvalue;
        }

        public void set_a_date(int row_index, int col_index, string myvalue)
        {
            dataGridView1.Rows[row_index].Cells[col_index].Value = myvalue;
        }


        // 返回 选择的行索引
        public bool has_selectrow()
        {
            return (dataGridView1.SelectedRows.Count > 0);
        }

        public int get_selectrow_index()
        {
            if (has_selectrow())
            {
                return dataGridView1.SelectedRows[0].Index;
            }
            else
                return -1;
        }

        // 得到选择行的指定列的值
        public object  get_value(int col_index)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                return dataGridView1.SelectedRows[0].Cells[col_index].Value;
            }
            else
                return null;
        }


        // 得到指定行列单元格的值
        public object get_value(int row, int col)
        {
            return dataGridView1.Rows[row].Cells[col].Value;
        }

        //得到 行 的个数
        public int get_row_number()
        {
            return dataGridView1.Rows.Count;
        }


        public void AllowUserToAddRows(bool allow)
        {
            dataGridView1.AllowUserToAddRows = allow ;
        }


        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (UserControlBtnClicked != null)
                UserControlBtnClicked(sender, new EventArgs());//把按钮自身作为参数传递
        }



        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {

            if ((UserMousePressed != null) && (e.Button == System.Windows.Forms.MouseButtons.Right))
            {
                UserMousePressed(sender, e);
                return;
            }
            if ((UserMouseClick != null) && (e.Button == System.Windows.Forms.MouseButtons.Left))
            {
                
                UserMouseClick(sender, e);
                return;
            }
        }


        // 将某列符合条件的行过滤出来
        public void filt_grd(int col, string myvalue )
        {
            DataTable tb;
            DataRow[] myrows;

            tb = ((DataTable)dataGridView1.DataSource).Clone ();


            myrows  = tb_copy.Select("工号 like '" + myvalue + "'");
            tb.Rows.Clear();
            foreach (DataRow myrow in myrows )
            {
                DataRow newrow;

                newrow = tb.NewRow ();
                newrow.ItemArray = myrow.ItemArray;

                tb.Rows.Add(newrow);
            }
            dataGridView1.DataSource = tb;
        }

        public void disp_all()
        {
            DataTable tb ;

            tb = tb_copy.Copy();

            dataGridView1.DataSource = tb;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
    }
}
