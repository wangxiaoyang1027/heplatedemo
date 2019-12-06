using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 重装板块成本系统
{
    public partial class 总控窗口 : Form
    {
        private int childFormNumber = 0;
        public string _username = "";
        public string _deptname = "";
        public int _deptcode = -1;
        public string _usercard;

        public 总控窗口()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "窗口 " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void 总控窗口_Load(object sender, EventArgs e)
        {
            
            if (_username == "")
            {
                forms.frm_login frm = new forms.frm_login();
                frm.ShowDialog();
                if( frm.dept_code == -1)
                {
                    this.Close();
                }
                else
                {
                    _username = frm.username;
                    _deptname = frm.dept_name;
                    _deptcode = frm.dept_code;
                    _usercard = frm.usercard;

                    this.Text = "重装板块成本系统（ver 1.5）       " + "部门：" + _deptname + "   " + _username;
                }

                if ( _deptcode !=1)
                {
                    管理ToolStripMenuItem.Enabled = false;
                    工具ToolStripMenuItem.Enabled = true;
                }
                else
                {
                    工具ToolStripMenuItem.Enabled = false;
                }

                导入工号台时ToolStripMenuItem.Enabled = false;
                导入每月台时ToolStripMenuItem.Enabled = false;

                if ( _deptcode == 33)
                {
                    导入每月台时ToolStripMenuItem.Enabled = true;
                }
                if (_deptcode == 21)
                {
                    导入工号台时ToolStripMenuItem.Enabled = true;
                }

            }
        }

        private void 建立用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            forms.frm_maintain_user frm = new forms.frm_maintain_user();

            frm.ShowDialog();

        }

        private void 退出ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 以其他用户登录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            forms.frm_login frm = new forms.frm_login();
            frm.ShowDialog();
            if (frm.dept_code == -1)
            {
                this.Close();
            }
            else
            {
                _username = frm.username;
                _deptname = frm.dept_name;
                _deptcode = frm.dept_code;

                this.Text = "重装板块成本系统       " + "部门：" + _deptname + "   " + _username;
            }
        }

        private void 工号维护ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 工号维护ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            forms.frm_worknoMaintain frm = new forms.frm_worknoMaintain();

            frm.ShowDialog();
        }

        private void 导入每月材料ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            forms.frm_import_excel frm = new forms.frm_import_excel();

            frm.deptcode = _deptcode;
            frm.deptname = _deptname;
            frm._isSale = false;

            frm.ShowDialog();
        }

        private void 材料录入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            forms.frm_材料录入 frm = new forms.frm_材料录入();

            frm._deptcode = _deptcode;
            frm._deptname = _deptname;

            frm.ShowDialog();
        }

        private void 材料统计ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            forms.frm_原材料统计 frm = new forms.frm_原材料统计();

            frm.deptcode = _deptcode;
            frm.deptname = _deptname;

            frm.ShowDialog();

        }

        private void 导入每月台时ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            forms.frm_重装厂工时导入 frm = new forms.frm_重装厂工时导入();

            frm.deptcode = _deptcode;
            frm.deptname = _deptname;

            frm.ShowDialog();
                 
        }

        private void 导入工号台时ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            forms.frm_导入工号台时 frm = new forms.frm_导入工号台时();

            frm.deptcode = _deptcode;
            frm.deptname = _deptname;
            frm.ShowDialog();
        }

        private void 更改个人密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            forms.frm_更改密码 frm = new forms.frm_更改密码();

            frm.deptcode = _deptcode;
            frm.usercard = _usercard;

            frm.ShowDialog();
        }

        private void 每月费用录入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            forms.frm_每月费用录入 frm = new forms.frm_每月费用录入();

            frm.deptcode = _deptcode;
            frm.deptname = _deptname;

            frm.ShowDialog();
        }

        private void 调整费用分配ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            forms.frm_调整费用分配 frm = new forms.frm_调整费用分配();

            frm.deptcode = _deptcode;
            frm.deptname = _deptname;

            frm.ShowDialog();
        }

        private void 其它单位材料查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            forms.frm其它部门费用 frm = new forms.frm其它部门费用();

            frm.deptcode = _deptcode;
            frm.deptname = _deptname;

            frm.ShowDialog();
        }

        private void 每月收入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            forms.frm_收入导入 frm = new forms.frm_收入导入();

            frm.deptcode = _deptcode;
            frm.deptname = _deptname;

            frm.ShowDialog();
            
        }

        private void 每月收入列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            forms.frm_每月收入列表 frm = new forms.frm_每月收入列表();


            frm.ShowDialog();
        }

        private void 工号工具ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            forms.frm_工号工具 frm = new forms.frm_工号工具();

            frm.deptcode = _deptcode;

            frm.ShowDialog();
        }

        private void 每月转出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            forms.frm_每月完工转出 frm = new forms.frm_每月完工转出();

            frm.deptcode = _deptcode;
            frm.deptname = _deptname;

            frm.ShowDialog();
        }

        private void 计算费用分配ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            forms.frm_计算费用分配 frm = new forms.frm_计算费用分配();

            frm.deptcode = _deptcode;
            frm.deptname = _deptname;

            frm.ShowDialog();
        }

        private void 导出报表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            forms.frm_导出报表 frm = new forms.frm_导出报表();

            frm.deptcode = _deptcode;
            frm.deptname = _deptname;

            frm.ShowDialog();


        }

        private void 成本明细ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            forms.frm_明细查询 frm = new forms.frm_明细查询();

            frm.ShowDialog();
        }

        private void 设置每月完工工号ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            forms.frm_每月完工工号表 frm = new forms.frm_每月完工工号表();

            frm.ShowDialog();
        }

        private void 本厂报表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            forms.frm_本厂报表 frm = new forms.frm_本厂报表();

            frm.deptcode = _deptcode;
            frm.deptname = _deptname;

            frm.ShowDialog();
        }

        private void 成品报表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            forms.frm_完工转账总表 frm = new forms.frm_完工转账总表();

            frm.ShowDialog();
        }

        private void 销售成本结算表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            forms.frm_销售成本结算表 frm = new forms.frm_销售成本结算表();

            frm.ShowDialog();
        }

        private void 转出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            forms.frm_成品库房转出 frm = new forms.frm_成品库房转出();

            frm.ShowDialog();
        }

        private void 查询ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            forms.frm_成品库房List frm = new forms.frm_成品库房List();

            frm.ShowDialog();
        }

        private void 铆焊齿轮成本结算表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            forms.frm_铆焊齿轮成本结算表 frm = new forms.frm_铆焊齿轮成本结算表();

            frm.ShowDialog();
        }

        private void 销售利润表内贸ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            forms.frm_内贸利润表 frm = new forms.frm_内贸利润表();

            frm.ShowDialog();
        }

        private void 销售利润表外贸ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            forms.frm_外贸利润表 frm = new forms.frm_外贸利润表();

            frm.ShowDialog();
        }

        private void 销售利润表内部交易ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            forms.frm_内部交易利润表 frm = new forms.frm_内部交易利润表();

            frm.ShowDialog();
        }

        private void 批量转出操作ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            forms.frm_成品库批量转出 frm = new forms.frm_成品库批量转出();

            frm.ShowDialog();
        }

        private void 报表生成ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 其它部门导入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void 其它费用导入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //forms.frm_otherCost frm = new forms.frm_otherCost();
            forms.frm_import_excel frm = new forms.frm_import_excel();

            frm._isSale = true;

            frm.deptcode = _deptcode;
            frm.deptname = _deptname;


            frm.ShowDialog();
        }

        private void 其它费用修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            forms.frm_材料录入 frm = new forms.frm_材料录入();

            frm._deptcode = _deptcode;
            frm._deptname = _deptname;

            frm.ShowDialog();
        }
    }
}
