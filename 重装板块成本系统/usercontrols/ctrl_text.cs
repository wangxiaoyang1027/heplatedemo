using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 外分厂生产管理.userctrl
{
    public partial class ctrl_text : UserControl
    {
        private string value;
        public bool _changedflag;
        private short _type = 0;        // 约定： 0：可输入任何字符  ， 1：输入 int  2：输入 decimal         

        System.Drawing.Color _bg = System.Drawing.Color.LightYellow;
        System.Drawing.Color _abg = System.Drawing.Color.LightPink;


        public ctrl_text()
        {
            InitializeComponent();
            _changedflag = false;
        }

        public void set_type(short mytype)
        {
            _type = mytype;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.BackColor = _abg;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            int i;
            decimal d;

            textBox1.BackColor = _bg;
            value = textBox1.Text;

            switch (_type)
            {
                case 1:
                    if (int.TryParse(value, out i) == false)
                    {
                        MessageBox.Show("输入错误， 要求 整数 ");
                        this.Focus();
                        this.textBox1.SelectAll();
                    }
                    break;
                case 2:
                    if (decimal.TryParse(value, out d) == false)
                    {
                        MessageBox.Show("输入错误， 要求 数字 ");
                        this.Focus();
                        this.textBox1.SelectAll();
                    }
                    break;
            }

        }

        private void ctrl_text_Load(object sender, EventArgs e)
        {
            textBox1.BackColor = _bg;
        }

        public void set_title(string title)
        {
            label1.Text = title;
        }

        public string get_value()
        {
            value = textBox1.Text.Trim();
            return value;
        }
      

        private void ctrl_text_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    value = textBox1.Text;
            //    this.OnKeyDown(e);
            //}
            this.OnKeyDown(e);
        }

        public  void set_value(string myvalue)
        {
            value = myvalue;
            textBox1.Text = myvalue;
        }

      

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            _changedflag = true;
        }


        public  void set_Pwdtype()
        {
            textBox1.UseSystemPasswordChar = true;

        }
    }
}
