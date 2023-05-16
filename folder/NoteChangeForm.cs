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
    public class NoteChangeForm : Form
    {
        private Label labelTitle;
        private TextBox textBoxContent;
        public Button buttonSave;
        public Button buttonDelete;
        public Button closeButton;
        private readonly Supabase.Client _supabase;
        // Define the NoteTitle property
        public string NoteTitle { get { return labelTitle.Text; } }

        // Define the NoteContent property
        public string NoteContent { get { return textBoxContent.Text; } }

        public NoteChangeForm(string noteTitle, string noteContent)
        {
            InitializeComponent();
            _supabase = new Supabase.Client("https://erlxhoijelsccfxiktwq.supabase.co", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImVybHhob2lqZWxzY2NmeGlrdHdxIiwicm9sZSI6ImFub24iLCJpYXQiOjE2ODA4MDAxNjQsImV4cCI6MTk5NjM3NjE2NH0.GmACZ332ohO4ccLgf-Ps-wsHjJW4lwzzjcf7x2Lk0pA");

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
            this.labelTitle = new System.Windows.Forms.Label();
            this.textBoxContent = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // Set the properties of the form
            this.ClientSize = new Size(1366, 800);
            this.Size = new Size(1366, 800);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Edit Note";

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



            this.buttonSave.FlatStyle = FlatStyle.Flat;
            this.buttonSave.Font = new Font("Segoe UI", 10F);
            this.buttonSave.Location = new Point(650, 390);
            this.buttonSave.Size = new Size(90, 30);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += ButtonSave_Click;



            this.buttonDelete.FlatStyle = FlatStyle.Flat;
            this.buttonDelete.Font = new Font("Segoe UI", 10F);
            this.buttonDelete.Location = new Point(550, 390);
            this.buttonDelete.Size = new Size(90, 30);
            this.buttonDelete.TabIndex = 2;
            this.buttonDelete.Text = "Delete";
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
            this.buttonDelete.Click += ButtonDelete_Click;
            // Add the label, text box, and button to the form

            this.closeButton.BackColor = Color.Black;
            this.closeButton.ForeColor = Color.White;
            this.closeButton.Location = new Point(960, 30);
            this.closeButton.Size = new Size(30, 20);
            this.closeButton.TabIndex = 3;
            this.closeButton.Text = "X";
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.textBoxContent);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonDelete);


            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private async void ButtonDelete_Click(object sender, EventArgs e)
        {
            Console.WriteLine(this.textBoxContent.Text);
            NotesForm notesForm = NotesForm.ActiveForm as NotesForm;
            try
            {
                await _supabase
               .From<Note>()
               .Where(x => x.Title == this.NoteTitle).Where(x => x.UserId == notesForm.CurrentUserId)
               .Delete();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


            notesForm.Controls.Remove(this.Parent);
            notesForm.notesDictionary.Remove(this.NoteTitle);
            foreach (KeyValuePair<string, string> kvp in notesForm.notesDictionary)
            {
                Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
            }
            notesForm.PopulateNotesList();
            notesForm.Refresh();
        }
        public string Encrypt(string noteContent, string key)
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
            if (labelTitle.Text != "" && textBoxContent.Text != "" && !notesForm.notesDictionary.ContainsValue(this.textBoxContent.Text))
            {
                try
                {
                    var update = await _supabase
                    .From<Note>()
                    .Where(x => x.Title == this.NoteTitle).Where(x => x.UserId == notesForm.CurrentUserId)
                    .Set(x => x.Content, Encrypt(this.textBoxContent.Text, notesForm.CurrentUserId.ToString() ) )
                    .Update();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }


                notesForm.Controls.Remove(this.Parent);
                notesForm.notesDictionary[this.NoteTitle] = this.textBoxContent.Text;
                notesForm.PopulateNotesList();
                notesForm.Refresh();
            }
            else
            {
                MessageBox.Show("You must enter a non empty title , also check the note content to not be empty");
            }

        }
    }
}
