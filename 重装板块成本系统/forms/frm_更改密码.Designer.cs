namespace 重装板块成本系统.forms
{
    partial class frm_更改密码
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
            this.txt_old = new 外分厂生产管理.userctrl.ctrl_text();
            this.txt_new1 = new 外分厂生产管理.userctrl.ctrl_text();
            this.txt_new2 = new 外分厂生产管理.userctrl.ctrl_text();
            this.btn_change = new System.Windows.Forms.Button();
            this.btn_cancle = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_old
            // 
            this.txt_old.Location = new System.Drawing.Point(55, -3);
            this.txt_old.Name = "txt_old";
            this.txt_old.Size = new System.Drawing.Size(295, 46);
            this.txt_old.TabIndex = 0;
            // 
            // txt_new1
            // 
            this.txt_new1.Location = new System.Drawing.Point(55, 45);
            this.txt_new1.Name = "txt_new1";
            this.txt_new1.Size = new System.Drawing.Size(295, 46);
            this.txt_new1.TabIndex = 1;
            // 
            // txt_new2
            // 
            this.txt_new2.Location = new System.Drawing.Point(55, 97);
            this.txt_new2.Name = "txt_new2";
            this.txt_new2.Size = new System.Drawing.Size(295, 46);
            this.txt_new2.TabIndex = 2;
            // 
            // btn_change
            // 
            this.btn_change.Location = new System.Drawing.Point(79, 182);
            this.btn_change.Name = "btn_change";
            this.btn_change.Size = new System.Drawing.Size(75, 23);
            this.btn_change.TabIndex = 3;
            this.btn_change.Text = "更 改";
            this.btn_change.UseVisualStyleBackColor = true;
            this.btn_change.Click += new System.EventHandler(this.btn_change_Click);
            // 
            // btn_cancle
            // 
            this.btn_cancle.Location = new System.Drawing.Point(275, 182);
            this.btn_cancle.Name = "btn_cancle";
            this.btn_cancle.Size = new System.Drawing.Size(75, 23);
            this.btn_cancle.TabIndex = 4;
            this.btn_cancle.Text = "取 消";
            this.btn_cancle.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(102, 217);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 16);
            this.label1.TabIndex = 5;
            // 
            // frm_更改密码
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(423, 253);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_cancle);
            this.Controls.Add(this.btn_change);
            this.Controls.Add(this.txt_new2);
            this.Controls.Add(this.txt_new1);
            this.Controls.Add(this.txt_old);
            this.Name = "frm_更改密码";
            this.Text = "frm_更改密码";
            this.Load += new System.EventHandler(this.frm_更改密码_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private 外分厂生产管理.userctrl.ctrl_text txt_old;
        private 外分厂生产管理.userctrl.ctrl_text txt_new1;
        private 外分厂生产管理.userctrl.ctrl_text txt_new2;
        private System.Windows.Forms.Button btn_change;
        private System.Windows.Forms.Button btn_cancle;
        private System.Windows.Forms.Label label1;
    }
}