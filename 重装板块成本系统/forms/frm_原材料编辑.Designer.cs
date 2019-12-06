namespace 重装板块成本系统.forms
{
    partial class frm_原材料编辑
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
            this.cmb_type = new System.Windows.Forms.ComboBox();
            this.lab_pzh = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.title = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_gonghao = new 外分厂生产管理.userctrl.ctrl_text();
            this.txt_money = new 外分厂生产管理.userctrl.ctrl_text();
            this.txt_weight = new 外分厂生产管理.userctrl.ctrl_text();
            this.SuspendLayout();
            // 
            // cmb_type
            // 
            this.cmb_type.Font = new System.Drawing.Font("宋体", 12F);
            this.cmb_type.FormattingEnabled = true;
            this.cmb_type.Location = new System.Drawing.Point(139, 136);
            this.cmb_type.Name = "cmb_type";
            this.cmb_type.Size = new System.Drawing.Size(185, 24);
            this.cmb_type.TabIndex = 18;
            // 
            // lab_pzh
            // 
            this.lab_pzh.AutoSize = true;
            this.lab_pzh.Font = new System.Drawing.Font("宋体", 12F);
            this.lab_pzh.Location = new System.Drawing.Point(66, 87);
            this.lab_pzh.Name = "lab_pzh";
            this.lab_pzh.Size = new System.Drawing.Size(56, 16);
            this.lab_pzh.TabIndex = 16;
            this.lab_pzh.Text = "label2";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("宋体", 12F);
            this.button2.Location = new System.Drawing.Point(270, 370);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 14;
            this.button2.Text = "取 消";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btn_save
            // 
            this.btn_save.Font = new System.Drawing.Font("宋体", 12F);
            this.btn_save.Location = new System.Drawing.Point(113, 370);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 13;
            this.btn_save.Text = "保 存";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("宋体", 12F);
            this.title.Location = new System.Drawing.Point(173, 34);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(56, 16);
            this.title.TabIndex = 17;
            this.title.Text = "标题：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F);
            this.label1.Location = new System.Drawing.Point(63, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 15;
            this.label1.Text = "类型：";
            // 
            // txt_gonghao
            // 
            this.txt_gonghao.Location = new System.Drawing.Point(50, 185);
            this.txt_gonghao.Name = "txt_gonghao";
            this.txt_gonghao.Size = new System.Drawing.Size(295, 46);
            this.txt_gonghao.TabIndex = 10;
            // 
            // txt_money
            // 
            this.txt_money.Location = new System.Drawing.Point(50, 289);
            this.txt_money.Name = "txt_money";
            this.txt_money.Size = new System.Drawing.Size(295, 46);
            this.txt_money.TabIndex = 12;
            // 
            // txt_weight
            // 
            this.txt_weight.Location = new System.Drawing.Point(50, 237);
            this.txt_weight.Name = "txt_weight";
            this.txt_weight.Size = new System.Drawing.Size(295, 46);
            this.txt_weight.TabIndex = 11;
            // 
            // frm_原材料编辑
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(387, 422);
            this.Controls.Add(this.txt_gonghao);
            this.Controls.Add(this.cmb_type);
            this.Controls.Add(this.lab_pzh);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.title);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_money);
            this.Controls.Add(this.txt_weight);
            this.Name = "frm_原材料编辑";
            this.Text = "frm_原材料编辑";
            this.Load += new System.EventHandler(this.frm_原材料编辑_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private 外分厂生产管理.userctrl.ctrl_text txt_gonghao;
        private System.Windows.Forms.ComboBox cmb_type;
        private System.Windows.Forms.Label lab_pzh;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Label label1;
        private 外分厂生产管理.userctrl.ctrl_text txt_money;
        private 外分厂生产管理.userctrl.ctrl_text txt_weight;
    }
}