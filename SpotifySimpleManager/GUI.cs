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
        private List<string> tracks;
        private bool api_init;

        public GUI()
        {
            InitializeComponent();
            dieSteuerung = new Steuerung(this);

            tracks = new List<string>();
            lB_tracks.DataSource = tracks;
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
            tracks.Clear();
            tracks.AddRange(contents);
        }

        private void b_get_Click(object sender, EventArgs e)
        {
            if (api_init)
            {
                bool success = dieSteuerung.TracksToGUI();
                b_compare.Enabled = success;
            }
        }

        private void b_compare_Click(object sender, EventArgs e)
        {
            dieSteuerung.CompareRequest();
        }
    }
}
