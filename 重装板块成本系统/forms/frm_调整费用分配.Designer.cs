namespace 重装板块成本系统.forms
{
    partial class frm_调整费用分配
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
            this.cmb_gonghao = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_search = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.txt_zzfy = new 外分厂生产管理.userctrl.ctrl_text();
            this.txt_gz = new 外分厂生产管理.userctrl.ctrl_text();
            this.txt_rldl = new 外分厂生产管理.userctrl.ctrl_text();
            this.grd_data = new 新财务管理.usercontrols.ctl_grid();
            this.label1 = new System.Windows.Forms.Label();
            this.mydate = new System.Windows.Forms.DateTimePicker();
            this.btn_dele = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmb_gonghao
            // 
            this.cmb_gonghao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_gonghao.Font = new System.Drawing.Font("宋体", 12F);
            this.cmb_gonghao.FormattingEnabled = true;
            this.cmb_gonghao.Location = new System.Drawing.Point(137, 379);
            this.cmb_gonghao.Name = "cmb_gonghao";
            this.cmb_gonghao.Size = new System.Drawing.Size(197, 24);
            this.cmb_gonghao.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F);
            this.label2.Location = new System.Drawing.Point(75, 382);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 23;
            this.label2.Text = "工号：";
            // 
            // btn_search
            // 
            this.btn_search.Font = new System.Drawing.Font("宋体", 12F);
            this.btn_search.Location = new System.Drawing.Point(279, 31);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(75, 24);
            this.btn_search.TabIndex = 22;
            this.btn_search.Text = "查 询";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Visible = false;
            // 
            // btn_exit
            // 
            this.btn_exit.Font = new System.Drawing.Font("宋体", 12F);
            this.btn_exit.Location = new System.Drawing.Point(540, 493);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(75, 34);
            this.btn_exit.TabIndex = 21;
            this.btn_exit.Text = "退 出";
            this.btn_exit.UseVisualStyleBackColor = true;
            // 
            // btn_save
            // 
            this.btn_save.Font = new System.Drawing.Font("宋体", 12F);
            this.btn_save.Location = new System.Drawing.Point(319, 493);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 34);
            this.btn_save.TabIndex = 20;
            this.btn_save.Text = "保 存";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_add
            // 
            this.btn_add.Font = new System.Drawing.Font("宋体", 12F);
            this.btn_add.Location = new System.Drawing.Point(439, 29);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(75, 26);
            this.btn_add.TabIndex = 19;
            this.btn_add.Text = "增 加";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // txt_zzfy
            // 
            this.txt_zzfy.Location = new System.Drawing.Point(368, 409);
            this.txt_zzfy.Name = "txt_zzfy";
            this.txt_zzfy.Size = new System.Drawing.Size(295, 46);
            this.txt_zzfy.TabIndex = 18;
            // 
            // txt_gz
            // 
            this.txt_gz.Location = new System.Drawing.Point(50, 409);
            this.txt_gz.Name = "txt_gz";
            this.txt_gz.Size = new System.Drawing.Size(295, 46);
            this.txt_gz.TabIndex = 17;
            // 
            // txt_rldl
            // 
            this.txt_rldl.Location = new System.Drawing.Point(368, 357);
            this.txt_rldl.Name = "txt_rldl";
            this.txt_rldl.Size = new System.Drawing.Size(295, 46);
            this.txt_rldl.TabIndex = 16;
            // 
            // grd_data
            // 
            this.grd_data.Location = new System.Drawing.Point(50, 81);
            this.grd_data.Name = "grd_data";
            this.grd_data.Size = new System.Drawing.Size(635, 221);
            this.grd_data.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F);
            this.label1.Location = new System.Drawing.Point(45, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "月份：";
            // 
            // mydate
            // 
            this.mydate.CalendarFont = new System.Drawing.Font("宋体", 12F);
            this.mydate.Font = new System.Drawing.Font("宋体", 12F);
            this.mydate.Location = new System.Drawing.Point(107, 29);
            this.mydate.Name = "mydate";
            this.mydate.Size = new System.Drawing.Size(153, 26);
            this.mydate.TabIndex = 13;
            this.mydate.ValueChanged += new System.EventHandler(this.mydate_ValueChanged);
            // 
            // btn_dele
            // 
            this.btn_dele.Font = new System.Drawing.Font("宋体", 12F);
            this.btn_dele.Location = new System.Drawing.Point(588, 31);
            this.btn_dele.Name = "btn_dele";
            this.btn_dele.Size = new System.Drawing.Size(75, 26);
            this.btn_dele.TabIndex = 25;
            this.btn_dele.Text = "删 除";
            this.btn_dele.UseVisualStyleBackColor = true;
            this.btn_dele.Click += new System.EventHandler(this.btn_dele_Click);
            // 
            // frm_调整费用分配
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 548);
            this.Controls.Add(this.btn_dele);
            this.Controls.Add(this.cmb_gonghao);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.txt_zzfy);
            this.Controls.Add(this.txt_gz);
            this.Controls.Add(this.txt_rldl);
            this.Controls.Add(this.grd_data);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mydate);
            this.Name = "frm_调整费用分配";
            this.Text = "frm_调整费用分配";
            this.Load += new System.EventHandler(this.frm_调整费用分配_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_gonghao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_add;
        private 外分厂生产管理.userctrl.ctrl_text txt_zzfy;
        private 外分厂生产管理.userctrl.ctrl_text txt_gz;
        private 外分厂生产管理.userctrl.ctrl_text txt_rldl;
        private 新财务管理.usercontrols.ctl_grid grd_data;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker mydate;
        private System.Windows.Forms.Button btn_dele;
    }
}