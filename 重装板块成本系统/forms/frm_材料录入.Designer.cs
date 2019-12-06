namespace 重装板块成本系统.forms
{
    partial class frm_材料录入
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
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btn_search = new System.Windows.Forms.Button();
            this.btn_dele = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.btn_edit = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.start_date = new System.Windows.Forms.DateTimePicker();
            this.grd_date = new 新财务管理.usercontrols.ctl_grid();
            this.txt_pzh = new 外分厂生产管理.userctrl.ctrl_text();
            this.btn_calc = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("宋体", 11F);
            this.checkBox1.Location = new System.Drawing.Point(609, 78);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(101, 19);
            this.checkBox1.TabIndex = 25;
            this.checkBox1.Text = "按工号查询";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // btn_search
            // 
            this.btn_search.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btn_search.Font = new System.Drawing.Font("宋体", 11F);
            this.btn_search.ForeColor = System.Drawing.Color.Yellow;
            this.btn_search.Location = new System.Drawing.Point(635, 17);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(75, 31);
            this.btn_search.TabIndex = 24;
            this.btn_search.Text = "查  询";
            this.btn_search.UseVisualStyleBackColor = false;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // btn_dele
            // 
            this.btn_dele.Location = new System.Drawing.Point(361, 73);
            this.btn_dele.Name = "btn_dele";
            this.btn_dele.Size = new System.Drawing.Size(75, 23);
            this.btn_dele.TabIndex = 20;
            this.btn_dele.Text = "删除";
            this.btn_dele.UseVisualStyleBackColor = true;
            this.btn_dele.Click += new System.EventHandler(this.btn_dele_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(685, 511);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(75, 23);
            this.btn_exit.TabIndex = 19;
            this.btn_exit.Text = "退 出";
            this.btn_exit.UseVisualStyleBackColor = true;
            // 
            // btn_edit
            // 
            this.btn_edit.Location = new System.Drawing.Point(245, 73);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(75, 23);
            this.btn_edit.TabIndex = 18;
            this.btn_edit.Text = "修改";
            this.btn_edit.UseVisualStyleBackColor = true;
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(129, 73);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(75, 23);
            this.btn_add.TabIndex = 17;
            this.btn_add.Text = "增 加";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F);
            this.label1.Location = new System.Drawing.Point(90, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 16;
            this.label1.Text = "月份：";
            // 
            // start_date
            // 
            this.start_date.Font = new System.Drawing.Font("宋体", 12F);
            this.start_date.Location = new System.Drawing.Point(160, 18);
            this.start_date.Name = "start_date";
            this.start_date.Size = new System.Drawing.Size(166, 26);
            this.start_date.TabIndex = 15;
            this.start_date.ValueChanged += new System.EventHandler(this.start_date_ValueChanged);
            // 
            // grd_date
            // 
            this.grd_date.Location = new System.Drawing.Point(42, 127);
            this.grd_date.Name = "grd_date";
            this.grd_date.Size = new System.Drawing.Size(718, 355);
            this.grd_date.TabIndex = 22;
            // 
            // txt_pzh
            // 
            this.txt_pzh.Location = new System.Drawing.Point(332, 3);
            this.txt_pzh.Name = "txt_pzh";
            this.txt_pzh.Size = new System.Drawing.Size(261, 46);
            this.txt_pzh.TabIndex = 21;
            // 
            // btn_calc
            // 
            this.btn_calc.Location = new System.Drawing.Point(475, 73);
            this.btn_calc.Name = "btn_calc";
            this.btn_calc.Size = new System.Drawing.Size(75, 23);
            this.btn_calc.TabIndex = 27;
            this.btn_calc.Text = "凭证核对";
            this.btn_calc.UseVisualStyleBackColor = true;
            this.btn_calc.Click += new System.EventHandler(this.btn_calc_Click);
            // 
            // frm_材料录入
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 559);
            this.Controls.Add(this.btn_calc);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.grd_date);
            this.Controls.Add(this.txt_pzh);
            this.Controls.Add(this.btn_dele);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_edit);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.start_date);
            this.Name = "frm_材料录入";
            this.Text = "frm_材料录入";
            this.Load += new System.EventHandler(this.frm_材料录入_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btn_search;
        private 新财务管理.usercontrols.ctl_grid grd_date;
        private 外分厂生产管理.userctrl.ctrl_text txt_pzh;
        private System.Windows.Forms.Button btn_dele;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Button btn_edit;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker start_date;
        private System.Windows.Forms.Button btn_calc;
    }
}