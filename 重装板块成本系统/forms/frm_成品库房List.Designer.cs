namespace 重装板块成本系统.forms
{
    partial class frm_成品库房List
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
            this.btn_search = new System.Windows.Forms.Button();
            this.btn_export = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btn_add = new System.Windows.Forms.Button();
            this.btn_del = new System.Windows.Forms.Button();
            this.btn_edit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_xsjy = new 外分厂生产管理.userctrl.ctrl_text();
            this.txt_gjjy = new 外分厂生产管理.userctrl.ctrl_text();
            this.txt_ys = new 外分厂生产管理.userctrl.ctrl_text();
            this.txt_qt = new 外分厂生产管理.userctrl.ctrl_text();
            this.txt_zdh = new 外分厂生产管理.userctrl.ctrl_text();
            this.txt_sj = new 外分厂生产管理.userctrl.ctrl_text();
            this.txt_ty = new 外分厂生产管理.userctrl.ctrl_text();
            this.txt_az = new 外分厂生产管理.userctrl.ctrl_text();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_cancle = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txt_je = new 外分厂生产管理.userctrl.ctrl_text();
            this.txt_gh = new 外分厂生产管理.userctrl.ctrl_text();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.mydate = new System.Windows.Forms.DateTimePicker();
            this.txt_workno = new 外分厂生产管理.userctrl.ctrl_text();
            this.grd = new 新财务管理.usercontrols.ctl_grid();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_search
            // 
            this.btn_search.Font = new System.Drawing.Font("宋体", 11F);
            this.btn_search.Location = new System.Drawing.Point(317, 32);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(62, 23);
            this.btn_search.TabIndex = 2;
            this.btn_search.Text = "查 询";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // btn_export
            // 
            this.btn_export.Font = new System.Drawing.Font("宋体", 11F);
            this.btn_export.Location = new System.Drawing.Point(104, 49);
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(75, 23);
            this.btn_export.TabIndex = 3;
            this.btn_export.Text = "导 出";
            this.btn_export.UseVisualStyleBackColor = true;
            this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
            // 
            // btn_add
            // 
            this.btn_add.Font = new System.Drawing.Font("宋体", 11F);
            this.btn_add.Location = new System.Drawing.Point(141, 81);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(75, 23);
            this.btn_add.TabIndex = 4;
            this.btn_add.Text = "增 加";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_del
            // 
            this.btn_del.Font = new System.Drawing.Font("宋体", 11F);
            this.btn_del.Location = new System.Drawing.Point(364, 81);
            this.btn_del.Name = "btn_del";
            this.btn_del.Size = new System.Drawing.Size(75, 23);
            this.btn_del.TabIndex = 5;
            this.btn_del.Text = "删 除";
            this.btn_del.UseVisualStyleBackColor = true;
            this.btn_del.Click += new System.EventHandler(this.btn_del_Click);
            // 
            // btn_edit
            // 
            this.btn_edit.Font = new System.Drawing.Font("宋体", 11F);
            this.btn_edit.Location = new System.Drawing.Point(252, 81);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(75, 23);
            this.btn_edit.TabIndex = 6;
            this.btn_edit.Text = "修 改";
            this.btn_edit.UseVisualStyleBackColor = true;
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_xsjy);
            this.groupBox1.Controls.Add(this.txt_gjjy);
            this.groupBox1.Controls.Add(this.txt_ys);
            this.groupBox1.Controls.Add(this.txt_qt);
            this.groupBox1.Controls.Add(this.txt_zdh);
            this.groupBox1.Controls.Add(this.txt_sj);
            this.groupBox1.Controls.Add(this.txt_ty);
            this.groupBox1.Controls.Add(this.txt_az);
            this.groupBox1.Controls.Add(this.btn_save);
            this.groupBox1.Controls.Add(this.btn_cancle);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.txt_je);
            this.groupBox1.Controls.Add(this.txt_gh);
            this.groupBox1.Location = new System.Drawing.Point(849, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(317, 575);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // txt_xsjy
            // 
            this.txt_xsjy.Location = new System.Drawing.Point(15, 417);
            this.txt_xsjy.Name = "txt_xsjy";
            this.txt_xsjy.Size = new System.Drawing.Size(295, 46);
            this.txt_xsjy.TabIndex = 16;
            // 
            // txt_gjjy
            // 
            this.txt_gjjy.Location = new System.Drawing.Point(15, 463);
            this.txt_gjjy.Name = "txt_gjjy";
            this.txt_gjjy.Size = new System.Drawing.Size(295, 46);
            this.txt_gjjy.TabIndex = 14;
            // 
            // txt_ys
            // 
            this.txt_ys.Location = new System.Drawing.Point(15, 280);
            this.txt_ys.Name = "txt_ys";
            this.txt_ys.Size = new System.Drawing.Size(295, 46);
            this.txt_ys.TabIndex = 12;
            // 
            // txt_qt
            // 
            this.txt_qt.Location = new System.Drawing.Point(15, 372);
            this.txt_qt.Name = "txt_qt";
            this.txt_qt.Size = new System.Drawing.Size(295, 46);
            this.txt_qt.TabIndex = 15;
            // 
            // txt_zdh
            // 
            this.txt_zdh.Location = new System.Drawing.Point(15, 191);
            this.txt_zdh.Name = "txt_zdh";
            this.txt_zdh.Size = new System.Drawing.Size(295, 46);
            this.txt_zdh.TabIndex = 11;
            // 
            // txt_sj
            // 
            this.txt_sj.Location = new System.Drawing.Point(15, 234);
            this.txt_sj.Name = "txt_sj";
            this.txt_sj.Size = new System.Drawing.Size(295, 46);
            this.txt_sj.TabIndex = 10;
            // 
            // txt_ty
            // 
            this.txt_ty.Location = new System.Drawing.Point(15, 145);
            this.txt_ty.Name = "txt_ty";
            this.txt_ty.Size = new System.Drawing.Size(295, 46);
            this.txt_ty.TabIndex = 9;
            // 
            // txt_az
            // 
            this.txt_az.Location = new System.Drawing.Point(15, 325);
            this.txt_az.Name = "txt_az";
            this.txt_az.Size = new System.Drawing.Size(295, 46);
            this.txt_az.TabIndex = 13;
            // 
            // btn_save
            // 
            this.btn_save.Font = new System.Drawing.Font("宋体", 11F);
            this.btn_save.Location = new System.Drawing.Point(75, 537);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 8;
            this.btn_save.Text = "保 存";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_cancle
            // 
            this.btn_cancle.Font = new System.Drawing.Font("宋体", 11F);
            this.btn_cancle.Location = new System.Drawing.Point(187, 537);
            this.btn_cancle.Name = "btn_cancle";
            this.btn_cancle.Size = new System.Drawing.Size(75, 23);
            this.btn_cancle.TabIndex = 7;
            this.btn_cancle.Text = "取 消";
            this.btn_cancle.UseVisualStyleBackColor = true;
            this.btn_cancle.Click += new System.EventHandler(this.btn_cancle_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 11F);
            this.label1.Location = new System.Drawing.Point(28, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "日期:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("宋体", 11F);
            this.dateTimePicker1.Location = new System.Drawing.Point(110, 75);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(188, 24);
            this.dateTimePicker1.TabIndex = 4;
            // 
            // txt_je
            // 
            this.txt_je.Location = new System.Drawing.Point(15, 101);
            this.txt_je.Name = "txt_je";
            this.txt_je.Size = new System.Drawing.Size(295, 46);
            this.txt_je.TabIndex = 3;
            // 
            // txt_gh
            // 
            this.txt_gh.Location = new System.Drawing.Point(15, 15);
            this.txt_gh.Name = "txt_gh";
            this.txt_gh.Size = new System.Drawing.Size(295, 46);
            this.txt_gh.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 11F);
            this.button1.Location = new System.Drawing.Point(385, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(54, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "导 入";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.mydate);
            this.groupBox2.Controls.Add(this.btn_export);
            this.groupBox2.Location = new System.Drawing.Point(525, 24);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(293, 80);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "导出操作：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 11F);
            this.label2.Location = new System.Drawing.Point(12, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "导出日期：";
            // 
            // mydate
            // 
            this.mydate.Font = new System.Drawing.Font("宋体", 11F);
            this.mydate.Location = new System.Drawing.Point(104, 19);
            this.mydate.Name = "mydate";
            this.mydate.Size = new System.Drawing.Size(171, 24);
            this.mydate.TabIndex = 4;
            // 
            // txt_workno
            // 
            this.txt_workno.Location = new System.Drawing.Point(20, 18);
            this.txt_workno.Name = "txt_workno";
            this.txt_workno.Size = new System.Drawing.Size(295, 46);
            this.txt_workno.TabIndex = 1;
            // 
            // grd
            // 
            this.grd.Location = new System.Drawing.Point(47, 110);
            this.grd.Name = "grd";
            this.grd.Size = new System.Drawing.Size(771, 489);
            this.grd.TabIndex = 0;
            this.grd.UserControlBtnClicked += new 新财务管理.usercontrols.ctl_grid.cmbClickHandle(this.grd_UserControlBtnClicked);
            this.grd.UserMousePressed += new 新财务管理.usercontrols.ctl_grid.mouse_keypress(this.grd_UserMousePressed);
            this.grd.Load += new System.EventHandler(this.grd_Load);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("宋体", 11F);
            this.button2.Location = new System.Drawing.Point(200, 49);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "导出总表";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frm_成品库房List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 611);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_edit);
            this.Controls.Add(this.btn_del);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.txt_workno);
            this.Controls.Add(this.grd);
            this.Name = "frm_成品库房List";
            this.Text = "frm_成品库房List";
            this.Load += new System.EventHandler(this.frm_成品库房List_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private 新财务管理.usercontrols.ctl_grid grd;
        private 外分厂生产管理.userctrl.ctrl_text txt_workno;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Button btn_export;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button btn_del;
        private System.Windows.Forms.Button btn_edit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_cancle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private 外分厂生产管理.userctrl.ctrl_text txt_je;
        private 外分厂生产管理.userctrl.ctrl_text txt_gh;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker mydate;
        private 外分厂生产管理.userctrl.ctrl_text txt_az;
        private 外分厂生产管理.userctrl.ctrl_text txt_ys;
        private 外分厂生产管理.userctrl.ctrl_text txt_zdh;
        private 外分厂生产管理.userctrl.ctrl_text txt_sj;
        private 外分厂生产管理.userctrl.ctrl_text txt_ty;
        private 外分厂生产管理.userctrl.ctrl_text txt_xsjy;
        private 外分厂生产管理.userctrl.ctrl_text txt_gjjy;
        private 外分厂生产管理.userctrl.ctrl_text txt_qt;
        private System.Windows.Forms.Button button2;
    }
}