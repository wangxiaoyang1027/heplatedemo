namespace 重装板块成本系统.forms
{
    partial class frm_成品库房查询
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
            this.txt_workno = new 外分厂生产管理.userctrl.ctrl_text();
            this.btn_search = new System.Windows.Forms.Button();
            this.grd = new 新财务管理.usercontrols.ctl_grid();
            this.SuspendLayout();
            // 
            // txt_workno
            // 
            this.txt_workno.Location = new System.Drawing.Point(68, 3);
            this.txt_workno.Name = "txt_workno";
            this.txt_workno.Size = new System.Drawing.Size(295, 46);
            this.txt_workno.TabIndex = 0;
            // 
            // btn_search
            // 
            this.btn_search.Location = new System.Drawing.Point(418, 12);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(75, 23);
            this.btn_search.TabIndex = 1;
            this.btn_search.Text = "查 询";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // grd
            // 
            this.grd.Location = new System.Drawing.Point(68, 73);
            this.grd.Name = "grd";
            this.grd.Size = new System.Drawing.Size(471, 292);
            this.grd.TabIndex = 2;
            // 
            // frm_成品库房查询
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 461);
            this.Controls.Add(this.grd);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.txt_workno);
            this.Name = "frm_成品库房查询";
            this.Text = "frm_成品库房查询";
            this.Load += new System.EventHandler(this.frm_成品库房查询_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private 外分厂生产管理.userctrl.ctrl_text txt_workno;
        private System.Windows.Forms.Button btn_search;
        private 新财务管理.usercontrols.ctl_grid grd;
    }
}