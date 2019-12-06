namespace 重装板块成本系统.forms
{
    partial class frm_每月完工转出
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
            this.btn_dele = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btn_edit = new System.Windows.Forms.Button();
            this.btn_gonghao = new System.Windows.Forms.Button();
            this.btn_out = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.mydate = new System.Windows.Forms.DateTimePicker();
            this.txt_gonghao = new 外分厂生产管理.userctrl.ctrl_text();
            this.grd_data = new 新财务管理.usercontrols.ctl_grid();
            this.SuspendLayout();
            // 
            // btn_dele
            // 
            this.btn_dele.BackColor = System.Drawing.Color.Red;
            this.btn_dele.Font = new System.Drawing.Font("宋体", 12F);
            this.btn_dele.Location = new System.Drawing.Point(1037, 17);
            this.btn_dele.Name = "btn_dele";
            this.btn_dele.Size = new System.Drawing.Size(77, 26);
            this.btn_dele.TabIndex = 19;
            this.btn_dele.Text = "删 除";
            this.btn_dele.UseVisualStyleBackColor = false;
            this.btn_dele.Click += new System.EventHandler(this.btn_dele_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("宋体", 11F);
            this.checkBox1.Location = new System.Drawing.Point(398, 17);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(161, 19);
            this.checkBox1.TabIndex = 18;
            this.checkBox1.Text = "按当月完工工号转出";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // btn_edit
            // 
            this.btn_edit.Font = new System.Drawing.Font("宋体", 12F);
            this.btn_edit.Location = new System.Drawing.Point(916, 18);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(77, 26);
            this.btn_edit.TabIndex = 17;
            this.btn_edit.Text = "修  改";
            this.btn_edit.UseVisualStyleBackColor = true;
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // btn_gonghao
            // 
            this.btn_gonghao.Font = new System.Drawing.Font("宋体", 12F);
            this.btn_gonghao.Location = new System.Drawing.Point(808, 19);
            this.btn_gonghao.Name = "btn_gonghao";
            this.btn_gonghao.Size = new System.Drawing.Size(89, 24);
            this.btn_gonghao.TabIndex = 16;
            this.btn_gonghao.Text = "查找工号";
            this.btn_gonghao.UseVisualStyleBackColor = true;
            this.btn_gonghao.Click += new System.EventHandler(this.btn_gonghao_Click);
            // 
            // btn_out
            // 
            this.btn_out.Font = new System.Drawing.Font("宋体", 12F);
            this.btn_out.Location = new System.Drawing.Point(299, 12);
            this.btn_out.Name = "btn_out";
            this.btn_out.Size = new System.Drawing.Size(66, 26);
            this.btn_out.TabIndex = 14;
            this.btn_out.Text = "转  出";
            this.btn_out.UseVisualStyleBackColor = true;
            this.btn_out.Click += new System.EventHandler(this.btn_out_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 12F);
            this.button1.Location = new System.Drawing.Point(212, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(68, 26);
            this.button1.TabIndex = 13;
            this.button1.Text = "查 询";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F);
            this.label1.Location = new System.Drawing.Point(-41, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "月份：";
            // 
            // mydate
            // 
            this.mydate.Font = new System.Drawing.Font("宋体", 12F);
            this.mydate.Location = new System.Drawing.Point(35, 10);
            this.mydate.Name = "mydate";
            this.mydate.Size = new System.Drawing.Size(152, 26);
            this.mydate.TabIndex = 10;
            // 
            // txt_gonghao
            // 
            this.txt_gonghao.Location = new System.Drawing.Point(577, 1);
            this.txt_gonghao.Name = "txt_gonghao";
            this.txt_gonghao.Size = new System.Drawing.Size(211, 46);
            this.txt_gonghao.TabIndex = 15;
            // 
            // grd_data
            // 
            this.grd_data.Location = new System.Drawing.Point(12, 53);
            this.grd_data.Name = "grd_data";
            this.grd_data.Size = new System.Drawing.Size(1102, 564);
            this.grd_data.TabIndex = 12;
            // 
            // frm_每月完工转出
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1131, 645);
            this.Controls.Add(this.btn_dele);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.btn_edit);
            this.Controls.Add(this.btn_gonghao);
            this.Controls.Add(this.txt_gonghao);
            this.Controls.Add(this.btn_out);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.grd_data);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mydate);
            this.Name = "frm_每月完工转出";
            this.Text = "frm_每月完工转出";
            this.Load += new System.EventHandler(this.frm_每月完工转出_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_dele;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btn_edit;
        private System.Windows.Forms.Button btn_gonghao;
        private 外分厂生产管理.userctrl.ctrl_text txt_gonghao;
        private System.Windows.Forms.Button btn_out;
        private System.Windows.Forms.Button button1;
        private 新财务管理.usercontrols.ctl_grid grd_data;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker mydate;
    }
}