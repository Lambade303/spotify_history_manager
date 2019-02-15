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

        public void Listbox_SetContent(string[] contents)
        {
            lV_tracks.Items.Clear();
            ListViewItem[] contents_listview = new ListViewItem[contents.Length];
            for (int i = 0; i < contents_listview.Length; i++)
            {
                contents_listview[i] = new ListViewItem(contents[i]);
            }
            lV_tracks.Items.AddRange(contents_listview);
        }

        public void Listbox_PaintAddedSongs(int[] addedSongs)
        {
            for (int i = 0; i < addedSongs.Length; i++)
            {
                ListViewItem L = lV_tracks.Items[addedSongs[i]];
                //Farbe
                L.BackColor = Color.ForestGreen;
                L.ForeColor = Color.White;
                //Anzeige (Status)
                L.SubItems.Add("ADD");
            }
        }

        public void Listbox_PaintRemovedSongs(int[] removedSongs)
        {
            for (int i = 0; i < removedSongs.Length; i++)
            {
                ListViewItem L = lV_tracks.Items[removedSongs[i]];
                //Farbe
                L.BackColor = Color.Red;
                //Anzeige (Status)
                L.SubItems.Add("REM");
            }
        }

        public int Listbox_AddItem(string item, int index)
        {
            ListViewItem v = lV_tracks.Items.Insert(index, item);
            return v.Index;
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
            dieSteuerung.PerformCompare();
        }

        private void b_debugdump_Click(object sender, EventArgs e)
        {
            dieSteuerung.TracksAsDump();
        }
    }
}
