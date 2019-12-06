namespace 重装板块成本系统.forms
{
    partial class frm_工时工号修改
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
            this.txt_new = new 外分厂生产管理.userctrl.ctrl_text();
            this.button1 = new System.Windows.Forms.Button();
            this.Msg = new System.Windows.Forms.Label();
            this.input_date = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // txt_old
            // 
            this.txt_old.Location = new System.Drawing.Point(82, 51);
            this.txt_old.Name = "txt_old";
            this.txt_old.Size = new System.Drawing.Size(295, 46);
            this.txt_old.TabIndex = 0;
            // 
            // txt_new
            // 
            this.txt_new.Location = new System.Drawing.Point(82, 103);
            this.txt_new.Name = "txt_new";
            this.txt_new.Size = new System.Drawing.Size(295, 46);
            this.txt_new.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(173, 171);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "更 改";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Msg
            // 
            this.Msg.AutoSize = true;
            this.Msg.Location = new System.Drawing.Point(97, 214);
            this.Msg.Name = "Msg";
            this.Msg.Size = new System.Drawing.Size(0, 12);
            this.Msg.TabIndex = 3;
            // 
            // input_date
            // 
            this.input_date.Font = new System.Drawing.Font("宋体", 11F);
            this.input_date.Location = new System.Drawing.Point(99, 24);
            this.input_date.Name = "input_date";
            this.input_date.Size = new System.Drawing.Size(200, 24);
            this.input_date.TabIndex = 4;
            // 
            // frm_工时工号修改
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 280);
            this.Controls.Add(this.input_date);
            this.Controls.Add(this.Msg);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txt_new);
            this.Controls.Add(this.txt_old);
            this.Name = "frm_工时工号修改";
            this.Text = "frm_工时工号修改";
            this.Load += new System.EventHandler(this.frm_工时工号修改_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private 外分厂生产管理.userctrl.ctrl_text txt_old;
        private 外分厂生产管理.userctrl.ctrl_text txt_new;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label Msg;
        private System.Windows.Forms.DateTimePicker input_date;
    }
}