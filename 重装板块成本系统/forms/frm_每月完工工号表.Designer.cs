namespace 重装板块成本系统.forms
{
    partial class frm_每月完工工号表
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
            this.radio_no_comp = new System.Windows.Forms.RadioButton();
            this.radio_complete = new System.Windows.Forms.RadioButton();
            this.radio_all = new System.Windows.Forms.RadioButton();
            this.mydate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.data_grid = new 新财务管理.usercontrols.ctl_grid();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radio_no_comp);
            this.groupBox1.Controls.Add(this.radio_complete);
            this.groupBox1.Controls.Add(this.radio_all);
            this.groupBox1.Location = new System.Drawing.Point(401, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(427, 56);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "范  围";
            // 
            // radio_no_comp
            // 
            this.radio_no_comp.AutoSize = true;
            this.radio_no_comp.Font = new System.Drawing.Font("宋体", 11F);
            this.radio_no_comp.Location = new System.Drawing.Point(308, 20);
            this.radio_no_comp.Name = "radio_no_comp";
            this.radio_no_comp.Size = new System.Drawing.Size(85, 19);
            this.radio_no_comp.TabIndex = 2;
            this.radio_no_comp.TabStop = true;
            this.radio_no_comp.Text = "未完工号";
            this.radio_no_comp.UseVisualStyleBackColor = true;
            // 
            // radio_complete
            // 
            this.radio_complete.AutoSize = true;
            this.radio_complete.Font = new System.Drawing.Font("宋体", 11F);
            this.radio_complete.Location = new System.Drawing.Point(174, 20);
            this.radio_complete.Name = "radio_complete";
            this.radio_complete.Size = new System.Drawing.Size(85, 19);
            this.radio_complete.TabIndex = 1;
            this.radio_complete.TabStop = true;
            this.radio_complete.Text = "完工工号";
            this.radio_complete.UseVisualStyleBackColor = true;
            // 
            // radio_all
            // 
            this.radio_all.AutoSize = true;
            this.radio_all.Font = new System.Drawing.Font("宋体", 11F);
            this.radio_all.Location = new System.Drawing.Point(36, 19);
            this.radio_all.Name = "radio_all";
            this.radio_all.Size = new System.Drawing.Size(85, 19);
            this.radio_all.TabIndex = 0;
            this.radio_all.TabStop = true;
            this.radio_all.Text = "所有工号";
            this.radio_all.UseVisualStyleBackColor = true;
            // 
            // mydate
            // 
            this.mydate.Font = new System.Drawing.Font("宋体", 11F);
            this.mydate.Location = new System.Drawing.Point(97, 26);
            this.mydate.Name = "mydate";
            this.mydate.Size = new System.Drawing.Size(200, 24);
            this.mydate.TabIndex = 7;
            this.mydate.ValueChanged += new System.EventHandler(this.mydate_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 11F);
            this.label1.Location = new System.Drawing.Point(39, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "月份：";
            // 
            // data_grid
            // 
            this.data_grid.Location = new System.Drawing.Point(42, 99);
            this.data_grid.Name = "data_grid";
            this.data_grid.Size = new System.Drawing.Size(786, 336);
            this.data_grid.TabIndex = 9;
            this.data_grid.UserMouseClick += new 新财务管理.usercontrols.ctl_grid.mouse_keyclick(this.data_grid_UserMouseClick);
            this.data_grid.Load += new System.EventHandler(this.ctl_grid1_Load);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(334, 466);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "保 存";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(446, 466);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "取 消";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // frm_每月完工工号表
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 554);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.data_grid);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.mydate);
            this.Controls.Add(this.label1);
            this.Name = "frm_每月完工工号表";
            this.Text = "frm_每月完工工号表";
            this.Load += new System.EventHandler(this.frm_每月完工工号表_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radio_no_comp;
        private System.Windows.Forms.RadioButton radio_complete;
        private System.Windows.Forms.RadioButton radio_all;
        private System.Windows.Forms.DateTimePicker mydate;
        private System.Windows.Forms.Label label1;
        private 新财务管理.usercontrols.ctl_grid data_grid;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}