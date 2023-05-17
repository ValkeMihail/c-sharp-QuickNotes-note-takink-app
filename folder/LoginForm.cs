using Supabase.Gotrue;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace folder
{
    public partial class LoginForm : Form
    {
        private readonly Supabase.Client _supabase;
      

        public LoginForm()
        {
            InitializeComponent();
            _supabase = new Supabase.Client("url", "apiKey");
        }
        public string Decrypt(string encryptedNote, string key)
        {
            byte[] combinedBytes = Convert.FromBase64String(encryptedNote);
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            using (SHA256 sha256 = SHA256.Create())
            {
                keyBytes = sha256.ComputeHash(keyBytes);
            }
            byte[] ivBytes = new byte[16];
            byte[] encryptedBytes = new byte[combinedBytes.Length - ivBytes.Length];

            Array.Copy(combinedBytes, 0, ivBytes, 0, ivBytes.Length);
            Array.Copy(combinedBytes, ivBytes.Length, encryptedBytes, 0, encryptedBytes.Length);

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = keyBytes;
                aesAlg.IV = ivBytes;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(encryptedBytes))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }
        private async void LoginButton_Click(object sender, EventArgs e)
        {
            string email = emailTextBox.Text.Trim();
            string password = passwordTextBox.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                this.messageLabel.Visible = true;
                this.messageLabel.ForeColor = Color.Red;
                this.messageLabel.Text = "Please fill in all fields.";

                return;
            }

            try
            {
                // Sign in the user with Supabase
                var session = await _supabase.Auth.SignIn(email, password);

                if (session != null)
                {
                    string userIdStr = session.User.Id;
                    Guid userId;

                    if (Guid.TryParse(userIdStr, out userId))
                    {
                       
                        this.messageLabel.Visible = true;
                        this.messageLabel.Text = "Login successful!";
                        this.messageLabel.ForeColor = Color.Green;

                        var noteresponse = await _supabase.From<Note>().Where(x => x.UserId == userId).Get();
                      
                        var notes = noteresponse.Models.ToList();
                      
                        Dictionary<string, string> noteDictus = new Dictionary<string, string>();
                      
                      
                        foreach (var note in notes)
                        {
                            try
                            {
                                if (!string.IsNullOrEmpty(note.Title) && !string.IsNullOrEmpty(note.Content))
                                {
                                    noteDictus.Add(note.Title, Decrypt(note.Content , userIdStr));
                                }

                             
                               
                               
                            }
                            catch (Exception ex)
                            {
                                this.messageLabel.Text = ex.ToString();
                            }
                        }
                       
                        NotesForm notesForm = new NotesForm(noteDictus, userId);
                        notesForm.ShowDialog();
                        



                    }
                    else
                    {
                        this.messageLabel.Visible = true;
                        this.messageLabel.Text = "Login Failed!";
                        this.messageLabel.ForeColor = Color.Red;
                    }
                }
                else
                {
                    this.messageLabel.Visible = true;
                    this.messageLabel.ForeColor = Color.Red;
                    this.messageLabel.Text = "Incorrect email and/or password. Please try again.";
                }
            }
            catch (BadRequestException ex)
            {
                this.messageLabel.Visible = true;
                this.messageLabel.ForeColor = Color.Red;
                this.messageLabel.Text = "Incorrect email and/or password. Please try again.";
            }
            catch (Exception ex)
            {
                this.messageLabel.Visible = true;
                this.messageLabel.ForeColor = Color.Red;
                this.messageLabel.Text = ex.Message;
            }
        }

    }
   

}
