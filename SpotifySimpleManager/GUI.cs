using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Toolkit.Uwp.Notifications;
using Windows.UI.Notifications;
using Windows.Data.Xml.Dom;


namespace SpotifySimpleManager
{
    public partial class GUI : Form
    {
        private Steuerung dieSteuerung;
        private ReminderUI derReminder;
        private bool api_init;

        public GUI()
        {
            InitializeComponent();
            dieSteuerung = new Steuerung(this);
            derReminder = new ReminderUI(this);
        }

        public void ShowToast(string Message)
        {
            derReminder.Show(Message, true, 3000);
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

        public void Listbox_PaintAddedSongs(params int[] addedSongs)
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

        public void Listbox_PaintRemovedSongs(params int[] removedSongs)
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

        public void Listbox_AddItem(string item, int index)
        {
            ListViewItem v = lV_tracks.Items.Insert(index, item);
        }

        public int Listbox_AddItem(string item)
        {
            ListViewItem v = lV_tracks.Items.Add(item);
            return v.Index;
        }

        public void ReminderUI_Clicked()
        {
            //GUI Anzeigen, Commit ausführen? vllt mit ReminderUI.Status-Enum Art der Nachricht im ReminderUI übergeben?
        }

        private void GUI_Load(object sender, EventArgs e)
        {
            dieSteuerung.InitializeAPIAsync();
        }

        private void b_debugdump_Click(object sender, EventArgs e)
        {
            dieSteuerung.TracksAsDump();
        }

        private async void menu_commit_save_Click(object sender, EventArgs e)
        {
            await dieSteuerung.PerformCompare(); //Erstellen des Commits
            dieSteuerung.SaveCommit(); //Speichern des Commits
            dieSteuerung.TracksAsDump(); //Dumpen für Fortschrittsanzeige
        }

        private void menu_commit_load_Click(object sender, EventArgs e)
        {
            menu_commit_save.Enabled = false;
            DialogResult d = fileDialog_commit.ShowDialog();
            if (d != DialogResult.Cancel) //Fehlerquelle vllt
            {
                string selectedPath = fileDialog_commit.FileName;
                dieSteuerung.LoadCommit(selectedPath);
            }
        }

        private async void menu_playlist_laden_Click(object sender, EventArgs e)
        {
            if (api_init)
            {
                try
                {
                    await dieSteuerung.RefreshPlaylistDataAsync();
                    bool success = dieSteuerung.TracksToGUI();
                    bool gleich = await dieSteuerung.PerformCompare();
                    menu_commit_save.Enabled = !gleich;
                }
                catch (Exception ex)
                {
                    ShowMessage("Ein Fehler ist beim Laden aufgetreten:\n" + ex.Message);
                }

            }
        }

        private void menu_listener_starten_Click(object sender, EventArgs e)
        {
            dieSteuerung.StartPlaylistListener();
        }

        private void menu_listener_stoppen_Click(object sender, EventArgs e)
        {
            dieSteuerung.StopPlaylistListener();
        }

        private void b_debughour_Click(object sender, EventArgs e)
        {
            dieSteuerung.InvokeOnFullHour();
        }
    }
}
