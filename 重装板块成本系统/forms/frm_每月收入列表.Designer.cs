namespace 重装板块成本系统.forms
{
    partial class frm_每月收入列表
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
            this.mydate = new System.Windows.Forms.DateTimePicker();
            this.btn_search = new System.Windows.Forms.Button();
            this.data_grd = new 新财务管理.usercontrols.ctl_grid();
            this.SuspendLayout();
            // 
            // mydate
            // 
            this.mydate.Font = new System.Drawing.Font("宋体", 12F);
            this.mydate.Location = new System.Drawing.Point(78, 12);
            this.mydate.Name = "mydate";
            this.mydate.Size = new System.Drawing.Size(200, 26);
            this.mydate.TabIndex = 1;
            // 
            // btn_search
            // 
            this.btn_search.Location = new System.Drawing.Point(307, 14);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(75, 23);
            this.btn_search.TabIndex = 2;
            this.btn_search.Text = "查 询";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // data_grd
            // 
            this.data_grd.Location = new System.Drawing.Point(40, 61);
            this.data_grd.Name = "data_grd";
            this.data_grd.Size = new System.Drawing.Size(814, 347);
            this.data_grd.TabIndex = 0;
            // 
            // frm_每月收入列表
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(951, 450);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.mydate);
            this.Controls.Add(this.data_grd);
            this.Name = "frm_每月收入列表";
            this.Text = "frm_每月收入列表";
            this.Load += new System.EventHandler(this.frm_每月收入列表_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private 新财务管理.usercontrols.ctl_grid data_grd;
        private System.Windows.Forms.DateTimePicker mydate;
        private System.Windows.Forms.Button btn_search;
    }
}