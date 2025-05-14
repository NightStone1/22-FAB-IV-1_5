using System;
using System.Net.Mail;
using System.Windows.Forms;
using MailKit.Net.Smtp;
using MimeKit;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Email
{
    public partial class Send : Form
    {
        string attachFile = null; // Путь к прикрепленному файлу (если есть)
        string login; // Логин пользователя
        string password; // Пароль пользователя
        string smtpserver = "smtp.mail.ru"; // Адрес SMTP сервера
        int smtpPort = 465; // Порт SMTP сервера
        public Send(string login, string password)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.CenterToScreen();
            this.login = login; // Сохранение логина, переданного из другой формы
            this.password = password; // Сохранение пароля, переданного из другой формы
        }
        private async void btn_send_Click(object sender, EventArgs e)
        {
            {
                txtStatus.Text = "Отправка..."; // Отображаем статус отправки
                try
                {
                    using (var smtp = new MailKit.Net.Smtp.SmtpClient())
                    {
                        smtp.ServerCertificateValidationCallback = (s, cert, chain, sslError) => true;
                        await smtp.ConnectAsync(smtpserver, smtpPort, true);
                        await smtp.AuthenticateAsync(login, password);
                        using (MimeMessage message = new MimeMessage())
                        {
                            message.From.Add(new MailboxAddress("", login));
                            if (!string.IsNullOrEmpty(txtTo.Text))
                                message.To.Add(new MailboxAddress("", txtTo.Text));
                            message.Subject = txtSubject.Text ?? string.Empty;
                            var builder = new BodyBuilder();
                            builder.TextBody = txtBody.Text ?? string.Empty;
                            // Добавляем вложения
                            foreach (var attachment in lstFiles.Items)
                            {
                                if (!string.IsNullOrEmpty(attachment.ToString()))
                                {
                                    builder.Attachments.Add(attachment.ToString());
                                }
                            }
                            message.Body = builder.ToMessageBody();
                            await smtp.SendAsync(message);
                        }
                        await smtp.DisconnectAsync(true);
                        txtStatus.Text = ("Email sent successfully!");
                    }
                }
                catch (SmtpCommandException ex)
                {
                    txtStatus.Text = ($"SMTP Error: {ex.StatusCode} - {ex.Message}");
                }
                catch (Exception ex)
                {
                    txtStatus.Text = ($"Error: {ex.GetType().Name} - {ex.Message}");
                }
            }
        }
        private void btn_chsfile_Click(object sender, EventArgs e)
        {
            // Создаем экземпляр диалогового окна для выбора файла
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Выберите файл"; // Заголовок окна
                openFileDialog.Filter = "Все файлы (*.*)|*.*"; // Фильтр файлов
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); // Начальная директория
                openFileDialog.CheckFileExists = true; // Проверка существования файла
                openFileDialog.CheckPathExists = true; // Проверка существования пути
                openFileDialog.RestoreDirectory = true; // Восстанавливать последнюю директорию
                // Если пользователь выбрал файл и нажал "OK"
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    attachFile = openFileDialog.FileName; // Получаем путь к выбранному файлу
                    lstFiles.Items.Add(attachFile); // Добавляем путь к файлу в список файлов
                }
            }
        }
    }
}
