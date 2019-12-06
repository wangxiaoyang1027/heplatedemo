namespace 重装板块成本系统.forms
{
    partial class frm_成品库房转出
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
            this.mydate = new System.Windows.Forms.DateTimePicker();
            this.btn_out = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_gjjy = new 外分厂生产管理.userctrl.ctrl_text();
            this.txt_xsjy = new 外分厂生产管理.userctrl.ctrl_text();
            this.txt_qt = new 外分厂生产管理.userctrl.ctrl_text();
            this.txt_az = new 外分厂生产管理.userctrl.ctrl_text();
            this.txt_ys = new 外分厂生产管理.userctrl.ctrl_text();
            this.txt_sj = new 外分厂生产管理.userctrl.ctrl_text();
            this.txt_zdh = new 外分厂生产管理.userctrl.ctrl_text();
            this.txt_ty = new 外分厂生产管理.userctrl.ctrl_text();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_cancle = new System.Windows.Forms.Button();
            this.txt_je = new 外分厂生产管理.userctrl.ctrl_text();
            this.txt_workno1 = new 外分厂生产管理.userctrl.ctrl_text();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_edit = new System.Windows.Forms.Button();
            this.btn_del = new System.Windows.Forms.Button();
            this.txt_workno = new 外分厂生产管理.userctrl.ctrl_text();
            this.grd = new 新财务管理.usercontrols.ctl_grid();
            this.chk_type = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_search
            // 
            this.btn_search.Location = new System.Drawing.Point(366, 26);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(75, 23);
            this.btn_search.TabIndex = 2;
            this.btn_search.Text = "查 询";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // mydate
            // 
            this.mydate.CalendarFont = new System.Drawing.Font("宋体", 9F);
            this.mydate.Font = new System.Drawing.Font("宋体", 11F);
            this.mydate.Location = new System.Drawing.Point(128, 73);
            this.mydate.Name = "mydate";
            this.mydate.Size = new System.Drawing.Size(200, 24);
            this.mydate.TabIndex = 4;
            // 
            // btn_out
            // 
            this.btn_out.Location = new System.Drawing.Point(364, 73);
            this.btn_out.Name = "btn_out";
            this.btn_out.Size = new System.Drawing.Size(75, 23);
            this.btn_out.TabIndex = 5;
            this.btn_out.Text = "转 出";
            this.btn_out.UseVisualStyleBackColor = true;
            this.btn_out.Click += new System.EventHandler(this.btn_out_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_gjjy);
            this.groupBox1.Controls.Add(this.txt_xsjy);
            this.groupBox1.Controls.Add(this.txt_qt);
            this.groupBox1.Controls.Add(this.txt_az);
            this.groupBox1.Controls.Add(this.txt_ys);
            this.groupBox1.Controls.Add(this.txt_sj);
            this.groupBox1.Controls.Add(this.txt_zdh);
            this.groupBox1.Controls.Add(this.txt_ty);
            this.groupBox1.Controls.Add(this.btn_save);
            this.groupBox1.Controls.Add(this.btn_cancle);
            this.groupBox1.Controls.Add(this.txt_je);
            this.groupBox1.Controls.Add(this.txt_workno1);
            this.groupBox1.Location = new System.Drawing.Point(746, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(319, 552);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "操作";
            // 
            // txt_gjjy
            // 
            this.txt_gjjy.Location = new System.Drawing.Point(18, 435);
            this.txt_gjjy.Name = "txt_gjjy";
            this.txt_gjjy.Size = new System.Drawing.Size(295, 46);
            this.txt_gjjy.TabIndex = 18;
            // 
            // txt_xsjy
            // 
            this.txt_xsjy.Location = new System.Drawing.Point(18, 389);
            this.txt_xsjy.Name = "txt_xsjy";
            this.txt_xsjy.Size = new System.Drawing.Size(295, 46);
            this.txt_xsjy.TabIndex = 17;
            // 
            // txt_qt
            // 
            this.txt_qt.Location = new System.Drawing.Point(18, 346);
            this.txt_qt.Name = "txt_qt";
            this.txt_qt.Size = new System.Drawing.Size(295, 46);
            this.txt_qt.TabIndex = 16;
            // 
            // txt_az
            // 
            this.txt_az.Location = new System.Drawing.Point(18, 301);
            this.txt_az.Name = "txt_az";
            this.txt_az.Size = new System.Drawing.Size(295, 46);
            this.txt_az.TabIndex = 15;
            // 
            // txt_ys
            // 
            this.txt_ys.Location = new System.Drawing.Point(18, 255);
            this.txt_ys.Name = "txt_ys";
            this.txt_ys.Size = new System.Drawing.Size(295, 46);
            this.txt_ys.TabIndex = 14;
            // 
            // txt_sj
            // 
            this.txt_sj.Location = new System.Drawing.Point(18, 210);
            this.txt_sj.Name = "txt_sj";
            this.txt_sj.Size = new System.Drawing.Size(295, 46);
            this.txt_sj.TabIndex = 13;
            // 
            // txt_zdh
            // 
            this.txt_zdh.Location = new System.Drawing.Point(18, 158);
            this.txt_zdh.Name = "txt_zdh";
            this.txt_zdh.Size = new System.Drawing.Size(295, 46);
            this.txt_zdh.TabIndex = 12;
            // 
            // txt_ty
            // 
            this.txt_ty.Location = new System.Drawing.Point(18, 113);
            this.txt_ty.Name = "txt_ty";
            this.txt_ty.Size = new System.Drawing.Size(295, 46);
            this.txt_ty.TabIndex = 11;
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(107, 493);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 10;
            this.btn_save.Text = "保 存";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_cancle
            // 
            this.btn_cancle.Location = new System.Drawing.Point(204, 493);
            this.btn_cancle.Name = "btn_cancle";
            this.btn_cancle.Size = new System.Drawing.Size(75, 23);
            this.btn_cancle.TabIndex = 9;
            this.btn_cancle.Text = "取 消";
            this.btn_cancle.UseVisualStyleBackColor = true;
            this.btn_cancle.Click += new System.EventHandler(this.btn_cancle_Click);
            // 
            // txt_je
            // 
            this.txt_je.Location = new System.Drawing.Point(18, 67);
            this.txt_je.Name = "txt_je";
            this.txt_je.Size = new System.Drawing.Size(295, 46);
            this.txt_je.TabIndex = 8;
            // 
            // txt_workno1
            // 
            this.txt_workno1.Location = new System.Drawing.Point(18, 22);
            this.txt_workno1.Name = "txt_workno1";
            this.txt_workno1.Size = new System.Drawing.Size(295, 46);
            this.txt_workno1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 11F);
            this.label1.Location = new System.Drawing.Point(41, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "转出时间：";
            // 
            // btn_edit
            // 
            this.btn_edit.Location = new System.Drawing.Point(446, 73);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(75, 23);
            this.btn_edit.TabIndex = 9;
            this.btn_edit.Text = "修 改";
            this.btn_edit.UseVisualStyleBackColor = true;
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // btn_del
            // 
            this.btn_del.Location = new System.Drawing.Point(447, 26);
            this.btn_del.Name = "btn_del";
            this.btn_del.Size = new System.Drawing.Size(75, 23);
            this.btn_del.TabIndex = 10;
            this.btn_del.Text = "删 除";
            this.btn_del.UseVisualStyleBackColor = true;
            this.btn_del.Click += new System.EventHandler(this.btn_del_Click);
            // 
            // txt_workno
            // 
            this.txt_workno.Location = new System.Drawing.Point(40, 12);
            this.txt_workno.Name = "txt_workno";
            this.txt_workno.Size = new System.Drawing.Size(295, 46);
            this.txt_workno.TabIndex = 1;
            // 
            // grd
            // 
            this.grd.Location = new System.Drawing.Point(40, 131);
            this.grd.Name = "grd";
            this.grd.Size = new System.Drawing.Size(673, 473);
            this.grd.TabIndex = 0;
            this.grd.UserMouseClick += new 新财务管理.usercontrols.ctl_grid.mouse_keyclick(this.grd_UserMouseClick);
            this.grd.Click += new System.EventHandler(this.grd_Click);
            // 
            // chk_type
            // 
            this.chk_type.AutoSize = true;
            this.chk_type.Location = new System.Drawing.Point(582, 77);
            this.chk_type.Name = "chk_type";
            this.chk_type.Size = new System.Drawing.Size(72, 16);
            this.chk_type.TabIndex = 11;
            this.chk_type.Text = "精简显示";
            this.chk_type.UseVisualStyleBackColor = true;
            this.chk_type.CheckedChanged += new System.EventHandler(this.chk_type_CheckedChanged);
            // 
            // frm_成品库房转出
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 616);
            this.Controls.Add(this.chk_type);
            this.Controls.Add(this.mydate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_del);
            this.Controls.Add(this.btn_edit);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_out);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.txt_workno);
            this.Controls.Add(this.grd);
            this.Name = "frm_成品库房转出";
            this.Text = "frm_成品库房转出";
            this.Load += new System.EventHandler(this.frm_成品库房转出_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private 新财务管理.usercontrols.ctl_grid grd;
        private 外分厂生产管理.userctrl.ctrl_text txt_workno;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.DateTimePicker mydate;
        private System.Windows.Forms.Button btn_out;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_cancle;
        private 外分厂生产管理.userctrl.ctrl_text txt_je;
        private 外分厂生产管理.userctrl.ctrl_text txt_workno1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_edit;
        private System.Windows.Forms.Button btn_del;
        private 外分厂生产管理.userctrl.ctrl_text txt_gjjy;
        private 外分厂生产管理.userctrl.ctrl_text txt_xsjy;
        private 外分厂生产管理.userctrl.ctrl_text txt_qt;
        private 外分厂生产管理.userctrl.ctrl_text txt_az;
        private 外分厂生产管理.userctrl.ctrl_text txt_ys;
        private 外分厂生产管理.userctrl.ctrl_text txt_sj;
        private 外分厂生产管理.userctrl.ctrl_text txt_zdh;
        private 外分厂生产管理.userctrl.ctrl_text txt_ty;
        private System.Windows.Forms.CheckBox chk_type;
    }
}