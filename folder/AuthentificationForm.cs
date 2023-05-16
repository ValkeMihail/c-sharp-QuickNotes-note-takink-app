using System;
using System.Windows.Forms;

namespace folder
{
    public partial class AuthentificationForm : Form
    {
        private RegisterForm registerForm;
        private LoginForm loginForm;

        public AuthentificationForm()
        {
            InitializeComponent();

            // Create instances of RegisterForm and LoginForm
            registerForm = new RegisterForm();
            loginForm = new LoginForm();

            // Set properties of RegisterForm
            registerForm.TopLevel = false;
            registerForm.FormBorderStyle = FormBorderStyle.None;
            registerForm.Dock = DockStyle.Fill;
            registerForm.Visible = false;

            // Set properties of LoginForm
            loginForm.TopLevel = false;
            loginForm.FormBorderStyle = FormBorderStyle.None;
            loginForm.Dock = DockStyle.Fill;
            loginForm.Visible = false;

            // Add RegisterForm and LoginForm to respective panels
            panelRegister.Controls.Add(registerForm);
            panelLogin.Controls.Add(loginForm);
        }
        private void closeButton_Click(object sender, EventArgs e)
        {
            Timer timer = new Timer();
            timer.Interval = 10;
            timer.Tick += (s, ev) =>
            {
                if (this.Opacity <= 0)
                {
                    timer.Stop();
                    this.Close();
                }
                else
                {
                    this.Opacity -= 0.05;
                }
            };
            timer.Start();
        }
        private void tabControlAuth_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Show RegisterForm or LoginForm depending on the selected tab
            if (tabControlAuth.SelectedTab == tabPageRegister)
            {
                registerForm.Visible = true;
                loginForm.Visible = false;

            }
            else if (tabControlAuth.SelectedTab == tabPageLogin)
            {
                loginForm.Visible = true;
                registerForm.Visible = false;
            }
           
        }

        private void AuthentificationForm_Load(object sender, EventArgs e)
        {
            registerForm.Visible = true;
            loginForm.Visible = false;
        }
    }

}
