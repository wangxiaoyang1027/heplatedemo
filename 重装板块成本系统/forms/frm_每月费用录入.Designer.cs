namespace 重装板块成本系统.forms
{
    partial class frm_每月费用录入
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_cancle = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.mydate = new System.Windows.Forms.DateTimePicker();
            this.txt_zzfy = new 外分厂生产管理.userctrl.ctrl_text();
            this.txt_gzfl = new 外分厂生产管理.userctrl.ctrl_text();
            this.txt_rldl = new 外分厂生产管理.userctrl.ctrl_text();
            this.lab_title = new System.Windows.Forms.Label();
            this.btn_edit = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.grd_data = new 新财务管理.usercontrols.ctl_grid();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_cancle);
            this.groupBox1.Controls.Add(this.btn_save);
            this.groupBox1.Controls.Add(this.mydate);
            this.groupBox1.Controls.Add(this.txt_zzfy);
            this.groupBox1.Controls.Add(this.txt_gzfl);
            this.groupBox1.Controls.Add(this.txt_rldl);
            this.groupBox1.Location = new System.Drawing.Point(41, 394);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(742, 204);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // btn_cancle
            // 
            this.btn_cancle.Location = new System.Drawing.Point(607, 147);
            this.btn_cancle.Name = "btn_cancle";
            this.btn_cancle.Size = new System.Drawing.Size(75, 23);
            this.btn_cancle.TabIndex = 6;
            this.btn_cancle.Text = "button2";
            this.btn_cancle.UseVisualStyleBackColor = true;
            // 
            // btn_save
            // 
            this.btn_save.Font = new System.Drawing.Font("宋体", 11F);
            this.btn_save.Location = new System.Drawing.Point(459, 147);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 5;
            this.btn_save.Text = "button1";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // mydate
            // 
            this.mydate.CalendarFont = new System.Drawing.Font("宋体", 11F);
            this.mydate.Font = new System.Drawing.Font("宋体", 11F);
            this.mydate.Location = new System.Drawing.Point(310, 20);
            this.mydate.Name = "mydate";
            this.mydate.Size = new System.Drawing.Size(200, 24);
            this.mydate.TabIndex = 4;
            // 
            // txt_zzfy
            // 
            this.txt_zzfy.Location = new System.Drawing.Point(26, 134);
            this.txt_zzfy.Name = "txt_zzfy";
            this.txt_zzfy.Size = new System.Drawing.Size(295, 46);
            this.txt_zzfy.TabIndex = 3;
            // 
            // txt_gzfl
            // 
            this.txt_gzfl.Location = new System.Drawing.Point(420, 71);
            this.txt_gzfl.Name = "txt_gzfl";
            this.txt_gzfl.Size = new System.Drawing.Size(295, 46);
            this.txt_gzfl.TabIndex = 2;
            // 
            // txt_rldl
            // 
            this.txt_rldl.Location = new System.Drawing.Point(26, 71);
            this.txt_rldl.Name = "txt_rldl";
            this.txt_rldl.Size = new System.Drawing.Size(295, 46);
            this.txt_rldl.TabIndex = 1;
            // 
            // lab_title
            // 
            this.lab_title.AutoSize = true;
            this.lab_title.Font = new System.Drawing.Font("宋体", 14F);
            this.lab_title.ForeColor = System.Drawing.Color.Red;
            this.lab_title.Location = new System.Drawing.Point(347, 9);
            this.lab_title.Name = "lab_title";
            this.lab_title.Size = new System.Drawing.Size(123, 19);
            this.lab_title.TabIndex = 7;
            this.lab_title.Text = "参与分配金额";
            // 
            // btn_edit
            // 
            this.btn_edit.Font = new System.Drawing.Font("宋体", 11F);
            this.btn_edit.Location = new System.Drawing.Point(708, 36);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(75, 23);
            this.btn_edit.TabIndex = 9;
            this.btn_edit.Text = "修  改";
            this.btn_edit.UseVisualStyleBackColor = true;
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // btn_add
            // 
            this.btn_add.Font = new System.Drawing.Font("宋体", 11F);
            this.btn_add.Location = new System.Drawing.Point(618, 36);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(75, 23);
            this.btn_add.TabIndex = 8;
            this.btn_add.Text = "增  加";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // grd_data
            // 
            this.grd_data.Location = new System.Drawing.Point(41, 65);
            this.grd_data.Name = "grd_data";
            this.grd_data.Size = new System.Drawing.Size(742, 323);
            this.grd_data.TabIndex = 6;
            // 
            // frm_每月费用录入
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 610);
            this.Controls.Add(this.btn_edit);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.lab_title);
            this.Controls.Add(this.grd_data);
            this.Controls.Add(this.groupBox1);
            this.Name = "frm_每月费用录入";
            this.Text = "frm_每月费用录入";
            this.Load += new System.EventHandler(this.frm_每月费用录入_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_cancle;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.DateTimePicker mydate;
        private 外分厂生产管理.userctrl.ctrl_text txt_zzfy;
        private 外分厂生产管理.userctrl.ctrl_text txt_gzfl;
        private 外分厂生产管理.userctrl.ctrl_text txt_rldl;
        private 新财务管理.usercontrols.ctl_grid grd_data;
        private System.Windows.Forms.Label lab_title;
        private System.Windows.Forms.Button btn_edit;
        private System.Windows.Forms.Button btn_add;
    }
}