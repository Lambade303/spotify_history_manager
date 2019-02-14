using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpotifySimpleManager
{
    public partial class GUI : Form
    {
        private Steuerung dieSteuerung;
        private bool api_init;

        public GUI()
        {
            InitializeComponent();
            dieSteuerung = new Steuerung(this);
        }

        private void GUI_Load(object sender, EventArgs e)
        {
            dieSteuerung.InitializeAPIAsync();
        }

        public void ShowMessage(string Message)
        {
            MessageBox.Show(Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void SetInitSuccess(bool success)
        {
            lbl_internet.Text = success ? "Keine API-Fehler" : "API-Fehler!";
            lbl_internet.ForeColor = success ? Color.DarkGreen : Color.DarkRed;
            api_init = success;
        }

        public void SetListBoxContent(string[] contents)
        {
            lB_tracks.Items.Clear();
            lB_tracks.Items.AddRange(contents);
        }

        private async void b_get_Click(object sender, EventArgs e)
        {
            if (api_init)
            {
                await dieSteuerung.RefreshPlaylistDataAsync();

                bool success = dieSteuerung.TracksToGUI();
                b_compare.Enabled = success;

            }
        }

        private void b_compare_Click(object sender, EventArgs e)
        {
            dieSteuerung.CompareRequest();
        }

        private void b_debugdump_Click(object sender, EventArgs e)
        {
            dieSteuerung.TracksAsDump();
        }
    }
}
