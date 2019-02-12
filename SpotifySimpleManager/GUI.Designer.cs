namespace SpotifySimpleManager
{
    partial class GUI
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.lB_tracks = new System.Windows.Forms.ListBox();
            this.b_get = new System.Windows.Forms.Button();
            this.lbl_internet = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lB_tracks
            // 
            this.lB_tracks.FormattingEnabled = true;
            this.lB_tracks.Location = new System.Drawing.Point(12, 12);
            this.lB_tracks.Name = "lB_tracks";
            this.lB_tracks.Size = new System.Drawing.Size(209, 420);
            this.lB_tracks.TabIndex = 0;
            // 
            // b_get
            // 
            this.b_get.Location = new System.Drawing.Point(227, 12);
            this.b_get.Name = "b_get";
            this.b_get.Size = new System.Drawing.Size(95, 23);
            this.b_get.TabIndex = 1;
            this.b_get.Text = "Playlist laden";
            this.b_get.UseVisualStyleBackColor = true;
            this.b_get.Click += new System.EventHandler(this.b_get_Click);
            // 
            // lbl_internet
            // 
            this.lbl_internet.AutoSize = true;
            this.lbl_internet.Location = new System.Drawing.Point(237, 419);
            this.lbl_internet.Name = "lbl_internet";
            this.lbl_internet.Size = new System.Drawing.Size(85, 13);
            this.lbl_internet.TabIndex = 2;
            this.lbl_internet.Text = "<<Verbindung>>";
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbl_internet);
            this.Controls.Add(this.b_get);
            this.Controls.Add(this.lB_tracks);
            this.Name = "GUI";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.GUI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lB_tracks;
        private System.Windows.Forms.Button b_get;
        private System.Windows.Forms.Label lbl_internet;
    }
}

