namespace 重装板块成本系统.forms
{
    partial class frm_明细查询
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
            this.btn_xq = new System.Windows.Forms.Button();
            this.btn_search = new System.Windows.Forms.Button();
            this.txt_gonghao = new 外分厂生产管理.userctrl.ctrl_text();
            this.grd_data = new 新财务管理.usercontrols.ctl_grid();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 11F);
            this.button1.Location = new System.Drawing.Point(847, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "导  出";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btn_xq
            // 
            this.btn_xq.Font = new System.Drawing.Font("宋体", 11F);
            this.btn_xq.Location = new System.Drawing.Point(490, 16);
            this.btn_xq.Name = "btn_xq";
            this.btn_xq.Size = new System.Drawing.Size(105, 23);
            this.btn_xq.TabIndex = 8;
            this.btn_xq.Text = "原材料详情";
            this.btn_xq.UseVisualStyleBackColor = true;
            this.btn_xq.Click += new System.EventHandler(this.btn_xq_Click);
            // 
            // btn_search
            // 
            this.btn_search.Font = new System.Drawing.Font("宋体", 11F);
            this.btn_search.Location = new System.Drawing.Point(395, 16);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(75, 23);
            this.btn_search.TabIndex = 7;
            this.btn_search.Text = "查  询";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // txt_gonghao
            // 
            this.txt_gonghao.Location = new System.Drawing.Point(28, 5);
            this.txt_gonghao.Name = "txt_gonghao";
            this.txt_gonghao.Size = new System.Drawing.Size(295, 46);
            this.txt_gonghao.TabIndex = 6;
            // 
            // grd_data
            // 
            this.grd_data.Location = new System.Drawing.Point(28, 57);
            this.grd_data.Name = "grd_data";
            this.grd_data.Size = new System.Drawing.Size(1072, 496);
            this.grd_data.TabIndex = 5;
            // 
            // frm_明细查询
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 565);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_xq);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.txt_gonghao);
            this.Controls.Add(this.grd_data);
            this.Name = "frm_明细查询";
            this.Text = "frm_明细查询";
            this.Load += new System.EventHandler(this.frm_明细查询_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_xq;
        private System.Windows.Forms.Button btn_search;
        private 外分厂生产管理.userctrl.ctrl_text txt_gonghao;
        private 新财务管理.usercontrols.ctl_grid grd_data;
    }
}