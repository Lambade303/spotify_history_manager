namespace SpotifySimpleManager
{
    partial class ReminderUI
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
            this.lbl_ueberschrift = new System.Windows.Forms.Label();
            this.lbl_message = new System.Windows.Forms.Label();
            this.pB_bild = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pB_bild)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_ueberschrift
            // 
            this.lbl_ueberschrift.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ueberschrift.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lbl_ueberschrift.Location = new System.Drawing.Point(71, 9);
            this.lbl_ueberschrift.Name = "lbl_ueberschrift";
            this.lbl_ueberschrift.Size = new System.Drawing.Size(226, 23);
            this.lbl_ueberschrift.TabIndex = 0;
            this.lbl_ueberschrift.Text = "Spotify History Manager";
            this.lbl_ueberschrift.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_message
            // 
            this.lbl_message.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_message.Location = new System.Drawing.Point(75, 32);
            this.lbl_message.Name = "lbl_message";
            this.lbl_message.Size = new System.Drawing.Size(222, 53);
            this.lbl_message.TabIndex = 1;
            this.lbl_message.Text = "<<MESSAGE>>";
            this.lbl_message.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pB_bild
            // 
            this.pB_bild.Image = global::SpotifySimpleManager.Properties.Resources.spotify_logo;
            this.pB_bild.Location = new System.Drawing.Point(9, 17);
            this.pB_bild.Name = "pB_bild";
            this.pB_bild.Size = new System.Drawing.Size(60, 60);
            this.pB_bild.TabIndex = 2;
            this.pB_bild.TabStop = false;
            // 
            // ReminderUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Aquamarine;
            this.ClientSize = new System.Drawing.Size(309, 94);
            this.ControlBox = false;
            this.Controls.Add(this.pB_bild);
            this.Controls.Add(this.lbl_message);
            this.Controls.Add(this.lbl_ueberschrift);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ReminderUI";
            this.Opacity = 0.75D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Reminder";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Reminder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pB_bild)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_ueberschrift;
        private System.Windows.Forms.Label lbl_message;
        private System.Windows.Forms.PictureBox pB_bild;
    }
}