namespace 重装板块成本系统.forms
{
    partial class frm_成品库批量转出
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
            this.mydate = new System.Windows.Forms.DateTimePicker();
            this.btn_export = new System.Windows.Forms.Button();
            this.mygrid = new 新财务管理.usercontrols.ctl_grid();
            this.btn_file = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_sheets = new System.Windows.Forms.ComboBox();
            this.btn_check = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.chk_all = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mydate
            // 
            this.mydate.Location = new System.Drawing.Point(81, 23);
            this.mydate.Name = "mydate";
            this.mydate.Size = new System.Drawing.Size(200, 21);
            this.mydate.TabIndex = 1;
            this.mydate.ValueChanged += new System.EventHandler(this.mydate_ValueChanged);
            // 
            // btn_export
            // 
            this.btn_export.Location = new System.Drawing.Point(1004, 23);
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(75, 23);
            this.btn_export.TabIndex = 2;
            this.btn_export.Text = "转 出";
            this.btn_export.UseVisualStyleBackColor = true;
            this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
            // 
            // mygrid
            // 
            this.mygrid.Location = new System.Drawing.Point(21, 63);
            this.mygrid.Name = "mygrid";
            this.mygrid.Size = new System.Drawing.Size(1058, 476);
            this.mygrid.TabIndex = 0;
            this.mygrid.UserControlBtnClicked += new 新财务管理.usercontrols.ctl_grid.cmbClickHandle(this.mygrid_UserControlBtnClicked);
            this.mygrid.UserMouseClick += new 新财务管理.usercontrols.ctl_grid.mouse_keyclick(this.mygrid_UserMouseClick);
            this.mygrid.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mygrid_MouseClick);
            this.mygrid.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.mygrid_MouseDoubleClick);
            // 
            // btn_file
            // 
            this.btn_file.Location = new System.Drawing.Point(41, 19);
            this.btn_file.Name = "btn_file";
            this.btn_file.Size = new System.Drawing.Size(75, 23);
            this.btn_file.TabIndex = 5;
            this.btn_file.Text = "文件";
            this.btn_file.UseVisualStyleBackColor = true;
            this.btn_file.Click += new System.EventHandler(this.btn_file_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_check);
            this.groupBox1.Controls.Add(this.cmb_sheets);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btn_file);
            this.groupBox1.Location = new System.Drawing.Point(395, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(578, 53);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 11F);
            this.label1.Location = new System.Drawing.Point(168, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "页表：";
            // 
            // cmb_sheets
            // 
            this.cmb_sheets.Font = new System.Drawing.Font("宋体", 11F);
            this.cmb_sheets.FormattingEnabled = true;
            this.cmb_sheets.Location = new System.Drawing.Point(226, 18);
            this.cmb_sheets.Name = "cmb_sheets";
            this.cmb_sheets.Size = new System.Drawing.Size(121, 23);
            this.cmb_sheets.TabIndex = 7;
            // 
            // btn_check
            // 
            this.btn_check.Location = new System.Drawing.Point(446, 17);
            this.btn_check.Name = "btn_check";
            this.btn_check.Size = new System.Drawing.Size(75, 23);
            this.btn_check.TabIndex = 8;
            this.btn_check.Text = "工号检查";
            this.btn_check.UseVisualStyleBackColor = true;
            this.btn_check.Click += new System.EventHandler(this.btn_check_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // chk_all
            // 
            this.chk_all.AutoSize = true;
            this.chk_all.Location = new System.Drawing.Point(314, 24);
            this.chk_all.Name = "chk_all";
            this.chk_all.Size = new System.Drawing.Size(54, 16);
            this.chk_all.TabIndex = 4;
            this.chk_all.Text = "全 选";
            this.chk_all.UseVisualStyleBackColor = true;
            this.chk_all.CheckedChanged += new System.EventHandler(this.chk_all_CheckedChanged);
            // 
            // frm_成品库批量转出
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 583);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chk_all);
            this.Controls.Add(this.btn_export);
            this.Controls.Add(this.mydate);
            this.Controls.Add(this.mygrid);
            this.Name = "frm_成品库批量转出";
            this.Text = "frm_成品库批量转出";
            this.Load += new System.EventHandler(this.frm_成品库批量转出_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private 新财务管理.usercontrols.ctl_grid mygrid;
        private System.Windows.Forms.DateTimePicker mydate;
        private System.Windows.Forms.Button btn_export;
        private System.Windows.Forms.Button btn_file;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_check;
        private System.Windows.Forms.ComboBox cmb_sheets;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.CheckBox chk_all;
    }
}