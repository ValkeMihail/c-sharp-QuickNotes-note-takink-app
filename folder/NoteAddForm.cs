using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace folder
{



    public class NoteAddForm : Form
    {
        private TextBox labelTitle;
        private TextBox textBoxContent;
        public Button buttonSave;
        public Button buttonDelete;
        public Button closeButton;

        private readonly Supabase.Client _supabase;
        public string NoteTitle { get { return labelTitle.Text; } }


        public string NoteContent { get { return textBoxContent.Text; } }

        public NoteAddForm(string noteTitle, string noteContent)
        {
            InitializeComponent();
           _supabase = new Supabase.Client("url", "apiKey");

            labelTitle.Text = noteTitle;
            textBoxContent.Text = noteContent;
        }


        private void closeButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine(this.textBoxContent.Text);

            NotesForm notesForm = NotesForm.ActiveForm as NotesForm;
            notesForm.Controls.Remove(this.Parent);
            notesForm.PopulateNotesList();
            notesForm.Refresh();
            this.Close();
        }

        private void InitializeComponent()
        {
            this.labelTitle = new System.Windows.Forms.TextBox();
            this.textBoxContent = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // Set the properties of the form
            this.ClientSize = new Size(1366, 800);
            this.Size = new Size(1366, 800);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "";
            this.BackColor = Color.White;
            this.TopLevel = true;

            // Set the properties of the label that displays the note title
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.labelTitle.Location = new Point(250, 150);
            this.labelTitle.TabIndex = 0;

            // Set the properties of the text box that displays the note content
            this.textBoxContent.BorderStyle = BorderStyle.FixedSingle;
            this.textBoxContent.Location = new Point(250, 200);
            this.textBoxContent.Multiline = true;
            this.textBoxContent.ScrollBars = ScrollBars.Vertical;
            this.textBoxContent.Size = new Size(500, 170);
            this.textBoxContent.TabIndex = 1;

            // Set the properties of the button that saves the note changes
            this.buttonSave.BackColor = SystemColors.ControlLight;
            this.buttonSave.FlatStyle = FlatStyle.Flat;
            this.buttonSave.Font = new Font("Segoe UI", 10F);
            this.buttonSave.Location = new Point(650, 390);
            this.buttonSave.Size = new Size(90, 30);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += ButtonSave_Click;

            this.BackColor = Color.Black;
            this.ForeColor = Color.White;
            this.labelTitle.BackColor = Color.DarkGray;
            this.textBoxContent.BackColor = Color.DarkGray;
            this.labelTitle.ForeColor = Color.White;
            this.textBoxContent.ForeColor = Color.White;
            this.buttonSave.BackColor = Color.Green;
            this.buttonSave.ForeColor = Color.White;
            this.buttonDelete.BackColor = Color.Red;
            this.buttonDelete.ForeColor = Color.White;

            this.closeButton = new System.Windows.Forms.Button();
            this.closeButton.BackColor = Color.Black;
            this.closeButton.ForeColor = Color.White;
            this.closeButton.Location = new Point(960, 30);
            this.closeButton.Size = new Size(30, 30);
            this.closeButton.TabIndex = 3;
            this.closeButton.Text = "X";
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Controls.Add(this.buttonSave);
            // Add the label, text box, and button to the form
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.textBoxContent);

            this.Controls.Add(this.closeButton);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        public  string Encrypt(string noteContent, string key)
        {
            byte[] noteBytes = Encoding.UTF8.GetBytes(noteContent);
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            Console.WriteLine(noteBytes);

            Console.WriteLine(keyBytes);
            using (SHA256 sha256 = SHA256.Create())
            {
                keyBytes = sha256.ComputeHash(keyBytes);
            }
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = keyBytes;
                aesAlg.GenerateIV();

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        csEncrypt.Write(noteBytes, 0, noteBytes.Length);
                        csEncrypt.FlushFinalBlock();

                        byte[] encryptedBytes = msEncrypt.ToArray();
                        byte[] combinedBytes = new byte[aesAlg.IV.Length + encryptedBytes.Length];
                        Array.Copy(aesAlg.IV, 0, combinedBytes, 0, aesAlg.IV.Length);
                        Array.Copy(encryptedBytes, 0, combinedBytes, aesAlg.IV.Length, encryptedBytes.Length);

                        return Convert.ToBase64String(combinedBytes);
                    }
                }
            }
        }

       

        private async void ButtonSave_Click(object sender, EventArgs e)
        {
            Console.WriteLine(this.textBoxContent.Text);
            NotesForm notesForm = NotesForm.ActiveForm as NotesForm;
            if (labelTitle.Text != ""  &&  !notesForm.notesDictionary.ContainsKey(labelTitle.Text) && textBoxContent.Text != "") {
                try
                {
                    var model = new Note
                    {
                        UserId = notesForm.CurrentUserId,
                        Content = this.Encrypt(textBoxContent.Text , notesForm.CurrentUserId.ToString()),
                        Title = labelTitle.Text,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now

                    };
                    await _supabase.From<Note>().Insert(model);
                    notesForm.Controls.Remove(this.Parent);
                    notesForm.notesDictionary[this.NoteTitle] = this.textBoxContent.Text;
                    notesForm.PopulateNotesList();
                    notesForm.Refresh();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            else {
                MessageBox.Show("You must enter a unique title, or a not empty title , also check the content to not be empty ");
            }
           


           
        }
    }
}
