namespace 重装板块成本系统.forms
{
    partial class frm_maintain_user
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
            this.txt_cardno = new 外分厂生产管理.userctrl.ctrl_text();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_noused = new System.Windows.Forms.ComboBox();
            this.txt_pwd1 = new 外分厂生产管理.userctrl.ctrl_text();
            this.txt_pwd = new 外分厂生产管理.userctrl.ctrl_text();
            this.btn_cancle = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.cmb_dept = new System.Windows.Forms.ComboBox();
            this.chk_admin = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_username = new 外分厂生产管理.userctrl.ctrl_text();
            this.btn_add = new System.Windows.Forms.Button();
            this.btn_edit = new System.Windows.Forms.Button();
            this.usergrid = new 新财务管理.usercontrols.ctl_grid();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_cardno);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmb_noused);
            this.groupBox1.Controls.Add(this.txt_pwd1);
            this.groupBox1.Controls.Add(this.txt_pwd);
            this.groupBox1.Controls.Add(this.btn_cancle);
            this.groupBox1.Controls.Add(this.btn_save);
            this.groupBox1.Controls.Add(this.cmb_dept);
            this.groupBox1.Controls.Add(this.chk_admin);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_username);
            this.groupBox1.Location = new System.Drawing.Point(434, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(354, 412);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // txt_cardno
            // 
            this.txt_cardno.Location = new System.Drawing.Point(38, 72);
            this.txt_cardno.Name = "txt_cardno";
            this.txt_cardno.Size = new System.Drawing.Size(295, 46);
            this.txt_cardno.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 11F);
            this.label2.Location = new System.Drawing.Point(35, 327);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "禁用：";
            // 
            // cmb_noused
            // 
            this.cmb_noused.Font = new System.Drawing.Font("宋体", 11F);
            this.cmb_noused.FormattingEnabled = true;
            this.cmb_noused.Location = new System.Drawing.Point(123, 324);
            this.cmb_noused.Name = "cmb_noused";
            this.cmb_noused.Size = new System.Drawing.Size(205, 23);
            this.cmb_noused.TabIndex = 8;
            // 
            // txt_pwd1
            // 
            this.txt_pwd1.Location = new System.Drawing.Point(33, 257);
            this.txt_pwd1.Name = "txt_pwd1";
            this.txt_pwd1.Size = new System.Drawing.Size(295, 46);
            this.txt_pwd1.TabIndex = 7;
            // 
            // txt_pwd
            // 
            this.txt_pwd.Location = new System.Drawing.Point(30, 205);
            this.txt_pwd.Name = "txt_pwd";
            this.txt_pwd.Size = new System.Drawing.Size(295, 46);
            this.txt_pwd.TabIndex = 6;
            // 
            // btn_cancle
            // 
            this.btn_cancle.Location = new System.Drawing.Point(237, 371);
            this.btn_cancle.Name = "btn_cancle";
            this.btn_cancle.Size = new System.Drawing.Size(75, 23);
            this.btn_cancle.TabIndex = 5;
            this.btn_cancle.Text = "取 消";
            this.btn_cancle.UseVisualStyleBackColor = true;
            this.btn_cancle.Click += new System.EventHandler(this.button3_Click);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(130, 371);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 4;
            this.btn_save.Text = "保 存";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // cmb_dept
            // 
            this.cmb_dept.Font = new System.Drawing.Font("宋体", 11F);
            this.cmb_dept.FormattingEnabled = true;
            this.cmb_dept.Location = new System.Drawing.Point(123, 179);
            this.cmb_dept.Name = "cmb_dept";
            this.cmb_dept.Size = new System.Drawing.Size(205, 23);
            this.cmb_dept.TabIndex = 3;
            // 
            // chk_admin
            // 
            this.chk_admin.AutoSize = true;
            this.chk_admin.Location = new System.Drawing.Point(168, 142);
            this.chk_admin.Name = "chk_admin";
            this.chk_admin.Size = new System.Drawing.Size(78, 16);
            this.chk_admin.TabIndex = 2;
            this.chk_admin.Text = "checkBox1";
            this.chk_admin.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 11F);
            this.label1.Location = new System.Drawing.Point(35, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "所属部门：";
            // 
            // txt_username
            // 
            this.txt_username.Location = new System.Drawing.Point(33, 20);
            this.txt_username.Name = "txt_username";
            this.txt_username.Size = new System.Drawing.Size(295, 46);
            this.txt_username.TabIndex = 0;
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(56, 26);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(75, 23);
            this.btn_add.TabIndex = 2;
            this.btn_add.Text = "增加";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_edit
            // 
            this.btn_edit.Enabled = false;
            this.btn_edit.Location = new System.Drawing.Point(163, 26);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(75, 23);
            this.btn_edit.TabIndex = 3;
            this.btn_edit.Text = "编辑";
            this.btn_edit.UseVisualStyleBackColor = true;
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // usergrid
            // 
            this.usergrid.Location = new System.Drawing.Point(12, 75);
            this.usergrid.Name = "usergrid";
            this.usergrid.Size = new System.Drawing.Size(392, 363);
            this.usergrid.TabIndex = 0;
            // 
            // frm_maintain_user
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_edit);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.usergrid);
            this.Name = "frm_maintain_user";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户维护";
            this.Load += new System.EventHandler(this.frm_maintain_user_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private 新财务管理.usercontrols.ctl_grid usergrid;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmb_dept;
        private System.Windows.Forms.CheckBox chk_admin;
        private System.Windows.Forms.Label label1;
        private 外分厂生产管理.userctrl.ctrl_text txt_username;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_noused;
        private 外分厂生产管理.userctrl.ctrl_text txt_pwd1;
        private 外分厂生产管理.userctrl.ctrl_text txt_pwd;
        private System.Windows.Forms.Button btn_cancle;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button btn_edit;
        private 外分厂生产管理.userctrl.ctrl_text txt_cardno;
    }
}