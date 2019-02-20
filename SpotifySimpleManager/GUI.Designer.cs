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
            this.b_get = new System.Windows.Forms.Button();
            this.lbl_internet = new System.Windows.Forms.Label();
            this.b_compare = new System.Windows.Forms.Button();
            this.b_debugdump = new System.Windows.Forms.Button();
            this.lV_tracks = new System.Windows.Forms.ListView();
            this.lV_cH_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lV_cH_status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.b_commit = new System.Windows.Forms.Button();
            this.menu_main = new System.Windows.Forms.MenuStrip();
            this.menu_commit = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_commit_load = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_commit_save = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menu_playlist = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_playlist_laden = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_main.SuspendLayout();
            this.SuspendLayout();
            // 
            // b_get
            // 
            this.b_get.Location = new System.Drawing.Point(693, 27);
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
            this.lbl_internet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lbl_internet.Location = new System.Drawing.Point(298, 452);
            this.lbl_internet.Name = "lbl_internet";
            this.lbl_internet.Size = new System.Drawing.Size(95, 13);
            this.lbl_internet.TabIndex = 2;
            this.lbl_internet.Text = "API-Überprüfung...";
            // 
            // b_compare
            // 
            this.b_compare.Enabled = false;
            this.b_compare.Location = new System.Drawing.Point(693, 56);
            this.b_compare.Name = "b_compare";
            this.b_compare.Size = new System.Drawing.Size(95, 23);
            this.b_compare.TabIndex = 3;
            this.b_compare.Text = "Vergleichen";
            this.b_compare.UseVisualStyleBackColor = true;
            this.b_compare.Click += new System.EventHandler(this.b_compare_Click);
            // 
            // b_debugdump
            // 
            this.b_debugdump.Location = new System.Drawing.Point(298, 426);
            this.b_debugdump.Name = "b_debugdump";
            this.b_debugdump.Size = new System.Drawing.Size(93, 23);
            this.b_debugdump.TabIndex = 5;
            this.b_debugdump.Text = "DEBUGDUMP";
            this.b_debugdump.UseVisualStyleBackColor = true;
            this.b_debugdump.Click += new System.EventHandler(this.b_debugdump_Click);
            // 
            // lV_tracks
            // 
            this.lV_tracks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lV_cH_name,
            this.lV_cH_status});
            this.lV_tracks.GridLines = true;
            this.lV_tracks.Location = new System.Drawing.Point(12, 42);
            this.lV_tracks.Name = "lV_tracks";
            this.lV_tracks.ShowItemToolTips = true;
            this.lV_tracks.Size = new System.Drawing.Size(280, 420);
            this.lV_tracks.TabIndex = 6;
            this.lV_tracks.UseCompatibleStateImageBehavior = false;
            this.lV_tracks.View = System.Windows.Forms.View.Details;
            // 
            // lV_cH_name
            // 
            this.lV_cH_name.Text = "Songname";
            this.lV_cH_name.Width = 210;
            // 
            // lV_cH_status
            // 
            this.lV_cH_status.Text = "Status";
            this.lV_cH_status.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.lV_cH_status.Width = 45;
            // 
            // b_commit
            // 
            this.b_commit.Enabled = false;
            this.b_commit.Location = new System.Drawing.Point(693, 85);
            this.b_commit.Name = "b_commit";
            this.b_commit.Size = new System.Drawing.Size(95, 23);
            this.b_commit.TabIndex = 7;
            this.b_commit.Text = "Commit";
            this.b_commit.UseVisualStyleBackColor = true;
            this.b_commit.Click += new System.EventHandler(this.b_commit_Click);
            // 
            // menu_main
            // 
            this.menu_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_commit,
            this.menu_playlist});
            this.menu_main.Location = new System.Drawing.Point(0, 0);
            this.menu_main.Name = "menu_main";
            this.menu_main.Size = new System.Drawing.Size(800, 24);
            this.menu_main.TabIndex = 8;
            this.menu_main.Text = "Menu";
            // 
            // menu_commit
            // 
            this.menu_commit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_commit_save,
            this.toolStripSeparator1,
            this.menu_commit_load});
            this.menu_commit.Name = "menu_commit";
            this.menu_commit.Size = new System.Drawing.Size(63, 20);
            this.menu_commit.Text = "Commit";
            // 
            // menu_commit_load
            // 
            this.menu_commit_load.Name = "menu_commit_load";
            this.menu_commit_load.Size = new System.Drawing.Size(224, 22);
            this.menu_commit_load.Text = "Commit laden und anzeigen";
            this.menu_commit_load.Click += new System.EventHandler(this.menu_commit_load_Click);
            // 
            // menu_commit_save
            // 
            this.menu_commit_save.Name = "menu_commit_save";
            this.menu_commit_save.Size = new System.Drawing.Size(224, 22);
            this.menu_commit_save.Text = "Commit abspeichern";
            this.menu_commit_save.Click += new System.EventHandler(this.menu_commit_save_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(221, 6);
            // 
            // menu_playlist
            // 
            this.menu_playlist.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_playlist_laden});
            this.menu_playlist.Name = "menu_playlist";
            this.menu_playlist.Size = new System.Drawing.Size(56, 20);
            this.menu_playlist.Text = "Playlist";
            // 
            // menu_playlist_laden
            // 
            this.menu_playlist_laden.Name = "menu_playlist_laden";
            this.menu_playlist_laden.Size = new System.Drawing.Size(180, 22);
            this.menu_playlist_laden.Text = "Playlist laden";
            this.menu_playlist_laden.Click += new System.EventHandler(this.menu_playlist_laden_Click);
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 474);
            this.Controls.Add(this.b_commit);
            this.Controls.Add(this.lV_tracks);
            this.Controls.Add(this.b_debugdump);
            this.Controls.Add(this.b_compare);
            this.Controls.Add(this.lbl_internet);
            this.Controls.Add(this.b_get);
            this.Controls.Add(this.menu_main);
            this.MainMenuStrip = this.menu_main;
            this.Name = "GUI";
            this.Text = "Spotify History";
            this.Load += new System.EventHandler(this.GUI_Load);
            this.menu_main.ResumeLayout(false);
            this.menu_main.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button b_get;
        private System.Windows.Forms.Label lbl_internet;
        private System.Windows.Forms.Button b_compare;
        private System.Windows.Forms.Button b_debugdump;
        private System.Windows.Forms.ListView lV_tracks;
        private System.Windows.Forms.ColumnHeader lV_cH_name;
        private System.Windows.Forms.ColumnHeader lV_cH_status;
        private System.Windows.Forms.Button b_commit;
        private System.Windows.Forms.MenuStrip menu_main;
        private System.Windows.Forms.ToolStripMenuItem menu_commit;
        private System.Windows.Forms.ToolStripMenuItem menu_commit_load;
        private System.Windows.Forms.ToolStripMenuItem menu_commit_save;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menu_playlist;
        private System.Windows.Forms.ToolStripMenuItem menu_playlist_laden;
    }
}

