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
        string login;
        string password;
        public Login()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.CenterToScreen();
        }
        
        private void usePchars_Click(object sender, EventArgs e)
        {
            txtbox_pw.UseSystemPasswordChar = false;
            usePchars.Visible = false;
            unusePchars.Visible = true;
        }
        private void unusePchars_Click(object sender, EventArgs e)
        {
            txtbox_pw.UseSystemPasswordChar = true;
            usePchars.Visible = true;
            unusePchars.Visible = false;
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            login = txt_log.Text;
            password = txtbox_pw.Text;
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
                Send send = new Send(login, password);
                send.ShowDialog();
            }            
        }

        private void btn_check_Click(object sender, EventArgs e)
        {
            login = txt_log.Text;
            password = txtbox_pw.Text;
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
                Check check = new Check(login, password);
                check.ShowDialog();
            }            
        }
    }
}
