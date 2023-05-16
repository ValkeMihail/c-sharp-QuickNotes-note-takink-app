using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace folder
{

    public partial class NotesForm : Form
    {

        public  Dictionary<string, string> notesDictionary = new Dictionary<string, string>();
        
        public Guid CurrentUserId { get; set; }
        private readonly Supabase.Client _supabase;
        public string Username;


       
        public NotesForm(Dictionary<string, string> userNotesDict, Guid currentUserId)
        {
            InitializeComponent();

            _supabase = new Supabase.Client("https://erlxhoijelsccfxiktwq.supabase.co", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImVybHhob2lqZWxzY2NmeGlrdHdxIiwicm9sZSI6ImFub24iLCJpYXQiOjE2ODA4MDAxNjQsImV4cCI6MTk5NjM3NjE2NH0.GmACZ332ohO4ccLgf-Ps-wsHjJW4lwzzjcf7x2Lk0pA");

            CurrentUserId = currentUserId;
            InitializeAsync(currentUserId.ToString());
            notesDictionary = userNotesDict;

         

            PopulateNotesList();
           
        }

        private async void InitializeAsync(string currentUserId)
        {
            try {
                var response = await _supabase.From<Users>().Where(x => x.id == currentUserId).Single();
                Username = response.username;
                this.Text = "QuickNote - " + Username;
            } catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
          

          
        }
        public void PopulateNotesList()
        {
          
            flowLayoutPanelNotes.Controls.Clear();

            foreach (KeyValuePair<string, string> note in notesDictionary)
            {
              
                NoteCardControl noteCard = new NoteCardControl();
                noteCard.Title = note.Key;
                noteCard.Content = note.Value;
                    
              
                noteCard.Tag = note.Key;

              
                noteCard.Click += NoteCard_Click;
                noteCard.Cursor = Cursors.Hand;
                
          
                flowLayoutPanelNotes.Controls.Add(noteCard);
            }


            flowLayoutPanelNotes.AutoScroll = true;
        }


        
        private void NoteCard_Click(object sender, EventArgs e)
        {

            NoteCardControl clickedNoteCard = sender as NoteCardControl;

            // Get the title and content of the clicked note
            string noteTitle = clickedNoteCard.Title;
            Console.WriteLine(noteTitle);
            string noteContent = clickedNoteCard.Content;
            Console.WriteLine(noteContent);
            // Create a new panel to host the NoteChange form
            try {
                Panel panelNoteChange = new Panel();

                panelNoteChange.BackColor = SystemColors.Control;
                panelNoteChange.Dock = DockStyle.Fill;
                panelNoteChange.BackColor = Color.Black;
                this.Controls.Add(panelNoteChange);

                // Create a new instance of the NoteChange form and add it to the panel
                NoteChangeForm noteChangeForm = new NoteChangeForm(noteTitle, noteContent);
                noteChangeForm.TopLevel = false;
                
                panelNoteChange.Controls.Add(noteChangeForm);
                Console.WriteLine(panelNoteChange.Controls.Contains(noteChangeForm));
                noteChangeForm.Visible = true;
                // Display the panel with the NoteChange form
                panelNoteChange.BringToFront();
            } catch(Exception ex) {
                Console.WriteLine(ex.Message);
            }
           

        }

        private void addNoteButton_Click(object sender, EventArgs e)
        {
            

            // Get the title and content of the clicked note
            string noteTitle = "";
            Console.WriteLine(noteTitle);
            string noteContent = "";
            Console.WriteLine(noteContent);
            // Create a new panel to host the NoteChange form
            try
            {
                Panel panelNoteChange = new Panel();

                panelNoteChange.BackColor = SystemColors.Control;
                panelNoteChange.Dock = DockStyle.Fill;
                panelNoteChange.BackColor = Color.Black;
                this.Controls.Add(panelNoteChange);

                // Create a new instance of the NoteChange form and add it to the panel
                NoteAddForm noteaddForm = new NoteAddForm(noteTitle, noteContent);
                noteaddForm.TopLevel = false;

                panelNoteChange.Controls.Add(noteaddForm);
                Console.WriteLine(panelNoteChange.Controls.Contains(noteaddForm));
                noteaddForm.Visible = true;
                // Display the panel with the NoteChange form
                panelNoteChange.BringToFront();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
