namespace 重装板块成本系统.forms
{
    partial class frm_库房信息导入
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
            this.import_date = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_filename = new 外分厂生产管理.userctrl.ctrl_text();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_filename = new System.Windows.Forms.Button();
            this.mygrd = new 新财务管理.usercontrols.ctl_grid();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // import_date
            // 
            this.import_date.Font = new System.Drawing.Font("宋体", 11F);
            this.import_date.Location = new System.Drawing.Point(106, 80);
            this.import_date.Name = "import_date";
            this.import_date.Size = new System.Drawing.Size(200, 24);
            this.import_date.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 11F);
            this.label1.Location = new System.Drawing.Point(38, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "日期：";
            // 
            // txt_filename
            // 
            this.txt_filename.Location = new System.Drawing.Point(23, 12);
            this.txt_filename.Name = "txt_filename";
            this.txt_filename.Size = new System.Drawing.Size(295, 46);
            this.txt_filename.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(335, 80);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "导 入";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_filename
            // 
            this.btn_filename.Location = new System.Drawing.Point(335, 26);
            this.btn_filename.Name = "btn_filename";
            this.btn_filename.Size = new System.Drawing.Size(36, 23);
            this.btn_filename.TabIndex = 4;
            this.btn_filename.Text = "...";
            this.btn_filename.UseVisualStyleBackColor = true;
            this.btn_filename.Click += new System.EventHandler(this.btn_filename_Click);
            // 
            // mygrd
            // 
            this.mygrd.Location = new System.Drawing.Point(41, 140);
            this.mygrd.Name = "mygrd";
            this.mygrd.Size = new System.Drawing.Size(454, 280);
            this.mygrd.TabIndex = 5;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // frm_库房信息导入
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 432);
            this.Controls.Add(this.mygrd);
            this.Controls.Add(this.btn_filename);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txt_filename);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.import_date);
            this.Name = "frm_库房信息导入";
            this.Text = "frm_库房信息导入";
            this.Load += new System.EventHandler(this.frm_库房信息导入_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker import_date;
        private System.Windows.Forms.Label label1;
        private 外分厂生产管理.userctrl.ctrl_text txt_filename;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_filename;
        private 新财务管理.usercontrols.ctl_grid mygrd;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}