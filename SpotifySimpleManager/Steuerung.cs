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

        SpotifyWebAPI api;
        FullPlaylist l303;
        List<PlaylistTrack> l303_tracks;

        private string savefilepath;

        public Steuerung(GUI pGUI)
        {
            dieGUI = pGUI;
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
            l303 = api.GetPlaylist("lambade303", "0Yk8TlHuFCGELX2EZHTRZ4");
            l303_tracks = await getTracksAsync();
        }

        public string[] GetTrackTitles()
        {
            string[] returns = new string[l303_tracks.Count];
            for (int i = 0; i < returns.Length; i++)
            {
                returns[i] = l303_tracks[i].Track.Name;
            }

            return returns;
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
