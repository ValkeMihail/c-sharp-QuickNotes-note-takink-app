using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace folder
{
    public partial class RegisterForm : Form
    {

        private readonly Supabase.Client _supabase;
       
        public RegisterForm()
        {
            InitializeComponent();
           
            _supabase = new Supabase.Client("https://erlxhoijelsccfxiktwq.supabase.co", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImVybHhob2lqZWxzY2NmeGlrdHdxIiwicm9sZSI6ImFub24iLCJpYXQiOjE2ODA4MDAxNjQsImV4cCI6MTk5NjM3NjE2NH0.GmACZ332ohO4ccLgf-Ps-wsHjJW4lwzzjcf7x2Lk0pA");

        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string email = txtEmail.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(email))
            {
                this.messageLabel.Visible = true;
                this.messageLabel.ForeColor = Color.Red;
                this.messageLabel.Text = "Please fill in all fields.";
                return;
            }

            // Check if username already exists
            if (await UsernameExists(username))
            {
                this.messageLabel.Visible = true;
                this.messageLabel.ForeColor = Color.Red;
                this.messageLabel.Text = "Username already taken.";
              
                return;
            }

            try
            {
                // Sign up the new user with Supabase
                var session = await _supabase.Auth.SignUp(email, password);


                if (session != null)
                {
                    string userId = session.User.Id.ToString();
                    // Update the 'username' column in the 'users' table
                    try
                    {
                        var update = await _supabase
                        .From<Users>()
                        .Where(x => x.id == userId)
                        .Set(x => x.username, username)
                        .Update();
                        this.messageLabel.Visible = true;
                        this.messageLabel.ForeColor = Color.Green;     
                        this.messageLabel.Text = "Registration successful.";

                        AuthentificationForm authForm = Application.OpenForms.OfType<AuthentificationForm>().FirstOrDefault();
                        if (authForm != null)
                        {

                            authForm.tabControlAuth.SelectedTab = authForm.tabPageLogin;

                        }

                    }
                    catch
                    {
                        this.messageLabel.Visible = true;
                        this.messageLabel.ForeColor = Color.Red;    
                        this.messageLabel.Text = "Registration failed.";
                    }


                }
                else
                {
                    this.messageLabel.Visible = true;
                    this.messageLabel.ForeColor = Color.Red;
                    this.messageLabel.Text = "Registration failed.";
                    
                }
            }
            catch (Exception ex)
            {
                this.messageLabel.Visible = true;
                this.messageLabel.ForeColor = Color.Red;
                this.messageLabel.Text = ex.Message;
                
            }
        }

        private async Task<bool> UsernameExists(string username)
        {
            var result = await _supabase
                .From<Users>()
                .Select("*")
                .Where(x => x.username == username)
                .Get();
            Console.WriteLine(result);
            return result.Models.Count() > 0;
        }

    }

    
}
