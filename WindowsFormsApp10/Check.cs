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
        string login;
        string password;
        string pop3server = "pop.mail.ru";
        int pop3port = 995;
        string pop3login;
        string pop3password;
        List<OpenPop.Mime.Message> messages = new List<OpenPop.Mime.Message>();
        public Check(string login, string password)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.CenterToScreen();
            this.login = login;
            this.password = password;
            lstEmails.FullRowSelect = true;
        }
        private void Check_Load(object sender, EventArgs e)
        {
            try
            {
                pop3login = login;
                pop3password = password;
                using (var pop3Client = new Pop3Client())
                {
                    pop3Client.Connect(pop3server, pop3port, true);
                    pop3Client.Authenticate(pop3login, pop3password);
                    int count = pop3Client.GetMessageCount();

                    if (count == 0)
                    {
                        pop3Client.Disconnect();
                        MessageBox.Show(
                            "Нет писем",
                            "Info",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        this.Dispose();
                        return;
                    }

                    messages.Clear();
                    lstEmails.Items.Clear(); // Очистка ListView перед добавлением новых элементов

                    for (int i = count; i >= 1; i--)
                    {
                        OpenPop.Mime.Message message = pop3Client.GetMessage(i);
                        messages.Add(message);
                    }

                    lstEmails.View = View.Details;
                    lstEmails.Columns.Add("От", 200);
                    lstEmails.Columns.Add("Тема", 200);
                    lstEmails.Columns.Add("Дата", 150);

                    foreach (OpenPop.Mime.Message message in messages)
                    {
                        string from = message.Headers.From.Address;
                        string subject = message.Headers.Subject;
                        DateTime dateSent = message.Headers.DateSent;
                        var item = new ListViewItem(from);
                        item.SubItems.Add(subject);
                        item.SubItems.Add(dateSent.ToString("dd.MM.yy"));
                        lstEmails.Items.Add(item);
                    }


                    pop3Client.Disconnect();
                    MessageBox.Show(
                        "Письма получены",
                        "Info",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                this.Dispose();
                MessageBox.Show(
                    $"Ошибка: {ex.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }       
        private void lstEmails_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstEmails.SelectedIndices.Count == 0) return;

            txtEmailBody.Clear();
            lstAttachments.Items.Clear(); // Очищаем список вложений

            try
            {
                int selectedIndex = lstEmails.SelectedIndices[0];
                OpenPop.Mime.Message message = messages[selectedIndex];

                // Отображение тела письма (как и раньше)
                MessagePart body = message.FindFirstPlainTextVersion();
                if (body != null)
                {
                    txtEmailBody.Text = body.GetBodyAsText();
                }
                else
                {
                    MessagePart htmlBody = message.FindFirstHtmlVersion();
                    if (htmlBody != null)
                        txtEmailBody.Text = htmlBody.GetBodyAsText();
                    else
                        txtEmailBody.Text = "Сообщение не содержит текст.";
                }

                // Обработка вложений
                foreach (var part in message.FindAllAttachments())
                {
                    lstAttachments.Items.Add(part.FileName); // Добавляем имя файла в список
                                                             // Можно также сохранить MessagePart в какой-нибудь коллекции
                                                             // для последующего использования (сохранения на диск)
                }

                if (lstAttachments.Items.Count == 0)
                {
                    lstAttachments.Items.Add("Нет вложений");
                }
            }
            catch (Exception ex)
            {
                txtEmailBody.Text = $"Ошибка: {ex.Message}";
            }
        }
        private void lstAttachments_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstAttachments.SelectedIndex == -1 || lstAttachments.SelectedItem.ToString() == "Нет вложений") return;

            try
            {
                int selectedEmailIndex = lstEmails.SelectedIndices[0]; // Получаем индекс выбранного письма
                OpenPop.Mime.Message message = messages[selectedEmailIndex];

                string selectedAttachmentName = lstAttachments.SelectedItem.ToString();

                // Находим MessagePart, соответствующий выбранному вложению
                foreach (var part in message.FindAllAttachments())
                {
                    if (part.FileName == selectedAttachmentName)
                    {
                        // Сохраняем вложение на диск
                        string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), part.FileName);
                        File.WriteAllBytes(filePath, part.Body);
                        MessageBox.Show($"Вложение сохранено в: {filePath}", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //Можно добавить отображение изображения в PictureBox, если это изображение.
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении вложения: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
