namespace 重装板块成本系统.forms
{
    partial class frm_worknoMaintain
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
            this.cmb_worknotype = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmb_dhdw = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_ghdw = new 外分厂生产管理.userctrl.ctrl_text();
            this.cmb_cplb = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmb_hylb = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_hth = new 外分厂生产管理.userctrl.ctrl_text();
            this.chk_calc = new System.Windows.Forms.CheckBox();
            this.txt_workno = new 外分厂生产管理.userctrl.ctrl_text();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.txt_name = new 外分厂生产管理.userctrl.ctrl_text();
            this.btn_cancle = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btn_search = new System.Windows.Forms.Button();
            this.txt_search = new 外分厂生产管理.userctrl.ctrl_text();
            this.grd = new 新财务管理.usercontrols.ctl_grid();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmb_worknotype);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cmb_dhdw);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txt_ghdw);
            this.groupBox1.Controls.Add(this.cmb_cplb);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmb_hylb);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_hth);
            this.groupBox1.Controls.Add(this.chk_calc);
            this.groupBox1.Controls.Add(this.txt_workno);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.txt_name);
            this.groupBox1.Controls.Add(this.btn_cancle);
            this.groupBox1.Controls.Add(this.btn_save);
            this.groupBox1.Location = new System.Drawing.Point(30, 353);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(968, 306);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // cmb_worknotype
            // 
            this.cmb_worknotype.Font = new System.Drawing.Font("宋体", 11F);
            this.cmb_worknotype.FormattingEnabled = true;
            this.cmb_worknotype.Location = new System.Drawing.Point(680, 177);
            this.cmb_worknotype.Name = "cmb_worknotype";
            this.cmb_worknotype.Size = new System.Drawing.Size(137, 23);
            this.cmb_worknotype.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 11F);
            this.label5.Location = new System.Drawing.Point(607, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 15);
            this.label5.TabIndex = 20;
            this.label5.Text = "工号类型：";
            // 
            // cmb_dhdw
            // 
            this.cmb_dhdw.Font = new System.Drawing.Font("宋体", 11F);
            this.cmb_dhdw.FormattingEnabled = true;
            this.cmb_dhdw.Location = new System.Drawing.Point(680, 132);
            this.cmb_dhdw.Name = "cmb_dhdw";
            this.cmb_dhdw.Size = new System.Drawing.Size(137, 23);
            this.cmb_dhdw.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 11F);
            this.label4.Location = new System.Drawing.Point(607, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 18;
            this.label4.Text = "订货单位";
            // 
            // txt_ghdw
            // 
            this.txt_ghdw.Location = new System.Drawing.Point(6, 167);
            this.txt_ghdw.Name = "txt_ghdw";
            this.txt_ghdw.Size = new System.Drawing.Size(295, 46);
            this.txt_ghdw.TabIndex = 6;
            // 
            // cmb_cplb
            // 
            this.cmb_cplb.Font = new System.Drawing.Font("宋体", 11F);
            this.cmb_cplb.FormattingEnabled = true;
            this.cmb_cplb.Location = new System.Drawing.Point(680, 88);
            this.cmb_cplb.Name = "cmb_cplb";
            this.cmb_cplb.Size = new System.Drawing.Size(137, 23);
            this.cmb_cplb.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 11F);
            this.label3.Location = new System.Drawing.Point(600, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 16;
            this.label3.Text = "产品类别";
            // 
            // cmb_hylb
            // 
            this.cmb_hylb.Font = new System.Drawing.Font("宋体", 11F);
            this.cmb_hylb.FormattingEnabled = true;
            this.cmb_hylb.Location = new System.Drawing.Point(96, 86);
            this.cmb_hylb.Name = "cmb_hylb";
            this.cmb_hylb.Size = new System.Drawing.Size(137, 23);
            this.cmb_hylb.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 11F);
            this.label2.Location = new System.Drawing.Point(23, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 14;
            this.label2.Text = "行业类别";
            // 
            // txt_hth
            // 
            this.txt_hth.Location = new System.Drawing.Point(6, 115);
            this.txt_hth.Name = "txt_hth";
            this.txt_hth.Size = new System.Drawing.Size(295, 46);
            this.txt_hth.TabIndex = 4;
            // 
            // chk_calc
            // 
            this.chk_calc.AutoSize = true;
            this.chk_calc.Location = new System.Drawing.Point(650, 217);
            this.chk_calc.Name = "chk_calc";
            this.chk_calc.Size = new System.Drawing.Size(84, 16);
            this.chk_calc.TabIndex = 11;
            this.chk_calc.Text = "非计算工号";
            this.chk_calc.UseVisualStyleBackColor = true;
            // 
            // txt_workno
            // 
            this.txt_workno.Location = new System.Drawing.Point(13, 20);
            this.txt_workno.Name = "txt_workno";
            this.txt_workno.Size = new System.Drawing.Size(295, 46);
            this.txt_workno.TabIndex = 0;
            this.txt_workno.Load += new System.EventHandler(this.txt_workno_Load);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 11F);
            this.label1.Location = new System.Drawing.Point(225, 230);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "状态：";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("宋体", 11F);
            this.radioButton2.Location = new System.Drawing.Point(377, 226);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(55, 19);
            this.radioButton2.TabIndex = 8;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "禁用";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("宋体", 11F);
            this.radioButton1.Location = new System.Drawing.Point(299, 226);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(55, 19);
            this.radioButton1.TabIndex = 7;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "启用";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // txt_name
            // 
            this.txt_name.Location = new System.Drawing.Point(590, 23);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(295, 46);
            this.txt_name.TabIndex = 1;
            this.txt_name.Load += new System.EventHandler(this.txt_name_Load);
            // 
            // btn_cancle
            // 
            this.btn_cancle.Location = new System.Drawing.Point(515, 262);
            this.btn_cancle.Name = "btn_cancle";
            this.btn_cancle.Size = new System.Drawing.Size(75, 23);
            this.btn_cancle.TabIndex = 9;
            this.btn_cancle.Text = "取消";
            this.btn_cancle.UseVisualStyleBackColor = true;
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(404, 262);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 8;
            this.btn_save.Text = "保存";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(434, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(545, 22);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(655, 22);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // btn_search
            // 
            this.btn_search.Location = new System.Drawing.Point(322, 22);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(75, 23);
            this.btn_search.TabIndex = 6;
            this.btn_search.Text = "查找";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // txt_search
            // 
            this.txt_search.Location = new System.Drawing.Point(21, 3);
            this.txt_search.Name = "txt_search";
            this.txt_search.Size = new System.Drawing.Size(295, 46);
            this.txt_search.TabIndex = 5;
            // 
            // grd
            // 
            this.grd.Location = new System.Drawing.Point(30, 65);
            this.grd.Name = "grd";
            this.grd.Size = new System.Drawing.Size(968, 280);
            this.grd.TabIndex = 0;
            // 
            // frm_worknoMaintain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1054, 665);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txt_search);
            this.Controls.Add(this.grd);
            this.Name = "frm_worknoMaintain";
            this.Text = "frm_worknoMaintain";
            this.Load += new System.EventHandler(this.frm_worknoMaintain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private 新财务管理.usercontrols.ctl_grid grd;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn_cancle;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button button3;
        private 外分厂生产管理.userctrl.ctrl_text txt_search;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private 外分厂生产管理.userctrl.ctrl_text txt_name;
        private 外分厂生产管理.userctrl.ctrl_text txt_workno;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chk_calc;
        private 外分厂生产管理.userctrl.ctrl_text txt_hth;
        private 外分厂生产管理.userctrl.ctrl_text txt_ghdw;
        private System.Windows.Forms.ComboBox cmb_cplb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_hylb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_dhdw;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmb_worknotype;
        private System.Windows.Forms.Label label5;
    }
}