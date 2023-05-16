using System.Drawing;
using System.Windows.Forms;

namespace folder
{

    public class NoteCardControl : Panel
    {
        public Label labelTitle;
        private TextBox textBoxContent;

        public NoteCardControl()
        {
            InitializeComponent();
        }

        public string Title
        {
            get { return labelTitle.Text; }
            set { labelTitle.Text = value; }
        }

        public string Content
        {
            get { return textBoxContent.Text; }
            set { textBoxContent.Text = value; }
        }

        private void InitializeComponent()
        {
            this.labelTitle = new System.Windows.Forms.Label();
            this.textBoxContent = new System.Windows.Forms.TextBox();
            this.SuspendLayout();

            // Set the properties of the note card control
            this.BackColor = SystemColors.ControlLightLight;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Margin = new Padding(10);
            this.Size = new Size(750, 200);
            this.BackColor = Color.Black;

            // Set the properties of the label that displays the note title
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.labelTitle.Location = new Point(10, 10);
            this.labelTitle.MaximumSize = new Size(160, 0);
            this.labelTitle.TabIndex = 0;

            // Set the properties of the text box that displays the note content
            this.textBoxContent.BorderStyle = BorderStyle;
            this.textBoxContent.Location = new Point(10, 55);
            this.textBoxContent.Multiline = true;
            this.textBoxContent.BackColor = Color.Black;
            this.textBoxContent.ForeColor = Color.White;
            this.textBoxContent.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.textBoxContent.Size = new Size(500, 100);
            this.textBoxContent.TabIndex = 1;
            this.textBoxContent.ReadOnly = true;
            // Add the label and text box to the note card control
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.textBoxContent);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
