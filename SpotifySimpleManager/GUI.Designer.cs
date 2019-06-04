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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GUI));
            this.lbl_internet = new System.Windows.Forms.Label();
            this.b_debugdump = new System.Windows.Forms.Button();
            this.lV_tracks = new System.Windows.Forms.ListView();
            this.lV_cH_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lV_cH_status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menu_main = new System.Windows.Forms.MenuStrip();
            this.menu_commit = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_commit_save = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_commit_separator = new System.Windows.Forms.ToolStripSeparator();
            this.menu_commit_load = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_playlist = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_playlist_laden = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_playlist_refresh = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_listener = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_listener_starten = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_listener_stoppen = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_extras = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_extras_optionen = new System.Windows.Forms.ToolStripMenuItem();
            this.fileDialog_commit = new System.Windows.Forms.OpenFileDialog();
            this.b_debughour = new System.Windows.Forms.Button();
            this.lbl_playlist_Name = new System.Windows.Forms.Label();
            this.lbl_playlist_author = new System.Windows.Forms.Label();
            this.lbl_playlist_songanz = new System.Windows.Forms.Label();
            this.group_debug = new System.Windows.Forms.GroupBox();
            this.b_debug_initapi = new System.Windows.Forms.Button();
            this.group_playlist = new System.Windows.Forms.GroupBox();
            this.lbl_playlist_access = new System.Windows.Forms.Label();
            this.lbl_diffindicator = new System.Windows.Forms.Label();
            this.pB_api_loading = new System.Windows.Forms.PictureBox();
            this._infoIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.menu_main.SuspendLayout();
            this.group_debug.SuspendLayout();
            this.group_playlist.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pB_api_loading)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_internet
            // 
            this.lbl_internet.AutoSize = true;
            this.lbl_internet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lbl_internet.Location = new System.Drawing.Point(12, 24);
            this.lbl_internet.Name = "lbl_internet";
            this.lbl_internet.Size = new System.Drawing.Size(95, 13);
            this.lbl_internet.TabIndex = 2;
            this.lbl_internet.Text = "API-Überprüfung...";
            // 
            // b_debugdump
            // 
            this.b_debugdump.Location = new System.Drawing.Point(6, 48);
            this.b_debugdump.Name = "b_debugdump";
            this.b_debugdump.Size = new System.Drawing.Size(93, 23);
            this.b_debugdump.TabIndex = 5;
            this.b_debugdump.Text = "Liste Dumpen";
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
            // menu_main
            // 
            this.menu_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_commit,
            this.menu_playlist,
            this.menu_listener,
            this.menu_extras});
            this.menu_main.Location = new System.Drawing.Point(0, 0);
            this.menu_main.Name = "menu_main";
            this.menu_main.Size = new System.Drawing.Size(419, 24);
            this.menu_main.TabIndex = 8;
            this.menu_main.Text = "Menu";
            // 
            // menu_commit
            // 
            this.menu_commit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_commit_save,
            this.menu_commit_separator,
            this.menu_commit_load});
            this.menu_commit.Name = "menu_commit";
            this.menu_commit.Size = new System.Drawing.Size(63, 20);
            this.menu_commit.Text = "Commit";
            // 
            // menu_commit_save
            // 
            this.menu_commit_save.Enabled = false;
            this.menu_commit_save.Name = "menu_commit_save";
            this.menu_commit_save.Size = new System.Drawing.Size(224, 22);
            this.menu_commit_save.Text = "Commit abspeichern";
            this.menu_commit_save.Click += new System.EventHandler(this.menu_commit_save_Click);
            // 
            // menu_commit_separator
            // 
            this.menu_commit_separator.Name = "menu_commit_separator";
            this.menu_commit_separator.Size = new System.Drawing.Size(221, 6);
            // 
            // menu_commit_load
            // 
            this.menu_commit_load.Name = "menu_commit_load";
            this.menu_commit_load.Size = new System.Drawing.Size(224, 22);
            this.menu_commit_load.Text = "Commit laden und anzeigen";
            this.menu_commit_load.Click += new System.EventHandler(this.menu_commit_load_Click);
            // 
            // menu_playlist
            // 
            this.menu_playlist.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_playlist_laden,
            this.menu_playlist_refresh});
            this.menu_playlist.Name = "menu_playlist";
            this.menu_playlist.Size = new System.Drawing.Size(56, 20);
            this.menu_playlist.Text = "Playlist";
            // 
            // menu_playlist_laden
            // 
            this.menu_playlist_laden.Name = "menu_playlist_laden";
            this.menu_playlist_laden.Size = new System.Drawing.Size(231, 22);
            this.menu_playlist_laden.Text = "Playlist laden und vergleichen";
            this.menu_playlist_laden.Click += new System.EventHandler(this.menu_playlist_laden_Click);
            // 
            // menu_playlist_refresh
            // 
            this.menu_playlist_refresh.Name = "menu_playlist_refresh";
            this.menu_playlist_refresh.Size = new System.Drawing.Size(231, 22);
            this.menu_playlist_refresh.Text = "Playlist-Daten refreshen (!)";
            this.menu_playlist_refresh.Click += new System.EventHandler(this.menu_playlist_refresh_Click);
            // 
            // menu_listener
            // 
            this.menu_listener.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_listener_starten,
            this.menu_listener_stoppen});
            this.menu_listener.Name = "menu_listener";
            this.menu_listener.Size = new System.Drawing.Size(60, 20);
            this.menu_listener.Text = "Listener";
            // 
            // menu_listener_starten
            // 
            this.menu_listener_starten.Name = "menu_listener_starten";
            this.menu_listener_starten.Size = new System.Drawing.Size(162, 22);
            this.menu_listener_starten.Text = "Listener Starten";
            this.menu_listener_starten.Click += new System.EventHandler(this.menu_listener_starten_Click);
            // 
            // menu_listener_stoppen
            // 
            this.menu_listener_stoppen.Name = "menu_listener_stoppen";
            this.menu_listener_stoppen.Size = new System.Drawing.Size(162, 22);
            this.menu_listener_stoppen.Text = "Listener Stoppen";
            this.menu_listener_stoppen.Click += new System.EventHandler(this.menu_listener_stoppen_Click);
            // 
            // menu_extras
            // 
            this.menu_extras.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_extras_optionen});
            this.menu_extras.Name = "menu_extras";
            this.menu_extras.Size = new System.Drawing.Size(49, 20);
            this.menu_extras.Text = "Extras";
            // 
            // menu_extras_optionen
            // 
            this.menu_extras_optionen.Name = "menu_extras_optionen";
            this.menu_extras_optionen.Size = new System.Drawing.Size(124, 22);
            this.menu_extras_optionen.Text = "Optionen";
            this.menu_extras_optionen.Click += new System.EventHandler(this.menu_extras_optionen_Click);
            // 
            // fileDialog_commit
            // 
            this.fileDialog_commit.DefaultExt = "shm";
            this.fileDialog_commit.Filter = "Commit-Dateien|c_*.shm";
            this.fileDialog_commit.InitialDirectory = "%USERPROFILE%/Documents/SpotifyHistoryManager";
            // 
            // b_debughour
            // 
            this.b_debughour.Location = new System.Drawing.Point(6, 19);
            this.b_debughour.Name = "b_debughour";
            this.b_debughour.Size = new System.Drawing.Size(93, 23);
            this.b_debughour.TabIndex = 9;
            this.b_debughour.Text = "Debug/FullHour";
            this.b_debughour.UseVisualStyleBackColor = true;
            this.b_debughour.Click += new System.EventHandler(this.b_debughour_Click);
            // 
            // lbl_playlist_Name
            // 
            this.lbl_playlist_Name.Location = new System.Drawing.Point(6, 32);
            this.lbl_playlist_Name.Name = "lbl_playlist_Name";
            this.lbl_playlist_Name.Size = new System.Drawing.Size(97, 41);
            this.lbl_playlist_Name.TabIndex = 10;
            this.lbl_playlist_Name.Text = " ";
            this.lbl_playlist_Name.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_playlist_author
            // 
            this.lbl_playlist_author.Location = new System.Drawing.Point(6, 73);
            this.lbl_playlist_author.Name = "lbl_playlist_author";
            this.lbl_playlist_author.Size = new System.Drawing.Size(97, 15);
            this.lbl_playlist_author.TabIndex = 11;
            this.lbl_playlist_author.Text = " ";
            this.lbl_playlist_author.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_playlist_songanz
            // 
            this.lbl_playlist_songanz.Location = new System.Drawing.Point(6, 88);
            this.lbl_playlist_songanz.Name = "lbl_playlist_songanz";
            this.lbl_playlist_songanz.Size = new System.Drawing.Size(97, 15);
            this.lbl_playlist_songanz.TabIndex = 12;
            this.lbl_playlist_songanz.Text = " ";
            this.lbl_playlist_songanz.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // group_debug
            // 
            this.group_debug.Controls.Add(this.b_debug_initapi);
            this.group_debug.Controls.Add(this.b_debughour);
            this.group_debug.Controls.Add(this.b_debugdump);
            this.group_debug.Location = new System.Drawing.Point(298, 337);
            this.group_debug.Name = "group_debug";
            this.group_debug.Size = new System.Drawing.Size(109, 125);
            this.group_debug.TabIndex = 13;
            this.group_debug.TabStop = false;
            this.group_debug.Text = "DEBUG";
            // 
            // b_debug_initapi
            // 
            this.b_debug_initapi.Location = new System.Drawing.Point(6, 77);
            this.b_debug_initapi.Name = "b_debug_initapi";
            this.b_debug_initapi.Size = new System.Drawing.Size(93, 23);
            this.b_debug_initapi.TabIndex = 10;
            this.b_debug_initapi.Text = "INITAPI";
            this.b_debug_initapi.UseVisualStyleBackColor = true;
            this.b_debug_initapi.Click += new System.EventHandler(this.b_debug_initapi_Click);
            // 
            // group_playlist
            // 
            this.group_playlist.Controls.Add(this.lbl_playlist_access);
            this.group_playlist.Controls.Add(this.lbl_playlist_Name);
            this.group_playlist.Controls.Add(this.lbl_playlist_author);
            this.group_playlist.Controls.Add(this.lbl_playlist_songanz);
            this.group_playlist.Location = new System.Drawing.Point(298, 42);
            this.group_playlist.Name = "group_playlist";
            this.group_playlist.Size = new System.Drawing.Size(109, 145);
            this.group_playlist.TabIndex = 14;
            this.group_playlist.TabStop = false;
            this.group_playlist.Text = "Playlist-Info";
            // 
            // lbl_playlist_access
            // 
            this.lbl_playlist_access.Location = new System.Drawing.Point(6, 127);
            this.lbl_playlist_access.Name = "lbl_playlist_access";
            this.lbl_playlist_access.Size = new System.Drawing.Size(97, 15);
            this.lbl_playlist_access.TabIndex = 13;
            this.lbl_playlist_access.Text = " ";
            this.lbl_playlist_access.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_diffindicator
            // 
            this.lbl_diffindicator.ForeColor = System.Drawing.Color.Black;
            this.lbl_diffindicator.Location = new System.Drawing.Point(133, 24);
            this.lbl_diffindicator.Name = "lbl_diffindicator";
            this.lbl_diffindicator.Size = new System.Drawing.Size(159, 13);
            this.lbl_diffindicator.TabIndex = 15;
            this.lbl_diffindicator.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pB_api_loading
            // 
            this.pB_api_loading.Image = global::SpotifySimpleManager.Properties.Resources.loading;
            this.pB_api_loading.Location = new System.Drawing.Point(111, 21);
            this.pB_api_loading.Name = "pB_api_loading";
            this.pB_api_loading.Size = new System.Drawing.Size(16, 16);
            this.pB_api_loading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pB_api_loading.TabIndex = 16;
            this.pB_api_loading.TabStop = false;
            // 
            // _infoIcon
            // 
            this._infoIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("_infoIcon.Icon")));
            this._infoIcon.Text = "Spotify History Manager";
            this._infoIcon.Visible = true;
            this._infoIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this._infoIcon_MouseDoubleClick);
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(419, 474);
            this.Controls.Add(this.pB_api_loading);
            this.Controls.Add(this.lbl_diffindicator);
            this.Controls.Add(this.group_playlist);
            this.Controls.Add(this.group_debug);
            this.Controls.Add(this.lV_tracks);
            this.Controls.Add(this.lbl_internet);
            this.Controls.Add(this.menu_main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu_main;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(435, 513);
            this.MinimumSize = new System.Drawing.Size(435, 513);
            this.Name = "GUI";
            this.Text = "Spotify History";
            this.Load += new System.EventHandler(this.GUI_Load);
            this.SizeChanged += new System.EventHandler(this.GUI_SizeChanged);
            this.menu_main.ResumeLayout(false);
            this.menu_main.PerformLayout();
            this.group_debug.ResumeLayout(false);
            this.group_playlist.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pB_api_loading)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl_internet;
        private System.Windows.Forms.Button b_debugdump;
        private System.Windows.Forms.ListView lV_tracks;
        private System.Windows.Forms.ColumnHeader lV_cH_name;
        private System.Windows.Forms.ColumnHeader lV_cH_status;
        private System.Windows.Forms.MenuStrip menu_main;
        private System.Windows.Forms.ToolStripMenuItem menu_commit;
        private System.Windows.Forms.ToolStripMenuItem menu_commit_load;
        private System.Windows.Forms.ToolStripMenuItem menu_commit_save;
        private System.Windows.Forms.ToolStripSeparator menu_commit_separator;
        private System.Windows.Forms.ToolStripMenuItem menu_playlist;
        private System.Windows.Forms.ToolStripMenuItem menu_playlist_laden;
        private System.Windows.Forms.ToolStripMenuItem menu_listener;
        private System.Windows.Forms.ToolStripMenuItem menu_listener_starten;
        private System.Windows.Forms.ToolStripMenuItem menu_listener_stoppen;
        private System.Windows.Forms.OpenFileDialog fileDialog_commit;
        private System.Windows.Forms.Button b_debughour;
        private System.Windows.Forms.Label lbl_playlist_Name;
        private System.Windows.Forms.Label lbl_playlist_author;
        private System.Windows.Forms.Label lbl_playlist_songanz;
        private System.Windows.Forms.GroupBox group_debug;
        private System.Windows.Forms.GroupBox group_playlist;
        private System.Windows.Forms.ToolStripMenuItem menu_playlist_refresh;
        private System.Windows.Forms.Label lbl_playlist_access;
        private System.Windows.Forms.Label lbl_diffindicator;
        private System.Windows.Forms.ToolStripMenuItem menu_extras;
        private System.Windows.Forms.ToolStripMenuItem menu_extras_optionen;
        private System.Windows.Forms.Button b_debug_initapi;
        private System.Windows.Forms.PictureBox pB_api_loading;
        private System.Windows.Forms.NotifyIcon _infoIcon;
    }
}

