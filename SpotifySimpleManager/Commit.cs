using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifySimpleManager
{
    class Commit
    {
        private string playlist_uri;
        private string[] uri_added;
        private string[] uri_removed;
        private string[] uri_new;
        private DateTime _timestamp;

        public Commit(string playlist_uri, string[] uri_added, string[] uri_removed, string[] uri_new)
        {
            this.playlist_uri = playlist_uri;
            this.uri_added = uri_added;
            this.uri_removed = uri_removed;
            this.uri_new = uri_new;
            _timestamp = DateTime.Now;
        }

        public string GetKomplettpaket()
        {
            //I: Header
            string header = "# " + _timestamp.ToShortDateString() + " ~ " + _timestamp.ToShortTimeString() + "\n";
            header += "# Playlist: " + playlist_uri + "\n";
            string header_indexes; //Hilft beim auslesen eines commits später
            //II: URI ADD
            int idx_add = 7; //Festgelegt

            string uri_add_teil = "";
            for (int i = 0; i < uri_added.Length; i++)
            {
                uri_add_teil += uri_added[i];
            }
            //III: URI REM
            int idx_rem = idx_add + uri_added.Length + 1; //+1 wegen leerzeile

            string uri_rem_teil = "";
            for (int i = 0; i < uri_removed.Length; i++)
            {
                uri_rem_teil += uri_removed[i];
            }
            //IV: URI NEW Liste
            int idx_new = idx_rem + uri_removed.Length + 1; //+1 wegen leerzeile

            string uri_new_teil = "";
            for (int i = 0; i < uri_new.Length; i++)
            {
                uri_new_teil += uri_new[i];
                if (i != uri_removed.Length - 1)
                {
                    uri_new_teil += "\n";
                }
            }

            //V: JOIN
            header_indexes =
                "# ADD:" + idx_add + "\n" +
                "# REM:" + idx_rem + "\n" +
                "# NEW:" + idx_new + "\n";
            string[] returns_array =
            {
                header,//2 Zeilen
                header_indexes,//3 Zeilen
                "\n", //Leerzeile
                uri_add_teil,
                "\n", //Leer
                uri_rem_teil,
                "\n", //Leer
                uri_new_teil
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
