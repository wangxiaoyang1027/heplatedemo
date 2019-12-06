namespace 重装板块成本系统.forms
{
    partial class frm_原材料明细
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
            this.SuspendLayout();
            // 
            // grd_data
            // 
            this.grd_data.Location = new System.Drawing.Point(12, 12);
            this.grd_data.Name = "grd_data";
            this.grd_data.Size = new System.Drawing.Size(1126, 537);
            this.grd_data.TabIndex = 0;
            // 
            // frm_原材料明细
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1150, 561);
            this.Controls.Add(this.grd_data);
            this.Name = "frm_原材料明细";
            this.Text = "frm_原材料明细";
            this.Load += new System.EventHandler(this.frm_原材料明细_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private 新财务管理.usercontrols.ctl_grid grd_data;
    }
}