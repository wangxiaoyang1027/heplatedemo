using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 重装板块成本系统.forms
{
    public partial class frm_删除转出 : Form
    {
        bool _flag;
        public frm_删除转出()
        {
            InitializeComponent();
        }

        private void frm_删除转出_Load(object sender, EventArgs e)
        {
            label1.Text = "你真的要删除这个转出信息吗？";
        }

        private void btn_yes_Click(object sender, EventArgs e)
        {
            _flag = true;
            this.Close();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            _flag = true;
            this.Close();
        }

        public bool show_window()
        {
            this.ShowDialog();
            return _flag;
        }
    }
}
