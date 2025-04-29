using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using OpenPop.Pop3;
using OpenPop.Mime;
using System.IO;


namespace Email
{
    public partial class Check : Form
    {
        string login; // Логин пользователя
        string password; // Пароль пользователя
        string pop3server = "pop.mail.ru"; // Адрес POP3 сервера
        int pop3port = 995; // Порт POP3 сервера
        string pop3login; // Логин для подключения к POP3 серверу
        string pop3password; // Пароль для подключения к POP3 серверу
        List<OpenPop.Mime.Message> messages = new List<OpenPop.Mime.Message>(); // Список для хранения полученных сообщений
        public Check(string login, string password)
        {
            InitializeComponent();
            this.MaximizeBox = false; // Запрет разворачивания окна на весь экран
            this.CenterToScreen(); // Размещение окна по центру экрана
            this.login = login; // Сохранение логина, переданного из другой формы
            this.password = password; // Сохранение пароля, переданного из другой формы
            lstEmails.FullRowSelect = true; // Включаем выделение всей строки в ListView
        }
        private void Check_Load(object sender, EventArgs e)
        {
            try
            {
                pop3login = login; // Присваиваем логин для POP3
                pop3password = password; // Присваиваем пароль для POP3
                using (var pop3Client = new Pop3Client()) // Создаем экземпляр клиента POP3
                {
                    // Подключаемся к POP3 серверу
                    pop3Client.Connect(pop3server, pop3port, true); // true - использовать SSL
                    // Аутентифицируемся на POP3 сервере
                    pop3Client.Authenticate(pop3login, pop3password);
                    // Получаем количество сообщений в почтовом ящике
                    int count = pop3Client.GetMessageCount();
                    // Если сообщений нет
                    if (count == 0)
                    {
                        pop3Client.Disconnect(); // Отключаемся от сервера
                        MessageBox.Show(
                            "Нет писем",
                            "Info",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        this.Dispose(); // Закрываем форму
                        return; // Выходим из обработчика
                    }
                    messages.Clear(); // Очищаем список сообщений
                    lstEmails.Items.Clear(); // Очищаем ListView перед добавлением новых элементов
                    // Загружаем сообщения в обратном порядке (от новых к старым)
                    for (int i = count; i >= 1; i--)
                    {
                        OpenPop.Mime.Message message = pop3Client.GetMessage(i); // Получаем сообщение по индексу
                        messages.Add(message); // Добавляем сообщение в список
                    }
                    lstEmails.View = View.Details; // Устанавливаем режим отображения ListView - таблица
                    lstEmails.Columns.Add("От", 200); // Добавляем столбец "От"
                    lstEmails.Columns.Add("Тема", 200); // Добавляем столбец "Тема"
                    lstEmails.Columns.Add("Дата", 150); // Добавляем столбец "Дата"
                    // Заполняем ListView данными из полученных сообщений
                    foreach (OpenPop.Mime.Message message in messages)
                    {
                        string from = message.Headers.From.Address; // Получаем адрес отправителя
                        string subject = message.Headers.Subject; // Получаем тему сообщения
                        DateTime dateSent = message.Headers.DateSent; // Получаем дату отправки
                        var item = new ListViewItem(from); // Создаем элемент ListView с адресом отправителя
                        item.SubItems.Add(subject); // Добавляем тему сообщения как подэлемент
                        item.SubItems.Add(dateSent.ToString("dd.MM.yy")); // Добавляем дату отправки как подэлемент
                        lstEmails.Items.Add(item); // Добавляем элемент в ListView
                    }
                    pop3Client.Disconnect(); // Отключаемся от POP3 сервера
                    MessageBox.Show(
                        "Письма получены",
                        "Info",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                this.Dispose(); // Закрываем форму в случае ошибки
                MessageBox.Show(
                    $"Ошибка: {ex.Message}", // Текст сообщения об ошибке
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void lstEmails_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Если ничего не выбрано, выходим из обработчика
            if (lstEmails.SelectedIndices.Count == 0) return;
            txtEmailBody.Clear(); // Очищаем поле для отображения тела письма
            lstAttachments.Items.Clear(); // Очищаем список вложений
            try
            {
                int selectedIndex = lstEmails.SelectedIndices[0]; // Получаем индекс выбранного письма
                OpenPop.Mime.Message message = messages[selectedIndex]; // Получаем сообщение из списка по индексу
                // Отображение тела письма
                MessagePart body = message.FindFirstPlainTextVersion(); // Ищем текстовую версию тела письма
                if (body != null)
                {
                    txtEmailBody.Text = body.GetBodyAsText(); // Отображаем текстовую версию тела письма
                }
                else
                {
                    MessagePart htmlBody = message.FindFirstHtmlVersion(); // Ищем HTML версию тела письма
                    if (htmlBody != null)
                        txtEmailBody.Text = htmlBody.GetBodyAsText(); // Отображаем HTML версию тела письма
                    else
                        txtEmailBody.Text = "Сообщение не содержит текст."; // Сообщаем, что тело письма отсутствует
                }
                // Обработка вложений
                foreach (var part in message.FindAllAttachments())
                {
                    lstAttachments.Items.Add(part.FileName); // Добавляем имя файла в список
                }
                //Если вложений нет, то отображаем сообщение
                if (lstAttachments.Items.Count == 0)
                {
                    lstAttachments.Items.Add("Нет вложений");
                }
            }
            catch (Exception ex)
            {
                txtEmailBody.Text = $"Ошибка: {ex.Message}"; // Отображаем сообщение об ошибке
            }
        }
        private void lstAttachments_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Если ничего не выбрано или выбрано сообщение "Нет вложений", выходим из обработчика
            if (lstAttachments.SelectedIndex == -1 || lstAttachments.SelectedItem.ToString() == "Нет вложений") return;
            try
            {
                int selectedEmailIndex = lstEmails.SelectedIndices[0]; // Получаем индекс выбранного письма
                OpenPop.Mime.Message message = messages[selectedEmailIndex]; // Получаем сообщение из списка по индексу
                string selectedAttachmentName = lstAttachments.SelectedItem.ToString(); // Получаем имя выбранного вложения
                // Находим MessagePart, соответствующий выбранному вложению
                foreach (var part in message.FindAllAttachments())
                {
                    if (part.FileName == selectedAttachmentName)
                    {
                        // Сохраняем вложение на диск
                        string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), part.FileName); // Формируем путь к файлу
                        File.WriteAllBytes(filePath, part.Body); // Сохраняем вложение
                        MessageBox.Show($"Вложение сохранено в: {filePath}", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information); // Сообщаем об успешном сохранении
                        break; // Выходим из цикла
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении вложения: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); // Сообщаем об ошибке
            }
        }
    }
}
