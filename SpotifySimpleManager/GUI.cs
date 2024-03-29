﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SpotifySimpleManager
{
    public enum GUIMode
    {
        Diff = 0,
        Load = 1,
        Lock = 2,
        BrokenDiff = 3,
        Hidden = 4,
    }

    public partial class GUI : Form
    {
        private Steuerung dieSteuerung;
        private ReminderUI derReminder;

        private GUIMode derModus;

        private bool api_init;
        private bool shadowMode;
        private int diff_add_songs;
        private int diff_rem_songs;

        public GUI(bool shadowMode)
        {
            InitializeComponent();

            dieSteuerung = new Steuerung(this);
            derReminder = new ReminderUI(this);

            this.shadowMode = shadowMode;
            initShadowMode();
        }

        public void ShowToast(string Message)
        {
            derReminder.Show(Message, true, 3000);
        }

        public void ShowMessage(string Message)
        {
            MessageBox.Show(this, Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void SetInitSuccess(bool success)
        {
            lbl_internet.Text = success ? "Keine API-Fehler" : "API-Fehler!";
            lbl_internet.ForeColor = success ? Color.DarkGreen : Color.DarkRed;
            ShowLoadingIcon(!success);
            api_init = success;
        }

        public void ChangeMode(GUIMode newMode)
        {
            FontStyle fs;

            switch (newMode)
            {
                case GUIMode.Diff:
                    {
                        group_playlist.Text = "Playlist-Info";
                        fs = FontStyle.Regular;
                        if (derModus == GUIMode.Lock)
                        {
                            setGUILock(false);
                            setGUIMenuLock(false);
                        }
                    }
                    break;
                case GUIMode.Load:
                    {
                        group_playlist.Text = "(LOAD) Playlist-Info";
                        fs = FontStyle.Italic;
                        if (derModus == GUIMode.Lock)
                        {
                            setGUILock(false);
                            setGUIMenuLock(false);
                        }
                    }
                    break;
                case GUIMode.Lock:
                    {
                        //Alles sperren
                        setGUILock(true);
                        setGUIMenuLock(true);
                        fs = FontStyle.Strikeout;
                    }
                    break;
                case GUIMode.BrokenDiff:
                    {
                        setGUILock(true);
                        setGUIMenuLock(false);
                        fs = FontStyle.Strikeout;
                    }
                    break;
                case GUIMode.Hidden:
                    {
                        setHiddenStatus(true);
                        fs = FontStyle.Regular;
                    }
                    break;
                default:
                    fs = FontStyle.Regular;
                    break;
            }

            derModus = newMode;

            group_playlist.Font = new Font(group_playlist.Font, fs);
            lV_tracks.Font = new Font(lV_tracks.Font, fs);

        }

        public void Listbox_SetContent(string[] contents, string[] information)
        {
            lV_tracks.Items.Clear();
            ListViewItem[] contents_listview = new ListViewItem[contents.Length];
            for (int i = 0; i < contents_listview.Length; i++)
            {
                contents_listview[i] = new ListViewItem(contents[i]);
                if (information != null)
                {
                    contents_listview[i].ToolTipText = information[i];
                }
            }
            lV_tracks.Items.AddRange(contents_listview);
        }

        public void Listbox_PaintAddedSongs(params int[] addedSongs)
        {
            diff_add_songs = addedSongs.Length;

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
            diff_rem_songs = removedSongs.Length;

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

        public void SetPlaylistInfo(string playlist_name, string playlist_author, int playlist_songscount, DateTime accessTime)
        {
            lbl_playlist_Name.Text = "Playlist: " + playlist_name;
            lbl_playlist_author.Text = "von: " + playlist_author;
            lbl_playlist_songanz.Text = "Songs#: " + playlist_songscount.ToString();
            lbl_playlist_access.Text = "Zugriff: " + accessTime.ToLongTimeString();
        }

        public void ResetAfterCommit()
        {
            lV_tracks.Items.Clear();
            lbl_diffindicator.Text = "";
            menu_commit_save.Enabled = false;
        }

        public void ReminderUI_Clicked()
        {
            setHiddenStatus(false);
        }

        public void UpdateDiffindicator()
        {
            string build = "";
            bool isAdd = diff_add_songs > 0;
            bool isRem = diff_rem_songs > 0;
            bool isDiff = isAdd || isRem;

            //inhaltliches
            if (isAdd)
            {
                build += diff_add_songs + " ADD";
                if (isRem)
                {
                    build += "; ";
                }
            }
            if (isRem)
            {
                build += diff_rem_songs + " REM";
            }

            //Farbliches
            if (isDiff)
            {
                lbl_diffindicator.Text = build;
                lbl_diffindicator.ForeColor = Color.OrangeRed;
            }
            else
            {
                lbl_diffindicator.Text = "Keine Veränderung!";
                lbl_diffindicator.ForeColor = Color.Black;
            }
        }

        public void ShowLoadingIcon(bool show)
        {
            pB_api_loading.Visible = show;
        }

        private async void initShadowMode()
        {
            if (shadowMode)
            {
                await dieSteuerung.InitializeAPIAsync();
                ChangeMode(GUIMode.Hidden);
                dieSteuerung.StartPlaylistListener();
            }
        }

        private void setGUILock(bool locked)
        {
            lV_tracks.Enabled = !locked;
            group_playlist.Enabled = !locked;
        }

        private void setGUIMenuLock(bool locked)
        {
            menu_main.Enabled = !locked;
            menu_extras.Enabled = true; //Extras immer an
        }

        private void setHiddenStatus(bool newValue)
        {
            if (newValue)
            {
                Hide();
                _infoIcon.Visible = true;
            }
            else
            {
                Show();
                _infoIcon.Visible = false;
            }
        }

        private async void GUI_Load(object sender, EventArgs e)
        {
            if (!api_init)
                await dieSteuerung.InitializeAPIAsync();
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
                    bool success = dieSteuerung.TracksToGUI();
                    int gleich = await dieSteuerung.PerformCompare();
                    menu_commit_save.Enabled = (gleich == 0) ? true : false;
                }
                catch
                {
                    ShowMessage("Ein Fehler ist beim Laden aufgetreten");
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

        private async void menu_playlist_refresh_Click(object sender, EventArgs e)
        {
            await dieSteuerung.RefreshPlaylistDataAsync();
        }

        private void menu_extras_optionen_Click(object sender, EventArgs e)
        {
            dieSteuerung.ShowOptionsDialog();
        }

        private async void b_debug_initapi_Click(object sender, EventArgs e)
        {
            await dieSteuerung.InitializeAPIAsync();
        }

        private void _infoIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            setHiddenStatus(false);
        }

        private void GUI_SizeChanged(object sender, EventArgs e)
        {
            //Minimized
            setHiddenStatus(true);
        }
    }
}
