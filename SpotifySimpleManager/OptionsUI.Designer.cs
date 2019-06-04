namespace SpotifySimpleManager
{
    partial class OptionsUI
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
            this.group_confjson = new System.Windows.Forms.GroupBox();
            this.tB_confjson_clientid = new System.Windows.Forms.TextBox();
            this.tB_confjson_clientsecret = new System.Windows.Forms.TextBox();
            this.tB_confjson_playlistid = new System.Windows.Forms.TextBox();
            this.tB_confjson_username = new System.Windows.Forms.TextBox();
            this.lbl_confjson_playlistid = new System.Windows.Forms.Label();
            this.lbl_confjson_clientsecret = new System.Windows.Forms.Label();
            this.lbl_confjson_clientid = new System.Windows.Forms.Label();
            this.lbl_confjson = new System.Windows.Forms.Label();
            this.lbl_configfile = new System.Windows.Forms.Label();
            this.tB_configfile = new System.Windows.Forms.TextBox();
            this.b_configfile_change = new System.Windows.Forms.Button();
            this.b_save = new System.Windows.Forms.Button();
            this.fileDialog_confjson = new System.Windows.Forms.OpenFileDialog();
            this.lbl_speicherort = new System.Windows.Forms.Label();
            this.tB_speicherort = new System.Windows.Forms.TextBox();
            this.b_unlock = new System.Windows.Forms.Button();
            this.b_commitspeicher_change = new System.Windows.Forms.Button();
            this.fileDialog_commitspeicher = new System.Windows.Forms.FolderBrowserDialog();
            this.group_confjson.SuspendLayout();
            this.SuspendLayout();
            // 
            // group_confjson
            // 
            this.group_confjson.Controls.Add(this.tB_confjson_clientid);
            this.group_confjson.Controls.Add(this.tB_confjson_clientsecret);
            this.group_confjson.Controls.Add(this.tB_confjson_playlistid);
            this.group_confjson.Controls.Add(this.tB_confjson_username);
            this.group_confjson.Controls.Add(this.lbl_confjson_playlistid);
            this.group_confjson.Controls.Add(this.lbl_confjson_clientsecret);
            this.group_confjson.Controls.Add(this.lbl_confjson_clientid);
            this.group_confjson.Controls.Add(this.lbl_confjson);
            this.group_confjson.Location = new System.Drawing.Point(15, 59);
            this.group_confjson.Name = "group_confjson";
            this.group_confjson.Size = new System.Drawing.Size(324, 146);
            this.group_confjson.TabIndex = 0;
            this.group_confjson.TabStop = false;
            this.group_confjson.Text = "Allgemeine Einstellungen (conf.json)";
            // 
            // tB_confjson_clientid
            // 
            this.tB_confjson_clientid.Location = new System.Drawing.Point(79, 53);
            this.tB_confjson_clientid.Name = "tB_confjson_clientid";
            this.tB_confjson_clientid.ReadOnly = true;
            this.tB_confjson_clientid.Size = new System.Drawing.Size(239, 20);
            this.tB_confjson_clientid.TabIndex = 7;
            this.tB_confjson_clientid.TextChanged += new System.EventHandler(this.lbl_TextChanged);
            // 
            // tB_confjson_clientsecret
            // 
            this.tB_confjson_clientsecret.Location = new System.Drawing.Point(79, 83);
            this.tB_confjson_clientsecret.Name = "tB_confjson_clientsecret";
            this.tB_confjson_clientsecret.ReadOnly = true;
            this.tB_confjson_clientsecret.Size = new System.Drawing.Size(239, 20);
            this.tB_confjson_clientsecret.TabIndex = 6;
            this.tB_confjson_clientsecret.TextChanged += new System.EventHandler(this.lbl_TextChanged);
            // 
            // tB_confjson_playlistid
            // 
            this.tB_confjson_playlistid.Location = new System.Drawing.Point(79, 113);
            this.tB_confjson_playlistid.Name = "tB_confjson_playlistid";
            this.tB_confjson_playlistid.ReadOnly = true;
            this.tB_confjson_playlistid.Size = new System.Drawing.Size(239, 20);
            this.tB_confjson_playlistid.TabIndex = 5;
            this.tB_confjson_playlistid.TextChanged += new System.EventHandler(this.lbl_TextChanged);
            // 
            // tB_confjson_username
            // 
            this.tB_confjson_username.Location = new System.Drawing.Point(79, 23);
            this.tB_confjson_username.Name = "tB_confjson_username";
            this.tB_confjson_username.ReadOnly = true;
            this.tB_confjson_username.Size = new System.Drawing.Size(239, 20);
            this.tB_confjson_username.TabIndex = 4;
            this.tB_confjson_username.TextChanged += new System.EventHandler(this.lbl_TextChanged);
            // 
            // lbl_confjson_playlistid
            // 
            this.lbl_confjson_playlistid.AutoSize = true;
            this.lbl_confjson_playlistid.Location = new System.Drawing.Point(6, 116);
            this.lbl_confjson_playlistid.Name = "lbl_confjson_playlistid";
            this.lbl_confjson_playlistid.Size = new System.Drawing.Size(56, 13);
            this.lbl_confjson_playlistid.TabIndex = 3;
            this.lbl_confjson_playlistid.Text = "Playlist-ID:";
            // 
            // lbl_confjson_clientsecret
            // 
            this.lbl_confjson_clientsecret.AutoSize = true;
            this.lbl_confjson_clientsecret.Location = new System.Drawing.Point(6, 86);
            this.lbl_confjson_clientsecret.Name = "lbl_confjson_clientsecret";
            this.lbl_confjson_clientsecret.Size = new System.Drawing.Size(70, 13);
            this.lbl_confjson_clientsecret.TabIndex = 2;
            this.lbl_confjson_clientsecret.Text = "Client-Secret:";
            // 
            // lbl_confjson_clientid
            // 
            this.lbl_confjson_clientid.AutoSize = true;
            this.lbl_confjson_clientid.Location = new System.Drawing.Point(6, 56);
            this.lbl_confjson_clientid.Name = "lbl_confjson_clientid";
            this.lbl_confjson_clientid.Size = new System.Drawing.Size(50, 13);
            this.lbl_confjson_clientid.TabIndex = 1;
            this.lbl_confjson_clientid.Text = "Client-ID:";
            // 
            // lbl_confjson
            // 
            this.lbl_confjson.AutoSize = true;
            this.lbl_confjson.Location = new System.Drawing.Point(6, 26);
            this.lbl_confjson.Name = "lbl_confjson";
            this.lbl_confjson.Size = new System.Drawing.Size(58, 13);
            this.lbl_confjson.TabIndex = 0;
            this.lbl_confjson.Text = "Username:";
            // 
            // lbl_configfile
            // 
            this.lbl_configfile.Location = new System.Drawing.Point(12, 33);
            this.lbl_configfile.Name = "lbl_configfile";
            this.lbl_configfile.Size = new System.Drawing.Size(55, 23);
            this.lbl_configfile.TabIndex = 1;
            this.lbl_configfile.Text = "conf.json:";
            this.lbl_configfile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tB_configfile
            // 
            this.tB_configfile.Location = new System.Drawing.Point(83, 35);
            this.tB_configfile.Name = "tB_configfile";
            this.tB_configfile.ReadOnly = true;
            this.tB_configfile.Size = new System.Drawing.Size(213, 20);
            this.tB_configfile.TabIndex = 2;
            this.tB_configfile.TextChanged += new System.EventHandler(this.lbl_TextChanged);
            // 
            // b_configfile_change
            // 
            this.b_configfile_change.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_configfile_change.Location = new System.Drawing.Point(302, 33);
            this.b_configfile_change.Name = "b_configfile_change";
            this.b_configfile_change.Size = new System.Drawing.Size(37, 23);
            this.b_configfile_change.TabIndex = 3;
            this.b_configfile_change.Text = ". . .";
            this.b_configfile_change.UseVisualStyleBackColor = true;
            this.b_configfile_change.Click += new System.EventHandler(this.b_configfile_change_Click);
            // 
            // b_save
            // 
            this.b_save.Location = new System.Drawing.Point(244, 211);
            this.b_save.Name = "b_save";
            this.b_save.Size = new System.Drawing.Size(95, 23);
            this.b_save.TabIndex = 4;
            this.b_save.Text = "Speichern";
            this.b_save.UseVisualStyleBackColor = true;
            this.b_save.Click += new System.EventHandler(this.b_save_Click);
            // 
            // fileDialog_confjson
            // 
            this.fileDialog_confjson.FileName = "conf.json";
            this.fileDialog_confjson.InitialDirectory = ".";
            // 
            // lbl_speicherort
            // 
            this.lbl_speicherort.Location = new System.Drawing.Point(12, 9);
            this.lbl_speicherort.Name = "lbl_speicherort";
            this.lbl_speicherort.Size = new System.Drawing.Size(65, 23);
            this.lbl_speicherort.TabIndex = 5;
            this.lbl_speicherort.Text = "Speicherort:";
            this.lbl_speicherort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tB_speicherort
            // 
            this.tB_speicherort.Location = new System.Drawing.Point(83, 7);
            this.tB_speicherort.Name = "tB_speicherort";
            this.tB_speicherort.ReadOnly = true;
            this.tB_speicherort.Size = new System.Drawing.Size(213, 20);
            this.tB_speicherort.TabIndex = 8;
            this.tB_speicherort.TextChanged += new System.EventHandler(this.lbl_TextChanged);
            // 
            // b_unlock
            // 
            this.b_unlock.Location = new System.Drawing.Point(15, 211);
            this.b_unlock.Name = "b_unlock";
            this.b_unlock.Size = new System.Drawing.Size(157, 23);
            this.b_unlock.TabIndex = 9;
            this.b_unlock.Text = "Entsperren (!)";
            this.b_unlock.UseVisualStyleBackColor = true;
            this.b_unlock.Click += new System.EventHandler(this.b_unlock_Click);
            // 
            // b_commitspeicher_change
            // 
            this.b_commitspeicher_change.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_commitspeicher_change.Location = new System.Drawing.Point(302, 5);
            this.b_commitspeicher_change.Name = "b_commitspeicher_change";
            this.b_commitspeicher_change.Size = new System.Drawing.Size(37, 23);
            this.b_commitspeicher_change.TabIndex = 10;
            this.b_commitspeicher_change.Text = ". . .";
            this.b_commitspeicher_change.UseVisualStyleBackColor = true;
            this.b_commitspeicher_change.Click += new System.EventHandler(this.b_commitspeicher_change_Click);
            // 
            // OptionsUI
            // 
            this.AcceptButton = this.b_save;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 285);
            this.Controls.Add(this.b_commitspeicher_change);
            this.Controls.Add(this.b_unlock);
            this.Controls.Add(this.tB_speicherort);
            this.Controls.Add(this.lbl_speicherort);
            this.Controls.Add(this.b_save);
            this.Controls.Add(this.b_configfile_change);
            this.Controls.Add(this.tB_configfile);
            this.Controls.Add(this.lbl_configfile);
            this.Controls.Add(this.group_confjson);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsUI";
            this.Text = "Optionen";
            this.group_confjson.ResumeLayout(false);
            this.group_confjson.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox group_confjson;
        private System.Windows.Forms.Label lbl_configfile;
        private System.Windows.Forms.TextBox tB_configfile;
        private System.Windows.Forms.Button b_configfile_change;
        private System.Windows.Forms.Label lbl_confjson;
        private System.Windows.Forms.Label lbl_confjson_clientid;
        private System.Windows.Forms.Label lbl_confjson_clientsecret;
        private System.Windows.Forms.Label lbl_confjson_playlistid;
        private System.Windows.Forms.TextBox tB_confjson_clientid;
        private System.Windows.Forms.TextBox tB_confjson_clientsecret;
        private System.Windows.Forms.TextBox tB_confjson_playlistid;
        private System.Windows.Forms.TextBox tB_confjson_username;
        private System.Windows.Forms.Button b_save;
        private System.Windows.Forms.OpenFileDialog fileDialog_confjson;
        private System.Windows.Forms.Label lbl_speicherort;
        private System.Windows.Forms.TextBox tB_speicherort;
        private System.Windows.Forms.Button b_unlock;
        private System.Windows.Forms.Button b_commitspeicher_change;
        private System.Windows.Forms.FolderBrowserDialog fileDialog_commitspeicher;
    }
}