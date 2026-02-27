using Blagodat.Data;
using Blagodat.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Blagodat.Views
{
    public partial class LoginForm : Form
    {
        private BlagodatContext _context;
        public static User CurrentUser { get; private set; }

        public LoginForm()
        {
            InitializeComponent();
            _context = new BlagodatContext();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Text = "Авторизация - Горнолыжный комплекс Благодать";
            textBoxPassword.PasswordChar = '*';

            panelHeader.BackColor = Color.FromArgb(118, 227, 131);
            btnLogin.BackColor = Color.FromArgb(73, 140, 81);
            btnLogin.ForeColor = Color.White;
 
            SetComicSansFont(this);
        }

        private void SetComicSansFont(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c.HasChildren)
                    SetComicSansFont(c);

                if (c is Label || c is Button || c is TextBox)
                {
                    c.Font = new Font("Comic Sans MS", c.Font.Size);
                }
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxUsername.Text) ||
                string.IsNullOrWhiteSpace(textBoxPassword.Text))
            {
                labelError.Text = "Введите логин и пароль";
                labelError.Visible = true;
                return;
            }

            var user = _context.Clients
                .FirstOrDefault(c => c.Email == textBoxUsername.Text &&
                                     c.Password == textBoxPassword.Text);

            if (user != null)
            {
                
                CurrentUser = new User
                {
                    Id = user.Id,
                    LastName = user.LastName,
                    FirstName = user.FirstName,
                    MiddleName = user.MiddleName,
                    Email = user.Email,
                    Role = GetUserRole(user.Email) 
                };

                MainForm mainForm = new MainForm();
                mainForm.Show();
                this.Hide();
            }
            else
            {
                labelError.Text = "Неверный логин или пароль";
                labelError.Visible = true;
            }
        }

        private string GetUserRole(string email)
        {
         
            if (email.Contains("admin"))
                return "Администратор";
            else if (email.Contains("senior"))
                return "Старший смены";
            else
                return "Продавец";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void labelError_Click(object sender, EventArgs e)
        {

        }
    }
    public class User
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string FullName => $"{LastName} {FirstName} {MiddleName}";
    }
}