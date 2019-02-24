﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotifyAPI;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Models;

namespace SpotifySimpleManager
{
    class Steuerung
    {
        GUI dieGUI;
        Daten dieDaten;
        Commit derCommit;
        Listener derListener;

        SpotifyWebAPI api;
        FullPlaylist l303;
        List<PlaylistTrack> l303_tracks;


        bool areDiffTracksMarked;
        bool isPlaylistOnGUI;

        public Steuerung(GUI pGUI)
        {
            dieGUI = pGUI;
            dieDaten = new Daten();
            derListener = new Listener();
            derListener.OnFullHour += DerListener_OnFullHour;
        }

        public async void InitializeAPIAsync() //Nach GUI-Load aufgerufen
        {
            //AUTHORIZATION
            CredentialsAuth auth = new CredentialsAuth("a9936dcafc7e4ffbad01ea306fc4b267", "6f103a536bf6432892fc44f9eed19ba2");
            Token t = await auth.GetToken();

            //Erroranzeige-GUI
            {
                bool fehler = t.HasError();
                dieGUI.SetInitSuccess(!fehler);
            }

            api = new SpotifyWebAPI()
            {
                AccessToken = t.AccessToken,
                TokenType = t.TokenType,
            };

            //Lambade303 laden:
            await RefreshPlaylistDataAsync();
        }

        public async Task RefreshPlaylistDataAsync()
        {
            l303 = api.GetPlaylist("lambade303", "0Yk8TlHuFCGELX2EZHTRZ4"); //Codeb.: 6YiI6sO5TyAtHDYanlKIjM; Lambade: 0Yk8TlHuFCGELX2EZHTRZ4
            l303_tracks = await getTracksAsync();

            dieGUI.SetPlaylistInfo(l303.Name, l303.Owner.DisplayName, l303.Tracks.Total);

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
            dieDaten.SaveURIsToFile(uris, l303.Uri, l303.Name);
        }

        /// <summary>
        /// <para>Startet den Vergleich.</para>
        /// <para>Returns: </para>
        /// <para>false - Playlist ist Gleich (Unverändert zu letztem Dump)</para>
        /// <para>true - Playlist ist Verschieden (Verändert zu letztem Dump)</para>
        /// </summary>
        /// <returns></returns>
        public async Task<bool> PerformCompare()
        {
            bool gleich = true;
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
                string[] uri_ALT = dieDaten.GetURIsFromFile(l303.Uri);

                // III: CHECKADD (uri_add-Liste) (FROM: NEU, TO: ALT)
                int[] uri_add = checkDiff(uri_NEU, uri_ALT);
                if (uri_add.Length > 0)
                    gleich = false;

                string[] uri_add_s = new string[uri_add.Length]; //Für Commit
                for (int i = 0; i < uri_add_s.Length; i++)
                {
                    uri_add_s[i] = uri_NEU[uri_add[i]];
                }

                //IV: CHECKREM (uri_rem-Liste) (FROM: ALT, TO: NEU)
                int[] uri_rem = checkDiff(uri_ALT, uri_NEU);
                if (uri_rem.Length > 0)
                    gleich = false;

                if (!gleich)
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
                    derCommit = new Commit(l303.Uri, uri_add_s, uri_rem, uri_ALT);
                }
            }
            return gleich;
        }

        public void SaveCommit()
        {
            if (derCommit != null)
            {
                dieDaten.PerformCommit(derCommit);
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
        }

        public void InvokeOnFullHour() //Nur Debug
        {
            DerListener_OnFullHour(this, new EventArgs());
        }

        private async void DerListener_OnFullHour(object sender, EventArgs e)
        {
            //Hier wird der Toast aufgerufen, falls ein Commit nötig ist.
            await RefreshPlaylistDataAsync();
            bool brauchtUpdate = !await PerformCompare(); //Returned ob die Playlist gleich ist, daher invert
            if (brauchtUpdate)
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
