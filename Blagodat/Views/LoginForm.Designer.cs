namespace Blagodat.Views
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panelHeader;
        private PictureBox pictureBoxLogo;
        private Label labelTitle;
        private Label labelUsername;
        private TextBox textBoxUsername;
        private Label labelPassword;
        private TextBox textBoxPassword;
        private Button btnLogin;
        private Button btnExit;
        private Label labelError;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panelHeader = new Panel();
            pictureBoxLogo = new PictureBox();
            labelTitle = new Label();
            labelUsername = new Label();
            textBoxUsername = new TextBox();
            labelPassword = new Label();
            textBoxPassword = new TextBox();
            btnLogin = new Button();
            btnExit = new Button();
            labelError = new Label();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            SuspendLayout();
          
            panelHeader.BackColor = Color.FromArgb(118, 227, 131);
            panelHeader.Controls.Add(pictureBoxLogo);
            panelHeader.Controls.Add(labelTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Margin = new Padding(3, 4, 3, 4);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(464, 133);
            panelHeader.TabIndex = 0;
           
            pictureBoxLogo.Location = new Point(11, 13);
            pictureBoxLogo.Margin = new Padding(3, 4, 3, 4);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new Size(91, 107);
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxLogo.TabIndex = 0;
            pictureBoxLogo.TabStop = false;
         
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Comic Sans MS", 16F, FontStyle.Bold);
            labelTitle.Location = new Point(114, 40);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(339, 38);
            labelTitle.TabIndex = 1;
            labelTitle.Text = "Горнолыжный комплекс";
         
            labelUsername.AutoSize = true;
            labelUsername.Font = new Font("Comic Sans MS", 12F);
            labelUsername.Location = new Point(57, 173);
            labelUsername.Name = "labelUsername";
            labelUsername.Size = new Size(66, 28);
            labelUsername.TabIndex = 1;
            labelUsername.Text = "Email:";
         
            textBoxUsername.Font = new Font("Comic Sans MS", 12F);
            textBoxUsername.Location = new Point(137, 169);
            textBoxUsername.Margin = new Padding(3, 4, 3, 4);
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.Size = new Size(228, 35);
            textBoxUsername.TabIndex = 2;
          
            labelPassword.AutoSize = true;
            labelPassword.Font = new Font("Comic Sans MS", 12F);
            labelPassword.Location = new Point(57, 240);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(92, 28);
            labelPassword.TabIndex = 3;
            labelPassword.Text = "Пароль:";
         
            textBoxPassword.Font = new Font("Comic Sans MS", 12F);
            textBoxPassword.Location = new Point(137, 236);
            textBoxPassword.Margin = new Padding(3, 4, 3, 4);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PasswordChar = '*';
            textBoxPassword.Size = new Size(228, 35);
            textBoxPassword.TabIndex = 4;
          
            btnLogin.BackColor = Color.FromArgb(73, 140, 81);
            btnLogin.Font = new Font("Comic Sans MS", 12F);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(91, 320);
            btnLogin.Margin = new Padding(3, 4, 3, 4);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(114, 53);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Войти";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
          
            btnExit.Font = new Font("Comic Sans MS", 12F);
            btnExit.Location = new Point(229, 320);
            btnExit.Margin = new Padding(3, 4, 3, 4);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(114, 53);
            btnExit.TabIndex = 6;
            btnExit.Text = "Выход";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
          
            labelError.AutoSize = true;
            labelError.Font = new Font("Comic Sans MS", 10F);
            labelError.ForeColor = Color.Red;
            labelError.Location = new Point(92, 396);
            labelError.Name = "labelError";
            labelError.Size = new Size(251, 24);
            labelError.TabIndex = 7;
            labelError.Text = "Неверный логин или пароль";
            labelError.Visible = false;
            labelError.Click += labelError_Click;
          
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(464, 467);
            Controls.Add(labelError);
            Controls.Add(btnExit);
            Controls.Add(btnLogin);
            Controls.Add(textBoxPassword);
            Controls.Add(labelPassword);
            Controls.Add(textBoxUsername);
            Controls.Add(labelUsername);
            Controls.Add(panelHeader);
            Margin = new Padding(3, 4, 3, 4);
            Name = "LoginForm";
            Text = "Авторизация";
            FormClosed += LoginForm_FormClosed;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}