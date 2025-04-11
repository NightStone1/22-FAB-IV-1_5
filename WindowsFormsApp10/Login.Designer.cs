namespace Email
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.txt_log = new System.Windows.Forms.TextBox();
            this.txtbox_pw = new System.Windows.Forms.TextBox();
            this.txtbox1 = new System.Windows.Forms.TextBox();
            this.txtbox2 = new System.Windows.Forms.TextBox();
            this.btn_send = new System.Windows.Forms.Button();
            this.btn_check = new System.Windows.Forms.Button();
            this.usePchars = new System.Windows.Forms.PictureBox();
            this.unusePchars = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.usePchars)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unusePchars)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_log
            // 
            this.txt_log.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txt_log.Location = new System.Drawing.Point(120, 20);
            this.txt_log.Multiline = true;
            this.txt_log.Name = "txt_log";
            this.txt_log.Size = new System.Drawing.Size(250, 25);
            this.txt_log.TabIndex = 0;
            this.txt_log.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtbox_pw
            // 
            this.txtbox_pw.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtbox_pw.Location = new System.Drawing.Point(120, 51);
            this.txtbox_pw.Multiline = true;
            this.txtbox_pw.Name = "txtbox_pw";
            this.txtbox_pw.PasswordChar = '*';
            this.txtbox_pw.Size = new System.Drawing.Size(250, 25);
            this.txtbox_pw.TabIndex = 1;
            this.txtbox_pw.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtbox1
            // 
            this.txtbox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtbox1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtbox1.Location = new System.Drawing.Point(10, 20);
            this.txtbox1.Multiline = true;
            this.txtbox1.Name = "txtbox1";
            this.txtbox1.ReadOnly = true;
            this.txtbox1.Size = new System.Drawing.Size(104, 25);
            this.txtbox1.TabIndex = 2;
            this.txtbox1.Text = "Почта";
            this.txtbox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtbox2
            // 
            this.txtbox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtbox2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtbox2.Location = new System.Drawing.Point(10, 51);
            this.txtbox2.Multiline = true;
            this.txtbox2.Name = "txtbox2";
            this.txtbox2.ReadOnly = true;
            this.txtbox2.Size = new System.Drawing.Size(104, 25);
            this.txtbox2.TabIndex = 3;
            this.txtbox2.Text = "Пароль";
            this.txtbox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btn_send
            // 
            this.btn_send.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_send.Location = new System.Drawing.Point(104, 82);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(200, 30);
            this.btn_send.TabIndex = 4;
            this.btn_send.Text = "Отправить сообщение";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // btn_check
            // 
            this.btn_check.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_check.Location = new System.Drawing.Point(104, 118);
            this.btn_check.Name = "btn_check";
            this.btn_check.Size = new System.Drawing.Size(200, 30);
            this.btn_check.TabIndex = 5;
            this.btn_check.Text = "Проверить почту";
            this.btn_check.UseVisualStyleBackColor = true;
            this.btn_check.Click += new System.EventHandler(this.btn_check_Click);
            // 
            // usePchars
            // 
            this.usePchars.Image = ((System.Drawing.Image)(resources.GetObject("usePchars.Image")));
            this.usePchars.Location = new System.Drawing.Point(376, 54);
            this.usePchars.Name = "usePchars";
            this.usePchars.Size = new System.Drawing.Size(22, 22);
            this.usePchars.TabIndex = 18;
            this.usePchars.TabStop = false;
            this.usePchars.Visible = false;
            this.usePchars.Click += new System.EventHandler(this.usePchars_Click);
            // 
            // unusePchars
            // 
            this.unusePchars.Image = ((System.Drawing.Image)(resources.GetObject("unusePchars.Image")));
            this.unusePchars.Location = new System.Drawing.Point(376, 54);
            this.unusePchars.Name = "unusePchars";
            this.unusePchars.Size = new System.Drawing.Size(22, 22);
            this.unusePchars.TabIndex = 19;
            this.unusePchars.TabStop = false;
            this.unusePchars.Click += new System.EventHandler(this.unusePchars_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 161);
            this.Controls.Add(this.usePchars);
            this.Controls.Add(this.unusePchars);
            this.Controls.Add(this.btn_check);
            this.Controls.Add(this.btn_send);
            this.Controls.Add(this.txtbox2);
            this.Controls.Add(this.txtbox1);
            this.Controls.Add(this.txtbox_pw);
            this.Controls.Add(this.txt_log);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.Text = "Вход";
            ((System.ComponentModel.ISupportInitialize)(this.usePchars)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unusePchars)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_log;
        private System.Windows.Forms.TextBox txtbox_pw;
        private System.Windows.Forms.TextBox txtbox1;
        private System.Windows.Forms.TextBox txtbox2;
        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.Button btn_check;
        private System.Windows.Forms.PictureBox usePchars;
        private System.Windows.Forms.PictureBox unusePchars;
    }
}