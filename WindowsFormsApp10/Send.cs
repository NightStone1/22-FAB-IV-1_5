using System;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

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
                    // Создаем экземпляр SMTP клиента
                    using (SmtpClient smtp = new SmtpClient(smtpserver, smtpPort))
                    {
                        // Устанавливаем учетные данные
                        smtp.Credentials = new NetworkCredential(login, password);
                        // Устанавливаем метод доставки
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        // Включаем SSL
                        smtp.EnableSsl = true;
                        // Создаем экземпляр сообщения
                        using (MailMessage message = new MailMessage(login, txtTo.Text, txtSubject.Text, txtBody.Text))
                        {
                            // Если есть прикрепленный файл
                            if (!string.IsNullOrEmpty(attachFile))
                                message.Attachments.Add(new Attachment(attachFile)); // Добавляем вложение
                            // Отправляем сообщение асинхронно
                            await smtp.SendMailAsync(message);
                        }
                        txtStatus.Text = "Письмо отправлено!"; // Отображаем статус отправки
                    }
                }
                catch (SmtpException ex)
                {
                    txtStatus.Text = $"Ошибка отправки письма: {ex.Message}"; // Отображаем сообщение об ошибке отправки
                }
                catch (Exception ex)
                {
                    txtStatus.Text = $"Непредвиденная ошибка: {ex.Message}"; // Отображаем сообщение о непредвиденной ошибке
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
