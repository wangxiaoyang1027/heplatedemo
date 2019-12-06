namespace 重装板块成本系统.forms
{
    partial class frm其它部门费用
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
            this.label1 = new System.Windows.Forms.Label();
            this.mydate = new System.Windows.Forms.DateTimePicker();
            this.cmb_dept = new System.Windows.Forms.ComboBox();
            this.grid_data = new 新财务管理.usercontrols.ctl_grid();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 11F);
            this.label1.Location = new System.Drawing.Point(94, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "时间：";
            // 
            // mydate
            // 
            this.mydate.Font = new System.Drawing.Font("宋体", 11F);
            this.mydate.Location = new System.Drawing.Point(175, 10);
            this.mydate.Name = "mydate";
            this.mydate.Size = new System.Drawing.Size(200, 24);
            this.mydate.TabIndex = 1;
            // 
            // cmb_dept
            // 
            this.cmb_dept.Font = new System.Drawing.Font("宋体", 11F);
            this.cmb_dept.FormattingEnabled = true;
            this.cmb_dept.Location = new System.Drawing.Point(533, 8);
            this.cmb_dept.Name = "cmb_dept";
            this.cmb_dept.Size = new System.Drawing.Size(121, 23);
            this.cmb_dept.TabIndex = 2;
            // 
            // grid_data
            // 
            this.grid_data.Location = new System.Drawing.Point(97, 65);
            this.grid_data.Name = "grid_data";
            this.grid_data.Size = new System.Drawing.Size(557, 417);
            this.grid_data.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 11F);
            this.label3.Location = new System.Drawing.Point(475, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "单位：";
            // 
            // frm其它部门费用
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(757, 541);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.grid_data);
            this.Controls.Add(this.cmb_dept);
            this.Controls.Add(this.mydate);
            this.Controls.Add(this.label1);
            this.Name = "frm其它部门费用";
            this.Text = "frm其它部门费用";
            this.Load += new System.EventHandler(this.frm其它部门费用_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker mydate;
        private System.Windows.Forms.ComboBox cmb_dept;
        private 新财务管理.usercontrols.ctl_grid grid_data;
        private System.Windows.Forms.Label label3;
    }
}