namespace 重装板块成本系统.forms
{
    partial class frm_收入导入
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btn_filename = new System.Windows.Forms.Button();
            this.btn_import = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_workno = new 外分厂生产管理.userctrl.ctrl_text();
            this.cmb_type = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_cancle = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.txt_weight = new 外分厂生产管理.userctrl.ctrl_text();
            this.txt_taifen = new 外分厂生产管理.userctrl.ctrl_text();
            this.txt_income = new 外分厂生产管理.userctrl.ctrl_text();
            this.mydate = new System.Windows.Forms.DateTimePicker();
            this.txt_filename = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_serarch = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.btn_edit = new System.Windows.Forms.Button();
            this.btn_dele = new System.Windows.Forms.Button();
            this.txt_searchworkno = new 外分厂生产管理.userctrl.ctrl_text();
            this.data_grd = new 新财务管理.usercontrols.ctl_grid();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btn_filename
            // 
            this.btn_filename.Location = new System.Drawing.Point(563, 20);
            this.btn_filename.Name = "btn_filename";
            this.btn_filename.Size = new System.Drawing.Size(30, 23);
            this.btn_filename.TabIndex = 1;
            this.btn_filename.Text = "...";
            this.btn_filename.UseVisualStyleBackColor = true;
            this.btn_filename.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // btn_import
            // 
            this.btn_import.Location = new System.Drawing.Point(655, 20);
            this.btn_import.Name = "btn_import";
            this.btn_import.Size = new System.Drawing.Size(75, 23);
            this.btn_import.TabIndex = 2;
            this.btn_import.Text = "button2";
            this.btn_import.UseVisualStyleBackColor = true;
            this.btn_import.Click += new System.EventHandler(this.btn_import_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_workno);
            this.groupBox1.Controls.Add(this.cmb_type);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btn_cancle);
            this.groupBox1.Controls.Add(this.btn_save);
            this.groupBox1.Controls.Add(this.txt_weight);
            this.groupBox1.Controls.Add(this.txt_taifen);
            this.groupBox1.Controls.Add(this.txt_income);
            this.groupBox1.Location = new System.Drawing.Point(563, 92);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(329, 462);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // txt_workno
            // 
            this.txt_workno.Location = new System.Drawing.Point(16, 59);
            this.txt_workno.Name = "txt_workno";
            this.txt_workno.Size = new System.Drawing.Size(295, 46);
            this.txt_workno.TabIndex = 0;
            // 
            // cmb_type
            // 
            this.cmb_type.Font = new System.Drawing.Font("宋体", 11F);
            this.cmb_type.FormattingEnabled = true;
            this.cmb_type.Location = new System.Drawing.Point(107, 200);
            this.cmb_type.Name = "cmb_type";
            this.cmb_type.Size = new System.Drawing.Size(121, 23);
            this.cmb_type.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 11F);
            this.label1.Location = new System.Drawing.Point(30, 200);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "类型:";
            // 
            // btn_cancle
            // 
            this.btn_cancle.Location = new System.Drawing.Point(200, 395);
            this.btn_cancle.Name = "btn_cancle";
            this.btn_cancle.Size = new System.Drawing.Size(75, 23);
            this.btn_cancle.TabIndex = 6;
            this.btn_cancle.Text = "button2";
            this.btn_cancle.UseVisualStyleBackColor = true;
            this.btn_cancle.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(82, 395);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 5;
            this.btn_save.Text = "button2";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt_weight
            // 
            this.txt_weight.Location = new System.Drawing.Point(16, 317);
            this.txt_weight.Name = "txt_weight";
            this.txt_weight.Size = new System.Drawing.Size(295, 46);
            this.txt_weight.TabIndex = 4;
            // 
            // txt_taifen
            // 
            this.txt_taifen.Location = new System.Drawing.Point(16, 250);
            this.txt_taifen.Name = "txt_taifen";
            this.txt_taifen.Size = new System.Drawing.Size(295, 46);
            this.txt_taifen.TabIndex = 3;
            // 
            // txt_income
            // 
            this.txt_income.Location = new System.Drawing.Point(16, 119);
            this.txt_income.Name = "txt_income";
            this.txt_income.Size = new System.Drawing.Size(295, 46);
            this.txt_income.TabIndex = 1;
            // 
            // mydate
            // 
            this.mydate.CalendarFont = new System.Drawing.Font("宋体", 11F);
            this.mydate.Font = new System.Drawing.Font("宋体", 11F);
            this.mydate.Location = new System.Drawing.Point(29, 19);
            this.mydate.Name = "mydate";
            this.mydate.Size = new System.Drawing.Size(200, 24);
            this.mydate.TabIndex = 5;
            this.mydate.ValueChanged += new System.EventHandler(this.mydate_ValueChanged);
            // 
            // txt_filename
            // 
            this.txt_filename.Font = new System.Drawing.Font("宋体", 11F);
            this.txt_filename.Location = new System.Drawing.Point(257, 19);
            this.txt_filename.Name = "txt_filename";
            this.txt_filename.Size = new System.Drawing.Size(300, 24);
            this.txt_filename.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 13F);
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(78, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "label2";
            // 
            // btn_serarch
            // 
            this.btn_serarch.Location = new System.Drawing.Point(348, 106);
            this.btn_serarch.Name = "btn_serarch";
            this.btn_serarch.Size = new System.Drawing.Size(55, 32);
            this.btn_serarch.TabIndex = 9;
            this.btn_serarch.Text = "查找";
            this.btn_serarch.UseVisualStyleBackColor = true;
            this.btn_serarch.Click += new System.EventHandler(this.btn_serarch_Click);
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(122, 165);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(55, 32);
            this.btn_add.TabIndex = 10;
            this.btn_add.Text = "查找";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_edit
            // 
            this.btn_edit.Location = new System.Drawing.Point(248, 165);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(55, 32);
            this.btn_edit.TabIndex = 11;
            this.btn_edit.Text = "查找";
            this.btn_edit.UseVisualStyleBackColor = true;
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // btn_dele
            // 
            this.btn_dele.Location = new System.Drawing.Point(358, 165);
            this.btn_dele.Name = "btn_dele";
            this.btn_dele.Size = new System.Drawing.Size(55, 32);
            this.btn_dele.TabIndex = 12;
            this.btn_dele.Text = "查找";
            this.btn_dele.UseVisualStyleBackColor = true;
            this.btn_dele.Click += new System.EventHandler(this.btn_dele_Click);
            // 
            // txt_searchworkno
            // 
            this.txt_searchworkno.Location = new System.Drawing.Point(29, 92);
            this.txt_searchworkno.Name = "txt_searchworkno";
            this.txt_searchworkno.Size = new System.Drawing.Size(295, 46);
            this.txt_searchworkno.TabIndex = 8;
            // 
            // data_grd
            // 
            this.data_grd.Location = new System.Drawing.Point(29, 217);
            this.data_grd.Name = "data_grd";
            this.data_grd.Size = new System.Drawing.Size(512, 337);
            this.data_grd.TabIndex = 3;
            // 
            // frm_收入导入
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 634);
            this.Controls.Add(this.btn_dele);
            this.Controls.Add(this.btn_edit);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.btn_serarch);
            this.Controls.Add(this.txt_searchworkno);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_filename);
            this.Controls.Add(this.mydate);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.data_grd);
            this.Controls.Add(this.btn_import);
            this.Controls.Add(this.btn_filename);
            this.Name = "frm_收入导入";
            this.Text = "frm_收入导入";
            this.Load += new System.EventHandler(this.frm_收入导入_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private 外分厂生产管理.userctrl.ctrl_text txt_income;
        private System.Windows.Forms.Button btn_filename;
        private System.Windows.Forms.Button btn_import;
        private 新财务管理.usercontrols.ctl_grid data_grd;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_cancle;
        private System.Windows.Forms.Button btn_save;
        private 外分厂生产管理.userctrl.ctrl_text txt_weight;
        private 外分厂生产管理.userctrl.ctrl_text txt_taifen;
        private System.Windows.Forms.ComboBox cmb_type;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker mydate;
        private System.Windows.Forms.TextBox txt_filename;
        private System.Windows.Forms.Label label2;
        private 外分厂生产管理.userctrl.ctrl_text txt_searchworkno;
        private System.Windows.Forms.Button btn_serarch;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button btn_edit;
        private 外分厂生产管理.userctrl.ctrl_text txt_workno;
        private System.Windows.Forms.Button btn_dele;
    }
}