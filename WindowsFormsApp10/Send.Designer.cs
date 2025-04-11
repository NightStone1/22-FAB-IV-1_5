namespace Email
{
    partial class Send
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Send));
            this.btn_send = new System.Windows.Forms.Button();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.txtbox2 = new System.Windows.Forms.TextBox();
            this.txtbox1 = new System.Windows.Forms.TextBox();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.txtBody = new System.Windows.Forms.TextBox();
            this.btn_chsfile = new System.Windows.Forms.Button();
            this.lstFiles = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btn_send
            // 
            this.btn_send.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_send.Location = new System.Drawing.Point(12, 347);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(200, 30);
            this.btn_send.TabIndex = 5;
            this.btn_send.Text = "Отправить сообщение";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // txtStatus
            // 
            this.txtStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtStatus.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtStatus.Location = new System.Drawing.Point(12, 413);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(707, 25);
            this.txtStatus.TabIndex = 6;
            // 
            // txtbox2
            // 
            this.txtbox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtbox2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtbox2.Location = new System.Drawing.Point(12, 43);
            this.txtbox2.Multiline = true;
            this.txtbox2.Name = "txtbox2";
            this.txtbox2.ReadOnly = true;
            this.txtbox2.Size = new System.Drawing.Size(112, 25);
            this.txtbox2.TabIndex = 10;
            this.txtbox2.Text = "Тема";
            this.txtbox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtbox1
            // 
            this.txtbox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtbox1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtbox1.Location = new System.Drawing.Point(12, 12);
            this.txtbox1.Multiline = true;
            this.txtbox1.Name = "txtbox1";
            this.txtbox1.ReadOnly = true;
            this.txtbox1.Size = new System.Drawing.Size(112, 25);
            this.txtbox1.TabIndex = 9;
            this.txtbox1.Text = "Отправить к";
            this.txtbox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSubject
            // 
            this.txtSubject.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtSubject.Location = new System.Drawing.Point(130, 43);
            this.txtSubject.Multiline = true;
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(250, 25);
            this.txtSubject.TabIndex = 8;
            // 
            // txtTo
            // 
            this.txtTo.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtTo.Location = new System.Drawing.Point(130, 12);
            this.txtTo.Multiline = true;
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(250, 25);
            this.txtTo.TabIndex = 7;
            // 
            // txtBody
            // 
            this.txtBody.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtBody.Location = new System.Drawing.Point(12, 74);
            this.txtBody.Multiline = true;
            this.txtBody.Name = "txtBody";
            this.txtBody.Size = new System.Drawing.Size(368, 231);
            this.txtBody.TabIndex = 11;
            // 
            // btn_chsfile
            // 
            this.btn_chsfile.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_chsfile.Location = new System.Drawing.Point(12, 311);
            this.btn_chsfile.Name = "btn_chsfile";
            this.btn_chsfile.Size = new System.Drawing.Size(200, 30);
            this.btn_chsfile.TabIndex = 12;
            this.btn_chsfile.Text = "Выбрать файл";
            this.btn_chsfile.UseVisualStyleBackColor = true;
            this.btn_chsfile.Click += new System.EventHandler(this.btn_chsfile_Click);
            // 
            // lstFiles
            // 
            this.lstFiles.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lstFiles.FormattingEnabled = true;
            this.lstFiles.ItemHeight = 21;
            this.lstFiles.Location = new System.Drawing.Point(386, 12);
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.Size = new System.Drawing.Size(336, 298);
            this.lstFiles.TabIndex = 13;
            // 
            // Send
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 451);
            this.Controls.Add(this.lstFiles);
            this.Controls.Add(this.btn_chsfile);
            this.Controls.Add(this.txtBody);
            this.Controls.Add(this.txtbox2);
            this.Controls.Add(this.txtbox1);
            this.Controls.Add(this.txtSubject);
            this.Controls.Add(this.txtTo);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.btn_send);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Send";
            this.Text = "Отправка сообщения";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.TextBox txtbox2;
        private System.Windows.Forms.TextBox txtbox1;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.TextBox txtBody;
        private System.Windows.Forms.Button btn_chsfile;
        private System.Windows.Forms.ListBox lstFiles;
    }
}