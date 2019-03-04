using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifySimpleManager
{
    class Commit
    {
        private string playlist_id;
        private string[] uri_added;
        private int[] uri_removed;
        private string[] uri_old;
        private DateTime _timestamp;

        public Commit(string playlist_id, string[] uri_added, int[] uri_removed, string[] uri_old)
        {
            this.playlist_id = playlist_id; //obv.
            this.uri_added = uri_added; //Die hinzugefügten URIs
            this.uri_removed = uri_removed; //Die Indizes der entfernten Songs (uri_alt)
            this.uri_old = uri_old; //Die alte Liste der Songs
            _timestamp = DateTime.Now;
        }

        public Commit(DateTime timestamp, string playlist_id, string[] uri_added, int[] uri_removed, string[] uri_old)
        {
            this.playlist_id = playlist_id; //obv.
            this.uri_added = uri_added; //Die hinzugefügten URIs
            this.uri_removed = uri_removed; //Die Indizes der entfernten Songs (uri_alt)
            this.uri_old = uri_old; //Die alte Liste der Songs
            _timestamp = timestamp;
        }

        public string GetPlaylistId() => playlist_id;
        public string[] GetAdded() => uri_added;
        public int[] GetRemoved() => uri_removed;
        public string[] GetOld() => uri_old;

        public string GetKomplettpaket()
        {
            //I: Header
            string header = "# " + _timestamp.ToShortDateString() + " ~ " + _timestamp.ToShortTimeString() + "\n";
            header += "# Playlist: " + playlist_id + "\n";
            string header_indexes; //Hilft beim auslesen eines commits später
            //II: URI ADD
            int idx_add = 6; //Festgelegt

            string uri_add_teil = "";
            for (int i = 0; i < uri_added.Length; i++)
            {
                uri_add_teil += uri_added[i] + "\n";
            }
            //III: URI REM
            int idx_rem = idx_add + uri_added.Length + 1; //+1 wegen leerzeile

            string uri_rem_teil = "";
            for (int i = 0; i < uri_removed.Length; i++)
            {
                uri_rem_teil += uri_removed[i] + "\n";
            }
            //IV: URI OLD Liste
            int idx_old = idx_rem + uri_removed.Length + 1; //+1 wegen leerzeile

            string uri_old_teil = "";
            for (int i = 0; i < uri_old.Length; i++)
            {
                uri_old_teil += uri_old[i];
                if (i != uri_old.Length - 1)
                {
                    uri_old_teil += "\n";
                }
            }

            //V: JOIN
            header_indexes =
                "# ADD:" + idx_add + "\n" +
                "# REM:" + idx_rem + "\n" +
                "# OLD:" + idx_old + "\n";
            string[] returns_array =
            {
                header,//2 Zeilen
                header_indexes,//3 Zeilen
                "\n", //Leerzeile
                uri_add_teil,
                "\n", //Leer
                uri_rem_teil,
                "\n", //Leer
                uri_old_teil
            };

            string returns = "";
            foreach (string item in returns_array)
            {
                returns += item;
            }
            return returns;
        }
    }
}
