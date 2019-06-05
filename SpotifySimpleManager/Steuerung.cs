using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotifyAPI;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Models;
using Newtonsoft.Json;

namespace SpotifySimpleManager
{
    class Steuerung
    {
        GUI dieGUI;
        Daten dieDaten;
        Commit derCommit;
        Listener derListener;
        OptionsUI dieOptions;

        Options _opt;
        SpotifyWebAPI api;
        FullPlaylist l303;
        List<PlaylistTrack> l303_tracks;


        private string configFilepath = "./conf.json"; //Bei Debug conf.json ins Ausgabeverzeichnis kopieren lassen!
        bool areDiffTracksMarked;
        bool isPlaylistOnGUI;

        public Steuerung(GUI pGUI)
        {
            dieGUI = pGUI;
            dieDaten = new Daten();
            derListener = new Listener();
            dieOptions = new OptionsUI();
            derListener.OnFullHour += DerListener_OnFullHour;

            string commitspeicher = dieDaten.Speicherort;

            ConfigJson json = ConfigJson.DeserializeFile(configFilepath);
            _opt = new Options(json, configFilepath, commitspeicher);
        }

        public async Task InitializeAPIAsync() //Nach GUI-Load aufgerufen
        {
            dieGUI.ChangeMode(GUIMode.Lock);

            //AUTHORIZATION
            string id = _opt.ClientId;
            string secret = _opt.ClientSecret;

            try
            {
                CredentialsAuth auth = new CredentialsAuth(id, secret);
                Token t = await auth.GetToken();
                bool fehler = t.HasError();
                dieGUI.SetInitSuccess(!fehler);

                api = new SpotifyWebAPI()
                {
                    AccessToken = t.AccessToken,
                    TokenType = t.TokenType,
                };

                GUIMode g = fehler ? GUIMode.Lock : GUIMode.Diff;
                dieGUI.ChangeMode(g);

                //Playlist laden: (5x retries)
                int retries = 0;
                bool exit = false;
                do
                {
                    try
                    {
                        await RefreshPlaylistDataAsync();
                        exit = true;
                    }
                    catch
                    {
                        retries++;
                    }
                } while (retries < 5 && !exit);
            }
            catch //Keine Verbindung
            {
                dieGUI.ShowMessage("Error bei der Verbindung zum Spotify-Server.");
                dieGUI.ChangeMode(GUIMode.BrokenDiff);
            }
        }

        public async Task RefreshPlaylistDataAsync()
        {
            string userid = _opt.Username;
            string playlistid = _opt.Playlist;
            dieGUI.ShowLoadingIcon(true);

            l303 = api.GetPlaylist(userid, playlistid);//Codeb.: 6YiI6sO5TyAtHDYanlKIjM; Lambade: 0Yk8TlHuFCGELX2EZHTRZ4
            l303_tracks = await getTracksAsync();
            dieGUI.ShowLoadingIcon(false);

            dieGUI.ChangeMode(GUIMode.Diff);
            dieGUI.SetPlaylistInfo(l303.Name, l303.Owner.DisplayName, l303.Tracks.Total, DateTime.Now);
            isPlaylistOnGUI = false;
        }

        public void StartPlaylistListener()
        {
            //Methode: Manuell; Wenn Von Nöten Erinnerung jd.Std.
            derListener.Start();
            dieGUI.ShowToast("Playlist-Listener gestartet für: " + l303.Name);
        }

        public void StopPlaylistListener()
        {
            derListener.Stop();
            dieGUI.ShowToast("Playlist-Listener gestoppt für: " + l303.Name);
        }

        public bool TracksToGUI()
        {
            try
            {
                string[] returns = new string[l303_tracks.Count];
                string[] infos = new string[l303_tracks.Count];

                for (int i = 0; i < returns.Length; i++)
                {
                    returns[i] = l303_tracks[i].Track.Name;

                    SimpleArtist[] a = l303_tracks[i].Track.Artists.ToArray();
                    string[] a_name = new string[a.Length];
                    for (int j = 0; j < a.Length; j++)
                    {
                        a_name[j] = a[j].Name;
                    }

                    infos[i] = "URI: " + l303_tracks[i].Track.Uri + "\n" +
                        "Künstler: " + String.Join(", ", a_name);
                }

                dieGUI.Listbox_SetContent(returns, infos);
                areDiffTracksMarked = false;

                isPlaylistOnGUI = true;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void TracksAsDump()
        {
            ///WIRD SPÄTER BEI LISTENER AUSGEFÜHRT

            string[] uris = new string[l303_tracks.Count];
            for (int i = 0; i < uris.Length; i++)
            {
                uris[i] = l303_tracks[i].Track.Uri;
            }
            dieDaten.SaveURIsToFile(uris, l303.Id, l303.Name);
        }

        /// <summary>
        /// <para>Startet den Vergleich.</para>
        /// <para>Returns: </para>
        /// <para>1 - Playlist ist Gleich (Unverändert zu letztem Dump)</para>
        /// <para>0 - Playlist ist Verschieden (Verändert zu letztem Dump)</para>
        /// <para>-1 - Ein Fehler ist aufgetreten.</para>
        /// </summary>
        /// <returns></returns>
        public async Task<int> PerformCompare()
        {
            int gleich = 1;
            if (!areDiffTracksMarked) //nur ausführen, wenn die Tracks nicht gemarked sind
            {
                //Spotify URIs schaben
                // I: Aktuelle Liste laden
                string[] uri_NEU = new string[l303_tracks.Count];
                for (int i = 0; i < uri_NEU.Length; i++)
                {
                    uri_NEU[i] = l303_tracks[i].Track.Uri;
                }
                // II: Dateiliste laden
                string[] uri_ALT = dieDaten.GetURIsFromFile(l303.Id);

                if (uri_ALT == null)
                    return -1;

                // III: CHECKADD (uri_add-Liste) (FROM: NEU, TO: ALT)
                int[] uri_add = checkDiff(uri_NEU, uri_ALT);
                if (uri_add.Length > 0)
                    gleich = 0;

                string[] uri_add_s = new string[uri_add.Length]; //Für Commit
                for (int i = 0; i < uri_add_s.Length; i++)
                {
                    uri_add_s[i] = uri_NEU[uri_add[i]];
                }

                //IV: CHECKREM (uri_rem-Liste) (FROM: ALT, TO: NEU)
                int[] uri_rem = checkDiff(uri_ALT, uri_NEU);
                if (uri_rem.Length > 0)
                    gleich = 0;

                if (gleich == 0)
                {
                    //V: Output GUI
                    if (isPlaylistOnGUI)
                    {
                        dieGUI.Listbox_PaintAddedSongs(uri_add);

                        //V.1: REMOVED SONGS neu-hinzufügen
                        for (int i = 0; i < uri_rem.Length; i++)
                        {
                            int gui_deletedIndex = uri_rem[i];
                            string songname = await getTrackNameAsync(uri_ALT[gui_deletedIndex]);
                            dieGUI.Listbox_AddItem(songname, gui_deletedIndex); // Das i-te gelöschte Item (indiziert aus Datei-Uri) wird hinzugefügt
                        }
                        dieGUI.Listbox_PaintRemovedSongs(uri_rem);
                        areDiffTracksMarked = true;
                    }
                    derCommit = new Commit(l303.Id, uri_add_s, uri_rem, uri_ALT);
                }

                dieGUI.UpdateDiffindicator();
            }
            return gleich;
        }

        public void SaveCommit()
        {
            if (derCommit != null)
            {
                dieDaten.PerformCommit(derCommit);
                dieGUI.ResetAfterCommit();
                areDiffTracksMarked = false;
                isPlaylistOnGUI = false;
                dieGUI.ShowMessage("Commit erfolgreich abgespeichert!");
            }
            else
            {
                dieGUI.ShowMessage("Commit nicht möglich!\nBitte erneut ausführen.");
            }
        }

        public async void LoadCommit(string pathName)
        {
            //Commit holen
            derCommit = dieDaten.GetCommitAt(pathName);

            //Commit anzeigen
            string[] tracks = derCommit.GetOld();
            tracks = await getSeveralTracksNamesAsync(tracks);

            dieGUI.Listbox_SetContent(tracks, null);

            string[] addedTracksItems = derCommit.GetAdded();
            string[] addedTracksNames = await getSeveralTracksNamesAsync(addedTracksItems);
            for (int i = 0; i < addedTracksItems.Length; i++)
            {
                string track_name = addedTracksNames[i];
                int index = dieGUI.Listbox_AddItem(track_name);
                dieGUI.Listbox_PaintAddedSongs(index);
            }

            int[] uri_rem = derCommit.GetRemoved();
            dieGUI.Listbox_PaintRemovedSongs(uri_rem);

            dieGUI.UpdateDiffindicator();

            //GUI-Modus ändern und Playlist-Infos anzeigen
            dieGUI.ChangeMode(GUIMode.Load);
            string id = derCommit.GetPlaylistId();
            if (id != l303.Id) //Wenn Id nicht gleich bereits geladener Id ist
            {
                FullPlaylist playl = await api.GetPlaylistAsync("lambade303", id);
                dieGUI.SetPlaylistInfo(playl.Name, playl.Owner.DisplayName, playl.Tracks.Total, DateTime.Now);
            }
        }

        public void InvokeOnFullHour() //Nur Debug
        {
            DerListener_OnFullHour(this, new EventArgs());
        }

        public void LockGUI(bool locked) //Nur Debug
        {
            if (locked)
                dieGUI.ChangeMode(GUIMode.Lock);
            else
                dieGUI.ChangeMode(GUIMode.Diff);
        }

        public void ShowOptionsDialog()
        {
            dieOptions.LoadOptions(_opt);
            System.Windows.Forms.DialogResult d = dieOptions.ShowDialog();
            if (d == System.Windows.Forms.DialogResult.Yes) // Yes bei Change - No bei KeinChange
            {
                _opt = dieOptions.GetOptionsData();
            }
        }

        private async void DerListener_OnFullHour(object sender, EventArgs e)
        {
            //Hier wird der Toast aufgerufen, falls ein Commit nötig ist.
            int retries = 0;
            bool exit = false;
            do
            {
                try
                {
                    await RefreshPlaylistDataAsync();
                    exit = true;
                }
                catch
                {
                    retries++;
                }
            } while (retries < 5 && !exit);


            int playlistIstGleich = await PerformCompare(); //Returned ob die Playlist gleich ist, daher invert


            if (playlistIstGleich == 0)
            {
                dieGUI.ShowToast("Die Playlist " + l303.Name + " ist nicht mehr synchronisiert.\nEin Commit ist nötig!");
            }
        }

        /// <summary>
        /// Holt bei bekannter URI den entsprechenden Songnamen per API
        /// </summary>
        /// <param name="uri">Die bekannte URI.</param>
        /// <returns></returns>
        private async Task<string> getTrackNameAsync(string uri)
        {
            string id = uri.Substring(14); //Konstante
            FullTrack t = await api.GetTrackAsync(id);
            return t.Name;
        }

        private async Task<string[]> getSeveralTracksNamesAsync(string[] uris)
        {
            string[] id = new string[uris.Length];
            for (int i = 0; i < id.Length; i++)
            {
                id[i] = uris[i].Substring(14);
            }

            string[] tracksNames = new string[uris.Length];
            for (int i = 0; i < uris.Length; i += 50)
            {
                int amount = (i + 50 > uris.Length) ? uris.Length - i : 50;
                SeveralTracks s = await api.GetSeveralTracksAsync(id.ToList().GetRange(i, amount)); //Gettet nur 50x

                for (int j = 0; j < s.Tracks.Count; j++)
                {
                    tracksNames[i + j] = s.Tracks[j].Name;
                }
            }

            return tracksNames;
        }

        /// <summary>
        /// Verglichen wird FROM zu TO
        /// </summary>
        /// <param name="pCompareFrom">Das Array, von dem ausgegangen wird</param>
        /// <param name="pCompareTo">Das Array, das dann gescannt wird</param>
        /// <returns></returns>
        private int[] checkDiff(string[] pCompareFrom, string[] pCompareTo)
        {
            List<int> returns = new List<int>();

            for (int i = 0; i < pCompareFrom.Length; i++)
            {
                bool gefunden = false;
                for (int j = 0; j < pCompareTo.Length; j++)
                {
                    if (pCompareFrom[i] == pCompareTo[j])
                    {
                        gefunden = true;
                        break;
                    }
                }
                if (!gefunden)
                {
                    returns.Add(i);
                }
            }

            return returns.ToArray();
        }

        private async Task<List<PlaylistTrack>> getTracksAsync()
        {
            int songsInPlaylist = l303.Tracks.Total;
            List<PlaylistTrack> l303_tracks = new List<PlaylistTrack>();
            Paging<PlaylistTrack> l303_request;

            for (int i = 0; i < songsInPlaylist; i += 100)
            {
                l303_request = await api.GetPlaylistTracksAsync("lambade303", l303.Id, "", 100, i); //Offset = i, Limit = 100 (Max.)
                l303_tracks.AddRange(l303_request.Items);
            }

            return l303_tracks;
        }
    }
}
