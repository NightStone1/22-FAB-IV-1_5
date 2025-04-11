using System;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace Email
{
    public partial class Send : Form
    {
        string attachFile = null;
        string login;
        string password;
        string smtpserver = "smtp.mail.ru";
        int smtpPort = 465;
        public Send(string login, string password)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.CenterToScreen();
            this.login = login;
            this.password = password;
        }

        private async void btn_send_Click(object sender, EventArgs e)
        {
            {
                txtStatus.Text = "Отправка...";
                try
                {
                    using (SmtpClient smtp = new SmtpClient(smtpserver, smtpPort))
                    {
                        smtp.Credentials = new NetworkCredential(login, password);
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.EnableSsl = true;

                        using (MailMessage message = new MailMessage(login, txtTo.Text, txtSubject.Text, txtBody.Text))
                        {
                            if (!string.IsNullOrEmpty(attachFile))
                                message.Attachments.Add(new Attachment(attachFile));

                            await smtp.SendMailAsync(message);
                        }

                        txtStatus.Text = "Письмо отправлено!";
                    }

                }
                catch (SmtpException ex)
                {
                    txtStatus.Text = $"Ошибка отправки письма: {ex.Message}";
                }
                catch (Exception ex)
                {
                    txtStatus.Text = $"Непредвиденная ошибка: {ex.Message}";
                }
            }
        }
        private void btn_chsfile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Выберите файл";
                openFileDialog.Filter = "Все файлы (*.*)|*.*";
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                openFileDialog.CheckFileExists = true;
                openFileDialog.CheckPathExists = true;
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    attachFile = openFileDialog.FileName;
                    lstFiles.Items.Add(attachFile);
                }
            }
        }
    }
}
