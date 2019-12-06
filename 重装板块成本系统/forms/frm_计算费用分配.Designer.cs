namespace 重装板块成本系统.forms
{
    partial class frm_计算费用分配
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
            this.grd_data = new 新财务管理.usercontrols.ctl_grid();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.mydate = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // grd_data
            // 
            this.grd_data.Location = new System.Drawing.Point(73, 78);
            this.grd_data.Name = "grd_data";
            this.grd_data.Size = new System.Drawing.Size(736, 469);
            this.grd_data.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 12F);
            this.button1.Location = new System.Drawing.Point(403, 34);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "计 算";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F);
            this.label1.Location = new System.Drawing.Point(70, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "请输入月份：";
            // 
            // mydate
            // 
            this.mydate.Font = new System.Drawing.Font("宋体", 12F);
            this.mydate.Location = new System.Drawing.Point(180, 31);
            this.mydate.Name = "mydate";
            this.mydate.Size = new System.Drawing.Size(159, 26);
            this.mydate.TabIndex = 7;
            this.mydate.ValueChanged += new System.EventHandler(this.mydate_ValueChanged);
            // 
            // frm_计算费用分配
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 630);
            this.Controls.Add(this.grd_data);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mydate);
            this.Name = "frm_计算费用分配";
            this.Text = "frm_计算费用分配";
            this.Load += new System.EventHandler(this.frm_计算费用分配_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private 新财务管理.usercontrols.ctl_grid grd_data;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker mydate;
    }
}