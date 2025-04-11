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
                    for (int i = count; i >= 1; i--)
                    {
                        OpenPop.Mime.Message message = pop3Client.GetMessage(i);
                        messages.Add(message);
                    }
                    for (int i = 0; i < messages.Count; i++)
                    {
                        OpenPop.Mime.Message message = messages[i];
                        string from = message.Headers.From.Address;
                        string subject = message.Headers.Subject;
                        lstEmails.Items.Add($"{from} - {subject}");

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
            if (lstEmails.SelectedIndex == -1) return;
            txtEmailBody.Clear();
            try
            {             
                OpenPop.Mime.Message message = messages[lstEmails.SelectedIndex];
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

            }
            catch (Exception ex)
            {
                txtEmailBody.Text = $"Ошибка: {ex.Message}";
            }
        }
    }
}
