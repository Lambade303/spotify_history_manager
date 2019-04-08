using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifySimpleManager
{
    public class Options
    {
        public string Commitspeicherort { get; set; }
        public string Username { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string Playlist { get; set; }
        public string Origin { get; set; } //Dateipfad

        public Options(ConfigJson c, string origin, string commitspeicher)
        {
            Commitspeicherort = commitspeicher;
            Username = c.Username;
            ClientId = c.ClientId;
            ClientSecret = c.ClientSecret;
            Playlist = c.Playlist;
            Origin = origin;
        }
    }
}
