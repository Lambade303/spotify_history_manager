using System;
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

        SpotifyWebAPI api;
        FullPlaylist l303;
        List<PlaylistTrack> l303_tracks;

        private string savefilepath;

        public Steuerung(GUI pGUI)
        {
            dieGUI = pGUI;
            dieDaten = new Daten();
        }

        public async void InitializeAPIAsync() //Nach GUI-Load aufgerufen
        {
            //AUTHORIZATION
            SpotifyAPI.Web.Auth.CredentialsAuth auth = new SpotifyAPI.Web.Auth.CredentialsAuth("a9936dcafc7e4ffbad01ea306fc4b267", "6f103a536bf6432892fc44f9eed19ba2");
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
            l303 = api.GetPlaylist("lambade303", "6YiI6sO5TyAtHDYanlKIjM"); //Codeb.: 6YiI6sO5TyAtHDYanlKIjM; Lambade: 0Yk8TlHuFCGELX2EZHTRZ4
            l303_tracks = await getTracksAsync();
        }

        public bool TracksToGUI()
        {
            try
            {
                string[] returns = new string[l303_tracks.Count];
                for (int i = 0; i < returns.Length; i++)
                {
                    returns[i] = l303_tracks[i].Track.Name;
                }

                dieGUI.SetListBoxContent(returns);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void TracksAsDump()
        {
            string[] uris = new string[l303_tracks.Count];
            for (int i = 0; i < uris.Length; i++)
            {
                uris[i] = l303_tracks[i].Track.Uri;
            }
            dieDaten.SaveURIsToFile(uris);
        }

        public void CompareRequest()
        {
            //Spotify URIs schaben
            // I: Aktuelle Liste laden
            string[] uri_NEU = new string[l303_tracks.Count];
            for (int i = 0; i < uri_NEU.Length; i++)
            {
                uri_NEU[i] = l303_tracks[i].Track.Uri;
            }
            // II: Dateiliste laden
            string[] uri_ALT = dieDaten.GetURIsFromFile();

            // III: CHECKADD (uri_add-Liste) (FROM: NEU, TO: ALT)
            int[] uri_add = checkDiff(uri_NEU, uri_ALT);

            //IV: CHECKREM (uri_rem-Liste) (FROM: ALT, TO: NEU)
            int[] uri_rem = checkDiff(uri_ALT, uri_NEU);

            //Output GUI
            string info = "Hinzugefügt: \n";
            for (int i = 0; i < uri_add.Length; i++)
            {
                info += uri_NEU[uri_add[i]] + "\n";
            }

            info += "\nEntfernt:\n";
            for (int i = 0; i < uri_rem.Length; i++)
            {
                info += uri_ALT[uri_rem[i]] + "\n";
            }
            dieGUI.ShowMessage(info);
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
