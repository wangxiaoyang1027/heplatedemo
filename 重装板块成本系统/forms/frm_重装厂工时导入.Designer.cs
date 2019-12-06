namespace 重装板块成本系统.forms
{
    partial class frm_重装厂工时导入
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.mydate = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.txt_filename = new 外分厂生产管理.userctrl.ctrl_text();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.工具ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.检查工号ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改工号ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grd_gs = new System.Windows.Forms.DataGridView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btn_inport = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd_gs)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 11F);
            this.label1.Location = new System.Drawing.Point(33, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "需要导入工时的月份：";
            // 
            // mydate
            // 
            this.mydate.CalendarForeColor = System.Drawing.Color.Red;
            this.mydate.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.mydate.Font = new System.Drawing.Font("宋体", 11F);
            this.mydate.Location = new System.Drawing.Point(196, 50);
            this.mydate.Name = "mydate";
            this.mydate.Size = new System.Drawing.Size(200, 24);
            this.mydate.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("宋体", 11F);
            this.button1.Location = new System.Drawing.Point(775, 51);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "查 找";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt_filename
            // 
            this.txt_filename.Enabled = false;
            this.txt_filename.Location = new System.Drawing.Point(474, 35);
            this.txt_filename.Name = "txt_filename";
            this.txt_filename.Size = new System.Drawing.Size(295, 46);
            this.txt_filename.TabIndex = 4;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.工具ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1032, 25);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 工具ToolStripMenuItem
            // 
            this.工具ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.检查工号ToolStripMenuItem,
            this.修改工号ToolStripMenuItem});
            this.工具ToolStripMenuItem.Name = "工具ToolStripMenuItem";
            this.工具ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.工具ToolStripMenuItem.Text = "工具";
            // 
            // 检查工号ToolStripMenuItem
            // 
            this.检查工号ToolStripMenuItem.Name = "检查工号ToolStripMenuItem";
            this.检查工号ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.检查工号ToolStripMenuItem.Text = "检查工号";
            this.检查工号ToolStripMenuItem.Click += new System.EventHandler(this.检查工号ToolStripMenuItem_Click_1);
            // 
            // 修改工号ToolStripMenuItem
            // 
            this.修改工号ToolStripMenuItem.Name = "修改工号ToolStripMenuItem";
            this.修改工号ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.修改工号ToolStripMenuItem.Text = "修改工号";
            this.修改工号ToolStripMenuItem.Click += new System.EventHandler(this.修改工号ToolStripMenuItem_Click);
            // 
            // grd_gs
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grd_gs.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.grd_gs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grd_gs.Location = new System.Drawing.Point(23, 87);
            this.grd_gs.Name = "grd_gs";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grd_gs.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.grd_gs.RowTemplate.Height = 23;
            this.grd_gs.Size = new System.Drawing.Size(986, 393);
            this.grd_gs.TabIndex = 9;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btn_inport
            // 
            this.btn_inport.Font = new System.Drawing.Font("宋体", 11F);
            this.btn_inport.Location = new System.Drawing.Point(934, 51);
            this.btn_inport.Name = "btn_inport";
            this.btn_inport.Size = new System.Drawing.Size(75, 23);
            this.btn_inport.TabIndex = 10;
            this.btn_inport.Text = "导  入";
            this.btn_inport.UseVisualStyleBackColor = true;
            this.btn_inport.Click += new System.EventHandler(this.cmb_input_Click);
            // 
            // frm_重装厂工时导入
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 498);
            this.Controls.Add(this.btn_inport);
            this.Controls.Add(this.grd_gs);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mydate);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txt_filename);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frm_重装厂工时导入";
            this.Text = "frm_重装厂工时导入";
            this.Load += new System.EventHandler(this.frm_重装厂工时导入_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd_gs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker mydate;
        private System.Windows.Forms.Button button1;
        private 外分厂生产管理.userctrl.ctrl_text txt_filename;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 工具ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 检查工号ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改工号ToolStripMenuItem;
        private System.Windows.Forms.DataGridView grd_gs;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btn_inport;
    }
}