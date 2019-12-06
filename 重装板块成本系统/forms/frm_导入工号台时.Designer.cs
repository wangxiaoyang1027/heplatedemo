namespace 重装板块成本系统.forms
{
    partial class frm_导入工号台时
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
            this.btn_dele = new System.Windows.Forms.Button();
            this.btn_chg_gh = new System.Windows.Forms.Button();
            this.btn_import = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.mydate = new System.Windows.Forms.DateTimePicker();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.mygrid = new 新财务管理.usercontrols.ctl_grid();
            this.txt_new_gh = new 外分厂生产管理.userctrl.ctrl_text();
            this.txt_old_gh = new 外分厂生产管理.userctrl.ctrl_text();
            this.txt_filename = new 外分厂生产管理.userctrl.ctrl_text();
            this.SuspendLayout();
            // 
            // btn_dele
            // 
            this.btn_dele.Font = new System.Drawing.Font("宋体", 12F);
            this.btn_dele.Location = new System.Drawing.Point(716, 27);
            this.btn_dele.Name = "btn_dele";
            this.btn_dele.Size = new System.Drawing.Size(56, 23);
            this.btn_dele.TabIndex = 19;
            this.btn_dele.Text = "删 除";
            this.btn_dele.UseVisualStyleBackColor = true;
            this.btn_dele.Visible = false;
            this.btn_dele.Click += new System.EventHandler(this.btn_dele_Click);
            // 
            // btn_chg_gh
            // 
            this.btn_chg_gh.Font = new System.Drawing.Font("宋体", 12F);
            this.btn_chg_gh.Location = new System.Drawing.Point(663, 73);
            this.btn_chg_gh.Name = "btn_chg_gh";
            this.btn_chg_gh.Size = new System.Drawing.Size(109, 32);
            this.btn_chg_gh.TabIndex = 16;
            this.btn_chg_gh.Text = "修改工号";
            this.btn_chg_gh.UseVisualStyleBackColor = true;
            this.btn_chg_gh.Click += new System.EventHandler(this.btn_chg_gh_Click);
            // 
            // btn_import
            // 
            this.btn_import.Font = new System.Drawing.Font("宋体", 12F);
            this.btn_import.Location = new System.Drawing.Point(621, 27);
            this.btn_import.Name = "btn_import";
            this.btn_import.Size = new System.Drawing.Size(56, 23);
            this.btn_import.TabIndex = 15;
            this.btn_import.Text = "导 入 ";
            this.btn_import.UseVisualStyleBackColor = true;
            this.btn_import.Click += new System.EventHandler(this.btn_import_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 12F);
            this.button1.Location = new System.Drawing.Point(551, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(44, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F);
            this.label1.Location = new System.Drawing.Point(53, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "月份：";
            // 
            // mydate
            // 
            this.mydate.CalendarFont = new System.Drawing.Font("宋体", 10F);
            this.mydate.Font = new System.Drawing.Font("宋体", 12F);
            this.mydate.Location = new System.Drawing.Point(115, 27);
            this.mydate.Name = "mydate";
            this.mydate.Size = new System.Drawing.Size(129, 26);
            this.mydate.TabIndex = 11;
            this.mydate.ValueChanged += new System.EventHandler(this.mydate_ValueChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // mygrid
            // 
            this.mygrid.Location = new System.Drawing.Point(42, 126);
            this.mygrid.Name = "mygrid";
            this.mygrid.Size = new System.Drawing.Size(730, 495);
            this.mygrid.TabIndex = 20;
            this.mygrid.Load += new System.EventHandler(this.ctl_grid1_Load);
            // 
            // txt_new_gh
            // 
            this.txt_new_gh.Location = new System.Drawing.Point(343, 59);
            this.txt_new_gh.Name = "txt_new_gh";
            this.txt_new_gh.Size = new System.Drawing.Size(295, 46);
            this.txt_new_gh.TabIndex = 18;
            // 
            // txt_old_gh
            // 
            this.txt_old_gh.Location = new System.Drawing.Point(42, 59);
            this.txt_old_gh.Name = "txt_old_gh";
            this.txt_old_gh.Size = new System.Drawing.Size(295, 46);
            this.txt_old_gh.TabIndex = 17;
            // 
            // txt_filename
            // 
            this.txt_filename.Location = new System.Drawing.Point(250, 11);
            this.txt_filename.Name = "txt_filename";
            this.txt_filename.Size = new System.Drawing.Size(295, 46);
            this.txt_filename.TabIndex = 13;
            // 
            // frm_导入工号台时
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 659);
            this.Controls.Add(this.mygrid);
            this.Controls.Add(this.btn_dele);
            this.Controls.Add(this.txt_new_gh);
            this.Controls.Add(this.txt_old_gh);
            this.Controls.Add(this.btn_chg_gh);
            this.Controls.Add(this.btn_import);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txt_filename);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mydate);
            this.Name = "frm_导入工号台时";
            this.Text = "frm_导入工号台时";
            this.Load += new System.EventHandler(this.frm_导入工号台时_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_dele;
        private 外分厂生产管理.userctrl.ctrl_text txt_new_gh;
        private 外分厂生产管理.userctrl.ctrl_text txt_old_gh;
        private System.Windows.Forms.Button btn_chg_gh;
        private System.Windows.Forms.Button btn_import;
        private System.Windows.Forms.Button button1;
        private 外分厂生产管理.userctrl.ctrl_text txt_filename;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker mydate;
        private 新财务管理.usercontrols.ctl_grid mygrid;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}