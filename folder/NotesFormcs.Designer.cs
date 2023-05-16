using System.Drawing;

namespace folder
{
    partial class NotesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotesForm));
            this.panelNoteCards = new System.Windows.Forms.Panel();
            this.flowLayoutPanelNotes = new System.Windows.Forms.FlowLayoutPanel();
            this.addNoteButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.panelNoteCards.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelNoteCards
            // 
            this.panelNoteCards.BackColor = System.Drawing.Color.DimGray;
            this.panelNoteCards.Controls.Add(this.flowLayoutPanelNotes);
            this.panelNoteCards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelNoteCards.Location = new System.Drawing.Point(0, 0);
            this.panelNoteCards.Name = "panelNoteCards";
            this.panelNoteCards.Size = new System.Drawing.Size(1366, 800);
            this.panelNoteCards.TabIndex = 0;
            // 
            // flowLayoutPanelNotes
            // 
            this.flowLayoutPanelNotes.AutoScroll = true;
            this.flowLayoutPanelNotes.BackColor = System.Drawing.Color.DimGray;
            this.flowLayoutPanelNotes.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.flowLayoutPanelNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelNotes.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.flowLayoutPanelNotes.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelNotes.Name = "flowLayoutPanelNotes";
            this.flowLayoutPanelNotes.Size = new System.Drawing.Size(1366, 800);
            this.flowLayoutPanelNotes.TabIndex = 0;
            // 
            // addNoteButton
            // 
            this.addNoteButton.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.addNoteButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addNoteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addNoteButton.Location = new System.Drawing.Point(1100, 105);
            this.addNoteButton.Name = "addNoteButton";
            this.addNoteButton.Size = new System.Drawing.Size(130, 38);
            this.addNoteButton.TabIndex = 6;
            this.addNoteButton.TabStop = false;
            this.addNoteButton.Text = "New Note";
            this.addNoteButton.UseVisualStyleBackColor = false;
            this.addNoteButton.Click += new System.EventHandler(this.addNoteButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.Black;
            this.closeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeButton.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.Location = new System.Drawing.Point(1300, 24);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(38, 38);
            this.closeButton.TabIndex = 7;
            this.closeButton.TabStop = false;
            this.closeButton.Text = "X";
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // NotesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1366, 800);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.addNoteButton);
            this.Controls.Add(this.panelNoteCards);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NotesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NotesFormcs";
            this.panelNoteCards.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelNoteCards;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelNotes;
        private System.Windows.Forms.Button addNoteButton;
        private System.Windows.Forms.Button closeButton;
    }
}