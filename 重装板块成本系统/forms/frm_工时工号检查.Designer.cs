namespace 重装板块成本系统.forms
{
    partial class frm_工时工号检查
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
            this.button1 = new System.Windows.Forms.Button();
            this.msg = new System.Windows.Forms.Label();
            this.grd_date = new 新财务管理.usercontrols.ctl_grid();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 11F);
            this.button1.Location = new System.Drawing.Point(344, 478);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "退 出";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // msg
            // 
            this.msg.AutoSize = true;
            this.msg.Font = new System.Drawing.Font("宋体", 16F);
            this.msg.ForeColor = System.Drawing.Color.Red;
            this.msg.Location = new System.Drawing.Point(9, 14);
            this.msg.Name = "msg";
            this.msg.Size = new System.Drawing.Size(428, 22);
            this.msg.TabIndex = 4;
            this.msg.Text = "这些工号有误，或者在工号主表中不存在！";
            // 
            // grd_date
            // 
            this.grd_date.Location = new System.Drawing.Point(27, 59);
            this.grd_date.Name = "grd_date";
            this.grd_date.Size = new System.Drawing.Size(392, 363);
            this.grd_date.TabIndex = 3;
            // 
            // frm_工时工号检查
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(447, 515);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.msg);
            this.Controls.Add(this.grd_date);
            this.Name = "frm_工时工号检查";
            this.Text = "frm_工时工号检查";
            this.Load += new System.EventHandler(this.frm_工时工号检查_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label msg;
        private 新财务管理.usercontrols.ctl_grid grd_date;
    }
}