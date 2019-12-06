namespace 重装板块成本系统.forms
{
    partial class frm_工号工具
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
            this.txt_filename = new 外分厂生产管理.userctrl.ctrl_text();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btn_operation = new System.Windows.Forms.Button();
            this.btn_search = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_cp = new System.Windows.Forms.ComboBox();
            this.cmb_dept = new System.Windows.Forms.ComboBox();
            this.cmb_hy = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txt_filename
            // 
            this.txt_filename.Location = new System.Drawing.Point(32, 65);
            this.txt_filename.Name = "txt_filename";
            this.txt_filename.Size = new System.Drawing.Size(295, 46);
            this.txt_filename.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btn_operation
            // 
            this.btn_operation.Location = new System.Drawing.Point(476, 77);
            this.btn_operation.Name = "btn_operation";
            this.btn_operation.Size = new System.Drawing.Size(139, 34);
            this.btn_operation.TabIndex = 2;
            this.btn_operation.Text = "button2";
            this.btn_operation.UseVisualStyleBackColor = true;
            this.btn_operation.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_search
            // 
            this.btn_search.Location = new System.Drawing.Point(334, 84);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(33, 23);
            this.btn_search.TabIndex = 3;
            this.btn_search.Text = "...";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14F);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(260, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // cmb_cp
            // 
            this.cmb_cp.FormattingEnabled = true;
            this.cmb_cp.Location = new System.Drawing.Point(667, 65);
            this.cmb_cp.Name = "cmb_cp";
            this.cmb_cp.Size = new System.Drawing.Size(121, 20);
            this.cmb_cp.TabIndex = 5;
            this.cmb_cp.Visible = false;
            // 
            // cmb_dept
            // 
            this.cmb_dept.FormattingEnabled = true;
            this.cmb_dept.Location = new System.Drawing.Point(667, 152);
            this.cmb_dept.Name = "cmb_dept";
            this.cmb_dept.Size = new System.Drawing.Size(121, 20);
            this.cmb_dept.TabIndex = 6;
            this.cmb_dept.Visible = false;
            // 
            // cmb_hy
            // 
            this.cmb_hy.FormattingEnabled = true;
            this.cmb_hy.Location = new System.Drawing.Point(667, 105);
            this.cmb_hy.Name = "cmb_hy";
            this.cmb_hy.Size = new System.Drawing.Size(121, 20);
            this.cmb_hy.TabIndex = 7;
            this.cmb_hy.Visible = false;
            // 
            // frm_工号工具
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cmb_hy);
            this.Controls.Add(this.cmb_dept);
            this.Controls.Add(this.cmb_cp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.btn_operation);
            this.Controls.Add(this.txt_filename);
            this.Name = "frm_工号工具";
            this.Text = "frm_工号工具";
            this.Load += new System.EventHandler(this.frm_工号工具_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private 外分厂生产管理.userctrl.ctrl_text txt_filename;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btn_operation;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_cp;
        private System.Windows.Forms.ComboBox cmb_dept;
        private System.Windows.Forms.ComboBox cmb_hy;
    }
}