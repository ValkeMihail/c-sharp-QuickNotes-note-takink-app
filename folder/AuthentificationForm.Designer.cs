namespace folder
{
    partial class AuthentificationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuthentificationForm));
            this.tabControlAuth = new System.Windows.Forms.TabControl();
            this.tabPageRegister = new System.Windows.Forms.TabPage();
            this.panelRegister = new System.Windows.Forms.Panel();
            this.tabPageLogin = new System.Windows.Forms.TabPage();
            this.panelLogin = new System.Windows.Forms.Panel();
            this.closeButton = new System.Windows.Forms.Button();
            this.tabControlAuth.SuspendLayout();
            this.tabPageRegister.SuspendLayout();
            this.tabPageLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlAuth
            // 
            this.tabControlAuth.Controls.Add(this.tabPageRegister);
            this.tabControlAuth.Controls.Add(this.tabPageLogin);
            this.tabControlAuth.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabControlAuth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlAuth.Location = new System.Drawing.Point(2, 71);
            this.tabControlAuth.Margin = new System.Windows.Forms.Padding(0);
            this.tabControlAuth.Name = "tabControlAuth";
            this.tabControlAuth.SelectedIndex = 0;
            this.tabControlAuth.Size = new System.Drawing.Size(1338, 706);
            this.tabControlAuth.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlAuth.TabIndex = 0;
            this.tabControlAuth.SelectedIndexChanged += new System.EventHandler(this.tabControlAuth_SelectedIndexChanged);
            // 
            // tabPageRegister
            // 
            this.tabPageRegister.BackColor = System.Drawing.Color.DimGray;
            this.tabPageRegister.Controls.Add(this.panelRegister);
            this.tabPageRegister.ForeColor = System.Drawing.Color.Transparent;
            this.tabPageRegister.Location = new System.Drawing.Point(4, 34);
            this.tabPageRegister.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageRegister.Name = "tabPageRegister";
            this.tabPageRegister.Size = new System.Drawing.Size(1330, 668);
            this.tabPageRegister.TabIndex = 0;
            this.tabPageRegister.Text = "Register";
            // 
            // panelRegister
            // 
            this.panelRegister.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRegister.Location = new System.Drawing.Point(0, 0);
            this.panelRegister.Name = "panelRegister";
            this.panelRegister.Size = new System.Drawing.Size(1330, 668);
            this.panelRegister.TabIndex = 0;
            // 
            // tabPageLogin
            // 
            this.tabPageLogin.BackColor = System.Drawing.Color.DimGray;
            this.tabPageLogin.Controls.Add(this.panelLogin);
            this.tabPageLogin.ForeColor = System.Drawing.Color.White;
            this.tabPageLogin.ImeMode = System.Windows.Forms.ImeMode.On;
            this.tabPageLogin.Location = new System.Drawing.Point(4, 34);
            this.tabPageLogin.Name = "tabPageLogin";
            this.tabPageLogin.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLogin.Size = new System.Drawing.Size(1330, 668);
            this.tabPageLogin.TabIndex = 1;
            this.tabPageLogin.Text = "Login";
            // 
            // panelLogin
            // 
            this.panelLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLogin.Location = new System.Drawing.Point(3, 3);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Size = new System.Drawing.Size(1324, 662);
            this.panelLogin.TabIndex = 0;
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.Transparent;
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.closeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.closeButton.ForeColor = System.Drawing.SystemColors.Control;
            this.closeButton.Location = new System.Drawing.Point(1286, 12);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(42, 36);
            this.closeButton.TabIndex = 6;
            this.closeButton.Text = "X";
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // AuthentificationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1340, 786);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.tabControlAuth);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AuthentificationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QuickNote";
            this.Load += new System.EventHandler(this.AuthentificationForm_Load);
            this.tabControlAuth.ResumeLayout(false);
            this.tabPageRegister.ResumeLayout(false);
            this.tabPageLogin.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TabControl tabControlAuth;
        public System.Windows.Forms.TabPage tabPageRegister;
        public System.Windows.Forms.TabPage tabPageLogin;
        private System.Windows.Forms.Panel panelRegister;
        private System.Windows.Forms.Panel panelLogin;
        private System.Windows.Forms.Button closeButton;
    }
}