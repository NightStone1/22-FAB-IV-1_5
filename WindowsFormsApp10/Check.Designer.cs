namespace Email
{
    partial class Check
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Check));
            this.txtEmailBody = new System.Windows.Forms.TextBox();
            this.lstEmails = new System.Windows.Forms.ListView();
            this.lstAttachments = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // txtEmailBody
            // 
            this.txtEmailBody.Location = new System.Drawing.Point(603, 12);
            this.txtEmailBody.Multiline = true;
            this.txtEmailBody.Name = "txtEmailBody";
            this.txtEmailBody.ReadOnly = true;
            this.txtEmailBody.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtEmailBody.Size = new System.Drawing.Size(582, 291);
            this.txtEmailBody.TabIndex = 1;
            // 
            // lstEmails
            // 
            this.lstEmails.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.lstEmails.HideSelection = false;
            this.lstEmails.Location = new System.Drawing.Point(12, 12);
            this.lstEmails.Name = "lstEmails";
            this.lstEmails.Size = new System.Drawing.Size(572, 427);
            this.lstEmails.TabIndex = 3;
            this.lstEmails.UseCompatibleStateImageBehavior = false;
            this.lstEmails.SelectedIndexChanged += new System.EventHandler(this.lstEmails_SelectedIndexChanged);
            // 
            // lstAttachments
            // 
            this.lstAttachments.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lstAttachments.FormattingEnabled = true;
            this.lstAttachments.ItemHeight = 21;
            this.lstAttachments.Location = new System.Drawing.Point(603, 311);
            this.lstAttachments.Name = "lstAttachments";
            this.lstAttachments.Size = new System.Drawing.Size(569, 130);
            this.lstAttachments.TabIndex = 14;
            this.lstAttachments.SelectedIndexChanged += new System.EventHandler(this.lstAttachments_SelectedIndexChanged);
            // 
            // Check
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 451);
            this.Controls.Add(this.lstAttachments);
            this.Controls.Add(this.lstEmails);
            this.Controls.Add(this.txtEmailBody);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Check";
            this.Text = "Проверка почты";
            this.Load += new System.EventHandler(this.Check_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtEmailBody;
        private System.Windows.Forms.ListView lstEmails;
        private System.Windows.Forms.ListBox lstAttachments;
    }
}