using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Email
{
    public partial class Login : Form
    {
        string login; // Логин пользователя
        string password; // Пароль пользователя        
        public Login()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.CenterToScreen();
        }
        private void usePchars_Click(object sender, EventArgs e)
        {
            txtbox_pw.UseSystemPasswordChar = false; // Отключаем скрытие пароля
            usePchars.Visible = false; // Скрываем кнопку "Показать пароль"
            unusePchars.Visible = true; // Показываем кнопку "Скрыть пароль"
        }
        private void unusePchars_Click(object sender, EventArgs e)
        {
            txtbox_pw.UseSystemPasswordChar = true; // Включаем скрытие пароля
            usePchars.Visible = true; // Показываем кнопку "Показать пароль"
            unusePchars.Visible = false; // Скрываем кнопку "Скрыть пароль"
        }
        private void btn_send_Click(object sender, EventArgs e)
        {
            login = txt_log.Text; // Получаем логин из текстового поля
            password = txtbox_pw.Text; // Получаем пароль из текстового поля
            // Проверяем, что логин и пароль не пустые
            if ((login.Length == 0) || (password.Length == 0))
            {
                MessageBox.Show(
                    "Неправильный логин или пароль",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                // Создаем экземпляр формы для отправки писем и передаем ей логин и пароль
                Send send = new Send(login, password);
                send.ShowDialog(); // Открываем форму
            }
        }
        private void btn_check_Click(object sender, EventArgs e)
        {
            login = txt_log.Text; // Получаем логин из текстового поля
            password = txtbox_pw.Text; // Получаем пароль из текстового поля
            // Проверяем, что логин и пароль не пустые
            if ((login.Length == 0) || (password.Length == 0))
            {
                MessageBox.Show(
                    "Неправильный логин или пароль",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                // Создаем экземпляр формы для проверки почты и передаем ей логин и пароль
                Check check = new Check(login, password);
                check.ShowDialog(); // Открываем форму
            }
        }
    }
}