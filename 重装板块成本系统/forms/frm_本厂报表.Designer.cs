﻿namespace 重装板块成本系统.forms
{
    partial class frm_本厂报表
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
            this.button1 = new System.Windows.Forms.Button();
            this.mydate = new System.Windows.Forms.DateTimePicker();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(114, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 11F);
            this.button1.Location = new System.Drawing.Point(358, 72);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "本厂报表";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // mydate
            // 
            this.mydate.Font = new System.Drawing.Font("宋体", 11F);
            this.mydate.Location = new System.Drawing.Point(105, 72);
            this.mydate.Name = "mydate";
            this.mydate.Size = new System.Drawing.Size(200, 24);
            this.mydate.TabIndex = 3;
            // 
            // frm_本厂报表
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 208);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.mydate);
            this.Controls.Add(this.label1);
            this.Name = "frm_本厂报表";
            this.Text = "frm_本厂报表";
            this.Load += new System.EventHandler(this.frm_本厂报表_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker mydate;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}